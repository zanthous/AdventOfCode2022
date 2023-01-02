//Appended the divider packets to the end of the input
string[] text = File.ReadAllLines("input.txt");

List<Node> leftNodes = new List<Node>();
List<Node> rightNodes = new List<Node>();

Dictionary<int, string> idToString = new Dictionary<int, string>();

for(int i = 0; i < text.Length; i++)              
{
	if(((i + 1) % 3) == 0)
	{
		continue;
	}
	bool left = (i % 3) == 0;
	Node currentNode = new Node(null, null);
	if(left)
	{
		leftNodes.Add(currentNode);
		var hash = currentNode.GetHashCode();
		leftNodes[leftNodes.Count - 1].id = hash;
		idToString[hash] = text[i];
	}
	else
	{
		rightNodes.Add(currentNode);
		var hash = currentNode.GetHashCode();
		rightNodes[rightNodes.Count - 1].id = hash;
		idToString[hash] = text[i];
	}
	for(int j = 0; j < text[i].Length; j++)
	{
		if(j == 0)
		{
			continue;
		}
		if(text[i][j] == '[')
		{
			var newNode = new Node(null, currentNode);
			currentNode.AddVal(newNode);
			currentNode = newNode;
		}
		else if(text[i][j] == ']')
		{
			currentNode = currentNode.Parent;
		}
		else if(text[i][j] == ',')
		{
			continue;
		}
		else
		{
			//10
			if(text[i][j + 1] == '0')
			{
				currentNode.AddVal(10);
				j++; //skip another character because of the 0 from 10
			}
			else
			{
				currentNode.AddVal((text[i][j] - 48));
			}
		}
	}
}
int total = 0;
for(int i = 0; i < leftNodes.Count; i++)
{
	//Console.WriteLine($"=={i}==");
	if(Node.Compare(leftNodes[i], rightNodes[i]))
	{
		//Console.WriteLine("right order");
		total += (i + 1);
	}
	leftNodes[i].Reset();
	rightNodes[i].Reset();
	//Console.WriteLine();
}
Console.WriteLine("part1: " + total);

int s1 = leftNodes[150].id;
int s2 = rightNodes[150].id;

leftNodes.AddRange(rightNodes);

int swaps = int.MaxValue;
while(swaps > 0)
{
	swaps = 0;
	for(int i = 0; i < leftNodes.Count - 1; i++)
	{
		if(!Node.Compare(leftNodes[i], leftNodes[i + 1]))
		{
			leftNodes.Swap(i, i + 1);
			swaps++;
		}
		leftNodes[i].Reset();
		leftNodes[i + 1].Reset();
	}
}

int s1Index = -1;
int s2Index = -1;

for(int i = 0; i < leftNodes.Count; i++)
{
	//Console.WriteLine(idToString[leftNodes[i].id]);
	if(leftNodes[i].id == s1)
		s1Index = i;
	if(leftNodes[i].id == s2)
		s2Index = i;
}
Console.WriteLine((s1Index + 1) * (s2Index + 1));

class Node
{
	List<Object> vals; //mixed list of int and Node??
	public int nodeIndex = 0;
	public bool isDone => vals == null ? true : (nodeIndex == vals.Count);
	public Node Parent;
	public int id;

	public Node(List<object> vals, Node parent)
	{
		this.vals = vals;
		if(vals == null) vals = new List<object>();
		Parent = parent;
	}
	public void AddVal(Object val)
	{
		if(vals == null) vals = new List<object>();
		vals.Add(val);
	}

	public Object GetNext()
	{
		if(isDone) return -1;
		var toReturn = vals[nodeIndex];
		nodeIndex++;
		return toReturn;
	}

	public void Reset()
	{
		nodeIndex = 0;
		if(vals == null) return;
		for(int i = 0; i < vals.Count; i++)
		{
			if(vals[i] is Node node)
			{
				node.Reset();
			}
		}
	}

	public static bool Compare(Node left, Node right)
	{
		while(!left.isDone && left.vals != null)
		{
			var l = left.GetNext();
			var r = right.GetNext();
			if(l is int && r is int)
			{
				//Console.WriteLine($"Compare {(int) l} and {(int) r}");
				//If the left list runs out of items first, the inputs are in the right order.
				//If the right list runs out of items first, the inputs are not in the right order.
				if((int) l == -1) return true;
				if((int) r == -1) return false;

				if((int) l > (int) r)
				{
					//Console.WriteLine("right smaller, wrong order");
					return false;
				}
				else if((int) l < (int) r)
				{
					//Console.WriteLine("left smaller, right order");
					return true;
				}
				else
				{
					continue;
				}

			}
			else if(l is Node && r is Node)
			{
				//Console.WriteLine($"Compare list and list");
				return Compare((Node) l, (Node) r);
			}
			else //1 of each type
			{
				if(l is Node)
				{
					if((int) r == -1) return false;
					//Console.WriteLine($"Compare list and {(int) r}");
					return Compare((Node) l, new Node(new List<object>() { (int) r }, right));
				}
				else // r is Node
				{
					if((int) l == -1) return true;
					//Console.WriteLine($"Compare {(int) l} and list");
					return Compare(new Node(new List<object>() { (int) l }, left), (Node) r);
				}
			}
		}
		//go back up to parents and continue comparing?
		Node leftCompare = left;
		Node rightCompare = right;
		if(left.isDone && left.Parent != null)
		{
			leftCompare = leftCompare.Parent;
		}
		if(right.isDone && right.Parent != null)
		{
			rightCompare = rightCompare.Parent;
		}
		if(leftCompare != left && rightCompare != right) //more comparing to do
			return Compare(leftCompare, rightCompare);

		return true;
	}
}

public static class Extensions
{
	public static void Swap<T>(this List<T> list, int i, int j)
	{
		T temp = list[i];
		list[i] = list[j];
		list[j] = temp;
	}
}