namespace Image_Slider_Puzzle
{
    public class AStarSolver
    {
        public PuzzleStateV2 SolvePuzzle(PuzzleStateV2 initialState, int[,] goal, int attemptsNumber = 1000000)
        {
            HashSet<PuzzleStateV2> visited = new HashSet<PuzzleStateV2>();
            PriorityQueue<PuzzleStateV2, int> openSet = new PriorityQueue<PuzzleStateV2, int>();
            openSet.Enqueue(initialState, initialState.Cost + initialState.Heuristic);

            while (attemptsNumber > 0)
            {
                attemptsNumber--;

                PuzzleStateV2 current = openSet.Dequeue();

                if (IsGoal(current, goal)) return current;

                visited.Add(current);

                foreach (PuzzleStateV2 neighbor in current.GetNeighbors(goal))
                {
                    if (!visited.Contains(neighbor)) openSet.Enqueue(neighbor, neighbor.Cost + neighbor.Heuristic);
                }
            }

            return null;
        }

        private static bool IsGoal(PuzzleStateV2 state, int[,] goal)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (state.Board[x, y] != goal[x, y]) return false;
                }
            }
            return true;
        }

        public string ReturnSolution(PuzzleStateV2 solution)
        {
            PuzzleStateV2 current = solution;
            Stack<string> directionsStack = new Stack<string>();

            while (current != null)
            {
                directionsStack.Push(current.Direction);
                current = current.Parent;
            }

            directionsStack.Pop();

            return string.Join(", ", directionsStack);
        }
    }

    public class PuzzleStateV2
    {
        public int[,] Board { get; }
        public int EmptyX { get; }
        public int EmptyY { get; }
        public int Cost { get; }
        public int Heuristic { get; }
        public string Direction { get; }
        public PuzzleStateV2 Parent { get; }

        public PuzzleStateV2(int[,] board, int emptyX, int emptyY, int cost, int[,] goal)
        {
            Board = board;
            EmptyX = emptyX;
            EmptyY = emptyY;
            Cost = cost;
            Heuristic = CalculateHeuristic(goal);
            Parent = null;
        }

        public PuzzleStateV2(int[,] board, int emptyX, int emptyY, int cost, int[,] goal, string direction, PuzzleStateV2 parent)
        {
            Board = board;
            EmptyX = emptyX;
            EmptyY = emptyY;
            Cost = cost;
            Heuristic = CalculateHeuristic(goal);
            Direction = direction;
            Parent = parent;
        }

        private int CalculateHeuristic(int[,] goal)
        {
            int heuristic = 0;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (Board[x, y] != goal[x, y]) heuristic++;
                }
            }
            return heuristic;
        }

        public IEnumerable<PuzzleStateV2> GetNeighbors(int[,] goal)
        {
            List<PuzzleStateV2> neighbors = new List<PuzzleStateV2>();
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };
            //var possibleMoves = new List<(int Dx, int Dy)> { (-1, 0), (1, 0), (0, -1), (0, 1) };
            var moveNames = new[] { "Up", "Down", "Left", "Right" };

            for (int i = 0; i < 4; i++)
            {
                //var (dx, dy) = possibleMoves[i];
                int newX = EmptyX + dx[i];
                int newY = EmptyY + dy[i];

                if (newX >= 0 && newX < 3 && newY >= 0 && newY < 3)
                {
                    int[,] newBoard = (int[,])Board.Clone();
                    newBoard[EmptyX, EmptyY] = newBoard[newX, newY];
                    newBoard[newX, newY] = 0;
                    string dir = moveNames[i];
                    neighbors.Add(new PuzzleStateV2(newBoard, newX, newY, Cost + 1, goal, moveNames[i], this));
                }
            }

            return neighbors;
        }
    }
}
