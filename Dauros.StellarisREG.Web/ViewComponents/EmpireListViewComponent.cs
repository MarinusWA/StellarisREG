using Dauros.StellarisREG.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            String? selectedAuthority, String? selectedPhenotype, string? selectedShipSet, HashSet<String> selectedCivics)
        {
            var result = new List<EmpireDataModel>();
            var states = new List<SelectState>();

            var r = new Random();

            for (int i = 0; i < 10; i++)
            {
                var ss = new SelectState();
				ss.SelectedDLC = selectedDLC ?? SelectState.AllDLC.ToHashSet();
                ss.AddEmpireProperty(selectedCivics ?? new HashSet<string>());
				ss.AddEmpireProperty(selectedEthics ?? new HashSet<string>());
                ss.AddEmpireProperty(selectedAuthority);
				ss.AddEmpireProperty(selectedOrigin);
                ss.AddEmpireProperty(selectedShipSet);
                ss.AddEmpireProperty(selectedPhenotype);

                states.Add(ss);
            }

            foreach (var ss in states)
            {
				//SetRandomArchetype(ss);
				SetRandomPhenotype(ss);
				//Mix up if it starts randomizing with an origin or with civics
				//this is to prevent civics restricted by origins (and vice versa) from having very low chances of appearing
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
                
                AddRandomTraits(ss);

                var empireData = new EmpireDataModel()
                {
                    Authority = ss.AuthorityName!,
                    Origin = ss.OriginName!,
                    Civics = ss.CivicNames,
                    Ethics = ss.EthicNames,
                    Traits = ss.TraitNames,
                    PlanetType = GetRandomPlanetType(ss),
                    SpeciesPhenotype = ss.PhenotypeName!
                };

                result.Add(empireData);
            }

            return View(result);
        }


		private void SetRandomPhenotype(SelectState ss)
		{
			if (ss.PhenotypeName == null)
			{
				var valid = ss.GetValidPhenotypes().ToArray();
				var r = new Random();
				ss.AddEmpireProperty(valid[r.Next(valid.Count())]);
			}
		}

		private void SetRandomShipSet(SelectState ss)
		{
			var dist = new List<String>() { EPN.S_Biological };
			//Make biological pick less likely (1/10 chance)
			for (int i = 0; i < 9; i++) dist.Add(EPN.S_Mechanical);

            if(ss.ShipsetName == null)
			{
				var valid = ss.GetValidShipsets().ToArray();
				dist.RemoveAll(d => !valid.Contains(d));
				valid = dist.ToArray();
				var r = new Random();
				ss.AddEmpireProperty(valid[r.Next(valid.Count())]);
			}
		}
		private void AddRandomTraits(SelectState ss)
        {
            var validTraits = ss.GetValidTraits().ToArray();
            var r = new Random();
            while (validTraits.Any())
            {
                var picked = validTraits[r.Next(validTraits.Count())];
                ss.AddEmpireProperty(picked);
				if (ss.Traits.Where(t=>t.CountsToCap).Count() >= 3 && ss.Traits.Sum(t => t.Cost) == 2) break;
                validTraits = ss.GetValidTraits().ToArray();
            }
        }


        private void AddRandomOrigin(SelectState ss)
        {
            if (ss.OriginName == null)
            {
                var validOrigins = ss.GetValidOrigins().ToArray();
                var r = new Random();
                ss.AddEmpireProperty(validOrigins[r.Next(validOrigins.Count())]);
            }
        }

        private void AddRandomAuthority(SelectState ss)
        {
            if (ss.AuthorityName == null)
            {
                var validAuths = ss.GetValidAuthorities().ToArray();
                var r = new Random();
                ss.AddEmpireProperty(validAuths[r.Next(validAuths.Count())]);
            }
        }

        private String GetRandomPlanetType(SelectState ss)
        {
            var r = new Random();
            var validPTypes = new List<String>() {
                EPN.PT_Arid, EPN.PT_Alpine,EPN.PT_Artic,EPN.PT_Continental,EPN.PT_Desert,EPN.PT_Ocean,EPN.PT_Savanna,EPN.PT_Tropical,EPN.PT_Tundra
            };
            var result = validPTypes[r.Next(validPTypes.Count)];

            if (ss.OriginName == EPN.O_LifeSeeded) result = EPN.PT_Gaia;
            else if (ss.OriginName == EPN.O_PostApocalyptic) result = EPN.PT_Tomb;
            else if (ss.OriginName == EPN.O_Remnants) result = EPN.PT_Relic;
            else if (ss.OriginName == EPN.O_ResourceConsolidation) result = EPN.PT_Machine;
            else if (ss.OriginName == EPN.O_ShatteredRing) result = EPN.PT_RingWorld;

            return result;
        }
        private void AddRandomCivics(SelectState ss)
        {
            var validCivics = ss.GetValidCivics().ToArray();
            var r = new Random();
            while (validCivics.Any())
            {
                var picked = validCivics[r.Next(validCivics.Count())];
                ss.AddEmpireProperty(picked);
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
                ss.AddEmpireProperty(picked);
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
        public String PlanetType { get; set; }
        public String SpeciesPhenotype { get; set; }
    }
}
