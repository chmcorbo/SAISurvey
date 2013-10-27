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
            get { return _session ?? (_session = _ConectionManager.GetConnection()); }
            set { _session = value; }
        }

        public RepositorioGenerico(ConectionManager pConectionManager)
        {
            _ConectionManager = pConectionManager;
        }

        public virtual void Adicionar(T pEntidadeBase)
        {
         
            try
            {
                Session.Save(pEntidadeBase);
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
                Session.SaveOrUpdate(pEntidadeBase);
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
                Session.Delete(pEntidadeBase);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir o registro. " + Environment.NewLine + e.Message);
            }
        }

        public virtual IQueryable<T> ListarTudo()
        {
            IQueryable<T> lista = null;
            try
            {
                lista = Session.CreateCriteria(typeof(T)).List<T>().AsQueryable();
            }
            catch (Exception e)
            {
                throw new Exception("Erro na execução da consulta. " + Environment.NewLine + e.Message);
            }
            
            return lista;
        }

        public virtual T ObterPorID(String pID)
        {
            IQueryOver<T> queryOver = Session.QueryOver<T>().Where(t => t.ID == pID);
            return queryOver.List<T>().FirstOrDefault();
        }

    }
}
