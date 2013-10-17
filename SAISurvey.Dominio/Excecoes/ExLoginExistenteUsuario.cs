using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Excecoes
{
    public class ExLoginExistenteUsuario : Exception
    {
        public ExLoginExistenteUsuario(String pMessage) { }
    }
}
