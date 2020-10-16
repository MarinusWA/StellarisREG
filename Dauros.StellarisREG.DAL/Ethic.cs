using System;
using System.Collections.Generic;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public class Ethic : EmpireProperty
    {
        #region Singletons

        public static Dictionary<String, Ethic> Collection { get; } = new Dictionary<string, Ethic>()
        {
            {
                EPN.Authoritarian,
                new Ethic(EPN.Authoritarian)
                {
                    Cost = 1,
                    Prohibits = new AndSet() { EPN.AuthoritarianF, EPN.Egalitarian, EPN.EgalitarianF }
                }
            },
            {
                EPN.AuthoritarianF,
                new Ethic(EPN.AuthoritarianF)
                {
                    Cost = 2,
                    Prohibits = new AndSet() { EPN.Authoritarian, EPN.Egalitarian, EPN.EgalitarianF }
                }
            },
            {
                EPN.Egalitarian,
                new Ethic(EPN.Egalitarian)
                {
                    Cost = 1,
                    Prohibits = new AndSet() { EPN.Authoritarian, EPN.AuthoritarianF, EPN.EgalitarianF }
                }
            },{
                EPN.EgalitarianF,
                new Ethic(EPN.EgalitarianF)
                {
                    Cost = 2,
                    Prohibits = new AndSet() { EPN.Authoritarian, EPN.AuthoritarianF, EPN.Egalitarian }
                }
            },
            {
                EPN.Materialist,
                new Ethic(EPN.Materialist)
                {
                    Cost = 1,
                    Prohibits = new AndSet() { EPN.MaterialistF, EPN.Spiritualist, EPN.SpiritualistF }
                }
            },{
                EPN.MaterialistF,
                new Ethic(EPN.MaterialistF)
                {
                    Cost = 2,
                    Prohibits = new AndSet() { EPN.Materialist, EPN.Spiritualist, EPN.SpiritualistF }
                }
            },
            {
                EPN.Spiritualist,
                new Ethic(EPN.Spiritualist)
                {
                    Cost = 1,
                    Prohibits = new AndSet() { EPN.Materialist, EPN.MaterialistF, EPN.SpiritualistF }
                }
            },{
                EPN.SpiritualistF,
                new Ethic(EPN.SpiritualistF)
                {
                    Cost = 2,
                    Prohibits = new AndSet() { EPN.Materialist, EPN.MaterialistF, EPN.Spiritualist }
                }
            },
            {
                EPN.Militarist,
                new Ethic(EPN.Militarist)
                {
                    Cost = 1,
                    Prohibits = new AndSet() { EPN.Pacifist, EPN.PacifistF, EPN.MilitaristF }
                }
            },{
                EPN.MilitaristF,
                new Ethic(EPN.MilitaristF)
                {
                    Cost = 2,
                    Prohibits = new AndSet() { EPN.Pacifist, EPN.PacifistF, EPN.Militarist }
                }
            },
            {
                EPN.Pacifist,
                new Ethic(EPN.Pacifist)
                {
                    Cost = 1,
                    Prohibits = new AndSet() { EPN.Militarist, EPN.MilitaristF, EPN.PacifistF }
                }
            },{
                EPN.PacifistF,
                new Ethic(EPN.PacifistF)
                {
                    Cost = 2,
                    Prohibits = new AndSet() { EPN.Militarist, EPN.MilitaristF, EPN.Pacifist }
                }
            },
            {
                EPN.Xenophobe,
                new Ethic(EPN.Xenophobe)
                {
                    Cost = 1,
                    Prohibits = new AndSet() { EPN.Xenophile, EPN.XenophileF, EPN.XenophobeF }
                }
            },{
                EPN.XenophobeF,
                new Ethic(EPN.XenophobeF)
                {
                    Cost = 2,
                    Prohibits = new AndSet() { EPN.Xenophile, EPN.XenophileF, EPN.Xenophobe }
                }
            },
            {
                EPN.Xenophile,
                new Ethic(EPN.Xenophile)
                {
                    Cost = 1,
                    Prohibits = new AndSet() { EPN.Xenophobe, EPN.XenophobeF, EPN.XenophileF }
                }
            },{
                EPN.XenophileF,
                new Ethic(EPN.XenophileF)
                {
                    Cost = 2,
                    Prohibits = new AndSet() { EPN.Xenophobe, EPN.XenophobeF, EPN.Xenophile }
                }
            },{
                EPN.Gestalt,
                new Ethic(EPN.Gestalt)
                {
                    Cost = 3
                }
            }

        };

        #endregion

        public int Cost { get; set; }

        public Ethic(String name, String? dlc = null) : base(name, EmpirePropertyType.Ethic, dlc) { }
    }

    
}