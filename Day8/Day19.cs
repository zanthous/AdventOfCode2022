//using System.Collections.Concurrent;
//using System.Diagnostics;
//using System.Threading;

//var text = File.ReadAllLines("input.txt");
//ushort problems = 3;
//ushort maxtimeP1 = 30;
//ushort memoThreshold = 28;

//ushort[] time = new ushort[problems];

//ushort[][] oreBot = new ushort[problems][];
//ushort[][] clayBot = new ushort[problems][];
//ushort[][] obsidianBot = new ushort[problems][];
//ushort[][] geodeBot = new ushort[problems][];
//ushort[][] ores = new ushort[problems][];
//ushort[][] clay = new ushort[problems][];
//ushort[][] obsidian = new ushort[problems][];
//ushort[][] geodes = new ushort[problems][];

//for(ushort i = 0; i < problems; i++)
//{
//	oreBot[i] = new ushort[maxtimeP1];
//	clayBot[i] = new ushort[maxtimeP1];
//	obsidianBot[i] = new ushort[maxtimeP1];
//	geodeBot[i] = new ushort[maxtimeP1];
//	ores[i] = new ushort[maxtimeP1];
//	clay[i] = new ushort[maxtimeP1];
//	obsidian[i] = new ushort[maxtimeP1];
//	geodes[i] = new ushort[maxtimeP1];
//}

//ushort[] orebotCost = new ushort[problems];
//ushort[] claybotCost  = new ushort[problems];
//ushort[] obsidianbotCost  = new ushort[problems];
//ushort[] obsidianCostClay  = new ushort[problems];
//ushort[] geodeBotCost  = new ushort[problems];
//ushort[] geodeBotCostObsidian = new ushort[problems];

//ushort[] greatestOreCost = new ushort[problems];

//for(ushort i = 0; i < problems; i++)
//{
//	var s = text[i].Split(' ').Take(6).Select(x => ushort.Parse(x)).ToList();
//	orebotCost[i] = s[0];
//	claybotCost[i] = s[1];
//	obsidianbotCost[i] = s[2];
//	obsidianCostClay[i] = s[3];
//	geodeBotCost[i] = s[4];
//	geodeBotCostObsidian[i] = s[5];
//	greatestOreCost[i] = Math.Max(Math.Max(Math.Max(orebotCost[i], obsidianbotCost[i]), geodeBotCost[i]), claybotCost[i]);
//}

//HashSet<(ushort, ushort, ushort, ushort, ushort, ushort, ushort, ushort)>[] memo =
//	new HashSet<(ushort, ushort, ushort, ushort, ushort, ushort, ushort, ushort)>[problems];

//for(ushort i = 0; i < problems; i++)
//{
//	memo[i] = new HashSet<(ushort, ushort, ushort, ushort, ushort, ushort, ushort, ushort)>();
//	oreBot[i][0] = 1;
//}
//ushort[] tri = new ushort[maxtimeP1+1];
//for(ushort i = 0; i < maxtimeP1+1; i++)
//{
//	tri[i] = Triangle(i);
//}


////Blueprushort 1: Each ore robot costs 4 ore.
////Each clay robot costs 4 ore.
////Each obsidian robot costs 2 ore and 7 clay.
////Each geode robot costs 4 ore and 13 obsidian.

//Stopwatch stopwatch = new Stopwatch();
//stopwatch.Start();
//ushort[] highestGeodes = new ushort[problems];
////bool oneAt20 = false;
//Thread[] myThreads = new Thread[problems];
//ushort[] threadNumbers = new ushort[problems];

//for(ushort i = 0; i < problems; i++)
//{
//	ushort localI = i;
//	ThreadStart start = new(() => Solve(localI));
//	myThreads[i] = new Thread(start);
//	myThreads[i].Start();
//}
//foreach(Thread thread in myThreads)
//{
//	thread.Join();
//}
//int result = highestGeodes[0] * highestGeodes[1] * highestGeodes[2];
////for(ushort i = 0; i < problems; i++)
////{
////	result += (i + 1) * highestGeodes[i];
////}

//stopwatch.Stop();
//Console.WriteLine(result);
//Console.WriteLine(stopwatch.ElapsedMilliseconds);

//ushort Triangle(ushort timeLeft)
//{
//	ushort bots = 1;
//	ushort total = 0;
//	for(ushort i = 1; i < timeLeft; i++)
//	{
//		total += bots;
//		bots++;
//	}
//	return total;
//}

