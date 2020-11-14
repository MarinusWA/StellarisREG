using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dauros.StellarisREG.Web.ViewComponents
{
    public class SelectStateModel
    {
        #region Ethics
        public List<String> SelectedEthics { get; set; } = new List<string>();
        public List<String> ValidEthics { get; set; } = new List<string>();
        public List<String> ProhibitedEthics { get; set; } = new List<string>();

        #endregion

        #region Origin
        public String? SelectedOrigin { get; set; }
        public List<String> ValidOrigins { get; set; } = new List<string>();
        public List<String> ProhibitedOrigins { get; set; } = new List<string>();
        #endregion

        #region Authority
        public String? SelectedAuthority { get; set; }
        public List<String> ValidAuthorities { get; set; } = new List<string>();
        public List<String> ProhibitedAuthorities { get; set; } = new List<string>();
        #endregion

        #region Civics
        public List<String> SelectedCivics { get; set; } = new List<string>();
        public List<String> ValidCivics { get; set; } = new List<string>();
        public List<String> ProhibitedCivics { get; set; } = new List<string>();
        #endregion

        #region Archetype
        public String? SelectedArchetype { get; set; }
        public List<String> ValidArchetypes { get; set; } = new List<string>();
        public List<String> ProhibitedArchetypes { get; set; } = new List<string>();
        #endregion


    }
}
