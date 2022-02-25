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
                    Prohibits = new AndSet(){ EPN.Gestalt }
                }
            },{
                EPN.O_Mechanist,
                new Origin(EPN.O_Mechanist, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.Materialist, EPN.MaterialistF }},
                    Prohibits = new AndSet(){ EPN.Gestalt }
                }
            },{
                EPN.O_SyncreticEvolution,
                new Origin(EPN.O_SyncreticEvolution, EPN.D_Utopia)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.C_SharedBurdens, EPN.C_FanaticPurifiers }
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
                    Prohibits = new AndSet(){ EPN.C_RogueServitor }
                }
            },{
                EPN.O_CloneArmy,
                new Origin(EPN.O_CloneArmy, EPN.D_Humanoids)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt }
                }
            },{
                EPN.O_LifeSeeded,
                new Origin(EPN.O_LifeSeeded, EPN.D_Apocalypse)
                {
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence }
                }
            },{
                EPN.O_PostApocalyptic,
                new Origin(EPN.O_PostApocalyptic, EPN.D_Apocalypse)
                {
                    Prohibits = new AndSet(){ EPN.A_MachineIntelligence, EPN.C_AgrarianIdyll }
                }
            },{
                EPN.O_Remnants,
                new Origin(EPN.O_Remnants, EPN.D_AncientRelics)
                {
                    Prohibits = new AndSet(){ EPN.C_AgrarianIdyll }
                }
            },{
                EPN.O_CalamitousBirth,
                new Origin(EPN.O_CalamitousBirth, EPN.D_Lithoids)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.T_Lithoid }}
                }
            },{
                EPN.O_CommonGround,
                new Origin(EPN.O_CommonGround, EPN.D_Federations)
                {
                    Prohibits = new AndSet(){ EPN.Xenophobe,EPN.XenophobeF,EPN.Gestalt,EPN.C_InwardPerfection,EPN.C_FanaticPurifiers,EPN.C_BarbaricDespoilers }
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
                    Prohibits = new AndSet(){ EPN.C_AgrarianIdyll }
                }
            },{
                EPN.O_VoidDwellers,
                new Origin(EPN.O_VoidDwellers, EPN.D_Federations)
                {
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.C_AgrarianIdyll }
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

        };


        #endregion

        public Origin(String name, params String[] dlc) : base(name, EmpirePropertyType.Origin, dlc) { }
    }
}