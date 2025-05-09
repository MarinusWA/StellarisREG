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
					EPN.T_Nonadaptive, EPN.T_SlowBreeders, EPN.T_PInfertility }
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
					prohibitions : new AndSet() { EPN.T_PInfertility, EPN.T_Incubators, EPN.T_Budding, EPN.T_Crystallization,
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
					Cost = 1
				}
			},
			#endregion
			#endregion
			#region Negative
			#region Phenotype
			#endregion
			#endregion
			#endregion
		};

		public Trait(String name, HashSet<OrSet>? dlc = null,
			HashSet<OrSet>? requirements = null, AndSet? prohibitions = null)
			: base(name, EmpirePropertyType.Trait, dlc, requirements, prohibitions) { }
	}
}
