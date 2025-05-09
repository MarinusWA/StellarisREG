using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public class SelectState
    {
        public HashSet<String> SelectedDLC { get; set; } = new HashSet<string>();
        public HashSet<String> EthicNames { get; } = new HashSet<String>();
        public IReadOnlyCollection<Ethic> Ethics => EthicNames.Select(en => Ethic.Collection[en]).ToHashSet();
        public String? OriginName { get; private set; }
        public Origin? Origin => OriginName is { } name ? Origin.Collection[name] : null;
        public String? AuthorityName { get; private set; }
        public Authority? Authority => AuthorityName is { } name ? Authority.Collection[name] : null;
        public HashSet<String> CivicNames { get; private set; } = new HashSet<String>();
        public IReadOnlyCollection<Civic> Civics => CivicNames.Select(en => Civic.Collection[en]).ToHashSet();
        public HashSet<String> TraitNames { get; private set; } = new HashSet<String>();
        public IReadOnlyCollection<Trait> Traits => TraitNames.Select(tn => Trait.Collection[tn]).ToHashSet();
        public String? ArchetypeName { get; private set; }
        public SpeciesPhenotype? Archetype => ArchetypeName is { } name ? SpeciesPhenotype.Collection[name] : null;
        public String? ShipsetName { get; private set; }
		public ShipSet? Shipset => ShipsetName != null ? ShipSet.Collection[ShipsetName] : null;
        public String? PhenotypeName { get; private set; }
		public SpeciesPhenotype? Phenotype => PhenotypeName is { } name ? SpeciesPhenotype.Collection[name] : null;


		/// <summary>
		/// Returns all DLC that impact Empire choices.
		/// </summary>
		/// <remarks>This is a fixed value hashset because using reflection would reduce performance (and it's slow enough as it is)</remarks>
		public static HashSet<String> AllDLC => new HashSet<string>()
        { EPN.D_AncientRelics, EPN.D_Apocalypse, EPN.D_Federations, EPN.D_Lithoids, EPN.D_Megacorp, EPN.D_Necroids, EPN.D_SyntheticDawn, EPN.D_Utopia, EPN.D_Humanoids, EPN.D_Plantoids,EPN.D_Nemesis, EPN.D_Aquatics,
            EPN.D_Toxoids, EPN.D_AstralPlanes, EPN.D_Overlord, EPN.D_GalParagons, EPN.D_FirstContact, EPN.D_MachineAge, EPN.D_CosmicStorms, EPN.D_GrandArchive, EPN.D_Biogenesis };

        /// <summary>
        /// Contains all EmpireProperties that are set on this SelectState
        /// </summary>
        public HashSet<EmpireProperty> EmpireProperties
        {
            get
            {
                var result = new HashSet<EmpireProperty>();
                result.UnionWith(Ethics);
                if (Origin != null) result.Add(Origin);
                if (Authority != null) result.Add(Authority);
                result.UnionWith(Civics);
                result.UnionWith(Traits);
                if (Archetype != null) result.Add(Archetype);
                if (Shipset != null) result.Add(Shipset);
                if (Phenotype != null) result.Add(Phenotype);
				return result;
            }
        }
        /// <summary>
        /// All properties allowed by DLC
        /// </summary>
        public HashSet<EmpireProperty> AllowedByDLCEmpireProperties
        {
            get
            {
                return AllEmpireProperties.Where(kvp =>
					EmpirePropertyIsAllowedByDLC(kvp.Value)
				).Select(kvp => kvp.Value).ToHashSet();
			}
		}

        private Boolean EmpirePropertyIsAllowedByDLC(EmpireProperty ep)
        {
            //properties that are prohibited by selected DLC (like the Corporate Dominion civic)
            if (ep.Prohibits.Overlaps(SelectedDLC)) return false;

            //If any of the OrSets does not contain atleast one of the selected DLC, it is not allowed
            return ep.DLC.All(orSet => orSet.Overlaps(SelectedDLC));
        }


		private static Dictionary<String, EmpireProperty> _allEmpireProperties = null!;
        public static Dictionary<String, EmpireProperty> AllEmpireProperties
        {
            get
            {
                if (_allEmpireProperties == null)
                {
                    var result = new Dictionary<String, EmpireProperty>();
                    result = result.Union(Ethic.Collection.ToDictionary(kvp => kvp.Key, kvp => kvp.Value as EmpireProperty)).ToDictionary(k => k.Key, k => k.Value);
                    result = result.Union(Civic.Collection.ToDictionary(kvp => kvp.Key, kvp => kvp.Value as EmpireProperty)).ToDictionary(k => k.Key, k => k.Value);
                    result = result.Union(Origin.Collection.ToDictionary(kvp => kvp.Key, kvp => kvp.Value as EmpireProperty)).ToDictionary(k => k.Key, k => k.Value);
                    result = result.Union(Authority.Collection.ToDictionary(kvp => kvp.Key, kvp => kvp.Value as EmpireProperty)).ToDictionary(k => k.Key, k => k.Value);
                    result = result.Union(Trait.Collection.ToDictionary(kvp => kvp.Key, kvp => kvp.Value as EmpireProperty)).ToDictionary(k => k.Key, k => k.Value);
                    result = result.Union(SpeciesPhenotype.Collection.ToDictionary(kvp => kvp.Key, kvp => kvp.Value as EmpireProperty)).ToDictionary(k => k.Key, k => k.Value);
                    result = result.Union(ShipSet.Collection.ToDictionary(kvp => kvp.Key, kvp => kvp.Value as EmpireProperty)).ToDictionary(k => k.Key, k => k.Value);
					_allEmpireProperties = result;
                }
                return _allEmpireProperties;
            }
        }

        public static HashSet<String> GrantedEmpireProperties
        {
			get
			{
				return AllEmpireProperties.Where(kvp => kvp.Value.GrantedTraits.Any()).Select(kvp => kvp.Key).ToHashSet();
			}
		}

        public SelectState() {
		}

        public SelectState(HashSet<EmpireProperty> eps)
        {
			foreach (var ep in eps)
            {
                AddEmpireProperty(ep);
            }
        }

        protected HashSet<String> GetValidProperties()
        {
            var prohibited = this.GetProhibited();
            var allowed = this.AllowedByDLCEmpireProperties.Except(EmpireProperties).Select(ep => ep.Name);
            return allowed.Except(prohibited).ToHashSet();
        }

        public HashSet<String> GetValidTraits()
        {
            return GetValidProperties().Where(ep => SelectState.GetEmpirePropertyType(ep) == EmpirePropertyType.Trait).ToHashSet();
        }

        public HashSet<String> GetValidEthics()
        {
            return GetValidProperties().Where(ep => SelectState.GetEmpirePropertyType(ep) == EmpirePropertyType.Ethic).ToHashSet();
        }

        public HashSet<String> GetValidOrigins()
        {
            return GetValidProperties().Where(ep => SelectState.GetEmpirePropertyType(ep) == EmpirePropertyType.Origin).ToHashSet();
        }

        public HashSet<String> GetValidAuthorities()
        {
            return GetValidProperties().Where(ep => SelectState.GetEmpirePropertyType(ep) == EmpirePropertyType.Authority).ToHashSet();
        }

        public HashSet<String> GetValidCivics()
        {
            return GetValidProperties().Where(ep => SelectState.GetEmpirePropertyType(ep) == EmpirePropertyType.Civic).ToHashSet();
        }

        public HashSet<String> GetValidArchetypes()
        {
            return GetValidProperties().Where(ep => SelectState.GetEmpirePropertyType(ep) == EmpirePropertyType.SpeciesArchetype).ToHashSet();
        }

		public HashSet<String> GetValidPhenotypes()
		{
			return GetValidProperties().Where(ep => SelectState.GetEmpirePropertyType(ep) == EmpirePropertyType.SpeciesPhenotype).ToHashSet();
		}

		public HashSet<String> GetValidShipsets()
		{
			return GetValidProperties().Where(ep => SelectState.GetEmpirePropertyType(ep) == EmpirePropertyType.Shipset).ToHashSet();
		}

		public AndSet GetProhibited()
        {
            var prohibited = new AndSet();

            foreach (var ep in AllowedByDLCEmpireProperties)
            {
                //Don't check properties that are already selected
                if (EmpireProperties.Contains(ep)) continue;

				//Create a selectstate with the new addition
				SelectState newState = new SelectState(this.EmpireProperties);
                newState.SelectedDLC = this.SelectedDLC;
				newState.AddEmpireProperty(ep);
                
                if (!newState.ValidateState())
                {
                    prohibited.Add(ep.Name);
                }
            }
            return prohibited;
        }

		public void AddEmpireProperty(IEnumerable<string?> empirePropertyNames)
		{
			foreach(var epn in empirePropertyNames)
			{
				AddEmpireProperty(epn);
			}
		}

		public void AddEmpireProperty(string? empirePropertyName)
        {
            if (empirePropertyName == null) return;
			
            var ep = AllEmpireProperties[empirePropertyName];
			AddEmpireProperty(ep);
			//If the empireproperty also grants traits, add these to the selectstate as well
			if (ep.GrantedTraits.Any())
			{
				foreach (var trait in ep.GrantedTraits)
				{
                    AddEmpireProperty(trait);
				}
			}
			
        }

        public void AddEmpireProperty(EmpireProperty ep)
        {
            switch (ep.Type)
            {
                case EmpirePropertyType.Origin:
                    this.OriginName = ep.Name;
                    break;
                case EmpirePropertyType.Ethic:
                    this.EthicNames.Add(ep.Name);
                    break;
                case EmpirePropertyType.Authority:
                    this.AuthorityName = ep.Name;
                    break;
                case EmpirePropertyType.Civic:
                    this.CivicNames.Add(ep.Name);
                    break;
                case EmpirePropertyType.Trait:
                    this.TraitNames.Add(ep.Name);
                    break;
                case EmpirePropertyType.Habitat:
                    break;
                case EmpirePropertyType.SpeciesArchetype:
                    this.ArchetypeName = ep.Name;
                    break;
                default:
                    break;
            }
        }

		/// <summary>
		/// Tests if a selection set is valid based on rules other than EmpireProperty prohibitions or requirements.
		/// </summary>
		/// <param name="selectedEmpirePropertyNames"></param>
		/// <returns></returns>
		public static Boolean ValidateSelection(HashSet<String> selectedEmpirePropertyNames)
        {
            var selectedEmpireProperties = selectedEmpirePropertyNames.Select(n => AllEmpireProperties[n]);

			//If a selectionset contains a selection that is prohibited by that same selectionset, it is invalid.
			var valid = !selectedEmpireProperties.Where(e => e.Prohibits != null).Any(e => e.Prohibits.Any(pe => selectedEmpirePropertyNames.Contains(pe)));
            if (!valid) return valid;

            //two or more authorities is not allowed
            valid = selectedEmpireProperties.Count(e => e.Type == EmpirePropertyType.Authority) <= 1;
            if (!valid) return valid;

			//two or more shipsets is not allowed
			valid = selectedEmpireProperties.Count(e => e.Type == EmpirePropertyType.Shipset) <= 1;
			if (!valid) return valid;

			//two or more phenotypes is not allowed
			valid = selectedEmpireProperties.Count(e => e.Type == EmpirePropertyType.SpeciesPhenotype) <= 1;
			if (!valid) return valid;

			//two or more orgins is not allowed
			valid = selectedEmpireProperties.Count(e => e.Type == EmpirePropertyType.Origin) <= 1;
            if (!valid) return valid;

            //two or more archetypes is not allowed
            valid = selectedEmpireProperties.Count(e => e.Type == EmpirePropertyType.SpeciesArchetype) <= 1;
            if (!valid) return valid;

            //more than three civics is not allowed
            valid = selectedEmpireProperties.Count(e => e.Type == EmpirePropertyType.Civic) <= 2;
            if (!valid) return valid;

            //Check if Ethic cost is valid
            var selectedEthics = selectedEmpireProperties.Where(ep => ep.Type == EmpirePropertyType.Ethic).Select(ep => (ep as Ethic)!);
            valid = selectedEthics.Sum(e => e.Cost) <= 3;
            if (!valid) return valid;

            //Machine empires only get one basepoint
            var basepoints = 2;
            var basePicks = 5;
            if (selectedEmpirePropertyNames.Contains(EPN.A_MachineIntelligence)) basepoints = 1;
            else if (selectedEmpirePropertyNames.Contains(EPN.O_Overtuned)) { basepoints += 2; basePicks += 1; }
			
            var selectedTraits = selectedEmpireProperties.Where(ep => ep.Type == EmpirePropertyType.Trait).Select(ep => (ep as Trait)!);
            if (selectedTraits.Count() == basePicks)
            {
                valid = selectedTraits.Sum(t => t.Cost) - basepoints <= 0;
            }
            if (!valid) return valid;

            //Trait count may not exceed 5
            valid = selectedTraits.Count() <= basePicks;
            if (!valid) return valid;

            return valid;
        }

        public Boolean ValidateState()
        {
            var directValidation = ValidateSelection(EmpireProperties.Select(ep => ep.Name).ToHashSet());
            if (directValidation)
                return GetValidShadowStates().Count() > 0;
            else
                return false;
        }

        public HashSet<AndSet> GetValidShadowStates()
        {
            var allPropertySelectedSets = new HashSet<HashSet<AndSet>>();
            var propertiesToCheckRequirements = new HashSet<EmpireProperty>(EmpireProperties);

            foreach (var ep in propertiesToCheckRequirements)
            {
				if (!ep.Requires.Any()) continue;

				

				var selSets = RecurseRequirement(new HashSet<OrSet>(ep.Requires), new HashSet<string>() { ep.Name });
                var validSets = new HashSet<AndSet>();
                foreach (var selSet in selSets)
                {
                    var isValid = ValidateSelection(selSet);
                    if (isValid) validSets.Add(selSet);
                }
                allPropertySelectedSets.Add(validSets);
            }

            var combinedSelectSets = MergeRequirementSetsWithState(allPropertySelectedSets);
            var combinedValidSets = new HashSet<AndSet>();
            foreach (var combiSet in combinedSelectSets)
            {
                var isValid = ValidateSelection(combiSet);
                if (isValid) combinedValidSets.Add(combiSet);
            }

            return combinedValidSets;
        }

        public static EmpirePropertyType GetEmpirePropertyType(String epString)
        {
            return AllEmpireProperties[epString].Type;
        }

        public HashSet<AndSet> MergeRequirementSetsWithState(HashSet<HashSet<AndSet>> remainingRequirements)
        {
            var result = new HashSet<AndSet>();
            if (remainingRequirements.Any())
            {
                var first = remainingRequirements.First();
                foreach (var ep in first)
                {
                    var newRemaining = remainingRequirements.Where(r => r != first).ToHashSet();
                    if (newRemaining.Count > 0)
                    {
                        var subSets = MergeRequirementSetsWithState(newRemaining);
                        foreach (var sub in subSets)
                        {
                            sub.UnionWith(ep);
                        }
                        result.UnionWith(subSets);
                    }
                    else
                    {
                        var newSet = new AndSet();
                        newSet.UnionWith(EmpireProperties.Select(ep => ep.Name));
                        newSet.UnionWith(ep);
                        result.Add(newSet);
                    }
                }
            }
            else
            {
                var newSet = new AndSet();
                newSet.UnionWith(EmpireProperties.Select(ep => ep.Name));
                result.Add(newSet);
            }
            return result;
        }

        /// <summary>
        /// Returns all possible selection sets for a single EmpireProperty
        /// </summary>
        /// <param name="remaining"></param>
        /// <returns></returns>
        public HashSet<AndSet> RecurseRequirement(HashSet<OrSet> remaining, HashSet<string> processing)
        {
            var result = new HashSet<AndSet>();
            var first = remaining.First();
            foreach (var epName in first)
            {
				try
                {
					//Check if this EP has requirements. If it does, add those to the remaining set
					var epProp = AllEmpireProperties[epName];
					//if the machine age DLC is selected, ignore the requirements of the machine phenotype
					if (epProp.Requires.Any() && !(epName == EPN.PH_Machine && SelectedDLC.Contains(EPN.D_MachineAge)))
                    {
                        var addedRequirements = epProp.Requires.Select(os=>new OrSet(os)).ToHashSet();
						foreach (var orSet in addedRequirements)
						{
                            orSet.RemoveWhere(x => processing.Contains(x));
						}
						remaining.UnionWith(addedRequirements);
                    }

                    var newRemaining = remaining.Where(r => r != first).ToHashSet();
                    if (newRemaining.Count > 0)
                    {
                        //Add the EP being processed to the collection
						processing.Add(epName);
						var subSets = RecurseRequirement(newRemaining, processing);
                        foreach (var sub in subSets)
                        {
                            sub.Add(epName);
                        }
                        result.UnionWith(subSets);
                    }
                    else
                    {

                        result.Add(new AndSet() { epName });
                    }
                }
                catch (Exception ex) { throw; }
            }
            return result;
        }

    }
}