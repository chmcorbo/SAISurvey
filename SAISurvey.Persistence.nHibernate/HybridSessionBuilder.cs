using System;
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
    public class HybridSessionBuilder
    {
        private static ISession _currentSession;
        private static ISessionFactory _sessionFactory;
        private static Boolean _criarBanco;

        public HybridSessionBuilder(Boolean pCriarBanco = false)
        {
            _criarBanco = pCriarBanco;
        }


        public ISession GetSession()
        {
            ISessionFactory factory = GetSessionFactory();

            if (!CurrentSessionContext.HasBind(factory))
                CurrentSessionContext.Bind(GetExistingOrNewSession(factory));

            return factory.GetCurrentSession();
        }

        public Configuration GetConfiguration()
        {
            var configuration = new Configuration();
            configuration.Configure();
            return configuration;
        }

        private ISessionFactory GetSessionFactory()
        {
            return _sessionFactory ?? (_sessionFactory = Build().BuildSessionFactory());
        }

        private ISession GetExistingOrNewSession(ISessionFactory factory)
        {
            if (_currentSession == null)
            {
                _currentSession = factory.OpenSession();
            }
            else if (!_currentSession.IsOpen)
            {
                _currentSession = factory.OpenSession();
            }

            return _currentSession;
        }

        public static FluentConfiguration Build()
        {
             return Fluently.Configure()
                           .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromAppSetting("MsSQLServerSAISurvey")))
                           .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()).Conventions.Add<StringColumnLengthConvention>())
                           .ExposeConfiguration(BuildSchema);

        }

        private static void BuildSchema(Configuration config)
        {
            config.SetProperty("current_session_context_class", "thread_static");

            if (_criarBanco)
            {
                new SchemaExport(config)
                    .Drop(true, true);

                new SchemaExport(config)
                    .Create(true, true);
            }
        }

        public static void ResetSession()
        {
            var builder = new HybridSessionBuilder();
            
            //builder.GetSession().Dispose();

            ISession currentSession = CurrentSessionContext.Unbind(builder.GetSessionFactory());

            if (currentSession == null) return;

            currentSession.Close();
            currentSession.Dispose();
        }
    }

    public class StringColumnLengthConvention : IPropertyConvention, IPropertyConventionAcceptance // ???
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Type == typeof(string)).Expect(x => x.Length == 0);
        }
        public void Apply(IPropertyInstance instance)
        {
            instance.Length(10000);
        }
    }
}

