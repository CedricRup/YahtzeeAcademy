using System.Linq;
using FsCheck;
using Xunit;
using Yahtzee.Domain;

namespace Tests
{
    public class DiceRollGeneratorTests
    {
        [Fact]
        public void A_Roll_Has_5_Dices()
        {
            Prop.ForAll<DiceRollGenerator>(generator => generator.Roll().Count() == 5)
                .QuickCheckThrowOnFailure();
        }

        [Fact]
        public void All_dices_are_more_than_0()
        {
            Prop.ForAll<DiceRollGenerator>(generator => generator.Roll().All(d=>d>0)).QuickCheckThrowOnFailure();
        }

        [Fact]
        public void All_dices_are_less_than_6()
        {
            Prop.ForAll<DiceRollGenerator>(generator => generator.Roll().All(d => d <= 6)).QuickCheckThrowOnFailure();
        }


        [Fact]
        public void EachValueCanBeRepresented()
        {
            DiceRollGenerator gen = new DiceRollGenerator();
            var manyRolls = Enumerable.Range(0, 100).SelectMany(_ => gen.Roll()).ToList();
            Assert.Contains(1,manyRolls);
            Assert.Contains(2, manyRolls);
            Assert.Contains(3, manyRolls);
            Assert.Contains(4, manyRolls);
            Assert.Contains(5, manyRolls);
            Assert.Contains(6, manyRolls);

        }
    }
}
