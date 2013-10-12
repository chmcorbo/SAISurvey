using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Servicos
{
    public interface IServValidadorAcessoUsuario
    {
        Boolean Execute(String pLogin, String pSenha);
    }
}
