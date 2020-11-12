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
            String? selectedAuthority, HashSet<String> selectedCivics, string pick = "")
        {
            var ss = new SelectState();
            ss.CivicNames = selectedCivics ?? new HashSet<string>();
            ss.EthicNames = selectedEthics ?? new HashSet<string>();
            ss.AuthorityName = selectedAuthority;
            ss.OriginName = selectedOrigin;
            
            //If state is invalid, create a state with just the pick selected
            //If the pick is not an empireproperty assume its a dlc string and return an empty selectstate
            if (!ss.ValidateState())
            {
                ss = new SelectState();
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

            ssm.ProhibitedAuthorities = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Authority).ToList();
            ssm.ProhibitedCivics = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Civic).ToList();
            ssm.ProhibitedEthics = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Ethic).ToList();
            ssm.ProhibitedOrigins = prohibited.Where(s => SelectState.GetEmpirePropertyType(s) == EmpirePropertyType.Origin).ToList();

            var allAllowedAuthorities = ss.AllowedByDLCEmpireProperties.Where(ep=>ep.Type == EmpirePropertyType.Authority).Select(ep => ep.Name);
            var allAllowedCivics = ss.AllowedByDLCEmpireProperties.Where(ep => ep.Type == EmpirePropertyType.Civic).Select(ep => ep.Name);
            var allAllowedEthics = ss.AllowedByDLCEmpireProperties.Where(ep => ep.Type == EmpirePropertyType.Ethic).Select(ep => ep.Name);
            var allAllowedOrigins = ss.AllowedByDLCEmpireProperties.Where(ep => ep.Type == EmpirePropertyType.Origin).Select(ep => ep.Name);

            ssm.ValidAuthorities = allAllowedAuthorities.Except(ssm.ProhibitedAuthorities).Except(new String[] { ssm.SelectedAuthority }).ToList();
            ssm.ValidCivics = allAllowedCivics.Except(ssm.ProhibitedCivics).Except(ssm.SelectedCivics).ToList();
            ssm.ValidEthics = allAllowedEthics.Except(ssm.ProhibitedEthics).Except(ssm.SelectedEthics).ToList();
            ssm.ValidOrigins = allAllowedOrigins.Except(ssm.ProhibitedOrigins).Except(new String[] { ssm.SelectedOrigin }).ToList();

            return View(ssm);
        }
    }
}
