using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.Domain
{
    public class Calculator
    {
        private static int[] HighStraightWith1 = new int[] { 1, 2, 3, 4, 5 };
        private static int[] HighStraightWith6 = new int[] { 2, 3, 4, 5, 6 };
        public Calculator()
        {
        }

        public int Calculate(List<int> roll, Combination combination)
        {
            return combination switch
            {
                Combination.Chance => roll.Sum(),
                Combination.ThreeOfAKind => IsThreeOfAKind(roll) ? roll.Sum() : 0,
                Combination.HighStraight => IsHighStraight(roll) ? 40 : 0,
                _ => roll.Count(dice => dice == (int)combination) * (int)combination

            };

            static bool IsHighStraight(List<int> roll)
            {
                var hashset = new HashSet<int>(roll);
                return hashset.SetEquals(HighStraightWith1) || hashset.SetEquals(HighStraightWith6);

            }

            static bool IsThreeOfAKind(List<int> roll)
            {
                return roll.GroupBy(dice => dice).Any(g => g.Count() >= 3);
            }
        }
    }
}