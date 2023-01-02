using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace AstarExample
{
	class Program
	{
		static int goalX, goalY;
		static void Main(string[] args)
		{
			string[] text = File.ReadAllLines("input.txt");
			// create a 2D array of heights
			int[,] heights = new int[text[0].Length, text.Length];
			(int, int) start = (0, 0);
			for(int y = 0; y < text.Length; y++)
			{
				for(int x = 0; x < text[y].Length; x++)
				{
					if(text[y][x] == 'S')
					{
						start = (x, y);
						text[y] = text[y].Replace('S', 'a');
					}
					else if(text[y][x] == 'E')
					{
						text[y] = text[y].Replace('E', 'z');
						goalY = y;
						goalX = x;
					}
					heights[x, y] = text[y][x] - 97;
				}
			}
			//p2 
			int min = int.MaxValue;
			for(int y = 0; y < text.Length; y++)
			{
				for(int x = 0; x < text[y].Length; x++)
				{
					if(text[y][x] == 'a')
					{
						min = Math.Min(min, Astar(heights, x, y));
					}
				}
			}
			Console.WriteLine(min);
		}

		static int Astar(int[,] heights, int startX, int startY)
		{
			// create a queue for the open list
			PriorityQueue<(int, int), float> openSet = new();

			Dictionary<(int, int), (int, int)> cameFrom = new();
			Dictionary<(int, int), float> gScore = new();
			Dictionary<(int, int), float> fScore = new();

			for(int i = 0; i < heights.GetLength(0); i++)
			{
				for(int j = 0; j < heights.GetLength(1); j++)
				{
					gScore[(i, j)] = float.MaxValue;
					fScore[(i, j)] = float.MaxValue;
				}
			}

			// add the starting position to the open list
			var start = (startX, startY);
			openSet.Enqueue(start, CalculateH(startX, startY));
			fScore[start] = CalculateH(startX, startY);
			gScore[start] = 0.0f;

			while(openSet.Count > 0)
			{
				var current = openSet.Dequeue();

				if(current.Item1 == goalX && current.Item2 == goalY)
				{
					var result = ReconstructPath(cameFrom, current);
					return (result.Count - 1);
				}

				List<(int, int)> neighbors = GetNeighbors(heights, current);

				foreach(var neighbor in neighbors)
				{
					var tentative_gScore = gScore[current] + 1;
					if(tentative_gScore < gScore[neighbor])
					{
						cameFrom[neighbor] = current;
						gScore[neighbor] = tentative_gScore;

						fScore[neighbor] = tentative_gScore + CalculateH(neighbor.Item1, neighbor.Item2);

						if(!openSet.UnorderedItems.Contains((neighbor, fScore[neighbor])))
							openSet.Enqueue(neighbor, fScore[neighbor]);
					}
				}
			}
			return int.MaxValue;
		}

		static List<(int, int)> GetNeighbors(int[,] heights, (int, int) currentNode)
		{
			List<(int, int)> neighbors = new List<(int, int)>();

			int currentHeight = heights[currentNode.Item1, currentNode.Item2];

			if(currentNode.Item1 > 0 && (heights[currentNode.Item1 - 1, currentNode.Item2] - currentHeight) < 2)
			{
				neighbors.Add((currentNode.Item1 - 1, currentNode.Item2));
			}

			if(currentNode.Item1 < heights.GetLength(0) - 1 && (heights[currentNode.Item1 + 1, currentNode.Item2] - currentHeight) < 2)
			{
				neighbors.Add((currentNode.Item1 + 1, currentNode.Item2));
			}

			if(currentNode.Item2 > 0 && (heights[currentNode.Item1, currentNode.Item2 - 1] - currentHeight) < 2)
			{
				neighbors.Add((currentNode.Item1, currentNode.Item2 - 1));
			}

			if(currentNode.Item2 < heights.GetLength(1) - 1 && (heights[currentNode.Item1, currentNode.Item2 + 1] - currentHeight) < 2)
			{
				neighbors.Add((currentNode.Item1, currentNode.Item2 + 1));
			}

			return neighbors;
		}

		static int CalculateH(int x, int y)
		{
			// calculate the Manhattan distance to the goal
			int dx = Math.Abs(goalX - x);
			int dy = Math.Abs(goalY - y);
			return dx + dy;
		}

		public static List<(int, int)> ReconstructPath(Dictionary<(int, int), (int, int)> cameFrom, (int, int) current)
		{
			List<(int, int)> nodes = new List<(int, int)>() { current };
			while(cameFrom.ContainsKey(current))
			{
				current = cameFrom[current];
				nodes.Add(current);
			}
			nodes.Reverse();
			return nodes;
		}
	}
}
