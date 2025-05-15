using Dauros.StellarisREG.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dauros.StellarisREG.Web.ViewComponents
{
    [ViewComponent]
    public class PreSelect : ViewComponent
    {
		private readonly IMemoryCache _memoryCache;

		public PreSelect(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}


		public async Task<IViewComponentResult> InvokeAsync(HashSet<String>? selectedDLC, string? selectedOrigin, HashSet<String> selectedEthics,
            String? selectedAuthority, String? selectedPhenotype, HashSet<String> selectedCivics,
            HashSet<String> selectedTraits, string? selectedShipset, string pick = "")
        {
            var cookieName = "selectedDLC";

            var ss = new SelectState(_memoryCache)
            {
                SelectedDLC = GetSelectedDLC(selectedDLC, cookieName)
            };

			ss.AddEmpireProperty(selectedCivics ?? new HashSet<string>());
			ss.AddEmpireProperty(selectedEthics ?? new HashSet<string>());
			ss.AddEmpireProperty(selectedAuthority);
			ss.AddEmpireProperty(selectedOrigin);
			//ss.AddEmpireProperty(selectedShipSet);
			ss.AddEmpireProperty(selectedPhenotype);
			ss.AddEmpireProperty(selectedTraits ?? new HashSet<string>());

			//Set the selected DLC in the cookie
			CookieHelper.SetJsonCookie(HttpContext.Response, cookieName, ss.SelectedDLC);

			//If state is invalid, create a state with just the pick selected
			if (!ss.ValidateState())
            {
                ss = new SelectState(_memoryCache) { SelectedDLC = GetSelectedDLC(selectedDLC, cookieName) };
				ss.AddEmpireProperty(pick);
			}
			//If the pick is not an empireproperty assume its a dlc string and return an empty selectstate
			else if (pick!= String.Empty && !SelectState.AllEmpireProperties.ContainsKey(pick))
            {
				ss = new SelectState(_memoryCache) { SelectedDLC = GetSelectedDLC(selectedDLC, cookieName) };
			}

			var prohibited = ss.GetProhibited();
            var ssm = new SelectStateModel();

            ssm.SelectedAuthority = ss.AuthorityName;
            ssm.SelectedCivics = ss.CivicNames.ToList();
            ssm.SelectedEthics = ss.EthicNames.ToList();
            ssm.SelectedOrigin = ss.OriginName;
            //ssm.SelectedArchetype = ss.ArchetypeName;
            ssm.SelectedShipset = ss.ShipsetName;
			ssm.SelectedPhenotype = ss.PhenotypeName;
            ssm.SelectedTraits = ss.TraitNames.Except(SelectState.GrantedTraits).ToList();

			ssm.ProhibitedAuthorities = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Authority).ToList();
            ssm.ProhibitedCivics = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Civic).ToList();
            ssm.ProhibitedEthics = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Ethic).ToList();
            ssm.ProhibitedOrigins = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Origin).ToList();
            //ssm.ProhibitedArchetypes = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.SpeciesArchetype).Except(SelectState.GrantedEmpireProperties).ToList();
            ssm.ProhibitedShipsets = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Shipset).ToList();
			ssm.ProhibitedPhenotypes = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.SpeciesPhenotype).ToList();
            ssm.ProhibitedTraits = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Trait).Except(SelectState.GrantedTraits).ToList();

			ssm.ValidAuthorities = ss.GetValidAuthorities().ToList();
            ssm.ValidCivics = ss.GetValidCivics().ToList();
            ssm.ValidEthics = ss.GetValidEthics().ToList();
            ssm.ValidOrigins = ss.GetValidOrigins().ToList();
            //ssm.ValidArchetypes = ss.GetValidArchetypes().Except(SelectState.GrantedEmpireProperties).ToList();
            ssm.ValidShipsets = ss.GetValidShipsets().ToList();
            ssm.ValidPhenotypes = ss.GetValidPhenotypes().ToList();
            ssm.ValidTraits = ss.GetValidTraits().ToList();


            //If there is only one valid option, select it and remove it from valids (to prevent doubling)
            if (ssm.ValidAuthorities.Count() == 1) { 
                ssm.SelectedAuthority = ssm.ValidAuthorities.First();
                ssm.ValidAuthorities.Remove(ssm.SelectedAuthority);
            };
            if (ssm.ValidPhenotypes.Count() == 1)
            {
				ssm.SelectedPhenotype = ssm.ValidPhenotypes.First();
				ssm.ValidPhenotypes.Remove(ssm.SelectedPhenotype);
			}
			if (ssm.ValidOrigins.Count() == 1)
            {
				ssm.SelectedOrigin = ssm.ValidOrigins.First();
				ssm.ValidOrigins.Remove(ssm.SelectedOrigin);
			}
			

			return View(ssm);
        }

        public HashSet<String> GetSelectedDLC(HashSet<String>? incomingDLC, string cookieName)
        {
			return incomingDLC
				?? CookieHelper.GetJsonCookie<HashSet<String>?>(HttpContext.Request, cookieName)
				?? SelectState.AllDLC.ToHashSet();
		}
	}
}
