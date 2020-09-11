using System;
using System.Collections.Generic;

namespace Yahtzee.Domain
{
    public class Turn
    {
        private int rollsRemaining = 3;

        public Turn()
        {
        }

        public List<int> Roll()
        {
            if (rollsRemaining > 0){
                rollsRemaining--;
                return new List<int> { 1, 2, 3, 4, 5 };
            }
            throw new YouCantRollAnymoreException();
        }
    }
}