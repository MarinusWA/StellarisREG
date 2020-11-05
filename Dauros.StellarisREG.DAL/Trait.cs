using System;
using System.Collections.Generic;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public class Trait : EmpireProperty
    {

        public static Dictionary<String, Trait> Collection { get; } = new Dictionary<string, Trait>()
        {
            {
                EPN.T_Lithoid,
                new Trait(EPN.T_Lithoid, EPN.D_Lithoids){ }
            },
            {
                EPN.T_MachineUnit,
                new Trait(EPN.T_MachineUnit, EPN.D_SyntheticDawn)
                { 
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } }
                }
            },
            {
                EPN.T_Necrophage,
                new Trait(EPN.T_Necrophage, EPN.D_Necroids)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } }
                }
            }
        };

        public Trait(String name, params String[] dlc) : base(name, EmpirePropertyType.Trait, dlc) { }
    }
}