//void Solve(ushort problem)
//{
//	if(time[problem] < memoThreshold && memo[problem].TryGetValue((time[problem], ores[problem][time[problem]],
//		clay[problem][time[problem]], obsidian[problem][time[problem]],
//		geodes[problem][time[problem]], oreBot[problem][time[problem]],
//		clayBot[problem][time[problem]], obsidianBot[problem][time[problem]]), out _))
//	{
//		time[problem]--; return;
//	}

//	if(geodes[problem][time[problem]] + tri[maxtimeP1 - time[problem] - 1] < highestGeodes[problem])
//	{
//		time[problem]--; return;
//	}

//	for(ushort i = 0; i < 3; i++)
//	{
//		if(time[problem] >= maxtimeP1 - 1)
//		{
//			break;
//		}

//		//always make a geodebot if possible
//		if(ores[problem][time[problem]] >= geodeBotCost[problem] && obsidian[problem][time[problem]] >= geodeBotCostObsidian[problem])
//		{
//			time[problem]++;
//			TickResources(problem);
//			obsidian[problem][time[problem]] -= geodeBotCostObsidian[problem];
//			ores[problem][time[problem]] -= geodeBotCost[problem];
//			geodeBot[problem][time[problem]]++;
//			Solve(problem);
//		}
//		else if(clay[problem][time[problem]] >= obsidianCostClay[problem] && ores[problem][time[problem]] >= obsidianbotCost[problem])
//		{
//			time[problem]++;
//			TickResources(problem);
//			clay[problem][time[problem]] -= obsidianCostClay[problem];
//			ores[problem][time[problem]] -= obsidianbotCost[problem];
//			obsidianBot[problem][time[problem]]++;
//			Solve(problem);
//		}
//		else
//		{
//			//var bought = false;
//			if(i == 0)
//			{
//				//if(oreBot[problem][time[problem]] >= greatestOreCost[problem])
//				//{
//				//	continue;
//				//}
//				if(ores[problem][time[problem]] >= orebotCost[problem])
//				{
//					//bought = true;
//					time[problem]++;
//					TickResources(problem);
//					ores[problem][time[problem]] -= orebotCost[problem];
//					oreBot[problem][time[problem]]++;
//					Solve(problem);
//				}
//			}
//			else if(i == 1)
//			{
//				//if(clayBot[problem][time[problem]] >= obsidianCostClay[problem])
//				//{
//				//	continue;
//				//}
//				if(ores[problem][time[problem]] >= claybotCost[problem])
//				{
//					//bought = true;
//					time[problem]++;
//					TickResources(problem);
//					ores[problem][time[problem]] -= claybotCost[problem];
//					clayBot[problem][time[problem]]++;
//					Solve(problem);
//				}
//			}
//			else
//			{
//				time[problem]++;
//				TickResources(problem);
//				Solve(problem);
//			}
//		}
//	}

//	if(time[problem] > 0)
//	{
//		highestGeodes[problem] = Math.Max(highestGeodes[problem], geodes[problem][time[problem]]);
//		time[problem]--;
//	}
//	if(time[problem] < memoThreshold)
//	memo[problem].Add((time[problem], ores[problem][time[problem]], clay[problem][time[problem]],
//		obsidian[problem][time[problem]], geodes[problem][time[problem]], oreBot[problem][time[problem]],
//		clayBot[problem][time[problem]], obsidianBot[problem][time[problem]]));
//}
	
//void TickResources(ushort problem)
//{
//	oreBot[problem][time[problem]] = oreBot[problem][time[problem] - 1];
//	clayBot[problem][time[problem]] = clayBot[problem][time[problem] - 1];
//	obsidianBot[problem][time[problem]] = obsidianBot[problem][time[problem] - 1];
//	geodeBot[problem][time[problem]] = geodeBot[problem][time[problem] - 1];

//	ores[problem][time[problem]] = (ushort) (ores[problem][time[problem] - 1] + oreBot[problem][time[problem]]);
//	clay[problem][time[problem]] = (ushort) (clay[problem][time[problem] - 1] + clayBot[problem][time[problem]]);
//	obsidian[problem][time[problem]] = (ushort) (obsidian[problem][time[problem] - 1] + obsidianBot[problem][time[problem]]);
//	geodes[problem][time[problem]] = (ushort) (geodes[problem][time[problem] - 1] + geodeBot[problem][time[problem]]);
//}