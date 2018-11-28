using FlashWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashWebAPI.Services
{
    public class ReferenceDataService
    {
        public static List<StationFaults> GetAll()
        {
            try
            {
                DB.DBContext dBContext = new DB.DBContext();
                return dBContext.StationFaults.ToList();
                 
            }
            catch (Exception)
            {

                return null;
            }

        }
        public static bool AddStationFaults(StationFaults stationFaults)
        {
            try
            {
                DB.DBContext dBContext = new DB.DBContext();
                dBContext.StationFaults.Add(stationFaults);
                dBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            
        }
        public static bool AddCorrectiveAction(string stationName,string fault,List<CorrectiveAction> correctiveActions)
        {
            try
            {
                DB.DBContext dBContext = new DB.DBContext();
                StationFaults station= dBContext.StationFaults.Where(x=>x.StationName.Equals(stationName) && x.Faults.Equals(fault))
                    .ToList().FirstOrDefault();
                if (station != null)
                {
                    foreach (CorrectiveAction ca in correctiveActions)
                    {
                        if (station.CorrectiveActions.Where(x=>x.Action.Equals(ca.Action)).ToList()==null)
                        {
                            station.CorrectiveActions.Add(ca);
                        }
                    }
                    dBContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }

        }
        public static List<StationFaults> GetStationFaults(string stationName,string assembly)
        {
            try
            {
                DB.DBContext dBContext = new DB.DBContext();
                return dBContext.StationFaults.Where(x=> x.StationName.Equals(stationName) && x.Assembly.Equals(assembly)).ToList();
            }
            catch (Exception)
            {

                return null;
            }

        }
        public static List<CorrectiveAction> GetCorrectiveAction(string stationName,string fault, string assembly)
        {
            try
            {
                DB.DBContext dBContext = new DB.DBContext();
                StationFaults faults= dBContext.StationFaults.Include(y=>y.CorrectiveActions).Where(x => x.Faults.Equals(fault) && x.Assembly.Equals(assembly) && x.StationName.Equals(stationName)).FirstOrDefault();
                if (faults != null)
                {
                    return faults.CorrectiveActions.ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }

        }


    }
}
