using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RpgTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Knight knight = new Knight()
			{
				HP = 750,
				Armor=12,
				Weapon=55,
				Att=70,
				Helmet=5,
				Legs=5,
				Shield=48,
				Def=66
			};
			Monster Bebok = new Monster() { HP = 10000, Att = 150, Def = 140 };
			while (Console.ReadLine().ToString() == "kill")
			{			
				Bebok.Defense(knight.Attac());
				Thread.Sleep(5);
				knight.Defense(Bebok.Attac());		
			}
			Console.ReadKey();
		}
	}
}
