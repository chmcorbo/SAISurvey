using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace SAISurvey.Persistence.nHibernate.Repositorios
{
    public class Banco
    {
        public static Boolean CriarBancoDeDados()
        {
            Boolean _erro = false;
            try
            {
                HybridSessionBuilder _builder = new HybridSessionBuilder(true);
                _builder.GetSession();
            }
            catch (Exception e)
            {
                _erro = true;
                throw new Exception("Erro na criação do banco de dados. " + Environment.NewLine + e.Message);
            }
            return !_erro;
        }
    }
}
