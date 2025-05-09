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
				new ShipSet(EPN.S_Biological, new[]{ EPN.D_Biogenesis }.ToOrSet()){ }
			},

		};

		public ShipSet(String name, HashSet<OrSet>? dlc = null,
			HashSet<OrSet>? requirements = null, AndSet? prohibitions = null)
			: base(name, EmpirePropertyType.Shipset, dlc, requirements, prohibitions) { }
	}
}
