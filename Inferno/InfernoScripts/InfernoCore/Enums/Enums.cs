﻿namespace Inferno
{
    public enum GameKey
    {
        EnterCar = 23,
        Sprint = 21,
        Jump = 22,
        Reload = 45,
        SeekCover = 44,
        Attack = 24,
        ChangeWeapon = 37,
        Aim = 25,
        LookBehind = 26,
        Stealth = 36,
        Cover = 44,
        VehicleAim = 68,
        VehicleAttack = 69,
        VehicleAccelerate = 71,
        VehicleBrake = 72,
        VehicleDuck = 73,
        VehicleExit = 75,
        VehicleHandbrake = 76,
        VehicleHorn = 86,
        VehicleLookBehind = 79,
        LX = 30,
        LY = 31,
        LStickUp = 32,
        LStickDown = 33,
        LStickLeft = 34,
        LStickRight = 35,
        RX = 1,
        RY = 2,
        RStickUp = 3,
        RStickDown = 4,
        RStickLeft = 5,
        RStickRight = 6,
        VehicleAccelerateKey = 232,
        VehicleForwardTiltKey = 209,
        VehicleBackwardTiltKey = 224
    };

    public enum FiringPattern
    {
        FullAuto = -957453492,
        BurstFire = 1073727030,
        BurstInCover = 40051185,
        BurstFireDriveby = -753768974,
        FromGround = 577037782,
        DelayFireByOneSec = 2055493265,
        SingleShot = 1566631136,
        BurstFirePistol = -1608983670,
        BurstFireSMG = 1863348768,
        BurstFireRifle = -1670073338,
        BurstFireMG = -1250703948,
        BurstFirePumpShotGun = 12239771,
        BurstFireHeli = -1857128337,
        BurstFireMicro = 1122960381,
        BurstFireBursts = 445831135,
        BurstFireTank = -490063247
    }

    

    public enum Weapon
    {
        UNARMED = -1569615261,
        ANIMAL = -100946242,
        COUGAR = 148160082,
        KNIFE = -1716189206,
        NIGHTSTICK = 1737195953,
        HAMMER = 1317494643,
        BAT = -1786099057,
        GOLFCLUB = 1141786504,
        CROWBAR = -2067956739,
        PISTOL = 453432689,
        COMBATPISTOL = 1593441988,
        APPISTOL = 584646201,
        PISTOL50 = -1716589765,
        MICROSMG = 324215364,
        SMG = 736523883,
        ASSAULTSMG = -270015777,
        ASSAULTRIFLE = -1074790547,
        CARBINERIFLE = -2084633992,
        ADVANCEDRIFLE = -1357824103,
        MG = -1660422300,
        COMBATMG = 2144741730,
        PUMPSHOTGUN = 487013001,
        SAWNOFFSHOTGUN = 2017895192,
        ASSAULTSHOTGUN = -494615257,
        BULLPUPSHOTGUN = -1654528753,
        BULLPURIFLE = 2132975508,
        STUNGUN = 911657153,
        SNIPERRIFLE = 100416529,
        HEAVYSNIPER = 205991906,
        HEAVYPISTOL = -771403250,
        HEAVYSHOTGUN = 984333226,
        REMOTESNIPER = 856002082,
        GRENADELAUNCHER = -1568386805,
        GRENADELAUNCHER_SMOKE = 1305664598,
        RPG = -1312131151,
        PASSENGER_ROCKET = 375527679,
        AIRSTRIKE_ROCKET = 324506233,
        STINGER = 1752584910,
        MINIGUN = 1119849093,
        GRENADE = -1813897027,
        STICKYBOMB = 741814745,
        SMOKEGRENADE = -37975472,
        BZGAS = -1600701090,
        MOLOTOV = 615608432,
        FIREEXTINGUISHER = 101631238,
        FIREWORK = 2138347493,
        PROXIMITYMINE = -1420407917,
        PETROLCAN = 883325847,
        DIGISCANNER = -38085395,
        BRIEFCASE = -2000187721,
        BRIEFCASE_02 = 28811031,
        BALL = 600439132,
        FLARE = 1233104067,
        VEHICLE_ROCKET = -1090665087,
        BARBED_WIRE = 1223143800,
        DROWNING = -10959621,
        DROWNING_IN_VEHICLE = 1936677264,
        BLEEDING = -1955384325,
        ELECTRIC_FENCE = -1833087301,
        EXPLOSION = 539292904,
        FALL = -842959696,
        EXHAUSTION = 910830060,
        HIT_BY_WATER_CANNON = -868994466,
        RAMMED_BY_CAR = 133987706,
        RUN_OVER_BY_CAR = -1553120962,
        MOW_OVER_BY_AIRCRAFT = -1323279794,
        HELI_CRASH = 341774354,
        FIRE = -544306709,
        MUSCKET = -1466123874,
        MARKSMANRIFLE = -952879014,
        RAILGUN = 1834241177,
        FLAREGUN = 1198879012,
        MARKSMANPISTOL = -598887786,
        MACHINEPISTOL = -619010992,
        GUSENBERG = 1627465347,
        TANK = 1945616459,
        REVOLVER = -1045183535,
        COMPACTRIFLE = 1649403952,
        DOUBLEBARRELSHOTGUN = -275439685,
        MINISMG = -1121678507,
        AUTOSHOTGUN = 317205821,
        COMPACTLAUNCHER = 125959754,
        PIPEBOMB = -1169823560,
        Bottle = -102323637,
        Dagger = -1834847097,
        Hatchet = -102973651,
        KnuckleDuster = -656458692,
        Machete = -581044007,
        Flashlight = -1951375401,
        SwitchBlade = -538741184,
        Poolcue = -1810795771,
        Wrench = 419712736,
        Battleaxe = -853065399,
        PistolMk2 = -1075685676,
        SMGMk2 = 2024373456,
        CombatMGMk2 = -608341376,
        AssaultRifleMk2 = 961495388,
        CarbineRifleMk2 = -86904375,
        HeavySniperMk2 = 177293209,
        HomingLauncher = 1672152130
    }

    public enum VehicleWeapon
    {
        ROTORS = -1323279794,
        TANK = 1945616459,
        SPACE_ROCKET = -123497569,
        PLANE_ROCKET = -821520672,
        PLAYER_LASER = -268631733,
        PLAYER_BULLET = 1259576109,
        PLAYER_BUZZARD = 1186503822,
        PLAYER_HUNTER = -1625648674,
        ENEMY_LASER = 1566990507,
        SEARCHLIGHT = -844344963,
        RADAR = -764006018,
    }

    public enum ExplosionType
    {
        GRENADE = -1236251694,
        GRENADELAUNCHER = 286056380,
        STICKYBOMB = -937058049,
        MOLOTOV = -61198893,
        ROCKET = 798856618,
        TANKSHELL = 1693512364,
        HI_OCTANE = 1436779599,
        CAR = 1768518260,
        PLANE = 428159217,
        PETROL_PUMP = 1114654932,
        BIKE = -411549476,
        DIR_STEAM = -1628533868,
        DIR_FLAME = 527211813,
        DIR_WATER_HYDRANT = 352593635,
        DIR_GAS_CANISTER = 845770333,
        BOAT = 1762719600,
        SHIP_DESTROY = 1907543711,
        TRUCK = 1115750597,
        BULLET = -1696146015,
        SMOKEGRENADELAUNCHER = -1014218325,
        SMOKEGRENADE = -1832600771,
        BZGAS = -515713583,
        FLARE = -1330848211,
    }

    /// <summary>
    /// ミッションキャラの扱い
    /// </summary>
    public enum MissionCharacterTreatmentType
    {
        AffectAllCharacter = 0,
        ExcludeUniqueCharacter = 1,
        ExcludeAllMissionCharacter = 2
    }

    public enum PedTaskAction
    {
        FALL_WITH_PARACHUTE = 334,
    }

    public enum CutSceneOnlyPedHash : uint
    {
        AbigailCutscene = 0x89768941,
        AmandaTownleyCutscene = 0x95EF18E3,
        AndreasCutscene = 0xE7565327,
        AnitaCutscene = 0x703F106,
        AntonCutscene = 0xA5C787B6,
        AshleyCutscene = 0x26C3D079,
        BallasogCutscene = 0xABEF0004,
        BankmanCutscene = 0x9760192E,
        BarryCutscene = 0x69591CF7,
        BeverlyCutscene = 0xB46EC356,
        BradCutscene = 0xEFE5AFE6,
        BradCadaverCutscene = 0x7228AF60,
        BrideCutscene = 0x82BF7EA1,
        BurgerDrugCutscene = 0x8CDCC057,
        Car3Guy1Cutscene = 0x4430687,
        Car3Guy2Cutscene = 0x1383A508,
        CarBuyerCutscene = 0x8CCE790F,
        CaseyCutscene = 0xEA969C40,
        ChefCutscene = 0xA347CA8A,
        ChinGoonCutscene = 0xA8C22996,
        ClayCutscene = 0xDBCB9834,
        CletusCutscene = 0xCAE9E5D5,
        CopCutscene = 0x9AB35F63,
        CrisFormageCutscene = 0xC1F380E6,
        CustomerCutscene = 0xA44F6F8B,
        DaleCutscene = 0xCE81655,
        DaveNortonCutscene = 0x8587248C,
        DebraCutscene = 0xECD04FE9,
        DeniseCutscene = 0x6F802738,
        DeniseFriendCutscene = 0xB58D2529,
        DevinCutscene = 0x2F016D02,
        DomCutscene = 0x4772AF42,
        DreyfussCutscene = 0x3C60A153,
        DrFriedlanderCutscene = 0xA3A35C2F,
        FabienCutscene = 0x47035EC1,
        FbiSuit01Cutscene = 0x585C0B52,
        FloydCutscene = 0x62547E7,
        FosRepCutscene = 0x1BCC157B,
        GCutscene = 0xA28E71D7,
        GroomCutscene = 0x7AAB19D2,
        GroveStrDlrCutscene = 0xE8594E22,
        GuadalopeCutscene = 0xF9513F1,
        GurkCutscene = 0xC314F727,
        HaoCutscene = 0xEC9E8F1C,
        HughCutscene = 0x6F139B54,
        HunterCutscene = 0x5B44892C,
        ImranCutscene = 0xE3420BDB,
        JanetCutscene = 0x3034F9E2,
        JanitorCutscene = 0xC2005A40,
        JewelassCutscene = 0x4440A804,
        JimmyBostonCutscene = 0x39677BD,
        JimmyDisantoCutscene = 0xB8CC92B4,
        JoeMinutemanCutscene = 0xF09D5E29,
        JohnnyKlebitzCutscene = 0xFA8AB881,
        JosefCutscene = 0x459762CA,
        JoshCutscene = 0x450EEF9D,
        LamarDavisCutscene = 0x45463A0D,
        LazlowCutscene = 0x38951A1B,
        LesterCrestCutscene = 0xB594F5C3,
        Lifeinvad01Cutscene = 0x72551375,
        MagentaCutscene = 0x5816C61A,
        ManuelCutscene = 0xFBB374CA,
        MarnieCutscene = 0x574DE134,
        MartinMadrazoCutscene = 0x43595670,
        MaryannCutscene = 0x998C7AD,
        MaudeCutscene = 0xBCC475CB,
        MerryWeatherCutscene = 0x613E626C,
        MichelleCutscene = 0x70AEB9C8,
        MiltonCutscene = 0xB76A330F,
        MollyCutscene = 0x45918E44,
        MoviePremFemaleCutscene = 0x4BBA84D9,
        MoviePremMaleCutscene = 0x8D67EE7D,
        MrKCutscene = 0xC3CC9A75,
        MrsPhillipsCutscene = 0xCBFDA3CF,
        MrsThornhillCutscene = 0x4F921E6E,
        NataliaCutscene = 0x4EFEB1F0,
        NervousRonCutscene = 0x7896DA94,
        NigelCutscene = 0xE1479C0B,
        OldMan1aCutscene = 0x1EEC7BDC,
        OldMan2Cutscene = 0x98F9E770,
        OmegaCutscene = 0x8B70B405,
        OrleansCutscene = 0xAD340F5A,
        OrtegaCutscene = 0xC0DB04CF,
        OscarCutscene = 0xF41F399B,
        PaperCutscene = 0x6B38B8F8,
        PatriciaCutscene = 0xDF8B1301,
        PornDudesCutscene = 0x2F4AFE35,
        PriestCutscene = 0x4D6DE57E,
        PrologueDriverCutscene = 0xF00B49DB,
        PrologueSec01Cutscene = 0x7FA2F024,
        PrologueSec02Cutscene = 0x1E9314A2,
        RampGangCutscene = 0xC2800DBE,
        RampHicCutscene = 0x858C94B8,
        RampHipsterCutscene = 0x21F58BB4,
        RampMarineCutscene = 0x616C97B9,
        RampMexCutscene = 0xF64ED7D0,
        ReporterCutscene = 0x2E420A24,
        RoccoPelosiCutscene = 0xAA64168C,
        RussianDrunkCutscene = 0x46521A32,
        ScreenWriterCutscene = 0x8BE12CEC,
        SiemonYetarianCutscene = 0xC0937202,
        SolomonCutscene = 0xF6D1E04E,
        SteveHainsCutscene = 0xA4E0A1FE,
        StretchCutscene = 0x893D6805,
        Stripper01Cutscene = 0xAEEA76B5,
        Stripper02Cutscene = 0x81441B71,
        TanishaCutscene = 0x42FE5370,
        TaoChengCutscene = 0x8864083D,
        TaosTranslatorCutscene = 0x53536529,
        TennisCoachCutscene = 0x5C26040A,
        TerryCutscene = 0x3A5201C5,
        TomCutscene = 0x69E8ABC3,
        TomEpsilonCutscene = 0x8C0FD4E2,
        TonyaCutscene = 0x6343DD19,
        TracyDisantoCutscene = 0x609B130,
        TrafficWardenCutscene = 0xDE2937F3,
        WadeCutscene = 0xD266D9D6,
        WeiChengCutscene = 0x30DB9D7B,
        ZimborCutscene = 0xEAACAAF0,
    }
}
