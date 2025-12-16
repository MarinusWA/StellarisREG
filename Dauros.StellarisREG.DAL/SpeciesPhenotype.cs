using System;
using System.Collections.Generic;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public class SpeciesPhenotype : EmpireProperty
    {
        public static Dictionary<String, SpeciesPhenotype> Collection => new Dictionary<string, SpeciesPhenotype>()
        {
            { 
                EPN.PH_Humanoid,
                new SpeciesPhenotype(EPN.PH_Humanoid){ }
            },
			{
				EPN.PH_Mammalian,
				new SpeciesPhenotype(EPN.PH_Mammalian){}
			},
			{
				EPN.PH_Reptilian,
				new SpeciesPhenotype(EPN.PH_Reptilian){}
			},
			{
				EPN.PH_Avian,
				new SpeciesPhenotype(EPN.PH_Avian){}
			},
			{
				EPN.PH_Arthropoid,
				new SpeciesPhenotype(EPN.PH_Arthropoid){}
			},
			{
				EPN.PH_Molluscoid,
				new SpeciesPhenotype(EPN.PH_Molluscoid){}
			},
			{
				EPN.PH_Fungoid,
				new SpeciesPhenotype(EPN.PH_Fungoid, dlc: new []{EPN.D_Plantoids}.ToOrSet()){}
			},
			{
				EPN.PH_Plantoid,
				new SpeciesPhenotype(EPN.PH_Plantoid, dlc: new []{EPN.D_Plantoids}.ToOrSet()){}
			},
			{
				EPN.PH_Lithoid,
				new SpeciesPhenotype(EPN.PH_Lithoid, dlc: new []{EPN.D_Lithoids}.ToOrSet())
				{GrantedTraits = new AndSet(){ EPN.T_Lithoid } }
			},
			{
				EPN.PH_Necroid,
				new SpeciesPhenotype(EPN.PH_Necroid, dlc : new[] { EPN.D_Necroids }.ToOrSet())
			},
			{
				EPN.PH_Aquatic,
				new SpeciesPhenotype(EPN.PH_Aquatic, dlc : new[] { EPN.D_Aquatics }.ToOrSet())
			},
			{
				EPN.PH_Toxoid,
				new SpeciesPhenotype(EPN.PH_Toxoid, dlc : new[] { EPN.D_Toxoids }.ToOrSet()){}
			},
			{
				EPN.PH_Machine,
				new SpeciesPhenotype(EPN.PH_Machine, 
					//It's strictly speaking incorrect to say that Shadows of the Shroud allows Machine species as it's only the Shroud-Forged Origin that allows this.
					//However, I'm not going to create an exception for this one case. Especially since most people who buy Shadows of the Shroud will likely also own Synthetic Dawn or Machine Age.
					dlc : new[] { EPN.D_SyntheticDawn,EPN.D_MachineAge, EPN.D_ShadowShroud }.ToOrSet(),
					
					requirements : new []{EPN.A_MachineIntelligence}.ToOrSet()
					){GrantedTraits = new AndSet() { EPN.T_MachineUnit }}
			},
			{
				EPN.PH_Psionic,
				new SpeciesPhenotype(EPN.PH_Psionic, dlc : new[] { EPN.D_ShadowShroud }.ToOrSet()){}
			},
			{
				EPN.PH_Thermophile,
				new SpeciesPhenotype(EPN.PH_Thermophile, dlc : new[] { EPN.D_Infernals }.ToOrSet()){}
			},
			{
				EPN.PH_TankVessel,
				new SpeciesPhenotype(EPN.PH_TankVessel, dlc : new[] { EPN.D_ShadowShroud }.ToOrSet()){ GrantedTraits = new AndSet(){ EPN.T_Tankbound } }
			},

		};

		public SpeciesPhenotype(String name, HashSet<OrSet>? dlc = null,
			HashSet<OrSet>? requirements = null, AndSet? prohibitions = null)
			: base(name, EmpirePropertyType.SpeciesPhenotype, dlc, requirements, prohibitions) { }
	}
}
