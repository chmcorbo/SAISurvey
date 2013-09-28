using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio.Modelo;

namespace SAISurvey.Dominio.Repositorios
{
    public interface IRepositorioGenerico<T> where T:EntidadeBase
    {
        void Adicionar(T pEntidadeBase);
        void Excluir(T pEntidadeBase);
        void Atualizar(T pEntidadeBase);
        T ObterPorID(String pID);
        IQueryable<T> ListarTudo();
    }
}
