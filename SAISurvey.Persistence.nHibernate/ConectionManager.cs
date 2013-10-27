using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace SAISurvey.Persistence.nHibernate
{
    public class ConectionManager
    {
        private HybridSessionBuilder _builder = new HybridSessionBuilder();
        private ITransaction _TransactionAtual = null;
        private ISession _ConexaoAtual = null;

        public ConectionManager()
        {

        }

        public ITransaction BeginTransaction()
        {
            _TransactionAtual = GetConnection().BeginTransaction();

            return _TransactionAtual;
        }

        public ISession GetSession()
        {
            if (_builder == null)
                _builder = new HybridSessionBuilder();

            return _ConexaoAtual ?? (_ConexaoAtual = _builder.GetSession());
        }

        public ISession GetConnection()
        {
            if (_ConexaoAtual == null)
            {
                _ConexaoAtual = GetSession();
            }
            return _ConexaoAtual;
        }

        public void CloseConnection()
        {
            if (_ConexaoAtual.IsOpen)
                _ConexaoAtual.Close();
        }

        public void CommitTransaction()
        {
            _TransactionAtual.Commit();
        }

        public void RollbackTransaction()
        {
            _TransactionAtual.Rollback();
        }

        public ITransaction GetTransaction()
        {
            return _TransactionAtual;
        }
    }
}
