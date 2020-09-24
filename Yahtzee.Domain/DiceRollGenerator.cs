using System;
using System.Linq;

namespace Yahtzee.Domain
{
    public class DiceRollGenerator
    {
        private readonly Random random = new Random();

        public Roll Roll(int numberOfDices = 5)
        {
            return new Roll(Enumerable.Range(0, numberOfDices).Select(_ => random.Next(1, 7)));
        }
    }
}