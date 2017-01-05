using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using RBJLLawFirmDBModel;

/// <summary>
/// Summary description for EmailHelper
/// </summary>
public class EmailHelper
{
    private RBJLLawFirmDBEntities db { get; set; }
    private MailMessage emailCore { get; set; }
    string fromAddress = "sk.wong@mholics.com";
    string sendToAddress = "sk.wong@mholics.com";
    string emailSubject = "testing send";
    string htmlContent = "<b>testing send Email</b>";

    public EmailHelper()
    {
        db = new RBJLLawFirmDBEntities();
        emailCore = new MailMessage();
        emailCore.From = new MailAddress(fromAddress);
        var emailList = getSystemEmail();
        foreach (var item in emailList)
        {
            emailCore.To.Add(new MailAddress(item));
        }
        emailCore.Bcc.Add(new MailAddress(sendToAddress));

        emailCore.Subject = emailSubject;
        emailCore.Body = htmlContent;


        emailCore.IsBodyHtml = true;
    }

    public EmailHelper(string setEmailSubject)
    {
        db = new RBJLLawFirmDBEntities();
        emailCore = new MailMessage();
        emailCore.From = new MailAddress(fromAddress);

        var emailList = getSystemEmail();
        foreach (var item in emailList)
        {
            emailCore.To.Add(new MailAddress(item));
        }

        emailCore.Bcc.Add(new MailAddress(sendToAddress));
        emailCore.Subject = setEmailSubject;
        emailCore.Body = htmlContent;


        emailCore.IsBodyHtml = true;
    }

    public EmailHelper(string setEmailSubject, string htmlContent)
    {
        db = new RBJLLawFirmDBEntities();
        emailCore = new MailMessage();
        emailCore.From = new MailAddress(fromAddress);

        var emailList = getSystemEmail();
        foreach (var item in emailList)
        {
            emailCore.To.Add(new MailAddress(item));
        }

        emailCore.Bcc.Add(new MailAddress(sendToAddress));
        emailCore.Subject = setEmailSubject;
        emailCore.Body = htmlContent;

        emailCore.IsBodyHtml = true;
    }

    public EmailHelper(EmailDto emailDto)
    {
        db = new RBJLLawFirmDBEntities();
        emailCore = new MailMessage();
        //emailCore.From = new MailAddress(fromAddress);
        emailCore.From = new MailAddress(emailDto.fromAddr);
        var emailList = getSystemEmail();
        foreach (var item in emailList)
        {
            emailCore.To.Add(new MailAddress(item));
        }
        emailCore.To.Add(new MailAddress(emailDto.ccTo));
        if (!String.IsNullOrEmpty(emailDto.ccTo2))
        {
            emailCore.To.Add(new MailAddress(emailDto.ccTo2));
        }

        emailCore.Bcc.Add(new MailAddress(sendToAddress));
        emailCore.Subject = emailDto.subject;
        emailCore.Body = emailDto.content;


        emailCore.IsBodyHtml = true;
    }



    private string[] getSystemEmail()
    {
        var result = db.Miscellaneous.Where(p => p.id == (int)EnumMiscellaneous.AccountEmail).FirstOrDefault().numberValue;
        var resultArr = result.Split(new char[] { ',', ';' });
        return resultArr;
    }


    public bool sendEmail()
    {
        bool result = false;
        SmtpClient client = new SmtpClient();
        // client.EnableSsl = true; //gmail
        client.EnableSsl = false;
        try
        {
            client.Send(emailCore);
            result = true;
        }

        catch (SmtpException ex)
        {
            HttpContext.Current.Response.Write(String.Format("Failed, CompleteEmail: SmtpException: {0}\n)", ex.Message));
            Console.WriteLine(String.Format("Failed, CompleteEmail: SmtpException: {0}\n)", ex.Message));
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(String.Format("Failed, CompleteEmail: SmtpException: {0}\n)", ex.Message));
            Console.WriteLine(String.Format("Failed, CompleteEmail: UnknownException: {0}\n)", ex.Message));
        }
        return result;
    }

}