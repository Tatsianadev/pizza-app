using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PizzaApp.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PizzaApp.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }
        // GET: Roles
        public ActionResult Index()
        {
            //return View();
            return View(RoleManager.Roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await RoleManager.CreateAsync(new ApplicationRole()
                {
                    Name = model.Name,
                    Description=model.Description
                    
                }) ;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Something wrong. Try again");
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Edit(string id)
        {
            ApplicationRole role = await RoleManager.FindByIdAsync(id);
            if (role!=null)
            {
                return View(new EditRoleModel { Id = role.Id, Name = role.Name, Description = role.Description });
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditRoleModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole role = await RoleManager.FindByIdAsync(model.Id);
                if (role!=null)
                {
                    role.Description = model.Description;
                    role.Name = model.Name;
                    IdentityResult result = RoleManager.Update(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Something wrong. Try again");
                    }

                }
            }
            return View(model);
        }

        public async Task<ActionResult> Delete (string id)
        {
            ApplicationRole role = await RoleManager.FindByIdAsync(id);
            if (role!=null)
            {
               IdentityResult result= await RoleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }
    }
}