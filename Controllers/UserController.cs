using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Module6HW5.Data;
using Module6HW5.Interfaces;
using Module6HW5.Models;

namespace Module6HW5.Controllers
{
    public class UserController : Controller, IUser
    {
        public Provider provider = new Provider();
        private readonly Random _random = new Random();

        [HttpGet]
        [Authorize(Roles = "user")]
        public ViewResult List()
        {
            return View(provider.GetList());
        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public ViewResult Create()
        {
            var user = new CreateUserParameters() { Job = "teacher", Name = "MAX", Id = Provider.Mylist.Count + 1, Salary = 1032 };
            return View(provider.Create(user));
        }

        [HttpPost("{id}")]
        [Authorize(Roles = "user")]
        public ActionResult Update([FromBody] int id)
        {
            if (id > 0 && id < Provider.Mylist.Count)
            {
                Provider.Mylist[id].Name = " changed by user";
            }

            return View(provider.GetList());
        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public ActionResult Update()
        {
            if (Provider.Mylist.Count > 0)
            {
                Provider.Mylist[_random.Next(0, Provider.Mylist.Count)].Name = " changed by user";
                return View(provider.GetList());
            }

            return RedirectToAction("Error", "Home");

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "user")]
        public ActionResult Delete([FromBody] int id)
        {
            if (id > 0 && id < Provider.Mylist.Count)
            {
                Provider.Mylist.RemoveAt(id);
            }

            return View(provider.GetList());
        }

        [HttpGet]
        [Authorize(Roles = "user")]
        public ActionResult Delete()
        {
            if (Provider.Mylist.Count > 0)
            {
                Provider.Mylist.RemoveAt(_random.Next(0, Provider.Mylist.Count));
                return View(provider.GetList());
            }
            return RedirectToAction("Error", "Home");
        }

    }
}
