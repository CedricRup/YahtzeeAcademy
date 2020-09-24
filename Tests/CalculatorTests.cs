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
            var roll = new List<int> { 1, 1, 1, 1, 1 }.ToRoll();
            var combination = Combination.Chance;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(5, score);
        }

        [Fact]
        public void Calculate_Chance_Combination_From_All_Dices()
        {
            var roll = new List<int> { 1, 2, 4, 1, 6 }.ToRoll();
            var combination = Combination.Chance;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(14, score);
        }

        [Fact]
        public void Calculate_Ace_Combination_From_A_Roll_With_One_Ace()
        {
            var roll = new List<int> { 1, 2, 4, 4, 6 }.ToRoll();
            var combination = Combination.Ace;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(1, score);
        }

        [Fact]
        public void Calculate_Ace_Combination_From_A_Roll_With_two_Aces()
        {
            var roll = new List<int> { 1, 1, 4, 4, 6 }.ToRoll();
            var combination = Combination.Ace;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(2, score);
        }

        [Fact]
        public void Calculate_Ace_Combination_From_A_Roll_With_two_Aces_anywhere()
        {
            var roll = new List<int> { 4, 5, 1, 4, 1 }.ToRoll();
            var combination = Combination.Ace;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(2, score);
        }

        [Fact]
        public void Calculate_Ace_Combination_From_A_Roll_With_no_Ace()
        {
            var roll = new List<int> { 4, 4, 4, 4, 4 }.ToRoll();
            var combination = Combination.Ace;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(0, score);
        }

        [Fact]
        public void Calculate_Ace_Combination_From_A_Roll_With_all_Ace()
        {
            var roll = new List<int> { 1, 1, 1, 1, 1 }.ToRoll();
            var combination = Combination.Ace;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(5, score);
        }

        [Fact]
        public void Calculate_Two_Combination_From_A_Roll_With_One_Two()
        {
            var roll = new List<int> { 1, 2, 4, 4, 6 }.ToRoll();
            var combination = Combination.Two;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(2, score);
        }

        [Fact]
        public void Calculate_Two_Combination_From_A_Roll_With_Two_Two()
        {
            var roll = new List<int> { 1, 2, 4, 2, 6 }.ToRoll();
            var combination = Combination.Two;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(4, score);
        }

        [Fact]
        public void Calculate_Three_Combination_From_A_Roll_With_One_Three()
        {
            var roll = new List<int> { 1, 2, 3, 4, 6 }.ToRoll();
            var combination = Combination.Three;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(3, score);
        }

        [Fact]
        public void Calculate_Four_Combination_From_A_Roll_With_Two_Four()
        {
            var roll = new List<int> { 1, 2, 4, 2, 4 }.ToRoll();
            var combination = Combination.Four;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(8, score);
        }

        [Fact]
        public void Calculate_Five_Combination_From_A_Roll_With_Two_Five()
        {
            var roll = new List<int> { 1, 5, 4, 5, 4 }.ToRoll();
            var combination = Combination.Five;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(10, score);
        }

        [Fact]
        public void Calculate_six_Combination_From_A_Roll_With_Two_six()
        {
            var roll = new List<int> { 6, 2, 4, 2, 6 }.ToRoll();
            var combination = Combination.Six;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(12, score);
        }

        [Fact]
        public void Calculate_Three_of_a_kind_with_less_than_three_identical_dices()
        {
            var roll = new List<int> { 1, 2, 3, 4, 5 }.ToRoll();
            var combination = Combination.ThreeOfAKind;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(0, score);
        }


        [Fact]
        public void Calculate_Three_of_a_kind_with_more_than_three_identical_dices()
        {
            var roll = new List<int> { 1, 1, 1, 1, 2 }.ToRoll();
            var combination = Combination.ThreeOfAKind;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(6, score);
        }

        [Fact]
        public void Calculate_High_Straight_from_one_to_five()
        {
            var roll = new List<int> { 1, 2, 3, 4, 5 }.ToRoll();
            var combination = Combination.HighStraight;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(40, score);
        }

        [Fact]
        public void Calculate_High_Straight_from_two_to_six()
        {
            var roll = new List<int> { 2, 3, 4, 5, 6 }.ToRoll();
            var combination = Combination.HighStraight;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(40, score);
        }

        [Fact]
        public void Calculate_High_Straight_from_two_to_six_not_ordered()
        {
            var roll = new List<int> { 3, 2, 4, 5, 6 }.ToRoll();
            var combination = Combination.HighStraight;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(40, score);
        }

        [Fact]
        public void Calculate_High_Straight_with_no_high_straight_in_dices()
        {
            var roll = new List<int> { 1, 3, 3, 4, 5 }.ToRoll();
            var combination = Combination.HighStraight;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(0, score);
        }

        [Fact]
        public void Calculate_Low_Straight_starting_with_1()
        {
            var roll = new List<int> { 1, 2, 3, 4, 1 }.ToRoll();
            var combination = Combination.LowStraight;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(30, score);
        }

        [Fact]
        public void Calculate_Low_Straight_starting_with_2()
        {
            var roll = new List<int> { 5, 2, 3, 4, 5 }.ToRoll();
            var combination = Combination.LowStraight;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(30, score);
        }

        [Fact]
        public void Calculate_Low_Straight_starting_with_3()
        {
            var roll = new List<int> { 3, 4, 5, 6, 6 }.ToRoll();
            var combination = Combination.LowStraight;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(30, score);
        }

        [Fact]
        public void Calculate_Low_Straight_with_High_Straight()
        {
            var roll = new List<int> { 1, 2, 3, 4, 5 }.ToRoll();
            var combination = Combination.LowStraight;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(30, score);
        }

        [Fact]
        public void Calculate_Low_Straight_without_Straight()
        {
            var roll = new List<int> { 1, 1, 1, 1, 1 }.ToRoll();
            var combination = Combination.LowStraight;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(0, score);
        }

        [Fact]
        public void Calculate_Full_with_ones_and_twos()
        {
            var roll = new List<int> { 1, 1, 1, 2, 2 }.ToRoll();
            var combination = Combination.Full;
            int score = new Calculator().Calculate(roll, combination);
            Assert.Equal(25, score);
        }


    }
}
