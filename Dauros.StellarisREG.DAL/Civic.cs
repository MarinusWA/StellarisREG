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
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.O_PostApocalyptic, EPN.O_ShatteredRing, EPN.O_VoidDwellers, EPN.O_Remnants, EPN.C_Anglers }
                }
            },
            {
                EPN.C_Anglers,
                new Civic(EPN.C_Anglers, EPN.D_Aquatics)
                {
                    Prohibits = new AndSet(){ EPN.C_AgrarianIdyll, EPN.A_Corporate, EPN.O_PostApocalyptic, EPN.O_ShatteredRing, EPN.O_VoidDwellers }
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
                EPN.C_BarbaricDespoilers,
                new Civic(EPN.C_BarbaricDespoilers, EPN.D_Apocalypse)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Militarist, EPN.MilitaristF }, new OrSet() {EPN.Authoritarian,EPN.AuthoritarianF,EPN.Xenophobe,EPN.XenophobeF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate,EPN.Xenophile,EPN.XenophileF,EPN.C_FanaticPurifiers,EPN.O_CommonGround }
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
                EPN.C_ByzantineBureaucracy,
                new Civic(EPN.C_ByzantineBureaucracy, EPN.D_Megacorp)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_CatalyticProcessing,
                new Civic(EPN.C_CatalyticProcessing, EPN.D_Plantoids)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() {EPN.AT_Animal}},
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.O_CalamitousBirth }
                }
            },
            {
                EPN.C_CitizenService,
                new Civic(EPN.C_CitizenService)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Democratic,EPN.A_Oligarchic }, new OrSet() {EPN.Militarist,EPN.MilitaristF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.XenophileF, EPN.C_Reanimators }
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
                EPN.C_DeathCult,
                new Civic(EPN.C_DeathCult, EPN.D_Necroids)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Spiritualist,EPN.SpiritualistF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_InwardPerfection, EPN.C_FanaticPurifiers, EPN.O_Necrophage }
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
                EPN.C_FanaticPurifiers,
                new Civic(EPN.C_FanaticPurifiers, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.XenophobeF },new OrSet() { EPN.Militarist,EPN.Spiritualist } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_BarbaricDespoilers,EPN.O_SyncreticEvolution,EPN.O_CommonGround,EPN.O_Hegemon }
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
                EPN.C_IdyllicBloom,
                new Civic(EPN.C_IdyllicBloom, EPN.D_Plantoids)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.AT_Plantoid } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.O_ShatteredRing, EPN.O_VoidDwellers,EPN.O_LifeSeeded, EPN.AT_Lithoid }
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
                EPN.C_MasterfulCrafters,
                new Civic(EPN.C_MasterfulCrafters, EPN.D_Humanoids)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
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
                EPN.C_MerchantGuilds,
                new Civic(EPN.C_MerchantGuilds, EPN.D_Megacorp)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_ExaltedPriesthood,EPN.C_AristocraticElite,EPN.C_Technocracy }
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
                EPN.C_PleasureSeekers,
                new Civic(EPN.C_PleasureSeekers,EPN.D_Humanoids)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_SlaverGuilds, EPN.C_WarriorCulture,EPN.C_SharedBurdens }
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
                EPN.C_PompousPurists,
                new Civic(EPN.C_PompousPurists,EPN.D_Humanoids)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Xenophobe, EPN.XenophobeF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_InwardPerfection, EPN.C_FanaticPurifiers, EPN.O_Scion }
                }
            },
            {
                EPN.C_Reanimators,
                new Civic(EPN.C_Reanimators, EPN.D_Necroids)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.Pacifist,EPN.PacifistF,EPN.C_CitizenService }
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
                EPN.C_SharedBurdens,
                new Civic(EPN.C_SharedBurdens, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.EgalitarianF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.Xenophobe,EPN.XenophobeF,EPN.C_Technocracy, EPN.C_PleasureSeekers }
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
                EPN.C_Ascensionists,
                new Civic(EPN.C_Ascensionists, true, EPN.D_Utopia, EPN.D_AstralPlanes)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Spiritualist, EPN.SpiritualistF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_SelectiveKinship,
                new Civic(EPN.C_SelectiveKinship, EPN.D_Lithoids)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.Xenophile, EPN.XenophileF, EPN.EgalitarianF, EPN.O_BrokenShackles }
                }
            },
            {
                EPN.C_Scavengers,
                new Civic(EPN.C_Scavengers,EPN.D_Toxoids)
                {
                     Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_MutagenicSpas,
                new Civic(EPN.C_MutagenicSpas, EPN.D_Toxoids)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.O_LifeSeeded }
                }
            },
            {
                EPN.C_RelentlessIndustrialists,
                new Civic(EPN.C_RelentlessIndustrialists, EPN.D_Toxoids)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Materialist, EPN.MaterialistF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_AgrarianIdyll, EPN.C_Environmentalist, EPN.C_IdyllicBloom, EPN.C_Memorialists, EPN.O_LifeSeeded }
                }
            },
            {
                EPN.C_EagerExplorers,
                new Civic(EPN.C_EagerExplorers, EPN.D_FirstContact)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_InwardPerfection, EPN.C_HyperspaceSpeciality, EPN.C_SovereignGuardianship, EPN.O_BrokenShackles, EPN.O_FearDark, EPN.O_Payback }
                }
            },
            {
                EPN.C_HeroicPast,
                new Civic(EPN.C_HeroicPast, EPN.D_GalParagons)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_VaultsKnowledge,
                new Civic(EPN.C_VaultsKnowledge, EPN.D_GalParagons)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_CrusaderSpirit,
                new Civic(EPN.C_CrusaderSpirit, EPN.D_GalParagons)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Authoritarian, EPN.AuthoritarianF, EPN.Militarist, EPN.MilitaristF, EPN.Spiritualist, EPN.SpiritualistF  } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.Pacifist, EPN.PacifistF, EPN.C_BeaconofLiberty, EPN.C_FanaticPurifiers }
                }
            },
            {
                EPN.C_OppressiveAutocracy,
                new Civic(EPN.C_OppressiveAutocracy, EPN.D_GalParagons)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.AuthoritarianF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_AgrarianIdyll, EPN.C_Environmentalist, EPN.C_FreeHaven, EPN.C_WarriorCulture, EPN.C_PleasureSeekers }
                }
            },
            {
                EPN.C_DarkConsortium,
                new Civic(EPN.C_DarkConsortium, EPN.D_AstralPlanes)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            {
                EPN.C_DimensionalWorship,
                new Civic(EPN.C_DimensionalWorship, EPN.D_AstralPlanes)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Spiritualist, EPN.SpiritualistF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_DeathCult }
                }
            },
            {
                EPN.C_HyperspaceSpeciality,
                new Civic(EPN.C_HyperspaceSpeciality, EPN.D_AstralPlanes)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_EagerExplorers }
                }
            },
            {
                EPN.C_SovereignGuardianship,
                new Civic(EPN.C_SovereignGuardianship, EPN.D_AstralPlanes)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Militarist,EPN.MilitaristF  } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_InwardPerfection, EPN.C_FanaticPurifiers, EPN.C_Reanimators, EPN.C_EagerExplorers,EPN.O_BrokenShackles, EPN.O_FearDark, EPN.O_Payback }
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
                EPN.C_CorporateDeathCult,
                new Civic(EPN.C_CorporateDeathCult, EPN.D_Megacorp, EPN.D_Necroids)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet() { EPN.Spiritualist, EPN.SpiritualistF } }
                }
            },
            {
                EPN.C_CorporateHedonism,
                new Civic(EPN.C_CorporateHedonism, EPN.D_Megacorp, EPN.D_Humanoids)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
                    Prohibits = new AndSet(){EPN.C_IndenturedAssets }
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
                EPN.C_MastercraftInc,
                new Civic(EPN.C_MastercraftInc, EPN.D_Megacorp, EPN.D_Humanoids)
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
                EPN.C_PrivateProspectors,
                new Civic(EPN.C_PrivateProspectors, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
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
                EPN.C_RuthlessCompetition,
                new Civic(EPN.C_RuthlessCompetition, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
                }
            },
            {
                EPN.C_WorkerCooperative,
                new Civic(EPN.C_WorkerCooperative, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet() { EPN.Egalitarian } },
                    Prohibits = new AndSet(){ EPN.Xenophobe, EPN.XenophobeF, EPN.C_CorporateHedonism, EPN.C_RuthlessCompetition, EPN.C_CutthroatPolitics, EPN.C_PleasureSeekers, EPN.C_SharedBurdens, EPN.C_PoliceState }
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
                EPN.C_CorporateAnglers,
                new Civic(EPN.C_CorporateAnglers, EPN.D_Aquatics, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
                    Prohibits = new AndSet(){ EPN.O_PostApocalyptic, EPN.O_ShatteredRing, EPN.O_VoidDwellers }
                }
            },
            {
                EPN.C_Gigacorp,
                new Civic(EPN.C_Gigacorp, EPN.D_Utopia, EPN.D_AstralPlanes, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet(){ EPN.Spiritualist, EPN.SpiritualistF } }
                }
            },{
                EPN.C_CatalyticRecyclers,
                new Civic(EPN.C_CatalyticRecyclers, EPN.D_Aquatics, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
                    Prohibits = new AndSet(){ EPN.C_CatalyticProcessing, EPN.O_CalamitousBirth }
                }
            },{
                EPN.C_PermanentEmployment,
                new Civic(EPN.C_PermanentEmployment, EPN.D_Necroids, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
                    Prohibits = new AndSet(){ EPN.Egalitarian, EPN.O_Mechanist, EPN.O_CloneArmy, EPN.O_Necrophage }
                }
            },{
                EPN.C_TrawlingOperations,
                new Civic(EPN.C_TrawlingOperations, EPN.D_Aquatics, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet() { EPN.T_Aquatic } },
                    Prohibits = new AndSet(){ EPN.C_Anglers, EPN.O_PostApocalyptic, EPN.O_ShatteredRing, EPN.O_VoidDwellers, EPN.O_Subterranean }
                }
            },{
                EPN.C_RefurbishmentDivision,
                new Civic(EPN.C_RefurbishmentDivision, EPN.D_Toxoids, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
                    Prohibits = new AndSet(){ EPN.C_Scavengers }
                }
            },{
                EPN.C_PrivatizedExploration,
                new Civic(EPN.C_PrivatizedExploration, EPN.D_FirstContact, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
                    Prohibits = new AndSet(){ EPN.C_CorporateProtectorate, EPN.C_HyperspaceTrade, EPN.C_HyperspaceSpeciality, EPN.O_BrokenShackles, EPN.O_FearDark, EPN.O_Payback }
                }
            },{
                EPN.C_PrecisionCogs,
                new Civic(EPN.C_PrecisionCogs, EPN.D_GalParagons, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
                }
            },{
                EPN.C_KnowledgeMentorship,
                new Civic(EPN.C_KnowledgeMentorship, EPN.D_GalParagons, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
                    Prohibits = new AndSet(){ EPN.C_VaultsKnowledge }
                }
            },{
                EPN.C_LetterMarque,
                new Civic(EPN.C_LetterMarque, EPN.D_GalParagons, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate },new OrSet() { EPN.Authoritarian, EPN.Militarist, EPN.MilitaristF } },
                    Prohibits = new AndSet(){ EPN.O_PostApocalyptic, EPN.O_ShatteredRing, EPN.O_VoidDwellers }
                }
            },{
                EPN.C_PharmaState,
                new Civic(EPN.C_PharmaState, EPN.D_GalParagons, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
                    Prohibits = new AndSet(){ EPN.O_BrokenShackles, EPN.O_Payback }
                }
            },{
                EPN.C_CorporateProtectorate,
                new Civic(EPN.C_CorporateProtectorate, EPN.D_AstralPlanes, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate },new OrSet() { EPN.Militarist, EPN.MilitaristF } },
                    Prohibits = new AndSet(){ EPN.C_PrivatizedExploration, EPN.C_InwardPerfection, EPN.C_SovereignGuardianship, EPN.C_Reanimators,EPN.C_EagerExplorers,EPN.O_BrokenShackles,EPN.O_FearDark,EPN.O_Payback }
                }
            },{
                EPN.C_DimensionalEnterprise,
                new Civic(EPN.C_DimensionalEnterprise, EPN.D_AstralPlanes, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } ,new OrSet() { EPN.Spiritualist, EPN.SpiritualistF }},
                    Prohibits = new AndSet(){ EPN.C_CorporateDeathCult, EPN.C_DeathCult, EPN.C_DimensionalWorship }
                }
            },{
                EPN.C_HyperspaceTrade,
                new Civic(EPN.C_HyperspaceTrade, EPN.D_AstralPlanes, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
                    Prohibits = new AndSet(){ EPN.C_PrivatizedExploration, EPN.C_EagerExplorers, EPN.C_HyperspaceSpeciality  }
                }
            },
            {
                EPN.C_ShadowCorpation,
                new Civic(EPN.C_ShadowCorpation, EPN.D_AstralPlanes, EPN.D_Megacorp)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
                    Prohibits = new AndSet(){ EPN.C_DarkConsortium }
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
                EPN.C_DevouringSwarm,
                new Civic(EPN.C_DevouringSwarm, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } },
                    Prohibits = new AndSet(){ EPN.T_Lithoid }
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
                EPN.C_ElevationalContemplations,
                new Civic(EPN.C_ElevationalContemplations, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_Empath,
                new Civic(EPN.C_Empath, EPN.D_Federations, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } },
                    Prohibits = new AndSet(){ EPN.C_DevouringSwarm, EPN.C_Terravore, EPN.O_Necrophage }
                }
            },
            {
                EPN.C_IdyllicBloomHM,
                //plantoids & fungoids only
                new Civic(EPN.C_IdyllicBloomHM, EPN.D_Plantoids, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } },
                    Prohibits = new AndSet(){ EPN.O_ShatteredRing,EPN.O_LifeSeeded, EPN.AT_Lithoid }
                }
            },
            {
                EPN.C_OrganicReprocessingHM,
                new Civic(EPN.C_OrganicReprocessingHM, EPN.D_Plantoids, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind}, new OrSet() { EPN.T_Lithoid } },
                    Prohibits = new AndSet(){ EPN.O_CalamitousBirth }
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
                EPN.C_VoidHive,
                new Civic(EPN.C_VoidHive, EPN.D_Lithoids, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind}}
                }
            },
            {
                EPN.C_Terravore,
                new Civic(EPN.C_Terravore, EPN.D_Lithoids,EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind}, new OrSet() { EPN.T_Lithoid } },
                    Prohibits = new AndSet(){ EPN.C_Empath, EPN.C_MemorialistHM, EPN.C_GuardianCluster }
                }
            },
            {
                EPN.C_CordycepticDrones,
                new Civic(EPN.C_CordycepticDrones, EPN.D_Necroids, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind} }
                }
            },
            {
                EPN.C_PermutationPools,
                new Civic(EPN.C_PermutationPools, EPN.D_Toxoids, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind} },
                    Prohibits = new AndSet(){ EPN.O_LifeSeeded }
                }
            },
            {
                EPN.C_Stargazers,
                new Civic(EPN.C_Stargazers, EPN.D_FirstContact, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind} },
                    Prohibits = new AndSet(){ EPN.C_HyperspaceSyncHM, EPN.O_BrokenShackles, EPN.O_FearDark, EPN.O_Payback }
                }
            },
            {
                EPN.C_AutonomousDrones,
                new Civic(EPN.C_AutonomousDrones, EPN.D_GalParagons, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind} }
                }
            },
            {
                EPN.C_NeuralVaults,
                new Civic(EPN.C_NeuralVaults, EPN.D_GalParagons, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind} }
                }
            },
            {
                EPN.C_GuardianCluster,
                new Civic(EPN.C_GuardianCluster, EPN.D_AstralPlanes, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind} },
                    Prohibits = new AndSet(){ EPN.C_DevouringSwarm, EPN.C_Terravore }
                }
            },
            {
                EPN.C_HyperspaceSyncHM,
                new Civic(EPN.C_HyperspaceSyncHM, EPN.D_AstralPlanes, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind} },
                    Prohibits = new AndSet(){ EPN.C_Stargazers  }
                }
            },
            
            #endregion
            #region Machine Intelligence
            {
                EPN.C_Constructobot,
                new Civic(EPN.C_Constructobot, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } }
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
                EPN.C_MemorialistMI,
                new Civic(EPN.C_MemorialistMI, EPN.D_SyntheticDawn,EPN.D_Necroids)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.C_DeterminedExterminator,EPN.C_DrivenAssimilator }
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
                EPN.C_RogueServitor,
                new Civic(EPN.C_RogueServitor, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.C_DeterminedExterminator,EPN.C_DrivenAssimilator }
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
                EPN.C_ElevationalHypotheses,
                new Civic(EPN.C_ElevationalHypotheses, EPN.D_SyntheticDawn, EPN.D_Utopia, EPN.D_AstralPlanes)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } }
                }
            }
            ,
            {
                EPN.C_OrganicReprocessingMI,
                new Civic(EPN.C_OrganicReprocessingMI,EPN.D_SyntheticDawn, EPN.D_Plantoids)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.O_ResourceConsolidation  }
                }
            }
            ,
            {
                EPN.C_HyperLube,
                new Civic(EPN.C_HyperLube,EPN.D_SyntheticDawn, EPN.D_Toxoids)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } }
                }
            }
            ,
            {
                EPN.C_ExplorationProtocols,
                new Civic(EPN.C_ExplorationProtocols,EPN.D_SyntheticDawn, EPN.D_FirstContact)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.C_DeterminedExterminator, EPN.C_DrivenAssimilator, EPN.C_HyperspaceSyncMI  }
                }
            }
            ,
            {
                EPN.C_XPCache,
                new Civic(EPN.C_XPCache,EPN.D_SyntheticDawn, EPN.D_GalParagons)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } }
                }
            }
            ,
            {
                EPN.C_SovereignCircuits,
                new Civic(EPN.C_SovereignCircuits, EPN.D_SyntheticDawn, EPN.D_GalParagons)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } }
                }
            },
            {
                EPN.C_GuardianMatrix,
                new Civic(EPN.C_GuardianMatrix, EPN.D_SyntheticDawn, EPN.D_AstralPlanes)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.C_DeterminedExterminator }
                }
            },
            {
                EPN.C_HyperspaceSyncMI,
                new Civic(EPN.C_HyperspaceSyncMI, EPN.D_SyntheticDawn, EPN.D_AstralPlanes)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.C_ExplorationProtocols }
                }
            }
            #endregion
        };

        public Civic(String name, bool inclusiveDLC, params String[] dlc) : base(name, EmpirePropertyType.Civic, inclusiveDLC, dlc) { }
        public Civic(String name, params String[] dlc) : base(name, EmpirePropertyType.Civic, false, dlc) { }
    }
}