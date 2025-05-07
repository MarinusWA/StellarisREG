using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dauros.StellarisREG.DAL
{
	public class ShipSet : EmpireProperty
	{
		public static Dictionary<String, ShipSet> Collection => new Dictionary<string, ShipSet>()
		{
			{
				EPN.S_Mechanical,
				new ShipSet(EPN.S_Mechanical){ }
			},
			{
				EPN.S_Biological,
				new ShipSet(EPN.S_Biological, EPN.D_Biogenesis){ }
			},

		};

		public ShipSet(string name, bool inclusiveDLC, params String[] dlc) : base(name, EmpirePropertyType.Shipset, inclusiveDLC, dlc) { }
		public ShipSet(string name, params String[] dlc) : base(name, EmpirePropertyType.Shipset, false, dlc) { }
	}
}
