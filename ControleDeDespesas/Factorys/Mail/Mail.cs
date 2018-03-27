using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Factorys.Mail
{
    public class Mail
    {
        public string To { get; private set; }
        public string From { get; private set; }
        public string Cc { get; private set; }
        public string Cco { get; private set; }
        public List<string> Attached { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }



        public Mail(string to, 
                    string from, 
                    string subject = "", 
                    string body = "", 
                    string cc = "", 
                    string cco = "", 
                    List<string> attached = null)
        {
            this.To = to;
            this.From = from;
            this.Subject = subject;
            this.Body = body;
            this.Cc = cc;
            this.Cco = cco;
            this.Attached = attached;
        }

        public void Send()
        {
            MailMessage mail = new MailMessage(this.From, this.To);

            mail.Body = this.Body;
            mail.Subject = this.Subject;

            try
            {
                mail.CC.Add(this.Cc);
                mail.Bcc.Add(this.Cco);
            }
            catch (ArgumentException ex)
            {

                Console.Write(ex.Message);
            }
            
            

            
            
                     
            //Anexos 
            if(this.Attached != null)
            {
                for (int i = 0; i <= this.Attached.Count; i++)
                {
                    mail.Attachments.Add(new Attachment(this.Attached[i]));
                }
            }

            //Faz o envio do e-mail
            using(SmtpClient client = new SmtpClient("172.16.0.150", 25))
            {
                try
                {
                    //Faz o envio 
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught in CreateBccTestMessage(): {0}",
                                ex.ToString());
                }                
            }

        }



    }
}
