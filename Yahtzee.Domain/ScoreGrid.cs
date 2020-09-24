using System;
using System.Collections.Generic;

namespace Yahtzee.Domain
{
    public class ScoreGrid
    {
        Calculator calculator = new Calculator();
        Dictionary<Box, int?> boxes = new Dictionary<Box, int?>();


        public bool SetScore(Box box, Roll roll)
        {
            if (!boxes.ContainsKey(box))
            {
                boxes[box] = calculator.Calculate(roll, BoxToCombination(box));

                return true;
            }
            return false;
        }

        private Combination BoxToCombination(Box box)
        {
            return box switch
            {
                Box.Aces => Combination.Ace,
                Box.Twos => Combination.Two,
                _ => throw new ArgumentOutOfRangeException(nameof(box), box, null)
            };
        }

        public int? GetScore(Box box)
        {
            return boxes.TryGetValue(box, out var result) ? result : null;
        }
    }
}