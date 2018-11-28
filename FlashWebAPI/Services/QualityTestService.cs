using FlashWebAPI.DB;
using FlashWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashWebAPI.Services
{
    public class QualityTestService
    {
        public static List<QualityTest> GetAll()
        {
            try
            {
                DBContext dBContext = new DBContext();
                return dBContext.QualityTests.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool CheckStatusofTest(string rfid,string testName)
        {
            try
            {
                DBContext dBContext = new DBContext();
                InDoorAssemblyLine inDoorAssemblyLine= dBContext.InDoorAssemblyLines.Include(y=>y.QualityTests).Where(x=>x.RFIDTag.Equals(rfid)).ToList().FirstOrDefault();
                if (inDoorAssemblyLine != null)
                {
                    if (inDoorAssemblyLine.QualityTests.Where(x => x.TestName.Equals(testName) && x.Status == true).ToList().FirstOrDefault() != null)
                    {
                        return true;
                    }
                }
                return false;
               

            }
            catch (Exception)
            {
                return false;
            }
        }
        public static List<QualityTest> GetInDoorAssemblyTests()
        {
            try
            {
                DBContext dBContext = new DBContext();
                return dBContext.QualityTests.Include(y => y.InDoor).Where(x => x.InDoor != null).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<QualityTest> GetOutDoorAssemblyTests()
        {
            try
            {
                DBContext dBContext = new DBContext();
                return dBContext.QualityTests.Include(y=> y.OutDoor).Where(x => x.OutDoor != null).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<QualityTest> GetTestsAgainstOneUnitOfIndoorAseembly(string barcode)
        {
            try
            {
                DBContext dBContext = new DBContext();
                return dBContext.InDoorAssemblyLines.Include(y=>y.QualityTests)
                    .Where(x=>x.Barcode.Equals(barcode))
                    .Select(z=>z.QualityTests).ToList()
                    .FirstOrDefault().ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<QualityTest> GetTestsAgainstOneUnitOfOutdoorAseembly(string barcode)
        {
            try
            {
                DBContext dBContext = new DBContext();
                return dBContext.OutDoorAssemblyLines.Include(y => y.QualityTests)
                    .Where(x => x.Barcode.Equals(barcode))
                    .Select(z => z.QualityTests).ToList()
                    .FirstOrDefault().ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static QualityTest GetFailedTestAgainstOneUnitOfOutdoorAseembly(string barcode)
        {
            try
            {
                DBContext dBContext = new DBContext();
                return dBContext.OutDoorAssemblyLines.Include(y => y.QualityTests)
                    .Where(x => x.Barcode.Equals(barcode))
                    .Select(z => z.QualityTests).ToList()
                    .FirstOrDefault().ToList()
                    .Where(t=>t.Status==false).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static QualityTest GetFailedTestAgainstOneUnitOfIndoorAseembly(string barcode)
        {
            try
            {
                DBContext dBContext = new DBContext();
                return dBContext.InDoorAssemblyLines.Include(y => y.QualityTests)
                    .Where(x => x.Barcode.Equals(barcode))
                    .Select(z => z.QualityTests).ToList()
                    .FirstOrDefault().ToList()
                    .Where(t => t.Status == false).First();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static QualityTest GetFailedTestUnit(string testName, string assembly)
        {
            try
            {
                QualityTest qualityTest = null;
                DBContext dBContext = new DBContext();
                List<QualityTest> qualityTests = dBContext.QualityTests
                    .Where(x => x.TestName.Equals(testName) && x.Assembly.Equals(assembly) && x.CurrentTestUnit == true)
                    .ToList();
                if (qualityTests!=null && qualityTests.Count() > 0)
                {
                    qualityTest = qualityTests.FirstOrDefault();
                    foreach (QualityTest qt in qualityTests)
                    {
                        if (qt.TestInTime > qualityTest.TestInTime)
                        {
                            qualityTest = qt;
                        }
                    }

                }
                return qualityTest;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static QualityTest GetFailedRepairingUnit(string testName, string assembly)
        {
            try
            {
                QualityTest qualityTest = null;
                DBContext dBContext = new DBContext();
                List<QualityTest> qualityTests = dBContext.QualityTests
                    .Where(x => x.TestName.Equals(testName) && x.Assembly.Equals(assembly) && x.CurrentRepairingUnit == true)
                    .ToList();
                if (qualityTests != null && qualityTests.Count() > 0)
                {
                    qualityTest = qualityTests.FirstOrDefault();
                    foreach (QualityTest qt in qualityTests)
                    {
                        if (qt.RepairingInTime > qualityTest.RepairingInTime)
                        {
                            qualityTest = qt;
                        }
                    }
                }
                return qualityTest;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static QualityTest GetFailedRepairingUnit(string repairingStaionName)
        {
            try
            {
                QualityTest qualityTest = null;
                DBContext dBContext = new DBContext();
                if (repairingStaionName.Equals(nameof(Constants.RepairingStationNames.InDoorRepairingStation)))
                {
                    List<QualityTest> qualityTests = dBContext.QualityTests
                    .Where(x => Constants.RepairingStationNames.InDoorRepairingStation.TestStations.Contains(x.TestName) && x.Assembly.Equals(Constants.RepairingStationNames.InDoorRepairingStation.AssemblyName) && x.CurrentRepairingUnit == true)
                    .ToList();
                    if (qualityTests != null && qualityTests.Count() > 0)
                    {
                        qualityTest = qualityTests.FirstOrDefault();
                        foreach (QualityTest qt in qualityTests)
                        {
                            if (qt.RepairingInTime > qualityTest.RepairingInTime)
                            {
                                qualityTest = qt;
                            }
                        }
                    }
                    return qualityTest;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool AddPreleminaryFaults(QualityTest test)
        {
            DBContext db = new DBContext();
            try
            {
                QualityTest qt = db.QualityTests.Where(x => x.TestName.Equals(test.TestName) && x.Barcode.Equals(test.Barcode)).ToList().FirstOrDefault();
                if (qt != null)
                {
                    qt.PreleminaryFault = test.PreleminaryFault;
                    qt.CurrentTestUnit = false;
                    qt.TestOutTime = DateTime.Now;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public static bool AddRepairingUnit(QualityTest test)
        {
            DBContext db = new DBContext();
            try
            {
                QualityTest qt = db.QualityTests.Where(x => x.TestName.Equals(test.TestName) && x.Barcode.Equals(test.Barcode)).ToList().FirstOrDefault();
                if (qt != null)
                {
                    qt.DiagnosisFault = test.DiagnosisFault;
                    qt.CorrectiveAction = test.CorrectiveAction;
                    qt.OperatorName = test.OperatorName;
                    qt.FaultType = test.FaultType;
                    qt.CurrentRepairingUnit = false;
                    qt.RepairingOutTime = DateTime.Now;
                    qt.Status = true;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
