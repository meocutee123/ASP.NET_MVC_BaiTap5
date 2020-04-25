using BaiTap5.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap5.Controllers
{
    public class NtuController : Controller
    {
        // GET: Ntu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(RegistrationModel empM)
        {
            string path = Server.MapPath("~/Images/");
            string fileName = Path.GetFileName(empM.imgFile.FileName);
            string fullPath = Path.Combine(path, fileName);
            empM.imgFile.SaveAs(fullPath);

            string fSave = Server.MapPath("~/Images/emp.txt");
            string[] emInfo =
                {
                    empM.empID, empM.empName, empM.empDateOfBirth.ToShortDateString(), empM.empEmail, empM.empPassword, empM.empDivision, fileName
                };
            //Lưu các thông ti vào tập tin emp.txt
            System.IO.File.WriteAllLines(fSave, emInfo);
            //Ghi nhận các thông tin đăng ký để hiện thị trên View Confirm
            ViewBag.empID = emInfo[0];
            ViewBag.empName = emInfo[1];
            ViewBag.empDateOfBirth = emInfo[2].ToString();
            ViewBag.empEmail = emInfo[3];
            ViewBag.empPassword = emInfo[4];
            ViewBag.empDivision = emInfo[5];
            ViewBag.empAvatar = "/Images/" + emInfo[6];

            return View("Confirm");
        }
        public ActionResult Confirm()
        {
            return View();
        }

        public ActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(SendMailModel model)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new System.Net.Mail.MailAddress(model.From);
            mail.To.Add(model.To);
            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.IsBodyHtml = true;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;

            smtp.Credentials = new System.Net.NetworkCredential(model.From, model.Password);
            smtp.Send(mail);

            ViewBag.Message = "Mail has been sent!";
            return View();
        }

        public ActionResult Banner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Banner(BannerModel bm)
        {
            string path = Server.MapPath("~/Banners/");
            string bannerfileName = Path.GetFileName(bm.imgFile.FileName);
            string fullPath = Path.Combine(path, bannerfileName);
            bm.imgFile.SaveAs(fullPath);

            string f2Save = Server.MapPath("~/Banners/banner.txt");
            string[] bannerInfor ={bannerfileName};
            //Lưu các thông ti vào tập tin emp.txt
            System.IO.File.WriteAllLines(f2Save, bannerInfor);
            ViewBag.Message = "Thay đổi thành công.";
            return View();

        }
    }
}