using System;
using System.Collections.Generic;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public class Civic : EmpireProperty
    {
        public static Dictionary<String, Civic> Collection { get; } = new Dictionary<string, Civic>()
        {
            #region Standard
            {
                EPN.C_AgrarianIdyll,
                new Civic(EPN.C_AgrarianIdyll)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Pacifist, EPN.PacifistF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.O_PostApocalyptic, EPN.O_ShatteredRing, EPN.O_VoidDwellers }
                }
            },
            {
                EPN.C_AristocraticElite,
                new Civic(EPN.C_AristocraticElite)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Oligarchic,EPN.A_Imperial } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_ExaltedPriesthood,EPN.C_MerchantGuilds,EPN.C_Technocracy,EPN.EgalitarianF,EPN.Egalitarian }
                }
            },
            {
                EPN.C_BeaconofLiberty,
                new Civic(EPN.C_BeaconofLiberty)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Democratic }, new OrSet() { EPN.Egalitarian, EPN.EgalitarianF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.Xenophobe,EPN.XenophobeF }
                }
            },
            {
                EPN.C_CitizenService,
                new Civic(EPN.C_CitizenService)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Democratic,EPN.A_Oligarchic }, new OrSet() {EPN.Militarist,EPN.MilitaristF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.XenophileF, EPN.C_ReanimatedArmies }
                }
            },
            {
                EPN.C_CorporateDominion,
                new Civic(EPN.C_CorporateDominion)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Oligarchic  } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.D_Megacorp,EPN.Xenophobe,EPN.XenophobeF }
                }
            },
            {
                EPN.C_CorveeSystem,
                new Civic(EPN.C_CorveeSystem)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.Egalitarian,EPN.EgalitarianF,EPN.C_FreeHaven }

                }
            },
            {
                EPN.C_CutthroatPolitics,
                new Civic(EPN.C_CutthroatPolitics)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_DistinguishedAdmiralty,
                new Civic(EPN.C_DistinguishedAdmiralty)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Militarist,EPN.MilitaristF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_EfficientBureaucracy,
                new Civic(EPN.C_EfficientBureaucracy)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_Environmentalist,
                new Civic(EPN.C_Environmentalist)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_ExaltedPriesthood,
                new Civic(EPN.C_ExaltedPriesthood)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Oligarchic,EPN.A_Dictatorial },new OrSet() {EPN.Spiritualist,EPN.SpiritualistF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_MerchantGuilds,EPN.C_AristocraticElite,EPN.C_Technocracy }
                }
            },
            {
                EPN.C_FeudalSociety,
                new Civic(EPN.C_FeudalSociety)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Imperial } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_FreeHaven,
                new Civic(EPN.C_FreeHaven)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Xenophile,EPN.XenophileF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_CorveeSystem }
                }
            },
            {
                EPN.C_FunctionalArchitecture,
                new Civic(EPN.C_FunctionalArchitecture)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_IdealisticFoundation,
                new Civic(EPN.C_IdealisticFoundation)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Egalitarian,EPN.EgalitarianF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_ImperialCult,
                new Civic(EPN.C_ImperialCult)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_Imperial }, new OrSet(){ EPN.Authoritarian,EPN.AuthoritarianF }, new OrSet() { EPN.Spiritualist, EPN.SpiritualistF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_InwardPerfection,
                new Civic(EPN.C_InwardPerfection)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Pacifist,EPN.PacifistF }, new OrSet() { EPN.Xenophobe,EPN.XenophobeF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_Meritocracy,
                new Civic(EPN.C_Meritocracy)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Democratic,EPN.A_Oligarchic } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_MiningGuilds,
                new Civic(EPN.C_MiningGuilds)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_NationalisticZeal,
                new Civic(EPN.C_NationalisticZeal)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Militarist,EPN.MilitaristF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_ParliamentarySystem,
                new Civic(EPN.C_ParliamentarySystem)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Democratic } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_PhilosopherKing,
                new Civic(EPN.C_PhilosopherKing)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Dictatorial, EPN.A_Imperial } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_PoliceState,
                new Civic(EPN.C_PoliceState)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.EgalitarianF }
                }
            },
            {
                EPN.C_ShadowCouncil,
                new Civic(EPN.C_ShadowCouncil)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.A_Imperial }
                }
            },
            {
                EPN.C_SlaverGuilds,
                new Civic(EPN.C_SlaverGuilds)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Authoritarian, EPN.AuthoritarianF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate,  }
                }
            },
            {
                EPN.C_Technocracy,
                new Civic(EPN.C_Technocracy)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.MaterialistF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_AristocraticElite,EPN.C_ExaltedPriesthood,EPN.C_MerchantGuilds,EPN.C_SharedBurdens }
                }
            },
            {
                EPN.C_WarriorCulture,
                new Civic(EPN.C_WarriorCulture)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Militarist,EPN.MilitaristF  } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_FanaticPurifiers,
                new Civic(EPN.C_FanaticPurifiers, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.XenophobeF },new OrSet() { EPN.Militarist,EPN.Spiritualist } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_BarbaricDespoilers,EPN.O_SyncreticEvolution,EPN.O_CommonGround,EPN.O_Hegemon }
                }
            },
            {
                EPN.C_BarbaricDespoilers,
                new Civic(EPN.C_BarbaricDespoilers, EPN.D_Apocalypse)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Militarist, EPN.MilitaristF }, new OrSet() {EPN.Authoritarian,EPN.AuthoritarianF,EPN.Xenophobe,EPN.XenophobeF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate,EPN.Xenophile,EPN.XenophileF,EPN.C_FanaticPurifiers,EPN.O_CommonGround }
                }
            },
            {
                EPN.C_ByzantineBureaucracy,
                new Civic(EPN.C_ByzantineBureaucracy, EPN.D_Megacorp)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_MerchantGuilds,
                new Civic(EPN.C_MerchantGuilds, EPN.D_Megacorp)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_ExaltedPriesthood,EPN.C_AristocraticElite,EPN.C_Technocracy }
                }
            },
            {
                EPN.C_SharedBurdens,
                new Civic(EPN.C_SharedBurdens, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.EgalitarianF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.Xenophobe,EPN.XenophobeF,EPN.C_Technocracy }
                }
            },
            {
                EPN.C_DiplomaticCorps,
                new Civic(EPN.C_DiplomaticCorps, EPN.D_Megacorp)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_InwardPerfection,EPN.C_FanaticPurifiers }
                }
            },
            {
                EPN.C_Memorialists,
                new Civic(EPN.C_Memorialists, EPN.D_Necroids)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_FanaticPurifiers }
                }
            },
            {
                EPN.C_ReanimatedArmies,
                new Civic(EPN.C_ReanimatedArmies, EPN.D_Necroids)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.Pacifist,EPN.PacifistF,EPN.C_CitizenService }
                }
            },
            {
                EPN.C_DeathCult,
                new Civic(EPN.C_DeathCult, EPN.D_Necroids)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Spiritualist,EPN.SpiritualistF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_InwardPerfection, EPN.C_FanaticPurifiers, EPN.O_Necrophage }
                }
            },
            #endregion
            #region Corporate
            {
                EPN.C_BrandLoyalty,
                new Civic(EPN.C_BrandLoyalty, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
                }
            },
            {
                EPN.C_CriminalHeritage,
                new Civic(EPN.C_CriminalHeritage, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
                }
            },
            {
                EPN.C_Franchising,
                new Civic(EPN.C_Franchising, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
                }
            },
            {
                EPN.C_FreeTraders,
                new Civic(EPN.C_FreeTraders, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
                }
            },
            {
                EPN.C_MediaConglomerate,
                new Civic(EPN.C_MediaConglomerate, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
                }
            },
            {
                EPN.C_PrivateProspectors,
                new Civic(EPN.C_PrivateProspectors, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
                }
            },
            {
                EPN.C_RuthlessCompetition,
                new Civic(EPN.C_RuthlessCompetition, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
                }
            },
            {
                EPN.C_TradingPosts,
                new Civic(EPN.C_TradingPosts, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
                }
            },
            {
                EPN.C_GospelMasses,
                new Civic(EPN.C_GospelMasses, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet() { EPN.Spiritualist,EPN.SpiritualistF } }
                }
            },
            {
                EPN.C_IndenturedAssets,
                new Civic(EPN.C_IndenturedAssets, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet() { EPN.Authoritarian, EPN.AuthoritarianF } }
                }
            },
            {
                EPN.C_NavalContractors,
                new Civic(EPN.C_NavalContractors, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet() { EPN.Militarist, EPN.MilitaristF } }
                }
            },
            {
                EPN.C_PrivateMilitaryCompanies,
                new Civic(EPN.C_PrivateMilitaryCompanies, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet() { EPN.Militarist, EPN.MilitaristF } }
                }
            },
            {
                EPN.C_PublicRelationsSpecialists,
                new Civic(EPN.C_PublicRelationsSpecialists, EPN.D_Megacorp, EPN.D_Federations)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
                }
            },
            {
                EPN.C_CorporateDeathCult,
                new Civic(EPN.C_CorporateDeathCult, EPN.D_Megacorp, EPN.D_Necroids)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet() { EPN.Spiritualist, EPN.SpiritualistF } }
                }
            },
            #endregion
            #region HiveMind
            {
                EPN.C_Ascetic,
                new Civic(EPN.C_Ascetic, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_DividedAttention,
                new Civic(EPN.C_DividedAttention, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_NaturalNeuralNetwork,
                new Civic(EPN.C_NaturalNeuralNetwork, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_OneMind,
                new Civic(EPN.C_OneMind, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_PooledKnowledge,
                new Civic(EPN.C_PooledKnowledge, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_StrengthofLegions,
                new Civic(EPN.C_StrengthofLegions, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_SubspaceEphapse,
                new Civic(EPN.C_SubspaceEphapse, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_SubsumedWill,
                new Civic(EPN.C_SubsumedWill, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_Empath,
                new Civic(EPN.C_Empath, EPN.D_Federations, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } },
                    Prohibits = new AndSet(){ EPN.C_DevouringSwarm, EPN.C_Terravore }
                }
            },
            {
                EPN.C_DevouringSwarm,
                new Civic(EPN.C_DevouringSwarm, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } },
                    Prohibits = new AndSet(){ EPN.T_Lithoid }
                }
            },
            {
                EPN.C_Terravore,
                new Civic(EPN.C_Terravore, EPN.D_Lithoids,EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind}, new OrSet() { EPN.T_Lithoid } }
                }
            },
            {
                EPN.C_MemorialistHM,
                new Civic(EPN.C_MemorialistHM, EPN.D_Utopia, EPN.D_Necroids)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } },
                    Prohibits = new AndSet(){ EPN.C_DevouringSwarm, EPN.C_Terravore }
                }
            },
            #endregion
            {
                EPN.C_Constructobot,
                new Civic(EPN.C_Constructobot, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                }
            },
            {
                EPN.C_DelegatedFunctions,
                new Civic(EPN.C_DelegatedFunctions, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                }
            },
            {
                EPN.C_FactoryOverclocking,
                new Civic(EPN.C_FactoryOverclocking, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                }
            },
            {
                EPN.C_Introspective,
                new Civic(EPN.C_Introspective, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                }
            },
            {
                EPN.C_MaintenanceProtocols,
                new Civic(EPN.C_MaintenanceProtocols, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                }
            },
            {
                EPN.C_OTAUpdates,
                new Civic(EPN.C_OTAUpdates, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                }
            },
            {
                EPN.C_RapidReplicator,
                new Civic(EPN.C_RapidReplicator, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                }
            },
            {
                EPN.C_Rockbreakers,
                new Civic(EPN.C_Rockbreakers, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                }
            },
            {
                EPN.C_StaticResearchAnalysis,
                new Civic(EPN.C_StaticResearchAnalysis, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                }
            },
            {
                EPN.C_UnitaryCohesion,
                new Civic(EPN.C_UnitaryCohesion, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                }
            },
            {
                EPN.C_Warbots,
                new Civic(EPN.C_Warbots, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                }
            },
            {
                EPN.C_ZeroWasteProtocols,
                new Civic(EPN.C_ZeroWasteProtocols, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                }
            },
            {
                EPN.C_DeterminedExterminator,
                new Civic(EPN.C_DeterminedExterminator, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.C_DrivenAssimilator,EPN.C_RogueServitor }
                }
            },
            {
                EPN.C_DrivenAssimilator,
                new Civic(EPN.C_DrivenAssimilator, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){EPN.C_DeterminedExterminator,EPN.C_RogueServitor }
                }
            },
            {
                EPN.C_RogueServitor,
                new Civic(EPN.C_RogueServitor, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.C_DeterminedExterminator,EPN.C_DrivenAssimilator }
                }
            },
            {
                EPN.C_MemorialistMI,
                new Civic(EPN.C_MemorialistMI, EPN.D_SyntheticDawn,EPN.D_Necroids)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.C_DeterminedExterminator,EPN.C_DrivenAssimilator }
                }
            }
        };

        public Civic(String name, params String[] dlc) : base(name, EmpirePropertyType.Civic, dlc) { }
    }
}