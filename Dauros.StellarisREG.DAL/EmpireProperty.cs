using System;
using System.Collections.Generic;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public abstract class EmpireProperty
    {
        public EmpirePropertyType Type { get; }
        public String Name { get; set; }
        public HashSet<OrSet> Requires { get; set; } = new HashSet<OrSet>();
        public AndSet? Prohibits { get; set; }
        public String? DLC { get; }
        public int ID => Name.GetHashCode();

        public EmpireProperty(String name, EmpirePropertyType type, String? dlc = null)
        {
            Name = name;
            Type = type;
            DLC = dlc;
        }
    }
}