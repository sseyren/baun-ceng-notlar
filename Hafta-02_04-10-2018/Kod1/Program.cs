using System;

// Namespace olmadan da classlar ve metodlar çalıştırmak mümkün.

class Deneme
{
    public int x;
    public int y;
    public Deneme(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
class AnaSınıf
{
	public static void Main(string[] args)
    {
        Deneme d = new Deneme(5, 6);
        Console.WriteLine(d.x);
    }
}