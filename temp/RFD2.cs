using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

namespace RiverFormationDynamics
{
    public class RFD2 : SwarmAlgorithm2
    {
        //private static readonly object _locker = new object();
        //private static ReaderWriterLockSlim _rw = new ReaderWriterLockSlim();

        //private Task[] _movingTasks;
        private List<NodeXY> _nodes;
        private Drop2[] _drops;
        private List<int> _bestPath;
        private int _source;
        private int _target;
        private double _initNodeHeight;
        private double _erosionProduced;
        private double _delta;
        private double _omega;
        private double _paramErosion;
        private double _paramBlockedDrop;
        private double _bestPathLength;
        private double _eFlat;
        private double _eUp;
        private double _pBase;
        private double _pEBase;

        #region Properties
        public List<int> BestPath
        {
            get
            {
                return _bestPath;
            }
        }
        public int Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
            }
        }
        public int Target
        {
            get
            {
                return _target;
            }
            set
            {
                double h = 0;
                for (int i = 0; i < _nodes[_target].Neighbours.Count; i++)
                {
                    h += _nodes[_target].Neighbours[i].Height;
                }
                h /= _nodes[_target].Neighbours.Count;
                _nodes[_target].Height = h;
                _target = value;
                _nodes[_target].Height = 0;
            }
        }
        #endregion

        public RFD2(int populationSize, List<NodeXY> nodes, double initNodeHeight)
            : base(populationSize)
        {
            _nodes = new List<NodeXY>(nodes);
            _initNodeHeight = initNodeHeight;

            _delta = 0.1;
            _omega = 0.005;
            _paramErosion = 1;
            _paramBlockedDrop = 1;

            _eFlat = 0.001;
            _eUp = 0.0001;

            double maxPBase = 5.0;
            double pow = 1.0 / 100.0;
            _pBase = Math.Pow(maxPBase, pow);
            double maxErosion = 1.0;
            _pEBase = Math.Pow(maxErosion, pow);
        }

        public double[] GetNodeHeight()
        {
            double[] nodeHeight = new double[_nodes.Count];

            for (int i = 0; i < _nodes.Count; i++)
            {
                nodeHeight[i] = _nodes[i].Height;
            }

            return nodeHeight;
        }

        public List<int> FindPath(int source, int target, int maxIter, out List<double> bestPathHistory)
        {
            Source = source;
            Target = target;
            _nodes[_target].Height = 0.0;
            int iter = 0, iterBest = 0, maxIterBest = 3000;
            double notClimbingFactor = 1.0;
            _bestPathLength = 999999.0;
            bestPathHistory = new List<double>(maxIter);
            _bestPath = new List<int>();
            //List<int> bestPath = new List<int>();
            //targetOld = new Point(target.X, target.Y);
            initializeDrops();

            do
            {
                iter++;
                iterBest++;
                _erosionProduced = 0.0;
                double p_climbing = 1.0 / notClimbingFactor;

                moveDrops(p_climbing);
                DepositSediment();
                //AnalyzePaths(ref bestPath, ref bestPathLength, ref iterBest);
                bestPathHistory.Add(_bestPathLength);
                notClimbingFactor += 0.01;
            } while (!EndCondition(iter, maxIter, iterBest, maxIterBest));
            
            return _bestPath;
        }

        private void moveDrops(double climbingProbability)
        {
            //_movingTasks = new Task[_populationSize];

            for (int i = 0; i < _populationSize; i++)
            {
                int d = i;
                moveDrop(_drops[d], climbingProbability);
                //_movingTasks[d] = Task.Factory.StartNew(() => moveDrop(_drops[d], climbingProbability));
                //_movingTasks[d] = Task.Factory.StartNew(delegate { moveDrop(_drops[d], climbingProbability); });
            }

            //try
            //{
            //    Task.WaitAll(_movingTasks);
            //}
            //catch (AggregateException e)
            //{
            //    throw (e);
            //}

            //var ff = Parallel.For(0, popSize, i => moveDrop(drops[i], source, target, map, climbingProbability));
        }

        private void moveDrop(Drop2 drop, double climbingProbability)
        {
            drop.evaporated = false;
            drop.canClimb = false;
            drop.path = new List<int>();
            drop.pathLength = 0.0;
            drop.sediment = 0.0;
            drop.currentNode = _nodes[_source];
            drop.path.Add(_source);

            double rC = _rng.NextDouble();
            if (rC <= climbingProbability)
            {
                drop.canClimb = true;
            }

            while (drop.currentNode.Index != _target && !drop.evaporated)
            {
                int nextNodeIdx = PickNextNode(drop.currentNode);
                NodeXY nextNode = drop.currentNode.Neighbours[nextNodeIdx];

                if (drop.path.Count >= _nodes.Count)
                {
                    drop.evaporated = true;
                    break;
                }

                drop.pathLength += drop.currentNode.NeighbourDistance[nextNodeIdx];
                drop.currentNode = nextNode;
                drop.path.Add(nextNode.Index);
            }

            if (drop.evaporated)
            {
                
            }
            else
            {
                ErodePath(drop);

                if (drop.pathLength < drop.bestPathLength)
                {
                    drop.bestPathLength = drop.pathLength;
                    drop.bestPath = new List<int>(drop.path);
                }

                if (drop.pathLength < _bestPathLength)
                {
                    _bestPathLength = drop.pathLength;
                    _bestPath = new List<int>(drop.path);
                }
            }
        }

        private void ErodePath(Drop2 drop)
        {
            for (int i = 0; i < drop.path.Count - 1; i++)
            {
                NodeXY a = _nodes[drop.path[i]];
                NodeXY b = _nodes[drop.path[i + 1]];
                double erosion = CalculateErosion(a, b) / drop.pathLength;
                a.Height -= erosion;
                _erosionProduced += erosion;
            }
        }

        private double CalculateErosion(NodeXY node1, NodeXY node2)
        {
            double gradient = node1.Height - node2.Height;
            double g = (gradient / _initNodeHeight) * 100.0;
            
            double erosion;

            if (gradient > 0.0)
            {
                //erosion = (_paramErosion / ((_nodes.Count - 1) * _populationSize)) * gradient;
                erosion = Math.Pow(_pEBase, gradient);
            }
            else if (gradient == 0.0)
            {
                erosion = _eFlat;
                //erosion = Math.Pow(pEBase_, gradient);
            }
            else
            {
                erosion = _eUp;
                //erosion = Math.Pow(pEBase_, gradient);
            }

            return erosion;
        }

        private int PickNextNode(NodeXY currentNode)
        {
            List<NodeXY> neighbours = currentNode.Neighbours;

            double[] probs = new double[neighbours.Count];

            for (int i = 0; i < neighbours.Count; i++)
            {
                if (neighbours[i].Status == 1)
                {
                    double gradient;
                    probs[i] = CalculateProb(currentNode, neighbours[i], out gradient, currentNode.NeighbourDistance[i]);
                }
            }

            return _rouletteWheel.ChooseAction(probs);
        }

        private double CalculateProb(NodeXY node1, NodeXY node2, out double gradient, double dist)
        {
            gradient = node1.Height - node2.Height;
            double p;
            double g = (gradient / _initNodeHeight) * 100.0;
            double pp = Math.Sqrt(Math.Pow(_nodes[Target].Coords.X - node2.Coords.X, 2) + Math.Pow(_nodes[Target].Coords.Y - node2.Coords.Y, 2)); ;
            
            if (gradient > 0)
            {
                //p = gradient / (dist + 1);
                //p = gradient;
                //p = Math.Pow(pBase, gradient) / (dist + 1) + pSeed;
                p = Math.Pow(_pBase, g);
            }
            else if (gradient == 0)
            {
                p = Math.Pow(_pBase, g);
                //p = rng.NextDouble() / 10;
                //p = Math.Pow(pBase, gradient) / (dist + 1) + pSeed;
                //p = delta / Distance(w, currentNode);
                //p = delta / (dist + 1);
                //p = _delta;
            }
            else
            {
                p = Math.Pow(_pBase, g);
                //p = _omega;
                //p = omega / (gradient * -1) / (dist + 1);
                //p = _omega / (gradient * -1);
                //p = Math.Pow(pBase, gradient) / (dist + 1) + pSeed;
            }

            return p / Math.Pow(5, pp);
        }

        private void DepositSediment()
        {
            double sediment = _erosionProduced / _nodes.Count;

            for (int i = 0; i < _nodes.Count; i++)
            {
                _nodes[i].Height += sediment;
                if (_nodes[i].Height > _initNodeHeight)
                {
                    _nodes[i].Height = _initNodeHeight;
                }
            }

            _nodes[_target].Height = 0.0;
        }

        private void initializeNodes()
        {
            
        }

        private void initializeDrops()
        {
            _drops = new Drop2[_populationSize];
            for (int i = 0; i < _populationSize; i++)
            {
                _drops[i] = new Drop2();
            }
        }

        private bool EndCondition(int iter, int maxIter, int iterBest, int maxIterBest)
        {
            if (iter >= maxIter || iterBest >= maxIterBest)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
