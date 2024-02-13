using System;
using System.Collections.Generic;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public class Authority : EmpireProperty
    {
        public static Dictionary<String, Authority> Collection { get; } = new Dictionary<string, Authority>()
        {
            {
                EPN.A_Democratic,
                new Authority(EPN.A_Democratic)
                {
                    Prohibits = new AndSet(){ EPN.Authoritarian,EPN.AuthoritarianF, EPN.Gestalt }
                }
            },
            {
                EPN.A_Oligarchic,
                new Authority(EPN.A_Oligarchic)
                {
                    Prohibits = new AndSet(){ EPN.EgalitarianF, EPN.AuthoritarianF, EPN.Gestalt }
                }
            },
            {
                EPN.A_Dictatorial,
                new Authority(EPN.A_Dictatorial)
                {
                    Prohibits = new AndSet(){ EPN.Egalitarian,EPN.EgalitarianF,EPN.Gestalt }
                }
            },
            {
                EPN.A_Imperial,
                new Authority(EPN.A_Imperial)
                {
                    Prohibits = new AndSet(){ EPN.Egalitarian,EPN.EgalitarianF,EPN.Gestalt }
                }
            },
            {
                EPN.A_HiveMind,
                new Authority(EPN.A_HiveMind, EPN.D_Utopia)
                {
                    Prohibits = new AndSet(){ EPN.Egalitarian,EPN.EgalitarianF, EPN.Authoritarian,EPN.AuthoritarianF, 
                        EPN.Materialist,EPN.MaterialistF, EPN.Spiritualist, EPN.SpiritualistF,
                        EPN.Xenophile, EPN.XenophileF, EPN.Xenophobe,EPN.XenophobeF,
                        EPN.Militarist, EPN.MaterialistF, EPN.Pacifist, EPN.PacifistF
                    },
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Gestalt } }
                }
            },
            {
                EPN.A_MachineIntelligence,
                new Authority(EPN.A_MachineIntelligence, EPN.D_SyntheticDawn)
                {
                    Prohibits = new AndSet(){ EPN.Egalitarian,EPN.EgalitarianF, EPN.Authoritarian,EPN.AuthoritarianF,
                        EPN.Materialist,EPN.MaterialistF, EPN.Spiritualist, EPN.SpiritualistF,
                        EPN.Xenophile, EPN.XenophileF, EPN.Xenophobe,EPN.XenophobeF,
                        EPN.Militarist, EPN.MaterialistF, EPN.Pacifist, EPN.PacifistF,
                        EPN.AT_Animal, EPN.AT_Lithoid, EPN.AT_Plantoid
                    },
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Gestalt } }
                }
            },
            {
                EPN.A_Corporate,
                new Authority(EPN.A_Corporate, EPN.D_Megacorp)
                {
                    Prohibits = new AndSet(){ EPN.AuthoritarianF,EPN.EgalitarianF,EPN.Gestalt }
                }
            }
        };

        public Authority(String name, bool inclusiveDLC, params String[] dlc) : base(name, EmpirePropertyType.Authority, inclusiveDLC, dlc) { }
        public Authority(String name, params String[] dlc) : base(name, EmpirePropertyType.Authority, false, dlc) { }
    }
}