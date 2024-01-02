using System.Net.Mail;

namespace Unieja.Api
{
    public class ConfigEmail
    {
        public string GetItemLabelValueEmail(string label, string value)
        {
            return $"<b style='font-size:18px'>{label}: </b><span style='font-size:15px;font-weight:normal'>{value}</span><br>";
        }

        public string GetBodyEmail(string Subject, string ItensBody)
        {
            string HeaderEmail = "https://unieja.com.br/wp-content/uploads/2023/07/cropped-cropped-logo_unieja.jpg";

            return "<div style='text-align:center'><div style='max-width: 600px; margin: 0 auto;'>" +
                      $"<img src='{HeaderEmail}'>" +
                      $"<h2>{Subject}<h2><br>" +
                      $"<div style='text-align:left;word-wrap: break-word'>{ItensBody}</div><br /></div>";
        }

        public RetornoEmail EmailEnviado(string emailDestino, string subject, string body, string tituloErro)
        {
            RetornoEmail retorno = new RetornoEmail();

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.hostinger.com");


                mail.From = new MailAddress("cadastro@unieja.com.br");
                mail.To.Add(new MailAddress("multiplaescolhaeducacional@gmail.com"));
                mail.CC.Add(new MailAddress("anderson.ferdomingos@gmail.com"));
                mail.ReplyToList.Add(new MailAddress(emailDestino));
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpServer.Port = 587;
                SmtpServer.EnableSsl = false;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("cadastro@unieja.com.br", "Unieja@22");

                SmtpServer.Send(mail);

                retorno.EmailEnviado = 1;
                retorno.RetornoMsgEmail = "E-mail enviado com sucesso!";
                
                return retorno;
            }
            catch (Exception ex)
            {
                retorno.EmailEnviado = 0;
                retorno.RetornoMsgEmail = "Falha" + tituloErro + " : " + ex.Message.ToString();

                return retorno;
            }
        }
    }

    public class RetornoEmail
    {
        public sbyte EmailEnviado { get; set; }

        public string RetornoMsgEmail { get; set; }
    }
}
