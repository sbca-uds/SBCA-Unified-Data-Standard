﻿namespace SBCA.UnifiedDataStandard.Component.Members.MemberMaterials
{
    // References:
    // http://www.awc.org/pdf/codes-standards/publications/nds/AWC-NDS2018-Supplement-ViewOnly-171027.pdf
    // https://www.spib.org/data/pdfs/design-values-tables-footnotes-2014.pdf
    // https://www.spib.org/data/pdfs/design-values-msr-mel-2014.pdf

    public enum LumberSpecies
    {
        AlaskaCedar,
        AlaskaHemlock,
        AlaskaSpruce,
        AlaskaYellowCedar,
        Aspen,
        Baldcypress,
        BalsamFir,
        Beech_Birch_Hickory,
        CoastSitkaSpruce,
        CoastSpecies,
        Cottonwood,
        DouglasFir_Larch,
        DouglasFir_Larch_North,
        DouglasFir_South,
        EasternHemlock,
        EasternHemlock_BalsamFir,
        EasternHemlock_Tamarack,
        EasternHemlock_Tamarack_North,
        EasternSoftwoods,
        EasternSpruce,
        EasternWhitePine,
        EasternWhitePine_North,
        Hem_Fir,
        Hem_Fir_North,
        MixedMaple,
        MixedOak,
        MixedSouthernPine,
        MountainHemlock,
        NorthernPine,
        NorthernRedOak,
        NorthernSpecies,
        NorthernWhiteCedar,
        PonderosaPine,
        RedMaple,
        RedOak,
        RedPine,
        Redwood,
        SitkaSpruce,
        SouthernPine,
        Spruce_Pine_Fir,
        Spruce_Pine_Fir_South,
        WesternCedars,
        WesternCedars_North,
        WesternHemlock,
        WesternHemlock_North,
        WesternWhitePine,
        WesternWoods,
        WhiteOak,
        YellowCedar,
        YellowPoplar,
        Other,
    }

    public enum LumberGrade
    {
        // Visually Graded
        SelectStructuralDense,
        SelectStructural,
        SelectStructuralNonDense,
        Number1Dense,
        Number1AndBetter,
        Number1,
        Number1NonDense,
        Number2Dense,
        Number2,
        Number2NonDense,
        Number3,
        Stud,
        Construction,
        Standard,
        Utility,

        // Machine Stress Rated
        MSR_750f_1_4E,
        MSR_850f_1_4E,
        MSR_900f_1_0E,
        MSR_975f_1_6E,
        MSR_1050f_1_2E,
        MSR_1050f_1_6E,
        MSR_1200f_1_2E,
        MSR_1200f_1_3E,
        MSR_1200f_1_6E,
        MSR_1250f_1_4E,
        MSR_1250f_1_6E,
        MSR_1350f_1_3E,
        MSR_1350f_1_4E,
        MSR_1400f_1_2E,
        MSR_1450f_1_3E,
        MSR_1450f_1_5E,
        MSR_1500f_1_4E,
        MSR_1500f_1_5E,
        MSR_1500f_1_6E,
        MSR_1500f_1_7E,
        MSR_1600f_1_4E,
        MSR_1650f_1_3E,
        MSR_1650f_1_5E,
        MSR_1650f_1_6E,
        MSR_1650f_1_7E,
        MSR_1700f_1_6E,
        MSR_1800f_1_5E,
        MSR_1800f_1_6E,
        MSR_1800f_1_8E,
        MSR_1800f_2_0E,
        MSR_1850f_1_7E,
        MSR_1950f_1_5E,
        MSR_1950f_1_7E,
        MSR_2000f_1_6E,
        MSR_2100f_1_8E,
        MSR_2250f_1_7E,
        MSR_2250f_1_8E,
        MSR_2250f_1_9E,
        MSR_2400f_1_8E,
        MSR_2400f_2_0E,
        MSR_2500f_2_2E,
        MSR_2550f_1_8E,
        MSR_2550f_2_1E,
        MSR_2700f_2_0E,
        MSR_2700f_2_2E,
        MSR_2850f_1_8E,
        MSR_2850f_2_3E,
        MSR_3000f_2_4E,

        // Machine Evaluated
        MEL_M_5,
        MEL_M_6,
        MEL_M_7,
        MEL_M_8,
        MEL_M_9,
        MEL_M_10,
        MEL_M_11,
        MEL_M_12,
        MEL_M_13,
        MEL_M_14,
        MEL_M_15,
        MEL_M_16,
        MEL_M_17,
        MEL_M_18,
        MEL_M_19,
        MEL_M_20,
        MEL_M_21,
        MEL_M_22,
        MEL_M_23,
        MEL_M_24,
        MEL_M_25,
        MEL_M_26,
        MEL_M_27,
        MEL_M_28,
        MEL_M_29,
        MEL_M_30,
        MEL_M_31,
        MEL_M_32,
        MEL_M_33,
        MEL_M_34,
        MEL_M_35,
        MEL_M_36,
        MEL_M_37,
        MEL_M_38,
        MEL_M_39,
        MEL_M_40,
        MEL_M_41,
        MEL_M_42,

        Other,
    }

    public enum Structure
    {
        Sawn,
        LaminatedVeneerLumber,
        LaminatedStrandLumber,
        OrientedStrandLumber,
        ParallelStrandLumber,
        StructuralCompositeLumber,
        Other,
    }

    public enum MemberType
    {
        TopChord,
        BottomChord,
        Web,
        Wedge,
        TopChordSlider,
        BottomChordSlider,
        GableStud,
        TrimEnd,
        WebBlock,
        EndVertical,
        NonStructuralBlock,
        KingPost,
        TopPlate,
        CapPlate,
        Cripple,
        Stud,
        Header,
        Other,
    }

    public enum GradingMethod
    {
        Visual,
        MachineStressRated,
        MachineEvaluated,
        Other,
    }
}
