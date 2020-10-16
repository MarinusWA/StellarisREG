using System;
using System.Collections.Generic;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public class RequirementRule
    {
        private readonly Func<SelectState, Boolean> _func;

        public RequirementRule(Func<SelectState, Boolean> func)
        {
            _func = func;
        }


        /// <summary>
        /// Tests if this rule conflicts with the provided state.
        /// </summary>
        /// <param name="state"></param>
        /// <returns>True if the rule does not conflict.</returns>
        public Boolean ConflictsWith(SelectState state)
        {
            return _func.Invoke(state);
        }
    }
}