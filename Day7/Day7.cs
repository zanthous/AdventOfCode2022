using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Helper;
internal class AOC
{
	public enum FileOrDir
	{
		File,
		Dir
	}

	unsafe class Node
	{
		public FileOrDir fileOrDir;
		public int size = 0;
		public string name = "";
		public List<Node> children;
		public Node parent;
	}

	static void Main(string[] args)
	{
		Node headNode;
		headNode = new Node();
		headNode.fileOrDir = FileOrDir.Dir;
		headNode.name = "/";
		headNode.parent = null;

		var curNode = headNode;
		var text = File.ReadAllLines("input.txt");

		for(int i = 0; i < text.Length; i++)
		{
			if(text[i] == "$ cd /")
			{
				curNode = headNode;
			}
			else if(text[i] == "$ cd ..")
			{
				curNode = curNode.parent;
				if(curNode == null) curNode = headNode;
			}
			else if(text[i].Contains("$ cd "))
			{
				var dir = text[i].Substring(5);
				Debug.Assert(curNode.children != null);
				foreach(var c in curNode.children)
				{
					if(c.name == dir)
					{
						curNode = c;
						break;
					}
				}
			}
			else if(text[i] == "$ ls")
			{
				continue;
			}
			else if(text[i].Substring(0, 4).Contains("dir "))
			{
				if(curNode.children == null)
				{
					curNode.children = new List<Node>();
				}
				var newNode = new Node();
				newNode.fileOrDir = FileOrDir.Dir;
				newNode.name = text[i].Substring(4);
				newNode.parent = curNode;
				curNode.children.Add(newNode);
			}
			else //number first, size
			{
				if(curNode.children == null)
				{
					curNode.children = new List<Node>();
				}
				var split = text[i].Split(" ");
				var newNode = new Node();
				newNode.fileOrDir = FileOrDir.File;
				newNode.size = int.Parse(split[0]);
				newNode.name = split[1];
				newNode.parent = curNode;
				curNode.children.Add(newNode);
			}
		}
		Solver solver = new Solver();
		solver.TraverseAndSum(headNode);
		solver.TraverseAndGetAnswer(headNode);
		solver.PickDelete(headNode);
		solver.maybeDelete.Sort();
		Console.WriteLine(solver.answer);


		int x = 0;

	}
	class Solver
	{
		public int answer = 0;

		public unsafe void TraverseAndSum(Node node)
		{
			if(node == null) return;

			if(node.fileOrDir == FileOrDir.Dir)
			{
				fixed(int* totalP = &node.size)
				{
					SumSizes(node, totalP);
				}
			}

			if(node.children == null) return;

			for(int i = 0; i < node.children.Count; i++)
			{
				TraverseAndSum(node.children[i]);
			}
		}

		public unsafe void TraverseAndGetAnswer(Node node)
		{
			if(node == null) return;

			if(node.fileOrDir == FileOrDir.Dir)
			{
				if(node.size <= 100000)
					answer += node.size;
			}

			if(node.children == null) return;

			for(int i = 0; i < node.children.Count; i++)
			{
				TraverseAndGetAnswer(node.children[i]);
			}
		}

		public unsafe void SumSizes(Node node, int* total)
		{
			if(node == null) return;

			//process node
			if(node.fileOrDir == FileOrDir.File)
			{
				*total += node.size;
			}

			if(node.children == null) return;

			for(int i = 0; i < node.children.Count; i++)
			{
				SumSizes(node.children[i], total);
			}
		}

		public void PickDelete(Node node)
		{
			//3,956,976
			if(node == null) return;

			//process
			if(node.fileOrDir == FileOrDir.Dir && node.size >= 3956976)
			{
				maybeDelete.Add(node.size);
			}

			if(node.children == null) return;

			for(int i = 0; i < node.children.Count; i++)
			{
				PickDelete(node.children[i]);
			}
		}

		public List<int> maybeDelete = new List<int>();

	}
}

//var text = File.ReadAllLines("input.txt");
//Stack<string> path = new Stack<string>();
//Dictionary<string, int> dict = new Dictionary<string, int>();

//for(int i = 1; i < text.Length; i++)
//{
//	var split = text[i].Split(' ');
//	if(split[1] == "cd")
//	{
//		if(split[2] == "..")
//		{
//			path.Pop();
//		}
//		else
//		{
//			path.Push(split[2]);
//		}
//	}
//	else if(split[1] == "ls" || split[0] == "dir") continue;
//	else
//	{
//		var size = int.Parse(split[0]);
//		for(int j = 0; j < path.Count + 1; j++)
//		{
//			var arr = path.ToArray();
//			Array.Reverse(arr);
//			var key = String.Join("/", arr, 0, j);
//			if(dict.ContainsKey(key))
//			{
//				dict[key] += size;
//			}
//			else
//			{
//				dict[key] = size;
//			}
//		}
//	}
//}
//int total = 0;
//foreach(var kp in dict)
//{
//	if(kp.Value <= 100000)
//	{
//		total += kp.Value;
//	}
//}
//var requiredSpace = 30000000 - (70000000 - dict[""]);

//int bestDir = int.MaxValue;

//foreach(var kp in dict)
//{
//	if(kp.Value >= requiredSpace)
//	{
//		bestDir = Math.Min(bestDir, kp.Value);
//	}
//}

//Console.WriteLine($"part 1: {total}\npart 2: {bestDir}");

//int x = 0;
