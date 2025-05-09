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
            String? selectedAuthority, String? selectedArchetype, string? selectedShipSet, HashSet<String> selectedCivics)
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
                ss.ArchetypeName = selectedArchetype;
                ss.SelectedDLC = selectedDLC != null ? selectedDLC.ToHashSet() : SelectState.AllDLC.ToHashSet();
                ss.ShipsetName = selectedShipSet;

                //Set auto assigned EmpireProperties
                if (selectedArchetype == EPN.AT_Lithoid)
                    ss.TraitNames.Add(EPN.T_Lithoid);
                else if (selectedArchetype == EPN.AT_Machine)
                    ss.TraitNames.Add(EPN.T_MachineUnit);

                if (ss.Authority != null && ss.Authority.Name == EPN.A_HiveMind)
                    ss.TraitNames.Add(EPN.T_HiveMinded);

                if (selectedOrigin == EPN.O_Necrophage)
                    ss.TraitNames.Add(EPN.T_Necrophage);
                else if (selectedOrigin == EPN.O_CloneArmy)
                    ss.TraitNames.Add(EPN.T_CloneSoldier);
                else if (selectedOrigin == EPN.O_SyncreticEvolution)
                    ss.TraitNames.Add(EPN.T_Serviles);
                else if (selectedOrigin == EPN.O_PostApocalyptic)
                    if (ss.ArchetypeName == EPN.AT_Machine)
						ss.TraitNames.Add(EPN.T_RadiationShields);
					else
						ss.TraitNames.Add(EPN.T_Survivor);
                else if (selectedOrigin == EPN.O_VoidDwellers)
                    ss.TraitNames.Add(EPN.T_VoidDweller);
                else if (selectedOrigin == EPN.O_Subterranean)
					if (ss.ArchetypeName == EPN.AT_Machine)
						ss.TraitNames.Add(EPN.T_Molebots);
                    else
                        ss.TraitNames.Add(EPN.T_CaveDweller);
                else if (selectedOrigin == EPN.O_UnderOneRule)
                    ss.TraitNames.Add(EPN.T_PerfectGenes);
                else if ( selectedOrigin == EPN.O_TeachersShroud)
                    ss.TraitNames.Add(EPN.T_LatentPsionic);
				else if (selectedOrigin == EPN.O_SyntheticFertility)
					ss.TraitNames.Add(EPN.T_PathogenicGenes);
				else if (selectedOrigin == EPN.O_EvolutionaryPredators)
					ss.TraitNames.Add(EPN.T_MalleableGenes);


				if (ss.CivicNames.Contains(EPN.C_Stargazers))
                    ss.TraitNames.Add(EPN.T_Stargazer);
				if (ss.CivicNames.Contains(EPN.C_StormInfluencers))
					ss.TraitNames.Add(EPN.T_StormTouched);
				if (ss.CivicNames.Contains(EPN.C_Anglers) || selectedOrigin == EPN.O_OceanParadise)
                    if (ss.ArchetypeName == EPN.AT_Machine)
						ss.TraitNames.Add(EPN.T_Waterproof);
					else
                        ss.TraitNames.Add(EPN.T_Aquatic);
				ss.TraitNames.Add(EPN.T_Aquatic);

                states.Add(ss);
            }

            foreach (var ss in states)
            {
                SetRandomArchetype(ss);
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
                    Archetype = ss.ArchetypeName ?? EPN.AT_Organic
            };

                result.Add(empireData);
            }

            return View(result);
        }

        private void SetRandomArchetype(SelectState ss)
        {
            var dist = new List<String>() {EPN.AT_Lithoid,EPN.AT_Machine };
            //Make biological pick more likely
            for (int i = 0; i < 4; i++) dist.Add(EPN.AT_Organic);
            for (int i = 0; i < 2; i++) dist.Add(EPN.PH_Plantoid);

            if (ss.ArchetypeName == null)
            {
                var valid = ss.GetValidArchetypes().ToArray();
                dist.RemoveAll(d => !valid.Contains(d));
                valid = dist.ToArray();
                var r = new Random();
                ss.ArchetypeName = valid[r.Next(valid.Count())];
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
				ss.ShipsetName = valid[r.Next(valid.Count())];
			}
		}
		private void AddRandomTraits(SelectState ss)
        {
            var validTraits = ss.GetValidTraits().ToArray();
            var r = new Random();
            while (validTraits.Any())
            {
                var picked = validTraits[r.Next(validTraits.Count())];
                ss.TraitNames.Add(picked);
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
        public String PlanetType { get; set; }
        public String Archetype { get; set; }
    }
}
