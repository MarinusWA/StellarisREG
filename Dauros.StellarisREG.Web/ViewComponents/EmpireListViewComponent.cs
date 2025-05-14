using Dauros.StellarisREG.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dauros.StellarisREG.Web.ViewComponents
{
    [ViewComponent]
    public class EmpireList : ViewComponent
    {
		private readonly IMemoryCache _memoryCache;
        private Random _random = new Random();

		public EmpireList(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		public IViewComponentResult Invoke(HashSet<String> selectedDLC, string? selectedOrigin, HashSet<String> selectedEthics,
            String? selectedAuthority, String? selectedPhenotype, string? selectedShipSet,
            HashSet<String> selectedCivics, HashSet<String> selectedTraits)
        {
            var result = new List<EmpireDataModel>();
            var states = new List<SelectState>();

            for (int i = 0; i < 10; i++)
            {
                var ss = new SelectState(_memoryCache) {
					SelectedDLC = selectedDLC ?? SelectState.AllDLC.ToHashSet()
				};
                ss.AddEmpireProperty(selectedCivics ?? new HashSet<string>());
				ss.AddEmpireProperty(selectedEthics ?? new HashSet<string>());
                ss.AddEmpireProperty(selectedAuthority);
				ss.AddEmpireProperty(selectedOrigin);
                ss.AddEmpireProperty(selectedShipSet);
                ss.AddEmpireProperty(selectedPhenotype);
				ss.AddEmpireProperty(selectedTraits ?? new HashSet<string>());

				states.Add(ss);
            }

            foreach (var ss in states)
            {
                try
                {
                    //SetRandomArchetype(ss);
                    SetRandomPhenotype(ss);
                    //Mix up if it starts randomizing with an origin or with civics
                    //this is to prevent civics restricted by origins (and vice versa) from having very low chances of appearing
                    var firstProp = _random.Next(2);
                    if (firstProp == 0)
                    {
                        AddRandomCivics(ss);
                        SetRandomOrigin(ss);
                    }
                    else
                    {
                        SetRandomOrigin(ss);
                        AddRandomCivics(ss);
                    }
                    AddRandomEthics(ss);
                    SetRandomAuthority(ss);

                    AddRandomTraits(ss);

                    var empireData = new EmpireDataModel()
                    {
                        Authority = ss.AuthorityName!,
                        Origin = ss.OriginName!,
                        Civics = ss.CivicNames,
                        Ethics = ss.EthicNames,
                        Traits = ss.TraitNames,
                        PlanetType = GetRandomPlanetType(ss),
                        Phenotype = ss.PhenotypeName!
                    };

                    result.Add(empireData);
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            return View(result);
        }


		private void SetRandomPhenotype(SelectState ss)
		{
			if (ss.PhenotypeName == null)
			{
				var valid = ss.GetValidPhenotypes().ToArray();
                if (valid.Any())
                {
                    ss.AddEmpireProperty(valid[_random.Next(valid.Count())]);
                }
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
				ss.AddEmpireProperty(valid[_random.Next(valid.Count())]);
			}
		}
		private void AddRandomTraits(SelectState ss)
        {
            var validTraits = ss.GetValidTraits().ToArray();
            while (validTraits.Any())
            {
                var picked = validTraits[_random.Next(validTraits.Count())];
                ss.AddEmpireProperty(picked);
				if (ss.Traits.Where(t=>t.CountsToCap).Count() >= 3 && ss.Traits.Sum(t => t.Cost) == 2) break;
                validTraits = ss.GetValidTraits().ToArray();
            }
        }


        private void SetRandomOrigin(SelectState ss)
        {
            if (ss.OriginName == null)
            {
                var validOrigins = ss.GetValidOrigins().ToArray();
                if (validOrigins.Any())
                {
                    ss.AddEmpireProperty(validOrigins[_random.Next(validOrigins.Count())]);
                }
            }
        }

        private void SetRandomAuthority(SelectState ss)
        {
            if (ss.AuthorityName == null)
            {
                var validAuths = ss.GetValidAuthorities().ToArray();
                if (validAuths.Any())
                {
                    ss.AddEmpireProperty(validAuths[_random.Next(validAuths.Count())]);
                }
            }
        }

        private String GetRandomPlanetType(SelectState ss)
        {
            //Only origins set planettype (for now)
            string? result = ss.Origin?.PlanetType;
            if (result == null)
            {
                var validPTypes = new List<String>() {
                EPN.PT_Arid, EPN.PT_Alpine,EPN.PT_Artic,EPN.PT_Continental,EPN.PT_Desert,EPN.PT_Ocean,EPN.PT_Savanna,EPN.PT_Tropical,EPN.PT_Tundra};
                result = validPTypes[_random.Next(validPTypes.Count)];
            }
            return result;
        }
        private void AddRandomCivics(SelectState ss)
        {
            var validCivics = ss.GetValidCivics().ToArray();
            while (validCivics.Any())
            {
                var picked = validCivics[_random.Next(validCivics.Count())];
                ss.AddEmpireProperty(picked);
                validCivics = ss.GetValidCivics().ToArray();
            }
        }

        private void AddRandomEthics(SelectState ss)
        {
            var validEthics = ss.GetValidEthics().ToArray();
            while (validEthics.Any())
            {
                var picked = validEthics[_random.Next(validEthics.Count())];
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
        public String Phenotype { get; set; }
    }
}
