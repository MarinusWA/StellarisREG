using System;
using System.Collections.Generic;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public class SpeciesArchetype : EmpireProperty
    {
        public static Dictionary<String, SpeciesArchetype> Collection => new Dictionary<string, SpeciesArchetype>()
        {
            { 
                EPN.AT_Organic,
                new SpeciesArchetype(EPN.AT_Organic){ 
                    Prohibits = new AndSet(){ EPN.AT_Machine, EPN.AT_Lithoid }
                }
            },
            {
                EPN.AT_Machine,
                new SpeciesArchetype(EPN.AT_Machine, new[] { EPN.D_SyntheticDawn, EPN.D_MachineAge }.ToOrSet()){
					Prohibits = new AndSet(){EPN.AT_Lithoid, EPN.AT_Organic},
                }
            },
			{
                EPN.AT_Lithoid,
                new SpeciesArchetype(EPN.AT_Lithoid, new[] { EPN.D_Lithoids }.ToOrSet()){
					Prohibits = new AndSet(){EPN.AT_Machine, EPN.AT_Organic},
				}
            }
        };

		public SpeciesArchetype(String name, HashSet<OrSet>? dlc = null,
			HashSet<OrSet>? requirements = null, AndSet? prohibitions = null)
			: base(name, EmpirePropertyType.SpeciesArchetype, dlc, requirements, prohibitions) { }
	}
}
