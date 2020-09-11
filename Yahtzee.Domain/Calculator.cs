using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.Domain
{
    public class Calculator
    {
        public Calculator()
        {
        }

        public int Calculate(List<int> roll, Combination combination) => combination switch
        {
            Combination.Chance => roll.Sum(),
            _ => roll.Count(dice => dice == (int)combination) * (int)combination,
            
        };
    }
}