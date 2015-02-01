using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverFormationDynamics
{
    class Drop2
    {
        public double sediment;
        public List<int> path;
        public double pathLength;
        public List<int> bestPath;
        public double bestPathLength;
        public bool evaporated;
        public bool canClimb;
        public NodeXY currentNode;

        public Drop2()
        {
            sediment = 0;
            path = new List<int>();
            pathLength = 0;
            bestPath = new List<int>();
            bestPathLength = 999999;
            evaporated = false;
            canClimb = false;
            currentNode = null;
        }
    }
}
