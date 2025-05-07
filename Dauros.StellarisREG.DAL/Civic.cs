using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
	public abstract class Civic : EmpireProperty
	{
		public static Dictionary<String, Civic> Collection { get; } = new Dictionary<string, Civic>()
		{
            #region Standard
			{
				EPN.C_CutthroatPolitics,
				new StandardCivic(EPN.C_CutthroatPolitics){ }
			},
			{
				EPN.C_EfficientBureaucracy,
				new StandardCivic(EPN.C_EfficientBureaucracy)
			},
			{
				EPN.C_FunctionalArchitecture,
				new StandardCivic(EPN.C_FunctionalArchitecture)
			},
			{
				EPN.C_MiningGuilds,
				new StandardCivic(EPN.C_MiningGuilds)
			},
			{
				EPN.C_AgrarianIdyll,
				new StandardCivic(EPN.C_AgrarianIdyll,
					requirements: new[] { EPN.Pacifist, EPN.PacifistF }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_RelentlessIndustrialists){
						EPN.C_OppressiveAutocracy, EPN.O_PostApocalyptic, EPN.O_Remnants, EPN.O_ShatteredRing, EPN.O_VoidDwellers }
				)
			},
			{
				EPN.C_AristocraticElite,
				new StandardCivic(EPN.C_AristocraticElite,
					requirements: new[] { EPN.A_Oligarchic,EPN.A_Imperial }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_ExaltedPriesthood,EPN.C_MerchantGuilds,EPN.C_Technocracy,EPN.EgalitarianF,EPN.Egalitarian, EPN.O_HardReset }
				)
			},
			{
				EPN.C_BeaconofLiberty,
				new StandardCivic(EPN.C_BeaconofLiberty,
					requirements:new HashSet<OrSet>(){ new OrSet() { EPN.A_Democratic }, new OrSet() { EPN.Egalitarian, EPN.EgalitarianF } },
					prohibitions:new AndSet(){ EPN.Xenophobe,EPN.XenophobeF }
				)
			},
			{
				EPN.C_CitizenService,
				new StandardCivic(EPN.C_CitizenService,
					requirements:new HashSet<OrSet>(){ new OrSet() { EPN.A_Democratic,EPN.A_Oligarchic }, new OrSet() {EPN.Militarist,EPN.MilitaristF } },
					prohibitions:new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.XenophileF, EPN.C_Reanimators }
				)
			},








			{
				EPN.C_Anglers,
				new StandardCivic(EPN.C_Anglers, new [] { EPN.D_Aquatics }.ToOrSet(),
					prohibitions:new AndSet(){ EPN.Gestalt, EPN.AT_Machine, EPN.C_AgrarianIdyll, EPN.A_Corporate, EPN.O_PostApocalyptic, EPN.O_ShatteredRing, EPN.O_VoidDwellers }
					)
			},
			
			{
				EPN.C_BarbaricDespoilers,
				new StandardCivic(EPN.C_BarbaricDespoilers, EPN.D_Apocalypse)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Militarist, EPN.MilitaristF }, new OrSet() {EPN.Authoritarian,EPN.AuthoritarianF,EPN.Xenophobe,EPN.XenophobeF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate,EPN.Xenophile,EPN.XenophileF,EPN.C_FanaticPurifiers,EPN.O_CommonGround }
				}
			},
			
			{
				EPN.C_ByzantineBureaucracy,
				new StandardCivic(EPN.C_ByzantineBureaucracy, EPN.D_Megacorp)
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_CatalyticProcessing,
				new StandardCivic(EPN.C_CatalyticProcessing, EPN.D_Plantoids)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() {EPN.AT_Animal}},
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.O_CalamitousBirth }
				}
			},
			
			{
				EPN.C_CorporateDominion,
				new StandardCivic(EPN.C_CorporateDominion,
					requirements:,
					prohibitions:
				)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Oligarchic  } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.D_Megacorp,EPN.Xenophobe,EPN.XenophobeF }
				}
			},
			{
				EPN.C_CorveeSystem,
				new StandardCivic(EPN.C_CorveeSystem,
					requirements:,
					prohibitions:
				))
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.Egalitarian,EPN.EgalitarianF,EPN.C_FreeHaven }

				}
			},
			
			{
				EPN.C_DeathCult,
				new StandardCivic(EPN.C_DeathCult, EPN.D_Necroids,
					requirements:,
					prohibitions:
				))
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Spiritualist,EPN.SpiritualistF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_InwardPerfection, EPN.C_FanaticPurifiers, EPN.O_Necrophage }
				}
			},
			{
				EPN.C_DiplomaticCorps,
				new StandardCivic(EPN.C_DiplomaticCorps, EPN.D_Megacorp,
					requirements:,
					prohibitions:
				))
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_InwardPerfection,EPN.C_FanaticPurifiers }
				}
			},
			{
				EPN.C_DistinguishedAdmiralty,
				new StandardCivic(EPN.C_DistinguishedAdmiralty,
					requirements:,
					prohibitions:
				))
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Militarist,EPN.MilitaristF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			
			{
				EPN.C_Environmentalist,
				new StandardCivic(EPN.C_Environmentalist,
					requirements:,
					prohibitions:
				))
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_ExaltedPriesthood,
				new StandardCivic(EPN.C_ExaltedPriesthood,
					requirements:,
					prohibitions:
				))
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Oligarchic,EPN.A_Dictatorial },new OrSet() {EPN.Spiritualist,EPN.SpiritualistF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_MerchantGuilds,EPN.C_AristocraticElite,EPN.C_Technocracy }
				}
			},
			{
				EPN.C_FanaticPurifiers,
				new StandardCivic(EPN.C_FanaticPurifiers, EPN.D_Utopia,
					requirements:,
					prohibitions:
				))
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.XenophobeF },new OrSet() { EPN.Militarist,EPN.Spiritualist } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_BarbaricDespoilers,EPN.O_SyncreticEvolution,EPN.O_CommonGround,EPN.O_Hegemon }
				}
			},
			{
				EPN.C_FeudalSociety,
				new StandardCivic(EPN.C_FeudalSociety,
					requirements:,
					prohibitions:
				))
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Imperial } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_FreeHaven,
				new StandardCivic(EPN.C_FreeHaven,
					requirements:,
					prohibitions:
				))
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Xenophile,EPN.XenophileF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_CorveeSystem }
				}
			},
			
			{
				EPN.C_IdealisticFoundation,
				new StandardCivic(EPN.C_IdealisticFoundation,
					requirements:,
					prohibitions:
				))
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Egalitarian,EPN.EgalitarianF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_IdyllicBloom,
				new StandardCivic(EPN.C_IdyllicBloom, EPN.D_Plantoids,
					requirements:,
					prohibitions:
				))
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.AT_Plantoid } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.O_ShatteredRing, EPN.O_VoidDwellers,EPN.O_LifeSeeded, EPN.AT_Lithoid }
				}
			},
			{
				EPN.C_ImperialCult,
				new StandardCivic(EPN.C_ImperialCult,
					requirements:,
					prohibitions:
				))
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_Imperial }, new OrSet(){ EPN.Authoritarian,EPN.AuthoritarianF }, new OrSet() { EPN.Spiritualist, EPN.SpiritualistF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_InwardPerfection,
				new StandardCivic(EPN.C_InwardPerfection,
					requirements:,
					prohibitions:
				))
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Pacifist,EPN.PacifistF }, new OrSet() { EPN.Xenophobe,EPN.XenophobeF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_MasterfulCrafters,
				new StandardCivic(EPN.C_MasterfulCrafters, EPN.D_Humanoids,
					requirements:,
					prohibitions:
				))
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_Memorialists,
				new StandardCivic(EPN.C_Memorialists, EPN.D_Necroids,
					requirements:,
					prohibitions:
				))
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_FanaticPurifiers }
				}
			},
			{
				EPN.C_MerchantGuilds,
				new StandardCivic(EPN.C_MerchantGuilds, EPN.D_Megacorp,
					requirements:,
					prohibitions:
				))
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_ExaltedPriesthood,EPN.C_AristocraticElite,EPN.C_Technocracy }
				}
			},
			{
				EPN.C_Meritocracy,
				new StandardCivic(EPN.C_Meritocracy,
					requirements:,
					prohibitions:
				))
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Democratic,EPN.A_Oligarchic } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			
			{
				EPN.C_NationalisticZeal,
				new StandardCivic(EPN.C_NationalisticZeal,
					requirements:,
					prohibitions:
				))
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Militarist,EPN.MilitaristF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_ParliamentarySystem,
				new StandardCivic(EPN.C_ParliamentarySystem,
					requirements:,
					prohibitions:
				))
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Democratic } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_PhilosopherKing,
				new StandardCivic(EPN.C_PhilosopherKing,
					requirements:,
					prohibitions:
				))
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Dictatorial, EPN.A_Imperial } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_PleasureSeekers,
				new StandardCivic(EPN.C_PleasureSeekers,EPN.D_Humanoids,
					requirements:,
					prohibitions:
				))
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_SlaverGuilds, EPN.C_WarriorCulture,EPN.C_SharedBurdens }
				}
			},
			{
				EPN.C_PoliceState,
				new StandardCivic(EPN.C_PoliceState,
					requirements:,
					prohibitions:
				))
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.EgalitarianF }
				}
			},
			{
				EPN.C_PompousPurists,
				new StandardCivic(EPN.C_PompousPurists,EPN.D_Humanoids)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Xenophobe, EPN.XenophobeF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_InwardPerfection, EPN.C_FanaticPurifiers, EPN.O_Scion }
				}
			},
			{
				EPN.C_Reanimators,
				new StandardCivic(EPN.C_Reanimators, EPN.D_Necroids)
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.Pacifist,EPN.PacifistF,EPN.C_CitizenService }
				}
			},
			{
				EPN.C_ShadowCouncil,
				new StandardCivic(EPN.C_ShadowCouncil)
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.A_Imperial }
				}
			},
			{
				EPN.C_SharedBurdens,
				new StandardCivic(EPN.C_SharedBurdens, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.EgalitarianF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.Xenophobe,EPN.XenophobeF,EPN.C_Technocracy, EPN.C_PleasureSeekers }
				}
			},
			{
				EPN.C_SlaverGuilds,
				new StandardCivic(EPN.C_SlaverGuilds)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Authoritarian, EPN.AuthoritarianF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate,  }
				}
			},
			{
				EPN.C_Technocracy,
				new StandardCivic(EPN.C_Technocracy)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.MaterialistF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_AristocraticElite,EPN.C_ExaltedPriesthood,EPN.C_MerchantGuilds,EPN.C_SharedBurdens }
				}
			},
			{
				EPN.C_WarriorCulture,
				new StandardCivic(EPN.C_WarriorCulture)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Militarist,EPN.MilitaristF  } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_Ascensionists,
				new StandardCivic(EPN.C_Ascensionists, true, EPN.D_Utopia, EPN.D_AstralPlanes)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Spiritualist, EPN.SpiritualistF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_SelectiveKinship,
				new StandardCivic(EPN.C_SelectiveKinship, EPN.D_Lithoids)
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.Xenophile, EPN.XenophileF, EPN.EgalitarianF, EPN.O_BrokenShackles }
				}
			},
			{
				EPN.C_Scavengers,
				new StandardCivic(EPN.C_Scavengers,EPN.D_Toxoids)
				{
					 Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_MutagenicSpas,
				new StandardCivic(EPN.C_MutagenicSpas, EPN.D_Toxoids)
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.O_LifeSeeded }
				}
			},
			{
				EPN.C_RelentlessIndustrialists,
				new StandardCivic(EPN.C_RelentlessIndustrialists, EPN.D_Toxoids)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Materialist, EPN.MaterialistF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_AgrarianIdyll, EPN.C_Environmentalist, EPN.C_IdyllicBloom, EPN.C_Memorialists, EPN.O_LifeSeeded }
				}
			},
			{
				EPN.C_EagerExplorers,
				new StandardCivic(EPN.C_EagerExplorers, EPN.D_FirstContact)
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_InwardPerfection, EPN.C_HyperspaceSpeciality, EPN.C_SovereignGuardianship, EPN.O_BrokenShackles, EPN.O_FearDark, EPN.O_Payback }
				}
			},
			{
				EPN.C_HeroicPast,
				new StandardCivic(EPN.C_HeroicPast, EPN.D_GalParagons)
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_VaultsKnowledge,
				new StandardCivic(EPN.C_VaultsKnowledge, EPN.D_GalParagons)
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_CrusaderSpirit,
				new StandardCivic(EPN.C_CrusaderSpirit, EPN.D_GalParagons)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Authoritarian, EPN.AuthoritarianF, EPN.Militarist, EPN.MilitaristF, EPN.Spiritualist, EPN.SpiritualistF  } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.Pacifist, EPN.PacifistF, EPN.C_BeaconofLiberty, EPN.C_FanaticPurifiers }
				}
			},
			{
				EPN.C_OppressiveAutocracy,
				new StandardCivic(EPN.C_OppressiveAutocracy, EPN.D_GalParagons)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.AuthoritarianF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_AgrarianIdyll, EPN.C_Environmentalist, EPN.C_FreeHaven, EPN.C_WarriorCulture, EPN.C_PleasureSeekers }
				}
			},
			{
				EPN.C_DarkConsortium,
				new StandardCivic(EPN.C_DarkConsortium, EPN.D_AstralPlanes)
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
				}
			},
			{
				EPN.C_DimensionalWorship,
				new StandardCivic(EPN.C_DimensionalWorship, EPN.D_AstralPlanes)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Spiritualist, EPN.SpiritualistF } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_DeathCult }
				}
			},
			{
				EPN.C_HyperspaceSpeciality,
				new StandardCivic(EPN.C_HyperspaceSpeciality, EPN.D_AstralPlanes)
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_EagerExplorers }
				}
			},
			{
				EPN.C_SovereignGuardianship,
				new StandardCivic(EPN.C_SovereignGuardianship, EPN.D_AstralPlanes)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Militarist,EPN.MilitaristF  } },
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.C_InwardPerfection, EPN.C_FanaticPurifiers, EPN.C_Reanimators, EPN.C_EagerExplorers,EPN.O_BrokenShackles, EPN.O_FearDark, EPN.O_Payback }
				}
			},
            #endregion
            #region Corporate
            {
				EPN.C_BrandLoyalty,
				new CorporateCivic(EPN.C_BrandLoyalty, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
				}
			},
			{
				EPN.C_CorporateDeathCult,
				new CorporateCivic(EPN.C_CorporateDeathCult, EPN.D_Megacorp, EPN.D_Necroids)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet() { EPN.Spiritualist, EPN.SpiritualistF } }
				}
			},
			{
				EPN.C_CorporateHedonism,
				new CorporateCivic(EPN.C_CorporateHedonism, EPN.D_Megacorp, EPN.D_Humanoids)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
					Prohibits = new AndSet(){EPN.C_IndenturedAssets }
				}
			},
			{
				EPN.C_CriminalHeritage,
				new CorporateCivic(EPN.C_CriminalHeritage, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
				}
			},
			{
				EPN.C_Franchising,
				new CorporateCivic(EPN.C_Franchising, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
				}
			},
			{
				EPN.C_FreeTraders,
				new CorporateCivic(EPN.C_FreeTraders, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
				}
			},
			{
				EPN.C_GospelMasses,
				new CorporateCivic(EPN.C_GospelMasses, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet() { EPN.Spiritualist,EPN.SpiritualistF } }
				}
			},
			{
				EPN.C_IndenturedAssets,
				new CorporateCivic(EPN.C_IndenturedAssets, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet() { EPN.Authoritarian, EPN.AuthoritarianF } }
				}
			},
			{
				EPN.C_MastercraftInc,
				new CorporateCivic(EPN.C_MastercraftInc, EPN.D_Megacorp, EPN.D_Humanoids)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
				}
			},
			{
				EPN.C_MediaConglomerate,
				new CorporateCivic(EPN.C_MediaConglomerate, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
				}
			},
			{
				EPN.C_NavalContractors,
				new CorporateCivic(EPN.C_NavalContractors, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet() { EPN.Militarist, EPN.MilitaristF } }
				}
			},
			{
				EPN.C_PrivateMilitaryCompanies,
				new CorporateCivic(EPN.C_PrivateMilitaryCompanies, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet() { EPN.Militarist, EPN.MilitaristF } }
				}
			},
			{
				EPN.C_PrivateProspectors,
				new CorporateCivic(EPN.C_PrivateProspectors, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
				}
			},
			{
				EPN.C_PublicRelationsSpecialists,
				new CorporateCivic(EPN.C_PublicRelationsSpecialists, EPN.D_Megacorp, EPN.D_Federations)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
				}
			},
			{
				EPN.C_RuthlessCompetition,
				new CorporateCivic(EPN.C_RuthlessCompetition, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
				}
			},
			{
				EPN.C_WorkerCooperative,
				new CorporateCivic(EPN.C_WorkerCooperative, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet() { EPN.Egalitarian } },
					Prohibits = new AndSet(){ EPN.Xenophobe, EPN.XenophobeF, EPN.C_CorporateHedonism, EPN.C_RuthlessCompetition, EPN.C_CutthroatPolitics, EPN.C_PleasureSeekers, EPN.C_SharedBurdens, EPN.C_PoliceState }
				}
			},
			{
				EPN.C_TradingPosts,
				new CorporateCivic(EPN.C_TradingPosts, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
				}
			},
			{
				EPN.C_CorporateAnglers,
				new CorporateCivic(EPN.C_CorporateAnglers, EPN.D_Aquatics, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
					Prohibits = new AndSet(){ EPN.O_PostApocalyptic, EPN.O_ShatteredRing, EPN.O_VoidDwellers }
				}
			},
			{
				EPN.C_Gigacorp,
				new CorporateCivic(EPN.C_Gigacorp, EPN.D_Utopia, EPN.D_AstralPlanes, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet(){ EPN.Spiritualist, EPN.SpiritualistF } }
				}
			},{
				EPN.C_CatalyticRecyclers,
				new CorporateCivic(EPN.C_CatalyticRecyclers, EPN.D_Aquatics, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
					Prohibits = new AndSet(){ EPN.C_CatalyticProcessing, EPN.O_CalamitousBirth }
				}
			},{
				EPN.C_PermanentEmployment,
				new CorporateCivic(EPN.C_PermanentEmployment, EPN.D_Necroids, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
					Prohibits = new AndSet(){ EPN.Egalitarian, EPN.O_Mechanist, EPN.O_CloneArmy, EPN.O_Necrophage }
				}
			},{
				EPN.C_TrawlingOperations,
				new CorporateCivic(EPN.C_TrawlingOperations, EPN.D_Aquatics, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate }, new OrSet() { EPN.T_Aquatic } },
					Prohibits = new AndSet(){ EPN.C_Anglers, EPN.O_PostApocalyptic, EPN.O_ShatteredRing, EPN.O_VoidDwellers, EPN.O_Subterranean }
				}
			},{
				EPN.C_RefurbishmentDivision,
				new CorporateCivic(EPN.C_RefurbishmentDivision, EPN.D_Toxoids, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
					Prohibits = new AndSet(){ EPN.C_Scavengers }
				}
			},{
				EPN.C_PrivatizedExploration,
				new CorporateCivic(EPN.C_PrivatizedExploration, EPN.D_FirstContact, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
					Prohibits = new AndSet(){ EPN.C_CorporateProtectorate, EPN.C_HyperspaceTrade, EPN.C_HyperspaceSpeciality, EPN.O_BrokenShackles, EPN.O_FearDark, EPN.O_Payback }
				}
			},{
				EPN.C_PrecisionCogs,
				new CorporateCivic(EPN.C_PrecisionCogs, EPN.D_GalParagons, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } }
				}
			},{
				EPN.C_KnowledgeMentorship,
				new CorporateCivic(EPN.C_KnowledgeMentorship, EPN.D_GalParagons, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
					Prohibits = new AndSet(){ EPN.C_VaultsKnowledge }
				}
			},{
				EPN.C_LetterMarque,
				new CorporateCivic(EPN.C_LetterMarque, EPN.D_GalParagons, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate },new OrSet() { EPN.Authoritarian, EPN.Militarist, EPN.MilitaristF } },
					Prohibits = new AndSet(){ EPN.O_PostApocalyptic, EPN.O_ShatteredRing, EPN.O_VoidDwellers }
				}
			},{
				EPN.C_PharmaState,
				new CorporateCivic(EPN.C_PharmaState, EPN.D_GalParagons, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
					Prohibits = new AndSet(){ EPN.O_BrokenShackles, EPN.O_Payback }
				}
			},{
				EPN.C_CorporateProtectorate,
				new CorporateCivic(EPN.C_CorporateProtectorate, EPN.D_AstralPlanes, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate },new OrSet() { EPN.Militarist, EPN.MilitaristF } },
					Prohibits = new AndSet(){ EPN.C_PrivatizedExploration, EPN.C_InwardPerfection, EPN.C_SovereignGuardianship, EPN.C_Reanimators,EPN.C_EagerExplorers,EPN.O_BrokenShackles,EPN.O_FearDark,EPN.O_Payback }
				}
			},{
				EPN.C_DimensionalEnterprise,
				new CorporateCivic(EPN.C_DimensionalEnterprise, EPN.D_AstralPlanes, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } ,new OrSet() { EPN.Spiritualist, EPN.SpiritualistF }},
					Prohibits = new AndSet(){ EPN.C_CorporateDeathCult, EPN.C_DeathCult, EPN.C_DimensionalWorship }
				}
			},{
				EPN.C_HyperspaceTrade,
				new CorporateCivic(EPN.C_HyperspaceTrade, EPN.D_AstralPlanes, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
					Prohibits = new AndSet(){ EPN.C_PrivatizedExploration, EPN.C_EagerExplorers, EPN.C_HyperspaceSpeciality  }
				}
			},
			{
				EPN.C_ShadowCorpation,
				new CorporateCivic(EPN.C_ShadowCorpation, EPN.D_AstralPlanes, EPN.D_Megacorp)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_Corporate } },
					Prohibits = new AndSet(){ EPN.C_DarkConsortium }
				}
			},

            #endregion
            #region HiveMind
            {
				EPN.C_Ascetic,
				new HiveMindCivic(EPN.C_Ascetic, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
				}
			},
			{
				EPN.C_DevouringSwarm,
				new HiveMindCivic(EPN.C_DevouringSwarm, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } },
					Prohibits = new AndSet(){ EPN.T_Lithoid }
				}
			},
			{
				EPN.C_DividedAttention,
				new HiveMindCivic(EPN.C_DividedAttention, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
				}
			},
			{
				EPN.C_ElevationalContemplations,
				new HiveMindCivic(EPN.C_ElevationalContemplations, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
				}
			},
			{
				EPN.C_Empath,
				new HiveMindCivic(EPN.C_Empath, EPN.D_Federations, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } },
					Prohibits = new AndSet(){ EPN.C_DevouringSwarm, EPN.C_Terravore, EPN.O_Necrophage }
				}
			},
			{
				EPN.C_IdyllicBloomHM,
                //plantoids & fungoids only
                new HiveMindCivic(EPN.C_IdyllicBloomHM, EPN.D_Plantoids, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } },
					Prohibits = new AndSet(){ EPN.O_ShatteredRing,EPN.O_LifeSeeded, EPN.AT_Lithoid }
				}
			},
			{
				EPN.C_OrganicReprocessingHM,
				new HiveMindCivic(EPN.C_OrganicReprocessingHM, EPN.D_Plantoids, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind}, new OrSet() { EPN.T_Lithoid } },
					Prohibits = new AndSet(){ EPN.O_CalamitousBirth }
				}
			},
			{
				EPN.C_MemorialistHM,
				new HiveMindCivic(EPN.C_MemorialistHM, EPN.D_Utopia, EPN.D_Necroids)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } },
					Prohibits = new AndSet(){ EPN.C_DevouringSwarm, EPN.C_Terravore }
				}
			},
			{
				EPN.C_NaturalNeuralNetwork,
				new HiveMindCivic(EPN.C_NaturalNeuralNetwork, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
				}
			},
			{
				EPN.C_OneMind,
				new HiveMindCivic(EPN.C_OneMind, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
				}
			},
			{
				EPN.C_PooledKnowledge,
				new HiveMindCivic(EPN.C_PooledKnowledge, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
				}
			},
			{
				EPN.C_StrengthofLegions,
				new HiveMindCivic(EPN.C_StrengthofLegions, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
				}
			},
			{
				EPN.C_SubspaceEphapse,
				new HiveMindCivic(EPN.C_SubspaceEphapse, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
				}
			},
			{
				EPN.C_SubsumedWill,
				new HiveMindCivic(EPN.C_SubsumedWill, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
				}
			},
			{
				EPN.C_VoidHive,
				new HiveMindCivic(EPN.C_VoidHive, EPN.D_Lithoids, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind}}
				}
			},
			{
				EPN.C_Terravore,
				new HiveMindCivic(EPN.C_Terravore, EPN.D_Lithoids,EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind}, new OrSet() { EPN.T_Lithoid } },
					Prohibits = new AndSet(){ EPN.C_Empath, EPN.C_MemorialistHM, EPN.C_GuardianCluster }
				}
			},
			{
				EPN.C_CordycepticDrones,
				new HiveMindCivic(EPN.C_CordycepticDrones, EPN.D_Necroids, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind} }
				}
			},
			{
				EPN.C_PermutationPools,
				new HiveMindCivic(EPN.C_PermutationPools, EPN.D_Toxoids, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind} },
					Prohibits = new AndSet(){ EPN.O_LifeSeeded }
				}
			},
			{
				EPN.C_Stargazers,
				new HiveMindCivic(EPN.C_Stargazers, EPN.D_FirstContact, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind} },
					Prohibits = new AndSet(){ EPN.C_HyperspaceSyncHM, EPN.O_BrokenShackles, EPN.O_FearDark, EPN.O_Payback }
				}
			},
			{
				EPN.C_AutonomousDrones,
				new HiveMindCivic(EPN.C_AutonomousDrones, EPN.D_GalParagons, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind} }
				}
			},
			{
				EPN.C_NeuralVaults,
				new HiveMindCivic(EPN.C_NeuralVaults, EPN.D_GalParagons, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind} }
				}
			},
			{
				EPN.C_GuardianCluster,
				new HiveMindCivic(EPN.C_GuardianCluster, EPN.D_AstralPlanes, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind} },
					Prohibits = new AndSet(){ EPN.C_DevouringSwarm, EPN.C_Terravore }
				}
			},
			{
				EPN.C_HyperspaceSyncHM,
				new HiveMindCivic(EPN.C_HyperspaceSyncHM, EPN.D_AstralPlanes, EPN.D_Utopia)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind} },
					Prohibits = new AndSet(){ EPN.C_Stargazers  }
				}
			},
            
            #endregion
            #region Machine Intelligence
            {
				EPN.C_BuiltToLast,
				new MachineIntelligenceCivic(EPN.C_BuiltToLast)
				{
				}
			},{
				EPN.C_Constructobot,
				new MachineIntelligenceCivic(EPN.C_Constructobot)
				{
				}
			},
			{
				EPN.C_DelegatedFunctions,
				new MachineIntelligenceCivic(EPN.C_DelegatedFunctions)
				{
				}
			},
			{
				EPN.C_FactoryOverclocking,
				new MachineIntelligenceCivic(EPN.C_FactoryOverclocking)
				{
				}
			},
			{
				EPN.C_Introspective,
				new MachineIntelligenceCivic(EPN.C_Introspective)
				{
				}
			},
			{
				EPN.C_MaintenanceProtocols,
				new MachineIntelligenceCivic(EPN.C_MaintenanceProtocols)
				{
				}
			},
			{
				EPN.C_OTAUpdates,
				new MachineIntelligenceCivic(EPN.C_OTAUpdates)
				{
				}
			},
			{
				EPN.C_RapidReplicator,
				new MachineIntelligenceCivic(EPN.C_RapidReplicator)
				{
				}
			},
			{
				EPN.C_Rockbreakers,
				new MachineIntelligenceCivic(EPN.C_Rockbreakers)
				{
				}
			},
			{
				EPN.C_StaticResearchAnalysis,
				new MachineIntelligenceCivic(EPN.C_StaticResearchAnalysis)
				{
				}
			},
			{
				EPN.C_UnitaryCohesion,
				new MachineIntelligenceCivic(EPN.C_UnitaryCohesion)
				{
				}
			},
			{
				EPN.C_Warbots,
				new MachineIntelligenceCivic(EPN.C_Warbots)
				{
					Prohibits   = new AndSet(){ EPN.obs }
				}
			},
			{
				EPN.C_ZeroWasteProtocols,
				new MachineIntelligenceCivic(EPN.C_ZeroWasteProtocols)
				{
				}
			},
			{
				EPN.C_ElevationalHypotheses,
				new MachineIntelligenceCivic(EPN.C_ElevationalHypotheses, false, EPN.D_Utopia, EPN.D_AstralPlanes)
				{
				}
			},
			{
				EPN.C_OrganicRetrofitting,
				new MachineIntelligenceCivic(EPN.C_OrganicRetrofitting, true, EPN.D_Plantoids)
				{
					Prohibits = new AndSet(){ EPN.O_ResourceConsolidation  }
				}
			}
			,
			{
				EPN.C_DeterminedExterminator,
				new MachineIntelligenceCivic(EPN.C_DeterminedExterminator)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
					Prohibits = new AndSet(){ EPN.C_DrivenAssimilator,EPN.C_RogueServitor }
				}
			},
			{
				EPN.C_DrivenAssimilator,
				new MachineIntelligenceCivic(EPN.C_DrivenAssimilator)
				{
					Prohibits = new AndSet(){EPN.C_DeterminedExterminator,EPN.C_RogueServitor }
				}
			},

			{
				EPN.C_MemorialistMI,
				new MachineIntelligenceCivic(EPN.C_MemorialistMI, EPN.D_SyntheticDawn,EPN.D_Necroids)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
					Prohibits = new AndSet(){ EPN.C_DeterminedExterminator,EPN.C_DrivenAssimilator }
				}
			},

			{
				EPN.C_RogueServitor,
				new MachineIntelligenceCivic(EPN.C_RogueServitor, EPN.D_SyntheticDawn)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
					Prohibits = new AndSet(){ EPN.C_DeterminedExterminator,EPN.C_DrivenAssimilator }
				}
			},
			
			{
				EPN.C_LubriationTanks,
				new MachineIntelligenceCivic(EPN.C_LubriationTanks,EPN.D_SyntheticDawn, EPN.D_Toxoids)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } }
				}
			}
			,
			{
				EPN.C_ExplorationProtocols,
				new MachineIntelligenceCivic(EPN.C_ExplorationProtocols,EPN.D_SyntheticDawn, EPN.D_FirstContact)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
					Prohibits = new AndSet(){ EPN.C_DeterminedExterminator, EPN.C_DrivenAssimilator, EPN.C_HyperspaceSyncMI  }
				}
			}
			,
			{
				EPN.C_XPCache,
				new MachineIntelligenceCivic(EPN.C_XPCache,EPN.D_SyntheticDawn, EPN.D_GalParagons)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } }
				}
			}
			,
			{
				EPN.C_SovereignCircuits,
				new MachineIntelligenceCivic(EPN.C_SovereignCircuits, EPN.D_SyntheticDawn, EPN.D_GalParagons)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } }
				}
			},
			{
				EPN.C_GuardianMatrix,
				new MachineIntelligenceCivic(EPN.C_GuardianMatrix, EPN.D_SyntheticDawn, EPN.D_AstralPlanes)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
					Prohibits = new AndSet(){ EPN.C_DeterminedExterminator }
				}
			},
			{
				EPN.C_HyperspaceSyncMI,
				new MachineIntelligenceCivic(EPN.C_HyperspaceSyncMI, EPN.D_SyntheticDawn, EPN.D_AstralPlanes)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
					Prohibits = new AndSet(){ EPN.C_ExplorationProtocols }
				}
			}
            #endregion
        };

		public Civic(String name, HashSet<OrSet>? dlc = null, 
			HashSet<OrSet>? requirements = null, AndSet? prohibitions = null) 
			: base(name, EmpirePropertyType.Civic, dlc, requirements, prohibitions) { }
	}

	/// <summary>
	/// Standard civics are the most common type of civic. They prohibit Gestalt and Corporate Authority
	/// </summary>
	public sealed class StandardCivic : Civic
	{
		public StandardCivic(String name, HashSet<OrSet>? dlc = null,
			HashSet<OrSet>? requirements = null, AndSet? prohibitions = null)
			: base(name, dlc, requirements, prohibitions) 
		{
			Prohibits = new AndSet() { EPN.Gestalt, EPN.A_Corporate };
		}
		
	}

	/// <summary>
	/// Corporate civics are only available to Corporate Authority empires.
	/// </summary>
	public sealed class CorporateCivic : Civic
	{
		public CorporateCivic(String name, HashSet<OrSet>? dlc = null,
			HashSet<OrSet>? requirements = null, AndSet? prohibitions = null)
			: base(name, dlc, requirements, prohibitions)
		{
			DLC = new[] { EPN.D_Megacorp }.ToOrSet();
			Requires = new[] { EPN.A_Corporate }.ToOrSet() ;
		}
	}

	/// <summary>
	/// Hive Mind civics are only available to Hive Mind empires.
	/// </summary>
	public sealed class HiveMindCivic : Civic
	{
		public HiveMindCivic(String name, HashSet<OrSet>? dlc = null,
			HashSet<OrSet>? requirements = null, AndSet? prohibitions = null)
			: base(name, dlc, requirements, prohibitions)
		{
			Requires = new[] { EPN.A_HiveMind }.ToOrSet() ;
		}
	}

	public sealed class MachineIntelligenceCivic : Civic
	{
		public MachineIntelligenceCivic(String name, HashSet<OrSet>? dlc = null,
			HashSet<OrSet>? requirements = null, AndSet? prohibitions = null)
			: base(name, dlc, requirements, prohibitions)
		{
			Requires = new[]{ EPN.A_MachineIntelligence }.ToOrSet();
			DLC = new[] { EPN.D_SyntheticDawn,EPN.D_MachineAge }.ToOrSet();
		}
	}
}