using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;

namespace RestaurantApp
{
    /**
     * This is the MailBiz class, it's responsible for sending email to the customers
     */
    class MailBiz
    {

        public static void sendmail(string toMail, string messageText, string subjectText )
        {

            //Make this method thread safe
            Object key = new Object();
            
            lock (key)
            {

                //The mail server
                SmtpClient client = new SmtpClient("fastapps04.qut.edu.au", 25);

                MailAddress from = new MailAddress("orders@asianfastfood.com", "Asian Fast Food", System.Text.Encoding.UTF8);
                MailAddress to = new MailAddress(toMail);

                MailMessage message = new MailMessage(from, to);
                message.Body = messageText;
                message.BodyEncoding = System.Text.Encoding.UTF8;

                message.Subject = subjectText;
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                client.Send(message);
                message.Dispose();

            }
        }
    }
}
