//// See https://aka.ms/new-console-template for more information
//using System.Diagnostics;
//using System.Resources;
//using System.Collections;
//using System.Text.RegularExpressions;

//var text = File.ReadAllLines("input5.txt");
//int total = 0;

//char[][] boxes = new char[9][];
//for(int i = 0; i < boxes.Length; i++)
//{
//	boxes[i] = new char[128];
//}


//for(int i = 0; i < 8; i++)
//{
//	for(int j = 1; j < text[i].Length; j += 4)
//	{
//		var pos = 8 - i - 1;
//		boxes[j / 4][pos] = char.IsLetter(text[i][j]) ? text[i][j] : '\0';
//	}
//}

//int asd = 0;
//for(int i = 10; i < text.Length; i++)
//{
//	MatchCollection matches = Regex.Matches(text[i], @"\d+");

//	// Create an array to store the numbers.
//	int[] numbers = new int[matches.Count];
//	Debug.Assert(numbers.Length == 3);

//	// Loop through the matches and convert each number to an integer.
//	for(int j = 0; j < matches.Count; j++)
//	{
//		numbers[j] = int.Parse(matches[j].Value);
//	}

//	//find first empty char in target
//	var targetStack = (numbers[2]-1);
//	int destinationIndex = -1;
//	for(int j = 0; j < boxes[targetStack].Length; j++)
//	{
//		if(boxes[targetStack][j] == '\0')
//		{
//			destinationIndex = j;
//			break;
//		}
//	}
//	var fromStack = (numbers[1]-1);

//	//find last crate in source stack
//	//int sourceIndex = -1;
//	//for(int j = 0; j < boxes[fromStack].Length; j++)
//	//{
//	//	if(boxes[fromStack][j] == '\0')
//	//	{
//	//		sourceIndex = j - 1;
//	//		break;
//	//	}
//	//}
//	var nToCopy = numbers[0];
//	int sourceIndex = -1;
//	for(int j = 0; j < boxes[fromStack].Length; j++)
//	{
//		if(boxes[fromStack][j] == '\0')
//		{
//			sourceIndex = j - 1;
//			break;
//		}
//	}
//	sourceIndex -= nToCopy - 1;

//	//copy chars over
//	//int movedBoxes = 0;
//	//for(int j = destinationIndex; j < destinationIndex + nToCopy; j++)
//	//{
//	//	//we have to copy boxes backward
//	//	boxes[targetStack][j] = boxes[fromStack][sourceIndex - movedBoxes];
//	//	//delete copied chars
//	//	boxes[fromStack][sourceIndex - movedBoxes] = '\0';
//	//	movedBoxes++;
//	//}
//	int movedBoxes = 0;
//	for(int j = destinationIndex; j < destinationIndex + nToCopy; j++)
//	{
//		//we have to copy boxes backward
//		boxes[targetStack][j] = boxes[fromStack][sourceIndex + movedBoxes];
//		//delete copied chars
//		boxes[fromStack][sourceIndex + movedBoxes] = '\0';
//		movedBoxes++;
//	}

//	//delete copied chars
//}

//int x = 0;
//string s = "";
//for(int i = 0; i < boxes.Length; i++)
//{
//	for(int j = 0; j < boxes[i].Length; j++)
//	{
//		if(boxes[i][j] == '\0')
//		{
//			if(j-1>= 0)
//			{ 
//				s += boxes[i][j - 1];
//			}
//			else
//			{
//				s += " ";
//				Console.WriteLine("why is it empty");
//			}
//			break;
//		}
//	}
//}
//Console.WriteLine(s);

//int a = 0;

using System.Text.RegularExpressions;

var text = File.ReadAllLines("input.txt");

//parse manually
//List<char>[] boxes = new List<char>[9];
//for(int i = 0; i < boxes.Length; i++)
//{
//	boxes[i] = new List<char>();
//}

//for(int i = 0; i < 8; i++)
//{
//	for(int j = 1; j < text[i].Length; j += 4)
//	{
//		if(text[i][j] != ' ')
//			boxes[j / 4].Insert(0, text[i][j]);
//	}
//}


//write input data
var boxes = new List<char>[]
{
	new List<char>("HBVWNMLP"),
	new List<char>("MQH"),
	new List<char>("NDBGFQML"),
	new List<char>("ZTFQMWG"),
	new List<char>("MTHP"),
	new List<char>("CBMJDHGT"),
	new List<char>("MNBFVR"),
	new List<char>("PLHMRGS"),
	new List<char>("PDBCN")
};


for(int i = 10; i < text.Length; i++)
{
	MatchCollection matches = Regex.Matches(text[i], @"\d+");

	var toMove = int.Parse(matches[0].Value);
	var from = int.Parse(matches[1].Value) - 1;
	var to = int.Parse(matches[2].Value) - 1;

	boxes[to].AddRange(boxes[from].Skip(boxes[from].Count - toMove));
	boxes[from].RemoveRange(boxes[from].Count - toMove, toMove);
}

string s = "";
for(int i = 0; i < boxes.Length; i++)
{
	s += boxes[i].Last();
}
Console.WriteLine(s);
