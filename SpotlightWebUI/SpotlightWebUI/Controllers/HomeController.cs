using SpotlightWebUI.Models;
using System.Collections.Generic;
using System.Web.Hosting;
using System.Web.Mvc;

namespace SpotlightWebUI.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact() {
            return View(new ContactForm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactForm cf) {
            if (ModelState.IsValid) {
                string emailTo = System.Configuration.ConfigurationManager.AppSettings["ContactEmailAddress"];
                string emailTemplatePath = HostingEnvironment.MapPath("~/Content/ContactEmailTemplate.html");
                string emailTemplateText = System.IO.File.ReadAllText(emailTemplatePath);
                Dictionary<string, string> fieldValues = new Dictionary<string, string>();
                fieldValues.Add("FirstName", cf.FirstName);
                fieldValues.Add("LastName", cf.LastName);
                fieldValues.Add("Email", cf.EmailAddress);
                fieldValues.Add("Phone", cf.PhoneNumber);
                fieldValues.Add("Address", cf.Address);
                fieldValues.Add("City", cf.City);
                fieldValues.Add("State", cf.State.ToString());
                fieldValues.Add("ZipCode", cf.ZipCode);
                fieldValues.Add("InterestedIn", cf.GetInterestedInString());
                fieldValues.Add("Message", cf.Message);
                string body = emailTemplateText;
                foreach (KeyValuePair<string, string> kvp in fieldValues) {
                    string searchString = string.Format("%%{0}%%", kvp.Key);
                    body = body.Replace(searchString, kvp.Value);
                }
                CommonUtils.Mailer.SendEmail(emailTo, new List<string>(), "New Contact from web-site", body);
                cf.SuccessYN = true;
            }
            return View(cf);
        }
    }
}