using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.App.Servicos.Modelo
{
    public class MessagemEmail
    {
        public String Remetente { get; set; }
        public String Destinatario { get; set; }
        public String Assunto { get; set; }
        public String ConteudoMessagem { get; set; }
    }
}
