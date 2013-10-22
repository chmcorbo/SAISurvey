using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Configuration;
using SAISurvey.App.Servicos.Modelo;

namespace SAISurvey.App.Servicos
{
    public class EnvioEmail
    {
        SmtpClient _SmtpClient;

        public EnvioEmail(String pServidorSMTP, Boolean pHabilitarSSL, String pUsuario, String pSenha)
        {
            _SmtpClient = new SmtpClient(pServidorSMTP, 587);
            _SmtpClient.Timeout = 120000;
            _SmtpClient.EnableSsl = pHabilitarSSL;
            _SmtpClient.Credentials = new NetworkCredential(pUsuario, pSenha);
        }
        public Boolean Enviar(MessagemEmail pMessagemEmail)
        {
            Boolean _erro = false;
            MailMessage messagem = new MailMessage();
            messagem.Sender = new MailAddress(pMessagemEmail.Remetente,"Infnet Comunicação");
            messagem.From = messagem.Sender;
            messagem.To.Add(pMessagemEmail.Destinatario);
            messagem.Subject = pMessagemEmail.Assunto;
            messagem.Body = pMessagemEmail.ConteudoMessagem;
            messagem.IsBodyHtml = false;
            messagem.Priority = MailPriority.High;
            _SmtpClient.Send(messagem);
            return !_erro;
        }
    

    }
}
