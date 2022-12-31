//using System;
//using System.Collections.Generic;
//using System.Runtime.Intrinsics.X86;
//using System.Xml.Linq;

//namespace AstarExample
//{
//	class Program
//	{
//		static int goalX, goalY;
//		static void Main(string[] args)
//		{
//			string[] text = File.ReadAllLines("input.txt");
//			// create a 2D array of heights
//			int[,] heights = new int[text[0].Length, text.Length];
//			(int, int) start = (0, 0);
//			for(int y = 0; y < text.Length; y++)
//			{
//				for(int x = 0; x < text[y].Length; x++)
//				{
//					if(text[y][x] == 'S')
//					{
//						start = (x, y);
//						text[y] = text[y].Replace('S', 'a');
//					}
//					else if(text[y][x] == 'E')
//					{
//						text[y] = text[y].Replace('E', 'z');
//						goalY = y;
//						goalX = x;
//					}
//					heights[x, y] = text[y][x] - 97;
//				}
//			}
//			//p2 
//			int min = int.MaxValue;
//			for(int y = 0; y < text.Length; y++)
//			{
//				for(int x = 0; x < text[y].Length; x++)
//				{
//					if(text[y][x] == 'a')
//					{
//						min = Math.Min(min, Astar(heights, x, y));
//					}
//				}
//			}
//			Console.WriteLine(min);	


//					// call the A* algorithm with the starting position (0, 0)
//					//Astar(heights, start.Item1, start.Item2);
//		}

//		static int Astar(int[,] heights, int startX, int startY)
//		{
//			// create a queue for the open list
//			PriorityQueue<(int, int), float> openSet = new();

//			Dictionary<(int, int), (int, int)> cameFrom = new();
//			Dictionary<(int, int), float> gScore = new();
//			Dictionary<(int, int), float> fScore = new();

//			for(int i = 0; i < heights.GetLength(0); i++)
//			{
//				for(int j = 0; j < heights.GetLength(1); j++)
//				{
//					gScore[(i, j)] = float.MaxValue;
//					fScore[(i, j)] = float.MaxValue;
//				}
//			}

//			// add the starting position to the open list
//			var start = (startX, startY);
//			openSet.Enqueue(start, CalculateH(startX, startY));
//			fScore[start] = CalculateH(startX, startY);
//			gScore[start] = 0.0f;
//			// loop until the open list is empty
//			while(openSet.Count > 0)
//			{
//				// get the current node (the one with the lowest f value)
//				var current = openSet.Dequeue();

//				// check if we have reached the goal (tile with value -1)
//				if(current.Item1 == goalX && current.Item2 == goalY)
//				{
//					// print the path to the goal
//					var result = ReconstructPath(cameFrom, current);
//					return(result.Count - 1);
//				}

//				// get the neighbors of the current node
//				List<(int, int)> neighbors = GetNeighbors(heights, current);

//				// loop through the neighbors
//				foreach(var neighbor in neighbors)
//				{

//					//todo
//					var tentative_gScore = gScore[current] + 1;//Math.Abs(heights[current.X,current.Y] - heights[neighbor.X, neighbor.Y]);
//					if(tentative_gScore < gScore[neighbor])
//					{
//						cameFrom[neighbor] = current;
//						gScore[neighbor] = tentative_gScore;

//						fScore[neighbor] = tentative_gScore + CalculateH(neighbor.Item1, neighbor.Item2);

//						if(!openSet.UnorderedItems.Contains((neighbor, fScore[neighbor])))
//							openSet.Enqueue(neighbor, fScore[neighbor]);
//					}
//				}
//			}
//			return int.MaxValue;
//		}

//		// method to get the valid neighbors of a node
//		static List<(int, int)> GetNeighbors(int[,] heights, (int, int) currentNode)
//		{
//			// create a list for the neighbors
//			List<(int, int)> neighbors = new List<(int, int)>();

//			// get the height of the current node
//			int currentHeight = heights[currentNode.Item1, currentNode.Item2];

//			// check if the tile to the left is within one height difference
//			if(currentNode.Item1 > 0 && (heights[currentNode.Item1 - 1, currentNode.Item2] - currentHeight) < 2)
//			{
//				// add the tile to the left as a neighbor
//				neighbors.Add((currentNode.Item1 - 1, currentNode.Item2));
//			}

//			// check if the tile to the right is within one height difference
//			if(currentNode.Item1 < heights.GetLength(0) - 1 && (heights[currentNode.Item1 + 1, currentNode.Item2] - currentHeight) < 2)
//			{
//				// add the tile to the right as a neighbor
//				neighbors.Add((currentNode.Item1 + 1, currentNode.Item2));
//			}

//			// check if the tile above is within one height difference
//			if(currentNode.Item2 > 0 && (heights[currentNode.Item1, currentNode.Item2 - 1] - currentHeight) < 2)
//			{
//				// add the tile above as a neighbor
//				neighbors.Add((currentNode.Item1, currentNode.Item2 - 1));
//			}

//			// check if the tile below is within one height difference
//			if(currentNode.Item2 < heights.GetLength(1) - 1 && (heights[currentNode.Item1, currentNode.Item2 + 1] - currentHeight) < 2)
//			{
//				// add the tile below as a neighbor
//				neighbors.Add((currentNode.Item1, currentNode.Item2 + 1));
//			}

//			return neighbors;
//		}
//		// method to calculate the heuristic value (h) for a node
//		static int CalculateH(int x, int y)
//		{
//			// calculate the Manhattan distance to the goal
//			int dx = Math.Abs(goalX - x);
//			int dy = Math.Abs(goalY - y);
//			return dx + dy;
//		}

//		public static List<(int, int)> ReconstructPath(Dictionary<(int, int), (int, int)> cameFrom, (int, int) current)
//		{
//			List<(int, int)> nodes = new List<(int, int)>() { current };
//			while(cameFrom.ContainsKey(current))
//			{
//				current = cameFrom[current];
//				nodes.Add(current);
//			}
//			nodes.Reverse();
//			return nodes;
//		}
//	}
//}
