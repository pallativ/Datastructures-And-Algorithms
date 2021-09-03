using System;
using System.Collections.Generic;
using System.Text;

namespace Datastructures._488
{
    public class Solution
    {
        private char[] ballColors = new char[5] { 'R', 'Y', 'B', 'G', 'W' };
        public Dictionary<char, int> ballsInHandDict { get; set; }
        public int FindMinStep(string board, string hand)
        {
            //// Populate the dictionary from balls in hand.
            //PopulateBallsInHand(hand);

            return 0;
        }
        private bool ClearBoard(string board, int start)
        {
            if (board.Length == 0)
                return true;
            for (int i = start; i < board.Length; i++)
            {

                if (ballsInHandDict[board[i]] > 0)
                {
                    ballsInHandDict[board[i]]--;
                    var newBoard =  board.Insert(i, board[i].ToString());
                    if (CanItBeCleared(newBoard))
                        return true;
                }
            }
            return false;
        }

        private bool CanItBeCleared(string board)
        {
            if(board.Length == 0)
                return true;
            foreach (var ballColor in ballColors)
            {
                string sequence = $"{ballColor}{ballColor}{ballColor}";
                board = board.Replace(sequence, string.Empty);
                if(board.Length == 1)
                    return true;
            }
            return false;
        }
        private void PopulateBallsInHand(string ballsInHand)
        {
            foreach (var ball in ballsInHand)
            {
                if (!ballsInHandDict.ContainsKey(ball))
                    ballsInHandDict.Add(ball, 0);
                ballsInHandDict[ball] += 1;
            }
        }

    }
}
