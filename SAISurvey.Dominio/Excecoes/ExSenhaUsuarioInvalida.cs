using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Excecoes
{
    public class ExSenhaUsuarioInvalida : Exception
    {
        public ExSenhaUsuarioInvalida() : base("Senha de usuário inválida") { }
    }
}
