//using System;
//using System.Collections.Generic;

//string[] text = File.ReadAllLines("input.txt");
//int[,] heights = new int[text[0].Length, text.Length];
//(int, int) start = (0, 0);
//(int, int) goal = (0, 0);
//for(int y = 0; y < text.Length; y++)
//{
//	for(int x = 0; x < text[y].Length; x++)
//	{
//		if(text[y][x] == 'S')
//		{
//			start = (x, y);
//			text[y] = text[y].Replace('S', 'a');
//		}
//		else if(text[y][x] == 'E')
//		{
//			text[y] = text[y].Replace('E', 'z');
//			goal = (x, y);
//		}
//		heights[x, y] = text[y][x] - 97;
//	}
//}

//int startX = start.Item1, startY = start.Item2, goalX = goal.Item1, goalY = goal.Item2;

//// Create a queue for BFS
//Queue<Node> queue = new Queue<Node>();

//// Create a visited array to track visited nodes
//bool[,] visited = new bool[heights.GetLength(0), heights.GetLength(1)];

//// Create a node for the starting position
//Node startNode = new Node(startX, startY, 0, null);

//// Mark the starting node as visited
//visited[startNode.x, startNode.y] = true;

//// Enqueue the starting node
//queue.Enqueue(startNode);

//while(queue.Count != 0)
//{
//	// Dequeue a node from the queue
//	Node currNode = queue.Dequeue();

//	// Check if we have reached the goal
//	if(currNode.x == goalX && currNode.y == goalY)
//	{
//		Console.WriteLine("Found the goal! Shortest path is " + currNode.distance + " steps.");
//		break;
//	}
//	int[] dx = new int[4] { -1, 0, 1, 0 };
//	int[] dy = new int[4] { 0, -1, 0, 1 };
//	for(int i = 0; i < 4; i++)
//	{
//		if(currNode.x + dx[i] >= 0 && currNode.x + dx[i] < heights.GetLength(0)
//				&& currNode.y + dy[i] >= 0 && currNode.y + dy[i] < heights.GetLength(1)
//				&& Math.Abs(heights[currNode.x, currNode.y] - heights[currNode.x + dx[i], currNode.y + dy[i]]) <= 1
//				&& !visited[currNode.x + dx[i], currNode.y + dy[i]])
//		{


//			// Mark the node as visited
//			if(!visited[currNode.x + dx[i], currNode.y + dy[i]])
//			{
//				// Create a new node for the move
//				Node newNode = new Node(currNode.x + dx[i], currNode.y + dy[i], currNode.distance + 1, currNode);
//				visited[currNode.x + dx[i], currNode.y + dy[i]] = true;
//				queue.Enqueue(newNode);

//			}

//			// Enqueue the new node
//		}
//	}
//}



//// Node class to represent a position on the grid
//class Node
//{
//	public int x, y, distance;
//	public Node parent;

//	public Node(int x, int y, int distance, Node parent )
//	{
//		this.x = x;
//		this.y = y;
//		this.distance = distance;
//		this.parent = parent;
//	}
//}