using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiMini_Project.Controllers
{
    
    public class UserController : ApiController
    {
        DataClasses1DataContext db=new DataClasses1DataContext();

        //[Route("AAapi/UserAccount/getAllUsers")]
        //[HttpGet]
        //public HttpResponseMessage getAllUsers()
        //{
        //    List<User> users = new List<User>();

        //    dynamic test = from u in db.Users select u;

        //    if (test != null)
        //    {
        //        foreach (User u in test)
        //        {
        //            users.Add(u);
        //        }
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, users);
        //}

        [HttpGet]
        public int updateUser(int userid,string name, string surname, string email, int number, string address)
        {
            var comp = getUser(userid);

            if (comp != null)
            {
                comp.Name = name;
                comp.Surname = surname;
                comp.Email = email;
                comp.Number = number;
                comp.Address = address;

                try
                {
                    db.SubmitChanges();
                    return 1;
                }
                catch (Exception ex)
                {
                    ex.GetBaseException();
                    return -2;
                }
            }
            else
            {
                return -3;
            }
   
        }

        [HttpGet]
        public int login(string password, string email)
        {
            var user = (from u in db.Users
                        where u.Email.Equals(email) & u.Password.Equals(password)
                        select u).FirstOrDefault();

            if (user == null)
                return -1;


            return user.Id;
        }

        [HttpGet]
        public User getUser(string email,int val)
        {
            var user = (from u in db.Users
                        where u.Email.Equals(email)
                        select u).FirstOrDefault();

            return user;
        }

        [HttpGet]
        public User getUser(int userId)
        {
            var user = (from u in db.Users
                        where u.Id.Equals(userId)
                        select u).FirstOrDefault();

            return user;
        }





        [HttpGet]
         public int registerNewUser(string name,string surname,string email,string password,string gender,int number,string address, string type = "Client")
        {
            var UserExist = (from x in db.Users
                             where x.Email.Equals(email)
                             select x).FirstOrDefault();

            if(UserExist == null)
            {
                User newPlayer = new User
                {
                    Name = name,
                    Surname = surname,
                    Email = email,
                    Gender = gender,
                    Password = password,
                    Address = address,
                    Number = number,
                    Type = type
                };
                db.Users.InsertOnSubmit(newPlayer);

                try
                {
                    db.SubmitChanges();
                    return 1;
                }
                catch(Exception EX)
                {
                    EX.GetBaseException();
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
