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
				new Origin(EPN.O_Remnants, true, EPN.D_AncientRelics, EPN.D_Federations)
				{
					Prohibits = new AndSet(EPNSET.HS_Planetscapers){ EPN.C_AgrarianIdyll }
				}
			},{
                EPN.O_Mechanist,
                new Origin(EPN.O_Mechanist, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.Materialist, EPN.MaterialistF }},
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.AT_Machine, EPN.C_PermanentEmployment }
                }
            },{
                EPN.O_SyncreticEvolution,
                new Origin(EPN.O_SyncreticEvolution, EPN.D_Utopia)
                {
                    Prohibits = new AndSet(EPNSET.HS_GenesisGuides){ EPN.Gestalt, EPN.C_FanaticPurifiers }
                }
            },{
				EPN.O_HardReset,
				new Origin(EPN.O_HardReset, EPN.D_SyntheticDawn)
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
					}
				}
			},{
				EPN.O_LifeSeeded,
				new Origin(EPN.O_LifeSeeded, EPN.D_Apocalypse)
				{
					Prohibits = new AndSet(EPNSET.HS_RelentlessIndustrialists
                        .Union<string>(EPNSET.HS_MutagenicSpas)
						.Union<string>(EPNSET.HS_GenesisGuides)
						){ }
				}
			},{
				EPN.O_PostApocalyptic,
				new Origin(EPN.O_PostApocalyptic, EPN.D_Apocalypse)
				{
					Prohibits = new AndSet(EPNSET.HS_Anglers
                        .Union<string>(EPNSET.HS_Planetscapers)
                        ){ EPN.AT_Machine, EPN.C_AgrarianIdyll, }
				}
			},{
				EPN.O_RadioactiveRovers,
				new Origin(EPN.O_RadioactiveRovers, EPN.D_Apocalypse)
				{
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.AT_Machine }},
					Prohibits = new AndSet(EPNSET.HS_Anglers
						.Union<string>(EPNSET.HS_Planetscapers)
						){ EPN.C_AgrarianIdyll, }
				}
			},{
				EPN.O_CloneArmy,
				new Origin(EPN.O_CloneArmy, EPN.D_Humanoids)
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.AT_Machine, EPN.C_NaturalDesign, EPN.C_PermanentEmployment }
				}
			},{
				EPN.O_CommonGround,
				new Origin(EPN.O_CommonGround, EPN.D_Federations)
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal)
                    { EPN.Xenophobe,EPN.XenophobeF, EPN.C_InwardPerfection, EPN.C_BarbaricDespoilers }
				}
			},{
				EPN.O_Hegemon,
				new Origin(EPN.O_Hegemon, EPN.D_Federations)
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal)
                    { EPN.Xenophobe, EPN.XenophobeF, EPN.Egalitarian,EPN.EgalitarianF,  EPN.C_InwardPerfection }
				}
			},{
				EPN.O_Doomsday,
				new Origin(EPN.O_Doomsday, EPN.D_Federations){ }
			},{
				EPN.O_Giants,
				new Origin(EPN.O_Giants, EPN.D_Federations)
				{
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.AT_Machine }
				}
			},{
				EPN.O_Scion,
				new Origin(EPN.O_Scion, EPN.D_Federations)
				{
					Prohibits = new AndSet(){ EPN.XenophobeF, EPN.Gestalt, EPN.C_PompousPurists, EPN.AT_Machine }
				}
			},{
				EPN.O_ShatteredRing,
				new Origin(EPN.O_ShatteredRing, EPN.D_Federations)
				{
					Prohibits = new AndSet(EPNSET.HS_Anglers
                        .Union<string>(EPNSET.HS_Planetscapers)
                        ){ EPN.C_AgrarianIdyll}
				}
			},{
				EPN.O_VoidDwellers,
				new Origin(EPN.O_VoidDwellers, EPN.D_Federations)
				{
					Prohibits = new AndSet(EPNSET.HS_Anglers
                        .Union<string>(EPNSET.HS_IdyllicBloom)
						.Union<string>(EPNSET.HS_Planetscapers)
						){ EPN.C_AgrarianIdyll}
				}
			},{
				EPN.O_Necrophage,
				new Origin(EPN.O_Necrophage, EPN.D_Necroids)
				{
					Prohibits = new AndSet(EPNSET.HS_DeathCult){ EPN.AT_Machine, EPN.Xenophile,EPN.XenophileF,EPN.EgalitarianF,
                    EPN.C_PermanentEmployment, EPN.C_Empath, EPN.C_Bodysnatcher}
				}
			}
			,{
				EPN.O_HereBeDragons,
				new Origin(EPN.O_HereBeDragons, EPN.D_Aquatics)
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal){  }
				}
			}
			,{
				EPN.O_OceanParadise,
				new Origin(EPN.O_OceanParadise, EPN.D_Aquatics)
				{
					Prohibits = new AndSet(){ }
				}
			},{
				EPN.O_KnightsToxicGod,
				new Origin(EPN.O_KnightsToxicGod, EPN.D_Toxoids)
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal){ EPN.Gestalt, EPN.AT_Machine, EPN.C_OppressiveAutocracy }
				}
			},{
				EPN.O_Overtuned,
				new Origin(EPN.O_Overtuned, EPN.D_Toxoids)
				{
					Prohibits = new AndSet(EPNSET.HS_NaturalDesign){ EPN.AT_Machine }
				}
			},{
				EPN.O_ImperialFiefdom,
				new Origin(EPN.O_ImperialFiefdom, EPN.D_Overlord)
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal){ EPN.C_InwardPerfection, EPN.C_DrivenAssimilator }
				}
			},{
				EPN.O_SlingshotStars,
				new Origin(EPN.O_SlingshotStars, EPN.D_Overlord)
				{

				}
			},{
				EPN.O_Subterranean,
				new Origin(EPN.O_Subterranean, EPN.D_Overlord)
				{
					Prohibits = new AndSet(){  }
				}
			},{
				EPN.O_BrokenShackles,
				new Origin(EPN.O_BrokenShackles, EPN.D_FirstContact)
				{
					Prohibits = new AndSet(EPNSET.HS_SovereignGuardianship
						.Union<string>(EPNSET.HS_EagerExplorers)
						){ EPN.Authoritarian, EPN.AuthoritarianF, EPN.Xenophobe, EPN.XenophobeF, 
						EPN.Gestalt, EPN.AT_Machine, EPN.C_SelectiveKinship, EPN.C_PharmaState }
				}
			},{
				EPN.O_Payback,
				new Origin(EPN.O_Payback, EPN.D_FirstContact)
				{
					Prohibits = new AndSet(EPNSET.HS_SovereignGuardianship
						.Union<string>(EPNSET.HS_Genocidal)
						.Union<string>(EPNSET.HS_EagerExplorers)
						){ EPN.Gestalt, EPN.AT_Machine, EPN.C_SlaverGuilds, EPN.C_PompousPurists,
					EPN.C_OppressiveAutocracy, EPN.C_PharmaState}
				}
			},{
				EPN.O_FearDark,
				new Origin(EPN.O_FearDark, EPN.D_FirstContact)
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal
						.Union<string>(EPNSET.HS_EagerExplorers)
						.Union<string>(EPNSET.HS_SovereignGuardianship)
						){ EPN.Gestalt, EPN.AT_Machine, EPN.C_InwardPerfection, EPN.S_Biological }
				}
			},
			{
				EPN.O_UnderOneRule,
				new Origin(EPN.O_UnderOneRule, EPN.D_GalParagons)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() {EPN.A_Dictatorial }},
					Prohibits = new AndSet(){ EPN.Gestalt, EPN.AT_Machine }
				}
			},{
				EPN.O_Riftworld,
				new Origin(EPN.O_Riftworld, EPN.D_AstralPlanes)
				{

				}
			},{
				EPN.O_StormChasers,
				new Origin(EPN.O_StormChasers, EPN.D_CosmicStorms)
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal) { }
				}
			},
			{
				EPN.O_PrimalCalling,
				new Origin(EPN.O_PrimalCalling, EPN.D_GrandArchive)
				{
					Prohibits = new AndSet()
					{ EPN.AT_Machine }
				}
			},
			{
				EPN.O_TreasureHunters,
				new Origin(EPN.O_TreasureHunters, EPN.D_GrandArchive)
				{
					Prohibits = new AndSet(EPNSET.HS_Genocidal) { }
				}
			},
			{
				EPN.O_StarlitCitadel,
				new Origin(EPN.O_StarlitCitadel, EPN.D_Biogenesis)
				{
					Prohibits = new AndSet(){ EPN.S_Biological }
				}
			},{
				EPN.O_TeachersShroud,
				new Origin(EPN.O_TeachersShroud, EPN.D_Overlord)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() {EPN.Spiritualist, EPN.SpiritualistF } },
					Prohibits = new AndSet(EPNSET.HS_Genocidal){ EPN.AT_Machine, EPN.C_NaturalDesign, EPN.C_AugmentationBazaars}
				}
			},{
				EPN.O_CyberneticCreed,
				new Origin(EPN.O_CyberneticCreed, EPN.D_MachineAge)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() {EPN.Spiritualist, EPN.SpiritualistF } },
					Prohibits = new AndSet(){ EPN.AT_Machine, EPN.Egalitarian, EPN.EgalitarianF, EPN.C_NaturalDesign, EPN.C_PermanentEmployment }
				}
			},{
				EPN.O_SyntheticFertility,
				new Origin(EPN.O_SyntheticFertility, EPN.D_MachineAge)
				{
					Prohibits = new AndSet(EPNSET.HS_EagerExplorers
						.Union<string>(EPNSET.HS_Reanimators)
						.Union<string>(EPNSET.HS_MutagenicSpas)
						){ EPN.Gestalt, EPN.AT_Machine, EPN.Spiritualist, EPN.SpiritualistF,
						EPN.C_NaturalDesign, EPN.C_AugmentationBazaars}
				}
			},{
				EPN.O_EvolutionaryPredators,
				new Origin(EPN.O_EvolutionaryPredators, EPN.D_Biogenesis)
				{
					Prohibits = new AndSet(EPNSET.HS_IdyllicBloom
						.Union<string>(EPNSET.HS_NaturalDesign)
						){ EPN.AT_Machine, EPN.C_PermanentEmployment, EPN.C_AugmentationBazaars, EPN.C_Bodysnatcher}
				}
			},{
				EPN.O_FruitfulPartnership,
				new Origin(EPN.O_FruitfulPartnership, EPN.D_Plantoids)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() { EPN.AT_Plantoid}, new OrSet() { EPN.Pacifist, EPN.PacifistF, EPN.Xenophile, EPN.XenophileF, EPN.A_HiveMind}},
					Prohibits = new AndSet(){ EPN.A_MachineIntelligence, EPN.C_DevouringSwarm }
				}
			},{
				EPN.O_CalamitousBirth,
				new Origin(EPN.O_CalamitousBirth, EPN.D_Lithoids)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.AT_Lithoid}},
					Prohibits = new AndSet(EPNSET.HS_Catalytic
						.Union<string>(EPNSET.HS_GenesisGuides)
						.Union<string>(EPNSET.HS_Planetscapers)
						){ EPN.S_Biological }
				}
			},
			{
				EPN.O_ArcWelders,
				new Origin(EPN.O_ArcWelders, EPN.D_MachineAge)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.AT_Machine}},
				}
			},{
                EPN.O_TreeofLife,
                new Origin(EPN.O_TreeofLife, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind }},
                    Prohibits = new AndSet(){ EPN.C_DevouringSwarm, EPN.C_Terravore }
                }
            },{
				EPN.O_ProgenitorHive,
				new Origin(EPN.O_ProgenitorHive, EPN.D_Overlord)
				{
					Requires = new HashSet<OrSet>(){ new OrSet() {EPN.A_HiveMind }} ,
					Prohibits = new AndSet(){ EPN.C_WildSwarm }
				}
			},{
                EPN.O_ResourceConsolidation,
                new Origin(EPN.O_ResourceConsolidation, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_MachineIntelligence }},
                    Prohibits = new AndSet(){ EPN.C_RogueServitor, EPN.C_OrganicRetrofitting, EPN.C_GenesisArchitects, EPN.C_GardeningProtocols }
                }
            },
			{
				EPN.O_Wilderness,
				new Origin(EPN.O_Wilderness, EPN.D_Biogenesis)
				{
					Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind, EPN.S_Biological }},
					Prohibits = new AndSet(){ EPN.C_OrganicReprocessingHM, EPN.C_MemorialistHM, EPN.C_PermutationPools,
						EPN.C_GenesisSymbiotes, EPN.C_ClimateModeling, EPN.C_CultivationDrones }
				}
			},
		};


        #endregion

        public Origin(String name, bool inclusiveDLC, params String[] dlc) : base(name, EmpirePropertyType.Origin, inclusiveDLC, dlc) { }
        public Origin(String name, params String[] dlc) : base(name, EmpirePropertyType.Origin, false, dlc) { }
    }
}