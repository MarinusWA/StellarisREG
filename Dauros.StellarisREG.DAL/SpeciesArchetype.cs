using System;
using System.Collections.Generic;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public class SpeciesArchetype : EmpireProperty
    {
        public static Dictionary<String, SpeciesArchetype> Collection => new Dictionary<string, SpeciesArchetype>()
        {
           
        };

        public SpeciesArchetype(string name, string? dlc = null) : base(name, EmpirePropertyType.SpeciesArchetype, dlc) { }
    }
}
