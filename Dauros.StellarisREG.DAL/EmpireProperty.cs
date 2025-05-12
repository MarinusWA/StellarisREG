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
        public HashSet<OrSet> Requires { get; init; } = new HashSet<OrSet>();
        public AndSet Prohibits { get; init; } = new AndSet();
        public HashSet<OrSet> DLC { get; init; } = new HashSet<OrSet>();
		public int ID => Name.GetHashCode();

		/// <summary>
		/// The planettype this EmpireProperty forces the empire to start with.
		/// </summary>
		public string? PlanetType { get; init; }
		/// <summary>
		/// Traits that are granted by this EmpireProperty.
		/// </summary>
		public IEnumerable<string> GrantedTraits { get; init; } = Enumerable.Empty<string>();

		public EmpireProperty(String name, EmpirePropertyType type, IEnumerable<OrSet>? dlc = null,
            IEnumerable<OrSet>? requirements = null, IEnumerable<string>? prohibitions = null)
        {
            Requires.UnionWith(requirements ?? Enumerable.Empty<OrSet>());  
            Prohibits.UnionWith(prohibitions ?? Enumerable.Empty<string>());
			DLC.UnionWith(dlc ?? Enumerable.Empty<OrSet>());
			Name = name;
            Type = type;
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