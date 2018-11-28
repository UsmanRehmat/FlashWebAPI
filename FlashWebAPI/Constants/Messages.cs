using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashWebAPI.Constants
{
    public class Messages
    {
        public static string SUCCESS= "Success";
        public static string ERROR = "Error";

        
    }
    public static class TestNames
    {
        public const string GAS_CHARGING = "Gas Charging Test";
        public const string LEAKAGE1 = "Leakage1 Test";
        public const string LEAKAGE2 = "Leakage2 Test";
        public const string LEAKAGE3 = "Leakage3 Test";
        public const string SAFETY = "Safety Test";
        public const string HEATING = "Heating Test";
        public const string PERFORMANCE = "Performance Test";
        public const string FINAL = "Final Test";
        public const string SOUND = "Sound Test";
        public const string InDoorRepairingStation = "Repairing Station1";
        public const string OutDoorRepairingStation = "Repairing Station1";
        public static List<string> Stations = new List<string> { SOUND, FINAL, PERFORMANCE, SAFETY,LEAKAGE1,LEAKAGE2,LEAKAGE3,GAS_CHARGING,HEATING,InDoorRepairingStation,OutDoorRepairingStation};
    }
    public static class RepairingStationNames
    {
        public static RepairingStation InDoorRepairingStation = new RepairingStation(AssemblyNames.INDOOR, TestNames.InDoorRepairingStation, new List<string>() { TestNames.PERFORMANCE, TestNames.SAFETY, TestNames.SOUND, TestNames.FINAL});
        public static RepairingStation OutDoorRepairingStation = new RepairingStation(AssemblyNames.OUTDOOR,TestNames.OutDoorRepairingStation, new List<string>() { TestNames.PERFORMANCE, TestNames.SAFETY, TestNames.SOUND, TestNames.FINAL, TestNames.LEAKAGE1, TestNames.LEAKAGE2,TestNames.LEAKAGE3,TestNames.HEATING });
        public static List<string> RepairingStations = new List<string> { TestNames.InDoorRepairingStation, TestNames.OutDoorRepairingStation };

    }
    public class RepairingStation
    {
        public string Name { set; get; }
        public string AssemblyName { set; get; }
        public List<string> TestStations { set; get; }
        public RepairingStation(string name,string assembly, List<string> test)
        {
            this.Name = name;
            this.AssemblyName = assembly;
            this.TestStations = test;
        }

    }

    public static class AssemblyNames
    {
        public const string INDOOR = "In door";
        public const string OUTDOOR = "Out door";
    }
}
