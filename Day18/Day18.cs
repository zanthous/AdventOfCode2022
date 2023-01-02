var text = File.ReadAllLines("input.txt");
int size = 24;
int[,,] level = new int[size, size, size];

for(int i = 0; i < text.Length; i++)
{
	var s = text[i].Split(',');
	level[int.Parse(s[0]) + 2, int.Parse(s[1]) + 2, int.Parse(s[2]) + 2] = (int) Block.Lava;
}
int total = 0;

//flood fill the outer area from val 2 to 1
Flood(0, 0, 0);
void Flood(int x, int y, int z)
{
	if(x < 0 || y < 0 || z < 0 ||
		x > size - 1 || y > size - 1 || z > size - 1 ||
		level[x, y, z] == (int) Block.Lava ||
		level[x, y, z] == (int) Block.Air)
	{
		return;
	}
	level[x, y, z] = (int) Block.Air;

	Flood(x - 1, y, z);
	Flood(x, y + 1, z);
	Flood(x, y - 1, z);
	Flood(x, y, z - 1);
	Flood(x, y, z + 1);
	Flood(x + 1, y, z);

	return;
}


for(int z = 0; z < level.GetLength(2); z++)
{
	for(int y = 0; y < level.GetLength(1); y++)
	{
		for(int x = 0; x < level.GetLength(0); x++)
		{
			if(level[x, y, z] == (int) Block.Lava)
				total += Check6(x, y, z);
		}
	}
}
Console.WriteLine(total);

int Check6(int x_in, int y_in, int z_in)
{
	int total = 0;
	int[] dx = new int[] { -1, 0, 0, 0, 0, 1 };
	int[] dy = new int[] { 0, 1, -1, 0, 0, 0 };
	int[] dz = new int[] { 0, 0, 0, -1, 1, 0 };

	for(int i = 0; i < 6; i++)
	{
		var x = x_in + dx[i];
		var y = y_in + dy[i];
		var z = z_in + dz[i];

		if(x < 2 || y < 2 || z < 2)
		{
			total++;
		}
		else
		{
			total += level[x, y, z] == (int) Block.Air ? 1 : 0;
		}
	}
	return total;
}

public enum Block
{
	Bubble,
	Air,
	Lava
}
