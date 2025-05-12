using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
	public class Origin : EmpireProperty
	{
		#region Singletons


		public static Dictionary<String, Origin> Collection { get; } = new Dictionary<string, Origin>()
		{
			{
				EPN.O_GalacticDoorstep,
				new Origin(EPN.O_GalacticDoorstep){ }
			},{
				EPN.O_ProsperousUnification,
				new Origin(EPN.O_ProsperousUnification){ }
			},{
				EPN.O_LostColony,
				new Origin(EPN.O_LostColony){ }
			},{
				EPN.O_Remnants,
				new Origin(EPN.O_Remnants, new []{ EPN.D_AncientRelics, EPN.D_Federations}.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_Planetscapers){ EPN.C_AgrarianIdyll },
					PlanetType = EPN.PT_Relic
				}
			},{
				EPN.O_Mechanist,
				new Origin(EPN.O_Mechanist, new[] { EPN.D_Utopia }.ToOrSet())
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.Materialist, EPN.MaterialistF }},
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.PH_Machine, EPN.C_PermanentEmployment }
				}
			},{
				EPN.O_SyncreticEvolution,
				new Origin(EPN.O_SyncreticEvolution, new[] { EPN.D_Utopia }.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_GenesisGuides){ EPN.Gestalt, EPN.C_FanaticPurifiers }
				}
			},{
				EPN.O_HardReset,
				new Origin(EPN.O_HardReset, new[] { EPN.D_SyntheticDawn }.ToOrSet())
				{
					Requires = new HashSet<OrSet>(){ new OrSet() {EPN.Militarist,EPN.MilitaristF }},
					Prohibits = new AndSet(EPNSET.HS_HyperspaceSpeciality
						.Union<string>(EPNSET.HS_DarkConsortium)
						.Union<string>(EPNSET.HS_GenesisGuides)
						.Union<string>(EPNSET.HS_Planetscapers)
						.Union<string>(EPNSET.HS_StormDevotion)
						.Union<string>(EPNSET.HS_EagerExplorers)
						.Union<string>(EPNSET.HS_PleasureSeekers)
						){
						EPN.Gestalt, EPN.SpiritualistF, EPN.XenophileF, EPN.C_AristocraticElite,
						EPN.C_ParliamentarySystem, EPN.C_IdyllicBloom, EPN.C_HeroicPast, EPN.C_NaturalDesign,
						EPN.C_CriminalHeritage,EPN.C_MediaConglomerate,EPN.C_TradingPosts, EPN.S_Biological
					},
					GrantedTraits = new[] { EPN.T_CyberCommandos, EPN.T_Unplugged }
				}
			},{
				EPN.O_LifeSeeded,
				new Origin(EPN.O_LifeSeeded, new[] { EPN.D_Apocalypse }.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_RelentlessIndustrialists
						.Union<string>(EPNSET.HS_MutagenicSpas)
						.Union<string>(EPNSET.HS_GenesisGuides)
						){ },
					PlanetType = EPN.PT_Gaia
				}
			},{
				EPN.O_PostApocalyptic,
				new Origin(EPN.O_PostApocalyptic, new[] { EPN.D_Apocalypse }.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_Anglers
						.Union<string>(EPNSET.HS_Planetscapers)
						){ EPN.PH_Machine, EPN.C_AgrarianIdyll, },
					PlanetType = EPN.PT_Tomb,
					GrantedTraits = new[] { EPN.T_Survivor }
				}
			},{
				EPN.O_RadioactiveRovers,
				new Origin(EPN.O_RadioactiveRovers, new[] { EPN.D_Apocalypse }.ToOrSet())
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.PH_Machine }},
					Prohibits = new AndSet(EPNSET.HS_Anglers
						.Union<string>(EPNSET.HS_Planetscapers)
						){ EPN.C_AgrarianIdyll, }
				}
			},{
				EPN.O_CloneArmy,
				new Origin(EPN.O_CloneArmy, new[] { EPN.D_Humanoids }.ToOrSet())
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.PH_Machine, EPN.C_NaturalDesign, EPN.C_PermanentEmployment },
					GrantedTraits = new[] { EPN.T_CloneSoldier }
				}
			},{
				EPN.O_CommonGround,
				new Origin(EPN.O_CommonGround, new[] { EPN.D_Federations }.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal)
					{ EPN.Xenophobe,EPN.XenophobeF, EPN.C_InwardPerfection, EPN.C_BarbaricDespoilers }
				}
			},{
				EPN.O_Hegemon,
				new Origin(EPN.O_Hegemon, new[] { EPN.D_Federations }.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal)
					{ EPN.Xenophobe, EPN.XenophobeF, EPN.Egalitarian,EPN.EgalitarianF,  EPN.C_InwardPerfection }
				}
			},{
				EPN.O_Doomsday,
				new Origin(EPN.O_Doomsday, new[] { EPN.D_Federations }.ToOrSet()){ }
			},{
				EPN.O_Giants,
				new Origin(EPN.O_Giants, new[] { EPN.D_Federations }.ToOrSet())
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.PH_Machine }
				}
			},{
				EPN.O_Scion,
				new Origin(EPN.O_Scion, new[] { EPN.D_Federations }.ToOrSet())
				{
					Prohibits = new AndSet(){ EPN.XenophobeF, EPN.Gestalt, EPN.C_PompousPurists, EPN.PH_Machine }
				}
			},{
				EPN.O_ShatteredRing,
				new Origin(EPN.O_ShatteredRing, new[] { EPN.D_Federations }.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_Anglers
						.Union<string>(EPNSET.HS_Planetscapers)
						){ EPN.C_AgrarianIdyll},
					PlanetType = EPN.PT_RingWorld
				}
			},{
				EPN.O_VoidDwellers,
				new Origin(EPN.O_VoidDwellers, new[] { EPN.D_Federations }.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_Anglers
						.Union<string>(EPNSET.HS_IdyllicBloom)
						.Union<string>(EPNSET.HS_Planetscapers)
						){ EPN.C_AgrarianIdyll}
					,PlanetType = EPN.PT_Habitat,
					GrantedTraits = new[] { EPN.T_VoidDweller }
				}
			},{
				EPN.O_Voidforged,
				new Origin(EPN.O_Voidforged, new[] { EPN.D_Federations }.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_Anglers
						.Union<string>(EPNSET.HS_IdyllicBloom)
						.Union<string>(EPNSET.HS_Planetscapers)
						){ EPN.C_AgrarianIdyll}
					,PlanetType = EPN.PT_Habitat,
					GrantedTraits = new[] { EPN.T_ZeroGOptimized }
				}
			},{
				EPN.O_Necrophage,
				new Origin(EPN.O_Necrophage, new[] { EPN.D_Necroids }.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_DeathCult){ EPN.PH_Machine, EPN.Xenophile,EPN.XenophileF,EPN.EgalitarianF,
					EPN.C_PermanentEmployment, EPN.C_Empath, EPN.C_Bodysnatcher},
					GrantedTraits = new[] { EPN.T_Necrophage }
				}
			}
			,{
				EPN.O_HereBeDragons,
				new Origin(EPN.O_HereBeDragons, new[] { EPN.D_Aquatics }.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal){  }
				}
			}
			,{
				EPN.O_OceanParadise,
				new Origin(EPN.O_OceanParadise, new[] { EPN.D_Aquatics }.ToOrSet())
				{
					Prohibits = new AndSet(){ }
				}
			},{
				EPN.O_KnightsToxicGod,
				new Origin(EPN.O_KnightsToxicGod, new[] { EPN.D_Toxoids }.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal){ EPN.Gestalt, EPN.PH_Machine, EPN.C_OppressiveAutocracy }
				}
			},{
				EPN.O_Overtuned,
				new Origin(EPN.O_Overtuned, new[] { EPN.D_Toxoids }.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_NaturalDesign){ EPN.PH_Machine }
				}
			},{
				EPN.O_ImperialFiefdom,
				new Origin(EPN.O_ImperialFiefdom, new[] { EPN.D_Overlord }.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal){ EPN.C_InwardPerfection, EPN.C_DrivenAssimilator }
				}
			},{
				EPN.O_SlingshotStars,
				new Origin(EPN.O_SlingshotStars, new[] { EPN.D_Overlord }.ToOrSet())
				{

				}
			},{
				EPN.O_Subterranean,
				new Origin(EPN.O_Subterranean, new[] { EPN.D_Overlord }.ToOrSet())
				{
					GrantedTraits = new[] { EPN.T_CaveDweller },
				}
			},{
				EPN.O_BrokenShackles,
				new Origin(EPN.O_BrokenShackles, new[] { EPN.D_FirstContact }.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_SovereignGuardianship
						.Union<string>(EPNSET.HS_EagerExplorers)
						){ EPN.Authoritarian, EPN.AuthoritarianF, EPN.Xenophobe, EPN.XenophobeF,
						EPN.Gestalt, EPN.PH_Machine, EPN.C_SelectiveKinship, EPN.C_PharmaState }
				}
			},{
				EPN.O_Payback,
				new Origin(EPN.O_Payback,new[]{ EPN.D_FirstContact }.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_SovereignGuardianship
						.Union<string>(EPNSET.HS_Genocidal)
						.Union<string>(EPNSET.HS_EagerExplorers)
						){ EPN.Gestalt, EPN.PH_Machine, EPN.C_SlaverGuilds, EPN.C_PompousPurists,
					EPN.C_OppressiveAutocracy, EPN.C_PharmaState}
				}
			},{
				EPN.O_FearDark,
				new Origin(EPN.O_FearDark,new[]{ EPN.D_FirstContact}.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal
						.Union<string>(EPNSET.HS_EagerExplorers)
						.Union<string>(EPNSET.HS_SovereignGuardianship)
						){ EPN.Gestalt, EPN.PH_Machine, EPN.C_InwardPerfection, EPN.S_Biological }
				}
			},
			{
				EPN.O_UnderOneRule,
				new Origin(EPN.O_UnderOneRule,new[]{ EPN.D_GalParagons}.ToOrSet())
				{
					Requires = new HashSet<OrSet>(){ new OrSet() {EPN.A_Dictatorial }},
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.PH_Machine },
					GrantedTraits = new[] { EPN.T_PerfectedGenes }
				}
			},{
				EPN.O_Riftworld,
				new Origin(EPN.O_Riftworld, new[]{EPN.D_AstralPlanes}.ToOrSet())
				{

				}
			},{
				EPN.O_StormChasers,
				new Origin(EPN.O_StormChasers,new[]{ EPN.D_CosmicStorms}.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal) { }
				}
			},
			{
				EPN.O_PrimalCalling,
				new Origin(EPN.O_PrimalCalling,new[]{ EPN.D_GrandArchive}.ToOrSet())
				{
					Prohibits = new AndSet()
					{ EPN.PH_Machine }
				}
			},
			{
				EPN.O_TreasureHunters,
				new Origin(EPN.O_TreasureHunters, new[]{EPN.D_GrandArchive}.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal) { }
				}
			},
			{
				EPN.O_StarlitCitadel,
				new Origin(EPN.O_StarlitCitadel, new[]{EPN.D_Biogenesis}.ToOrSet())
				{
					Prohibits = new AndSet(){ EPN.S_Biological }
				}
			},{
				EPN.O_TeachersShroud,
				new Origin(EPN.O_TeachersShroud,new[]{ EPN.D_Overlord}.ToOrSet())
				{
					Requires = new HashSet<OrSet>(){ new OrSet() {EPN.Spiritualist, EPN.SpiritualistF } },
					Prohibits = new AndSet(EPNSET.HS_Genocidal){ EPN.PH_Machine, EPN.C_NaturalDesign, EPN.C_AugmentationBazaars}
				}
			},{
				EPN.O_CyberneticCreed,
				new Origin(EPN.O_CyberneticCreed,new[]{ EPN.D_MachineAge}.ToOrSet())
				{
					Requires = new HashSet<OrSet>(){ new OrSet() {EPN.Spiritualist, EPN.SpiritualistF } },
					Prohibits = new AndSet(){ EPN.PH_Machine, EPN.Egalitarian, EPN.EgalitarianF, EPN.C_NaturalDesign, EPN.C_PermanentEmployment }
					, GrantedTraits = new[] { EPN.T_RitualisticImplants }
				}
			},{
				EPN.O_SyntheticFertility,
				new Origin(EPN.O_SyntheticFertility,new[]{ EPN.D_MachineAge}.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_EagerExplorers
						.Union<string>(EPNSET.HS_Reanimators)
						.Union<string>(EPNSET.HS_MutagenicSpas)
						){ EPN.Gestalt, EPN.PH_Machine, EPN.Spiritualist, EPN.SpiritualistF,
						EPN.C_NaturalDesign, EPN.C_AugmentationBazaars},
					GrantedTraits = new[] { EPN.T_PathogenicGenes }
				}
			},{
				EPN.O_EvolutionaryPredators,
				new Origin(EPN.O_EvolutionaryPredators,new[]{ EPN.D_Biogenesis}.ToOrSet())
				{
					Prohibits = new AndSet(EPNSET.HS_IdyllicBloom
						.Union<string>(EPNSET.HS_NaturalDesign)
						){ EPN.PH_Machine, EPN.C_PermanentEmployment, EPN.C_AugmentationBazaars, EPN.C_Bodysnatcher},
					GrantedTraits = new[] { EPN.T_MalleableGenes }
				}
			},{
				EPN.O_FruitfulPartnership,
				new Origin(EPN.O_FruitfulPartnership,new[]{ EPN.D_Plantoids}.ToOrSet())
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.PH_Plantoid}, new OrSet() { EPN.Pacifist, EPN.PacifistF, EPN.Xenophile, EPN.XenophileF, EPN.A_HiveMind}},
					Prohibits = new AndSet(){ EPN.A_MachineIntelligence, EPN.C_DevouringSwarm }
				}
			},{
				EPN.O_CalamitousBirth,
				new Origin(EPN.O_CalamitousBirth,new[]{ EPN.D_Lithoids}.ToOrSet())
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.PH_Lithoid}},
					Prohibits = new AndSet(EPNSET.HS_Catalytic
						.Union<string>(EPNSET.HS_GenesisGuides)
						.Union<string>(EPNSET.HS_Planetscapers)
						){ EPN.S_Biological }
				}
			},
			{
				EPN.O_ArcWelders,
				new Origin(EPN.O_ArcWelders,new[]{ EPN.D_MachineAge}.ToOrSet())
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.PH_Machine}},
				}
			},{
				EPN.O_TreeofLife,
				new Origin(EPN.O_TreeofLife,new[]{ EPN.D_Utopia}.ToOrSet())
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind }},
					Prohibits = new AndSet(){ EPN.C_DevouringSwarm, EPN.C_Terravore }
				}
			},{
				EPN.O_ProgenitorHive,
				new Origin(EPN.O_ProgenitorHive,new[]{ EPN.D_Overlord}.ToOrSet())
				{
					Requires = new HashSet<OrSet>(){ new OrSet() {EPN.A_HiveMind }} ,
					Prohibits = new AndSet(){ EPN.C_WildSwarm }
				}
			},{
				EPN.O_ResourceConsolidation,
				new Origin(EPN.O_ResourceConsolidation,new[]{ EPN.D_SyntheticDawn}.ToOrSet())
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_MachineIntelligence }},
					Prohibits = new AndSet(){ EPN.C_RogueServitor, EPN.C_OrganicRetrofitting, EPN.C_GenesisArchitects, EPN.C_GardeningProtocols },
					PlanetType = EPN.PT_Machine
				}
			},
			{
				EPN.O_Wilderness,
				new Origin(EPN.O_Wilderness, new[]{ EPN.D_Biogenesis }.ToOrSet())
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind, EPN.S_Biological }},
					Prohibits = new AndSet(){ EPN.C_OrganicReprocessing, EPN.C_MemorialistHM, EPN.C_PermutationPools,
						EPN.C_GenesisSymbiotes, EPN.C_ClimateModelingHM, EPN.C_CultivationDrones },
					GrantedTraits = new[] { EPN.T_Wilderness }
				}
			},
		};


		#endregion

		public Origin(String name, HashSet<OrSet>? dlc = null,
			HashSet<OrSet>? requirements = null, AndSet? prohibitions = null)
			: base(name, EmpirePropertyType.Origin, dlc, requirements, prohibitions) { }
	}
}