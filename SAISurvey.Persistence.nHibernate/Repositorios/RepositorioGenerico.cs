using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using SAISurvey.Dominio;
using SAISurvey.Dominio.Repositorios;

namespace SAISurvey.Persistence.nHibernate.Repositorios
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T: EntidadeBase 
    {
        private ISession _session;
        private ConectionManager _ConectionManager;

        protected ConectionManager ConectionManager
        {
            get { return _ConectionManager; }
        }

        protected ISession Session
        {
            get { return _session; }
            set { _session = value; }
        }

        public RepositorioGenerico()
        {
            
        }

        public RepositorioGenerico(ConectionManager pConectionManager)
        {
            _ConectionManager = pConectionManager;
        }

        public virtual void Adicionar(T pEntidadeBase)
        {
         
            try
            {
                _session = _ConectionManager.GetConnection();
                _session.Save(pEntidadeBase);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao inserir ou atualizar o registro. " + Environment.NewLine + e.Message);
            }

        }

        public virtual void Atualizar(T pEntidadeBase)
        {
            try
            {
                _session = _ConectionManager.GetConnection();
                _session.SaveOrUpdate(pEntidadeBase);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao inserir ou atualizar o registro. " + Environment.NewLine + e.Message);
            }
        }

        public virtual void Excluir(T pEntidadeBase)
        {
            try
            {
                _session = _ConectionManager.GetConnection();
                _session.Delete(pEntidadeBase);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir o registro. " + Environment.NewLine + e.Message);
            }
        }

        public virtual IQueryable<T> ListarTudo()
        {
            _session = _ConectionManager.GetConnection();
            IQueryable<T> lista = null;
            try
            {
                lista = _session.CreateCriteria(typeof(T)).List<T>().AsQueryable();
            }
            catch (Exception e)
            {
                throw new Exception("Erro na execução da consulta. " + Environment.NewLine + e.Message);
            }
            
            return lista;
        }

        public virtual T ObterPorID(String pID)
        {
            _session = _ConectionManager.GetConnection();
            IQueryOver<T> queryOver = _session.QueryOver<T>().Where(t => t.ID == pID);
            return queryOver.List<T>().FirstOrDefault();
        }

    }
}
