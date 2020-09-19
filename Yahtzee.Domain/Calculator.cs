using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.Domain
{
    public class Calculator
    {
        private static readonly int[] HighStraightWith1 = {1, 2, 3, 4, 5};
        private static readonly int[] HighStraightWith6 = {2, 3, 4, 5, 6};
        private static readonly int[] LowStraightWith1 = {1, 2, 3, 4};
        private static readonly int[] LowStraightWith2 = {2, 3, 4, 5};
        private static readonly int[] LowStraightWith3 = {3, 4, 5, 6};

        public int Calculate(List<int> roll, Combination combination)
        {
            return combination switch
            {
                Combination.Chance => roll.Sum(),
                Combination.ThreeOfAKind => IsThreeOfAKind(roll) ? roll.Sum() : 0,
                Combination.HighStraight => IsHighStraight(roll) ? 40 : 0,
                Combination.LowStraight => IsLowStraight(roll) ? 30 : 0,
                Combination.Full => IsFull(roll) ? 25 : 0,
                _ => roll.Count(dice => dice == (int) combination) * (int) combination
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

            static bool IsFull(List<int> roll)
            {
                return roll.ToHashSet().Count == 2;
            }

            static bool IsLowStraight(List<int> roll)
            {
                var hashset = new HashSet<int>(roll);
                return hashset.IsSupersetOf(LowStraightWith1)
                       || hashset.IsSupersetOf(LowStraightWith2)
                       || hashset.IsSupersetOf(LowStraightWith3);
            }
        }

        
    }
}