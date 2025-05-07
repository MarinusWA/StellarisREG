using System;
using System.Collections.Generic;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public abstract class EmpirePropertySet : HashSet<String>
    {
        public abstract EmpirePropertySetType SetType { get; }
		public EmpirePropertySet() : base()
		{ }

		public EmpirePropertySet(IEnumerable<string> set) : base(set)
		{ }
	}

    public class AndSet : EmpirePropertySet
    {
        public override EmpirePropertySetType SetType  => EmpirePropertySetType.And; 

        public AndSet() :base()
        { }

        public AndSet(IEnumerable<string> set) : base(set)
		{ }
	}

    public class OrSet : EmpirePropertySet
    {
        public override EmpirePropertySetType SetType => EmpirePropertySetType.Or;
        public OrSet() : base()
		{ }
		public OrSet(IEnumerable<string> set) : base(set)
		{ }
	}





}
