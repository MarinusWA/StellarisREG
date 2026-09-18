using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dauros.StellarisREG.DAL;

public class Migration : EmpireProperty
{
	public static Dictionary<String, Migration> Collection => new Dictionary<string, Migration>()
		{
			{
				EPN.M_Settled,
				new Migration(EPN.M_Settled){ }
			},
			{
				EPN.M_Nomadic,
				new Migration(EPN.M_Nomadic){ GrantedTraits = new HashSet<string>() { EPN.T_Nomadic } }
			}
		};

	public Migration(String name, HashSet<OrSet>? dlc = null,
		HashSet<OrSet>? requirements = null, AndSet? prohibitions = null)
		: base(name, EmpirePropertyType.Migration, dlc, requirements, prohibitions) {
		DLC = new[] { EPN.D_Nomads }.ToOrSet();
	}
}
	
