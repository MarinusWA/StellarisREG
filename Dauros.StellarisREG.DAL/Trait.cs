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
            {
                EPN.T_Adaptive,
                new Trait(EPN.T_Adaptive){
                    Cost=2,
                    Prohibits = new AndSet(){ EPN.T_ExtremelyAdaptive, EPN.T_Nonadaptive, EPN.AT_Lithoid, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_ExtremelyAdaptive,
                new Trait(EPN.T_ExtremelyAdaptive){
                    Cost=4,
                    Prohibits = new AndSet(){ EPN.T_Adaptive, EPN.T_Nonadaptive, EPN.AT_Lithoid, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Nonadaptive,
                new Trait(EPN.T_Nonadaptive){
                    Cost= -2,
                    Prohibits = new AndSet(){ EPN.T_Adaptive,EPN.T_ExtremelyAdaptive, EPN.AT_Lithoid, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Agrarian,
                new Trait(EPN.T_Agrarian){
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence },
                    Cost=2
                }
            },
            {
                EPN.T_Charismatic,
                new Trait(EPN.T_Charismatic){
                    Cost=2,
                    Prohibits = new AndSet(){ EPN.T_Repugnant, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Repugnant,
                new Trait(EPN.T_Repugnant){
                    Cost=-2,
                    Prohibits = new AndSet(){ EPN.T_Charismatic, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Communal,
                new Trait(EPN.T_Communal){
                    Cost=1,
                    Prohibits = new AndSet(){ EPN.T_Solitary, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Solitary,
                new Trait(EPN.T_Solitary){
                    Cost= -1,
                    Prohibits = new AndSet(){ EPN.T_Communal, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Conformists,
                new Trait(EPN.T_Conformists){
                    Cost=2,
                    Prohibits = new AndSet(){ EPN.T_Deviants, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Deviants,
                new Trait(EPN.T_Deviants){
                    Cost=-2,
                    Prohibits = new AndSet(){ EPN.T_Conformists, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Conservationist,
                new Trait(EPN.T_Conservationist){
                    Cost=1,
                    Prohibits = new AndSet(){ EPN.T_Wasteful, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Wasteful,
                new Trait(EPN.T_Wasteful){
                    Cost=-1,
                    Prohibits = new AndSet(){ EPN.T_Conservationist, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Docile,
                new Trait(EPN.T_Docile){
                    Cost= 2,
                    Prohibits = new AndSet(){ EPN.T_Unruly, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Unruly,
                new Trait(EPN.T_Unruly){
                    Cost=-2,
                    Prohibits = new AndSet(){ EPN.T_Docile, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Enduring,
                new Trait(EPN.T_Enduring){
                    Cost= 1,
                    Prohibits = new AndSet(){ EPN.T_Fleeting,EPN.T_Venerable, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Venerable,
                new Trait(EPN.T_Venerable){
                    Cost=4,
                    Prohibits = new AndSet(){ EPN.T_Fleeting,EPN.T_Enduring, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Fleeting,
                new Trait(EPN.T_Fleeting){
                    Cost=-1,
                    Prohibits = new AndSet(){ EPN.T_Venerable,EPN.T_Enduring, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Industrious,
                new Trait(EPN.T_Industrious){
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence },
                    Cost=2
                }
            },
            {
                EPN.T_Ingenious,
                new Trait(EPN.T_Ingenious){
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence },
                    Cost=2
                }
            },
            {
                EPN.T_Intelligent,
                new Trait(EPN.T_Intelligent){
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence },
                    Cost=2
                }
            },
            {
                EPN.T_NaturalEngineers,
                new Trait(EPN.T_NaturalEngineers){
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence },
                    Cost=1
                }
            },
            {
                EPN.T_NaturalPhysicists,
                new Trait(EPN.T_NaturalPhysicists){
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence },
                    Cost=1
                }
            },
            {
                EPN.T_NaturalSociologists,
                new Trait(EPN.T_NaturalSociologists){
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence },
                    Cost=1
                }
            },
            {
                EPN.T_Nomadic,
                new Trait(EPN.T_Nomadic){
                    Cost=1,
                    Prohibits = new AndSet(){ EPN.T_Sedentary, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Sedentary,
                new Trait(EPN.T_Sedentary){
                    Cost=-1,
                    Prohibits = new AndSet(){ EPN.T_Nomadic, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_QuickLearners,
                new Trait(EPN.T_QuickLearners){
                    Cost=1,
                    Prohibits = new AndSet(){ EPN.T_SlowLearners, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_SlowLearners,
                new Trait(EPN.T_SlowLearners){
                    Cost=-1,
                    Prohibits = new AndSet(){ EPN.T_QuickLearners, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_RapidBreeders,
                new Trait(EPN.T_RapidBreeders){
                    Cost=2,
                    Prohibits = new AndSet(){ EPN.T_SlowBreeders, EPN.AT_Lithoid, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_SlowBreeders,
                new Trait(EPN.T_SlowBreeders){
                    Cost=-2,
                    Prohibits = new AndSet(){ EPN.T_RapidBreeders, EPN.AT_Lithoid, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Resilient,
                new Trait(EPN.T_Resilient){
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence },
                    Cost=1
                }
            },
            {
                EPN.T_Strong,
                new Trait(EPN.T_Strong){
                    Cost=1,
                    Prohibits = new AndSet(){ EPN.T_VeryStrong,EPN.T_Weak, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_VeryStrong,
                new Trait(EPN.T_VeryStrong){
                    Cost=3,
                    Prohibits = new AndSet(){ EPN.T_Strong,EPN.T_Weak, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Weak,
                new Trait(EPN.T_Weak){
                    Cost=-1,
                    Prohibits = new AndSet(){ EPN.T_Strong,EPN.T_VeryStrong, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Talented,
                new Trait(EPN.T_Talented){
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence },
                    Cost=1
                }
            },
            {
                EPN.T_Thrifty,
                new Trait(EPN.T_Thrifty){
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence },
                    Cost=2
                }
            },
            {
                EPN.T_Traditional,
                new Trait(EPN.T_Traditional){
                    Cost=1,
                    Prohibits = new AndSet(){ EPN.T_Quarrelsome, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Quarrelsome,
                new Trait(EPN.T_Quarrelsome){
                    Cost=-1,
                    Prohibits = new AndSet(){ EPN.T_Traditional, EPN.A_MachineIntelligence }
                }
            },
            {
                EPN.T_Decadent,
                new Trait(EPN.T_Decadent){
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence },
                    Cost=-1
                }
            },
            #endregion
            #region Lithoid
            {
                EPN.T_GaseousByproducts,
                new Trait(EPN.T_GaseousByproducts, EPN.D_Lithoids){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.AT_Lithoid } },
                    Prohibits = new AndSet(){EPN.T_ScintillatingSkin,EPN.T_VolatileExcretions },
                    Cost=2
                }
            },
            {
                EPN.T_ScintillatingSkin,
                new Trait(EPN.T_ScintillatingSkin, EPN.D_Lithoids){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.AT_Lithoid } },
                    Prohibits = new AndSet(){EPN.T_GaseousByproducts,EPN.T_VolatileExcretions },
                    Cost=2
                }
            },
            {
                EPN.T_VolatileExcretions,
                new Trait(EPN.T_VolatileExcretions, EPN.D_Lithoids){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.AT_Lithoid } },
                    Prohibits = new AndSet(){EPN.T_ScintillatingSkin,EPN.T_GaseousByproducts },
                    Cost=2
                }
            },
            {
                EPN.T_Lithoid,
                new Trait(EPN.T_Lithoid, EPN.D_Lithoids){
                    Cost=0,
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.AT_Lithoid } }
                }
            },
            #endregion
            {
                EPN.T_MachineUnit,
                new Trait(EPN.T_MachineUnit, EPN.D_SyntheticDawn)
                { 
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.AT_Machine, EPN.A_MachineIntelligence } },
                    Cost=0
                }
            },
            {
                EPN.T_Necrophage,
                new Trait(EPN.T_Necrophage, EPN.D_Necroids){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.O_Necrophage } },
                    Cost=0
                }
            },

            #region Machine
            {
                EPN.T_DoubleJointed,
                new Trait(EPN.T_DoubleJointed, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.T_Bulky },
                    Cost=1
                }
            },
            {
                EPN.T_Bulky,
                new Trait(EPN.T_Bulky, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.T_DoubleJointed },
                    Cost=-1
                }
            },
            {
                EPN.T_Durable,
                new Trait(EPN.T_Durable, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.T_HighMaintenance },
                    Cost=1
                }
            },
            {
                EPN.T_HighMaintenance,
                new Trait(EPN.T_HighMaintenance, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.T_Durable },
                    Cost=-1
                }
            },
            {
                EPN.T_EfficientProcessors,
                new Trait(EPN.T_EfficientProcessors, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Cost=3
                }
            },
            {
                EPN.T_EmotionEmulators,
                new Trait(EPN.T_EmotionEmulators, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.T_Uncanny },
                    Cost=1
                }
            },
            {
                EPN.T_Uncanny,
                new Trait(EPN.T_Uncanny, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.T_EmotionEmulators },
                    Cost=-1
                }
            },
            {
                EPN.T_EnhancedMemory,
                new Trait(EPN.T_EnhancedMemory, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Cost=2
                }
            },
            //{
            //    EPN.T_Harvesters,
            //    new Trait(EPN.T_Harvesters, EPN.D_SyntheticDawn){
            //        Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
            //        Cost=2
            //    }
            //},
            {
                EPN.T_LearningAlgorithms,
                new Trait(EPN.T_LearningAlgorithms, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.T_RepurposedHardware },
                    Cost=1
                }
            },
            {
                EPN.T_RepurposedHardware,
                new Trait(EPN.T_RepurposedHardware, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.T_LearningAlgorithms },
                    Cost=-1
                }
            },
            {
                EPN.T_LogicEngines,
                new Trait(EPN.T_LogicEngines, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Cost=2
                }
            },
            //{
            //    EPN.T_LoyaltyCircuits,
            //    new Trait(EPN.T_LoyaltyCircuits, EPN.D_SyntheticDawn){
            //        Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
            //        Cost=2
            //    }
            //},
            {
                EPN.T_MassProduced,
                new Trait(EPN.T_MassProduced, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.T_CustomMade },
                    Cost=1
                }
            },
            {
                EPN.T_CustomMade,
                new Trait(EPN.T_CustomMade, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.T_MassProduced },
                    Cost=1
                }
            },
            {
                EPN.T_PowerDrills,
                new Trait(EPN.T_PowerDrills, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Cost=2
                }
            },
            //{
            //    EPN.T_PropagandaMachines,
            //    new Trait(EPN.T_PropagandaMachines, EPN.D_SyntheticDawn){
            //        Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
            //        Cost=1
            //    }
            //},
            {
                EPN.T_Recycled,
                new Trait(EPN.T_Recycled, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.T_Luxurious },
                    Cost=2
                }
            },
            {
                EPN.T_Luxurious,
                new Trait(EPN.T_Luxurious, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.T_Recycled },
                    Cost=-2
                }
            },
            {
                EPN.T_StreamlinedProtocols,
                new Trait(EPN.T_StreamlinedProtocols, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.T_HighBandwidth },
                    Cost=2
                }
            },
            {
                EPN.T_HighBandwidth,
                new Trait(EPN.T_HighBandwidth, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Prohibits = new AndSet(){ EPN.T_StreamlinedProtocols },
                    Cost=-2
                }
            },
            {
                EPN.T_Superconductive,
                new Trait(EPN.T_Superconductive, EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Cost=2
                }
            },
            #endregion
        };

        public Trait(String name, params String[] dlc) : base(name, EmpirePropertyType.Trait, dlc) { }
    }
}
