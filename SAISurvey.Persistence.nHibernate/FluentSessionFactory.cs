using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace SAISurvey.Persistence.nHibernate
{
    public class FluentSessionFactory
    {
        public static ISessionFactory _sessionFactory;

        private static ISessionFactory CriarSessionFactory(bool criarBanco)
        {
            //Implementando um singleton para caso a sessão já exista
            if (_sessionFactory != null && !criarBanco)
                return _sessionFactory;

            #region Configuração de qual Banco de dados será utilizando

            //Arquivo de configuração de banco SQL Server, MySQL e PostgreSQL
            IPersistenceConfigurer configDB = null;

            //Se for o banco SQLServer

            configDB = MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromAppSetting("MsSQLServerUpperAcademy"));

            #endregion

            //Adicionando os arquivos de mapeamento
            var configFluent = Fluently.Configure().Database((IPersistenceConfigurer)configDB)
                .Mappings(m =>
                {
                    m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()).Conventions.Add<StringColumnLengthConvention>();
                });

            //Gerando o Banco de dados
            if (criarBanco)
                configFluent = configFluent.ExposeConfiguration(GerarSchema);

            _sessionFactory = configFluent.BuildSessionFactory();

            return _sessionFactory;
        }

        public static ISession AbrirSession(bool criarBanco = false)
        {
            return CriarSessionFactory(criarBanco).OpenSession();
        }

        private static void GerarSchema(NHibernate.Cfg.Configuration config)
        {
            SchemaExport schema = new SchemaExport(config);

            //Deletando o Schema existente
            schema.Drop(false, true);

            //Gerar Schema
            schema.Create(false, true);
        }
    }

}
