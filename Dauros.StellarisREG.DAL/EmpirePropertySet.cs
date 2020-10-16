using System;
using System.Collections.Generic;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public abstract class EmpirePropertySet : HashSet<String>
    {
        public abstract EmpirePropertySetType SetType { get; }
    }

    public class AndSet : EmpirePropertySet
    {
        public override EmpirePropertySetType SetType  => EmpirePropertySetType.And; 
    }

    public class OrSet : EmpirePropertySet
    {
        public override EmpirePropertySetType SetType => EmpirePropertySetType.Or;
    }





}
