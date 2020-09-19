using System;
using System.Collections.Generic;
using System.Linq;
using Roll = System.Collections.Generic.List<int>;

namespace Yahtzee.Domain
{
    public class Calculator
    {
        private static readonly int[] HighStraightWith1 = {1, 2, 3, 4, 5};
        private static readonly int[] HighStraightWith6 = {2, 3, 4, 5, 6};
        private static readonly int[] LowStraightWith1 = {1, 2, 3, 4};
        private static readonly int[] LowStraightWith2 = {2, 3, 4, 5};
        private static readonly int[] LowStraightWith3 = {3, 4, 5, 6};

        public int Calculate(Roll roll, Combination combination)
        {
            var hashset = new HashSet<int>(roll);
            static int Sum(Roll theRoll) => theRoll.Sum();
            static bool AlwaysTrue(Roll _) => true;

            bool IsHighStraight(Roll theRoll) =>
                hashset.SetEquals(HighStraightWith1) || hashset.SetEquals(HighStraightWith6);

            static bool IsThreeOfAKind(Roll roll) => roll.GroupBy(dice => dice).Any(g => g.Count() >= 3);
            bool IsFull(Roll theRoll) => hashset.Count == 2;

            bool IsLowStraight(Roll theRoll) =>
                hashset.IsSupersetOf(LowStraightWith1)
                || hashset.IsSupersetOf(LowStraightWith2)
                || hashset.IsSupersetOf(LowStraightWith3);

            int SumOfDicesOfAKind(Roll theRoll) =>
                theRoll.Count(dice => dice == (int) combination) * (int) combination;

            var dic = new Dictionary<Combination, ValueTuple<Predicate<Roll>, Func<Roll, int>>>
            {
                {Combination.Chance, (AlwaysTrue, Sum)},
                {Combination.ThreeOfAKind, (IsThreeOfAKind, Sum)},
                {Combination.HighStraight, (IsHighStraight, _ => 40)},
                {Combination.LowStraight, (IsLowStraight, _ => 30)},
                {Combination.Full, (IsFull, _ => 25)}
            };

            var recipe =
                dic.TryGetValue(combination, out var toApply)
                    ? toApply
                    : (AlwaysTrue, SumOfDicesOfAKind);

            var (predicate, score) = recipe;
            return predicate(roll) ? score(roll) : 0;
        }
    }
}