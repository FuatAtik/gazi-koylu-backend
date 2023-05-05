using System.Threading.Tasks;
using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc;
using Taigate.Cms.Models;

namespace Taigate.Cms.Services
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailTemplate emailTemplate);
        Task<bool> SendEmailWithAttachment(EmailTemplate emailTemplate,string attachmentPath, string attachmentName);

    }
}