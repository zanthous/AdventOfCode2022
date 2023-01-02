/* part 2 I just used a spreadsheet, used data from every 1000 iterations
 * part 1's solution can be gotten by looping only until 2022
 * 
 * 217042 + 

264400 * 5780346

((1t / 173000) * 264400) + 217042


(1tril / number of indices it takes for the pattern to repeat (173000)) * difference between repetitions (264400)
+ mod 1tril and run the simulation for this many steps to get a result
*/

//#define DRAW
internal class Program
{
	private static void Main(string[] args)
	{
		string text = File.ReadAllText("input.txt");
		//string text = ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>";

		int lastRockIndex;
		List<int[]> rocks = new List<int[]>
{
	new []{ 1,1,1,1},
	new []{ 0, 1, 0, 0,
	1,1,1,0,
	0,1,0,0},
	new []{ 1,1,1,0,
	0,0,1,0,
	0,0,1,0
	},
	new []{ 1,0,0,0,
	1,0,0,0,
	1,0,0,0,
	1,0,0,0
	},
	new []{ 1,1,0,0,
	1,1,0,0
	}
};
		List<List<(int, int)>> downCollisionChecks = new()
{
	new List<(int, int)>()
	{
		(0,-1),
		(1,-1),
		(2,-1),
		(3,-1)
	},
	new List<(int, int)>()
	{
		(0,0),
		(1,-1),
		(2,0)
	},
	new List<(int, int)>()
	{
		(0,-1),
		(1,-1),
		(2,-1),
	},
	new List<(int, int)>()
	{
		(0,-1),
	},
	new List<(int, int)>()
	{
		(0,-1),
		(1,-1),
	}
};
		List<List<(int, int)>> rightCollisionChecks = new()
{
	new List<(int, int)>()
	{
		(4,0),
	},

	new List<(int, int)>()
	{
		(2,0),
		(3,1),
		(2,2)
	},
	new List<(int, int)>()
	{
		(3,0),
		(3,1),
		(3,2),
	},
	new List<(int, int)>()
	{
		(1,0),
		(1,1),
		(1,2),
		(1,3),
	},
	new List<(int, int)>()
	{
		(2,0),
		(2,1),
	}
};
		List<List<(int, int)>> leftCollisionChecks = new()
{
	new List<(int, int)>()
	{
		(-1,0),
	},

	new List<(int, int)>()
	{
		(0,0),
		(-1,1),
		(0,2)
	},
	new List<(int, int)>()
	{
		(-1,0),
		(1,1),
		(1,2),
	},
	new List<(int, int)>()
	{
		(-1,0),
		(-1,1),
		(-1,2),
		(-1,3),
	},
	new List<(int, int)>()
	{
		(-1,0),
		(-1,1),
	}
};

		Console.WriteLine(text.Length);

		List<int> yValues = new List<int>();
		List<int> rockLength = new List<int> { 4, 3, 3, 1, 2 };

		int highestRock = 1;
		int rockIndex = 0;

		int[,] level = new int[9, 2400000 * 4];

		for(int i = 0; i < 2400000 * 4; i++)
		{
			for(int j = 0; j < 9; j++)
			{
				if(j == 0 || j == 8 || i == 0)
					level[j, i] = 1;
			}
		}

		(int, int) currentRock;
		int windIndex = 0;

		for(int i = 0; i < 50455 * 64; i++)
		{
			//if(i % 10091 == 0)
			if(i % 1000 == 0)
				Console.WriteLine($"{i}");//{highestRock - 1}{i}
			SpawnRock();
			var result = false;
			while(!result)
			{
				result = MoveRock();
			}
		}
		Console.WriteLine(highestRock - 1);
		//DrawLevel();
		//for(int i = 0; i < yValues.Count; i++)
		//{
		//	Console.WriteLine(yValues[i]);
		//}
		int stopppp = 0;

		(int, int) GetSpawn()
		{
			return (3, highestRock + 3);
		}

		bool MoveRock()
		{
			//push wind
			var dir = GetWind();

			if(!dir && !Collides(2))
			{
				DrawRock(lastRockIndex, currentRock, true);
#if DRAW
				Console.Clear();
				DrawLevel();
				int stop = 0;
#endif
				currentRock = (currentRock.Item1 - 1, currentRock.Item2);
				DrawRock(lastRockIndex, currentRock, false);
#if DRAW
				Console.Clear();
				DrawLevel();
				int stop1 = 0;
#endif
			}
			else if(dir && !Collides(1)) //right
			{
				DrawRock(lastRockIndex, currentRock, true);
#if DRAW
				Console.Clear();
				DrawLevel();
				int stop = 0;
#endif
				currentRock = (currentRock.Item1 + 1, currentRock.Item2);
				DrawRock(lastRockIndex, currentRock, false);
#if DRAW
				Console.Clear();
				DrawLevel();
				int stop1 = 0;
#endif
			}
			//tick physics
			if(Collides(0))
			{
				highestRock = Math.Max(currentRock.Item2 + rocks[lastRockIndex].Length / 4, highestRock);
				return true;
			}
			else
			{
				DrawRock(lastRockIndex, currentRock, true);
#if DRAW
				Console.Clear();
				DrawLevel();
				int stop = 0;
#endif
				currentRock = (currentRock.Item1, currentRock.Item2 - 1);
				DrawRock(lastRockIndex, currentRock, false);
#if DRAW
				Console.Clear();
				DrawLevel();
				int stop1 = 0;
#endif
			}

			return false;
		}
		//0 down 1 right 2 left
		bool Collides(int dir)
		{
			List<List<(int, int)>> list = downCollisionChecks;
			switch(dir)
			{
				case 0:
					list = downCollisionChecks;
					break;
				case 1:
					list = rightCollisionChecks;
					break;
				case 2:
					list = leftCollisionChecks;
					break;
			}
			for(int i = 0; i < list[lastRockIndex].Count; i++)
			{
				var x = currentRock.Item1 + list[lastRockIndex][i].Item1;
				var y = currentRock.Item2 + list[lastRockIndex][i].Item2;
				if(level[x, y] == 1)
				{
					return true;
				}
			}
			return false;
		}

		bool GetWind()
		{
			var result = text[windIndex] == '>';
			windIndex = (windIndex + 1) % text.Length;

			return result;
		}
		void SpawnRock()
		{
			lastRockIndex = rockIndex;
			currentRock = GetSpawn();
			DrawRock(rockIndex, currentRock, false);
			rockIndex = (rockIndex + 1) % rocks.Count;
		}

		void DrawRock(int rockIndex, (int, int) pos, bool erase)
		{
			if(!erase)
			{
				for(int y = 0; y < rocks[rockIndex].Length / 4; y++)
				{
					for(int x = 0; x < 4; x++)
					{
						if(rocks[rockIndex][y * 4 + x] == 1)
							level[pos.Item1 + x, pos.Item2 + y] = 1;
					}
				}
			}
			else
			{
				for(int y = 0; y < rocks[rockIndex].Length / 4; y++)
				{
					for(int x = 0; x < 4; x++)
					{
						if(rocks[rockIndex][y * 4 + x] == 1)
							level[pos.Item1 + x, pos.Item2 + y] = 0;
					}
				}
			}
		}

		void DrawLevel()
		{
			for(int y = 150; y > 90; y--)
			{
				var result = true;
				for(int x = 0; x < 9; x++)
				{
					if(!(x == 0 || x == 8) && level[x, y] == 1)
						result = false;
					Console.Write(level[x, y] == 1 ? '#' : '.');
				}
#if !DRAW
				if(result)
				{
					yValues.Add(y);
				}
#endif
				Console.WriteLine();
			}
		}
	}
}