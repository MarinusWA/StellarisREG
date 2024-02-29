using System;
using System.Collections.Generic;
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
                new Origin(EPN.O_LostColony)
                {
                    
                }
            },{
                EPN.O_Mechanist,
                new Origin(EPN.O_Mechanist, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.Materialist, EPN.MaterialistF }},
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.C_PermanentEmployment }
                }
            },{
                EPN.O_SyncreticEvolution,
                new Origin(EPN.O_SyncreticEvolution, EPN.D_Utopia)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.C_FanaticPurifiers }
                }
            },{
                EPN.O_TreeofLife,
                new Origin(EPN.O_TreeofLife, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind }},
                    Prohibits = new AndSet(){ EPN.C_DevouringSwarm, EPN.C_Terravore }
                }
            },{
                EPN.O_ResourceConsolidation,
                new Origin(EPN.O_ResourceConsolidation, EPN.D_SyntheticDawn)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_MachineIntelligence }},
                    Prohibits = new AndSet(){ EPN.C_RogueServitor, EPN.C_OrganicReprocessingMI }
                }
            },{
                EPN.O_CloneArmy,
                new Origin(EPN.O_CloneArmy, EPN.D_Humanoids)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.C_PermanentEmployment }
                }
            },{
                EPN.O_LifeSeeded,
                new Origin(EPN.O_LifeSeeded, EPN.D_Apocalypse)
                {
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence, EPN.C_MutagenicSpas, EPN.C_PermutationPools, EPN.C_RelentlessIndustrialists }
                }
            },{
                EPN.O_PostApocalyptic,
                new Origin(EPN.O_PostApocalyptic, EPN.D_Apocalypse)
                {
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence, EPN.C_AgrarianIdyll, EPN.C_Anglers, EPN.C_TrawlingOperations }
                }
            },{
                EPN.O_Remnants,
                new Origin(EPN.O_Remnants, true, EPN.D_AncientRelics, EPN.D_Federations)
                {
                    Prohibits = new AndSet(){ EPN.C_AgrarianIdyll }
                }
            },{
                EPN.O_CalamitousBirth,
                new Origin(EPN.O_CalamitousBirth, EPN.D_Lithoids)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.T_Lithoid }},
                    Prohibits = new AndSet(){ EPN.C_CatalyticProcessing, EPN.C_CatalyticRecyclers, EPN.C_OrganicReprocessingHM }
                }
            },{
                EPN.O_CommonGround,
                new Origin(EPN.O_CommonGround, EPN.D_Federations)
                {
                    Prohibits = new AndSet(){ EPN.Xenophobe,EPN.XenophobeF,EPN.Gestalt,EPN.C_InwardPerfection,EPN.C_FanaticPurifiers,EPN.C_BarbaricDespoilers, EPN.C_DevouringSwarm }
                }
            },{
                EPN.O_Hegemon,
                new Origin(EPN.O_Hegemon, EPN.D_Federations)
                {
                    Prohibits = new AndSet(){ EPN.Xenophobe, EPN.XenophobeF, EPN.Egalitarian,EPN.EgalitarianF, EPN.Gestalt, EPN.C_InwardPerfection, EPN.C_FanaticPurifiers }
                }
            },{
                EPN.O_Doomsday,
                new Origin(EPN.O_Doomsday, EPN.D_Federations){ }
            },{
                EPN.O_Giants,
                new Origin(EPN.O_Giants, EPN.D_Federations)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt }
                }
            },{
                EPN.O_Scion,
                new Origin(EPN.O_Scion, EPN.D_Federations)
                {
                    Prohibits = new AndSet(){ EPN.XenophobeF, EPN.Gestalt }
                }
            },{
                EPN.O_ShatteredRing,
                new Origin(EPN.O_ShatteredRing, EPN.D_Federations)
                {
                    Prohibits = new AndSet(){ EPN.C_AgrarianIdyll, EPN.C_Anglers, EPN.C_TrawlingOperations }
                }
            },{
                EPN.O_VoidDwellers,
                new Origin(EPN.O_VoidDwellers, EPN.D_Federations)
                {
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence, EPN.C_AgrarianIdyll, EPN.C_IdyllicBloom, EPN.C_IdyllicBloomHM, EPN.C_Anglers, EPN.C_TrawlingOperations }
                }
            },{
                EPN.O_Necrophage,
                new Origin(EPN.O_Necrophage, EPN.D_Necroids)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.Xenophile,EPN.XenophileF,EPN.EgalitarianF,EPN.C_CorporateDeathCult,EPN.C_DeathCult }
                }
            }
            ,{
                EPN.O_HereBeDragons,
                new Origin(EPN.O_HereBeDragons, EPN.D_Aquatics)
                {
                    Prohibits = new AndSet(){ EPN.C_DeterminedExterminator, EPN.C_DevouringSwarm, EPN.C_FanaticPurifiers }
                }
            }
            ,{
                EPN.O_OceanParadise,
                new Origin(EPN.O_OceanParadise, EPN.D_Aquatics)
                {
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence }
                }
            }
            ,{
                EPN.O_FruitfulPartnership,
                new Origin(EPN.O_FruitfulPartnership, EPN.D_Plantoids)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.AT_Plantoid}, new OrSet() { EPN.Pacifist, EPN.PacifistF, EPN.Xenophile, EPN.XenophileF, EPN.A_HiveMind}},
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence, EPN.C_DevouringSwarm }
                }
            }
            ,{
                EPN.O_ImperialFiefdom,
                new Origin(EPN.O_ImperialFiefdom, EPN.D_Overlord)
                {
                    Prohibits = new AndSet(){ EPN.C_DevouringSwarm, EPN.C_FanaticPurifiers, EPN.C_DeterminedExterminator, EPN.C_InwardPerfection, EPN.C_DrivenAssimilator }
                }
            }
            ,{
                EPN.O_ProgenitorHive,
                new Origin(EPN.O_ProgenitorHive, EPN.D_Overlord)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() {EPN.A_HiveMind } }
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
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence }
                }
            },{
                EPN.O_TeachersShroud,
                new Origin(EPN.O_TeachersShroud, EPN.D_Overlord)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() {EPN.Spiritualist, EPN.SpiritualistF } },
                    Prohibits = new AndSet(){ EPN.C_FanaticPurifiers }
                }
            },{
                EPN.O_KnightsToxicGod,
                new Origin(EPN.O_KnightsToxicGod, EPN.D_Toxoids)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.C_FanaticPurifiers, EPN.C_OppressiveAutocracy }
                }
            },{
                EPN.O_Overtuned,
                new Origin(EPN.O_Overtuned, EPN.D_Toxoids)
                {
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence }
                }
            },{
                EPN.O_BrokenShackles,
                new Origin(EPN.O_BrokenShackles, EPN.D_FirstContact)
                {
                    Prohibits = new AndSet(){ EPN.Authoritarian, EPN.AuthoritarianF, EPN.Xenophobe, EPN.XenophobeF, EPN.Gestalt,
                    EPN.C_SelectiveKinship, EPN.C_EagerExplorers, EPN.C_SovereignGuardianship }
                }
            },{
                EPN.O_Payback,
                new Origin(EPN.O_Payback, EPN.D_FirstContact)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.C_SlaverGuilds, EPN.C_FanaticPurifiers, EPN.C_PompousPurists, EPN.C_EagerExplorers,
                    EPN.C_OppressiveAutocracy, EPN.C_SovereignGuardianship, EPN.C_IndenturedAssets, EPN.C_PrivatizedExploration, EPN.C_PharmaState, EPN.C_CorporateProtectorate}
                }
            },{
                EPN.O_FearDark,
                new Origin(EPN.O_FearDark, EPN.D_FirstContact)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.C_InwardPerfection, EPN.C_FanaticPurifiers, EPN.C_EagerExplorers, EPN.C_SovereignGuardianship, EPN.C_PrivatizedExploration, EPN.C_CorporateProtectorate }
                }
            },
            {
                EPN.O_UnderOneRule,
                new Origin(EPN.O_UnderOneRule, EPN.D_GalParagons)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() {EPN.A_Dictatorial }}
                }
            },
            {
                EPN.O_Riftworld,
                new Origin(EPN.O_Riftworld, EPN.D_AstralPlanes)
                {
                    
                }
            }
        };


        #endregion

        public Origin(String name, bool inclusiveDLC, params String[] dlc) : base(name, EmpirePropertyType.Origin, inclusiveDLC, dlc) { }
        public Origin(String name, params String[] dlc) : base(name, EmpirePropertyType.Origin, false, dlc) { }
    }
}