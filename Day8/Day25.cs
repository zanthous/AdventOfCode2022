using System.Numerics;
using System.Text;

var text = File.ReadAllText("input.txt").Split("\r\n");
BigInteger total = 0;

for(int i = 0; i < text.Length; i++)
{
	total += ToMemeFormat(text[i]);
}

Console.WriteLine(total);

string result = "";
while(total > 0)
{
	BigInteger remainder = total % (BigInteger)5; // get the remainder
	result += remainder.ToString(); // append the remainder to the result string
	total = total / 5; // divide the decimal number by 5
}

// reverse the result string
char[] charArray = result.ToCharArray();
Array.Reverse(charArray);
result = new string(charArray);

StringBuilder final = new StringBuilder(result);
Console.WriteLine(result);

int nChanged = int.MaxValue;

while(nChanged > 0)
{
	nChanged = 0;
	int carry = 0;
	for(int i = final.Length -1; i > -1; i--)
	{
		//this probably works
		final[i] = (char) ((int) final[i] + carry);
		carry = 0;
		if(final[i] == '3')
		{
			final[i] = '=';
			carry++;
			nChanged++;
		}
		else if(final[i] == '4')
		{
			final[i] = '-';
			carry++;
			nChanged++;
		}
		else if(final[i] == '5')
		{
			final[i] = '0';
			carry++;
			nChanged++;
		}
	}
}
Console.WriteLine(final);

while(true)
{
	var s = Console.ReadLine();
	Console.WriteLine(ToMemeFormat(s));
}

BigInteger ToMemeFormat(string s)
{
	BigInteger current = 0;
	for(int j = 0; j < s.Length; j++)
	{
		switch(s[j])
		{
			case '2':
				current += ((BigInteger) Math.Pow(5, s.Length - 1 - j)) * 2;
				break;
			case '1':
				current += ((BigInteger) Math.Pow(5, s.Length - 1 - j)) * 1;
				break;
			case '0':
				break;
			case '-':
				current += ((BigInteger) Math.Pow(5, s.Length - 1 - j)) * -1;
				break;
			case '=':
				current += ((BigInteger) Math.Pow(5, s.Length - 1 - j)) * -2;
				break;
		}
	}
	return current;
}
