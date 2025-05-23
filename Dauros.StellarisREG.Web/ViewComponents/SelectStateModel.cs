﻿using System;
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

		#region Shipsets
		public String? SelectedShipset { get; set; }
		public List<String> ValidShipsets { get; set; } = new List<string>();
		public List<String> ProhibitedShipsets { get; set; } = new List<string>();
		#endregion

		#region Phenotype
		public String? SelectedPhenotype { get; set; }
		public List<String> ValidPhenotypes { get; set; } = new List<string>();
		public List<String> ProhibitedPhenotypes { get; set; } = new List<string>();
		#endregion

		#region Trait
		public List<String> SelectedTraits { get; set; } = new List<string>();
		public List<String> ValidTraits { get; set; } = new List<string>();
		public List<String> ProhibitedTraits { get; set; } = new List<string>();
		#endregion

	}
}
