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
                    Prohibits = new AndSet(){ EPN.T_ExtremelyAdaptive, EPN.T_Nonadaptive, EPN.T_Lithoid }
                }
            },
            {
                EPN.T_ExtremelyAdaptive,
                new Trait(EPN.T_ExtremelyAdaptive){
                    Cost=4,
                    Prohibits = new AndSet(){ EPN.T_Adaptive, EPN.T_Nonadaptive, EPN.T_Lithoid }
                }
            },
            {
                EPN.T_Nonadaptive,
                new Trait(EPN.T_Nonadaptive){
                    Cost= -2,
                    Prohibits = new AndSet(){ EPN.T_Adaptive,EPN.T_ExtremelyAdaptive, EPN.T_Lithoid }
                }
            },
            {
                EPN.T_Agrarian,
                new Trait(EPN.T_Agrarian){
                    Cost=2
                }
            },
            {
                EPN.T_Charismatic,
                new Trait(EPN.T_Charismatic){
                    Cost=2,
                    Prohibits = new AndSet(){ EPN.T_Repugnant }
                }
            },
            {
                EPN.T_Repugnant,
                new Trait(EPN.T_Repugnant){
                    Cost=-2,
                    Prohibits = new AndSet(){ EPN.T_Charismatic }
                }
            },
            {
                EPN.T_Communal,
                new Trait(EPN.T_Communal){
                    Cost=1,
                    Prohibits = new AndSet(){ EPN.T_Solitary }
                }
            },
            {
                EPN.T_Solitary,
                new Trait(EPN.T_Solitary){
                    Cost= -1,
                    Prohibits = new AndSet(){ EPN.T_Communal }
                }
            },
            {
                EPN.T_Conformists,
                new Trait(EPN.T_Conformists){
                    Cost=2,
                    Prohibits = new AndSet(){ EPN.T_Deviants }
                }
            },
            {
                EPN.T_Deviants,
                new Trait(EPN.T_Deviants){
                    Cost=-2,
                    Prohibits = new AndSet(){ EPN.T_Conformists }
                }
            },
            {
                EPN.T_Conservationist,
                new Trait(EPN.T_Conservationist){
                    Cost=1,
                    Prohibits = new AndSet(){ EPN.T_Wasteful }
                }
            },
            {
                EPN.T_Wasteful,
                new Trait(EPN.T_Wasteful){
                    Cost=-1,
                    Prohibits = new AndSet(){ EPN.T_Conservationist }
                }
            },
            {
                EPN.T_Docile,
                new Trait(EPN.T_Docile){
                    Cost= 2,
                    Prohibits = new AndSet(){ EPN.T_Unruly }
                }
            },
            {
                EPN.T_Unruly,
                new Trait(EPN.T_Unruly){
                    Cost=-2,
                    Prohibits = new AndSet(){ EPN.T_Docile }
                }
            },
            {
                EPN.T_Enduring,
                new Trait(EPN.T_Enduring){
                    Cost= 1,
                    Prohibits = new AndSet(){ EPN.T_Fleeting,EPN.T_Venerable }
                }
            },
            {
                EPN.T_Venerable,
                new Trait(EPN.T_Venerable){
                    Cost=4,
                    Prohibits = new AndSet(){ EPN.T_Fleeting,EPN.T_Enduring }
                }
            },
            {
                EPN.T_Fleeting,
                new Trait(EPN.T_Fleeting){
                    Cost=-1,
                    Prohibits = new AndSet(){ EPN.T_Venerable,EPN.T_Enduring }
                }
            },
            {
                EPN.T_Industrious,
                new Trait(EPN.T_Industrious){
                    Cost=2
                }
            },
            {
                EPN.T_Ingenious,
                new Trait(EPN.T_Ingenious){
                    Cost=2
                }
            },
            {
                EPN.T_Intelligent,
                new Trait(EPN.T_Intelligent){
                    Cost=2
                }
            },
            {
                EPN.T_NaturalEngineers,
                new Trait(EPN.T_NaturalEngineers){
                    Cost=1
                }
            },
            {
                EPN.T_NaturalPhysicists,
                new Trait(EPN.T_NaturalPhysicists){
                    Cost=1
                }
            },
            {
                EPN.T_NaturalSociologists,
                new Trait(EPN.T_NaturalSociologists){
                    Cost=1
                }
            },
            {
                EPN.T_Nomadic,
                new Trait(EPN.T_Nomadic){
                    Cost=1,
                    Prohibits = new AndSet(){ EPN.T_Sedentary }
                }
            },
            {
                EPN.T_Sedentary,
                new Trait(EPN.T_Sedentary){
                    Cost=-1,
                    Prohibits = new AndSet(){ EPN.T_Nomadic }
                }
            },
            {
                EPN.T_QuickLearners,
                new Trait(EPN.T_QuickLearners){
                    Cost=1,
                    Prohibits = new AndSet(){ EPN.T_SlowLearners }
                }
            },
            {
                EPN.T_SlowLearners,
                new Trait(EPN.T_SlowLearners){
                    Cost=-1,
                    Prohibits = new AndSet(){ EPN.T_QuickLearners }
                }
            },
            {
                EPN.T_RapidBreeders,
                new Trait(EPN.T_RapidBreeders){
                    Cost=2,
                    Prohibits = new AndSet(){ EPN.T_SlowBreeders, EPN.T_Lithoid }
                }
            },
            {
                EPN.T_SlowBreeders,
                new Trait(EPN.T_SlowBreeders){
                    Cost=-2,
                    Prohibits = new AndSet(){ EPN.T_RapidBreeders, EPN.T_Lithoid }
                }
            },
            {
                EPN.T_Resilient,
                new Trait(EPN.T_Resilient){
                    Cost=1
                }
            },
            {
                EPN.T_Strong,
                new Trait(EPN.T_Strong){
                    Cost=1,
                    Prohibits = new AndSet(){ EPN.T_VeryStrong,EPN.T_Weak }
                }
            },
            {
                EPN.T_VeryStrong,
                new Trait(EPN.T_VeryStrong){
                    Cost=3,
                    Prohibits = new AndSet(){ EPN.T_Strong,EPN.T_Weak }
                }
            },
            {
                EPN.T_Weak,
                new Trait(EPN.T_Weak){
                    Cost=-1,
                    Prohibits = new AndSet(){ EPN.T_Strong,EPN.T_VeryStrong }
                }
            },
            {
                EPN.T_Talented,
                new Trait(EPN.T_Talented){
                    Cost=1
                }
            },
            {
                EPN.T_Thrifty,
                new Trait(EPN.T_Thrifty){
                    Cost=2
                }
            },
            {
                EPN.T_Traditional,
                new Trait(EPN.T_Traditional){
                    Cost=1,
                    Prohibits = new AndSet(){ EPN.T_Quarrelsome }
                }
            },
            {
                EPN.T_Quarrelsome,
                new Trait(EPN.T_Quarrelsome){
                    Cost=-1,
                    Prohibits = new AndSet(){ EPN.T_Traditional }
                }
            },
            {
                EPN.T_Decadent,
                new Trait(EPN.T_Decadent){
                    Cost=-1
                }
            },
            #endregion
            #region Lithoid
            {
                EPN.T_GaseousByproducts,
                new Trait(EPN.T_GaseousByproducts, EPN.D_Lithoids){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.T_Lithoid } },
                    Prohibits = new AndSet(){EPN.T_ScintillatingSkin,EPN.T_VolatileExcretions },
                    Cost=2
                }
            },
            {
                EPN.T_ScintillatingSkin,
                new Trait(EPN.T_ScintillatingSkin, EPN.D_Lithoids){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.T_Lithoid } },
                    Prohibits = new AndSet(){EPN.T_GaseousByproducts,EPN.T_VolatileExcretions },
                    Cost=2
                }
            },
            {
                EPN.T_VolatileExcretions,
                new Trait(EPN.T_VolatileExcretions, EPN.D_Lithoids){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.T_Lithoid } },
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
                    Cost=1
                }
            },
            {
                EPN,
                new Trait(EPN., EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Cost=
                }
            },
            {
                EPN,
                new Trait(EPN., EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Cost=
                }
            },
            {
                EPN,
                new Trait(EPN., EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Cost=
                }
            },
            {
                EPN,
                new Trait(EPN., EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Cost=
                }
            },
            {
                EPN,
                new Trait(EPN., EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Cost=
                }
            },
            {
                EPN,
                new Trait(EPN., EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Cost=
                }
            },
            {
                EPN,
                new Trait(EPN., EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Cost=
                }
            },
            {
                EPN,
                new Trait(EPN., EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Cost=
                }
            },
            {
                EPN,
                new Trait(EPN., EPN.D_SyntheticDawn){
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.A_MachineIntelligence } },
                    Cost=
                }
            },


            #endregion
        };

        public Trait(String name, params String[] dlc) : base(name, EmpirePropertyType.Trait, dlc) { }
    }
}
