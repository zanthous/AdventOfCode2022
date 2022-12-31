//bool debug = false;
//var text = File.ReadAllText("input.txt").Split("\r\n");

////char[][] elves = new char[text.Length][];

//HashSet<(int, int)> elves = new HashSet<(int, int)>();

//for(int i = text.Length - 1; i > -1; i--)
//{
//	//elves[i] = new char[text[i].Length];
//	for(int j = 0; j < text[i].Length; j++)
//	{
//		if(text[i][j] == '#')
//			elves.Add((j, text.Length -1 - i));
//		//elves[i][j] = text[i][j];
//	}
//}

//Print();
//List<(int, int)> dir = new List<(int, int)>()
//{
//	(-1, 1), //NW 0
//	(0, 1), //N 1
//	(1, 1), //NE 2
//	(1, 0), //E 3
//	(1, -1), //SE 4
//	(0, -1), //S 5
//	(-1, -1), //SW 6 
//	(-1, 0) //W 7
//};

////3 dir indicies for where to check and another dir index for where to move
//List<(int, int, int, int)> instructions = new List<(int, int, int, int)>()
//{
//	(0,1,2,1),
//	(4,5,6,5),
//	(0,6,7,7),
//	(2,3,4,3)
//};

//int instructionIndex = 0;
//void NextInstruction()
//{
//	instructionIndex = (instructionIndex + 1) % instructions.Count;
//}

////starting pos proposed pos,
////if key already exists, set it to some garbage data marking that multiple elves want to go to it
////clear every round
//Dictionary<(int, int), (int,int)> proposals = new ();
//List<(int, int)> clearedRoundOne = new();
//int roundNumber = 0;
//int moved = 0;

//do
//{
//	foreach(var e in elves)
//	{
//		if(Check8(e)) clearedRoundOne.Add(e);
//	}
//	//round 2 
//	for(int j = 0; j < clearedRoundOne.Count; j++)
//	{
//		Check3(clearedRoundOne[j]);
//	}
//	moved = 0;
//	foreach(var toFrom in proposals)
//	{
//		if(toFrom.Value != (int.MinValue, int.MinValue))
//		{
//			elves.Remove(toFrom.Value);
//			elves.Add(toFrom.Key);
//			moved++;
//		}
//	}

	

//	Print();

//	roundNumber++;
//	clearedRoundOne.Clear();
//	proposals.Clear();
//	NextInstruction();
//} while(moved > 0);
//Console.WriteLine(roundNumber);


////int xSize = xMax - xMin;
////int ySize = yMax - yMin;
////int area = (xSize+1) * (ySize+1);
////int emptySquares = area - elves.Count;
////Console.WriteLine(emptySquares);
//void Print()
//{
//	if(!debug) return;
//	Console.WriteLine();
//	int xMin = int.MaxValue;
//	int xMax = int.MinValue;
//	int yMin = int.MaxValue;
//	int yMax = int.MinValue;

//	foreach(var e in elves)
//	{
//		xMin = Math.Min(xMin, e.Item1);
//		xMax = Math.Max(xMax, e.Item1);
//		yMin = Math.Min(yMin, e.Item2);
//		yMax = Math.Max(yMax, e.Item2);
//	}
//	for(int y = yMax; y > yMin - 1; y--)
//	{
//		for(int x = xMin; x <= xMax; x++)
//		{
//			if(elves.Contains((x, y)))
//			{
//				Console.Write('#');
//			}
//			else
//			{
//				Console.Write('.');
//			}
//		}
//		Console.WriteLine();
//	}
//	Console.WriteLine();
//	Console.WriteLine();
//	Console.WriteLine();
//}

////true if one elf is in any adjacent square
//bool Check8((int,int) pos)
//{
//	for(int i = 0; i < dir.Count; i++)
//	{
//		if(elves.Contains((pos.Item1 + dir[i].Item1, pos.Item2 + dir[i].Item2)))
//			return true;
//	}
//	return false;
//}

////true if shouldmove
//void Check3((int,int) pos)
//{
//	int instruction = instructionIndex-1;
//	(int, int) targetOffset, targetPos, newPos, offset;
//	for(int i = 0; i < instructions.Count; i++)
//	{
//		instruction++;
//		instruction = (instruction % instructions.Count);
//		targetOffset = dir[instructions[instruction].Item4];
//		targetPos = (pos.Item1 + targetOffset.Item1, pos.Item2 + targetOffset.Item2);
//		offset = dir[instructions[instruction].Item1];
//		newPos = (pos.Item1 + offset.Item1, pos.Item2 + offset.Item2);
//		if(elves.Contains(newPos))
//			continue;
//		offset = dir[instructions[instruction].Item2];
//		newPos = (pos.Item1 + offset.Item1, pos.Item2 + offset.Item2);
//		if(elves.Contains(newPos))
//			continue;
//		offset = dir[instructions[instruction].Item3];
//		newPos = (pos.Item1 + offset.Item1, pos.Item2 + offset.Item2);
//		if(elves.Contains(newPos))
//			continue;
//		if(!proposals.ContainsKey(targetPos))
//		{
//			proposals.Add(targetPos, pos);
//			return;
//		}
//		else
//		{
//			proposals[targetPos] = (int.MinValue, int.MinValue); //multiple elves want to move here
//			return;
//		}
//	}

//}