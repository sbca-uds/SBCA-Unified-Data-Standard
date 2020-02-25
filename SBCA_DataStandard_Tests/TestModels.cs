using System;
using System.Collections.Generic;
using SBCA.UnifiedDataStandard.Component;
using SBCA.UnifiedDataStandard.Component.Bearings;
using SBCA.UnifiedDataStandard.Component.Connectors;
using SBCA.UnifiedDataStandard.Component.Connectors.ConnectorMaterials;
using SBCA.UnifiedDataStandard.Component.Geometry;
using SBCA.UnifiedDataStandard.Component.InstallationHardware.HardwareMaterials;
using SBCA.UnifiedDataStandard.Component.Members;
using SBCA.UnifiedDataStandard.Component.Members.MemberMaterials;
using SBCA.UnifiedDataStandard.QualityControl;

namespace SBCA.UnifiedDataStandard.Tests
{
    public static class TestModels
    {
        public static ComponentFile TestComponent { get; set; } = new ComponentFile()
        {
            Name = "Test",
            Guid = new Guid("DCBA9337-2417-46F4-82ED-27CFD6BB5E4B"),
            AngleUnit = AngleUnit.Degrees,
            DistanceUnit = DistanceUnit.Inches,
            NumberOfPlies = 1,
            CreationTimeStamp = DateTime.Parse("2/25/2020"),
            CreationProgram = "SBCA Uniform Data Standard Repository Tests",
            CreationProgramVersion = new Version(0, 1, 2).ToString(),
            ComponentUsage = ComponentUsage.Roof,
            Lumbers = TestLumbers,
            ConnectorPlateTypes = TestConnectorPlateTypes,
            PliesFieldInstalled = false,
            HangerTypes = TestHangers,

            Members = new List<Member>()
            {
                new Member()
                {
                    Name = "B1",
                    Guid = Guid.Parse("A9F7FCF8-EA8D-46E2-9024-F30FE02BC814"),
                    MaterialGuid = Guid.Parse("9db95b90-542e-4045-ae39-42ce31ef65f8"),
                    MaterialDescription = "#2 SYP 2x4",
                    StockLength = 120,
                    MemberType = MemberType.BottomChord,
                    Thickness = 1.5,
                    BaseVertices = new List<Point2D>()
                    {
                        new Point2D()
                        {
                            X = 100,
                            Y = 0,
                        },

                        new Point2D()
                        {
                            X = 100,
                            Y = 3.5,
                        },

                    },
                    EndVertices = new List<Point2D>()
                    {
                        new Point2D()
                        {
                            X = 110,
                            Y = 0,
                        },

                        new Point2D()
                        {
                            X = 110,
                            Y = 3.5,
                        }
                    }
                },
            },


            ConnectorPlatePairs = new List<ConnectorPlatePair>()
            {
                new ConnectorPlatePair()
                {
                    Guid = new Guid("D1834CE8-4BDA-44A0-AD97-B277D037DCFE"),
                    Name = "Joint 1",
                    ConnectorPlates = new List<ConnectorPlate>()
                    {
                        new ConnectorPlate()
                        {
                            Name = "1",
                            MaterialGuid = Guid.Parse("92862168-2B8C-42F6-9A68-68EDAABEBC29"),
                            Center = new Point3D(){X = 60.0, Y = 3.5, Z = 1.5},
                            ThicknessDirection = new Direction3D(){X = 0.0, Y = 0.0, Z = 1.0 },
                            WidthDirection = new Direction3D(){X = 0.0, Y = 0.0, Z = 1.0 },
                            LengthDirection = new Direction3D(){X = 0.0, Y = 0.0, Z = 1.0 },
                        },
                        new ConnectorPlate()
                        {
                            Name = "1",
                            MaterialGuid = Guid.Parse("92862168-2B8C-42F6-9A68-68EDAABEBC29"),
                            Center = new Point3D(){X = 60.0, Y = 3.5, Z = -1.5},
                            ThicknessDirection = new Direction3D(){X = 0.0, Y = 0.0, Z = 1.0 },
                            WidthDirection = new Direction3D(){X = 0.0, Y = 0.0, Z = 1.0 },
                            LengthDirection = new Direction3D(){X = 0.0, Y = 0.0, Z = 1.0 },
                        },
                    },
                }
            },

            Bearings = new List<Bearing>()
            {
                new Bearing()
                {
                    Guid = Guid.Parse("1E9E3783-E616-4511-B62B-5DD5EDA62FCE"),
                    Description = "Hanger",
                    //AssociatedHardwareSetGuid = Guid.Parse("2E6993B2-888A-40D9-B40D-468A836AAA13"),
                    Width = 3.5,
                    Thickness = 1.5,
                    Center = new Point2D(){ X = 92.5, Y = 0 },
                },

                new Bearing()
                {
                    Guid = Guid.Parse("93067B38-4823-4D07-83CB-9FDD090B81D7"),
                    Description = "Double Wall Plate",
                    Width = 3.5,
                    Thickness = 1.5,
                    Center = new Point2D(){ X = 1.75, Y = 0 },
                }
            },
        };

