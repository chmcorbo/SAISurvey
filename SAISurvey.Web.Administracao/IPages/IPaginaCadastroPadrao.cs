using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio;

namespace SAISurvey.Web.Administracao.IPages
{
    public interface IPaginaCadastroPadrao<T>  where T : EntidadeBase
    {
        void BindToUI(T pObjeto);
        T BindToModel();
        void Gravar(T pObjeto);
    }
}
