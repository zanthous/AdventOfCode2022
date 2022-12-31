//string[] text = File.ReadAllLines("input.txt");
//(int, int)[] knots = new (int, int)[10];
//HashSet<(int, int)> set = new() { (0, 0) }; //add initial position

//for(int i = 0; i < text.Length; i++)
//{
//	var split = text[i].Split(' ');
//	for(int j = 0; j < int.Parse(split[1]); j++)
//	{
//		knots[0] = text[i][0] switch
//		{
//			'U' => (knots[0].Item1, knots[0].Item2 + 1),
//			'D' => (knots[0].Item1, knots[0].Item2 - 1),
//			'L' => (knots[0].Item1 - 1, knots[0].Item2),
//			'R' => (knots[0].Item1 + 1, knots[0].Item2),
//		};
//		for(int k = 1; k < knots.Length; k++)
//		{
//			knots[k] = MoveKnot(knots[k - 1], knots[k]);
//		}
//		set.Add(knots[^1]);
//	}
//}
//(int, int) MoveKnot((int, int) head, (int, int) tail)
//{
//	if(!(Math.Abs(head.Item1 - tail.Item1) < 2 && Math.Abs(head.Item2 - tail.Item2) < 2)) //if not touching
//		return (tail.Item1 + Math.Sign(head.Item1 - tail.Item1), 
//			tail.Item2 + Math.Sign(head.Item2 - tail.Item2)); //move toward the head knot on both axes

//	if(Math.Abs(head.Item1 - tail.Item1) > 1) return (tail.Item1 + Math.Sign(head.Item1 - tail.Item1), tail.Item2); //2 or more away, move toward one space
//	if(Math.Abs(head.Item2 - tail.Item2) > 1) return (tail.Item1, tail.Item2 + Math.Sign(head.Item2 - tail.Item2));
//	return tail;
//}
//Console.WriteLine(set.Count);