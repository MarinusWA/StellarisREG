using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;
using System.Xml.Linq;

namespace Dauros.StellarisREG.DAL
{
	public class SelectState : IEquatable<SelectState>
	{
		public HashSet<String> SelectedDLC { get; init; } = new HashSet<string>();
		public HashSet<String> EthicNames { get; } = new HashSet<String>();
		public IEnumerable<Ethic> Ethics => EthicNames.Select(en => Ethic.Collection[en]);
		public String? OriginName { get; private set; }
		public Origin? Origin => OriginName is { } name ? Origin.Collection[name] : null;
		public String? AuthorityName { get; private set; }
		public Authority? Authority => AuthorityName is { } name ? Authority.Collection[name] : null;
		public HashSet<String> CivicNames { get; private set; } = new HashSet<String>();
		public IEnumerable<Civic> Civics => CivicNames.Select(en => Civic.Collection[en]);
		public HashSet<String> TraitNames { get; private set; } = new HashSet<String>();
		public IEnumerable<Trait> Traits => TraitNames.Select(tn => Trait.Collection[tn]);
		public String? ShipsetName { get; private set; }
		public ShipSet? Shipset => ShipsetName != null ? ShipSet.Collection[ShipsetName] : null;
		public String? PhenotypeName { get; private set; }
		public SpeciesPhenotype? Phenotype => PhenotypeName is { } name ? SpeciesPhenotype.Collection[name] : null;
		private readonly IMemoryCache _memoryCache;


		/// <summary>
		/// Returns all DLC that impact Empire choices.
		/// </summary>
		/// <remarks>This is a fixed value hashset because using reflection would reduce performance (and it's slow enough as it is)</remarks>
		public static HashSet<String> AllDLC => new HashSet<string>()
		{ EPN.D_AncientRelics, EPN.D_Apocalypse, EPN.D_Federations, EPN.D_Lithoids, EPN.D_Megacorp, EPN.D_Necroids, EPN.D_SyntheticDawn, EPN.D_Utopia, EPN.D_Humanoids, EPN.D_Plantoids,EPN.D_Nemesis, EPN.D_Aquatics,
			EPN.D_Toxoids, EPN.D_AstralPlanes, EPN.D_Overlord, EPN.D_GalParagons, EPN.D_FirstContact, EPN.D_MachineAge, EPN.D_CosmicStorms, EPN.D_GrandArchive, EPN.D_Biogenesis };

		#region Hashing



		public IEnumerable<string> GetHashableSet()
		{
			var set = EmpireProperties.Select(ep => ep.Name).ToHashSet();
			set.UnionWith(SelectedDLC);
			return set;
		}


		public override int GetHashCode()
		{
			var hash = new HashCode();
			foreach (var item in GetHashableSet().Order().ToList())
			{
				hash.Add(item);
			}
			return hash.ToHashCode();
		}

		public override bool Equals(object? obj) => Equals(obj as SelectState);

		public bool Equals(SelectState? other)
		{
			if (other is null) return false;

			var thisNames = EmpireProperties.Select(ep => ep.Name).ToHashSet();
			var otherNames = other.EmpireProperties.Select(ep => ep.Name).ToHashSet();

			return thisNames.SetEquals(otherNames) && other.SelectedDLC.SetEquals(SelectedDLC);
		}
		#endregion

