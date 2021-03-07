using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Sss.GvErlenacker.Models.DataModels;
using Sss.GvErlenacker.Models.Enums;
using Sss.GvErlenacker.Models.Poco;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Sss.GvErlenacker.Services.Impl
{
    public class MailService : BaseService, IMailService
    {

        private readonly IConfigService _configService;
        private readonly IImageService _imageService;
        private readonly ISponsorService _sponsorService;


        public MailService(IConfigService configService, IImageService imageService, ISponsorService sponsorService)
        {
            _configService = configService;
            _imageService = imageService;
            _sponsorService = sponsorService;
        }

        public void SendConfirmMail(MemberFormModel model)
        {
            var config = _configService.GetEMailConfig(1548);
            var bld = new StringBuilder();
            bld.Append(GetMailHeader());

            if (model.Salutation == ESalutation.Female)
            {
                bld.Append(config.SalutationFemale.Replace("[[Name]]", model.Name));
            }
            else if (model.Salutation == ESalutation.Male)
            {
                bld.Append(config.SalutationMale.Replace("[[Name]]", model.Name));
            }

            bld.Append("<br /><br />");
            bld.Append(config.Body);

            if (model.SponsorType == ESponsorType.Business || model.SponsorType == ESponsorType.Link)
            {
                bld.Append($"Firma: {model.Company}");
                bld.Append($"Website: {model.Website}");
            }

            bld.Append($"<p>Name: {model.Name}<br />");
            bld.Append($"Vorname: {model.FirstName}<br />");
            bld.Append($"Strasse: {model.Street} {model.Number}<br />");
            bld.Append($"PlZ / Ort: {model.Zip} {model.City}<br />");
            bld.Append($"Email: {model.Email}<br />");
            bld.Append($"Telefon: {model.Phone}<br /></p>");
            bld.Append(config.Footer);
            bld.Append(GetMailFooter());

            var mail = new MailMessage()
            {
                From = new MailAddress(config.SenderEmail),
                Subject = config.Subject,
                Body = bld.ToString(),
                IsBodyHtml = true
            };
            mail.To.Add(model.Email);
            foreach (var receiver in config.ReceiverEMails)
            {
                mail.Bcc.Add(receiver.Trim());
            }

            SendMail(mail);
        }

        public void SendInfoMail(MemberFormModel model)
        {
            var config = _configService.GetEMailConfig(1668);
            var bld = new StringBuilder();
            bld.Append(GetMailHeader());

            bld.Append(config.SalutationMale);
            bld.Append("<br /><br />");
            bld.Append(config.Body);

            bld.Append(config.Body);

            if (model.SponsorType == ESponsorType.Business || model.SponsorType == ESponsorType.Link)
            {
                bld.Append($"Firma: {model.Company}");
                bld.Append($"Website: {model.Website}");
            }

            bld.Append($"<p>Name: {model.Name}<br />");
            bld.Append($"Vorname: {model.FirstName}<br />");
            bld.Append($"Strasse: {model.Street} {model.Number}<br />");
            bld.Append($"PlZ / Ort: {model.Zip} {model.City}<br />");
            bld.Append($"Email: {model.Email}<br />");
            bld.Append($"Telefon: {model.Phone}<br /></p>");
            bld.Append(config.Footer);
            bld.Append(GetMailFooter());



            bld.Append(config.Footer);
            bld.Append(GetMailFooter());

            var mail = new MailMessage()
            {
                From = new MailAddress(config.SenderEmail),
                Subject = config.Subject,
                Body = bld.ToString(),
                IsBodyHtml = true
            };


            foreach (var receiver in config.ReceiverEMails)
            {
                mail.To.Add(receiver.Trim());
            }

            SendMail(mail);
        }

        public void SendContactMail(ContactFormViewModel model)
        {
            var config = _configService.GetEMailConfig(1676);
            var bld = new StringBuilder();
            bld.Append(GetMailHeader());
            bld.Append(config.SalutationMale);
            bld.Append("<br /><br />");
            bld.Append(config.Body);
            bld.Append($"<p>Name: {model.Name}<br />");
            bld.Append($"Vorname: {model.Firstname}<br />");
            bld.Append($"Email: {model.Email}<br />");
            bld.Append($"Nachricht: {model.Message}</p>");

            bld.Append(config.Footer);
            bld.Append(GetMailFooter());

            var mail = new MailMessage()
            {
                From = new MailAddress(config.SenderEmail),
                Subject = config.Subject,
                Body = bld.ToString(),
                IsBodyHtml = true
            };


            if (model.Key == null || model.Key == Guid.Empty)
            {
                foreach (var receiver in config.ReceiverEMails)
                {
                    mail.To.Add(receiver.Trim());
                }

            }
            else
            {
                var member = CurrentHelper.Content(1624).Value<IEnumerable<IPublishedElement>>("boardMembers")
                    .FirstOrDefault(m => m.Key == model.Key);

                if (member == null)
                    throw new Exception("Member not found!");


                mail.To.Add(member.Value<string>("email"));
            }



            SendMail(mail);
        }



        public void SendMessageReceivedMail(ContactFormViewModel model)
        {
            var config = _configService.GetEMailConfig(1675);
            var bld = new StringBuilder();
            bld.Append(GetMailHeader());
            bld.Append(config.SalutationMale);
            bld.Append("<br /><br />");
            bld.Append(config.Body);
            bld.Append($"<p>Name: {model.Name}<br />");
            bld.Append($"Vorname: {model.Firstname}<br />");
            bld.Append($"Email: {model.Email}<br />");
            bld.Append($"Nachricht: {model.Message}</p>");

            bld.Append(config.Footer);
            bld.Append(GetMailFooter());

            var mail = new MailMessage()
            {
                From = new MailAddress(config.SenderEmail),
                Subject = config.Subject,
                Body = bld.ToString(),
                IsBodyHtml = true
            };


            mail.To.Add(model.Email);

            foreach (var receiver in config.ReceiverEMails)
            {
                mail.Bcc.Add(receiver.Trim());
            }
            

            SendMail(mail);

        }


        private string GetMailHeader()
        {
            var bld = new StringBuilder();

            var config = CurrentHelper.ContentAtRoot().First(c => c.ContentType.Alias == "configFolder")?.Children
                .First(c => c.ContentType.Alias == "headerConfig");

            Image logo = _imageService.GetImage(config.Value("logo") as IPublishedContent, height: 150);

            string host = CurrentContext.HttpContext?.Request?.Url?.Host != null ?
                $"http://{CurrentContext.HttpContext.Request.Url.Host}" : "http://gv-erlenacker.ch";

            bld.Append($"<div><img src='{host}{logo.LargeUrl}' alt='Gönnervereinigung Nachwuchs Erlenacker' / ></div>");

            return bld.ToString();

        }


        private string GetMailFooter()
        {
            var bld = new StringBuilder();
            string host = CurrentContext.HttpContext?.Request?.Url?.Host != null ?
                $"http://{CurrentContext.HttpContext.Request.Url.Host}" : "http://gv-erlenacker.sss";
            var sponsor = _sponsorService.GetPremiumSponsor();

            bld.Append(
                $"<div>");
            bld.Append($"Mit freundlicher Unterstützung unseres Hauptsponsors:<br /><br />");
            bld.Append($"<a href='{sponsor.Website}'>");
            bld.Append($"<img src='{host}{sponsor.Logo.SmallUrl}' alt='{sponsor.FactoryName}' />");
            bld.Append("</a></div>");

            return bld.ToString();
        }


        private void SendMail(MailMessage mail)
        {
            var smtpClient = new SmtpClient("server85.hostfactory.ch")
            {
                Port = 587,
                Credentials = new NetworkCredential("no-reply@gv-erlenacker.ch", "NoReply12345!"),
                EnableSsl = true,
            };



            smtpClient.Send(mail);
        }
    }
}
