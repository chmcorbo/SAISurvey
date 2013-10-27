using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.Dominio;
using SAISurvey.Dominio.Controladores;
using SAISurvey.Dominio.Repositorios;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Repositorios;

namespace SAISurvey.Persistence.nHibernate.Controladores
{
    public class ControladorGenerico<T> : IControladorGenerico<T> where T:EntidadeBase
    {
        private ConectionManager _conexao;
        private IRepositorioGenerico<T> _repositorio;

        protected ConectionManager Conexao
        {
            get { return _conexao; }
            set { _conexao = value; }
        }

        protected IRepositorioGenerico<T> Repositorio
        {
            get { return _repositorio; }
            set { _repositorio = value; }
        }

        public ControladorGenerico()
        {
            _conexao = new ConectionManager();
            _repositorio = new RepositorioGenerico<T>(_conexao);
        }

        public virtual void Adicionar(T pEntidadeBase)
        {
            try
            {
                _conexao.BeginTransaction();
                _repositorio.Adicionar(pEntidadeBase);
                _conexao.CommitTransaction();
            }
            catch (Exception ex)
            {
                _conexao.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }

        public virtual void Atualizar(T pEntidadeBase)
        {
            try
            {
                _conexao.BeginTransaction();
                _repositorio.Atualizar(pEntidadeBase);
                _conexao.CommitTransaction();
            }
            catch (Exception ex)
            {
                _conexao.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }

        public virtual void Excluir(T pEntidadeBase)
        {
            try
            {
                _conexao.BeginTransaction();
                _repositorio.Excluir(pEntidadeBase);
                _conexao.CommitTransaction();
            }
            catch (Exception ex)
            {
                _conexao.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }


        public virtual T ObterPorID(string pID)
        {
            return _repositorio.ObterPorID(pID);
        }

        public virtual List<T> ListarTudo()
        {
            return _repositorio.ListarTudo().ToList();
        }
    }
}
