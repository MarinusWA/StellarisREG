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
                EPN.AT_Biological,
                new SpeciesArchetype(EPN.AT_Biological){ 
                    Prohibits = new AndSet(){EPN.T_Lithoid,EPN.T_MachineUnit }
                }
            },
            {
                EPN.AT_Machine,
                new SpeciesArchetype(EPN.AT_Machine, EPN.D_SyntheticDawn){
                    Prohibits = new AndSet(){EPN.T_Lithoid },
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } }
                }
            },
            {
                EPN.AT_Lithoid,
                new SpeciesArchetype(EPN.AT_Lithoid, EPN.D_Lithoids){
                }
            },
            {
                EPN.AT_Plantoid,
                new SpeciesArchetype(EPN.AT_Plantoid, EPN.D_Plantoids){
                }
            },
            {
                EPN.AT_Fungoid,
                new SpeciesArchetype(EPN.AT_Fungoid, EPN.D_Plantoids){
                }
            }
        };

        public SpeciesArchetype(string name, params String[] dlc) : base(name, EmpirePropertyType.SpeciesArchetype, dlc) { }
    }
}
