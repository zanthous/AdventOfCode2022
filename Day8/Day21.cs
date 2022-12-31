//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Numerics;
//using System.Text;
//Stopwatch stopwatch = new Stopwatch();
//var text = File.ReadAllLines("input.txt");
//Dictionary<string, long> vals = new();
//Dictionary<string, string> requiredFor = new();

////Dictionary<string, long> requirementsMet = new();
////Dictionary<string, List<string>> requirements = new();
////Dictionary<string, char> operators = new();

//Dictionary<string, Problem> problems = new ();

//for(int i = 0; i < text.Length; i++)
//{
//	var s = text[i].Split(' ');
//	if(s.Length ==2 )
//	{
//		vals.Add(s[0], long.Parse(s[1]));
//	}
//	else
//	{
//		requiredFor.Add(s[1], s[0]);
//		requiredFor.Add(s[3], s[0]);

//		problems.Add(s[0], new Problem());
//		Op op = Op.None;
//		if(s[2][0] == '*') op = Op.Multiply;
//		else if(s[2][0] == '/') op = Op.Divide;
//		else if(s[2][0] == '+') op = Op.Add;
//		else if(s[2][0] == '-') op = Op.Subtract;
//		else if(s[2][0] == '=') op = Op.Equals;
//		problems[s[0]].op = op;
//		problems[s[0]].key = s[0];
//		problems[s[0]].requirements = new List<string>() { s[1], s[3] };
//	}
//}
//List<string> keys = new List<string>(vals.Keys);
//Stack<int> sides = new();
//Problem ss = null;

//Stack<object> stuff = new();

//foreach(var k in keys)
//{
//	var r = requiredFor[k];
//	problems[r].requirementsMet++;
//	if(problems[r].requirementsMet == 2)
//	{
//		Solve(problems[r]);
//	}
//}

//void Solve(Problem p)
//{
//	if(ss == null)
//	{ 
//		if(p.requirements[0] == "humn" )
//		{
//			ss = p;
//			stuff.Push(ss.op);
//			stuff.Push((long)vals[p.requirements[1]]);
//			sides.Push(0);
//		}
//		else if(p.requirements[1] == "humn")
//		{
//			ss = p;
//			stuff.Push(ss.op);
//			stuff.Push((long) vals[p.requirements[0]]);
//			sides.Push(1);
//		}
//	}
//	else
//	{
//		if(p.requirements[0] == ss.key)
//		{
//			ss = p;
//			stuff.Push(ss.op);
//			stuff.Push((long) vals[p.requirements[1]]);
//			sides.Push(0);
//		}
//		else if(p.requirements[1] == ss.key)
//		{
//			ss = p;
//			stuff.Push(ss.op);
//			stuff.Push((long) vals[p.requirements[0]]);
//			sides.Push(1);
//		}
//	}

//	switch(p.op)
//	{
//		case Op.Add:
//			p.val = vals[p.requirements[0]] + vals[p.requirements[1]];
//			break;
//		case Op.Multiply:
//			p.val = vals[p.requirements[0]] * vals[p.requirements[1]];
//			break;
//		case Op.Subtract:
//			p.val = vals[p.requirements[0]] - vals[p.requirements[1]];
//			break;
//		case Op.Divide:
//			p.val = vals[p.requirements[0]] / vals[p.requirements[1]];
//			break;
//		case Op.Equals:
//			Console.WriteLine(vals[p.requirements[0]] == vals[p.requirements[1]]);
//			Console.WriteLine($"{vals[p.requirements[0]]} and {vals[p.requirements[1]]}");
//			break;
//		default:
//			break;
//	}
//	vals.Add(p.key, p.val);
//	if(p.key!= "root")
//	{ 
//		problems[requiredFor[p.key]].requirementsMet++;
	
//		if(problems[requiredFor[p.key]].requirementsMet == 2)
//		{
//			Solve(problems[requiredFor[p.key]]);
//		}
//	}
//	else
//	{
//		//Console.WriteLine($"root is {p.requirements[0]} {p.op} {p.requirements[1]} = {p.val}");
//	}
//}

//Console.WriteLine(problems["root"].val);

//stopwatch.Stop();
//long goal = (long) stuff.Pop();
//stuff.Pop();
//sides.Pop();
//var arr = stuff.ToList();
//var sidesArr = sides.ToList();
//sidesArr.Reverse();
//arr.Reverse();
//Console.WriteLine();
//Console.Write($"{goal} = ");
//StringBuilder result = new StringBuilder("");
//result.Append("x");

//for(int i = 0; i < arr.Count; i++)
//{
//	if(i % 2 == 1)
//	{
//		//number
//		if(sidesArr[i/2] == 1)
//		{ 
//			result = result.Insert(0,"(" +((long) arr[i]).ToString());
//			result.Append(")");
//		}
//		else
//		{
//			result.Append(((long) arr[i]).ToString());
//			result.Append(")");
//			result = result.Insert(0, "(");
//		}
//	}
//	else
//	{
//		string sign = "";
//		switch((Op) arr[i])
//		{
//			case Op.Divide:
//				sign ="/";
//				break;
//			case Op.Multiply:
//				sign = "*";
//				break;
//			case Op.Subtract:
//				sign = "-";
//				break;
//			case Op.Add:
//				sign = "+";
//				break;
//		}

//		if(sidesArr[i / 2] == 1)
//		{
//			result = result.Insert(0,sign);
//		}
//		else
//		{
//			result.Append(sign);
//		}
//	}
//}
//Console.WriteLine(result);


////this was super wrong, todo use recursion and order the operations correctly
////instead wolframalpha'd string output

////while(stuff.Count>0)
////{
////	var num = (long) stuff.Pop();
////	var op = (Op) stuff.Pop();
////	var _side = side.Pop();
////	switch(op)
////	{
////		case Op.Add:
////			if(_side == 0)
////			{
////				goal -= num;
////			}
////			else
////			{
////				goal = num - goal;
////			}
////			break;
////		case Op.Multiply:
////			if(_side == 0)
////			{
////				goal = goal/ num;
////			}
////			else
////			{
////				goal = num / goal;
////			}
////			break;
////		case Op.Divide:
////			if(_side == 0)
////			{
////				goal *= num;
////			}
////			else
////			{
////				goal = num * goal;
////			}
////			break;
////		case Op.Subtract:
////			if(_side == 0)
////			{
////				goal += num;
////			}
////			else
////			{
////				goal = num + goal;
////			}
////			break;
////		default:
////			Console.WriteLine("error");
////			break;
////	}
////	int stoppp = 0;
////}
////Console.WriteLine($"\nresult: {goal}");
////int stop = 0;

////while(ss.key != "root")
////{
////	ss = problems[requiredFor[ss.key]];
////	Console.WriteLine(ss.key);
////}
////Console.WriteLine($"{problems["nrrs"].val} {problems["nrrs"].op}");


//public enum Op
//{
//	None,
//	Add,
//	Subtract,
//	Multiply,
//	Divide,
//	Equals
//}

//class Problem
//{
//	public List<string> requirements;
//	public string key;
//	public long requirementsMet = 0;
//	public Op op = 0;
//	public long val;
//}