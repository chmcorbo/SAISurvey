using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Excecoes
{
    public class ExUsuarioNaoEncontrado : Exception
    {
        public ExUsuarioNaoEncontrado() : base("Login de usuário inválido") { }
    }
}
