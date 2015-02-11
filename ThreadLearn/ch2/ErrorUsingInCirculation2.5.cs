using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Mail;
using System.Threading;
using System.Collections;

namespace ThreadLearn.ch2
{
    public class LoopingThreads
    {
        public delegate void SendMail(string oMessageTo);
        private class MyMail
        {
            public string EmailTo;
            public string EmailFrom;
            public string EmailSubject;
            public string EmailBody;
            public SendMail SendThisEmail; //delegate instance

            public void Send()
            {
                MailAddress Messagefrom = new MailAddress("movotoabel@gmail.com", "great abel", System.Text.Encoding.UTF8);  //发件人邮箱地址 
                ErrorUsingInCirculation2.gmail(Messagefrom, EmailTo, "test"+System.DateTime.Now.ToString(), "test");
                SendThisEmail(EmailTo);
            }

        }
        public static Thread CreateEmail(SendMail oSendEmail, string EmailTo, string EmailFrom, string EmailBody, string EmailSubject)
        {
            MyMail oMail = new MyMail();
            oMail.EmailTo = EmailTo;
            oMail.SendThisEmail = oSendEmail;

            Thread t = new Thread(new ThreadStart(oMail.Send));
            return t;


        }
    }

    class Mailer
    {
        public static void MailMethod(string oString)
        {
            Console.WriteLine("Sending mail:" + oString);
        }
    }
    public class ErrorUsingInCirculation2
    {
       

        
          public static bool gmail(MailAddress Messagefrom, string MessageTo, string MessageSubject, string MessageBody) 
        { 
            MailMessage message = new MailMessage(); 
            message.From = Messagefrom; 
            message.To.Add(MessageTo);              //收件人邮箱地址可以是多个以实现群发 
            message.Subject = MessageSubject; 
            message.Body = MessageBody; 
            message.IsBodyHtml = true;              //是否为html格式 
            message.Priority = MailPriority.High;  //发送邮件的优先等级 
            SmtpClient sc = new SmtpClient(); 
            sc.Host = "smtp.gmail.com";              //指定发送邮件的服务器地址或IP 
            sc.Port = 587;                          //指定发送邮件端口 
            sc.UseDefaultCredentials = true; 
            sc.EnableSsl = true; 
            sc.Credentials = new System.Net.NetworkCredential("movotoabel@gmail.com", "42Murloc"); //指定登录服务器的用户名和密码 
            try 
            { 
                sc.Send(message);      //发送邮件 
            } 
            catch (Exception e) 
            { 
                return false; 
            } 
            return true; 
        }

          static ArrayList al = new ArrayList();

        public static void Main()
        {
            al.Add("movotoabel@gmail.com");
            al.Add("awan@movoto.com");

            SendAllEmail();
        }
        public static void SendAllEmail()
        {
            int loopTo = al.Count - 1;
            for (int i = 0; i <= loopTo; i++)
            {
                Thread t = LoopingThreads.CreateEmail(
                    new LoopingThreads.SendMail(Mailer.MailMethod), (string)al[i], "movotoabel@movoto.com", "test", "test");
                t.Start();
                t.Join(Timeout.Infinite);
            }
        }

    }
}
