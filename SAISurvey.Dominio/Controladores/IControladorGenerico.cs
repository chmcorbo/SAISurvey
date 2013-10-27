using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Controladores
{
    public interface IControladorGenerico<T> where T:EntidadeBase
    {
        void Adicionar(T pEntidadeBase);
        void Atualizar(T pEntidadeBase);
        void Excluir(T pEntidadeBase);
        T ObterPorID(String pID);
        List<T> ListarTudo();
    }
}
