using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dauros.StellarisREG.DAL
{
	public static class EPNSET
	{



		public static HashSet<String> HS_Anglers =
			new HashSet<String>() { EPN.C_Anglers, EPN.C_TrawlingOperations, EPN.C_MarineMachines, EPN.C_MaritimeRobotics};

		public static HashSet<String> HS_Beastmasters =
			new HashSet<String>() { EPN.C_Beastmasters, EPN.C_SpaceRanchers};

		public static HashSet<String> HS_Catalytic =
			new HashSet<String>() { EPN.C_CatalyticProcessing, EPN.C_CatalyticRecyclers, EPN.C_OrganicReprocessing };

		public static HashSet<String> HS_Chosen =
			new HashSet<String>() { EPN.C_Chosen, EPN.C_ChosenExecutives };

		public static HashSet<String> HS_Crowdsourcing =
			new HashSet<String>() { EPN.C_Crowdsourcing, EPN.C_DecentralizedRandD };

		public static HashSet<String> HS_DarkConsortium =
			new HashSet<String>() { EPN.C_DarkConsortium, EPN.C_ShadowCorpation};
		
		public static HashSet<String> HS_DeathCult =
			new HashSet<String>() { EPN.C_DeathCult, EPN.C_CorporateDeathCult };

		public static HashSet<String> HS_DimensionalWorship =
			new HashSet<String>() { EPN.C_DimensionalWorship, EPN.C_DimensionalEnterprise };

		public static HashSet<String> HS_EagerExplorers =
			new HashSet<String>() { EPN.C_EagerExplorers, EPN.C_PrivatizedExploration };

		public static HashSet<String> HS_GenesisGuides =
			new HashSet<String>() { EPN.C_GenesisGuides, EPN.C_AstrogenesisTechnologies, EPN.C_GenesisArchitects, EPN.C_GenesisSymbiotes };

		public static HashSet<String> HS_Genocidal =
			new HashSet<String>() { EPN.C_FanaticPurifiers,EPN.C_DevouringSwarm,EPN.C_DeterminedExterminator,EPN.C_ScorchedWorldHeralds};

		public static HashSet<String> HS_HyperspaceSpeciality =
			new HashSet<String>() { EPN.C_HyperspaceSpeciality, EPN.C_HyperspaceTrade};

		public static HashSet<String> HS_IdyllicBloom =
			new HashSet<String>() { EPN.C_IdyllicBloom, EPN.C_MycorrhizalIdeal };

		public static HashSet<String> HS_MutagenicSpas =
			new HashSet<String>() { EPN.C_MutagenicSpas, EPN.C_MutagenicLuxury,EPN.C_LuxuryLubePools,EPN.C_LubricationTanks,
				EPN.C_PermutationPools,EPN.C_HyperLubrication };

		public static HashSet<String> HS_NaturalDesign =
			new HashSet<String>() { EPN.C_NaturalDesign, EPN.C_InnateDesign };

		public static HashSet<String> HS_Planetscapers =
			new HashSet<String>() { EPN.C_Planetscapers, EPN.C_GeoEngineeringInc, EPN.C_CultivationDrones, EPN.C_GardeningProtocols };

		public static HashSet<String> HS_PleasureSeekers =
			new HashSet<String>() { EPN.C_PleasureSeekers, EPN.C_CorporateHedonism};

		public static HashSet<String> HS_Reanimators =
			new HashSet<String>() { EPN.C_Reanimators, EPN.C_PermanentEmployment};

		public static HashSet<String> HS_RelentlessIndustrialists =
			new HashSet<String>() { EPN.C_RelentlessIndustrialists, EPN.C_ShareholderValues };

		public static HashSet<String> HS_Slavers =
			new HashSet<String>() { EPN.C_SlaverGuilds, EPN.C_IndenturedAssets };

		public static HashSet<String> HS_SovereignGuardianship =
			new HashSet<String>() { EPN.C_SovereignGuardianship, EPN.C_CorporateProtectorate};

		public static HashSet<String> HS_StormDevotion =
			new HashSet<string>() { EPN.C_StormDevotion, EPN.C_StormInfluencers };

		
	}
}
