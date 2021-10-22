using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.SendEmail
{
    public class SendMail
    {
        public async Task<ModelSendResponse> Send(ModelSend ModeloSend)
        {
            try
            {
                // Estancia da Classe de Mensagem
                MailMessage _mailMessage = new MailMessage();
                // Remetente
                _mailMessage.From = new MailAddress(ModeloSend.EmailRemetente);

                // Destinatario seta no metodo abaixo

                //Contrói o MailMessage
                _mailMessage.CC.Add(ModeloSend.EmailDestinatario);
                _mailMessage.Subject = ModeloSend.ClientAssunto;
                _mailMessage.IsBodyHtml = true;
                string email = $"<b>Nome do Client {ModeloSend.ClientName}</b>" +
                                 $"<br></br>" +
                                 $"<p>Email {ModeloSend.ClientMail}</p>"+
                                 $"<br></br>" +
                                 $"<p>Número de Celular {ModeloSend.ClientContato}</p>"+
                                 $"<br></br>" +
                                 $"<p>Objetivo {ModeloSend.ClientAssunto}</p>"+
                                 $"<br></br>" +
                                 $"<p>Mesangem {ModeloSend.ClientMessage}</p>";
                
                _mailMessage.Body = email;

                //CONFIGURAÇÃO COM PORTA
                SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

                //CONFIGURAÇÃO SEM PORTA
                // SmtpClient _smtpClient = new SmtpClient(UtilRsource.ConfigSmtp);

                // Credencial para envio por SMTP Seguro (Quando o servidor exige autenticação)
                _smtpClient.UseDefaultCredentials = false;
                _smtpClient.Credentials = new NetworkCredential("", "");

                _smtpClient.EnableSsl = true;

                _smtpClient.Send(_mailMessage);

                ModelSendResponse Response = new ModelSendResponse();
                Response.Message = "Entraremos em contato em breve!";
                Response.Success = true;
                return Response;

            }
            catch (Exception ex)
            {
                ModelSendResponse Response = new ModelSendResponse();
                Response.Message = "Mensagem não enviada tente novamente mais tarde" + ex.Message;
                Response.Success = false;
                return Response;
               
            }
        }
    }
}
