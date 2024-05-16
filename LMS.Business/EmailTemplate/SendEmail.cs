using LMS.Business.Models;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;

namespace LMS.Business.EmailTemplate
{

    public class SendEmail : IRequest<Unit>
    {
        public SendEmailDto SendEmailDto { get; set; }

        public class Handler : IRequestHandler<SendEmail, Unit>
        {
            private const string EmailFrom = "no-reply@techqode.com";
            private const string EmailFromPassword = "S+m-i5ccugxz";
            private const string SmtpServer = "mail.techqode.com";
            private const int Port = 465;

            private readonly IConfiguration _configuration;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public Handler(IConfiguration iConfig, IHttpContextAccessor httpContextAccessor)
            {
                _configuration = iConfig;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<Unit> Handle(SendEmail request, CancellationToken cancellationToken)
            {
                try
                {
                    string baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
                    var msg = new MailMessage();
                    var sb = new StringBuilder();

                    //string path = _configuration.GetSection("frontend").GetSection("IpAndServerAddress").Value;

                    if (request.SendEmailDto.EmailType == "Forgot Password")
                    {
                        var link = baseUrl + "/Identity/Account/ResetPassword?id=" + request.SendEmailDto.UserId;
                        //Basic Email Template
                        sb.Append("<table class='body-wrap' style='box-sizing: border-box; font-size: 14px; width: 100%; background-color: transparent; margin:0;' bgcolor=transparent>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0;' valign='top'>");
                        sb.Append("</td>");
                        sb.Append("<td class='container' width='600' style='font-family:'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; display: block !important; max-width: 600px !important; clear: both !important; margin: 0 auto;' valign='top'>");
                        sb.Append("<div class='content' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; max-width: 600px; display: block; margin: 0 auto; padding: 20px;'>");
                        sb.Append("<table class='main' width='100%' cellpadding='0' cellspacing='0' itemprop='action' itemscope  itemtype='http://schema.org/ConfirmAction' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; border-radius: 3px; background-color: transparent; margin: 0; border: 1px dashed #4D79F6;'  bgcolor='#fff'>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-wrap' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 20px;' valign='top'>");
                        sb.Append("<meta itemprop='name' content='Confirm Email' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;' />");
                        sb.Append("<table width='100%' cellpadding='0' cellspacing='0'  style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.Append("<a href='#'>");
                        sb.Append("<img src='assets/images/logo-sm.png' alt='' style='margin-left: auto; margin-right: auto; display:block; margin-bottom: 10px; height: 40px;'>");
                        sb.Append("</a>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-block' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; color: #4D79F6; font-size: 24px; font-weight: 700; text-align: center; vertical-align: top; margin: 0; padding: 0 0 10px;' valign='top'>");
                        sb.Append("Welcome To LMS");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-block' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; color: #3F5DB3; font-size: 14px; vertical-align: top; margin: 0; padding: 10px 10px;' valign='top'>");
                        sb.Append(" Your Request For Reset Password has been approved");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-block' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 10px 10px;'  valign='top'>");
                        sb.Append("Please Click on the link below to Reset Your Password.");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-block' itemprop='handler' itemscope itemtype='http://schema.org/HttpActionHandler'  style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 10px 10px;'      valign='top'>");
                        sb.Append("<a href='"+ link+"' class='btn-primary' style='font-size: 14px; text-decoration: none; line-height: 2em; font-weight: bold; text-align: center; cursor: pointer; display: block; border-radius: 5px; text-transform: capitalize; border: none; padding: 10px 20px;'>");
                        sb.Append("Click to Reset Your Password");
                        sb.Append("</a>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr  style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-block'  style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; padding-top: 5px; vertical-align: top; margin: 0; text-align: right;' valign='top'>");
                        sb.Append("&mdash;" + "<b>" + "LMS" + "</b>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("</table>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("</table>");
                        sb.Append("</div>");
                        sb.Append("</td>");
                        sb.Append("<td style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0;'          valign='top'>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("</table>");

                        msg.Body = sb.ToString();
                    }

                    if (request.SendEmailDto.EmailType == "Confirm Email Account")
                    {
                        var link = baseUrl + "/Identity/Account/Login";
                        //Basic Email Template
                        sb.Append("<table class='body-wrap' style='box-sizing: border-box; font-size: 14px; width: 100%; background-color: transparent; margin:0;' bgcolor=transparent>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0;' valign='top'>");
                        sb.Append("</td>");
                        sb.Append("<td class='container' width='600' style='font-family:'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; display: block !important; max-width: 600px !important; clear: both !important; margin: 0 auto;' valign='top'>");
                        sb.Append("<div class='content' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; max-width: 600px; display: block; margin: 0 auto; padding: 20px;'>");
                        sb.Append("<table class='main' width='100%' cellpadding='0' cellspacing='0' itemprop='action' itemscope  itemtype='http://schema.org/ConfirmAction' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; border-radius: 3px; background-color: transparent; margin: 0; border: 1px dashed #4D79F6;'  bgcolor='#fff'>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-wrap' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 20px;' valign='top'>");
                        sb.Append("<meta itemprop='name' content='Confirm Email' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;' />");
                        sb.Append("<table width='100%' cellpadding='0' cellspacing='0'  style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.Append("<a href='#'>");
                        sb.Append("<img src='assets/images/logo-sm.png' alt='' style='margin-left: auto; margin-right: auto; display:block; margin-bottom: 10px; height: 40px;'>");
                        sb.Append("</a>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-block' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; color: #4D79F6; font-size: 24px; font-weight: 700; text-align: center; vertical-align: top; margin: 0; padding: 0 0 10px;' valign='top'>");
                        sb.Append("WelCome To LMS");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-block' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; color: #3F5DB3; font-size: 14px; vertical-align: top; margin: 0; padding: 10px 10px;' valign='top'>");
                        sb.Append("Dear: " + request.SendEmailDto.Name + " Your account has been approved you can login by clicking link bellow");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-block' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 10px 10px;'  valign='top'>");
                        // sb.Append("We may need to send you critical information about our service and it is  important that we have an accurate email address.");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-block' itemprop='handler' itemscope itemtype='http://schema.org/HttpActionHandler'  style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 10px 10px;'      valign='top'>");
                        sb.Append("<a href='" + link + "' class='btn-primary' style='font-size: 14px; text-decoration: none; line-height: 2em; font-weight: bold; text-align: center; cursor: pointer; display: block; border-radius: 5px; text-transform: capitalize; border: none; padding: 10px 20px;'>");
                        sb.Append("Go To Login");
                        sb.Append("</a>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr  style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-block'  style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; padding-top: 5px; vertical-align: top; margin: 0; text-align: right;' valign='top'>");
                        sb.Append("&mdash;" + "<b>" + "LMS" + "</b>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("</table>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("</table>");
                        sb.Append("</div>");
                        sb.Append("</td>");
                        sb.Append("<td style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0;'          valign='top'>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("</table>");

                        msg.Body = sb.ToString();
                    }
                    
                    if (request.SendEmailDto.EmailType == "Verification Student Profile")
                    {
                        var link = baseUrl + "/Account/ApprovedTraineeStatus?id="+request.SendEmailDto.UserId+"&status=true";
                        //Basic Email Template
                        sb.Append("<table class='body-wrap' style='box-sizing: border-box; font-size: 14px; width: 100%; background-color: transparent; margin:0;' bgcolor=transparent>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0;' valign='top'>");
                        sb.Append("</td>");
                        sb.Append("<td class='container' width='600' style='font-family:'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; display: block !important; max-width: 600px !important; clear: both !important; margin: 0 auto;' valign='top'>");
                        sb.Append("<div class='content' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; max-width: 600px; display: block; margin: 0 auto; padding: 20px;'>");
                        sb.Append("<table class='main' width='100%' cellpadding='0' cellspacing='0' itemprop='action' itemscope  itemtype='http://schema.org/ConfirmAction' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; border-radius: 3px; background-color: transparent; margin: 0; border: 1px dashed #4D79F6;'  bgcolor='#fff'>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-wrap' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 20px;' valign='top'>");
                        sb.Append("<meta itemprop='name' content='Confirm Email' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;' />");
                        sb.Append("<table width='100%' cellpadding='0' cellspacing='0'  style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.Append("<a href='#'>");
                        sb.Append("<img src='assets/images/logo-sm.png' alt='' style='margin-left: auto; margin-right: auto; display:block; margin-bottom: 10px; height: 40px;'>");
                        sb.Append("</a>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-block' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; color: #4D79F6; font-size: 24px; font-weight: 700; text-align: center; vertical-align: top; margin: 0; padding: 0 0 10px;' valign='top'>");
                        sb.Append("WelCome To LMS");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-block' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; color: #3F5DB3; font-size: 14px; vertical-align: top; margin: 0; padding: 10px 10px;' valign='top'>");
                        sb.Append("New student: " + request.SendEmailDto.Name + " has been registered. Please verify student profile by clicking on link below");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-block' style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 10px 10px;'  valign='top'>");
                        // sb.Append("We may need to send you critical information about our service and it is  important that we have an accurate email address.");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-block' itemprop='handler' itemscope itemtype='http://schema.org/HttpActionHandler'  style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0; padding: 10px 10px;'      valign='top'>");
                        sb.Append("<a href='" + link + "' class='btn-primary' style='font-size: 14px; text-decoration: none; line-height: 2em; font-weight: bold; text-align: center; cursor: pointer; display: block; border-radius: 5px; text-transform: capitalize; border: none; padding: 10px 20px;'>");
                        sb.Append("Go To Login");
                        sb.Append("</a>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr  style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; margin: 0;'>");
                        sb.Append("<td class='content-block'  style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; padding-top: 5px; vertical-align: top; margin: 0; text-align: right;' valign='top'>");
                        sb.Append("&mdash;" + "<b>" + "LMS" + "</b>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("</table>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("</table>");
                        sb.Append("</div>");
                        sb.Append("</td>");
                        sb.Append("<td style='font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; box-sizing: border-box; font-size: 14px; vertical-align: top; margin: 0;'          valign='top'>");
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("</table>");

                        msg.Body = sb.ToString();
                    }


                    var mimeMessage = new MimeMessage();
                    mimeMessage.From.Add(new MailboxAddress("Salam LMS", EmailFrom));
                    mimeMessage.To.Add(new MailboxAddress("Salam LMS", request.SendEmailDto.EmailTo));
                    mimeMessage.Subject = request.SendEmailDto.Subject;
                    mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                    { Text = msg.Body };


                    using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
                    await smtpClient.ConnectAsync(SmtpServer, Port, true, cancellationToken);
                    await smtpClient.AuthenticateAsync(EmailFrom, EmailFromPassword, cancellationToken);
                    var response = await smtpClient.SendAsync(mimeMessage, cancellationToken);
                    await smtpClient.DisconnectAsync(true, cancellationToken);


                    return Unit.Value;
                }
                catch (Exception)
                {
                    return Unit.Value;
                }
            }
        }
    }
}
