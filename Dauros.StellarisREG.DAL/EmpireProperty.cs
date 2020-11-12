using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public abstract class EmpireProperty
    {
        public EmpirePropertyType Type { get; }
        public String Name { get; set; }
        public HashSet<OrSet> Requires { get; set; } = new HashSet<OrSet>();
        public AndSet Prohibits { get; set; } = new AndSet();
        public HashSet<String> DLC { get; } = new HashSet<string>();
        public int ID => Name.GetHashCode();

        public EmpireProperty(String name, EmpirePropertyType type, params String[] dlc)
        {
            Name = name;
            Type = type;
            DLC = dlc.ToHashSet();
        }

        public override bool Equals(object obj)
        {
            if (obj is EmpireProperty)
            {
                return (obj as EmpireProperty)!.ID == this.ID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}