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
                    Prohibits = new AndSet(){EPN.T_Lithoid }
                }
            },
            {
                EPN.AT_Lithoid,
                new SpeciesArchetype(EPN.AT_Lithoid, EPN.D_Lithoids){
                }
            }
        };

        public SpeciesArchetype(string name, params String[] dlc) : base(name, EmpirePropertyType.SpeciesArchetype, dlc) { }
    }
}
