using System;

public class Test
{
	public static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		for(int i = 0; i < n; i++){
			if(i == 0 || i == n-1)
				Console.WriteLine(new string('*',n));
			else
				Console.WriteLine("*"+new string(' ',n-2)+"*");
		}
		
	}
}
