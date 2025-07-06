using Dauros.StellarisREG.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
	public abstract class Civic : EmpireProperty
	{
		public static Dictionary<String, Civic> Collection { get; } = new Dictionary<string, Civic>()
		{
			#region Standard
			#region BaseGame
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
				EPN.C_CorporateDominion,
				new StandardCivic(EPN.C_CorporateDominion,
					requirements: new[]{ EPN.A_Oligarchic  }.ToOrSet(),
					prohibitions:new AndSet(){ EPN.D_Megacorp,EPN.Xenophobe,EPN.XenophobeF }
				)
			},
			{
				EPN.C_CorveeSystem,
				new StandardCivic(EPN.C_CorveeSystem,
					prohibitions:new AndSet(){ EPN.Egalitarian,EPN.EgalitarianF,EPN.C_FreeHaven, EPN.C_OppressiveAutocracy }
				)
			},
			{
				EPN.C_DistinguishedAdmiralty,
				new StandardCivic(EPN.C_DistinguishedAdmiralty,
					requirements: new[] { EPN.Militarist, EPN.MilitaristF }.ToOrSet()
				)
			},
			{
				EPN.C_Environmentalist,
				new StandardCivic(EPN.C_Environmentalist,
					prohibitions: new AndSet(EPNSET.HS_RelentlessIndustrialists
						.Union<string>(EPNSET.HS_Planetscapers)) { EPN.C_OppressiveAutocracy }
				)
			},
			{
				EPN.C_ExaltedPriesthood,
				new StandardCivic(EPN.C_ExaltedPriesthood,
					requirements: new HashSet<OrSet>() { new OrSet() { EPN.A_Oligarchic, EPN.A_Dictatorial }, new OrSet() { EPN.Spiritualist, EPN.SpiritualistF } },
					prohibitions: new AndSet() { EPN.C_MerchantGuilds, EPN.C_AristocraticElite, EPN.C_Technocracy }
				)
			},
			{
				EPN.C_FeudalSociety,
				new StandardCivic(EPN.C_FeudalSociety,
					requirements: new[] { EPN.A_Imperial }.ToOrSet()
				)
			},
			{
				EPN.C_FreeHaven,
				new StandardCivic(EPN.C_FreeHaven,
					requirements: new[] { EPN.Xenophile, EPN.XenophileF }.ToOrSet(),
					prohibitions: new AndSet() { EPN.C_CorveeSystem }
				)
			},
			{
				EPN.C_IdealisticFoundation,
				new StandardCivic(EPN.C_IdealisticFoundation,
					requirements: new[] { EPN.Egalitarian, EPN.EgalitarianF }.ToOrSet()
				)
			},
			{
				EPN.C_ImperialCult,
				new StandardCivic(EPN.C_ImperialCult,
					requirements:new HashSet<OrSet>(){new OrSet(){ EPN.A_Imperial }, 
						new OrSet(){ EPN.Authoritarian,EPN.AuthoritarianF }, new OrSet() { EPN.Spiritualist, EPN.SpiritualistF } }
				)
			},
			{
				EPN.C_Meritocracy,
				new StandardCivic(EPN.C_Meritocracy,
					requirements: new[] { EPN.A_Democratic, EPN.A_Oligarchic }.ToOrSet()
				)
			},
			{
				EPN.C_NationalisticZeal,
				new StandardCivic(EPN.C_NationalisticZeal,
					requirements: new[] { EPN.Militarist, EPN.MilitaristF }.ToOrSet()
				)
			},
			{
				EPN.C_ParliamentarySystem,
				new StandardCivic(EPN.C_ParliamentarySystem,
					requirements: new[] { EPN.A_Democratic }.ToOrSet(),
					prohibitions: new AndSet() { EPN.C_Crowdsourcing, EPN.O_HardReset }
				)
			},
			{
				EPN.C_PhilosopherKing,
				new StandardCivic(EPN.C_PhilosopherKing,
					requirements: new[] { EPN.A_Dictatorial, EPN.A_Imperial }.ToOrSet()
				)
			},
			{
				EPN.C_PoliceState,
				new StandardCivic(EPN.C_PoliceState,
					prohibitions: new AndSet() { EPN.C_CivilEducation, EPN.EgalitarianF }
				)
			},
			{
				EPN.C_ShadowCouncil,
				new StandardCivic(EPN.C_ShadowCouncil,
					prohibitions: new AndSet() { EPN.A_Imperial }
				)
			},
			{
				EPN.C_SlaverGuilds,
				new StandardCivic(EPN.C_SlaverGuilds,
					requirements: new[] { EPN.Authoritarian, EPN.AuthoritarianF }.ToOrSet(),
					prohibitions: new AndSet() { EPN.C_PleasureSeekers, EPN.O_Payback }
				)
			},
			{
				EPN.C_Technocracy,
				new StandardCivic(EPN.C_Technocracy,
					requirements: new[] { EPN.MaterialistF }.ToOrSet(),
					prohibitions: new AndSet() { EPN.C_AristocraticElite, EPN.C_ExaltedPriesthood, EPN.C_MerchantGuilds, EPN.C_SharedBurdens }
				)
			},
			{
				EPN.C_WarriorCulture,
				new StandardCivic(EPN.C_WarriorCulture,
					requirements: new[] { EPN.Militarist, EPN.MilitaristF }.ToOrSet()
				)
			},
			#endregion
			#region DLC
			{
				EPN.C_Ascensionists,
				new StandardCivic(EPN.C_Ascensionists,
					dlc: new[] { EPN.D_Utopia, EPN.D_AstralPlanes }.ToOrSet(),
					requirements: new[] { EPN.Spiritualist, EPN.SpiritualistF }.ToOrSet()
				)
			},
			{
				EPN.C_CatalyticProcessing,
				new StandardCivic(EPN.C_CatalyticProcessing,
					dlc: new[] {EPN.D_Plantoids }.ToOrSet(),
					prohibitions:new AndSet(){ EPN.O_CalamitousBirth }
				)
			},
			{
				EPN.C_MasterfulCrafters,
				new StandardCivic(EPN.C_MasterfulCrafters,
					dlc: new[] { EPN.D_Humanoids }.ToOrSet()
				)
			},
			{
				EPN.C_PleasureSeekers,
				new StandardCivic(EPN.C_PleasureSeekers,
					dlc: new[] { EPN.D_Humanoids }.ToOrSet(),
					prohibitions: new AndSet() { EPN.C_SlaverGuilds, EPN.C_WarriorCulture, EPN.C_SharedBurdens, EPN.O_HardReset }
				)
			},
			{
				EPN.C_PompousPurists,
				new StandardCivic(EPN.C_PompousPurists,
					dlc: new[] { EPN.D_Humanoids }.ToOrSet(),
					requirements: new[] { EPN.Xenophobe, EPN.XenophobeF }.ToOrSet(),
					prohibitions: new AndSet() { EPN.C_InwardPerfection, EPN.C_FanaticPurifiers, EPN.O_Scion, EPN.O_Payback }
				)
			},
			{
				EPN.C_ByzantineBureaucracy,
				new StandardCivic(EPN.C_ByzantineBureaucracy,
					dlc: new[] { EPN.D_Megacorp }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.Spiritualist, EPN.SpiritualistF }
				)
			},
			{
				EPN.C_MerchantGuilds,
				new StandardCivic(EPN.C_MerchantGuilds,
					dlc: new[] { EPN.D_Megacorp }.ToOrSet(),
					prohibitions: new AndSet() { EPN.C_ExaltedPriesthood, EPN.C_AristocraticElite, EPN.C_Technocracy }
				)
			},
			{
				EPN.C_SharedBurdens,
				new StandardCivic(EPN.C_SharedBurdens,
					dlc: new[] { EPN.D_Megacorp }.ToOrSet(),
					requirements: new[] { EPN.EgalitarianF }.ToOrSet(),
					prohibitions: new AndSet() { EPN.Xenophobe, EPN.XenophobeF, EPN.C_Technocracy, EPN.C_PleasureSeekers }
				)
			},
			{
				EPN.C_SelectiveKinship,
				new StandardCivic(EPN.C_SelectiveKinship,
					dlc: new[] { EPN.D_Lithoids }.ToOrSet(),
					prohibitions: new AndSet() { EPN.Xenophile, EPN.XenophileF, EPN.EgalitarianF, EPN.O_BrokenShackles, EPN.C_FanaticPurifiers, EPN.PH_Machine }
				)
			},
			{
				EPN.C_DiplomaticCorps,
				new StandardCivic(EPN.C_DiplomaticCorps,
					dlc: new[] { EPN.D_Federations }.ToOrSet(),
					prohibitions:new AndSet(){  EPN.C_InwardPerfection,EPN.C_FanaticPurifiers }
				)
			},
			{
				EPN.C_DeathCult,
				new StandardCivic(EPN.C_DeathCult,
					dlc: new[] { EPN.D_Necroids }.ToOrSet(),
					requirements: new[]{ EPN.Spiritualist,EPN.SpiritualistF }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_DimensionalWorship){ EPN.C_InwardPerfection, EPN.C_FanaticPurifiers, EPN.O_Necrophage, EPN.O_CyberneticCreed }
				)
			},
			{
				EPN.C_Memorialists,
				new StandardCivic(EPN.C_Memorialists,
					dlc: new[] { EPN.D_Necroids }.ToOrSet(),
					prohibitions:new AndSet(){ EPN.C_FanaticPurifiers }
				)
			},
			{
				EPN.C_Reanimators,
				new StandardCivic(EPN.C_Reanimators,
					dlc: new[] { EPN.D_Necroids }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_SovereignGuardianship)
					{EPN.Pacifist, EPN.PacifistF, EPN.C_CitizenService, EPN.O_SyntheticFertility, EPN.PH_Machine }
				)
			},
			{
				EPN.C_MutagenicSpas,
				new StandardCivic(EPN.C_MutagenicSpas, 
					dlc: new[] { EPN.D_Toxoids }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_Planetscapers){ EPN.PH_Machine, EPN.O_LifeSeeded, EPN.O_SyntheticFertility }
				)
			},
			{
				EPN.C_LubricationTanks,
				new StandardCivic(EPN.C_LubricationTanks,
					dlc: new[] { EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.PH_Machine }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_Planetscapers){EPN.A_MachineIntelligence, EPN.O_LifeSeeded, EPN.O_SyntheticFertility }
				)
			},
			{
				EPN.C_RelentlessIndustrialists,
				new StandardCivic(EPN.C_RelentlessIndustrialists,
					dlc: new[] { EPN.D_Toxoids }.ToOrSet(),
					requirements:new[]{ EPN.Materialist, EPN.MaterialistF }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_AgrarianIdyll, EPN.C_Environmentalist, EPN.C_IdyllicBloom, EPN.C_Memorialists, EPN.O_LifeSeeded }
				)
			},
			{
				EPN.C_Scavengers,
				new StandardCivic(EPN.C_Scavengers,
					dlc: new[] { EPN.D_Toxoids }.ToOrSet()
				)
			},
			{
				EPN.C_EagerExplorers,
				new StandardCivic(EPN.C_EagerExplorers,
					dlc: new[] { EPN.D_FirstContact }.ToOrSet(),
					prohibitions:new AndSet(EPNSET.HS_SovereignGuardianship
						.Union<string>(EPNSET.HS_HyperspaceSpeciality)
						.Union<string>(EPNSET.HS_GenesisGuides)
						.Union<string>(EPNSET.HS_Beastmasters))
					{ EPN.C_InwardPerfection,EPN.O_BrokenShackles, EPN.O_FearDark, EPN.O_Payback, EPN.O_SyntheticFertility }
				)
			},
			{
				EPN.C_CrusaderSpirit,
				new StandardCivic(EPN.C_CrusaderSpirit,
					dlc: new[] { EPN.D_GalParagons }.ToOrSet(),
					requirements: new[]{ EPN.Authoritarian, EPN.AuthoritarianF, EPN.Militarist, EPN.MilitaristF, EPN.Spiritualist, EPN.SpiritualistF }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.Pacifist, EPN.PacifistF, EPN.C_BeaconofLiberty, EPN.C_FanaticPurifiers }
				)
			},
			{
				EPN.C_HeroicPast,
				new StandardCivic(EPN.C_HeroicPast,
					dlc: new[] { EPN.D_GalParagons }.ToOrSet(),
					prohibitions: new AndSet() { EPN.C_HeroicPast }
				)
			},
			{
				EPN.C_VaultsKnowledge,
				new StandardCivic(EPN.C_VaultsKnowledge,
					dlc: new[] { EPN.D_GalParagons }.ToOrSet()
				)
			},
			{
				EPN.C_DimensionalWorship,
				new StandardCivic(EPN.C_DimensionalWorship,
					dlc: new[] { EPN.D_AstralPlanes }.ToOrSet(),
					requirements: new[] { EPN.Spiritualist, EPN.SpiritualistF }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_DeathCult) { }
				)
			},
			{
				EPN.C_DarkConsortium,
				new StandardCivic(EPN.C_DarkConsortium,
					dlc: new[] { EPN.D_AstralPlanes }.ToOrSet(),
					prohibitions: new AndSet() { EPN.O_HardReset }
				)
			},
			{
				EPN.C_HyperspaceSpeciality,
				new StandardCivic(EPN.C_HyperspaceSpeciality,
					dlc: new[] { EPN.D_AstralPlanes }.ToOrSet(),
					prohibitions: new AndSet(){  EPN.C_EagerExplorers }
				)
			},
			{
				EPN.C_GenesisGuides,
				new StandardCivic(EPN.C_GenesisGuides,
					dlc: new[] { EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_EagerExplorers)
					{ EPN.Xenophobe,EPN.XenophobeF, EPN.C_NaturalDesign,EPN.O_SyncreticEvolution, EPN.O_HardReset, EPN.O_LifeSeeded }
				)
			},
			{
				EPN.C_RapidReplicator,
				new StandardCivic(EPN.C_RapidReplicator,
					dlc: new[] { EPN.D_MachineAge }.ToOrSet(),
					requirements: new[] { EPN.PH_Machine }.ToOrSet()
				)
			},
			{
				EPN.C_StaticResearchAnalysis,
				new StandardCivic(EPN.C_StaticResearchAnalysis,
					dlc: new[] { EPN.D_MachineAge }.ToOrSet(),
					requirements: new[] { EPN.PH_Machine }.ToOrSet()
				)
			},
			{
				EPN.C_Warbots,
				new StandardCivic(EPN.C_Warbots,
					dlc: new[] { EPN.D_MachineAge }.ToOrSet(),
					requirements: new[] { EPN.PH_Machine }.ToOrSet()
				)
			},
			{
				EPN.C_Astrometeorology,
				new StandardCivic(EPN.C_Astrometeorology,
					dlc: new[] { EPN.D_CosmicStorms }.ToOrSet()
				)
			},
			{
				EPN.C_CivilEducation,
				new StandardCivic(EPN.C_CivilEducation,
					dlc: new[] { EPN.D_Biogenesis }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_PoliceState, EPN.C_OppressiveAutocracy }
				)
			},
			{
				EPN.C_Crowdsourcing,
				new StandardCivic(EPN.C_Crowdsourcing,
					dlc: new[] { EPN.D_Biogenesis }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_ParliamentarySystem, EPN.AuthoritarianF, EPN.EgalitarianF, EPN.XenophileF, EPN.XenophobeF,
						EPN.MaterialistF, EPN.SpiritualistF, EPN.MilitaristF, EPN.PacifistF }
				)
			},
			{
				EPN.C_GeneticIdentification,
				new StandardCivic(EPN.C_GeneticIdentification,
					dlc: new[] { EPN.D_Biogenesis }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.PH_Machine }
				)
			},
			#endregion
			#region Permanent
			{
				EPN.C_InwardPerfection,
				new StandardCivic(EPN.C_InwardPerfection,
					requirements:new HashSet<OrSet>(){ new OrSet() { EPN.Pacifist,EPN.PacifistF }, new OrSet() { EPN.Xenophobe,EPN.XenophobeF } },
					prohibitions:new AndSet(EPNSET.HS_EagerExplorers
						.Union<String>(EPNSET.HS_SovereignGuardianship))
					{ EPN.C_PompousPurists, EPN.O_CommonGround, EPN.O_Hegemon, EPN.O_FearDark }
				)
			},
			{
				EPN.C_IdyllicBloom,
				new StandardCivic(EPN.C_IdyllicBloom,
					dlc: new[] { EPN.D_Plantoids }.ToOrSet(),
					requirements: new[]{ EPN.PH_Plantoid, EPN.PH_Fungoid }.ToOrSet(),
					prohibitions:new AndSet(EPNSET.HS_RelentlessIndustrialists){ EPN.O_HardReset, EPN.O_VoidDwellers}
				)
			},
			{
				EPN.C_FanaticPurifiers,
				new StandardCivic(EPN.C_FanaticPurifiers,
					dlc: new[] { EPN.D_Utopia }.ToOrSet(),
					requirements:new HashSet<OrSet>(){ new OrSet() { EPN.XenophobeF },new OrSet() { EPN.Militarist,EPN.Spiritualist } },
					prohibitions:new AndSet(EPNSET.HS_SovereignGuardianship){ EPN.C_BarbaricDespoilers,EPN.C_PompousPurists, EPN.C_SelectiveKinship,EPN.C_CrusaderSpirit,
						EPN.O_SyncreticEvolution,EPN.O_CommonGround,EPN.O_Hegemon, EPN.O_HereBeDragons,EPN.O_ImperialFiefdom, EPN.O_TeachersShroud,
						EPN.O_KnightsToxicGod, EPN.O_BrokenShackles, EPN.O_FearDark, EPN.O_Payback,EPN.O_StormChasers, EPN.O_TreasureHunters}
				)
			},
			{
				EPN.C_BarbaricDespoilers,
				new StandardCivic(EPN.C_BarbaricDespoilers,
					dlc: new[] { EPN.D_Apocalypse }.ToOrSet(),
					requirements: new HashSet<OrSet>(){ new OrSet() { EPN.Militarist, EPN.MilitaristF }, new OrSet() {EPN.Authoritarian,EPN.AuthoritarianF,EPN.Xenophobe,EPN.XenophobeF } },
					prohibitions: new AndSet(){ EPN.Xenophile,EPN.XenophileF,EPN.C_FanaticPurifiers,EPN.O_CommonGround }
				)
			},
			{
				EPN.C_Anglers,
				new StandardCivic(EPN.C_Anglers,
					dlc: new [] { EPN.D_Aquatics }.ToOrSet(),
					prohibitions:new AndSet(){ EPN.PH_Machine, EPN.O_PostApocalyptic,EPN.O_ShatteredRing,EPN.O_VoidDwellers,EPN.O_Subterranean}
				){ GrantedTraits = new HashSet<string>(){ EPN.T_Aquatic } }
			},
			{
				EPN.C_MarineMachines,
				new StandardCivic(EPN.C_MarineMachines,
					dlc: new [] { EPN.D_Aquatics }.ToOrSet(),
					requirements: new[]{ EPN.PH_Machine }.ToOrSet(),
					prohibitions:new AndSet(){ EPN.O_PostApocalyptic,EPN.O_ShatteredRing,EPN.O_VoidDwellers,EPN.O_Subterranean}
				)
			},
			{
				EPN.C_OppressiveAutocracy,
				new StandardCivic(EPN.C_OppressiveAutocracy,
					dlc: new [] { EPN.D_GalParagons }.ToOrSet(),
					requirements: new[]{ EPN.AuthoritarianF }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_AgrarianIdyll, EPN.C_Environmentalist, EPN.C_FreeHaven,
						EPN.C_WarriorCulture, EPN.C_PleasureSeekers, EPN.C_CivilEducation, EPN.O_KnightsToxicGod }
				)
			},
			{
				EPN.C_SovereignGuardianship,
				new StandardCivic(EPN.C_SovereignGuardianship,
					dlc: new [] { EPN.D_AstralPlanes }.ToOrSet(),
					requirements: new[] { EPN.Militarist,EPN.MilitaristF  }.ToOrSet(),
					prohibitions:new AndSet(){ EPN.C_InwardPerfection, EPN.C_FanaticPurifiers, EPN.C_Reanimators, EPN.C_EagerExplorers,EPN.O_BrokenShackles, EPN.O_FearDark, EPN.O_Payback }
				)
			},
			{
				EPN.C_NaturalDesign,
				new StandardCivic(EPN.C_NaturalDesign,
					dlc: new [] { EPN.D_MachineAge }.ToOrSet(),
					prohibitions:new AndSet(){ EPN.PH_Machine, EPN.C_GenesisGuides, EPN.O_HardReset, EPN.O_CloneArmy,
					EPN.O_Overtuned,EPN.O_TeachersShroud,EPN.O_CyberneticCreed,EPN.O_SyntheticFertility}
				)
			},
			{
				EPN.C_Planetscapers,
				new StandardCivic(EPN.C_Planetscapers,
					dlc: new [] { EPN.D_CosmicStorms }.ToOrSet(),
					prohibitions:new AndSet(){ EPN.C_Environmentalist, EPN.C_RelentlessIndustrialists, EPN.C_MutagenicSpas,
					EPN.O_Remnants, EPN.O_HardReset,EPN.O_PostApocalyptic,EPN.O_CalamitousBirth,EPN.O_ShatteredRing, EPN.O_VoidDwellers}
				)
			},
			{
				EPN.C_StormDevotion,
				new StandardCivic(EPN.C_StormDevotion,
					dlc: new [] { EPN.D_CosmicStorms }.ToOrSet(),
					prohibitions:new AndSet(){ EPN.O_HardReset }
				){ GrantedTraits = new[]{ EPN.T_StormTouched } }
			},
			{
				EPN.C_Beastmasters,
				new StandardCivic(EPN.C_Beastmasters,
					dlc: new [] { EPN.D_GrandArchive }.ToOrSet(),
					prohibitions:new AndSet(EPNSET.HS_EagerExplorers){ }
				)
			},
			{
				EPN.C_GalacticCurators,
				new StandardCivic(EPN.C_GalacticCurators,
					dlc: new [] { EPN.D_GrandArchive }.ToOrSet()
				)
			},
			#endregion
			#endregion
			#region Corporate
			{
				EPN.C_Franchising,
				new CorporateCivic(EPN.C_Franchising)
			},
			{
				EPN.C_FreeTraders,
				new CorporateCivic(EPN.C_FreeTraders)
			},
			{
				EPN.C_PrivateProspectors,
				new CorporateCivic(EPN.C_PrivateProspectors)
			},
			{
				EPN.C_TradingPosts,
				new CorporateCivic(EPN.C_TradingPosts,
					prohibitions: new AndSet(){ EPN.O_HardReset }
				)
			},
			{
				EPN.C_BrandLoyalty,
				new CorporateCivic(EPN.C_BrandLoyalty,
					prohibitions: new AndSet(){ EPN.C_BeaconofLiberty }
				)
			},
			{
				EPN.C_GospelMasses,
				new CorporateCivic(EPN.C_GospelMasses,
					requirements: new[] { EPN.Spiritualist, EPN.SpiritualistF }.ToOrSet()
				)
			},
			{
				EPN.C_IndenturedAssets,
				new CorporateCivic(EPN.C_IndenturedAssets,
					requirements: new[] { EPN.Authoritarian }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_CorporateHedonism, EPN.C_PleasureSeekers, EPN.C_SlaverGuilds, EPN.O_Payback }
				)
			},
			{
				EPN.C_MediaConglomerate,
				new CorporateCivic(EPN.C_MediaConglomerate,
					prohibitions: new AndSet(){ EPN.C_IdealisticFoundation, EPN.O_HardReset }
				)
			},
			{
				EPN.C_NavalContractors,
				new CorporateCivic(EPN.C_NavalContractors,
					requirements: new[] { EPN.Militarist, EPN.MilitaristF }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_CitizenService }
				)
			},
			{
				EPN.C_PrivateMilitaryCompanies,
				new CorporateCivic(EPN.C_PrivateMilitaryCompanies,
					requirements: new[] { EPN.Militarist, EPN.MilitaristF }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_WarriorCulture }
				)
			},
			{
				EPN.C_RuthlessCompetition,
				new CorporateCivic(EPN.C_RuthlessCompetition,
					prohibitions: new AndSet(){ EPN.C_WorkerCooperative, EPN.C_Meritocracy }
				)
			},
			{
				EPN.C_WorkerCooperative,
				new CorporateCivic(EPN.C_WorkerCooperative,
					requirements: new[] { EPN.Egalitarian }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.Xenophobe,EPN.XenophobeF, EPN.C_CorporateHedonism, EPN.C_RuthlessCompetition,
					EPN.C_CutthroatPolitics,EPN.C_PleasureSeekers,EPN.C_SharedBurdens,EPN.C_PoliceState}
				)
			},
			#region DLC
			{
				EPN.C_Gigacorp,
				new CorporateCivic(EPN.C_Gigacorp,
					dlc: new[] { EPN.D_Utopia, EPN.D_AstralPlanes }.ToOrSet(),
					requirements: new[] { EPN.Spiritualist, EPN.SpiritualistF }.ToOrSet()
				)
			},
			{
				EPN.C_CatalyticRecyclers,
				new CorporateCivic(EPN.C_CatalyticRecyclers,
					dlc: new[] { EPN.D_Plantoids }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_CatalyticProcessing,EPN.O_CalamitousBirth }
				)
			},
			{
				EPN.C_CorporateHedonism,
				new CorporateCivic(EPN.C_CorporateHedonism,
					dlc: new[] { EPN.D_Humanoids }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_IndenturedAssets, EPN.C_WorkerCooperative, 
						EPN.C_PleasureSeekers, EPN.C_SlaverGuilds, EPN.O_HardReset }
				)
			},
			{
				EPN.C_MastercraftInc,
				new CorporateCivic(EPN.C_MastercraftInc,
					dlc: new[] { EPN.D_Humanoids }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_MasterfulCrafters }
				)
			},
			{
				EPN.C_PublicRelationsSpecialists,
				new CorporateCivic(EPN.C_PublicRelationsSpecialists,
					dlc: new[] { EPN.D_Federations }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_DiplomaticCorps }
				)
			},
			{
				EPN.C_CorporateDeathCult,
				new CorporateCivic(EPN.C_CorporateDeathCult,
					dlc: new[] { EPN.D_Necroids }.ToOrSet(),
					requirements: new[] { EPN.Spiritualist, EPN.SpiritualistF }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_DimensionalWorship)
					{ EPN.C_InwardPerfection, EPN.C_FanaticPurifiers, EPN.O_Necrophage, EPN.O_CyberneticCreed }
				)
			},
			{
				EPN.C_PermanentEmployment,
				new CorporateCivic(EPN.C_PermanentEmployment,
					dlc: new[] { EPN.D_Necroids }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.Egalitarian, EPN.O_Mechanist, EPN.O_CloneArmy, EPN.O_Necrophage,
					EPN.O_CyberneticCreed, EPN.O_SyntheticFertility, EPN.PH_Machine}
				)
			},
			{
				EPN.C_MutagenicLuxury,
				new CorporateCivic(EPN.C_MutagenicLuxury,
					dlc: new[] { EPN.D_Toxoids }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_Planetscapers){ EPN.PH_Machine, EPN.C_MutagenicSpas, EPN.O_LifeSeeded, EPN.O_SyntheticFertility }
				)
			},
			{
				EPN.C_LuxuryLubePools,
				new CorporateCivic(EPN.C_LuxuryLubePools,
					dlc: new[] { EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.PH_Machine }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_Planetscapers){ EPN.C_LubricationTanks, EPN.O_LifeSeeded, EPN.O_SyntheticFertility }
				)
			},
			{
				EPN.C_RefurbishmentDivision,
				new CorporateCivic(EPN.C_RefurbishmentDivision,
					dlc: new[] { EPN.D_Toxoids }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_Scavengers }
				)
			},
			{
				EPN.C_ShareholderValues,
				new CorporateCivic(EPN.C_ShareholderValues,
					dlc: new[] { EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.Materialist, EPN.MaterialistF }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_Planetscapers){ EPN.C_AgrarianIdyll, EPN.C_Environmentalist,EPN.C_IdyllicBloom,
						EPN.C_Memorialists, EPN.C_RelentlessIndustrialists, EPN.O_LifeSeeded }
				)
			},
			{
				EPN.C_PrivatizedExploration,
				new CorporateCivic(EPN.C_PrivatizedExploration,
					dlc: new[] { EPN.D_FirstContact }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_SovereignGuardianship
						.Union<string>(EPNSET.HS_HyperspaceSpeciality)
						.Union<string>(EPNSET.HS_GenesisGuides)
						.Union<string>(EPNSET.HS_Beastmasters)
						){ EPN.O_BrokenShackles, EPN.O_FearDark,EPN.O_Payback,EPN.O_SyntheticFertility }
				)
			},
			{
				EPN.C_KnowledgeMentorship,
				new CorporateCivic(EPN.C_KnowledgeMentorship,
					dlc: new[] { EPN.D_GalParagons }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_VaultsKnowledge }
				)
			},
			{
				EPN.C_LetterMarque,
				new CorporateCivic(EPN.C_LetterMarque,
					dlc: new[] { EPN.D_GalParagons }.ToOrSet(),
					requirements: new[] { EPN.Authoritarian, EPN.Militarist, EPN.MilitaristF }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.Pacifist, EPN.PacifistF }
				)
			},
			{
				EPN.C_PharmaState,
				new CorporateCivic(EPN.C_PharmaState,
					dlc: new[] { EPN.D_GalParagons }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.O_BrokenShackles, EPN.O_Payback, EPN.PH_Machine }
				)
			},
			{
				EPN.C_PrecisionCogs,
				new CorporateCivic(EPN.C_PrecisionCogs,
					dlc: new[] { EPN.D_GalParagons }.ToOrSet()
				)
			},
			{
				EPN.C_DimensionalEnterprise,
				new CorporateCivic(EPN.C_DimensionalEnterprise,
					dlc: new[] { EPN.D_AstralPlanes }.ToOrSet(),
					requirements: new[] { EPN.Spiritualist,EPN.SpiritualistF }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_DeathCult){ EPN.C_DimensionalWorship }
				)
			},
			{
				EPN.C_HyperspaceTrade,
				new CorporateCivic(EPN.C_HyperspaceTrade,
					dlc: new[] { EPN.D_AstralPlanes }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_EagerExplorers, EPN.C_HyperspaceSpeciality }
				)
			},
			{
				EPN.C_AstrogenesisTechnologies,
				new CorporateCivic(EPN.C_AstrogenesisTechnologies,
					dlc: new[] { EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_EagerExplorers){ EPN.Xenophobe,EPN.XenophobeF,
					EPN.C_GenesisGuides,EPN.O_SyncreticEvolution,EPN.O_HardReset,EPN.O_LifeSeeded}
				)
			},
			{
				EPN.C_WeatherExploitation,
				new CorporateCivic(EPN.C_WeatherExploitation,
					dlc: new[] { EPN.D_CosmicStorms }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_Astrometeorology }
				)
			},
			{
				EPN.C_DecentralizedRandD,
				new CorporateCivic(EPN.C_DecentralizedRandD,
					dlc: new[] { EPN.D_Biogenesis }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.AuthoritarianF, EPN.SpiritualistF, EPN.MilitaristF, EPN.XenophobeF, EPN.EgalitarianF, EPN.MaterialistF, EPN.PacifistF, EPN.XenophileF,
					EPN.C_Crowdsourcing, EPN.C_ParliamentarySystem}
				)
			},
			{
				EPN.C_SequencedSecurities,
				new CorporateCivic(EPN.C_SequencedSecurities,
					dlc: new[] { EPN.D_Biogenesis }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.PH_Machine, EPN.C_GeneticIdentification }
				)
			},
			#endregion
			#region Permanent
			{
				EPN.C_CriminalHeritage,
				new CorporateCivic(EPN.C_CriminalHeritage)
			},
			{
				EPN.C_TrawlingOperations,
				new CorporateCivic(EPN.C_TrawlingOperations,
					dlc: new[] { EPN.D_Aquatics }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.PH_Machine, EPN.O_HardReset, EPN.O_PostApocalyptic, EPN.O_ShatteredRing,
					EPN.O_VoidDwellers, EPN.O_Subterranean}
				)
			},
			{
				EPN.C_MaritimeRobotics,
				new CorporateCivic(EPN.C_MaritimeRobotics,
					dlc: new[] { EPN.D_Aquatics }.ToOrSet(),
					requirements: new[] { EPN.PH_Machine }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.O_PostApocalyptic, EPN.O_ShatteredRing,EPN.O_VoidDwellers,EPN.O_Subterranean }
				)
			},
			{
				EPN.C_CorporateProtectorate,
				new CorporateCivic(EPN.C_CorporateProtectorate,
					dlc: new[] { EPN.D_AstralPlanes }.ToOrSet(),
					requirements: new[] { EPN.Militarist,EPN.MilitaristF }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_EagerExplorers){ EPN.C_Reanimators,EPN.O_BrokenShackles,
						EPN.O_FearDark,EPN.O_Payback }
				)
			},
			{
				EPN.C_ShadowCorpation,
				new CorporateCivic(EPN.C_ShadowCorpation,
					dlc: new[] { EPN.D_AstralPlanes }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.O_HardReset }
				)
			},
			{
				EPN.C_AugmentationBazaars,
				new CorporateCivic(EPN.C_AugmentationBazaars,
					dlc: new[] { EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.PH_Machine, EPN.O_TeachersShroud,EPN.O_SyntheticFertility }
				)
			},
			{
				EPN.C_GeoEngineeringInc,
				new CorporateCivic(EPN.C_GeoEngineeringInc,
					dlc: new[] { EPN.D_CosmicStorms }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_RelentlessIndustrialists
						.Union<string>(EPNSET.HS_MutagenicSpas)
						){ EPN.C_Environmentalist,EPN.O_Remnants,EPN.O_HardReset,EPN.O_PostApocalyptic,
					EPN.O_CalamitousBirth,EPN.O_ShatteredRing,EPN.O_VoidDwellers, EPN.C_Planetscapers}
				)
			},
			{
				EPN.C_StormInfluencers,
				new CorporateCivic(EPN.C_StormInfluencers,
					dlc: new[] { EPN.D_CosmicStorms }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.O_HardReset }
				){ GrantedTraits = new[]{ EPN.T_StormTouched } }
			},
			{
				EPN.C_AntiquarianExpertise,
				new CorporateCivic(EPN.C_AntiquarianExpertise,
					dlc: new[] { EPN.D_GrandArchive }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_GalacticCurators }
				)
			},
			{
				EPN.C_SpaceRanchers,
				new CorporateCivic(EPN.C_SpaceRanchers,
					dlc: new[] { EPN.D_GrandArchive }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_EagerExplorers,EPN.C_Beastmasters }
				)
			},
			#endregion
			#endregion
			#region Hive Mind
			{
				EPN.C_DividedAttention,
				new HiveMindCivic(EPN.C_DividedAttention)
			},
			{
				EPN.C_OneMind,
				new HiveMindCivic(EPN.C_OneMind)
			},
			{
				EPN.C_PooledKnowledge,
				new HiveMindCivic(EPN.C_PooledKnowledge)
			},
			{
				EPN.C_StrengthofLegions,
				new HiveMindCivic(EPN.C_StrengthofLegions)
			},
			{
				EPN.C_SubspaceEphapse,
				new HiveMindCivic(EPN.C_SubspaceEphapse)
			},
			{
				EPN.C_SubsumedWill,
				new HiveMindCivic(EPN.C_SubsumedWill)
			},
			{
				EPN.C_ElevationalContemplations,
				new HiveMindCivic(EPN.C_ElevationalContemplations,
					dlc: new[] {EPN.D_Utopia,EPN.D_AstralPlanes }.ToOrSet()
				)
			},
			{
				EPN.C_OrganicReprocessing,
				new HiveMindCivic(EPN.C_OrganicReprocessing,
					dlc: new[] { EPN.D_Plantoids }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.O_CalamitousBirth,EPN.O_Wilderness }
				)
			},
			{
				EPN.C_Ascetic,
				new HiveMindCivic(EPN.C_Ascetic,
					dlc: new[] { EPN.D_Utopia }.ToOrSet()
				)
			},
			{
				EPN.C_NaturalNeuralNetwork,
				new HiveMindCivic(EPN.C_NaturalNeuralNetwork,
					dlc: new[] { EPN.D_Utopia }.ToOrSet()
				)
			},
			{
				EPN.C_VoidHive,
				new HiveMindCivic(EPN.C_VoidHive,
					dlc: new[] { EPN.D_Lithoids }.ToOrSet()
				)
			},
			{
				EPN.C_Empath,
				new HiveMindCivic(EPN.C_Empath,
					dlc: new[] { EPN.D_Federations }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_Genocidal){ EPN.O_Necrophage }
				)
			},
			{
				EPN.C_CordycepticDrones,
				new HiveMindCivic(EPN.C_CordycepticDrones,
					dlc: new[] { EPN.D_Necroids }.ToOrSet()
				)
			},
			{
				EPN.C_MemorialistHM,
				new HiveMindCivic(EPN.C_MemorialistHM,
					dlc: new[] { EPN.D_Necroids }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_Genocidal){ EPN.O_Wilderness  }
				)
			},
			{
				EPN.C_PermutationPools,
				new HiveMindCivic(EPN.C_PermutationPools,
					dlc: new[] { EPN.D_Toxoids }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.O_LifeSeeded }
				)
			},
			{
				EPN.C_AutonomousDrones,
				new HiveMindCivic(EPN.C_AutonomousDrones,
					dlc: new[] { EPN.D_GalParagons }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.O_Wilderness }
				)
			},
			{
				EPN.C_NeuralVaults,
				new HiveMindCivic(EPN.C_NeuralVaults,
					dlc: new[] { EPN.D_GalParagons }.ToOrSet()
				)
			},
			{
				EPN.C_HyperspaceSyncHM,
				new HiveMindCivic(EPN.C_HyperspaceSyncHM,
					dlc: new[] { EPN.D_AstralPlanes }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_Stargazers }
				)
			},
			{
				EPN.C_GenesisSymbiotes,
				new HiveMindCivic(EPN.C_GenesisSymbiotes,
					dlc: new[] { EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_InnateDesign, EPN.C_Stargazers, EPN.O_LifeSeeded, EPN.O_Wilderness }
				)
			},
			{
				EPN.C_ClimateModelingHM,
				new HiveMindCivic(EPN.C_ClimateModelingHM,
					dlc: new[] { EPN.D_CosmicStorms }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.O_Wilderness }
				)
			},
			#region Permanent
			{
				EPN.C_MycorrhizalIdeal,
				new HiveMindCivic(EPN.C_MycorrhizalIdeal,
					dlc: new[] { EPN.D_Plantoids }.ToOrSet(),
					requirements: new[] { EPN.PH_Plantoid, EPN.PH_Fungoid }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.O_VoidDwellers }
				)
			},
			{
				EPN.C_Stargazers,
				new HiveMindCivic(EPN.C_Stargazers,
					dlc: new[] { EPN.D_FirstContact }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_HyperspaceSyncHM, EPN.C_GenesisSymbiotes, EPN.C_WildSwarm,
					EPN.O_BrokenShackles,EPN.O_FearDark,EPN.O_Payback}
				){ GrantedTraits = new[] { EPN.T_Stargazer } }
			},
			{
				EPN.C_GuardianCluster,
				new HiveMindCivic(EPN.C_GuardianCluster,
					dlc: new[] { EPN.D_AstralPlanes }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_Genocidal){  }
				)
			},
			{
				EPN.C_InnateDesign,
				new HiveMindCivic(EPN.C_InnateDesign,
					dlc: new[] { EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_GenesisSymbiotes,EPN.O_Overtuned }
				)
			},
			{
				EPN.C_CultivationDrones,
				new HiveMindCivic(EPN.C_CultivationDrones,
					dlc: new[] { EPN.D_CosmicStorms }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_PermutationPools, EPN.O_Remnants, EPN.O_PostApocalyptic, EPN.O_CalamitousBirth,
					EPN.O_ShatteredRing, EPN.O_VoidDwellers, EPN.O_Wilderness}
				)
			},
			{
				EPN.C_CaretakerNetworkHM,
				new HiveMindCivic(EPN.C_CaretakerNetworkHM,
					dlc: new[] { EPN.D_GrandArchive }.ToOrSet()
				)
			},
			{
				EPN.C_WildSwarm,
				new HiveMindCivic(EPN.C_WildSwarm,
					dlc: new[] { EPN.D_GrandArchive }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_Stargazers, EPN.O_ProgenitorHive }
				)
			},
			{
				EPN.C_AerospaceAdaption,
				new HiveMindCivic(EPN.C_AerospaceAdaption,
					dlc: new[] { EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.S_Biological }.ToOrSet()
				)
			},
			{
				EPN.C_Bodysnatcher,
				new HiveMindCivic(EPN.C_Bodysnatcher,
					dlc: new[] { EPN.D_Biogenesis }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_Genocidal){ EPN.O_Necrophage,EPN.O_EvolutionaryPredators }
				)
			},
			{
				EPN.C_FamiliarFace,
				new HiveMindCivic(EPN.C_FamiliarFace,
					dlc: new[] { EPN.D_Biogenesis }.ToOrSet(),
					prohibitions: new AndSet(EPNSET.HS_Genocidal){  }
				)
			},
			{
				EPN.C_SharedGenetics,
				new HiveMindCivic(EPN.C_SharedGenetics,
					dlc: new[] { EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.S_Biological }.ToOrSet()
				)
			},
			#endregion
			#region Genodical
			{
				EPN.C_DevouringSwarm,
				new HiveMindCivic(EPN.C_DevouringSwarm,
					dlc: new[] { EPN.D_Utopia }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.PH_Lithoid, EPN.C_Empath, EPN.C_MemorialistHM, EPN.C_GuardianCluster,
					EPN.C_Bodysnatcher, EPN.C_FamiliarFace, EPN.O_CommonGround, EPN.O_Hegemon, EPN.O_ImperialFiefdom, EPN.O_Wilderness,
					EPN.O_TreeofLife, EPN.O_FruitfulPartnership, EPN.O_HereBeDragons, EPN.O_StormChasers,EPN.O_TreasureHunters}
				)
			},
			{
				EPN.C_Terravore,
				new HiveMindCivic(EPN.C_NeuralVaults,
					dlc: new HashSet<OrSet>(){ new OrSet() { EPN.D_Utopia },new OrSet() {EPN.D_Lithoids } },
					requirements: new[] { EPN.PH_Lithoid }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_Empath, EPN.C_MemorialistHM, EPN.C_GuardianCluster,
					EPN.C_Bodysnatcher, EPN.C_FamiliarFace, EPN.O_CommonGround, EPN.O_Hegemon, EPN.O_ImperialFiefdom, EPN.O_Wilderness,
					EPN.O_TreeofLife, EPN.O_FruitfulPartnership, EPN.O_HereBeDragons, EPN.O_StormChasers,EPN.O_TreasureHunters}
				)
			},
			{
				EPN.C_DevouringWilderness,
				new HiveMindCivic(EPN.C_DevouringWilderness,
					dlc: new HashSet<OrSet>(){ new OrSet() { EPN.D_Utopia }, new OrSet() {EPN.D_Biogenesis } },
					requirements: new[] { EPN.O_Wilderness }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.PH_Lithoid, EPN.C_Empath, EPN.C_MemorialistHM, EPN.C_GuardianCluster,
					EPN.C_Bodysnatcher,EPN.C_FamiliarFace}
				)
			},
			#endregion
			#endregion
			#region Machine Intelligence
			{
				EPN.C_BuiltToLast,
				new MachineIntelligenceCivic(EPN.C_BuiltToLast)
			},
			{
				EPN.C_Constructobot,
				new MachineIntelligenceCivic(EPN.C_Constructobot)
			},
			{
				EPN.C_DelegatedFunctions,
				new MachineIntelligenceCivic(EPN.C_DelegatedFunctions)
			},
			{
				EPN.C_FactoryOverclocking,
				new MachineIntelligenceCivic(EPN.C_FactoryOverclocking)
			},
			{
				EPN.C_Introspective,
				new MachineIntelligenceCivic(EPN.C_Introspective)
			},
			{
				EPN.C_MaintenanceProtocols,
				new MachineIntelligenceCivic(EPN.C_MaintenanceProtocols)
			},
			{
				EPN.C_OTAUpdates,
				new MachineIntelligenceCivic(EPN.C_OTAUpdates)
			},
			{
				EPN.C_RapidReplicatorMI,
				new MachineIntelligenceCivic(EPN.C_RapidReplicatorMI)
			},
			{
				EPN.C_Rockbreakers,
				new MachineIntelligenceCivic(EPN.C_Rockbreakers)
			},
			{
				EPN.C_StaticResearchAnalysisMI,
				new MachineIntelligenceCivic(EPN.C_StaticResearchAnalysisMI)
			},
			{
				EPN.C_UnitaryCohesion,
				new MachineIntelligenceCivic(EPN.C_UnitaryCohesion)
			},
			{
				EPN.C_WarbotsMI,
				new MachineIntelligenceCivic(EPN.C_WarbotsMI,
					prohibitions: new AndSet(){ EPN.C_ObsessionalDirective }
				)
			},
			{
				EPN.C_ZeroWasteProtocols,
				new MachineIntelligenceCivic(EPN.C_ZeroWasteProtocols)
			},
			{
				EPN.C_ElevationalHypotheses,
				new MachineIntelligenceCivic(EPN.C_ElevationalHypotheses,
					dlc: new[] { EPN.D_Utopia, EPN.D_AstralPlanes }.ToOrSet()
				)
			},
			{
				EPN.C_AstroMiningDrones,
				new MachineIntelligenceCivic(EPN.C_AstroMiningDrones,
					dlc: new[] { EPN.D_Federations  }.ToOrSet()
				)
			},
			{
				EPN.C_MemorialistMI,
				new MachineIntelligenceCivic(EPN.C_MemorialistMI,
					dlc: new[] { EPN.D_Necroids }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_DeterminedExterminator, EPN.C_DrivenAssimilator }
				)
			},
			{
				EPN.C_SpywareDirectives,
				new MachineIntelligenceCivic(EPN.C_SpywareDirectives,
					dlc: new[] { EPN.D_Nemesis }.ToOrSet()
				)
			},
			{
				EPN.C_HyperLubeBasins,
				new MachineIntelligenceCivic(EPN.C_HyperLubeBasins,
					dlc: new[] { EPN.D_Toxoids }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_GardeningProtocols }
				)
			},
			{
				EPN.C_ExplorationProtocols,
				new MachineIntelligenceCivic(EPN.C_ExplorationProtocols,
					dlc: new[] { EPN.D_FirstContact }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_DeterminedExterminator, EPN.C_DrivenAssimilator, EPN.C_HyperspaceSyncMI, EPN.C_Biodrones }
				)
			},
			{
				EPN.C_ExperienceCache,
				new MachineIntelligenceCivic(EPN.C_ExperienceCache,
					dlc: new[] { EPN.D_GalParagons }.ToOrSet()
				)
			},
			{
				EPN.C_SovereignCircuits,
				new MachineIntelligenceCivic(EPN.C_SovereignCircuits,
					dlc: new[] { EPN.D_GalParagons }.ToOrSet()
				)
			},
			{
				EPN.C_HyperspaceSyncMI,
				new MachineIntelligenceCivic(EPN.C_HyperspaceSyncMI,
					dlc: new[] { EPN.D_AstralPlanes }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_ExplorationProtocols }
				)
			},
			{
				EPN.C_DiplomaticProtocols,
				new MachineIntelligenceCivic(EPN.C_DiplomaticProtocols,
					dlc: new[] { EPN.D_MachineAge  }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_DeterminedExterminator }
				)
			},
			{
				EPN.C_GenesisArchitects,
				new MachineIntelligenceCivic(EPN.C_GenesisArchitects,
					dlc: new[] { EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_ExplorationProtocols, EPN.O_ResourceConsolidation, EPN.O_LifeSeeded }
				)
			},
			{
				EPN.C_ClimateModelingMI,
				new MachineIntelligenceCivic(EPN.C_ClimateModelingMI,
					dlc: new[] { EPN.D_CosmicStorms }.ToOrSet()
				)
			},
			{
				EPN.C_StalwartNetwork,
				new MachineIntelligenceCivic(EPN.C_StalwartNetwork,
					dlc: new[] { EPN.D_Biogenesis }.ToOrSet()
				)
			},
			#region Permanent
			{
				EPN.C_DeterminedExterminator,
				new MachineIntelligenceCivic(EPN.C_DeterminedExterminator,
					dlc: new[] { EPN.D_SyntheticDawn }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_DrivenAssimilator, EPN.C_RogueServitor, EPN.C_ExplorationProtocols,
					EPN.C_GuardianMatrix, EPN.C_DiplomaticProtocols, EPN.C_TacticalAlgorithms, EPN.C_Biodrones,
					EPN.O_CommonGround, EPN.O_Hegemon, EPN.O_HereBeDragons, EPN.O_ImperialFiefdom, EPN.O_StormChasers, EPN.O_TreasureHunters}
				)
			},
			{
				EPN.C_DrivenAssimilator,
				new MachineIntelligenceCivic(EPN.C_DrivenAssimilator,
					dlc: new[] { EPN.D_SyntheticDawn }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_DeterminedExterminator, EPN.C_RogueServitor, EPN.C_ExplorationProtocols, EPN.O_ImperialFiefdom }
				)
			},
			{
				EPN.C_RogueServitor,
				new MachineIntelligenceCivic(EPN.C_RogueServitor,
					dlc: new[] { EPN.D_SyntheticDawn }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_DeterminedExterminator, EPN.C_DrivenAssimilator, EPN.O_ResourceConsolidation }
				)
			},
			{
				EPN.C_GuardianMatrix,
				new MachineIntelligenceCivic(EPN.C_GuardianMatrix,
					dlc: new[] { EPN.D_AstralPlanes }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_DeterminedExterminator }
				)
			},
			{
				EPN.C_ObsessionalDirective,
				new MachineIntelligenceCivic(EPN.C_ObsessionalDirective,
					dlc: new[] { EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_WarbotsMI }
				)
			},
			{
				EPN.C_TacticalAlgorithms,
				new MachineIntelligenceCivic(EPN.C_TacticalAlgorithms,
					dlc: new[] { EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_DeterminedExterminator }
				)
			},
			{
				EPN.C_GardeningProtocols,
				new MachineIntelligenceCivic(EPN.C_GardeningProtocols,
					dlc: new[] { EPN.D_CosmicStorms }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_HyperLubeBasins, EPN.O_Remnants, EPN.O_PostApocalyptic, EPN.O_ShatteredRing,
					EPN.O_VoidDwellers, EPN.O_ResourceConsolidation}
				)
			},
			{
				EPN.C_Biodrones,
				new MachineIntelligenceCivic(EPN.C_Biodrones,
					dlc: new[] { EPN.D_GrandArchive }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.C_DeterminedExterminator, EPN.C_ExplorationProtocols }
				)
			},
			{
				EPN.C_CaretakerNetworkMI,
				new MachineIntelligenceCivic(EPN.C_CaretakerNetworkMI,
					dlc: new[] { EPN.D_GrandArchive }.ToOrSet()
				)
			},
			#endregion
			#endregion
		};

		public Civic(String name, HashSet<OrSet>? dlc = null, 
			HashSet<OrSet>? requirements = null, IEnumerable<string>? prohibitions = null) 
			: base(name, EmpirePropertyType.Civic, dlc, requirements, prohibitions) { }
	}

	/// <summary>
	/// Standard civics are the most common type of civic. They prohibit Gestalt and Corporate Authority
	/// </summary>
	public sealed class StandardCivic : Civic
	{
		public StandardCivic(String name, HashSet<OrSet>? dlc = null,
			HashSet<OrSet>? requirements = null, AndSet? prohibitions = null)
			: base(name, dlc, requirements,
				  new[] { EPN.Gestalt, EPN.A_Corporate }.Union<string>(prohibitions ?? Enumerable.Empty<string>()))

		{ }
	}

	/// <summary>
	/// Corporate civics are only available to Corporate Authority empires.
	/// </summary>
	public sealed class CorporateCivic : Civic
	{
		public CorporateCivic(String name, HashSet<OrSet>? dlc = null,
			HashSet<OrSet>? requirements = null, AndSet? prohibitions = null)
			:
			 base(name,
				new[] { EPN.D_Megacorp }.ToOrSet()
					.Union(dlc ?? new HashSet<OrSet>()).ToHashSet(),
			new[] { EPN.A_Corporate}.ToOrSet()
					.Union(requirements ?? new HashSet<OrSet>()).ToHashSet(),
			prohibitions)
		{
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
			DLC = new[] { EPN.A_HiveMind, EPN.D_Biogenesis }.ToOrSet();
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