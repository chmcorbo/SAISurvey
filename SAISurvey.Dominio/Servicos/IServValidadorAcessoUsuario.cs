using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;

namespace SAISurvey.Dominio.Servicos
{
    public interface IServValidadorAcessoUsuario
    {
        Usuario Execute(String pLogin, String pSenha);
    }
}
