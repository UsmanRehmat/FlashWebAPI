using FlashWebAPI.DB;
using FlashWebAPI.Models;
using System.Linq;

using System;
using Microsoft.EntityFrameworkCore;
using FlashWebAPI.Constants;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace FlashWebAPI.Services
{
    public class OutDoorAssemblyLineService
    {
        public static List<OutDoorAssemblyLine> GetAll()
        {
            try
            {
                DBContext dbContext = new DBContext();
                return dbContext.OutDoorAssemblyLines.ToList();
                //return JsonConvert.SerializeObject(dbContext.OutDoorAssemblyLines.ToList(),Formatting.None);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string AddOutDoorAssemblyLine(OutDoorAssemblyLine outDoorAssemblyLine)
        {
            try
            {
                DBContext dbContext = new DBContext();
                outDoorAssemblyLine.LineStartTime = DateTime.Now;
                dbContext.OutDoorAssemblyLines.Add(outDoorAssemblyLine);
                dbContext.SaveChanges();
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message;   
            }
        }
        public static string AddMotorQrCode(OutDoorAssemblyLine outDoorAssemblyLine)
        {
            try
            {
                //we are passing RFID data on each step
                DBContext dbContext = new DBContext();
                OutDoorAssemblyLine odal= dbContext.OutDoorAssemblyLines.Where(x => x.RFIDTag.Equals(outDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                if (odal != null)
                {
                    odal.MotorQRCode = outDoorAssemblyLine.MotorQRCode;
                    dbContext.SaveChanges();
                    return "true";
                }
                else
                {
                    return "Invalide RFID Tag";
                }
              
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddPCBQrCode(OutDoorAssemblyLine outDoorAssemblyLine)
        {
            try
            {
                //we are passing RFID data on each step
                DBContext dbContext = new DBContext();
                OutDoorAssemblyLine odal = dbContext.OutDoorAssemblyLines.Where(x => x.RFIDTag.Equals(outDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                if (odal != null)
                {
                    odal.PCBQRCode = outDoorAssemblyLine.PCBQRCode;
                    dbContext.SaveChanges();
                    return "true";
                }
                else
                {
                    return "Invalide RFID Tag";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddBarCode(OutDoorAssemblyLine outDoorAssemblyLine)
        {
            try
            {
                //we are passing RFID data on each step
                DBContext dbContext = new DBContext();
                OutDoorAssemblyLine odal = dbContext.OutDoorAssemblyLines.Where(x => x.RFIDTag.Equals(outDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                if (odal != null)
                {
                    odal.Barcode = outDoorAssemblyLine.Barcode;
                    dbContext.SaveChanges();
                    return "true";
                }
                else
                {
                    return "Invalide RFID Tag";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddGasChargingStation(OutDoorAssemblyLine outDoorAssemblyLine)
        {
            try
            {
                if (isValidRFID(outDoorAssemblyLine.RFIDTag))
                {
                    DBContext dbContext = new DBContext();
                    OutDoorAssemblyLine odal = dbContext.OutDoorAssemblyLines.Include(y => y.QualityTests).Where(x => x.RFIDTag.Equals(outDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                    if (odal != null)
                    {
                        odal.VaccumingPressure = outDoorAssemblyLine.VaccumingPressure;
                        odal.GasName = outDoorAssemblyLine.GasName;
                        odal.GasAmount = outDoorAssemblyLine.GasAmount;
                        dbContext.SaveChanges();
                        return AddQualityTest(outDoorAssemblyLine, TestNames.GAS_CHARGING);
                    }
                }
                return "Invalide RFID tag.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddLeakage1Station(OutDoorAssemblyLine outDoorAssemblyLine)
        {
            try
            {
                if (isValidRFID(outDoorAssemblyLine.RFIDTag))
                {
                    return AddQualityTest(outDoorAssemblyLine, TestNames.LEAKAGE1);
                }
                else
                {
                    return "Invalid RFID";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
        }
        public static string AddLeakage2Station(OutDoorAssemblyLine outDoorAssemblyLine)
        {
            try
            {
                if (isValidRFID(outDoorAssemblyLine.RFIDTag))
                {

                    
                        return AddQualityTest(outDoorAssemblyLine, TestNames.LEAKAGE2);
                    

                }
                else
                {
                    return "Invalid RFID";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public static string AddLeakage3Station(OutDoorAssemblyLine outDoorAssemblyLine)
        {
            try
            {
                if (isValidRFID(outDoorAssemblyLine.RFIDTag))
                {

                        return AddQualityTest(outDoorAssemblyLine, TestNames.LEAKAGE3);

                }
                else
                {
                    return "Invalid RFID";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public static string AddSafetyTest(OutDoorAssemblyLine outDoorAssemblyLine)
        {
            try
            {
                if (isValidRFID(outDoorAssemblyLine.RFIDTag))
                {
                  
                        return AddQualityTest(outDoorAssemblyLine, TestNames.SAFETY);
                  
                }
                else
                {
                    return "Invalid RFID";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddFinalTest(OutDoorAssemblyLine outDoorAssemblyLine)
        {
            try
            {
                if (isValidRFID(outDoorAssemblyLine.RFIDTag))
                {
                        return AddQualityTest(outDoorAssemblyLine, TestNames.FINAL);
                   
                }
                else
                {
                    return "Invalid RFID";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddHeatingTest(OutDoorAssemblyLine outDoorAssemblyLine)
        {
            try
            {
                if (isValidRFID(outDoorAssemblyLine.RFIDTag))
                {

                    DBContext dbContext = new DBContext();
                    OutDoorAssemblyLine odal = dbContext.OutDoorAssemblyLines.Include(y => y.QualityTests).Where(x => x.RFIDTag.Equals(outDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                    if (odal != null)
                    {
                        odal.PressureAtHeatingTest = outDoorAssemblyLine.PressureAtHeatingTest;
                        odal.TempratureAtHeatingTest = outDoorAssemblyLine.TempratureAtHeatingTest;
                        dbContext.SaveChanges();
                      
                        return AddQualityTest(outDoorAssemblyLine, TestNames.HEATING);
                       
                    }
                }
                return "Invalid RFID";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddPerformanceTest(OutDoorAssemblyLine outDoorAssemblyLine)
        {
            try
            {
                if (isValidRFID(outDoorAssemblyLine.RFIDTag))
                {

                    DBContext dbContext = new DBContext();
                    OutDoorAssemblyLine odal = dbContext.OutDoorAssemblyLines.Include(y => y.QualityTests).Where(x => x.RFIDTag.Equals(outDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                    if (odal != null)
                    {
                        odal.Voltage = outDoorAssemblyLine.Voltage;
                        odal.Pressure = outDoorAssemblyLine.Pressure;
                        odal.Current = outDoorAssemblyLine.Current;
                        odal.Power = outDoorAssemblyLine.Power;
                        odal.Frequancy = outDoorAssemblyLine.Frequancy;
                        odal.AmbientTemperature = outDoorAssemblyLine.AmbientTemperature;
                        odal.GrillTemperature = outDoorAssemblyLine.GrillTemperature;
                        odal.DeltaTemperature = outDoorAssemblyLine.AmbientTemperature - outDoorAssemblyLine.GrillTemperature;
                        dbContext.SaveChanges();
                       
                        return AddQualityTest(outDoorAssemblyLine, TestNames.PERFORMANCE);
                       
                    }
                }
                return "Invalid RFID";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddRepairingStation1(OutDoorAssemblyLine outDoorAssemblyLine)
        {
            try
            {
                if (isValidRFID(outDoorAssemblyLine.RFIDTag))
                {
                    string testName = outDoorAssemblyLine.QualityTests.FirstOrDefault().TestName;
                    if (isTestExist(outDoorAssemblyLine, testName))
                    {
                        return AddRepairingTest(outDoorAssemblyLine, testName);
                    }
                    else
                    {
                        return "No test exist with this name";
                    }
                }
                else
                {
                    return "Invalid RFID";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddRepairingStation2(OutDoorAssemblyLine outDoorAssemblyLine)
        {
            try
            {
                string testName = outDoorAssemblyLine.QualityTests.FirstOrDefault().TestName;
                if (isValidRFID(outDoorAssemblyLine.RFIDTag))
                {
                    if (isTestExist(outDoorAssemblyLine, testName))
                    {
                        return AddRepairingTest(outDoorAssemblyLine, testName);
                    }
                    else
                    {
                        return "No test exist with this name";
                    }
                }
                else
                {
                    return "Invalid RFID";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddRepairingTest(OutDoorAssemblyLine outDoorAssemblyLine, string testName = "")
        {
            try
            {
                // setting test name comes from
                testName = outDoorAssemblyLine.QualityTests.FirstOrDefault().TestName;
                //we are passing RFID data on each step
                DBContext dbContext = new DBContext();
                OutDoorAssemblyLine odal = dbContext.OutDoorAssemblyLines.Include(y => y.QualityTests).Where(x => x.RFIDTag.Equals(outDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                if (odal != null)
                {
                    QualityTest existingTest = odal.QualityTests.Where(x => x.TestName.Equals(testName)).LastOrDefault();
                    if (existingTest != null)
                    {
                        QualityTest qt = outDoorAssemblyLine.QualityTests.FirstOrDefault();
                        if (qt != null)
                        {
                            existingTest.DiagnosisFault = qt.DiagnosisFault;
                            existingTest.CorrectiveAction = qt.CorrectiveAction;
                            existingTest.RepairingOutTime = DateTime.Now;
                            dbContext.SaveChanges();
                            return "true";
                        }
                        else
                        {
                            return "Repairing iformation is null";
                        }
                    }
                    else
                    {
                        return "There is no test exist with this name";
                    }
                }
                else
                {
                    return "Invalide RFID Tag";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddQualityTest(OutDoorAssemblyLine outDoorAssemblyLine, string testName="")
        {
            try
            {
                //we are passing RFID data on each step
                DBContext dbContext = new DBContext();
                OutDoorAssemblyLine odal = dbContext.OutDoorAssemblyLines.Include(y => y.QualityTests).Where(x => x.RFIDTag.Equals(outDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                if (odal != null)
                {
                    QualityTest qt = outDoorAssemblyLine.QualityTests.FirstOrDefault();
                    if (qt != null)
                    {
                        qt.TestName = testName;
                        qt.TestOutTime = DateTime.Now;
                        qt.OutDoor = odal;
                        qt.Assembly = AssemblyNames.OUTDOOR;
                        odal.QualityTests.Add(qt);
                    }
                    dbContext.SaveChanges();
                    return "true";
                }
                else
                {
                    return "Invalide RFID Tag";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string UpdateQualityTest(OutDoorAssemblyLine outDoorAssemblyLine, string testName = "")
        {
            try
            {
                //we are passing RFID data on each step
                DBContext dbContext = new DBContext();
                OutDoorAssemblyLine odal = dbContext.OutDoorAssemblyLines.Include(y => y.QualityTests).Where(x => x.RFIDTag.Equals(outDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                if (odal != null)
                {
                    QualityTest existingTest=odal.QualityTests.Where(x => x.TestName.Equals(testName)).FirstOrDefault();
                    if (existingTest != null)
                    {
                        QualityTest qt = outDoorAssemblyLine.QualityTests.FirstOrDefault();
                        if (qt != null)
                        {
                            existingTest.Status = qt.Status;
                            existingTest.TestInTime = DateTime.Now;
                            dbContext.SaveChanges();
                            return "true";
                        }
                        else
                        {
                            return "quality test missing";
                        }
                    }
                    else
                    {
                        return "There is no test exist with this name.";
                    }
                }
                else
                {
                    return "Invalide RFID Tag";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static bool isTestExist(OutDoorAssemblyLine outDoorAssemblyLine, string testName="")
        {
            try
            {
                //we are passing RFID data on each step
                DBContext dbContext = new DBContext();
                OutDoorAssemblyLine odal = dbContext.OutDoorAssemblyLines.Include(y => y.QualityTests).Where(x => x.RFIDTag.Equals(outDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                if (odal != null)
                {
                    if (odal.QualityTests.Where(x => x.TestName.Equals(testName)).Count() > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool isValidRFID(string rfid)
        {
            try
            {
                //we are passing RFID data on each step
                DBContext dbContext = new DBContext();
                if (dbContext.OutDoorAssemblyLines.Where(x => x.RFIDTag.Equals(rfid)).Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
