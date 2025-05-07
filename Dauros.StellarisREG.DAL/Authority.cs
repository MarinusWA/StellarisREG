using System;
using System.Collections.Generic;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public sealed class Authority : EmpireProperty
    {
        public static Dictionary<String, Authority> Collection { get; } = new Dictionary<string, Authority>()
        {
            {
                EPN.A_Democratic,
                new Authority(EPN.A_Democratic, prohibitions: new AndSet(){ EPN.Authoritarian,EPN.AuthoritarianF, EPN.Gestalt})
            },
            {
                EPN.A_Oligarchic,
                new Authority(EPN.A_Oligarchic, prohibitions:new AndSet(){ EPN.EgalitarianF, EPN.AuthoritarianF, EPN.Gestalt })
            },
            {
                EPN.A_Dictatorial,
                new Authority(EPN.A_Dictatorial, prohibitions:new AndSet(){ EPN.Egalitarian,EPN.EgalitarianF, EPN.Gestalt })
            },
            {
                EPN.A_Imperial,
                new Authority(EPN.A_Imperial, prohibitions:new AndSet(){ EPN.Egalitarian,EPN.EgalitarianF,EPN.Gestalt })
            },
            {
                EPN.A_HiveMind,
                new Authority(EPN.A_HiveMind, 
                    new [] { EPN.D_Utopia, EPN.D_Biogenesis }.ToOrSet(),
					new [] { EPN.Gestalt }.ToOrSet(),
                    new AndSet(){ EPN.Egalitarian,EPN.EgalitarianF, EPN.Authoritarian,EPN.AuthoritarianF,
                        EPN.Materialist,EPN.MaterialistF, EPN.Spiritualist, EPN.SpiritualistF,
                        EPN.Xenophile, EPN.XenophileF, EPN.Xenophobe,EPN.XenophobeF,
                        EPN.Militarist, EPN.MaterialistF, EPN.Pacifist, EPN.PacifistF, EPN.AT_Machine
                  }
                )
			},
            {
                EPN.A_MachineIntelligence,
                new Authority(EPN.A_MachineIntelligence, 
                    new[] { EPN.D_SyntheticDawn, EPN.D_MachineAge }.ToOrSet(),
                    new[] { EPN.Gestalt, EPN.AT_Machine }.ToOrSet(),
					new AndSet(){ EPN.Egalitarian,EPN.EgalitarianF, EPN.Authoritarian,EPN.AuthoritarianF,
						EPN.Materialist,EPN.MaterialistF, EPN.Spiritualist, EPN.SpiritualistF,
						EPN.Xenophile, EPN.XenophileF, EPN.Xenophobe,EPN.XenophobeF,
						EPN.Militarist, EPN.MaterialistF, EPN.Pacifist, EPN.PacifistF,
						EPN.AT_Animal, EPN.AT_Lithoid, EPN.AT_Plantoid
					}
				)
            },
            {
                EPN.A_Corporate,
                new Authority(EPN.A_Corporate, 
                    new [] { EPN.D_Megacorp }.ToOrSet(),
                    prohibitions:new AndSet(){ EPN.AuthoritarianF,EPN.EgalitarianF,EPN.Gestalt }
                )
            }
        };

        public Authority(String name, HashSet<OrSet>? dlc = null, HashSet<OrSet>? requirements = null, AndSet? prohibitions = null) 
            : base(name, EmpirePropertyType.Authority, dlc, requirements, prohibitions) { }
    }
}