		public string PrintEmpireProperties()
		{
			var sb = new StringBuilder();
			foreach (var ep in EmpireProperties)
			{
				sb.Append(ep.Name + ",");
			}
			return sb.ToString();
		}


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
				if (Shipset != null) result.Add(Shipset);
				if (Phenotype != null) result.Add(Phenotype);
				return result;
			}
		}
		/// <summary>
		/// All properties allowed by DLC
		/// </summary>
		public IEnumerable<EmpireProperty> AllowedByDLCEmpireProperties
		{
			get
			{
				return AllEmpireProperties.Where(kvp =>
					EmpirePropertyIsAllowedByDLC(kvp.Value)
				).Select(kvp => kvp.Value);
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

		private static HashSet<string>? _grantedTraitsCache;
		public static HashSet<String> GrantedTraits
		{
			get
			{
				if (_grantedTraitsCache == null)
				{
					_grantedTraitsCache = AllEmpireProperties
						.Where(kvp => kvp.Value.GrantedTraits.Any())
						.SelectMany(kvp => kvp.Value.GrantedTraits)
						.ToHashSet();
				}
				return _grantedTraitsCache;
			}
		}

		public SelectState(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		public SelectState(IMemoryCache memoryCache, HashSet<EmpireProperty> eps)
		{
			_memoryCache = memoryCache;
			foreach (var ep in eps)
			{
				AddEmpireProperty(ep);
			}
		}

		protected IEnumerable<String> GetValidProperties()
		{
			Dictionary<SelectState, IEnumerable<String>>? set;
			if (!_memoryCache.TryGetValue("ValidProps", out set))
			{
				set = new Dictionary<SelectState, IEnumerable<String>>();
				_memoryCache.Set("ValidProps", set, TimeSpan.FromMinutes(60));
			}

			if (!set!.TryGetValue(this, out IEnumerable<string>? cached) || cached == null)
			{
				var prohibited = this.GetProhibited();
				var allowed = this.AllowedByDLCEmpireProperties.Except(EmpireProperties).Select(ep => ep.Name);
				var validProps = allowed.Except(prohibited);
				set.Add(this, validProps);
				return validProps;
			}
			return cached;
		}

		public HashSet<String> GetValidTraits()
		{
			return GetValidProperties().Where(ep => SelectState.GetEmpirePropertyType(ep) == EmpirePropertyType.Trait)
				.Except(SelectState.GrantedTraits).ToHashSet();//Granted traits are not selectable or pickable


			//Dictionary<SelectState, HashSet<String>>? set;
			//if (!_memoryCache.TryGetValue("ValidTraits", out set))
			//{
			//	set = new Dictionary<SelectState, HashSet<String>>();
			//	_memoryCache.Set("ValidTraits", set, TimeSpan.FromMinutes(60));
			//}

			//if (!set!.ContainsKey(this))
			//{
			//	var validProps = GetValidProperties().Where(ep => SelectState.GetEmpirePropertyType(ep) == EmpirePropertyType.Trait)
			//	.Except(SelectState.GrantedTraits).ToHashSet();//Granted traits are not selectable or pickable
				
			//	return validProps;
			//}
			//else
			//	return set[this];
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


		/// <summary>
		/// All empire properties that are prohibited by the current selection set.
		/// </summary>
		/// <returns></returns>
		public AndSet GetProhibited()
		{
			Dictionary<SelectState, AndSet>? prohibitions;
			if (!_memoryCache.TryGetValue("Prohibited", out prohibitions))
			{
				prohibitions = new Dictionary<SelectState, AndSet>();
				_memoryCache.Set("Prohibited", prohibitions, TimeSpan.FromMinutes(60));
			}

			if (prohibitions!.ContainsKey(this))
			{
				//	Debug.WriteLine($"Found prohibited key {string.Join(", ", this.GetHashableSet())} for {this.GetHashCode()}");
				return prohibitions[this];
			}

			var prohibited = new AndSet();

			//Only properties allowed by the selected DLC are checked (because the remainder is already prohibited)
			foreach (var ep in AllowedByDLCEmpireProperties)
			{
				//Don't check properties that are already selected
				if (EmpireProperties.Contains(ep)) continue;

				//Create a selectstate with the new addition
				SelectState newState = new SelectState(_memoryCache, this.EmpireProperties)
				{
					SelectedDLC = this.SelectedDLC
				};
				newState.AddEmpireProperty(ep);

				if (!newState.ValidateState())
				{

					prohibited.Add(ep.Name);
				}
			}
			prohibitions.Add(this, prohibited);
			//			Debug.WriteLine($"Added prohibited key {string.Join(", ", this.GetHashableSet())} for {this.GetHashCode()}");
			return prohibited;
		}

		public void AddEmpireProperty(IEnumerable<string?> empirePropertyNames)
		{
			foreach (var epn in empirePropertyNames)
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
				case EmpirePropertyType.SpeciesPhenotype:
					this.PhenotypeName = ep.Name;
					break;
				default:
					break;
			}

			//Debug.WriteLine($"Added {ep.Name} to get {this.PrintEmpireProperties()}");
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

			//more than three civics is not allowed
			valid = selectedEmpireProperties.Count(e => e.Type == EmpirePropertyType.Civic) <= 2;
			if (!valid) return valid;

			//Check if Ethic cost is valid
			var selectedEthics = selectedEmpireProperties.Where(ep => ep.Type == EmpirePropertyType.Ethic).Select(ep => (ep as Ethic)!);
			valid = selectedEthics.Sum(e => e.Cost) <= 3;
			if (!valid) return valid;

			//At most one Design Trait is allowed for Machine Empires
			valid = selectedEmpireProperties.OfType<MachineTrait>().Count(mt => mt.IsDesignTrait) <= 1;
			if (!valid) return valid;

			return valid;
		}

		public Boolean ValidateTraitRestrictions()
		{
			var basePicks = GetTraitBasepicks();
			var selectedTraits = this.EmpireProperties.Where(ep => ep.Type == EmpirePropertyType.Trait).Select(ep => (ep as Trait)!);

			//Traits with a cost of zero don't count as a pick
			var traitCount = selectedTraits.Where(t => t.CountsToCap).Count();
			//Trait count may not exceed allowed picks
			if (traitCount > basePicks) return false;

			var picksRemaining = basePicks - traitCount;
			var currentCost = selectedTraits.Sum(t => t.Cost);

			//Check the points restriction
			var basepoints = GetTraitBasepoints();

			var prohibitedTraits = selectedTraits.Where(t => t.Prohibits.Any()).SelectMany(t => t.Prohibits).ToHashSet();

			var allowedTraitPicks = this.AllowedByDLCEmpireProperties
				.Where(ep => ep.Type == EmpirePropertyType.Trait)
				.Except(this.EmpireProperties)//Already selected traits are not allowed
				.Select(ep => (ep as Trait)!)
				.ExceptBy(prohibitedTraits, x => x.Name)//Prohibited traits are not allowed
				;

			//The maximum possible negative costs for the remaining picks
			var maxNegativeRemainder = allowedTraitPicks.OrderBy(t => t.Cost).Take(picksRemaining).Sum(t => t.Cost);
			//If the current set of traits (plus basepoints) costs more than what could be couped back with negative picks,
			//the current selection is invalid
			if (currentCost - basepoints + maxNegativeRemainder > 0) return false;

			return true;
		}

		public int GetTraitBasepoints()
		{
			//This returns the selected traits along with their requirments
			var shadows = GetValidShadowStates();
			var basepoints = 2;
			//Machine empires only get one basepoint
			if (shadows.Any(set => set.Contains(EPN.PH_Machine))) basepoints = 1;
			//Overtuned gives 2 extra points
			else if (shadows.Any(set => set.Contains(EPN.O_Overtuned))) basepoints += 2;
			return basepoints;
		}


		public int GetTraitBasepicks()
		{
			var shadows = GetValidShadowStates();
			var basepicks = 5;
			//Overtuned gives an extra pick
			if (shadows.Any(set => set.Contains(EPN.O_Overtuned))) basepicks += 1;
			return basepicks;
		}

		public Boolean ValidateState()
		{
			Dictionary<SelectState, bool>? states;
			if (!_memoryCache.TryGetValue("States", out states))
			{
				states = new Dictionary<SelectState, bool>();
				_memoryCache.Set("States", states, TimeSpan.FromMinutes(60));
			}

			if (states!.ContainsKey(this))
			{
				//Debug.WriteLine($"Found validate key {string.Join(", ", this.GetHashableSet())} for {this.GetHashCode()}");
				return states[this];
			}

			var directValidation = ValidateSelection(EmpireProperties.Select(ep => ep.Name).ToHashSet());
			if (directValidation && ValidateTraitRestrictions())
			{
				var hasValidShadows = GetValidShadowStates().Count() > 0;

				//Debug.WriteLine($"Added validate key {string.Join(", ", this.GetHashableSet())} for {this.GetHashCode()}");
				states!.Add(this, hasValidShadows);
				return hasValidShadows;
			}
			else
				return false;
		}

		/// <summary>
		/// A shadow state is all selected properties along with all their required properties. 
		/// This function will return each possible requirement configuration for the SelectState
		/// </summary>
		/// <returns></returns>
		public HashSet<AndSet> GetValidShadowStates()
		{
			var allPropertySelectedSets = new HashSet<HashSet<AndSet>>();
			var propertiesToCheckRequirements = new HashSet<EmpireProperty>(EmpireProperties);

			Dictionary<string, HashSet<AndSet>>? requirements;
			if (!_memoryCache.TryGetValue("Required", out requirements))
			{
				requirements = new();
				_memoryCache.Set("Required", requirements, TimeSpan.FromMinutes(60));
			}

			foreach (var ep in propertiesToCheckRequirements)
			{
				if (!ep.Requires.Any() || (ep.Name == EPN.PH_Machine && SelectedDLC.Contains(EPN.D_MachineAge))) continue;

				//MachineAge changes requirements for Machine empires so it needs to be part of the key
				var cacheKey = ep.Name + SelectedDLC.Contains(EPN.D_MachineAge);

				HashSet<AndSet> combinedRequirementSets;
				if (!requirements!.ContainsKey(cacheKey))
				{
					combinedRequirementSets = RecurseRequirement(new HashSet<OrSet>(ep.Requires), new HashSet<string>() { ep.Name });
					//Add the requirements to the cache
					requirements.Add(cacheKey, combinedRequirementSets);
					//Debug.WriteLine($"Added requirement key {cacheKey} for {this.GetHashCode()}");
				}
				else
				{
					combinedRequirementSets = requirements[cacheKey];
					//Debug.WriteLine($"Found requirement key {cacheKey} for {this.GetHashCode()}");
				}
				var validSets = new HashSet<AndSet>();
				foreach (var reqSet in combinedRequirementSets)
				{
					var isValid = ValidateSelection(reqSet);
					if (isValid) validSets.Add(reqSet);
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
				foreach (var requirementSet in first)
				{
					var newRemaining = remainingRequirements.Where(r => r != first).ToHashSet();
					if (newRemaining.Count > 0)
					{
						var subSets = MergeRequirementSetsWithState(newRemaining);
						foreach (var sub in subSets)
						{
							sub.UnionWith(requirementSet);
						}
						result.UnionWith(subSets);
					}
					else
					{
						var newSet = new AndSet();
						newSet.UnionWith(EmpireProperties.Select(ep => ep.Name));
						newSet.UnionWith(requirementSet);
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
						var addedRequirements = epProp.Requires.Select(os => new OrSet(os)).ToHashSet();
						foreach (var orSet in addedRequirements)
						{
							orSet.RemoveWhere(x => processing.Contains(x));
							if (!orSet.Any()) addedRequirements.Remove(orSet);
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