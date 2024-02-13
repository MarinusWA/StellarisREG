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
        public static String T_CloneSoldier => "Clone Soldier";
        public static String T_Survivor => "Survivor";
        public static String T_VoidDweller => "Void Dweller";
        public static String T_CaveDweller => "Cave Dweller";
        public static String T_PerfectGenes => "Perfected Genes";
        #endregion

        #region Humanoid
        public static String T_EIteroparity => "Existential Iteroparity";
        public static String T_PInfertility => "Psychological Infertility";
        public static String T_Jinxed => "Jinxed";
        #endregion

        #region Toxoid
        public static String T_Incubators => "Incubators";
        public static String T_Noxious => "Noxious";
        public static String T_InBreath => "Inorganic Breath";
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
        public static String T_Lithoid => "Lithoid";
        #endregion


        public static String T_MachineUnit => "MachineUnit";
        public static String T_Necrophage => "Necrophage";
        public static String T_Aquatic => "Aquatic";
        public static String T_HiveMinded => "Hive-Minded";
        public static String T_Stargazer => "Stargazer";

        #region Machine Traits

        public static String T_DomesticProtocols => "Domestic Protocols";
        public static String T_DoubleJointed => "Double Jointed";
        public static String T_Bulky => "Bulky";
        public static String T_Durable => "Durable";
        public static String T_HighMaintenance => "High Maintenance";
        public static String T_EfficientProcessors => "Efficient Processors";
        public static String T_EmotionEmulators => "Emotion Emulators";
        public static String T_Uncanny => "Uncanny";
        public static String T_EnhancedMemory => "Enhanced Memory";
        public static String T_Harvesters => "Harvesters";
        public static String T_LearningAlgorithms => "Learning Algorithms";
        public static String T_RepurposedHardware => "Repurposed Hardware";
        public static String T_LogicEngines => "Logic Engines";
        public static String T_LoyaltyCircuits => "Loyalty Circuits";
        public static String T_MassProduced => "Mass-Produced";
        public static String T_CustomMade => "Custom-Made";
        public static String T_PowerDrills => "Power Drills";
        public static String T_PropagandaMachines => "Propaganda Machines";
        public static String T_Recycled => "Recycled";
        public static String T_Luxurious => "Luxurious";
        public static String T_StreamlinedProtocols => "Streamlined Protocols";
        public static String T_HighBandwidth => "High Bandwidth";
        public static String T_Superconductive => "Superconductive";

        #endregion

        #region Overtuned
        public static String T_AugmentedIntelligence => "Augmented Intelligence";
        public static String T_CraftedSmiles => "Crafted Smiles";
        public static String T_DedicatedMiner => "Dedicated Miner";
        public static String T_ExpressedTradition => "Expressed Tradition";
        public static String T_FarmAppendages => "Farm Appendages";
        public static String T_GeneMentorship => "Gene Mentorship";
        public static String T_JuicedPower => "Juiced Power";
        public static String T_LowMaintenance => "Low Maintenance";
        public static String T_SplicedAdaptability => "Spliced Adaptability";
        public static String T_TechnicalTalent => "Technical Talent";
        public static String T_ElevatedSynapses => "Elevated Synapses";
        public static String T_PrePlannedGrowth => "Pre-Planned Growth";
        public static String T_ExcessiveEndurance => "Excessive Endurance";
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
        public static String C_OrganicReprocessingHM => "Organic Reprocessing HM";
        public static String C_PooledKnowledge => "Pooled Knowledge";
        public static String C_StrengthofLegions=> "Strength of Legions";
        public static String C_SubspaceEphapse => "Subspace Ephapse";
        public static String C_SubsumedWill => "Subsumed Will";
        public static String C_Terravore=> "Terravore";
        
        
        public static String C_VoidHive => "VoidHive";
        public static String C_CordycepticDrones => "Cordyceptic Drones";
        public static String C_PermutationPools => "Permutation Pools";
        public static String C_Stargazers => "Stargazers";
        public static string C_AutonomousDrones => "AutonomousDrones";
        public static String C_NeuralVaults => "Neural Vaults";
        public static String C_GuardianCluster => "Guardian Cluster";
        public static String C_HyperspaceSyncHM => "Hyperspace Synchronicity HM";

        #endregion

        #region Machine Intelligence
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
        public static String C_RapidReplicator => "Rapid Replicator";
        public static String C_Rockbreakers => "Rockbreakers";
        public static String C_RogueServitor => "Rogue Servitor";
        public static String C_StaticResearchAnalysis => "Static Research Analysis";
        public static String C_UnitaryCohesion => "Unitary Cohesion";
        public static String C_Warbots => "Warbots";
        public static String C_ZeroWasteProtocols => "Zero-Waste Protocols";

        
        public static String C_OrganicReprocessingMI => "Organic Reprocessing MI";
        public static String C_HyperLube => "Hyper Lubrication Basin";
        public static String C_ExplorationProtocols => "Exploration Protocols";
        public static String C_XPCache => "Experience Cache";
        public static String C_SovereignCircuits => "Sovereign Circuits";
        public static String C_GuardianMatrix => "Guardian Matrix";
        public static String C_HyperspaceSyncMI => "Hyperspace Synchronicity MI";

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

        #region Origins
        public static String O_LostColony => "Lost Colony";
        public static String O_Mechanist => "Mechanist";
        public static String O_GalacticDoorstep => "Galactic Doorstep";
        public static String O_ProsperousUnification => "Prosperous Unification";
        public static String O_SyncreticEvolution => "Syncretic Evolution";
        public static String O_TreeofLife => "Tree of Life";
        public static String O_ResourceConsolidation => "Resource Consolidation";
        public static String O_CloneArmy => "Clone Army";
        public static String O_LifeSeeded => "Life-Seeded";
        public static String O_PostApocalyptic => "Post-Apocalyptic";
        public static String O_Remnants => "Remnants";
        public static String O_CalamitousBirth => "Calamitous Birth";
        public static String O_CommonGround => "Common Ground";
        public static String O_Hegemon => "Hegemon";
        public static String O_Doomsday => "Doomsday";
        public static String O_Giants => "On the Shoulders of Giants";
        public static String O_Scion => "Scion";
        public static String O_ShatteredRing => "Shattered Ring";
        public static String O_VoidDwellers => "Void Dwellers";
        public static String O_Necrophage => "Necrophage";
        public static String O_HereBeDragons => "Here Be Dragons";
        public static String O_OceanParadise => "Ocean Paradise";

        public static String O_ImperialFiefdom => "Imperial Fiefdom";
        public static String O_ProgenitorHive => "Progenitor Hive";
        public static String O_FruitfulPartnership => "Fruitful Partnership";
        public static String O_SlingshotStars => "Slingshot to the Stars";
        public static String O_Subterranean => "Subterranean";
        public static String O_TeachersShroud => "Teachers of the Shroud";
        public static String O_KnightsToxicGod => "Knights of the Toxic God";
        public static String O_Overtuned => "Overtuned";
        public static String O_BrokenShackles => "Broken Shackles";
        public static String O_Payback => "Payback";
        public static String O_FearDark => "Fear of the Dark";
        public static String O_UnderOneRule => "Under One Rule";
        public static String O_Riftworld => "Riftworld";

        #endregion


        #region Archetypes
        public static String AT_Animal => "Animal";
        public static String AT_Machine => "Machine ";
        public static String AT_Lithoid => "Lithoid ";
        public static String AT_Plantoid => "Plant/Fungus";
        
        #endregion

        #region PlanetTypes
        public static String PT_Arid => "Arid";
        public static String PT_Desert => "Desert";
        public static String PT_Savanna => "Savanna";
        public static String PT_Alpine => "Alpine";
        public static String PT_Artic => "Artic";
        public static String PT_Tundra => "Tundra";
        public static String PT_Continental => "Continental";
        public static String PT_Ocean => "Ocean";
        public static String PT_Tropical => "Tropical";
        public static String PT_Gaia => "Gaia";
        public static String PT_Tomb => "Tomb";
        public static String PT_Relic => "Relic";
        public static String PT_RingWorld => "Ring Segment";
        public static String PT_Machine => "Machine World";


        #endregion
    }
}
