using Dauros.StellarisREG.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace Dauros.StellarisREG.Web.ViewComponents
{
    [ViewComponent]
    public class PreSelect : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(HashSet<String> selectedDLC, string? selectedOrigin, HashSet<String> selectedEthics,
            String? selectedAuthority, String? selectedPhenotype, HashSet<String> selectedCivics, string? selectedShipset, string pick = "")
        {
			var ss = new SelectState();
			ss.SelectedDLC = selectedDLC ?? SelectState.AllDLC.ToHashSet();
			ss.AddEmpireProperty(selectedCivics ?? new HashSet<string>());
			ss.AddEmpireProperty(selectedEthics ?? new HashSet<string>());
			ss.AddEmpireProperty(selectedAuthority);
			ss.AddEmpireProperty(selectedOrigin);
			//ss.AddEmpireProperty(selectedShipSet);
			ss.AddEmpireProperty(selectedPhenotype);

			//If state is invalid, create a state with just the pick selected
			//If the pick is not an empireproperty assume its a dlc string and return an empty selectstate
			if (!ss.ValidateState())
            {
                ss = new SelectState();
                ss.SelectedDLC = selectedDLC ?? SelectState.AllDLC.ToHashSet();
				ss.AddEmpireProperty(pick);
            }
            else if (!SelectState.AllEmpireProperties.ContainsKey(pick))
            {
                ss = new SelectState();
            }
            
            ss.SelectedDLC = selectedDLC ?? SelectState.AllDLC.ToHashSet();

			
            

            var prohibited = ss.GetProhibited();
            var ssm = new SelectStateModel();

            ssm.SelectedAuthority = ss.AuthorityName;
            ssm.SelectedCivics = ss.CivicNames.ToList();
            ssm.SelectedEthics = ss.EthicNames.ToList();
            ssm.SelectedOrigin = ss.OriginName;
            //ssm.SelectedArchetype = ss.ArchetypeName;
            ssm.SelectedShipset = ss.ShipsetName;
			ssm.SelectedPhenotype = ss.PhenotypeName;

			ssm.ProhibitedAuthorities = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Authority).Except(SelectState.GrantedEmpireProperties).ToList();
            ssm.ProhibitedCivics = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Civic).Except(SelectState.GrantedEmpireProperties).ToList();
            ssm.ProhibitedEthics = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Ethic).Except(SelectState.GrantedEmpireProperties).ToList();
            ssm.ProhibitedOrigins = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Origin).Except(SelectState.GrantedEmpireProperties).ToList();
            //ssm.ProhibitedArchetypes = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.SpeciesArchetype).Except(SelectState.GrantedEmpireProperties).ToList();
            ssm.ProhibitedShipsets = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Shipset).Except(SelectState.GrantedEmpireProperties).ToList();
			ssm.ProhibitedPhenotypes = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.SpeciesPhenotype).Except(SelectState.GrantedEmpireProperties).ToList();

			ssm.ValidAuthorities = ss.GetValidAuthorities().Except(SelectState.GrantedEmpireProperties).ToList();
            ssm.ValidCivics = ss.GetValidCivics().Except(SelectState.GrantedEmpireProperties).ToList();
            ssm.ValidEthics = ss.GetValidEthics().Except(SelectState.GrantedEmpireProperties).ToList();
            ssm.ValidOrigins = ss.GetValidOrigins().Except(SelectState.GrantedEmpireProperties).ToList();
            //ssm.ValidArchetypes = ss.GetValidArchetypes().Except(SelectState.GrantedEmpireProperties).ToList();
            ssm.ValidShipsets = ss.GetValidShipsets().Except(SelectState.GrantedEmpireProperties).ToList();
            ssm.ValidPhenotypes = ss.GetValidPhenotypes().Except(SelectState.GrantedEmpireProperties).ToList();

			return View(ssm);
        }
    }
}
