using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTest
{
	public class Monster 
	{
		public int HP { get; set; }
		public double Def { get; set; }
		public double Att { get; set; }
		private double _defW = 0.15;
		private double _attW = 0.25;
		public Monster() { }

		private int ClaculateAttac()
		{
			var min = Att - (Att * _attW);
			var att = 0;
			if (!MissAttac())
			{
				att = new Random().Next(Convert.ToInt32(Math.Round(min)), Convert.ToInt32(Att) + 1);
			}		
			return att;
		}

		private double CalculateDefBonus()
		{
			var def = Def * _defW;
			return def;
		}

		public int Attac()
		{
			return ClaculateAttac();
		}

		public void Defense(int att)
		{
			if (att == 0)
			{
				Console.WriteLine("You miss!");
			}
			else
			{
				var lossHP = att - Convert.ToInt32(CalculateDefBonus());
				Console.WriteLine("You hit: " + lossHP.ToString());
				HP -= att;
				Console.WriteLine("Monster HP left: " + HP.ToString());
			}
		}
		private bool MissAttac()
		{
			var miss = new Random().NextDouble();
			Dictionary<bool, double> chance = new Dictionary<bool, double>();
			chance.Add(true, 0.09);
			chance.Add(false, 0.91);
			var cumulative = 0.0;
			bool ret = false;
			foreach (var item in chance)
			{
				cumulative += item.Value;
				if (miss < cumulative)
				{
					ret = item.Key;
					break;
				}
			}
			return ret;
		}

	}
}
