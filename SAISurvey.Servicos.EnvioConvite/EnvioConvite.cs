using System;
using System.ServiceProcess;

namespace SAISurvey.Servicos.EnvioConvite
{
    public partial class SEnvioConvite : ServiceBase
    {
        private CPrincipal cPrincipal;

        public SEnvioConvite()
        {
            InitializeComponent();
            cPrincipal = new CPrincipal();
            //cPrincipal.InitializeComponente(elgSAISurveyEnvioConvite);
        }

        protected override void OnStart(string[] args)
        {
            cPrincipal.Iniciar(args);
        }

        protected override void OnStop()
        {
            cPrincipal.Finalizar();
        }
    }
}
