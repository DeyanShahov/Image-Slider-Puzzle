namespace Image_Slider_Puzzle
{
    public class BFSSolver
    {
        public List<string> SolvePuzzle(int[] initialState, int attempts = 1000000)
        {
            //Start state of Puzzle
            var initialStateString = string.Join(",", initialState);
            var initialPuzzleState = new PuzzleState { State = initialState, Moves = new List<string>() };

            //Determine target state (sorted)
            var goalState = Enumerable.Range(0, initialState.Length).ToArray();
            var goalStateString = string.Join(",", goalState);

            //Determine how moves can be made (all possible directions)
            var possibleMoves = new List<(int Dx, int Dy)> { (-1, 0), (1, 0), (0, -1), (0, 1) };
            var moveNames = new List<string> { StringData.directionLeft, StringData.directionRight, StringData.directionUp, StringData.directionDown };

            //Determine queue for BFS
            var queue = new Queue<PuzzleState>();
            queue.Enqueue(initialPuzzleState);

            //Run BFS
            while (queue.Any() && queue.Count < attempts)
            {
                var currentState = queue.Dequeue();

                //Found SOLUTION for Win
                if (string.Join(",", currentState.State) == goalStateString) 
                {
                    queue.Clear();
                    //GC.Collect();
                    return currentState.Moves;
                }

                //Find the position of 0 (black box)
                var zeroIndex = Array.IndexOf(currentState.State, 0);
                var zeroX = zeroIndex % 3;
                var zeroY = zeroIndex / 3;

                //Try all possible moves
                for (int i = 0; i < possibleMoves.Count; i++)
                {
                    var (dx, dy) = possibleMoves[i];
                    var newX = zeroX + dx;
                    var newY = zeroY + dy;

                    if (newX >= 0 && newX < 3 && newY >= 0 && newY < 3)
                    {
                        var newState = (int[])currentState.State.Clone();
                        var newIndex = newY * 3 + newX;

                        //Swap the positions of the numbers
                        var temp = newState[zeroIndex];
                        newState[zeroIndex] = newState[newIndex];
                        newState[newIndex] = temp;

                        //Add the move to the list
                        var newMoves = new List<string>(currentState.Moves);
                        newMoves.Add(moveNames[i]);

                        //Create new state and add it to the queue
                        var nextState = new PuzzleState { State = newState, Moves = newMoves };
                        queue.Enqueue(nextState);
                    }
                }

            }

            queue.Clear();
            return new List<string> { StringData.warningNoSolution };

        }
    }

    public class PuzzleState
    {
        public int[] State { get; set; }
        public List<string> Moves { get; set; }
    }
}
