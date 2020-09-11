using System.Collections.Generic;
using Xunit;
using Yahtzee.Domain;

namespace Tests
{
    public class TurnTests
    {
        // Classe => Round
        // Ok Throw all dices => Roll
        // Ok Throw all dices => Ok
        // Ok Throw all dices => Ok
        // Ok Throw 4 times => Nope
        // choose a combination => score 
        // Choose a combiantion again => Nope
        // Combinaison chosen => no reroll
        // Choose dices to reroll
        // Turn start => all dices are rolled

        [Fact]
        public void When_a_first_roll_is_made_a_set_of_5_dices_is_returned(){
            var turn = new Turn();
            var dices = turn.Roll();
            Assert.Equal(5,dices.Count);           
        }

        [Fact]
        public void You_cant_roll_4_times(){
            var turn = new Turn();
            turn.Roll();
            turn.Roll();
            turn.Roll();
            var ex = Assert.Throws<YouCantRollAnymoreException>(() => turn.Roll());

        }
    }
}