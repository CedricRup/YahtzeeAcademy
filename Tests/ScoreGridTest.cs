using System.Collections.Generic;
using Xunit;
using Yahtzee.Domain;

namespace Tests
{
    public class ScoreGridTests
    {
        [Fact]
        public void Add_Score_In_Empty_Box_with_only_ones()
        {
            var roll = new List<int> { 1, 1, 1, 1, 1 }.ToRoll();
            ScoreGrid grid = new ScoreGrid();
            grid.SetScore(Box.Aces, roll);
            Assert.Equal(5, grid.GetScore(Box.Aces));
        }

        [Fact]
        public void Add_Score_In_Empty_Box_ones_and_one_five()
        {
            var roll = new List<int> { 1, 1, 1, 1, 5 }.ToRoll();
            ScoreGrid grid = new ScoreGrid();
            grid.SetScore(Box.Aces, roll);
            Assert.Equal(4, grid.GetScore(Box.Aces));
        }

        [Fact]
        public void Add_Score_In_Ace_That_is_not_empty_and_score_stay_the_same()
        {
            var roll1 = new List<int> { 1, 1, 1, 1, 5 }.ToRoll();
            var roll2 = new List<int> { 1, 1, 1, 5, 5 }.ToRoll();
            ScoreGrid grid = new ScoreGrid();
            grid.SetScore(Box.Aces, roll1);
            grid.SetScore(Box.Aces, roll2);
            Assert.Equal(4, grid.GetScore(Box.Aces));
        }

        [Fact]
        public void Setting_the_score_should_return_false_if_box_is_already_full()
        {
            var roll1 = new List<int> { 1, 1, 1, 1, 5 }.ToRoll();
            var roll2 = new List<int> { 1, 1, 1, 5, 5 }.ToRoll();
            ScoreGrid grid = new ScoreGrid();
            grid.SetScore(Box.Aces, roll1);
            Assert.False(grid.SetScore(Box.Aces, roll2));
        }


        [Fact]
        public void Setting_the_score_should_return_true_if_box_is_empty()
        {
            var roll1 = new List<int> { 1, 1, 1, 1, 5 }.ToRoll();
            ScoreGrid grid = new ScoreGrid();
            Assert.True(grid.SetScore(Box.Aces, roll1));
        }

        [Fact]
        public void Should_be_able_to_score_in_box_two()
        {
            var roll = new List<int> { 1, 2, 1, 1, 5 }.ToRoll();
            ScoreGrid grid = new ScoreGrid();
            grid.SetScore(Box.Twos, roll);
            Assert.Equal(2, grid.GetScore(Box.Twos));
        }

        [Fact]
        public void Scores_should_be_correct_when_two_boxes_are_filled()
        {
            var roll1 = new List<int> { 1, 1, 1, 1, 5 }.ToRoll();
            var roll2 = new List<int> { 2, 1, 1, 5, 5 }.ToRoll();
            ScoreGrid grid = new ScoreGrid();
            grid.SetScore(Box.Aces, roll1);
            grid.SetScore(Box.Twos, roll2);
            Assert.Equal(4, grid.GetScore(Box.Aces));
            Assert.Equal(2, grid.GetScore(Box.Twos));

        }

        [Fact]
        public void should_be_able_to_score_in_an_empty_box_when_another_is_filled()
        {
            var roll1 = new List<int> { 1, 1, 1, 1, 5 }.ToRoll();
            var roll2 = new List<int> { 2, 1, 1, 5, 5 }.ToRoll();
            ScoreGrid grid = new ScoreGrid();
            grid.SetScore(Box.Aces, roll1);
            Assert.True(grid.SetScore(Box.Twos, roll2));
        }



    }
}  