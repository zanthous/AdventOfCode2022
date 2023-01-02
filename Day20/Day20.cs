var text = File.ReadAllLines("input.txt");
long[] numbers = new long[text.Length];
long key = 811589153;
int shuffles = 10;

for(int i = 0; i < text.Length; i++)
{
	numbers[i] = int.Parse(text[i]) * key;
}

Node[] toShift = new Node[text.Length];
CircularDoublyLinkedList list = new CircularDoublyLinkedList();

for(int i = 0; i < numbers.Length; i++)
{
	var node = list.AddToEnd(numbers[i]);
	toShift[i] = node;
}

for(int i = 0; i < shuffles; i++)
{
	for(int j = 0; j < numbers.Length; j++)
	{
		list.Shift(toShift[j], numbers[j]);
	}
}

void Print()
{
	var n = list.Head;
	Console.WriteLine(n.Data);
	for(int a = 0; a < text.Length - 1; a++)
	{
		n = n.Next;
		Console.WriteLine(n.Data);
	}
	Console.WriteLine();
	Console.WriteLine();
	Console.WriteLine();
}
Node temp = list.Head;
for(int i = 0; i < text.Length; i++)
{
	temp = temp.Next;
	if(temp.Data == 0)
		break;
}

long result = 0;
for(int i = 0; i < 3000; i++)
{
	temp = temp.Next;
	if(i == 999 || i == 1999 || i == 2999)
	{
		result += temp.Data;
	}
}
//p2
Console.WriteLine(result);

//var n = list.Head;
//for(int a = 0; a < text.Length; a++)
//{
//	Console.WriteLine(n.Data);
//	n = n.Next;
//}
//Console.WriteLine();
//Console.WriteLine();
//Console.WriteLine();


class Node
{
	public long Data { get; set; }
	public Node Prev { get; set; }
	public Node Next { get; set; }
}

class CircularDoublyLinkedList
{
	public Node Head { get; set; }

	public int Count { get; private set; }


	public Node AddToEnd(long data)
	{
		Node newNode = new Node { Data = data };

		if(Head == null)
		{
			Head = newNode;
			Head.Prev = Head;
			Head.Next = Head;
		}
		else
		{
			newNode.Prev = Head.Prev;
			newNode.Next = Head;
			Head.Prev.Next = newNode;
			Head.Prev = newNode;
		}
		Count++;
		return newNode;
	}

	public void Shift(Node node, long steps)
	{
		long copy = steps;
		if((Math.Abs(copy) % (long) (Count - 1) == 0) || steps == 0)
		{
			return;
		}

		if(steps > (long) (Count - 1) || steps < (long) (-Count + 1))
		{

			steps = (steps % (long) (Count - 1));
		}

		Node target = node;
		Node swapHead = Head;
		bool swap = false;
		if(node == Head)
		{
			swapHead = node.Next;
			swap = true;
		}

		if(steps > 0)
		{
			while(steps > 0)
			{
				target = target.Next;
				steps--;
			}

			node.Next.Prev = node.Prev;
			node.Prev.Next = node.Next;

			Node afterTarget = target.Next;
			target.Next = node;
			node.Prev = target;
			node.Next = afterTarget;
			afterTarget.Prev = node;
		}
		else
		{
			while(steps < 0)
			{
				target = target.Prev;
				steps++;
			}

			node.Next.Prev = node.Prev;
			node.Prev.Next = node.Next;


			Node beforeTarget = target.Prev;
			beforeTarget.Next = node;
			node.Prev = beforeTarget;
			node.Next = target;
			target.Prev = node;
		}
		//put in position
		if(swap)
			Head = swapHead;
	}
}