using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FluentEmail.Core;
using Microsoft.Extensions.Logging;
using Taigate.Cms.Models;

namespace Taigate.Cms.Services
{
    public class EmailSender:IEmailSender
    {
        private readonly IFluentEmail _email;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(IFluentEmail email, ILogger<EmailSender> logger)
        {
            _email = email;
            _logger = logger;
        }

        public async Task<bool> SendEmail(EmailTemplate emailTemplate)
        {
            var result = await _email
                .To(emailTemplate.To)
                .Subject(emailTemplate.Subject)
                .Body(emailTemplate.Body)
                //.CC(emailTemplate.CC)
                .SendAsync();

            if (!result.Successful)
            {
                _logger.LogError("Mail Gönderilemedi.\n{Errors}", string.Join(Environment.NewLine, result.ErrorMessages));
            }

            return result.Successful;
        }
        
        public async Task<bool> SendEmailWithAttachment(EmailTemplate emailTemplate,string attachmentPath,string attachmentName)
        {
            var result = await _email
                .To(emailTemplate.To)
                .Subject(emailTemplate.Subject)
                .Body(emailTemplate.Body)
                .AttachFromFilename($"{Directory.GetCurrentDirectory()}/wwwroot/Files/CV/"+attachmentPath,"application/pdf",attachmentName)
                //.CC(emailTemplate.CC)
                .SendAsync();

            if (!result.Successful)
            {
                _logger.LogError("Mail Gönderilemedi.\n{Errors}", string.Join(Environment.NewLine, result.ErrorMessages));
            }

            return result.Successful;
        }

    }
}