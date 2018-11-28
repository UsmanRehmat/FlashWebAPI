using FlashWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlashWebAPI.DB;

namespace FlashWebAPI.Services
{
    public class RegisrationService
    {
        public static string register(User user)
        {
            string message = Constants.Messages.SUCCESS;
            try
            {
                DBContext dbContext = new DBContext();
                if (dbContext.Users.Where(x => x.UserName.Equals(user.UserName)).FirstOrDefault()!=null)
                {
                    message = "User already exist";
                    return message;
                }
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return message;
            }
            catch (Exception ex)
            {
                return Constants.Messages.ERROR;
            }
        }
        public static User login(User user)
        {
            try
            {
                DBContext dbContext = new DBContext();
                List<User> users = dbContext.Users.Where(x => x.UserName.Equals(user.UserName) && x.Password == user.Password).ToList();
                if (users != null && users.Count ==1)
                {
                    User _user = users.First();
                    _user.Password=string.Empty;
                    return _user;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool  update(User user)
        {
            try
            {
                DBContext dbContext = new DBContext();
                List<User> users = dbContext.Users.Where(x => x.UserName.Equals(user.UserName)).ToList();
                if (users != null && users.Count == 1)
                {
                    User _user = users.First();
                    dbContext.Users.Remove(_user);
                    dbContext.SaveChanges();
                    dbContext.Users.Add(user);
                    dbContext.SaveChanges();
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

        public static bool delete(User user)
        {
            try
            {
                DBContext dbContext = new DBContext();
                List<User> users = dbContext.Users.Where(x => x.UserName.Equals(user.UserName)).ToList();
                if (users != null && users.Count == 1)
                {
                    User _user = users.First();
                    dbContext.Users.Remove(_user);
                    dbContext.SaveChanges();
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


        public static List<User> GetAll()
        {
            try
            {
                DBContext dBContext = new DBContext();
                return dBContext.Users.ToList();
            }
            catch (Exception)
            {
                return null;
            }
          
        }
    }
}
