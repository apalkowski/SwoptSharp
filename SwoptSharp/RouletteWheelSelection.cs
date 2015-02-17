#region License

// SwoptSharp, a collection of swarm intelligence algorithms for general optimisation purposes
// Copyright (C) 2015  Aleksander Palkowski <http://apalkowski.com>
// 
// This program is free software; you can redistribute it and/or modify it under the terms of the
// GNU General Public License as published by the Free Software Foundation; either version 2 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without
// even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// General Public License for more details.
// 
// You should have received a copy of the GNU General Public License along with this program; if
// not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA
// 02110-1301 USA.

#endregion License

using System;

namespace SwoptSharp
{
    public class RouletteWheelSelection
    {
        private Random rng;

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
    }
}