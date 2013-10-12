using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;

namespace SAISurvey.Dominio.Servicos
{
    public interface IServValidadorGravacaoUsuario
    {
        Boolean Execute(Usuario pUsuario);
    }
}
