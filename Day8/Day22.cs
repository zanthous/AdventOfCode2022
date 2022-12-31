//using System.Data;
//using System.Diagnostics;
//using System.Text;
//using System.Text.RegularExpressions;

//var text = File.ReadAllText("input.txt").Split("\r\n\r\n");
//var tempMap = text[0].Split("\r\n");
////StringBuilder[] map = new StringBuilder[tempMap.Length];
//int[][] map = new int[tempMap.Length][];
//int[][][] _3dMap = new int[6][][];
////for(int i = 0; i < tempMap.Length; i++)
////{
////	map[i] = new StringBuilder(tempMap[i]);
////}
//int faceSize = 50;
//for(int i = 0; i < map.Length; i++)
//{
//	map[i] = new int[faceSize*3];
//	for(int j = 0; j < faceSize*3; j++)
//	{
//		if(j < tempMap[i].Length)
//		{
//			map[i][j] = (int) tempMap[i][j] == ' ' ? 0 : (int) tempMap[i][j];
//		}
//	}
//}

//for(int i = 0; i < _3dMap.Length; i++)
//{
//	_3dMap[i] = new int[faceSize][];
//	for(int j = 0; j < faceSize; j++)
//	{
//		_3dMap[i][j] = new int[faceSize];
//	}
//}
////this one is pretty hard to do fully programatically so I'm going to hardcode the inputs
////3dmap is stored as index of cube, y, x
////upper right
//int xOffset = 2 * faceSize;
//int yOffset = 0;
//for(int x = 0; x < faceSize; x++)
//{
//	for(int y = 0; y < faceSize; y++)
//	{
//		_3dMap[0][y][x] = map[y + yOffset][x + xOffset];
//	}
//}
//xOffset = faceSize;
//for(int x = 0; x < faceSize; x++)
//{
//	for(int y = 0; y < faceSize; y++)
//	{
//		_3dMap[1][y][x] = map[y + yOffset][x + xOffset];
//	}
//}
//yOffset = faceSize;
//xOffset = faceSize;
//for(int x = 0; x < faceSize; x++)
//{
//	for(int y = 0; y < faceSize; y++)
//	{
//		_3dMap[2][y][x] = map[y + yOffset][x + xOffset];
//	}
//}
//xOffset = faceSize;
//yOffset = faceSize * 2;
//for(int x = 0; x < faceSize; x++)
//{
//	for(int y = 0; y < faceSize; y++)
//	{
//		_3dMap[3][y][x] = map[y + yOffset][x + xOffset];
//	}
//}
//xOffset = 0;
//yOffset = faceSize * 2;
//for(int x = 0; x < faceSize; x++)
//{
//	for(int y = 0; y < faceSize; y++)
//	{
//		_3dMap[4][y][x] = map[y + yOffset][x + xOffset];
//	}
//}
//xOffset = 0;
//yOffset = faceSize * 3;
//for(int x = 0; x < faceSize; x++)
//{
//	for(int y = 0; y < faceSize; y++)
//	{
//		_3dMap[5][y][x] = map[y + yOffset][x + xOffset];
//	}
//}

//var directions = text[1];

//var dir = new List<(int, int)>
//{
//	( 1,0 ),
//	( 0,1 ),
//	( -1,0 ),
//	( 0,-1)
//};
//var orientation = 0;
//char orientationChar = '>';

//List<List<int>> newOrientations = new List<List<int>>() // O
//{
//	new List<int>(){2,2,2,3},
//	new List<int>(){0,1,0,0},
//	new List<int>(){3,1,1,3},
//	new List<int>(){2,2,2,3},
//	new List<int>(){0,1,0,0},
//	new List<int>(){3,1,1,3}
//};
//List<List<int>> connections = new List<List<int>> // O
//{
//	new List<int>(){3, 2, 1, 5}, //face, orientation -> face
//	new List<int>(){0, 2, 4, 5},
//	new List<int>(){0, 3, 4, 1},
//	new List<int>(){0, 5, 4, 2},
//	new List<int>(){3, 5, 1, 2}, //4
//	new List<int>(){3, 0, 1, 4}
//};

//void Rotate(char c)
//{
//	if(c == 'R')
//	{
//		orientation = (orientation + 1) % 4;
//	}
//	else
//	{
//		if((orientation - 1) < 0)
//		{
//			orientation = 3;
//		}
//		else
//		{
//			orientation = (orientation - 1) % 4;
//		}
//	}
//	switch(orientation)
//	{
//		case 0:
//			orientationChar = '>';
//			break;
//		case 1:
//			orientationChar = 'v';
//			break;
//		case 2:
//			orientationChar = '<';
//			break;
//		case 3:
//			orientationChar = '^';
//			break;
//	}
//}
//string pattern = @"\d{1,2}[a-zA-Z]|\d{1,2}"; //it ends without a turn to match the distance
//var matches = Regex.Matches(directions, pattern);
//var distances = new List<int>();
//var turns = new List<char>();
//int face = 1;
//for(int i = 0; i < matches.Count; i++)
//{
//	var m = matches[i];
//	var s = m.ToString();
//	//distances.Add()
//	if(i != matches.Count - 1)
//	{
//		turns.Add(s[^1]);
//		var length = s.Length == 3 ? 2 : 1;
//		distances.Add(int.Parse(s.Substring(0, length)));
//	}
//	else
//	{
//		distances.Add(int.Parse(s));
//	}
//}
//int currentInstruction = 0;
//orientationChar = '>';
//orientation = 0;
//face = 1;
//(int, int) pos = (0, 0);

