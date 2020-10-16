using System;
using System.Collections.Generic;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public class Civic : EmpireProperty
    {
        public static Dictionary<String, Civic> Collection { get; } = new Dictionary<string, Civic>()
        {
            {
                EPN.C_AgrarianIdyll,
                new Civic(EPN.C_AgrarianIdyll)
                {
                    Requires = new HashSet<OrSet>(){ new OrSet() { EPN.Pacifist, EPN.PacifistF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate, EPN.O_PostApocalyptic, EPN.O_ShatteredRing, EPN.O_VoidDwellers }
                }
            },
            {
                EPN.C_ImperialCult,
                new Civic(EPN.C_ImperialCult)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_Imperial }, new OrSet(){ EPN.Authoritarian,EPN.AuthoritarianF }, new OrSet() { EPN.Spiritualist, EPN.SpiritualistF } },
                    Prohibits = new AndSet(){ EPN.Gestalt, EPN.A_Corporate }
                }
            },
            #region HiveMind
            {
                EPN.C_Ascetic,
                new Civic(EPN.C_Ascetic, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_DividedAttention,
                new Civic(EPN.C_DividedAttention, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_NaturalNeuralNetwork,
                new Civic(EPN.C_NaturalNeuralNetwork, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_OneMind,
                new Civic(EPN.C_OneMind, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_PooledKnowledge,
                new Civic(EPN.C_PooledKnowledge, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_StrengthofLegions,
                new Civic(EPN.C_StrengthofLegions, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_SubspaceEphapse,
                new Civic(EPN.C_SubspaceEphapse, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_SubsumedWill,
                new Civic(EPN.C_SubsumedWill, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } }
                }
            },
            {
                EPN.C_Empath,
                new Civic(EPN.C_Empath, EPN.D_Federations)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } },
                    Prohibits = new AndSet(){ EPN.C_DevouringSwarm, EPN.C_Terravore }
                }
            },
            {
                EPN.C_DevouringSwarm,
                new Civic(EPN.C_DevouringSwarm, EPN.D_Utopia)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind } },
                    Prohibits = new AndSet(){ EPN.T_Lithoid }
                }
            },
            {
                EPN.C_Terravore,
                new Civic(EPN.C_Terravore, EPN.D_Lithoids)
                {
                    Requires = new HashSet<OrSet>(){new OrSet(){ EPN.A_HiveMind, EPN.T_Lithoid } }
                }
            }
            #endregion
        };

        public Civic(String name, String? dlc = null) : base(name, EmpirePropertyType.Civic, dlc) { }
    }
}