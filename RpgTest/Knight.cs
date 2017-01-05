using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgTest
{
	class Knight
	{
		public int HP { get; set; }
		public double Def { get; set; }
		public double Att { get; set; }
		public double Helmet { get; set; }
		public double Armor { get; set; }
		public double Legs { get; set; }
		public double Shield { get; set; }
		public double Weapon { get; set; }
		private double _defW = 0.15;
		private double _attW = 0.35;
		private double _weaponW = 0.45;

		public Knight()
		{ }

		private int ClaculateAttac()
		{
			var max = Att + Weapon;
			var min = max - (Att * _attW + Weapon * _weaponW);
			var att = 0;
			if (!MissAttac())
			{
				 att = new Random().Next(Convert.ToInt32(Math.Round(min)), Convert.ToInt32(max) + 1);
			}
		
			return att;
		}

		public double CalculateDefBonus()
		{
			var def = (Def + Helmet + Armor + Legs + Shield ) * _defW;
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
				Console.WriteLine("Monster miss!");
			}
			else
			{
				var lossHP = att - Convert.ToInt32(CalculateDefBonus());
				Console.WriteLine("Monster hit: " + lossHP.ToString());
				HP -= att;
				Console.WriteLine("Your HP: " + HP.ToString());
			}
		}

		private bool MissAttac()
		{
			var miss = new Random().NextDouble();
			Dictionary<bool, double> chance = new Dictionary<bool, double>();
			chance.Add(true, 0.09);
			chance.Add(false, 0.91);
			var cumulative = 0.0;
			bool ret= false;
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
