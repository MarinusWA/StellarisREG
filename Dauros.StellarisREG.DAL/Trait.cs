using System;
using System.Collections.Generic;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
	public class Trait : EmpireProperty
	{
		public int Cost { get; set; }
		public bool CountsToCap => Cost != 0;


		public static Dictionary<String, Trait> Collection { get; } = new Dictionary<string, Trait>()
		{
			#region Biological
			#region Basic
			{
				EPN.T_HiveMinded,
				new Trait(EPN.T_HiveMinded,
					prohibitions: new AndSet(){EPN.T_Conformists, EPN.T_Conservationist, EPN.T_Thrifty, EPN.T_Familial,
					EPN.T_Deviants, EPN.T_Wasteful, EPN.T_Decadent}
				)
				{
					Cost = 0
				}
			},
			{
				EPN.T_Lithoid,
				new Trait(EPN.T_Lithoid,
					prohibitions: new AndSet(){ EPN.T_ExtremelyAdaptive, EPN.T_Nonadaptive, EPN.T_RapidBreeders, EPN.T_Agrarian,
					EPN.T_Nonadaptive, EPN.T_SlowBreeders, EPN.T_PsychoInfertility }
				)
				{
					Cost = 0
				}
			},
			{
				EPN.T_Aquatic,
				new Trait(EPN.T_Aquatic,
					prohibitions: new AndSet(){ EPN.T_CaveDweller }
				)
				{
					Cost = 2
				}
			},
			#endregion
			#region Positive
			{
				EPN.T_Adaptive,
				new Trait(EPN.T_Adaptive,
					prohibitions: new AndSet(){ EPN.T_ExtremelyAdaptive, EPN.T_Nonadaptive }
				)
				{
					Cost = 2
				}
			},
			{
				EPN.T_ExtremelyAdaptive,
				new Trait(EPN.T_ExtremelyAdaptive,
					prohibitions: new AndSet(){ EPN.T_Adaptive, EPN.T_Nonadaptive }
					)
				{
					Cost = 4
				}
			},
			{
				EPN.T_Agrarian,
				new Trait(EPN.T_Agrarian, prohibitions : new AndSet() { EPN.AT_Lithoid})
				{
					Cost = 2
				}
			},
			{
				EPN.T_Charismatic,
				new Trait(EPN.T_Charismatic, prohibitions : new AndSet() { EPN.T_Repugnant })
				{
					Cost = 2
				}
			},
			{
				EPN.T_Communal,
				new Trait(EPN.T_Communal, prohibitions : new AndSet() { EPN.T_Solitary })
				{
					Cost = 1
				}
			},
			{
				EPN.T_Conformists,
				new Trait(EPN.T_Conformists, prohibitions : new AndSet() { EPN.T_Deviants, EPN.A_HiveMind })
				{
					Cost = 2
				}
			},
			{
				EPN.T_Conservationist,
				new Trait(EPN.T_Conservationist, prohibitions : new AndSet() { EPN.T_Wasteful, EPN.A_HiveMind })
				{
					Cost = 1
				}
			},
			{
				EPN.T_Docile,
				new Trait(EPN.T_Docile, prohibitions : new AndSet() { EPN.T_Unruly })
				{
					Cost = 2
				}
			},
			{
				EPN.T_Enduring,
				new Trait(EPN.T_Enduring, prohibitions : new AndSet() { EPN.T_Venerable, EPN.T_Fleeting })
				{
					Cost = 1
				}
			},
			{
				EPN.T_Venerable,
				new Trait(EPN.T_Venerable, prohibitions : new AndSet() { EPN.T_Enduring, EPN.T_Fleeting })
				{
					Cost = 4
				}
			},
			{
				EPN.T_Industrious,
				new Trait(EPN.T_Industrious)
				{
					Cost = 2
				}
			},
			{
				EPN.T_Ingenious,
				new Trait(EPN.T_Ingenious)
				{
					Cost = 2
				}
			},
			{
				EPN.T_Intelligent,
				new Trait(EPN.T_Intelligent)
				{
					Cost = 2
				}
			},
			{
				EPN.T_NaturalEngineers,
				new Trait(EPN.T_NaturalEngineers, prohibitions : new AndSet() { EPN.T_NaturalPhysicists, EPN.T_NaturalSociologists })
				{
					Cost = 1
				}
			},
			{
				EPN.T_NaturalPhysicists,
				new Trait(EPN.T_NaturalPhysicists, prohibitions : new AndSet() { EPN.T_NaturalEngineers, EPN.T_NaturalSociologists })
				{
					Cost = 1
				}
			},
			{
				EPN.T_NaturalSociologists,
				new Trait(EPN.T_NaturalSociologists,prohibitions : new AndSet() { EPN.T_NaturalPhysicists, EPN.T_NaturalEngineers })
				{
					Cost = 1
				}
			},
			{
				EPN.T_Nomadic,
				new Trait(EPN.T_Nomadic, prohibitions : new AndSet() { EPN.T_Sedentary })
				{
					Cost = 1
				}
			},
			{
				EPN.T_QuickLearners,
				new Trait(EPN.T_QuickLearners, prohibitions : new AndSet() { EPN.T_SlowLearners })
				{
					Cost = 1
				}
			},
			{
				EPN.T_RapidBreeders,
				new Trait(EPN.T_RapidBreeders,
					prohibitions : new AndSet() { EPN.T_SlowBreeders, EPN.T_Incubators, EPN.T_Budding, EPN.T_Crystallization,
					EPN.T_EggLaying, EPN.T_ExistentialIteroparity})
				{
					Cost = 2
				}
			},
			{
				EPN.T_Resilient,
				new Trait(EPN.T_Resilient)
				{
					Cost = 1
				}
			},
			{
				EPN.T_Strong,
				new Trait(EPN.T_Strong,
					prohibitions: new AndSet(){ EPN.T_VeryStrong,EPN.T_Weak })
				{
					Cost = 1
				}
			},
			{
				EPN.T_VeryStrong,
				new Trait(EPN.T_VeryStrong,
					prohibitions: new AndSet(){ EPN.T_Strong,EPN.T_Weak })
				{
					Cost = 3
				}
			},
			{
				EPN.T_Talented,
				new Trait(EPN.T_Talented)
				{
					Cost = 1
				}
			},
			{
				EPN.T_Thrifty,
				new Trait(EPN.T_Thrifty, prohibitions : new AndSet() { EPN.A_HiveMind })
				{
					Cost = 2
				}
			},
			{
				EPN.T_Traditional,
				new Trait(EPN.T_Traditional,
					prohibitions: new AndSet(){ EPN.T_Quarrelsome })
				{
					Cost = 1
				}
			},
			{
				EPN.T_ExistentialIteroparity,
				new Trait(EPN.T_ExistentialIteroparity,
					dlc: new [] { EPN.D_Humanoids }.ToOrSet(),
					prohibitions : new AndSet() { EPN.T_PsychoInfertility, EPN.T_Incubators, EPN.T_Budding, EPN.T_Crystallization,
					EPN.T_EggLaying, EPN.T_RapidBreeders})
				{
					Cost = 2
				}
			},
			{
				EPN.T_Incubators,
				new Trait(EPN.T_Incubators,
					dlc: new [] { EPN.D_Toxoids }.ToOrSet(),
					prohibitions : new AndSet() { EPN.T_SlowBreeders, EPN.T_ExistentialIteroparity, EPN.T_Budding, EPN.T_Crystallization,
					EPN.T_EggLaying, EPN.T_RapidBreeders})
				{
					Cost = 2
				}
			},
			{
				EPN.T_Noxious,
				new Trait(EPN.T_Noxious,
					dlc: new [] { EPN.D_Toxoids }.ToOrSet())
				{
					Cost = 1
				}
			},
			{
				EPN.T_InorganicBreath,
				new Trait(EPN.T_InorganicBreath,
					dlc: new [] { EPN.D_Toxoids }.ToOrSet())
				{
					Cost = 3
				}
			},
			#region Phenotype
			{
				EPN.T_Phototrophic,
				new Trait(EPN.T_Phototrophic,
					dlc: new [] {EPN.D_Plantoids }.ToOrSet(),
					requirements: new[] { EPN.PH_Plantoid, EPN.PH_Fungoid }.ToOrSet(),
					prohibitions: new AndSet(){EPN.T_Radiotrophic,EPN.T_Voidling, EPN.T_CaveDweller })
				{
					Cost = 1
				}
			},
			{
				EPN.T_Radiotrophic,
				new Trait(EPN.T_Radiotrophic,
					dlc: new [] {EPN.D_Plantoids }.ToOrSet(),
					requirements: new[] { EPN.PH_Plantoid, EPN.PH_Fungoid, EPN.PH_Lithoid }.ToOrSet(),
					prohibitions: new AndSet(){EPN.T_Phototrophic, EPN.T_Voidling})
				{
					Cost = 2
				}
			},
			{
				EPN.T_InvSpecies,
				new Trait(EPN.T_InvSpecies,
					dlc: new [] {EPN.D_Plantoids }.ToOrSet(),
					requirements: new[] { EPN.PH_Plantoid, EPN.PH_Fungoid }.ToOrSet(),
					prohibitions: new AndSet(){EPN.T_Adaptive, EPN.T_ExtremelyAdaptive, EPN.T_Agrarian, EPN.T_Charismatic, EPN.T_Communal,
					EPN.T_Conformists, EPN.T_Conservationist, EPN.T_Docile, EPN.T_Enduring, EPN.T_Venerable, EPN.T_Industrious, EPN.T_Ingenious,
					EPN.T_Intelligent, EPN.T_NaturalEngineers, EPN.T_NaturalPhysicists, EPN.T_NaturalSociologists, EPN.T_Nomadic, EPN.T_QuickLearners,
					EPN.T_RapidBreeders, EPN.T_Resilient, EPN.T_Strong, EPN.T_VeryStrong, EPN.T_Talented, EPN.T_Thrifty, EPN.T_Traditional,
					EPN.T_ExistentialIteroparity,EPN.T_Incubators, EPN.T_Noxious, EPN.T_InorganicBreath})
				{
					Cost = 2
				}
			},
			{
				EPN.T_Budding,
				new Trait(EPN.T_Budding,
					dlc: new [] {EPN.D_Plantoids }.ToOrSet(),
					requirements: new[] { EPN.PH_Plantoid, EPN.PH_Fungoid }.ToOrSet(),
					prohibitions: new AndSet(){EPN.T_SlowBreeders, EPN.T_RapidBreeders, EPN.T_ExistentialIteroparity,EPN.T_Incubators,
					EPN.T_Crystallization, EPN.T_EggLaying,EPN.T_Polymelic})
				{
					Cost = 2
				}
			},
			{
				EPN.T_Crystallization,
				new Trait(EPN.T_Crystallization,
					dlc: new [] {EPN.D_Plantoids }.ToOrSet(),
					requirements: new[] { EPN.PH_Lithoid }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_SlowBreeders, EPN.T_RapidBreeders, EPN.T_ExistentialIteroparity,EPN.T_Incubators,
					EPN.T_Budding, EPN.T_EggLaying,EPN.T_Polymelic }
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_GaseousByproducts,
				new Trait(EPN.T_GaseousByproducts,
					dlc: new [] {EPN.D_Lithoids }.ToOrSet(),
					requirements: new[] { EPN.PH_Lithoid }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_DrakeScaled, EPN.T_ScintillatingSkin, EPN.T_VolatileExcretions }
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_ScintillatingSkin,
				new Trait(EPN.T_ScintillatingSkin,
					dlc: new [] {EPN.D_Lithoids }.ToOrSet(),
					requirements: new[] { EPN.PH_Lithoid }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_DrakeScaled, EPN.T_GaseousByproducts, EPN.T_VolatileExcretions }
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_VolatileExcretions,
				new Trait(EPN.T_VolatileExcretions,
					dlc: new [] {EPN.D_Lithoids }.ToOrSet(),
					requirements: new[] { EPN.PH_Lithoid }.ToOrSet(),
					prohibitions: new AndSet(){EPN.T_DrakeScaled, EPN.T_GaseousByproducts,EPN.T_ScintillatingSkin }
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_Familial,
				new Trait(EPN.T_Familial,
					dlc: new [] {EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Humanoid, EPN.PH_Mammalian,EPN.PH_Avian }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.A_HiveMind }
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_GeneticMemory,
				new Trait(EPN.T_GeneticMemory,
					dlc: new [] {EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Humanoid, EPN.PH_Mammalian, EPN.PH_Necroid }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_Nonadaptive}
					)
				{
					Cost = 3
				}
			},
			{
				EPN.T_Camouflage,
				new Trait(EPN.T_Camouflage,
					dlc: new [] {EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Arthropoid, EPN.PH_Reptilian, EPN.PH_Aquatic }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_Chromalogs, EPN.T_NaturalPhysicists, EPN.T_NerveStapled }
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_Chromalogs,
				new Trait(EPN.T_Chromalogs,
					dlc: new [] {EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Arthropoid, EPN.PH_Reptilian, EPN.PH_Aquatic }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_Camouflage, EPN.T_NaturalPhysicists, EPN.T_NerveStapled }
					)
				{
					Cost = 4
				}
			},
			{
				EPN.T_EggLaying,
				new Trait(EPN.T_EggLaying,
					dlc: new [] {EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Avian, EPN.PH_Reptilian, EPN.PH_Aquatic }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_SlowBreeders, EPN.T_RapidBreeders, EPN.T_ExistentialIteroparity,
					EPN.T_Incubators, EPN.T_Budding, EPN.T_Crystallization, EPN.T_Polymelic}
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_SpareOrgans,
				new Trait(EPN.T_SpareOrgans,
					dlc: new [] {EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Molluscoid, EPN.PH_Necroid, EPN.PH_Toxoid  }.ToOrSet()
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_SeasonalDormancy,
				new Trait(EPN.T_SeasonalDormancy,
					dlc: new [] {EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Mammalian, EPN.PH_Reptilian }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_Wasteful, EPN.T_Conservationist, EPN.T_LowMaintenance}
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_Flight,
				new Trait(EPN.T_Flight,
					dlc: new [] {EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Avian, EPN.PH_Arthropoid }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_SpatialMastery, EPN.T_Communal, EPN.T_Shelled}
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_SpatialMastery,
				new Trait(EPN.T_SpatialMastery,
					dlc: new [] {EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Avian, EPN.PH_Arthropoid }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_Flight, EPN.T_Communal, EPN.T_Shelled }
					)
				{
					Cost = 4
				}
			},
			{
				EPN.T_Shelled,
				new Trait(EPN.T_Shelled,
					dlc: new [] {EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Molluscoid, EPN.PH_Necroid }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_SpatialMastery, EPN.T_Flight}
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_AcidicVascularity,
				new Trait(EPN.T_AcidicVascularity,
					dlc: new [] {EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Necroid, EPN.PH_Toxoid }.ToOrSet()
					)
				{
					Cost = 1
				}
			},

			#endregion
			#endregion
			#region Negative
			{
				EPN.T_Decadent,
				new Trait(EPN.T_Decadent,
					prohibitions: new AndSet(){ EPN.T_HiveMinded}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Deviants,
				new Trait(EPN.T_Deviants,
					prohibitions: new AndSet(){ EPN.T_HiveMinded, EPN.T_Conformists}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Fleeting,
				new Trait(EPN.T_Fleeting,
					prohibitions: new AndSet(){ EPN.T_Enduring, EPN.T_Venerable}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Nonadaptive,
				new Trait(EPN.T_Nonadaptive,
					prohibitions: new AndSet(){EPN.T_Adaptive, EPN.T_ExtremelyAdaptive, EPN.T_Lithoid}
					)
				{
					Cost = -2
				}
			},
			{
				EPN.T_Sedentary,
				new Trait(EPN.T_Sedentary,
					prohibitions: new AndSet(){ EPN.T_Nomadic}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Quarrelsome,
				new Trait(EPN.T_Quarrelsome,
					prohibitions: new AndSet(){ EPN.T_Traditional}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Repugnant,
				new Trait(EPN.T_Repugnant,
					prohibitions: new AndSet(){ EPN.T_Charismatic}
					)
				{
					Cost = -2
				}
			},
			{
				EPN.T_SlowBreeders,
				new Trait(EPN.T_SlowBreeders,
					prohibitions: new AndSet(){ EPN.T_RapidBreeders, EPN.T_ExistentialIteroparity, EPN.T_Incubators,
					EPN.T_Budding, EPN.T_Crystallization, EPN.T_EggLaying, EPN.T_Lithoid,EPN.T_NascentStage}
					)
				{
					Cost = -2
				}
			},
			{
				EPN.T_SlowLearners,
				new Trait(EPN.T_SlowLearners,
					prohibitions: new AndSet(){EPN.T_QuickLearners}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Solitary,
				new Trait(EPN.T_Solitary,
					prohibitions: new AndSet(){ EPN.T_Communal}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Unruly,
				new Trait(EPN.T_Unruly,
					prohibitions: new AndSet(){ EPN.T_Docile}
					)
				{
					Cost = -2
				}
			},
			{
				EPN.T_Wasteful,
				new Trait(EPN.T_Wasteful,
					prohibitions: new AndSet(){ EPN.T_HiveMinded, EPN.T_Conservationist}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Weak,
				new Trait(EPN.T_Weak,
					prohibitions: new AndSet(){ EPN.T_Strong, EPN.T_VeryStrong, EPN.T_HollowBones}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Jinxed,
				new Trait(EPN.T_Jinxed, 
					dlc: new[]{ EPN.D_Humanoids }.ToOrSet())
				{
					Cost = -1
				}
			},
			{
				EPN.T_PsychoInfertility,
				new Trait(EPN.T_PsychoInfertility,
					dlc: new[]{ EPN.D_Humanoids }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_ExistentialIteroparity, EPN.T_NascentStage}
					)
				{
					Cost = -2
				}
			},
			#region Phenotype
			{
				EPN.T_NascentStage,
				new Trait(EPN.T_NascentStage,
					dlc: new[]{ EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Humanoid, EPN.PH_Mammalian, EPN.PH_Reptilian, EPN.PH_Arthropoid }.ToOrSet(),
					prohibitions: new AndSet(){EPN.T_SlowBreeders, EPN.T_PsychoInfertility, EPN.T_PathogenicGenes}
					)
				{
					Cost = -2
				}
			},
			{
				EPN.T_PermeableSkin,
				new Trait(EPN.T_PermeableSkin,
					dlc: new[]{ EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Molluscoid, EPN.PH_Aquatic }.ToOrSet(),
					prohibitions: new AndSet(){EPN.T_Adaptive, EPN.T_ExtremelyAdaptive,
					EPN.PT_Ecumenopolis, EPN.PT_Gaia, EPN.PT_Habitat, EPN.PT_HiveWorld, EPN.PT_Machine, EPN.PT_NaniteWorld,
					EPN.PT_Relic,EPN.PT_RingWorld,EPN.PT_SynapticLathe,EPN.PT_Tomb}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_HollowBones,
				new Trait(EPN.T_HollowBones,
					dlc: new[]{ EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Avian, EPN.PH_Toxoid }.ToOrSet(),
					prohibitions: new AndSet(){EPN.T_Strong, EPN.T_VeryStrong,EPN.T_Weak}
					)
				{
					Cost = -3
				}
			},
			{
				EPN.T_Rooted,
				new Trait(EPN.T_Rooted,
					dlc: new[]{ EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Fungoid, EPN.PH_Plantoid }.ToOrSet(),
					prohibitions: new AndSet(){EPN.T_Nomadic, EPN.T_Sedentary}
					)
				{
					Cost = -3
				}
			},
			{
				EPN.T_Brittle,
				new Trait(EPN.T_Brittle,
					dlc: new[]{ EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Lithoid, EPN.PH_Necroid }.ToOrSet()
					)
				{
					Cost = -3
				}
			},
			#endregion
			#endregion
			#region Granted Traits
			//These don't have requirements set because the only way they can be added to the SelectState is through the GrantedTrait property
			//So these traits will always have their requirements set on the selectstate
			//TODO: add Serviles
			{
				EPN.T_Survivor,
				new Trait(EPN.T_Survivor,
					dlc: new[]{ EPN.D_Apocalypse }.ToOrSet())
				{
					Cost = 0
				}
			},
			{
				EPN.T_VoidDweller,
				new Trait(EPN.T_VoidDweller,
					dlc: new[]{ EPN.D_Federations }.ToOrSet())
				{
					Cost = 0
				}
			},
			{
				EPN.T_Necrophage,
				new Trait(EPN.T_Necrophage,
					dlc: new[]{ EPN.D_Necroids }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_Budding, EPN.T_Crystallization,
						EPN.T_PsychoInfertility, EPN.T_VatGrown, EPN.T_Polymelic })
				{
					Cost = 0
				}
			},
			{
				EPN.T_CaveDweller,
				new Trait(EPN.T_CaveDweller,
					dlc: new[]{ EPN.D_Overlord }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_Phototrophic, EPN.T_Aquatic })
				{
					Cost = 0
				}
			},
			{
				EPN.T_PerfectedGenes,
				new Trait(EPN.T_PerfectedGenes,
					dlc: new[]{ EPN.D_GalParagons }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_Fleeting, EPN.T_Weak})
				{
					Cost = 0
				}
			},
			{
				EPN.T_PathogenicGenes,
				new Trait(EPN.T_PathogenicGenes,
					dlc: new[]{ EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_RapidBreeders, EPN.T_ExistentialIteroparity,EPN.T_Incubators,
					EPN.T_Budding, EPN.T_Crystallization, EPN.T_EggLaying, EPN.T_Nomadic, EPN.T_Adaptive, EPN.T_ExtremelyAdaptive,
					EPN.T_SlowBreeders, EPN.T_PsychoInfertility, EPN.T_Sedentary, EPN.T_Nonadaptive, EPN.T_NascentStage})
				{
					Cost = -1
				}
			},
			{
				EPN.T_MalleableGenes,
				new Trait(EPN.T_MalleableGenes,
					dlc: new[]{ EPN.D_Biogenesis }.ToOrSet())
				{
					Cost = 6
				}
			},
			{
				EPN.T_Wilderness,
				new Trait(EPN.T_Wilderness,
					dlc: new[]{ EPN.D_Biogenesis }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_Nomadic, EPN.T_Incubators, EPN.T_Sedentary, EPN.T_NascentStage})
				{
					Cost = 0
				}
			},
			{
				EPN.T_Stargazer,
				new Trait(EPN.T_Stargazer,
					dlc: new[]{ EPN.D_FirstContact }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_Sedentary}
					)
				{
					Cost = 0
				}
			},
			{
				EPN.T_StormTouched,
				new Trait(EPN.T_StormTouched,
					dlc: new[]{ EPN.D_CosmicStorms }.ToOrSet())
				{
					Cost = 0
				}
			},
			{
				EPN.T_CyberCommandos,
				new Trait(EPN.T_StormTouched,
					dlc: new[]{ EPN.D_SyntheticDawn }.ToOrSet())
				{
					Cost = 0
				}
			},
			{
				EPN.T_Unplugged,
				new Trait(EPN.T_Unplugged,
					dlc: new[]{ EPN.D_SyntheticDawn }.ToOrSet())
				{
					Cost = 0
				}
			},
			{
				EPN.T_CloneSoldier,
				new Trait(EPN.T_CloneSoldier,
					dlc: new[]{ EPN.D_Humanoids }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_RapidBreeders, EPN.T_ExistentialIteroparity, EPN.T_Budding,
						EPN.T_Crystallization, EPN.T_EggLaying, EPN.T_SlowBreeders, EPN.T_PsychoInfertility, EPN.T_Polymelic }
					)
				{
					Cost = 0
				}
			},
			{
				EPN.T_RitualisticImplants,
				new Trait(EPN.T_RitualisticImplants,
					dlc: new[]{ EPN.D_MachineAge }.ToOrSet())
				{
					Cost = 0
				}
			},
			#endregion

			#region Overtuned
			{
				EPN.T_AugmentedIntelligence,
				new Trait(EPN.T_AugmentedIntelligence,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_CommercialGenius,
				new Trait(EPN.T_CommercialGenius,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet())
				{
					Cost = 1
				}
			},
			{
				EPN.T_CraftedSmiles,
				new Trait(EPN.T_CraftedSmiles,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_DedicatedMiner,
				new Trait(EPN.T_DedicatedMiner,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_ExpressedTradition,
				new Trait(EPN.T_ExpressedTradition,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_FarmAppendages,
				new Trait(EPN.T_FarmAppendages,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_GeneMentorship,
				new Trait(EPN.T_GeneMentorship,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_JuicedPower,
				new Trait(EPN.T_JuicedPower,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_LowMaintenance,
				new Trait(EPN.T_LowMaintenance,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_SplicedAdaptability,
				new Trait(EPN.T_SplicedAdaptability,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_TechnicalTalent,
				new Trait(EPN.T_TechnicalTalent,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_FleetingExcellence,
				new Trait(EPN.T_FleetingExcellence,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_ElevatedSynapses,
				new Trait(EPN.T_ElevatedSynapses,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_PrePlannedGrowth,
				new Trait(EPN.T_PrePlannedGrowth,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_ExcessiveEndurance,
				new Trait(EPN.T_ExcessiveEndurance,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 3
				}
			},

			#endregion
			#endregion

			#region Machine

			#endregion
		};

		public Trait(String name, HashSet<OrSet>? dlc = null,
			HashSet<OrSet>? requirements = null, AndSet? prohibitions = null)
			: base(name, EmpirePropertyType.Trait, dlc, requirements, prohibitions) { }
	}
}
