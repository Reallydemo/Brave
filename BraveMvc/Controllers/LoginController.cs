using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using Models;
using BLL;

namespace BraveMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Users user, string returnUrl)
        {
            
            try
            {
                Users users = UsersManage.Login(user);
                if (users != null)
                {

                    HttpContext.Session["User_id"] = users.User_id;
                    HttpContext.Session["Image"] = users.UserImage;
                    HttpContext.Session["Account"] = users.UserAccount;
                    HttpContext.Session["UserName"] = users.UserName;



                    return Content("<script>;alert('登入成功!，返回商城首页!');window.location.href='/Malls/Index'</script>");
                    
                }
                else
                {
                    return Content("<script>;alert('该账号不存在或密码错误!');history.go(-1)</script>");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            
        }
    }
}