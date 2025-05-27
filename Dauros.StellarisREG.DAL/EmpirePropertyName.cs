using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Dauros.StellarisREG.DAL
{
    public static class EPN
    {
        #region Traits

        #region Initial
        public static String T_Adaptive => "Adaptive";
        public static String T_ExtremelyAdaptive => "Extremely Adaptive";
        public static String T_Agrarian => "Agrarian";
        public static String T_Charismatic => "Charismatic";
        public static String T_Communal => "Communal";
        public static String T_Conformists => "Conformists";
        public static String T_Conservationist => "Conservationist";
        public static String T_Docile => "Docile";
        public static String T_Enduring => "Enduring";
        public static String T_Venerable => "Venerable";
        public static String T_Industrious => "Industrious";
        public static String T_Ingenious => "Ingenious";
        public static String T_Intelligent => "Intelligent";
        public static String T_NaturalEngineers => "Natural Engineers";
        public static String T_NaturalPhysicists => "Natural Physicists";
        public static String T_NaturalSociologists => "Natural Sociologists";
        public static String T_Nomadic => "Nomadic";
        public static String T_QuickLearners => "Quick Learners";
        public static String T_RapidBreeders => "Rapid Breeders";
        public static String T_Resilient => "Resilient";
        public static String T_Strong => "Strong";
        public static String T_VeryStrong => "Very Strong";
        public static String T_Talented => "Talented";
        public static String T_Thrifty => "Thrifty";
        public static String T_Traditional => "Traditional";
        public static String T_Nonadaptive => "Nonadaptive";
        public static String T_Repugnant => "Repugnant";
        public static String T_Solitary => "Solitary";
        public static String T_Deviants => "Deviants";
        public static String T_Wasteful => "Wasteful";
        public static String T_Unruly => "Unruly";
        public static String T_Fleeting => "Fleeting";
        public static String T_Sedentary => "Sedentary";
        public static String T_SlowLearners => "Slow Learners";
        public static String T_SlowBreeders => "Slow Breeders";
        public static String T_Weak => "Weak";
        public static String T_Quarrelsome => "Quarrelsome";
        public static String T_Decadent => "Decadent";



        #endregion

        #region Origin Traits
        public static String T_Serviles => "Serviles";
		public static String T_Survivor => "Survivor";
		public static String T_VoidDweller => "Void Dweller";
        public static String T_Necrophage => "Necrophage";
		public static String T_CaveDweller => "Cave Dweller";
		public static String T_PerfectedGenes => "Perfected Genes";
		public static String T_PathogenicGenes => "Pathogenic Genes";
		public static String T_MalleableGenes => "Malleable Genes";
		public static String T_Wilderness => "Wilderness";
		public static String T_Stargazer => "Stargazer";
		public static String T_StormTouched => "Storm Touched";

		public static String T_CyberCommandos => "Cyber Commandos";
		public static String T_Unplugged => "Unplugged";
		public static String T_CloneSoldier => "Clone Soldier";
		
        public static String T_RadiationShields => "Radiation Shields";
		public static String T_Molebots => "Molebots";
		public static String T_ZeroGOptimized => "Zero-G Optimized";
		public static String T_SyntheticSalvation => "Synthetic Salvation";
		public static String T_LatentPsionic => "Latent Psionic";



		#endregion

		#region Leviathan Traits
		public static string T_Voidling => "Voidling";
		public static string T_Polymelic => "Polymelic";
		public static string T_DrakeScaled => "Drake-Scaled";
		#endregion

		#region Humanoid
		public static String T_ExistentialIteroparity => "Existential Iteroparity";
        public static String T_PsychoInfertility => "Psychological Infertility";
        public static String T_Jinxed => "Jinxed";
        #endregion

        #region Toxoid
        public static String T_Incubators => "Incubators";
        public static String T_Noxious => "Noxious";
        public static String T_InorganicBreath => "Inorganic Breath";
        #endregion

        #region PlantoidFungoid
        public static String T_Phototrophic => "Phototrophic";
        public static String T_Radiotrophic => "Radiotrophic";
        public static String T_Budding => "Budding";
        public static String T_InvSpecies => "Invasive Species";
        #endregion
        #region Lithoid
        public static String T_GaseousByproducts => "Gaseous Byproducts"; 
        public static String T_ScintillatingSkin => "Scintillating Skin";
        public static String T_VolatileExcretions => "Volatile Excretions";
        public static String T_Crystallization => "Crystallization";

		#endregion

		#region Biogenesis
		public static String T_Familial => "Familial";
		public static String T_GeneticMemory => "Genetic Memory";
		public static String T_Camouflage => "Camouflage";
		public static String T_Chromalogs => "Chromalogs";
		public static String T_EggLaying => "Egg Laying";
		public static String T_SpareOrgans => "Spare Organs";
		public static String T_SeasonalDormancy => "Seasonal Dormancy";
		public static String T_Flight => "Flight";
		public static String T_SpatialMastery => "Spatial Mastery";
		public static String T_Shelled => "Shelled";
		public static String T_AcidicVascularity => "Acidic Vascularity";

		public static String T_NascentStage => "Nascent Stage";
		public static String T_PermeableSkin => "Permeable Skin";
		public static String T_HollowBones => "Hollow Bones";
		public static String T_Rooted => "Rooted";
		public static String T_Brittle => "Brittle";

		#endregion

		#region Basic Traits
		public static String T_HiveMinded => "Hive-Minded";
		public static String T_Lithoid => "Lithoid";
		public static String T_Aquatic => "Aquatic";
		public static String T_MachineUnit => "Machine";
		#endregion


        
		public static String T_Waterproof => "Waterproof";

		#region Machine Traits
		#region Positive
		public static String T_AdaptiveFrames => "Adaptive Frames";
		public static String T_EfficientProcessors => "Efficient Processors";
		public static String T_Harvesters => "Harvesters";
		public static String T_PowerDrills => "Power Drills";
		public static String T_Superconductive => "Superconductive";
		public static String T_DoubleJointed => "Double Jointed";
        public static String T_Durable => "Durable";
		public static String T_EmotionEmulators => "Emotion Emulators";
		public static String T_MassProduced => "Mass-Produced";
		public static String T_Recycled => "Recycled";
		public static String T_StreamlinedProtocols => "Streamlined Protocols";
        public static String T_DomesticProtocols => "Domestic Protocols";
		public static String T_LogicEngines => "Logic Engines";
		public static String T_TradingAlgorithms => "Trading Algorithms";
		public static String T_EternalMachine => "Eternal Machine";
		public static String T_LoyaltyCircuits => "Loyalty Circuits";
		public static String T_PropagandaMachines => "Propaganda Machines";
		public static String T_EnhancedMemory => "Enhanced Memory";
		public static String T_LearningAlgorithms => "Learning Algorithms";
		public static String T_EngineeringCore => "Engineering Core";
		public static String T_PhysicsCore => "Physics Core";
		public static String T_SociologyCore => "Sociology Core";
		public static String T_IntegratedWeaponry => "Integrated Weaponry";
		#endregion
		#region Negative
		public static String T_Bulky => "Bulky";
		public static String T_CustomMade => "Custom-Made";
		public static String T_HighBandwidth => "High Bandwidth";
		public static String T_HighMaintenance => "High Maintenance";
		public static String T_Luxurious => "Luxurious";
		public static String T_Uncanny => "Uncanny";
        public static String T_RepurposedHardware => "Repurposed Hardware";
		public static String T_DelicateChassis => "Delicate Chassis";
		public static String T_ScarcitySubroutines => "Scarcity Subroutines";

        #endregion
        #region Design Traits
        public static String T_ArtGenerator => "Art Generator";
		public static String T_ConversationalAI => "Conversational AI";
		public static String T_Nannybot => "Nannybot";
		public static String T_ResearchAssistants => "Research Assistants";
		public static String T_WarMachine => "War Machine";
		public static String T_Workerbots => "Workerbots";
		#endregion

		#endregion

		#region Overtuned
		public static String T_AugmentedIntelligence => "Augmented Intelligence";
		public static String T_CommercialGenius => "Commercial Genius";
		public static String T_CraftedSmiles => "Crafted Smiles";
        public static String T_DedicatedMiner => "Dedicated Miner";
        public static String T_ExpressedTradition => "Expressed Tradition";
        public static String T_FarmAppendages => "Farm Appendages";
        public static String T_GeneMentorship => "Gene Mentorship";
        public static String T_JuicedPower => "Juiced Power";
        public static String T_LowMaintenance => "Low Maintenance";
        public static String T_SplicedAdaptability => "Spliced Adaptability";
        public static String T_TechnicalTalent => "Technical Talent";
		public static String T_FleetingExcellence => "Fleeting Excellence";
		public static String T_ElevatedSynapses => "Elevated Synapses";
        public static String T_PrePlannedGrowth => "Pre-Planned Growth";
        public static String T_ExcessiveEndurance => "Excessive Endurance";
		#endregion

		#region Cybernetic Creed
		public static String T_RitualisticImplants => "Ritualistic Implants";
		public static String T_AugmentationsChoir => "Augmentations of the Choir";
		public static String T_AugmentationsCommune => "Augmentations of the Commune";
		public static String T_AugmentationsFellowship => "Augmentations of the Fellowship";
		public static String T_AugmentationsTemplars => "Augmentations of the Templars";

		#endregion

		#region BioAscension 
		//These are the traits that are unlocked by Biological Ascension and therefore cannot be selected at game start
		//There are included here because they can act as blockers for other traits
		public static String T_Delicious => "Delicious";
		public static String T_Felsic => "Felsic";
		public static String T_NaturalMachinist => "Natural Machinist";
		public static String T_NerveStapled => "Nerve Stapled";
		public static String T_VatGrown => "Vat-Grown";
		public static String T_Erudite => "Erudite";
		public static String T_Fertile => "Fertile";
		public static String T_Robust => "Robust";
		public static String T_ExoticMetabolism => "Exotic Metabolism";
		#endregion

		#endregion

		#region DLC
		public static String D_Utopia => "Utopia";
        public static String D_Lithoids => "Lithoids";
        public static String D_SyntheticDawn => "Synthetic Dawn";
        public static String D_Megacorp => "Megacorp";
        public static String D_Federations => "Federations";
        public static String D_Apocalypse => "Apocalypse";
        public static String D_AncientRelics => "Ancient Relics";
        public static String D_Necroids => "Necroids";
        public static String D_Plantoids => "Plantoids";
        public static String D_Humanoids => "Humanoids";
        public static String D_Nemesis => "Nemesis";
        public static String D_Aquatics => "Aquatics";
        public static String D_Overlord => "Overlord";
        public static String D_FirstContact => "First Contact";
        public static String D_GalParagons => "Galactic Paragons";
        public static String D_Toxoids => "Toxoids";
        public static String D_AstralPlanes => "Astral Planes";

        public static String D_MachineAge => "Machine Age";
		public static String D_CosmicStorms => "Cosmic Storms";
		public static String D_GrandArchive => "Grand Archive";
		public static String D_Biogenesis => "Biogenesis";

		#endregion

		#region Ethics
		public static String Materialist => "Materialist";
        public static String MaterialistF => "Fanatic Materialist";
        public static String Spiritualist => "Spiritualist";
        public static String SpiritualistF => "Fanatic Spiritualist";
        public static String Authoritarian => "Authoritarian";
        public static String AuthoritarianF => "Fanatic Authoritarian";
        public static String Egalitarian => "Egalitarian";
        public static String EgalitarianF => "Fanatic Egalitarian";
        public static String Militarist => "Militarist";
        public static String MilitaristF => "Fanatic Militarist";
        public static String Pacifist => "Pacifist";
        public static String PacifistF => "Fanatic Pacifist";
        public static String Xenophile => "Xenophile";
        public static String XenophileF => "Fanatic Xenophile";
        public static String Xenophobe => "Xenophobe";
        public static String XenophobeF => "Fanatic Xenophobe";
        public static String Gestalt => "Gestalt Consiousness";

        #endregion

        #region Civics
        #region Standard
        public static String C_AgrarianIdyll => "Agrarian Idyll";
        public static String C_AristocraticElite => "Aristocratic Elite";
        public static String C_BeaconofLiberty => "Beacon of Liberty";
        public static String C_CitizenService => "Citizen Service";
        public static String C_CatalyticProcessing => "Catalytic Processing";
        public static String C_CorporateDominion => "Corporate Dominion";
        public static String C_CorveeSystem => "Corvée System";
        public static String C_CutthroatPolitics => "Cutthroat Politics";
        public static String C_DistinguishedAdmiralty => "Distinguished Admiralty";
        public static String C_EfficientBureaucracy => "Efficient Bureaucracy";
        public static String C_Environmentalist => "Environmentalist";
        public static String C_ExaltedPriesthood => "Exalted Priesthood";
        public static String C_FeudalSociety => "Feudal Society";
        public static String C_FreeHaven => "Free Haven";
        public static String C_FunctionalArchitecture => "Functional Architecture";
        public static String C_IdealisticFoundation => "Idealistic Foundation";
        public static String C_IdyllicBloom => "Idyllic Bloom";
        public static String C_ImperialCult => "Imperial Cult";
        public static String C_InwardPerfection => "Inward Perfection";
        public static String C_MasterfulCrafters => "Masterful Crafters";
        public static String C_Meritocracy => "Meritocracy";
        public static String C_MiningGuilds => "Mining Guilds";
        public static String C_NationalisticZeal => "Nationalistic Zeal";
        public static String C_ParliamentarySystem => "Parliamentary System";
        public static String C_PhilosopherKing => "Philosopher King";
        public static String C_PleasureSeekers => "Pleasure Seekers";
        public static String C_PoliceState => "Police State";
        public static String C_ShadowCouncil => "Shadow Council";
        public static String C_SlaverGuilds => "Slaver Guilds";
        public static String C_Technocracy => "Technocracy";
        public static String C_WarriorCulture => "Warrior Culture";
        public static String C_FanaticPurifiers => "Fanatic Purifiers";
        public static String C_BarbaricDespoilers => "Barbaric Despoilers";
        public static String C_ByzantineBureaucracy => "Byzantine Bureaucracy";
        public static String C_MerchantGuilds => "Merchant Guilds";
        public static String C_SharedBurdens => "Shared Burdens";
        public static String C_DiplomaticCorps => "Diplomatic Corps";
        public static String C_Memorialists =>"Memorialists";
        public static String C_Reanimators => "Reanimators";
        public static String C_DeathCult => "Death Cult";
        public static String C_Anglers => "Anglers";
        public static String C_PompousPurists => "Pompous Purists";


        public static String C_Ascensionists => "Ascensionists";
        public static String C_SelectiveKinship => "Selective Kinship";
        public static String C_Scavengers => "Scavengers";
        public static String C_MutagenicSpas => "Mutagenic Spas";
        public static String C_RelentlessIndustrialists => "Relentless Industrialists";
        public static String C_EagerExplorers => "Eager Explorers";
        public static String C_HeroicPast => "Heroic Past";
        public static String C_VaultsKnowledge => "Vaults of Knowledge";
        public static String C_CrusaderSpirit => "Crusader Spirit";
        public static String C_OppressiveAutocracy => "Oppressive Autocracy";
        public static String C_DarkConsortium => "Dark Consortium";
        public static String C_DimensionalWorship => "Dimensional Worship";
        public static String C_HyperspaceSpeciality => "Hyperspace Speciality";
        public static String C_SovereignGuardianship => "Sovereign Guardianship";
		public static String C_GenesisGuides => "Genesis Guides";
		public static String C_CivilEducation => "Civil Education";
		public static String C_Crowdsourcing => "Crowdsourcing";
		public static String C_GeneticIdentification => "Genetic Identification";
		public static String C_NaturalDesign => "Natural Design";
		public static String C_Planetscapers => "Planetscapers";
		public static String C_StormDevotion => "Storm Devotion";
		public static String C_Beastmasters => "Beastmasters";
		public static String C_GalacticCurators => "Galactic Curators";
		public static String C_MarineMachines => "Marine Machines";
		public static String C_LuxuryLubePools => "Luxury Lubrication Pools";
		public static String C_LubricationTanks => "Lubrication Tanks";

        public static String C_RapidReplicator => "Rapid Replicator";
		public static String C_StaticResearchAnalysis => "Static Research Analysis";
		public static String C_Warbots => "Warbots";

		#endregion
		#region Hive Mind
		public static String C_Ascetic => "Ascetic";
        public static String C_DevouringSwarm => "Devouring Swarm";
        public static String C_DividedAttention => "Divided Attention";
        public static String C_ElevationalContemplations => "ElevationalContemplations";
        public static String C_NaturalNeuralNetwork => "Natural Neural Network";
        public static String C_Empath => "Empath";
        public static String C_IdyllicBloomHM => "Idyllic Bloom HM";
        public static String C_MemorialistHM => "Memorialist HM";
        
        public static String C_OneMind => "One Mind";
        public static String C_OrganicReprocessing => "Organic Reprocessing";
        public static String C_PooledKnowledge => "Pooled Knowledge";
        public static String C_StrengthofLegions=> "Strength of Legions";
        public static String C_SubspaceEphapse => "Subspace Ephapse";
        public static String C_SubsumedWill => "Subsumed Will";
        public static String C_Terravore=> "Terravore";
        public static String C_WildSwarm => "Wild Swarm";
        public static String C_ClimateModelingHM => "Climate Modeling HM";

		public static String C_VoidHive => "VoidHive";
        public static String C_CordycepticDrones => "Cordyceptic Drones";
        public static String C_PermutationPools => "Permutation Pools";
        public static String C_Stargazers => "Stargazers";
        public static string C_AutonomousDrones => "AutonomousDrones";
        public static String C_NeuralVaults => "Neural Vaults";
        public static String C_GuardianCluster => "Guardian Cluster";
        public static String C_HyperspaceSyncHM => "Hyperspace Synchronicity HM";
        public static String C_CultivationDrones => "Cultivation Drones";
		public static String C_GenesisSymbiotes => "Genesis Symbiotes";
		public static String C_MycorrhizalIdeal => "Mycorrhizal Ideal";
        public static String C_InnateDesign => "Innate Design";
		public static string C_AerospaceAdaption => "Aerospace Adaptation";
		public static String C_Bodysnatcher => "Bodysnatcher";
		public static String C_FamiliarFace => "Familiar Face";
        public static String C_SharedGenetics => "Shared Genetics";
		public static String C_DevouringWilderness => "Devouring Wilderness";
		public static string C_CaretakerNetworkHM => "Caretaker Network HM";

		#endregion

		#region Machine Intelligence
		public static String C_BuiltToLast => "Built to Last";
		public static String C_Constructobot => "Constructobot";
        public static String C_DelegatedFunctions => "Delegated Functions";
        public static String C_DeterminedExterminator => "Determined Exterminator";
        public static String C_DrivenAssimilator => "Driven Assimilator";
        public static String C_ElevationalHypotheses => "Elevational Hypotheses";
        public static String C_FactoryOverclocking => "Factory Overclocking";
        public static String C_Introspective => "Introspective";
        public static String C_MaintenanceProtocols => "Maintenance Protocols";
        public static String C_MemorialistMI => "Memorialist MI";
        public static String C_OTAUpdates => "OTA Updates";
        public static String C_RapidReplicatorMI => "Rapid Replicator ";
        public static String C_Rockbreakers => "Rockbreakers";
        public static String C_RogueServitor => "Rogue Servitor";
        public static String C_StaticResearchAnalysisMI => "Static Research Analysis ";
        public static String C_UnitaryCohesion => "Unitary Cohesion";
        public static String C_WarbotsMI => "Warbots MI";
        public static String C_ZeroWasteProtocols => "Zero-Waste Protocols";

        
        public static String C_OrganicRetrofitting => "Organic Retrofitting";
        
        public static String C_HyperLubrication => "Hyper Lubrication";
		public static String C_ExplorationProtocols => "Exploration Protocols";
        public static String C_XPCache => "Experience Cache";
        public static String C_SovereignCircuits => "Sovereign Circuits";
        public static String C_GuardianMatrix => "Guardian Matrix";
        public static String C_HyperspaceSyncMI => "Hyperspace Synchronicity MI";
		public static String C_Astrometeorology => "Astrometeorology";
        public static String C_GardeningProtocols => "Gardening Protocols";
        public static String C_GenesisArchitects => "Genesis Architects";
		public static String C_ObsessionalDirective => "Obsessional Directive";
        public static String C_AstroMiningDrones => "Astro-Mining Drones";
		public static String C_SpywareDirectives => "Spyware Directives";
        public static String C_HyperLubeBasins => "Hyper Lubrication Basin";
		public static String C_Biodrones => "Biodrones";
        public static String C_ExperienceCache => "Experience Cache";
		public static String C_DiplomaticProtocols => "Diplomatic Protocols";
		public static String C_ClimateModelingMI => "Climate Modeling MI";
		public static String C_StalwartNetwork => "Stalwart Network";
		public static String C_TacticalAlgorithms => "Tactical Algorithms";
		public static string C_CaretakerNetworkMI => "Caretaker Network MI";
		#endregion

		#region Corporate
		public static String C_BrandLoyalty => "Brand Loyalty";
        public static String C_CorporateDeathCult => "Corporate Death Cult";
        public static String C_CorporateHedonism => "Corporate Hedonism";
        public static String C_CriminalHeritage => "Criminal Heritage";
        public static String C_Franchising => "Franchising";
        public static String C_FreeTraders => "Free Traders";
        public static String C_GospelMasses => "Gospel of the Masses";
        public static String C_IndenturedAssets => "Indentured Assets";
        public static String C_MastercraftInc => "Mastercraft Inc.";
        public static String C_MediaConglomerate => "Media Conglomerate";
        public static String C_NavalContractors => "Naval Contractors";
        public static String C_PrivateMilitaryCompanies => "Private Military Companies";
        public static String C_PrivateProspectors => "Private Prospectors";
        public static String C_PublicRelationsSpecialists => "Public Relations Specialists";
        public static String C_RuthlessCompetition => "Ruthless Competition";
        public static String C_TradingPosts => "Trading Posts";
        public static String C_CorporateAnglers => "Corporate Anglers";
        public static String C_WorkerCooperative => "Worker Cooperative";
        public static String C_Gigacorp => "Gigacorp";
        public static String C_CatalyticRecyclers => "Catalytic Recyclers";
        public static String C_PermanentEmployment => "Permanent Employment";
        public static String C_TrawlingOperations => "Trawling Operations";
        public static String C_RefurbishmentDivision => "Refurbishment Division";
        public static String C_PrivatizedExploration => "Privatized Exploration";
        public static String C_PrecisionCogs => "Precision Cogs";
        public static String C_KnowledgeMentorship => "Knowledge Mentorship";
        public static String C_LetterMarque => "Letters of Marque";
        public static String C_PharmaState => "Pharma State";
        public static String C_CorporateProtectorate => "Corporate Protectorate";
        public static String C_DimensionalEnterprise => "Dimensional Enterprise";
        public static String C_HyperspaceTrade => "Hyperspace Trade";
        public static String C_ShadowCorpation => "Shadow Corporation";
		public static String C_MutagenicLuxury => "Mutagenic Luxury";
		public static String C_ShareholderValues => "Shareholder Values";
		public static String C_AstrogenesisTechnologies => "Astrogenesis Technologies";
		public static String C_WeatherExploitation => "Weather Exploitation";
		public static String C_DecentralizedRandD => "Decentralized R&D";
		public static String C_SequencedSecurities => "Sequenced Securities";
        public static String C_GeoEngineeringInc => "Geo-Engineering Inc.";
		public static String C_MaritimeRobotics => "Maritime Robotics";
		public static String C_AugmentationBazaars => "Augmentation Bazaars";
		public static String C_StormInfluencers => "Storm Influencers";
		public static String C_AntiquarianExpertise => "Antiquarian Expertise";
		public static String C_SpaceRanchers => "Space Ranchers";

		#endregion
		#endregion

		#region Authority

		public static String A_Democratic => "Democratic";
        public static String A_Oligarchic => "Oligarchic";
        public static String A_Dictatorial => "Dictatorial";
        public static String A_Imperial => "Imperial";
        public static String A_HiveMind => "Hive Mind";
        public static String A_MachineIntelligence => "Machine Intelligence";
        public static String A_Corporate => "Corporate";

        #endregion

        #region ShipTypes
        public static String S_Mechanical => "Mechanical";
        public static String S_Biological => "Biological";
		#endregion

		#region Origins
		#region Ascension Origins
		public static String O_TeachersShroud => "Teachers of the Shroud";
        public static String O_CyberneticCreed => "Cybernetic Creed";
		public static String O_SyntheticFertility => "Synthetic Fertility";
		public static String O_EvolutionaryPredators => "Evolutionary Predators";
		#endregion

		#region Species Restricted Origins
		public static String O_FruitfulPartnership => "Fruitful Partnership";
		public static String O_CalamitousBirth => "Calamitous Birth";
		public static String O_ArcWelders => "Arc Welders";
		#endregion

		#region Gestalt Origins
		public static String O_TreeofLife => "Tree of Life";
		public static String O_ProgenitorHive => "Progenitor Hive";
		public static String O_ResourceConsolidation => "Resource Consolidation";
		public static String O_Wilderness => "Wilderness ";//This has an added space to differentiate it from the Wilderness trait
		#endregion
		public static String O_LostColony => "Lost Colony";
        public static String O_Mechanist => "Mechanist";
        public static String O_GalacticDoorstep => "Galactic Doorstep";
        public static String O_ProsperousUnification => "Prosperous Unification";
        public static String O_SyncreticEvolution => "Syncretic Evolution";
        
        
        public static String O_CloneArmy => "Clone Army";
        public static String O_LifeSeeded => "Life-Seeded";
        public static String O_PostApocalyptic => "Post-Apocalyptic";
        public static String O_Remnants => "Remnants";
        
        public static String O_CommonGround => "Common Ground";
        public static String O_Hegemon => "Hegemon";
        public static String O_Doomsday => "Doomsday";
        public static String O_Giants => "On the Shoulders of Giants";
        public static String O_Scion => "Scion";
        public static String O_ShatteredRing => "Shattered Ring";
        public static String O_VoidDwellers => "Void Dwellers";
		public static String O_Voidforged => "Voidforged";
		public static String O_Necrophage => "Necrophage ";//This has an added space to differentiate it from the Necrophage trait
		public static String O_HereBeDragons => "Here Be Dragons";
        public static String O_OceanParadise => "Ocean Paradise";

        public static String O_ImperialFiefdom => "Imperial Fiefdom";
        
        
        public static String O_SlingshotStars => "Slingshot to the Stars";
        public static String O_Subterranean => "Subterranean";

        
        public static String O_KnightsToxicGod => "Knights of the Toxic God";
        public static String O_Overtuned => "Overtuned";
        public static String O_BrokenShackles => "Broken Shackles";
        public static String O_Payback => "Payback";
        public static String O_FearDark => "Fear of the Dark";
        public static String O_UnderOneRule => "Under One Rule";
        public static String O_Riftworld => "Riftworld";
		public static String O_HardReset => "Hard Reset";
		public static String O_StormChasers => "Storm Chasers";
		public static String O_PrimalCalling => "Primal Calling";
		public static String O_TreasureHunters => "Treasure Hunters";
		public static String O_StarlitCitadel => "Starlit Citadel";
        public static String O_RadioactiveRovers => "Radioactive Rovers";
		#endregion


		#region Species Archetypes

		//public static String AT_Organic => "Organic type";
		//public static String AT_Machine => "Machine type";
		//public static String AT_Lithoid => "Lithoid type";

		#endregion
		#region Phenotypes


		public static String PH_Humanoid => "Humanoid species";
		public static String PH_Mammalian => "Mammalian species";
		public static String PH_Reptilian => "Reptilian species";
        public static String PH_Avian => "Avian species";
		public static String PH_Arthropoid => "Arthropoid species";
		public static String PH_Molluscoid => "Molluscoid species";
		public static String PH_Fungoid => "Fungoid species";
		public static String PH_Plantoid => "Plantoid species";
		public static String PH_Lithoid => "Lithoid species";
		public static String PH_Necroid => "Necroid species";
		public static String PH_Aquatic => "Aquatic species";
		public static String PH_Toxoid => "Toxoid species";
		public static String PH_Machine => "Machine species";

        #endregion

        #region PlanetTypes
        public static String PT_Dry => "Dry";
		public static String PT_Wet => "Wet";
		public static String PT_Cold => "Cold";

		public static String PT_Arid => "Arid";
        public static String PT_Desert => "Desert";
        public static String PT_Savanna => "Savanna";
        public static String PT_Alpine => "Alpine";
        public static String PT_Arctic => "Arctic";
        public static String PT_Tundra => "Tundra";
        public static String PT_Continental => "Continental";
        public static String PT_Ocean => "Ocean";
        public static String PT_Tropical => "Tropical";
		public static String PT_Habitat => "Habitat";
		public static String PT_Gaia => "Gaia";
		public static String PT_RingWorld => "Ring World";
		public static String PT_Machine => "Machine World";
		public static String PT_Tomb => "Tomb World";
        public static String PT_Relic => "Relic World";
		public static String PT_Ecumenopolis => "Ecumenopolis";
		public static String PT_HiveWorld => "Hive World";
		public static String PT_NaniteWorld => "Nanite World";
		public static String PT_SynapticLathe => "Synaptic Lathe";


		#endregion
	}

   
}
