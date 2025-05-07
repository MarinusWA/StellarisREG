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
            String? selectedAuthority, String? selectedArchetype, HashSet<String> selectedCivics, string? selectedShipset, string pick = "")
        {
            var ss = new SelectState();
            ss.CivicNames = selectedCivics ?? new HashSet<string>();
            ss.EthicNames = selectedEthics ?? new HashSet<string>();
            ss.AuthorityName = selectedAuthority;
            ss.OriginName = selectedOrigin;
            ss.ArchetypeName = selectedArchetype;
            ss.ShipsetName = selectedShipset;
            ss.SelectedDLC = selectedDLC ?? SelectState.AllDLC.ToHashSet();

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
            ssm.SelectedArchetype = ss.ArchetypeName;
            ssm.SelectedShipset = ss.ShipsetName;

			ssm.ProhibitedAuthorities = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Authority).ToList();
            ssm.ProhibitedCivics = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Civic).ToList();
            ssm.ProhibitedEthics = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Ethic).ToList();
            ssm.ProhibitedOrigins = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Origin).ToList();
            ssm.ProhibitedArchetypes = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.SpeciesArchetype).ToList();
            ssm.ProhibitedShipsets = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Shipset).ToList();

			ssm.ValidAuthorities = ss.GetValidAuthorities().ToList();
            ssm.ValidCivics = ss.GetValidCivics().ToList();
            ssm.ValidEthics = ss.GetValidEthics().ToList();
            ssm.ValidOrigins = ss.GetValidOrigins().ToList();
            ssm.ValidArchetypes = ss.GetValidArchetypes().ToList();
            ssm.ValidShipsets = ss.GetValidShipsets().ToList();

			return View(ssm);
        }
    }
}
