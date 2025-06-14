﻿using System;
using System.Collections.Generic;
using System.Linq;
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
				new BiologicalTrait(EPN.T_HiveMinded,
					prohibitions: new AndSet(){EPN.T_Conformists, EPN.T_Conservationist, EPN.T_Thrifty, EPN.T_Familial,
					EPN.T_Deviants, EPN.T_Wasteful, EPN.T_Decadent}
				)
				{
					Cost = 0
				}
			},
			{
				EPN.T_Lithoid,
				new BiologicalTrait(EPN.T_Lithoid,
					prohibitions: new AndSet(){ EPN.T_ExtremelyAdaptive, EPN.T_Nonadaptive, EPN.T_RapidBreeders, EPN.T_Agrarian,
					EPN.T_Nonadaptive, EPN.T_SlowBreeders, EPN.T_PsychoInfertility }
				)
				{
					Cost = 0
				}
			},
			{
				EPN.T_Aquatic,
				new BiologicalTrait(EPN.T_Aquatic,
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
				new BiologicalTrait(EPN.T_Adaptive,
					prohibitions: new AndSet(){ EPN.T_ExtremelyAdaptive, EPN.T_Nonadaptive }
				)
				{
					Cost = 2
				}
			},
			{
				EPN.T_ExtremelyAdaptive,
				new BiologicalTrait(EPN.T_ExtremelyAdaptive,
					prohibitions: new AndSet(){ EPN.T_Adaptive, EPN.T_Nonadaptive }
					)
				{
					Cost = 4
				}
			},
			{
				EPN.T_Agrarian,
				new BiologicalTrait(EPN.T_Agrarian, prohibitions : new AndSet() { EPN.PH_Lithoid})
				{
					Cost = 2
				}
			},
			{
				EPN.T_Charismatic,
				new BiologicalTrait(EPN.T_Charismatic, prohibitions : new AndSet() { EPN.T_Repugnant })
				{
					Cost = 2
				}
			},
			{
				EPN.T_Communal,
				new BiologicalTrait(EPN.T_Communal, prohibitions : new AndSet() { EPN.T_Solitary })
				{
					Cost = 1
				}
			},
			{
				EPN.T_Conformists,
				new BiologicalTrait(EPN.T_Conformists, prohibitions : new AndSet() { EPN.T_Deviants, EPN.A_HiveMind })
				{
					Cost = 2
				}
			},
			{
				EPN.T_Conservationist,
				new BiologicalTrait(EPN.T_Conservationist, prohibitions : new AndSet() { EPN.T_Wasteful, EPN.A_HiveMind })
				{
					Cost = 1
				}
			},
			{
				EPN.T_Docile,
				new BiologicalTrait(EPN.T_Docile, prohibitions : new AndSet() { EPN.T_Unruly })
				{
					Cost = 2
				}
			},
			{
				EPN.T_Enduring,
				new BiologicalTrait(EPN.T_Enduring, prohibitions : new AndSet() { EPN.T_Venerable, EPN.T_Fleeting })
				{
					Cost = 1
				}
			},
			{
				EPN.T_Venerable,
				new BiologicalTrait(EPN.T_Venerable, prohibitions : new AndSet() { EPN.T_Enduring, EPN.T_Fleeting })
				{
					Cost = 4
				}
			},
			{
				EPN.T_Industrious,
				new BiologicalTrait(EPN.T_Industrious)
				{
					Cost = 2
				}
			},
			{
				EPN.T_Ingenious,
				new BiologicalTrait(EPN.T_Ingenious)
				{
					Cost = 2
				}
			},
			{
				EPN.T_Intelligent,
				new BiologicalTrait(EPN.T_Intelligent)
				{
					Cost = 2
				}
			},
			{
				EPN.T_NaturalEngineers,
				new BiologicalTrait(EPN.T_NaturalEngineers, prohibitions : new AndSet() { EPN.T_NaturalPhysicists, EPN.T_NaturalSociologists })
				{
					Cost = 1
				}
			},
			{
				EPN.T_NaturalPhysicists,
				new BiologicalTrait(EPN.T_NaturalPhysicists, prohibitions : new AndSet() { EPN.T_NaturalEngineers, EPN.T_NaturalSociologists })
				{
					Cost = 1
				}
			},
			{
				EPN.T_NaturalSociologists,
				new BiologicalTrait(EPN.T_NaturalSociologists,prohibitions : new AndSet() { EPN.T_NaturalPhysicists, EPN.T_NaturalEngineers })
				{
					Cost = 1
				}
			},
			{
				EPN.T_Nomadic,
				new BiologicalTrait(EPN.T_Nomadic, prohibitions : new AndSet() { EPN.T_Sedentary })
				{
					Cost = 1
				}
			},
			{
				EPN.T_QuickLearners,
				new BiologicalTrait(EPN.T_QuickLearners, prohibitions : new AndSet() { EPN.T_SlowLearners })
				{
					Cost = 1
				}
			},
			{
				EPN.T_RapidBreeders,
				new BiologicalTrait(EPN.T_RapidBreeders,
					prohibitions : new AndSet() { EPN.T_SlowBreeders, EPN.T_Incubators, EPN.T_Budding, EPN.T_Crystallization,
					EPN.T_EggLaying, EPN.T_ExistentialIteroparity})
				{
					Cost = 2
				}
			},
			{
				EPN.T_Resilient,
				new BiologicalTrait(EPN.T_Resilient)
				{
					Cost = 1
				}
			},
			{
				EPN.T_Strong,
				new BiologicalTrait(EPN.T_Strong,
					prohibitions: new AndSet(){ EPN.T_VeryStrong,EPN.T_Weak })
				{
					Cost = 1
				}
			},
			{
				EPN.T_VeryStrong,
				new BiologicalTrait(EPN.T_VeryStrong,
					prohibitions: new AndSet(){ EPN.T_Strong,EPN.T_Weak })
				{
					Cost = 3
				}
			},
			{
				EPN.T_Talented,
				new BiologicalTrait(EPN.T_Talented)
				{
					Cost = 1
				}
			},
			{
				EPN.T_Thrifty,
				new BiologicalTrait(EPN.T_Thrifty, prohibitions : new AndSet() { EPN.A_HiveMind })
				{
					Cost = 2
				}
			},
			{
				EPN.T_Traditional,
				new BiologicalTrait(EPN.T_Traditional,
					prohibitions: new AndSet(){ EPN.T_Quarrelsome })
				{
					Cost = 1
				}
			},
			{
				EPN.T_ExistentialIteroparity,
				new BiologicalTrait(EPN.T_ExistentialIteroparity,
					dlc: new [] { EPN.D_Humanoids }.ToOrSet(),
					prohibitions : new AndSet() { EPN.T_PsychoInfertility, EPN.T_Incubators, EPN.T_Budding, EPN.T_Crystallization,
					EPN.T_EggLaying, EPN.T_RapidBreeders})
				{
					Cost = 2
				}
			},
			{
				EPN.T_Incubators,
				new BiologicalTrait(EPN.T_Incubators,
					dlc: new [] { EPN.D_Toxoids }.ToOrSet(),
					prohibitions : new AndSet() { EPN.T_SlowBreeders, EPN.T_ExistentialIteroparity, EPN.T_Budding, EPN.T_Crystallization,
					EPN.T_EggLaying, EPN.T_RapidBreeders})
				{
					Cost = 2
				}
			},
			{
				EPN.T_Noxious,
				new BiologicalTrait(EPN.T_Noxious,
					dlc: new [] { EPN.D_Toxoids }.ToOrSet())
				{
					Cost = 1
				}
			},
			{
				EPN.T_InorganicBreath,
				new BiologicalTrait(EPN.T_InorganicBreath,
					dlc: new [] { EPN.D_Toxoids }.ToOrSet())
				{
					Cost = 3
				}
			},
			#region Phenotype
			{
				EPN.T_Phototrophic,
				new BiologicalTrait(EPN.T_Phototrophic,
					dlc: new [] {EPN.D_Plantoids }.ToOrSet(),
					requirements: new[] { EPN.PH_Plantoid, EPN.PH_Fungoid }.ToOrSet(),
					prohibitions: new AndSet(){EPN.T_Radiotrophic,EPN.T_Voidling, EPN.T_CaveDweller })
				{
					Cost = 1
				}
			},
			{
				EPN.T_Radiotrophic,
				new BiologicalTrait(EPN.T_Radiotrophic,
					dlc: new [] {EPN.D_Plantoids }.ToOrSet(),
					requirements: new[] { EPN.PH_Plantoid, EPN.PH_Fungoid, EPN.PH_Lithoid }.ToOrSet(),
					prohibitions: new AndSet(){EPN.T_Phototrophic, EPN.T_Voidling})
				{
					Cost = 2
				}
			},
			{
				EPN.T_InvSpecies,
				new BiologicalTrait(EPN.T_InvSpecies,
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
				new BiologicalTrait(EPN.T_Budding,
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
				new BiologicalTrait(EPN.T_Crystallization,
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
				new BiologicalTrait(EPN.T_GaseousByproducts,
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
				new BiologicalTrait(EPN.T_ScintillatingSkin,
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
				new BiologicalTrait(EPN.T_VolatileExcretions,
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
				new BiologicalTrait(EPN.T_Familial,
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
				new BiologicalTrait(EPN.T_GeneticMemory,
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
				new BiologicalTrait(EPN.T_Camouflage,
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
				new BiologicalTrait(EPN.T_Chromalogs,
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
				new BiologicalTrait(EPN.T_EggLaying,
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
				new BiologicalTrait(EPN.T_SpareOrgans,
					dlc: new [] {EPN.D_Biogenesis }.ToOrSet(),
					requirements: new[] { EPN.PH_Molluscoid, EPN.PH_Necroid, EPN.PH_Toxoid  }.ToOrSet()
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_SeasonalDormancy,
				new BiologicalTrait(EPN.T_SeasonalDormancy,
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
				new BiologicalTrait(EPN.T_Flight,
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
				new BiologicalTrait(EPN.T_SpatialMastery,
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
				new BiologicalTrait(EPN.T_Shelled,
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
				new BiologicalTrait(EPN.T_AcidicVascularity,
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
				new BiologicalTrait(EPN.T_Decadent,
					prohibitions: new AndSet(){ EPN.Gestalt}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Deviants,
				new BiologicalTrait(EPN.T_Deviants,
					prohibitions: new AndSet(){ EPN.Gestalt, EPN.T_Conformists}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Fleeting,
				new BiologicalTrait(EPN.T_Fleeting,
					prohibitions: new AndSet(){ EPN.T_Enduring, EPN.T_Venerable}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Nonadaptive,
				new BiologicalTrait(EPN.T_Nonadaptive,
					prohibitions: new AndSet(){EPN.T_Adaptive, EPN.T_ExtremelyAdaptive, EPN.T_Lithoid}
					)
				{
					Cost = -2
				}
			},
			{
				EPN.T_Sedentary,
				new BiologicalTrait(EPN.T_Sedentary,
					prohibitions: new AndSet(){ EPN.T_Nomadic}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Quarrelsome,
				new BiologicalTrait(EPN.T_Quarrelsome,
					prohibitions: new AndSet(){ EPN.T_Traditional, EPN.Gestalt}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Repugnant,
				new BiologicalTrait(EPN.T_Repugnant,
					prohibitions: new AndSet(){ EPN.T_Charismatic}
					)
				{
					Cost = -2
				}
			},
			{
				EPN.T_SlowBreeders,
				new BiologicalTrait(EPN.T_SlowBreeders,
					prohibitions: new AndSet(){ EPN.T_RapidBreeders, EPN.T_ExistentialIteroparity, EPN.T_Incubators,
					EPN.T_Budding, EPN.T_Crystallization, EPN.T_EggLaying, EPN.T_Lithoid,EPN.T_NascentStage}
					)
				{
					Cost = -2
				}
			},
			{
				EPN.T_SlowLearners,
				new BiologicalTrait(EPN.T_SlowLearners,
					prohibitions: new AndSet(){EPN.T_QuickLearners}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Solitary,
				new BiologicalTrait(EPN.T_Solitary,
					prohibitions: new AndSet(){ EPN.T_Communal}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Unruly,
				new BiologicalTrait(EPN.T_Unruly,
					prohibitions: new AndSet(){ EPN.T_Docile}
					)
				{
					Cost = -2
				}
			},
			{
				EPN.T_Wasteful,
				new BiologicalTrait(EPN.T_Wasteful,
					prohibitions: new AndSet(){ EPN.Gestalt, EPN.T_Conservationist}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Weak,
				new BiologicalTrait(EPN.T_Weak,
					prohibitions: new AndSet(){ EPN.T_Strong, EPN.T_VeryStrong, EPN.T_HollowBones}
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_Jinxed,
				new BiologicalTrait(EPN.T_Jinxed,
					dlc: new[]{ EPN.D_Humanoids }.ToOrSet())
				{
					Cost = -1
				}
			},
			{
				EPN.T_PsychoInfertility,
				new BiologicalTrait(EPN.T_PsychoInfertility,
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
				new BiologicalTrait(EPN.T_NascentStage,
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
				new BiologicalTrait(EPN.T_PermeableSkin,
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
				new BiologicalTrait(EPN.T_HollowBones,
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
				new BiologicalTrait(EPN.T_Rooted,
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
				new BiologicalTrait(EPN.T_Brittle,
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
				new BiologicalTrait(EPN.T_Survivor,
					dlc: new[]{ EPN.D_Apocalypse }.ToOrSet())
				{
					Cost = 0
				}
			},
			{
				EPN.T_VoidDweller,
				new BiologicalTrait(EPN.T_VoidDweller,
					dlc: new[]{ EPN.D_Federations }.ToOrSet())
				{
					Cost = 0
				}
			},
			{
				EPN.T_Necrophage,
				new BiologicalTrait(EPN.T_Necrophage,
					dlc: new[]{ EPN.D_Necroids }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_Budding, EPN.T_Crystallization,
						EPN.T_PsychoInfertility, EPN.T_VatGrown, EPN.T_Polymelic })
				{
					Cost = 0
				}
			},
			{
				EPN.T_CaveDweller,
				new BiologicalTrait(EPN.T_CaveDweller,
					dlc: new[]{ EPN.D_Overlord }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_Phototrophic, EPN.T_Aquatic })
				{
					Cost = 0
				}
			},
			{
				EPN.T_PerfectedGenes,
				new BiologicalTrait(EPN.T_PerfectedGenes,
					dlc: new[]{ EPN.D_GalParagons }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_Fleeting, EPN.T_Weak})
				{
					Cost = 0
				}
			},
			{
				EPN.T_PathogenicGenes,
				new BiologicalTrait(EPN.T_PathogenicGenes,
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
				new BiologicalTrait(EPN.T_MalleableGenes,
					dlc: new[]{ EPN.D_Biogenesis }.ToOrSet())
				{
					Cost = 6
				}
			},
			{
				EPN.T_Wilderness,
				new BiologicalTrait(EPN.T_Wilderness,
					dlc: new[]{ EPN.D_Biogenesis }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_Nomadic, EPN.T_Incubators, EPN.T_Sedentary, EPN.T_NascentStage})
				{
					Cost = 0
				}
			},
			{
				EPN.T_Stargazer,
				new BiologicalTrait(EPN.T_Stargazer,
					dlc: new[]{ EPN.D_FirstContact }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_Sedentary}
					)
				{
					Cost = 0
				}
			},
			{
				EPN.T_StormTouched,
				new BiologicalTrait(EPN.T_StormTouched,
					dlc: new[]{ EPN.D_CosmicStorms }.ToOrSet())
				{
					Cost = 0
				}
			},
			{
				EPN.T_CyberCommandos,
				new BiologicalTrait(EPN.T_CyberCommandos,
					dlc: new[]{ EPN.D_SyntheticDawn }.ToOrSet())
				{
					Cost = 0
				}
			},
			{
				EPN.T_Unplugged,
				new BiologicalTrait(EPN.T_Unplugged,
					dlc: new[]{ EPN.D_SyntheticDawn }.ToOrSet())
				{
					Cost = 0
				}
			},
			{
				EPN.T_CloneSoldier,
				new BiologicalTrait(EPN.T_CloneSoldier,
					dlc: new[]{ EPN.D_Humanoids }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_RapidBreeders, EPN.T_ExistentialIteroparity, EPN.T_Budding,
						EPN.T_Crystallization, EPN.T_EggLaying, EPN.T_SlowBreeders, EPN.T_PsychoInfertility, EPN.T_Polymelic }
					)
				{
					Cost = 0,
				}
			},
			{
				EPN.T_RitualisticImplants,
				new BiologicalTrait(EPN.T_RitualisticImplants,
					dlc: new[]{ EPN.D_MachineAge }.ToOrSet())
				{
					Cost = 0
				}
			},
			#endregion

			#region Overtuned
			{
				EPN.T_AugmentedIntelligence,
				new BiologicalTrait(EPN.T_AugmentedIntelligence,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_CommercialGenius,
				new BiologicalTrait(EPN.T_CommercialGenius,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet())
				{
					Cost = 1
				}
			},
			{
				EPN.T_CraftedSmiles,
				new BiologicalTrait(EPN.T_CraftedSmiles,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_DedicatedMiner,
				new BiologicalTrait(EPN.T_DedicatedMiner,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_ExpressedTradition,
				new BiologicalTrait(EPN.T_ExpressedTradition,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_FarmAppendages,
				new BiologicalTrait(EPN.T_FarmAppendages,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_GeneMentorship,
				new BiologicalTrait(EPN.T_GeneMentorship,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_JuicedPower,
				new BiologicalTrait(EPN.T_JuicedPower,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_LowMaintenance,
				new BiologicalTrait(EPN.T_LowMaintenance,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_SplicedAdaptability,
				new BiologicalTrait(EPN.T_SplicedAdaptability,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_TechnicalTalent,
				new BiologicalTrait(EPN.T_TechnicalTalent,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_FleetingExcellence,
				new BiologicalTrait(EPN.T_FleetingExcellence,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_ElevatedSynapses,
				new BiologicalTrait(EPN.T_ElevatedSynapses,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_PrePlannedGrowth,
				new BiologicalTrait(EPN.T_PrePlannedGrowth,
					dlc: new[]{ EPN.D_Toxoids }.ToOrSet(),
					requirements: new[] { EPN.O_Overtuned }.ToOrSet()
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_ExcessiveEndurance,
				new BiologicalTrait(EPN.T_ExcessiveEndurance,
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
			#region Granted Traits
			{
				EPN.T_MachineUnit,
				new MachineTrait(EPN.T_MachineUnit)
				{
					Cost = 0
				}
			},
			{
				EPN.T_RadiationShields,
				new MachineTrait(EPN.T_RadiationShields,
					dlc: new[]{ EPN.D_Apocalypse }.ToOrSet(),
					requirements: new[] { EPN.O_RadioactiveRovers }.ToOrSet()
					)
				{
					Cost = 0
				}
			},
			{
				EPN.T_ZeroGOptimized,
				new MachineTrait(EPN.T_ZeroGOptimized,
					dlc: new[]{ EPN.D_Federations }.ToOrSet(),
					requirements: new[] { EPN.O_Voidforged }.ToOrSet()
					)
				{
					Cost = 0
				}
			},
			{
				EPN.T_Molebots,
				new MachineTrait(EPN.T_Molebots,
					dlc: new HashSet<OrSet>(){ new OrSet{ EPN.D_Overlord }, new OrSet{EPN.D_MachineAge } },
					prohibitions: new AndSet { EPN.T_Waterproof},
					requirements: new[] { EPN.O_Subterranean }.ToOrSet()
					)
				{
					Cost = 0
				}
			},
			{
				EPN.T_SyntheticSalvation,
				new MachineTrait(EPN.T_SyntheticSalvation,
					dlc: new[]{ EPN.D_MachineAge }.ToOrSet(),
					requirements: new[] { EPN.O_SyntheticFertility }.ToOrSet()
					)
				{
					Cost = 0
				}
			},
			{
				EPN.T_Waterproof,
				new MachineTrait(EPN.T_Waterproof,
					dlc: new[]{ EPN.D_Aquatics }.ToOrSet(),
					prohibitions: new AndSet { EPN.T_Molebots }
					)
				{
					Cost = 2
				}
			},
			#endregion
			#region Basic
			#region Positive
			{
				EPN.T_AdaptiveFrames,
				new MachineTrait(EPN.T_AdaptiveFrames)
				{
					Cost = 3
				}
			},
			{
				EPN.T_EfficientProcessors,
				new MachineTrait(EPN.T_EfficientProcessors)
				{
					Cost = 3
				}
			},
			{
				EPN.T_Harvesters,
				new MachineTrait(EPN.T_Harvesters)
				{
					Cost = 2
				}
			},
			{
				EPN.T_PowerDrills,
				new MachineTrait(EPN.T_PowerDrills)
				{
					Cost = 2
				}
			},
			{
				EPN.T_Superconductive,
				new MachineTrait(EPN.T_Superconductive)
				{
					Cost = 2
				}
			},
			{
				EPN.T_DoubleJointed,
				new MachineTrait(EPN.T_DoubleJointed,
					prohibitions: new AndSet(){ EPN.T_Bulky }
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_Durable,
				new MachineTrait(EPN.T_Durable,
					prohibitions: new AndSet(){ EPN.T_HighMaintenance }
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_EmotionEmulators,
				new MachineTrait(EPN.T_EmotionEmulators,
					prohibitions: new AndSet(){ EPN.T_Uncanny }
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_MassProduced,
				new MachineTrait(EPN.T_MassProduced,
					prohibitions: new AndSet(){ EPN.T_CustomMade }
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_Recycled,
				new MachineTrait(EPN.T_Recycled,
					prohibitions: new AndSet(){ EPN.T_Luxurious }
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_StreamlinedProtocols,
				new MachineTrait(EPN.T_StreamlinedProtocols,
					prohibitions: new AndSet(){ EPN.T_HighBandwidth }
					)
				{
					Cost = 2
				}
			},
			//This trait is used for Robots only
			//{
			//	EPN.T_DomesticProtocols,
			//	new MachineTrait(EPN.T_DomesticProtocols,
			//		prohibitions: new AndSet(){ EPN.PH_Machine }
			//		)
			//	{
			//		Cost = 2
			//	}
			//},
			{
				EPN.T_LogicEngines,
				new MachineTrait(EPN.T_LogicEngines)
				{
					Cost = 2
				}
			},
			{
				EPN.T_TradingAlgorithms,
				new MachineTrait(EPN.T_TradingAlgorithms,
					prohibitions: new AndSet(){ EPN.A_MachineIntelligence, EPN.T_ScarcitySubroutines }
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_EternalMachine,
				new MachineTrait(EPN.T_EternalMachine)
				{
					Cost = 4
				}
			},
			{
				EPN.T_LoyaltyCircuits,
				new MachineTrait(EPN.T_LoyaltyCircuits,
					prohibitions: new AndSet(){ EPN.A_MachineIntelligence }
					)
				{
					Cost = 2
				}
			},
			{
				EPN.T_PropagandaMachines,
				new MachineTrait(EPN.T_PropagandaMachines,
					prohibitions: new AndSet(){ EPN.T_Quarrelsome }
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_EnhancedMemory,
				new MachineTrait(EPN.T_EnhancedMemory)
				{
					Cost = 2
				}
			},
			{
				EPN.T_LearningAlgorithms,
				new MachineTrait(EPN.T_LearningAlgorithms,
					prohibitions: new AndSet(){ EPN.T_RepurposedHardware }
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_EngineeringCore,
				new MachineTrait(EPN.T_EngineeringCore,
					dlc: new[]{ EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(){ }
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_PhysicsCore,
				new MachineTrait(EPN.T_PhysicsCore,
					dlc: new[]{ EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(){ }
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_SociologyCore,
				new MachineTrait(EPN.T_SociologyCore,
					dlc: new[]{ EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(){ }
					)
				{
					Cost = 1
				}
			},
			{
				EPN.T_IntegratedWeaponry,
				new MachineTrait(EPN.T_IntegratedWeaponry,
					dlc: new[]{ EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.T_DelicateChassis }
					)
				{
					Cost = 2
				}
			},
			#endregion
			#region Negative
			{
				EPN.T_Bulky,
				new MachineTrait(EPN.T_Bulky,
					prohibitions: new AndSet(){ EPN.T_DoubleJointed }
					)
				{
					Cost = -1
				}
			},
			{
				EPN.T_CustomMade,
				new MachineTrait(EPN.T_CustomMade,
					prohibitions: new AndSet(){ EPN.T_MassProduced })
				{
					Cost = -1
				}
			},
			{
				EPN.T_HighBandwidth,
				new MachineTrait(EPN.T_HighBandwidth,
					prohibitions: new AndSet(){ EPN.T_StreamlinedProtocols })
				{
					Cost = -2
				}
			},
			{
				EPN.T_HighMaintenance,
				new MachineTrait(EPN.T_HighMaintenance,
					prohibitions: new AndSet(){ EPN.T_Durable })
				{
					Cost = -1
				}
			},
			{
				EPN.T_Luxurious,
				new MachineTrait(EPN.T_Luxurious,
					prohibitions: new AndSet(){ EPN.T_Recycled })
				{
					Cost = -2
				}
			},
			{
				EPN.T_Uncanny,
				new MachineTrait(EPN.T_Uncanny,
					prohibitions: new AndSet(){ EPN.T_EmotionEmulators })
				{
					Cost = -1
				}
			},
			{
				EPN.T_DecadentM,
				new MachineTrait(EPN.T_DecadentM, dlc: new[]{ EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.A_MachineIntelligence })
				{
					Cost = -1
				}
			},
			{
				EPN.T_DeviantsM,
				new MachineTrait(EPN.T_DeviantsM,dlc: new[]{ EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.A_MachineIntelligence })
				{
					Cost = -1
				}
			},
			{
				EPN.T_QuarrelsomeM,
				new MachineTrait(EPN.T_QuarrelsomeM,dlc: new[]{ EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.A_MachineIntelligence, EPN.T_PropagandaMachines })
				{
					Cost = -1
				}
			},
			{
				EPN.T_WastefulM,
				new MachineTrait(EPN.T_WastefulM,dlc: new[]{ EPN.D_MachineAge }.ToOrSet(),
					prohibitions: new AndSet(){ EPN.A_MachineIntelligence })
				{
					Cost = -1
				}
			},
			{
				EPN.T_RepurposedHardware,
				new MachineTrait(EPN.T_RepurposedHardware,
					prohibitions: new AndSet(){ EPN.T_LearningAlgorithms })
				{
					Cost = -1
				}
			},
			{
				EPN.T_DelicateChassis,
				new MachineTrait(EPN.T_DelicateChassis,
					prohibitions: new AndSet(){ EPN.T_IntegratedWeaponry })
				{
					Cost = -1
				}
			},
			{
				EPN.T_ScarcitySubroutines,
				new MachineTrait(EPN.T_ScarcitySubroutines,
					prohibitions: new AndSet(){ EPN.T_TradingAlgorithms, EPN.A_MachineIntelligence })
				{
					Cost = -1
				}
			},
			#endregion
			#endregion
			#endregion
			#region Design Traits
			{
				EPN.T_ArtGenerator,
				new MachineTrait(EPN.T_ArtGenerator,
					dlc: new[]{ EPN.D_MachineAge }.ToOrSet())
				{
					Cost = 0,
					IsDesignTrait = true
				}
			},
			{
				EPN.T_ConversationalAI,
				new MachineTrait(EPN.T_ConversationalAI,
					dlc: new[]{ EPN.D_MachineAge }.ToOrSet())
				{
					Cost = 0,
					IsDesignTrait = true
				}
			},
			{
				EPN.T_Nannybot,
				new MachineTrait(EPN.T_Nannybot,
					dlc: new[]{ EPN.D_MachineAge }.ToOrSet())
				{
					Cost = 0,
					IsDesignTrait = true
				}
			},
			{
				EPN.T_ResearchAssistants,
				new MachineTrait(EPN.T_ResearchAssistants,
					dlc: new[]{ EPN.D_MachineAge }.ToOrSet())
				{
					Cost = 0,
					IsDesignTrait = true
				}
			},
			{
				EPN.T_WarMachine,
				new MachineTrait(EPN.T_WarMachine,
					dlc: new[]{ EPN.D_MachineAge }.ToOrSet())
				{
					Cost = 0,
					IsDesignTrait = true
				}
			},
			{
				EPN.T_Workerbots,
				new MachineTrait(EPN.T_Workerbots,
					dlc: new[]{ EPN.D_MachineAge }.ToOrSet())
				{
					Cost = 0,
					IsDesignTrait = true
				}
			},
			#endregion
		};

		public Trait(String name, HashSet<OrSet>? dlc = null,
			HashSet<OrSet>? requirements = null, IEnumerable<string>? prohibitions = null)
			: base(name, EmpirePropertyType.Trait, dlc, requirements,prohibitions) { }
	}

	public class BiologicalTrait : Trait
	{
		public BiologicalTrait(string name, HashSet<OrSet>? dlc = null,
			HashSet<OrSet>? requirements = null, AndSet? prohibitions = null)
			: base(name,dlc, requirements, 
				  new[] { EPN.PH_Machine }.Union<string>(prohibitions ?? Enumerable.Empty<string>()))
		{ }
	}

	public class MachineTrait : Trait
	{
		/// <summary>
		/// Design traits are only available at empire creation and do not cost trait points. 
		/// A species can only have one design trait. 
		/// </summary>
		public bool IsDesignTrait { get; init; } = false;

		public MachineTrait(string name, HashSet<OrSet>? dlc = null,
			HashSet<OrSet>? requirements = null, AndSet? prohibitions = null)
			: base(name,
				new[] { EPN.D_SyntheticDawn, EPN.D_MachineAge }.ToOrSet()
					.Union(dlc ?? new HashSet<OrSet>()).ToHashSet(),
			new[] {EPN.PH_Machine }.ToOrSet()
					.Union(requirements ?? new HashSet<OrSet>()).ToHashSet(),
			prohibitions)
		{ }
	}
}
