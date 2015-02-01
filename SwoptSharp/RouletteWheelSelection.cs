using System;

namespace SwoptSharp
{
    public class RouletteWheelSelection
    {
        #region Private Fields

        private Random rng;

        #endregion Private Fields

        #region Public Constructors

        public RouletteWheelSelection()
            : this(null)
        {
        }

        public RouletteWheelSelection(Random rng)
        {
            if (rng == null)
            {
                this.rng = new Random();
            }
            else
            {
                this.rng = rng;
            }
        }

        #endregion Public Constructors

        #region Public Methods

        public int ChooseAction(double[] actionEstimates)
        {
            double randomNumber = rng.NextDouble();

            return ChooseActionBase(actionEstimates, randomNumber);
        }

        public int ChooseAction(double[] actionEstimates, double randomNumber)
        {
            return ChooseActionBase(actionEstimates, randomNumber);
        }

        public int ChooseAction(double[] actionEstimates, Random rng)
        {
            double randomNumber = rng.NextDouble();

            return ChooseActionBase(actionEstimates, randomNumber);
        }

        #endregion Public Methods

        #region Private Methods

        private int ChooseActionBase(double[] actionEstimates, double randomNumber)
        {
            int actionsCount = actionEstimates.Length;
            double cumulative = 0;
            double estimateSum = 0;

            for (int i = 0; i < actionsCount; i++)
            {
                estimateSum += actionEstimates[i];
            }

            for (int i = 0; i < actionsCount; i++)
            {
                cumulative += actionEstimates[i] / estimateSum;
                if (randomNumber <= cumulative)
                {
                    return i;
                }
            }

            return actionsCount - 1;
        }

        #endregion Private Methods
    }
}