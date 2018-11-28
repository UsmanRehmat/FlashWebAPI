using FlashWebAPI.Constants;
using FlashWebAPI.DB;
using FlashWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashWebAPI.Services
{
    public class IndoorAssemblyLineService
    {
        public static List<InDoorAssemblyLine> GetAll()
        {
            try
            {
                DBContext dbContext = new DBContext();
                return dbContext.InDoorAssemblyLines.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string AddInDoorAssemblyUnit(InDoorAssemblyLine inDoorAssemblyLine)
        {
            try
            {
                DBContext dbContext = new DBContext();
                InDoorAssemblyLine odal = dbContext.InDoorAssemblyLines.Where(x => x.RFIDTag.Equals(inDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                if (!inDoorAssemblyLine.RFIDTag.Equals(string.Empty) && odal==null)
                {
                    inDoorAssemblyLine.StartTime = DateTime.Now;
                    dbContext.InDoorAssemblyLines.Add(inDoorAssemblyLine);
                    dbContext.SaveChanges();
                    return "true";
                }
                else
                {
                    return "RFID is empty or already exist";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddEvaporatorAndMotorQRCode(InDoorAssemblyLine inDoorAssemblyLine)
        {
            try
            {
                DBContext dbContext = new DBContext();
                if (isValidRFID(inDoorAssemblyLine.RFIDTag))
                {
                    InDoorAssemblyLine odal = dbContext.InDoorAssemblyLines.Where(x => x.RFIDTag.Equals(inDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                    if (odal != null)
                    {
                        odal.BlowerMotorQRCode = inDoorAssemblyLine.BlowerMotorQRCode;
                        odal.EvaporatorBarcode = inDoorAssemblyLine.EvaporatorBarcode;
                        dbContext.SaveChanges();
                        return "true";
                    }
                    

                }
                return "Invalid RFID tag."; 
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddElectricalBoxAndBarCode(InDoorAssemblyLine inDoorAssemblyLine)
        {
            try
            {
                DBContext dbContext = new DBContext();
                if (isValidRFID(inDoorAssemblyLine.RFIDTag))
                {
                    InDoorAssemblyLine odal = dbContext.InDoorAssemblyLines.Where(x => x.RFIDTag.Equals(inDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                    if (odal != null)
                    {
                        odal.ElectricalBoxQRCode = inDoorAssemblyLine.ElectricalBoxQRCode;
                        odal.Barcode = inDoorAssemblyLine.Barcode;
                        dbContext.SaveChanges();
                        return "true";
                    }


                }
                return "Invalid RFID tag.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddPerformanceTest(InDoorAssemblyLine inDoorAssemblyLine)
        {
            try
            {
                if (isValidRFID(inDoorAssemblyLine.RFIDTag))
                {
                    return AddQualityTest(inDoorAssemblyLine, TestNames.PERFORMANCE);  
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
        public static string AddPerformanceTestForTesting(InDoorAssemblyLine inDoorAssemblyLine)
        {
            try
            {
                if (isValidRFID(inDoorAssemblyLine.RFIDTag))
                {
                    DBContext dbContext = new DBContext();
                    InDoorAssemblyLine odal = dbContext.InDoorAssemblyLines.Include(y => y.QualityTests).Where(x => x.RFIDTag.Equals(inDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                    if (odal != null)
                    {
                        odal.EvaporatorBarcode = inDoorAssemblyLine.EvaporatorBarcode;
                        odal.ElectricalBoxQRCode = inDoorAssemblyLine.ElectricalBoxQRCode;
                        odal.Barcode = inDoorAssemblyLine.Barcode;
                        if (inDoorAssemblyLine.Barcode.Length > 9)
                        {
                            odal.Model = inDoorAssemblyLine.Barcode.Substring(0, 9);
                            odal.UnitNumber = inDoorAssemblyLine.Barcode.Substring(9);
                        }
                        dbContext.SaveChanges();

                        return AddQualityTest(inDoorAssemblyLine, TestNames.PERFORMANCE);

                    }
                    else
                    {
                        return "Invalid RFID";
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
        public static string AddSafetyTest(InDoorAssemblyLine inDoorAssemblyLine)
        {
            try
            {
                if (isValidRFID(inDoorAssemblyLine.RFIDTag))
                {
                    return AddQualityTest(inDoorAssemblyLine, TestNames.SAFETY);
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
        public static string AddSoundTest(InDoorAssemblyLine inDoorAssemblyLine)
        {
            try
            {
                if (isValidRFID(inDoorAssemblyLine.RFIDTag))
                {

                    DBContext dbContext = new DBContext();
                    InDoorAssemblyLine odal = dbContext.InDoorAssemblyLines.Include(y => y.QualityTests).Where(x => x.RFIDTag.Equals(inDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                    if (odal != null)
                    {
                        odal.RPM = inDoorAssemblyLine.RPM;
                        odal.Power = inDoorAssemblyLine.Power;
                        odal.Current = inDoorAssemblyLine.Current;
                        odal.Voltage = inDoorAssemblyLine.Voltage;
                        odal.Inductance = inDoorAssemblyLine.Inductance;
                        odal.Capacitance = inDoorAssemblyLine.Capacitance;
                        dbContext.SaveChanges();
                        
                        return AddQualityTest(inDoorAssemblyLine, TestNames.SOUND);
                        
                    }
                }
                return "Invalid RFID";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddFinalTest(InDoorAssemblyLine inDoorAssemblyLine)
        {
            try
            {
                if (isValidRFID(inDoorAssemblyLine.RFIDTag))
                {
                    return AddQualityTest(inDoorAssemblyLine, TestNames.FINAL);
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
        public static string AddRepairingStation1(InDoorAssemblyLine inDoorAssemblyLine)
        {
            try
            {
                if (isValidRFID(inDoorAssemblyLine.RFIDTag))
                {
                    string testName = inDoorAssemblyLine.QualityTests.FirstOrDefault().TestName;
                    if (isTestExist(inDoorAssemblyLine, testName))
                    {
                        return AddRepairingTest(inDoorAssemblyLine, testName);
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
        public static string AddRepairingStation2(InDoorAssemblyLine inDoorAssemblyLine)
        {
            try
            {
                string testName = inDoorAssemblyLine.QualityTests.FirstOrDefault().TestName;
                if (isValidRFID(inDoorAssemblyLine.RFIDTag))
                {
                    if (isTestExist(inDoorAssemblyLine, testName))
                    {
                        return AddRepairingTest(inDoorAssemblyLine, testName);
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
        public static string AddLineExit(InDoorAssemblyLine inDoorAssemblyLine)
        {
            try
            {
                DBContext dbContext = new DBContext();
                if (isValidRFID(inDoorAssemblyLine.RFIDTag))
                {
                    InDoorAssemblyLine odal = dbContext.InDoorAssemblyLines.Where(x => x.RFIDTag.Equals(inDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                    if (odal != null)
                    {
                        odal.ExitTime = inDoorAssemblyLine.ExitTime;
                        odal.RFIDTag = "";
                        dbContext.SaveChanges();
                        return "true";
                    }


                }
                return "Invalid RFID tag.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string AddRepairingTest(InDoorAssemblyLine inDoorAssemblyLine, string testName = "")
        {
            try
            {
                // setting test name comes from
                testName = inDoorAssemblyLine.QualityTests.FirstOrDefault().TestName;
                //we are passing RFID data on each step
                DBContext dbContext = new DBContext();
                InDoorAssemblyLine odal = dbContext.InDoorAssemblyLines.Include(y => y.QualityTests).Where(x => x.RFIDTag.Equals(inDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                if (odal != null)
                {
                    QualityTest existingTest = odal.QualityTests.Where(x => x.TestName.Equals(testName)).LastOrDefault();
                    if (existingTest != null)
                    {
                        QualityTest qt = inDoorAssemblyLine.QualityTests.FirstOrDefault();
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
        public static string AddTimeInRepairingTest(InDoorAssemblyLine inDoorAssemblyLine, string testName = "")
        {
            try
            {
                // setting test name comes from
                testName = inDoorAssemblyLine.QualityTests.FirstOrDefault().TestName;
                //we are passing RFID data on each step
                DBContext dbContext = new DBContext();
                InDoorAssemblyLine odal = dbContext.InDoorAssemblyLines.Include(y => y.QualityTests).Where(x => x.RFIDTag.Equals(inDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                if (odal != null)
                {
                    QualityTest existingTest = odal.QualityTests.Where(x => x.TestName.Equals(testName)).LastOrDefault();
                    if (existingTest != null)
                    {
                        QualityTest qt = inDoorAssemblyLine.QualityTests.FirstOrDefault();
                        if (qt != null)
                        {
                            existingTest.RepairingInTime = DateTime.Now;
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
        public static string AddQualityTest(InDoorAssemblyLine inDoorAssemblyLine, string testName = "")
        {
            try
            {
                //we are passing RFID data on each step
                DBContext dbContext = new DBContext();
                InDoorAssemblyLine odal = dbContext.InDoorAssemblyLines.Include(y => y.QualityTests).Where(x => x.RFIDTag.Equals(inDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                if (odal != null)
                {
                    QualityTest qt = inDoorAssemblyLine.QualityTests.FirstOrDefault();
                    if (qt != null)
                    {
                        qt.TestName = testName;
                        qt.Barcode = odal.Barcode;
                        qt.TestOutTime = DateTime.Now;
                        qt.InDoor = odal;
                        qt.Assembly = AssemblyNames.INDOOR;
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
        public static string UpdateQualityTest(InDoorAssemblyLine inDoorAssemblyLine, string testName = "")
        {
            try
            {
                //we are passing RFID data on each step
                DBContext dbContext = new DBContext();
                InDoorAssemblyLine odal = dbContext.InDoorAssemblyLines.Include(y => y.QualityTests).Where(x => x.RFIDTag.Equals(inDoorAssemblyLine.RFIDTag)).FirstOrDefault();
                if (odal != null)
                {
                    QualityTest existingTest = odal.QualityTests.Where(x => x.TestName.Equals(testName)).FirstOrDefault();
                    if (existingTest != null)
                    {
                        QualityTest qt = inDoorAssemblyLine.QualityTests.FirstOrDefault();
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
        public static bool isTestExist(InDoorAssemblyLine inDoorAssemblyLine, string testName = "")
        {
            try
            {
                //we are passing RFID data on each step
                DBContext dbContext = new DBContext();
                InDoorAssemblyLine odal = dbContext.InDoorAssemblyLines.Include(y => y.QualityTests).Where(x => x.RFIDTag.Equals(inDoorAssemblyLine.RFIDTag)).FirstOrDefault();
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
                if (dbContext.InDoorAssemblyLines.Where(x => x.RFIDTag.Equals(rfid)).Count() > 0)
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
