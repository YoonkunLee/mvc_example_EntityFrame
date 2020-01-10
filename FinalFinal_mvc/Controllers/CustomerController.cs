using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalFinal_mvc.DataContext;
using FinalFinal_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalFinal_mvc.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {           
            using (var db = new CustomerDbContext())
            {
                //var females = new List<User>();

                var list = db.Users.ToList();

                //for(int i=0; i<list.Count; i++)
                //{
                //    if(list[i].Gender =="F")
                //    {
                //        females.Add(list[i]);
                //    }
                //}

                //var femailUserNames = new List<string>();
                //foreach (var user in list)
                //{
                //    if (user.Gender == "F")
                //    {
                //        femailUserNames.Add(user.UserName);
                //    }
                //}
                //var females1 = list.Where(m => m.Gender.Equals("F")).Select(m => m.UserName).ToList();

                //var females2 = from user in list
                //              where user.Gender == "F"
                //              select user.UserName;

                //list.ForEach(m => m.Email = "");
                //list.ForEach(m => m.Email = string.Empty);
                //list.ForEach(m =>
                //{
                //    m.Email = "";
                //    m.Gender = "";
                //});


                return View(list);
            }
        }       
        
        public IActionResult Enroll()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enroll(User model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new CustomerDbContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Success", "Customer", model);
            }
            return View(model);
        }

        public IActionResult Update(int? Id)
        {
            using (var db = new CustomerDbContext())
            {
                var user = db.Users.Find(Id);
                if (user == null)
                {
                    return RedirectToAction("Enroll");
                }
                return View(user);
            }
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            using (var db = new CustomerDbContext())
            {
                if (user == null)
                {
                    return RedirectToAction("Enroll");
                }
                if (ModelState.IsValid)
                {
                    db.Users.Update(user);
                    db.SaveChanges();

                    return ReDirectToIndex();
                }
                return View(user);
            }
        }

        public IActionResult Delete(int id)
        {
            using (CustomerDbContext db = new CustomerDbContext())
            {
                User userToBeDeleted = db.Users.Where(x => x.id.Equals(id)).FirstOrDefault();
                if(userToBeDeleted != null)
                {
                    db.Users.Remove(userToBeDeleted);
                    db.SaveChanges();
                }          
            }
            return ReDirectToIndex();

        }

        public IActionResult ReDirectToIndex()
        {
            return RedirectToAction("Index", "Customer");
        }

        public IActionResult Success(User user)
        {
            return View(user);
        }
    }
}