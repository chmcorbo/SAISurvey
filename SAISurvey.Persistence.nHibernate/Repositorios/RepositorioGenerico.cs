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
        HybridSessionBuilder _builder = new HybridSessionBuilder();

        private ISession _session;
        protected virtual ISession Session
        {
            get
            {
                if (_builder == null)
                    _builder = new HybridSessionBuilder();

                return _session ?? (_session = _builder.GetSession());
            }
        }

        public virtual void Adicionar(T pEntidadeBase)
        {
            ITransaction transaction = Session.BeginTransaction();
            try
            {
                Session.Clear(); // Ver isso com o Coelho
                Session.SaveOrUpdate(pEntidadeBase);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception("Erro ao inserir ou atualizar o registro. " + Environment.NewLine + e.Message);
            }
            finally
            {
                transaction.Dispose();
            }

        }

        public virtual void Atualizar(T pEntidadeBase)
        {
            this.Adicionar(pEntidadeBase);
        }

        public virtual void Excluir(T pEntidadeBase)
        {
            ITransaction transaction = Session.BeginTransaction();
            try
            {
                Session.Clear();
                Session.Delete(pEntidadeBase);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception("Erro ao excluir o registro. " + Environment.NewLine + e.Message);
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public virtual IQueryable<T> ListarTudo()
        {
            ITransaction transaction = Session.BeginTransaction();
            IQueryable<T> lista = null;
            try
            {
                Session.Clear();
                lista = Session.CreateCriteria(typeof(T)).List<T>().AsQueryable();
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
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
