using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public class SelectState
    {
        public HashSet<String> EthicNames { get; set; } = new HashSet<String>();
        public IReadOnlyCollection<Ethic> Ethics => EthicNames.Select(en => Ethic.Collection[en]).ToHashSet();
        public String? OriginName { get; set; }
        public Origin? Origin => OriginName != null ? Origin.Collection[OriginName] : null;
        public String? AuthorityName { get; set; }
        public Authority? Authority => AuthorityName != null ? Authority.Collection[AuthorityName] : null;
        public HashSet<String> CivicNames { get; set; } = new HashSet<String>();
        public IReadOnlyCollection<Civic> Civics => CivicNames.Select(en => Civic.Collection[en]).ToHashSet();
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
                return result;
            }
        }

        public static Dictionary<String, EmpireProperty> AllEmpireProperties
        {
            get
            {
                var result = new Dictionary<String, EmpireProperty>();
                result = result.Union(Ethic.Collection.ToDictionary(kvp => kvp.Key, kvp => kvp.Value as EmpireProperty)).ToDictionary(k => k.Key, k => k.Value);
                result = result.Union(Civic.Collection.ToDictionary(kvp => kvp.Key, kvp => kvp.Value as EmpireProperty)).ToDictionary(k => k.Key, k => k.Value);
                result = result.Union(Origin.Collection.ToDictionary(kvp => kvp.Key, kvp => kvp.Value as EmpireProperty)).ToDictionary(k => k.Key, k => k.Value);
                result = result.Union(Authority.Collection.ToDictionary(kvp => kvp.Key, kvp => kvp.Value as EmpireProperty)).ToDictionary(k => k.Key, k => k.Value);
                return result;
            }
        }

        public AndSet GetProhibited()
        {
            var prohibited = new AndSet();

            var allSelectedPropertiesShadowStates = new HashSet<HashSet<AndSet>>();
            foreach (var ep in EmpireProperties)
            {
                if (ep.Requires.Any())
                {
                    var temp = new HashSet<OrSet>();
                    var singlePropertyShadowStates = RecurseRequirement(temp.Union(ep.Requires).ToHashSet());
                    allSelectedPropertiesShadowStates.Add(singlePropertyShadowStates);
                }
            }

            var merged = MergeRequirementSets(allSelectedPropertiesShadowStates);

            //Strip invalid states
            var validShadowStates = merged.Where(ss => ValidateSelection(ss));

            foreach (var kvp in AllEmpireProperties)
            {
                var ep = kvp.Value;
                var additionShadowStates = new HashSet<AndSet>();
                if (kvp.Value.Requires.Any())
                {
                    var temp = new HashSet<OrSet>();
                    additionShadowStates = RecurseRequirement(temp.Union(ep.Requires).ToHashSet());
                }

                var foundValidMergedState = false;

                foreach (var vss in validShadowStates)
                {
                    //Don't check properties that are already part of the shadowstate
                    if (vss.Contains(kvp.Key)) continue;
                    var isValidAdditionShadowState = false;
                    foreach (var addSS in additionShadowStates)
                    {
                        addSS.UnionWith(vss);
                        isValidAdditionShadowState = ValidateSelection(addSS);
                        if (isValidAdditionShadowState)
                        {
                            foundValidMergedState = true;
                            break;
                        }
                    }
                    
                    if (isValidAdditionShadowState)
                    {
                        foundValidMergedState = true;
                        break;
                    }
                }

                if (!foundValidMergedState) prohibited.Add(kvp.Key);
            }


            return prohibited;
        }

        #region OLD


        public HashSet<String> GetProhibitedOld()
        {
            var prohibitions = new HashSet<String>();
            var directProhibitions = new HashSet<String>();
            var selectedPropsWithProhibitions = EmpireProperties.Where(ep => ep.Prohibits != null)?.SelectMany(ep => ep.Prohibits);
            if (selectedPropsWithProhibitions != null)
                directProhibitions.UnionWith(selectedPropsWithProhibitions);


            var shadows = GetValidShadowStates();
            var propCount = new Dictionary<String, int>();
            //Only get prohibited from EmpireProperties that appear in all sets.
            foreach (var shadow in shadows)
            {
                foreach (var epn in shadow)
                {
                    var subPs = AllEmpireProperties[epn].Prohibits;
                    if (subPs != null)
                    {
                        foreach (var subP in subPs)
                        {
                            if (propCount.ContainsKey(subP))
                                propCount[subP]++;
                            else
                                propCount.Add(subP, 1);
                        }
                    }
                }
            }

            foreach (var kvp in propCount)
            {
                if (kvp.Value == shadows.Count())
                    directProhibitions.Add(kvp.Key);
            }

            prohibitions.UnionWith(directProhibitions);

            //All properties that require one of the directly prohibited properties are also prohibited
            foreach (var ep in AllEmpireProperties.Values)
            {
                if (!ep.Requires.Any()) continue;

                var shadowSet = RecurseRequirement(ep.Requires);
                var pSetCount = 0;
                foreach (var reqProp in shadowSet)
                {
                    if (reqProp.Except(directProhibitions).Count() < reqProp.Count())
                        pSetCount++;
                }

                if (pSetCount == shadowSet.Count())
                    prohibitions.Add(ep.Name);
            }

            return prohibitions;
        }

        public static Boolean ValidateSelection(HashSet<String> selectedEmpirePropertyNames)
        {
            var selectedEmpireProperties = selectedEmpirePropertyNames.Select(n => AllEmpireProperties[n]);
            //If a selectionset contains a selection that is prohibited by that same selectionset, it is invalid.
            var valid = !selectedEmpireProperties.Where(e => e.Prohibits != null).Any(e => e.Prohibits.Any(pe => selectedEmpirePropertyNames.Contains(pe)));
            if (!valid) return valid;

            //Check if Ethic cost is valid
            var selectedEthics = selectedEmpireProperties.Where(ep => ep.Type == EmpirePropertyType.Ethic).Select(ep => (ep as Ethic)!);
            valid = selectedEthics.Sum(e => e.Cost) <= 3;
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

                var selSets = RecurseRequirement(ep.Requires);
                var validSets = new HashSet<AndSet>();
                foreach (var selSet in selSets)
                {
                    var isValid = ValidateSelection(selSet);
                    if (isValid) validSets.Add(selSet);
                }
                allPropertySelectedSets.Add(validSets);
            }

            var combinedSelectSets = MergeRequirementSets(allPropertySelectedSets);
            var combinedValidSets = new HashSet<AndSet>();
            foreach (var combiSet in combinedSelectSets)
            {
                var isValid = ValidateSelection(combiSet);
                if (isValid) combinedValidSets.Add(combiSet);
            }

            return combinedValidSets;
        }

        public HashSet<HashSet<OrSet>> GetRequirements(AndSet selectedEmpireProperties)
        {
            var result = new HashSet<HashSet<OrSet>>();
            var eps = selectedEmpireProperties.Select(p => AllEmpireProperties[p]);
            foreach (var ep in eps.Where(e => e.Requires.Any()))
            {
                result.Add(ep.Requires);
            }
            return result;
        }

        public HashSet<AndSet> MergeRequirementSets(HashSet<HashSet<AndSet>> remaining)
        {
            var result = new HashSet<AndSet>();
            var first = remaining.First();
            foreach (var ep in first)
            {
                var newRemaining = remaining.Where(r => r != first).ToHashSet();
                if (newRemaining.Count > 0)
                {
                    var subSets = MergeRequirementSets(newRemaining);
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
            return result;
        }

        /// <summary>
        /// Returns all possible selection sets for a single EmpireProperty
        /// </summary>
        /// <param name="remaining"></param>
        /// <returns></returns>
        public HashSet<AndSet> RecurseRequirement(HashSet<OrSet> remaining)
        {
            var result = new HashSet<AndSet>();
            var first = remaining.First();
            foreach (var ep in first)
            {
                //Check if this EP has requirements. If it does, add those to the remaining set
                var prop = AllEmpireProperties[ep];
                if (prop.Requires.Any())
                {
                    remaining.UnionWith(prop.Requires);
                }

                var newRemaining = remaining.Where(r => r != first).ToHashSet();
                if (newRemaining.Count > 0)
                {
                    var subSets = RecurseRequirement(newRemaining);
                    foreach (var sub in subSets)
                    {
                        sub.Add(ep);
                    }
                    result.UnionWith(subSets);
                }
                else
                {

                    result.Add(new AndSet() { ep });
                }
            }
            return result;
        }

        #endregion
    }
}