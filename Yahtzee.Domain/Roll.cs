using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.Domain
{
    public class Roll : IEnumerable<int>
    {
        private List<int> dices;

        public Roll(IEnumerable<int> dices)
        {
            this.dices = dices.ToList();
        }
        public IEnumerator<int> GetEnumerator()
        {
            return dices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class DicesUtilities
    {
        public static Roll ToRoll(this IEnumerable<int> dices)
        {
            return new Roll(dices);
        }
    }
}
