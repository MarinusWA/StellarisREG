using Dauros.StellarisREG.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dauros.StellarisREG.Web.ViewComponents
{
    [ViewComponent]
    public class EmpireList : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(HashSet<String> selectedDLC, string? selectedOrigin, HashSet<String> selectedEthics,
            String? selectedAuthority, HashSet<String> selectedCivics)
        {
            var result = new List<EmpireDataModel>();
            var states = new List<SelectState>();

            var r = new Random();

            for (int i = 0; i < 10; i++)
            {
                var ss = new SelectState();
                ss.CivicNames = selectedCivics != null ? selectedCivics.ToHashSet() : new HashSet<string>();
                ss.EthicNames = selectedEthics != null ? selectedEthics.ToHashSet() : new HashSet<string>();
                ss.AuthorityName = selectedAuthority;
                ss.OriginName = selectedOrigin;
                ss.SelectedDLC = selectedDLC != null ? selectedDLC.ToHashSet() : SelectState.AllDLC.ToHashSet();
                states.Add(ss);
            }

            foreach (var ss in states)
            {
                var firstProp = r.Next(2);
                if (firstProp == 0)
                {
                    AddRandomCivics(ss);
                    AddRandomOrigin(ss);
                }
                else
                {
                    AddRandomOrigin(ss);
                    AddRandomCivics(ss);
                }
                AddRandomEthics(ss);
                AddRandomAuthority(ss);

                var empireData = new EmpireDataModel()
                {
                    Authority = ss.AuthorityName!,
                    Origin = ss.OriginName!,
                    Civics = ss.CivicNames,
                    Ethics = ss.EthicNames,
                };

                result.Add(empireData);
            }

            return View(result);
        }



        private void AddRandomOrigin(SelectState ss)
        {
            if (ss.OriginName == null)
            {
                var validOrigins = ss.GetValidOrigins().ToArray();
                var r = new Random();
                ss.OriginName = validOrigins[r.Next(validOrigins.Count())];
            }
        }

        private void AddRandomAuthority(SelectState ss)
        {
            if (ss.AuthorityName == null)
            {
                var validAuths = ss.GetValidAuthorities().ToArray();
                var r = new Random();
                ss.AuthorityName = validAuths[r.Next(validAuths.Count())];
            }
        }

        private void AddRandomCivics(SelectState ss)
        {
            var validCivics = ss.GetValidCivics().ToArray();
            var r = new Random();
            while (validCivics.Any())
            {
                var picked = validCivics[r.Next(validCivics.Count())];
                ss.CivicNames.Add(picked);
                validCivics = ss.GetValidCivics().ToArray();
            }
        }

        private void AddRandomEthics(SelectState ss)
        {
            var validEthics = ss.GetValidEthics().ToArray();
            var r = new Random();
            while (validEthics.Any())
            {
                var picked = validEthics[r.Next(validEthics.Count())];
                ss.EthicNames.Add(picked);
                validEthics = ss.GetValidEthics().ToArray();
            }
        }



    }

    public class EmpireDataModel
    {
        public HashSet<String> Ethics { get; internal set; } = new HashSet<String>();
        public HashSet<String> Civics { get; internal set; } = new HashSet<String>();
        public HashSet<String> Traits { get; internal set; } = new HashSet<String>();
        public String Origin { get; set; }
        public String Authority { get; set; }
        public String Habitat { get; set; }
    }
}
