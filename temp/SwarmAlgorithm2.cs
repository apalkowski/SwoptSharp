using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiverFormationDynamics
{
    public abstract class SwarmAlgorithm2
    {
        protected int _populationSize;
        protected static Random _rng;
        protected static RouletteWheelSelection _rouletteWheel;

        public SwarmAlgorithm2(int populationSize)
        {
            _populationSize = populationSize;
            _rng = new Random();
            _rouletteWheel = new RouletteWheelSelection(_rng);
        }
    }
}
