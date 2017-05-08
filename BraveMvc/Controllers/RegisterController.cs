using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;
using Models;
using BLL;
using DALFactory;
using IDAL;

namespace BraveMvc.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users user, HttpPostedFileBase file)
        {
            string ValidateCode = Request["txtverifcode"];

            if (ValidateCode != Session["ValidateCode"].ToString())
            {
                return Content("<script>;alert('验证码错误！');history.go(-1)</script>");
            }
            var chk_member = UsersManage.Findname(user);
            if (chk_member != null)
            {
                return Content("<script>;alert('该账号已经有人注册了！');history.go(-1)</script>");

            }
            try
            {

                if (file != null)
                {
                    string filePath = file.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string serverpath = Server.MapPath(@"\Images\users\") + filename;
                    string relativepath = @"/Images/users/" + filename;
                    file.SaveAs(serverpath);
                    user.UserImage = relativepath;
                }

                else
                {
                    return Content("<script>;alert('请先上传图片！');history.go(-1)</script>");

                }
                UsersManage.Register(user);
                return Content("<script>;alert('注册成功！');history.go(-1)</script>");
            }


            catch (DbEntityValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [AllowAnonymous]

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users user, string returnUrl)
        {
            string ValidateCode = Request["txtverifcode"];
            if (ValidateCode != Session["ValidateCode"].ToString())
            {
                return Content("<script>;alert('验证码错误！');history.go(-1)</script>");
            }
            try
            {
                Users users =UsersManage.Login(user);
                if (users != null)
                {

                    HttpContext.Session["User_id"] = users.User_id;
                    HttpContext.Session["Image"] = users.UserImage;
                    HttpContext.Session["Account"] = users.UserAccount;
                    HttpContext.Session["UserName"] = users.UserName;



                    return Content("<script>;alert('登录成功!返回首页!');window.location.href='/Home/Index'</script>");
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
        public ActionResult LogOff()
        {
            Session["UserName"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}