using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Taigate.Cms.Models;
using Taigate.Cms.Services;
using Taigate.Core;
using Taigate.Data.Data;
using Taigate.Data.Data.Entities.Components.DoganlarMobilya;

namespace Taigate.Cms.Controllers
{
    [Route("mail")]
    public class EmailController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public EmailController(AppDbContext dbContext, IEmailSender emailSender, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _emailSender = emailSender;
            _webHostEnvironment = webHostEnvironment;
        }
        
        
        [HttpPost]
        [Route("gazikoylu")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> SendEmailGaziKoylu(EmailModel model)
        {
            if (!ModelState.IsValid) return Json(new {success = false, responseText = "Formu Yeniden Doldurunuz."});
            try
            {
                var emailTemplate = new EmailTemplate
                {
                    To = "fuatatik@outlook.com",
                    Body = " İsim: " + model.Name + " \n Email: " +
                           model.Email + " \n Konu: " + model.Subject + " \n Mesaj:  \n " + model.Message,
                    Subject = "Yeni bir iletisim formu dolduruldu!",
                    CC = ""
                };
                await _emailSender.SendEmail(emailTemplate);
                return Json(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json(new {success = false, responseText = "Formu Yeniden Doldurunuz."});
            }
        }
        

        [HttpPost]
        [Route("gazikoyluhomepage")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> SendEmailGaziKoyluHomePage(EmailModel model)
        {
            if (!ModelState.IsValid) return Json(new {success = false, responseText = "Formu Yeniden Doldurunuz."});
            try
            {
                var emailTemplate = new EmailTemplate
                {
                    To = "fuatatik@outlook.com",
                    Body = " İsim: " + model.Name + " \n Email: " +
                           model.Email + " \n Konu: " + model.Subject + " \n Mesaj:  \n " + model.Message,
                    Subject = "Yeni bir Anasayfa "+model.Subject+" formu dolduruldu!",
                    CC = ""
                };
                await _emailSender.SendEmail(emailTemplate);
                return Json(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json(new {success = false, responseText = "Formu Yeniden Doldurunuz."});
            }
        }
        
        
        [HttpPost]
        [Route("doganlarmobilya")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> SendEmailDoganlarMobilya(EmailModel model, bool kvkk)
        {
            if (!kvkk) return Json(new {success = false, responseText = "Kvkk Alanını işaretleyiniz."});
            if (!ModelState.IsValid) return Json(new {success = false, responseText = "Formu Yeniden Doldurunuz."});

            try
            {
                string SubjectType = "";
                switch (model.SubjectType)
                {
                    case 1:
                        SubjectType = "Bilgi";
                        break;
                    case 2:
                        SubjectType = "Talep";
                        break;
                    case 3:
                        SubjectType = "Şikayet";
                        break;
                }

                var emailTemplate = new EmailTemplate
                {
                    To = "musteri.hizmetleri@doganlarmobilyagrubu.com",
                    Body = " İsim: " + model.Name + " \n Şirket Ünvanı: " + model.CompanyDegree + " \n Email: " +
                           model.Email + " \n Konu: " + model.Subject + " \n Konu Türü: " + SubjectType +
                           " \n Telefon: " + model.Phone + " \n Mesaj:  \n " + model.Message,
                    Subject = "DOGANLAR MOBİLYA - Yeni bir " + SubjectType + " formu dolduruldu!",
                    CC = ""
                };
                await _emailSender.SendEmail(emailTemplate);
                return Json(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json(new {success = false, responseText = "Formu Yeniden Doldurunuz."});
            }
        }

        public static string ConvertTextToSlug(string s)
        {
            StringBuilder sb = new StringBuilder();
            bool wasHyphen = true;
            foreach (char c in s)
            {
                if (char.IsLetterOrDigit(c))
                {
                    sb.Append(char.ToLower(c));
                    wasHyphen = false;
                }
                else if (char.IsWhiteSpace(c) && !wasHyphen)
                {
                    sb.Append('-');
                    wasHyphen = true;
                }
            }

            // Avoid trailing hyphens
            if (wasHyphen && sb.Length > 0)
                sb.Length--;
            return sb.ToString();
        }


        [HttpPost]
        [Route("doganlarMobilyaCV")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> DoganlarMobilyaContactPageFormCV(EmailModel model, string captcha)
        {
            if (!ModelState.IsValid) return Json(new {success = false, responseText = "Formu Yeniden Doldurunuz."});

            var verified = ReCaptchaClass.Validate(captcha) == "true";

            if (!verified)
            {
                return Json(new {success = false, responseText = "Captcha yanlış doğrulanmış"});
            }

            try
            {
                string path_for_Uploaded_Files = _webHostEnvironment.WebRootPath + "/Files/CV";

                var uploaded_files = Request.Form.Files;


                string sFiles_uploaded = "";
                string attachmentName = "";
                string new_Filename_on_Server = "";

                foreach (var uploaded_file in uploaded_files)
                {
                    //ContentType check
                    if (uploaded_file.ContentType == "application/pdf" || uploaded_file.ContentType ==
                        "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
                    {
                        if (uploaded_file.Length < 1000000)
                        {
                            Guid idGudi = Guid.NewGuid();
                            
                            switch (uploaded_file.ContentType)
                            {
                                case "application/pdf":
                                    attachmentName = ConvertTextToSlug(model.Name)+".pdf";
                                    break;
                                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                                    attachmentName = ConvertTextToSlug(model.Name)+".docx";
                                    break;
                            }
                            sFiles_uploaded += attachmentName + idGudi + ".pdf";

                            new_Filename_on_Server = path_for_Uploaded_Files + "/" + sFiles_uploaded;

                            using (FileStream stream = new FileStream(new_Filename_on_Server, FileMode.Create))
                            {
                                await uploaded_file.CopyToAsync(stream);
                            }
                        }
                        else
                        {
                            return Json(new {success = false, responseText = "Yuksek Dosya Boyutu."});
                        }
                    }
                }

                var emailTemplate = new EmailTemplate
                {
                    To = "ik@doganlarmobilyagrubu.com",
                    Subject = "Bir iş başvuru formu dolduruldu!",
                    Body = " İsim Soyisim: " + model.Name + " \n Email: " + model.Email + " \n Mesaj: " + model.Message,
                    CC = ""
                };
                await _emailSender.SendEmailWithAttachment(emailTemplate, sFiles_uploaded, attachmentName);
                await _dbContext.Set<DoganlarMobilyaCVForm>().AddAsync(new DoganlarMobilyaCVForm()
                {
                    Mail = model.Email,
                    FullName = model.Name,
                    Message = model.Message,
                    CheckKvkk = true,
                    FilePath = sFiles_uploaded,
                    DisplayOrder = 0,
                    CreatedDate = DateTime.Now
                });
                await _dbContext.SaveChangesAsync();


                return Json(new {success = true});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json(new {success = false, responseText = "Formu Yeniden Doldurunuz."});
            }
        }
    }
}