////for(int i = 0; i < map.Length; i++)
////{
////	if(map[0][i] != 0)
////	{
////		pos = (i, 0);
////		break;
////	}
////}

//void GetTransformedPosition()
//{
//	var newOrientation = newOrientations[face][orientation];
//	face = connections[face][orientation];
//	if(orientation == 0)
//	{
//		if(newOrientation == 2)//from right to left side
//		{
//			pos = (faceSize-1, faceSize - pos.Item2 - 1); // O
//		}
//		else if(newOrientation == 3) //right to up
//		{
//			pos = (pos.Item2, faceSize - 1); // O
//		}
//		else if(newOrientation == 0)// right
//		{
//			pos = (0, pos.Item2); // O
//		}
//		else
//		{
//			Console.WriteLine("unexpected");
//		}
//	}
//	else if(orientation == 1) //down to [left, down]
//	{
//		if(newOrientation == 1)//down
//		{
//			pos = (pos.Item1, 0); // O
//		}
//		else if(newOrientation == 2)
//		{
//			pos = (faceSize - 1, pos.Item1); // O
//		}
//		else
//		{
//			Console.WriteLine("unexpected");
//		}
//	}
//	else if(orientation == 2) // left to
//	{
//		if(newOrientation == 0) //right
//		{
//			pos = (0, faceSize - 1 - pos.Item2); // O
//		}
//		else if(newOrientation == 1) // down
//		{
//			//low y = low x 
//			pos = (pos.Item2, 0);// O
//		}
//		else if(newOrientation == 2)
//		{
//			pos = (faceSize - 1, pos.Item2); // O
//		}
//		else
//		{
//			Console.WriteLine("unexpected");
//		}
//	}
//	else if(orientation == 3) // up to
//	{
//		if(newOrientation == 3) // up
//		{
//			pos = (pos.Item1, faceSize - 1);
//		}
//		else if(newOrientation == 0) // right
//		{
//			pos = (0, pos.Item1);
//		}
//		else
//		{
//			Console.WriteLine("unexpected");
//		}
//	}
//	orientation = newOrientation;
//	switch(orientation)
//	{
//		case 0:
//			orientationChar = '>';
//			break;
//		case 1:
//			orientationChar = 'v';
//			break;
//		case 2:
//			orientationChar = '<';
//			break;
//		case 3:
//			orientationChar = '^';
//			break;
//	}
//}

//for(int i = 0; i < distances.Count; i++)
//{
//	var preMove = pos;
//	var preFace = face;
//	var previousOrientation = orientation;
//	currentInstruction = distances[i];
//	while(_3dMap[face][pos.Item2][pos.Item1] != '#' && currentInstruction > 0)
//	{
//		_3dMap[face][pos.Item2][pos.Item1] = orientationChar;
//		pos = (pos.Item1 + dir[orientation].Item1, pos.Item2 + dir[orientation].Item2);
//		if(pos.Item2 >= faceSize || pos.Item2 < 0 || pos.Item1 >= faceSize || pos.Item1 < 0)
//		{
//			//back up 1
//			pos = (pos.Item1 - dir[orientation].Item1, pos.Item2 - dir[orientation].Item2);
//			GetTransformedPosition();
//			//part 1 method
//			//while(!(pos.Item2 >= map.Length || pos.Item2 < 0 || pos.Item1 >= map[pos.Item2].Length || (pos.Item1 < 0)) && map[pos.Item2][pos.Item1] != 0)
//			//{
//			//	pos = (pos.Item1 - dir[orientation].Item1, pos.Item2 - dir[orientation].Item2);
//			//}
//			//pos = (pos.Item1 + dir[orientation].Item1, pos.Item2 + dir[orientation].Item2);
//			if(_3dMap[face][pos.Item2][pos.Item1] == '#')
//			{
//				pos = preMove;
//				face = preFace;
//				orientation = previousOrientation;
//				break;
//			}
//		}
//		preFace = face;
//		preMove = pos;
//		currentInstruction--;
//	}
//	if(_3dMap[face][pos.Item2][pos.Item1] == '#')
//	{
//		//back up
//		pos = (pos.Item1 - dir[orientation].Item1, pos.Item2 - dir[orientation].Item2);
//	}
//	if(i != distances.Count - 1)
//	{
//		Rotate(turns[i]);
//	}

//	//Console.WriteLine($"i:{i} {pos}");
//}

//_3dMap[face][pos.Item2][pos.Item1] = orientationChar;


////for(int f = 0; f < 6; f++)
////{
////	for(int y = 0; y < faceSize; y++)
////	{
////		for(int x = 0; x < faceSize; x++)
////		{
////			Console.Write(_3dMap[f][y][x] == 0 ? ' ' : (char) _3dMap[f][y][x]);
////		}
////		Console.WriteLine();
////	}
////	Console.WriteLine();
////}


////final face is 3?
//xOffset = faceSize;
//yOffset = faceSize * 2;
//Console.WriteLine($"face {face}");
//Console.WriteLine((1000 * (pos.Item2 + 1 + yOffset)) + (4 * (pos.Item1 + 1 + xOffset)) + orientation);