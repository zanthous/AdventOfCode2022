//using System.Diagnostics;
//using System.Numerics;
//using System.Reflection.Metadata.Ecma335;

//List<BigInteger>[] monkeys = new List<BigInteger>[8] 
//{
//	new List<BigInteger>(){84, 66, 62, 69, 88, 91, 91},
//	new List<BigInteger>(){98, 50, 76, 99},
//	new List<BigInteger>(){72, 56, 94},
//	new List<BigInteger>(){55, 88, 90, 77, 60, 67},
//	new List<BigInteger>(){69, 72, 63, 60, 72, 52, 63, 78},
//	new List<BigInteger>(){89, 73},
//	new List<BigInteger>(){78, 68, 98, 88, 66},
//	new List<BigInteger>(){70}
//};
////multAdd
//(bool, int)[] ops = new (bool, int)[8] {
//	(true,11), (true, -1), (false, 1), (false,2), (true,13), (false,5), (false,6), (false,7)
//};
//// 2 3 5 7 11 13 17 19

//int lcm = 9699690;
//int[] tests = new int[8] { 2,7,13,3,19,17,11,5};
//(int, int)[] trueFalse = new (int, int)[8] { (4,7), (3, 6), (4, 0), (6, 5), (1, 7), (2, 0), (2, 5), (1, 3) };

//int[] inspectedCount = new int[8];

//for(int turn = 0; turn < 10000; turn++) //20 rounds
//{
//	for(int monkey = 0; monkey < 8; monkey++) // 8 monkeys
//	{
//		for(int item = 0; item < monkeys[monkey].Count; item++)
//		{
//			inspectedCount[monkey]++;

//			var val = ops[monkey].Item2 == -1 ? monkeys[monkey][item] : ops[monkey].Item2;
//			monkeys[monkey][item] = ops[monkey].Item1 ? monkeys[monkey][item] * val : monkeys[monkey][item] + val;

//			monkeys[monkey][item] = monkeys[monkey][item] %= lcm;

//			var moveLoc = (monkeys[monkey][item] % tests[monkey] == 0);

//			monkeys[moveLoc ? trueFalse[monkey].Item1 : trueFalse[monkey].Item2].Add(monkeys[monkey][item]);
//			monkeys[monkey].RemoveAt(item);
//			item--;
//		}
//	}
//}

//int result = 0;
//var list = inspectedCount.ToList();
//list.Sort();


//Console.WriteLine(result);