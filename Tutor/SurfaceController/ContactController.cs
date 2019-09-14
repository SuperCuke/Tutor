using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tutor.SurfaceController
{
    public class ContactController : Umbraco.Web.Mvc.SurfaceController
    {
        [HttpPost]
        public ActionResult Index(ContactModel contactModel)
        {
            var media = Services.MediaService.CreateMedia("Feedback" + Guid.NewGuid().ToString(), 1189, "tutorFeedback");
            media.SetValue("contactName", contactModel.Name);
            media.SetValue("email", contactModel.Email);
            media.SetValue("message", contactModel.Message);
            media.SetValue("subject", contactModel.Subject);
            media.SetValue("feedbackDate", DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());

            Services.MediaService.Save(media);
            return Content("OK");
        }
    }

    public class ContactModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}