using System.Collections.Generic;
using Xunit;
using Yahtzee.Domain;

namespace Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculate_Chance_Combination_Only_Ones()
        {
            var roll = new List<int>{1,1,1,1,1};
            var combination = Combination.Chance;
            int score = new Calculator().Calculate(roll,combination);
            Assert.Equal(5,score);
        }

        [Fact]
        public void Calculate_Chance_Combination_From_All_Dices()
        {
            var roll = new List<int>{1,2,4,1,6};
            var combination = Combination.Chance;
            int score = new Calculator().Calculate(roll,combination);
            Assert.Equal(14,score);
        }

        [Fact]
        public void Calculate_Ace_Combination_From_A_Roll_With_One_Ace()
        {
            var roll = new List<int>{1,2,4,4,6};
            var combination = Combination.Ace;
            int score = new Calculator().Calculate(roll,combination);
            Assert.Equal(1,score);
        }

        [Fact]
        public void Calculate_Ace_Combination_From_A_Roll_With_two_Aces()
        {
            var roll = new List<int>{1,1,4,4,6};
            var combination = Combination.Ace;
            int score = new Calculator().Calculate(roll,combination);
            Assert.Equal(2,score);
        }

        [Fact]
        public void Calculate_Ace_Combination_From_A_Roll_With_two_Aces_anywhere()
        {
            var roll = new List<int>{4,5,1,4,1};
            var combination = Combination.Ace;
            int score = new Calculator().Calculate(roll,combination);
            Assert.Equal(2,score);
        }

        [Fact]
        public void Calculate_Ace_Combination_From_A_Roll_With_no_Ace()
        {
            var roll = new List<int>{4,4,4,4,4};
            var combination = Combination.Ace;
            int score = new Calculator().Calculate(roll,combination);
            Assert.Equal(0,score);
        }

        [Fact]
        public void Calculate_Ace_Combination_From_A_Roll_With_all_Ace()
        {
            var roll = new List<int>{1,1,1,1,1};
            var combination = Combination.Ace;
            int score = new Calculator().Calculate(roll,combination);
            Assert.Equal(5,score);
        }

        [Fact]
        public void Calculate_Two_Combination_From_A_Roll_With_One_Two()
        {
            var roll = new List<int>{1,2,4,4,6};
            var combination = Combination.Two;
            int score = new Calculator().Calculate(roll,combination);
            Assert.Equal(2,score);
        }

        [Fact]
        public void Calculate_Two_Combination_From_A_Roll_With_Two_Two()
        {
            var roll = new List<int>{1,2,4,2,6};
            var combination = Combination.Two;
            int score = new Calculator().Calculate(roll,combination);
            Assert.Equal(4,score);
        }

        [Fact]
        public void Calculate_Three_Combination_From_A_Roll_With_One_Three()
        {
            var roll = new List<int>{1,2,3,4,6};
            var combination = Combination.Three;
            int score = new Calculator().Calculate(roll,combination);
            Assert.Equal(3,score);
        }

        [Fact]
        public void Calculate_Four_Combination_From_A_Roll_With_Two_Four()
        {
            var roll = new List<int>{1,2,4,2,4};
            var combination = Combination.Four;
            int score = new Calculator().Calculate(roll,combination);
            Assert.Equal(8,score);
        }

        [Fact]
        public void Calculate_Five_Combination_From_A_Roll_With_Two_Five()
        {
            var roll = new List<int>{1,5,4,5,4};
            var combination = Combination.Five;
            int score = new Calculator().Calculate(roll,combination);
            Assert.Equal(10,score);
        }

        [Fact]
        public void Calculate_six_Combination_From_A_Roll_With_Two_six()
        {
            var roll = new List<int>{6,2,4,2,6};
            var combination = Combination.Six;
            int score = new Calculator().Calculate(roll,combination);
            Assert.Equal(12,score);
        }
    }
}
