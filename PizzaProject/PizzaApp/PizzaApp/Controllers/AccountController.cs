using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PizzaApp.Models.Identity;

namespace PizzaApp.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user=new ApplicationUser
                {
                    UserName = model.Name,
                    Address=model.Address,
                    PhoneNumber=model.Phone,
                    Email = model.Email
                   
                };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                    //return RedirectToAction("Menu", "Menu");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("",error);
                    }
                }
            }

            return View(model);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindAsync(model.UserName, model.Password);
                if (user==null)
                {
                    ModelState.AddModelError("", "Invalid password");
                }
                else
                {
                    ClaimsIdentity claims =
                        await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claims);
                    if (String.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return Redirect(returnUrl);
                }
            }

            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //public ActionResult Delete()
        //{
        //    return View();
        //}

        //[HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteComfirmed()
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);
           
            if (user!=null)
            {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Logout", "Account");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Edit()
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);
            if (user!=null)
            {
                EditModel model = new EditModel() {
                    Name=user.UserName, 
                    Email = user.Email, 
                    Address=user.Address,
                    Phone=user.PhoneNumber 
                };
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<ActionResult> Edit(EditModel model)
        {
            //ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user!=null)
            {
                user.Email = model.Email;
                user.UserName = model.Name;
                user.Address = model.Address;
                user.PhoneNumber = model.Phone;
                IdentityResult result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Private", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to make changes. Try again");
                }
                
            }
            else
            {
                ModelState.AddModelError("", "User didn't find");
            }
            return View(model);
        }

        public async Task<ActionResult> Private()
        {
            ApplicationUser user = await UserManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }
    }
}