        public static List<Lumber> TestLumbers => new List<Lumber>()
        {
            new Lumber()
            {
                Guid = Guid.Parse("9db95b90-542e-4045-ae39-42ce31ef65f8"),
                Description = "2x4" + LumberGrade.Number2 + LumberSpecies.SouthernPine,
                Grade = LumberGrade.Number2,
                Species = LumberSpecies.SouthernPine,
                Structure = Structure.Sawn,
                TreatmentType = "None",
                GradingMethod = GradingMethod.Visual,
                ActualThickness = 1.5,
                ActualWidth = 3.5,
                NominalThickness = "2",
                NominalWidth = "4",
            }
        };

        public static List<ConnectorPlateType> TestConnectorPlateTypes => new List<ConnectorPlateType>()
        {
            new ConnectorPlateType()
            {
                Guid = Guid.Parse("92862168-2B8C-42F6-9A68-68EDAABEBC29"),
                Description = "AS20 4x4",
                PlateManufacturer = PlateManufacturer.Simpson,
                PlateGauge = PlateGauge.Twenty,
                Length = 4,
                Width = 4,
                Thickness = 0.0356,
                Galvinized = true,
                StrengthGrade = StrengthGrade.Standard,
                TeethPerSquareInch = 8,
            }
        };

        public static List<HangerType> TestHangers => new List<HangerType>()
        {
            new HangerType()
            {
                Guid = Guid.Parse("2E6993B2-888A-40D9-B40D-468A836AAA13"),
                Description = "Hanger 1",
            }
        };

        public static QualityControlFile TestQualityControlFile { get; set; } = new QualityControlFile()
        {
            ComponentName = "Test",
            ComponentGuid = new Guid("DCBA9337-2417-46F4-82ED-27CFD6BB5E4B"),
            Guid = Guid.Parse("39842E94-D740-45DD-B7B1-0E5D0FFAE4F0"),
            PlateQualityControlDatas = new List<PlateQualityControlData>()
            {
                new PlateQualityControlData()
                {
                    AreaMethod = AreaMethod.Gross,
                    PlatePairGuid = Guid.Parse("d1834ce8-4bda-44a0-ad97-b277d037dcfe"),
                    RotationToleranceMax = 10.0,
                    RotationToleranceMin = -10.0,
                    ZeroTolerancePolygon = new Polygon2D
                    {
                        Vertices = new List<Point2D>
                        {
                            
                        },
                    },
                    ContactAreas = new List<PlateMemberContactArea>()
                    {
                        new PlateMemberContactArea()
                        {
                            JointStressIndex = .95,
                            MemberGuid = Guid.Parse("A9F7FCF8-EA8D-46E2-9024-F30FE02BC814"),
                            MemberName = "B1",
                            RequiredArea = 24.0,
                            RequiredTeeth = 52,
                        }
                    }
                }
            }

        };

        public static UnifiedDataStandardFile TestUnifiedDataStandardFile { get; set; } = new UnifiedDataStandardFile()
        {
            Manifest = new Manifest()
            {
                Version = new Version(0, 1, 2),
            },
            ComponentFiles = new List<ComponentFile>()
            {
                TestComponent,
            },
            QualityControlFiles = new List<QualityControlFile>()
            {
                TestQualityControlFile,
            },
        };
    }
}
