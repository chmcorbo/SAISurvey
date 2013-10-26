using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SAISurvey.Servicos.EnvioConvite
{
    public class CPrincipal
    {
        private System.Timers.Timer _timerTarefa;
        private SGerenciadorTarefas sGerenciadorTarefas;
        private System.Diagnostics.EventLog _EventLog = null;

        public void InitializeComponente(System.Diagnostics.EventLog pEventLog)
        {
            if (!System.Diagnostics.EventLog.SourceExists("elgSAISurveyEnvioConvite"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "elgSAISurveyEnvioConvite", "wsSAISurveyEnvioConviteLog");
            }
            _EventLog.Source = "elgSAISurveyEnvioConvite";
            _EventLog.Log = "wsSAISurveyEnvioConviteLog";
        }

        public void Iniciar(String[] args)
        {
            sGerenciadorTarefas = new SGerenciadorTarefas(_EventLog);
            _timerTarefa = new System.Timers.Timer();
            _timerTarefa.Enabled = false;
            _timerTarefa.Elapsed += new System.Timers.ElapsedEventHandler(sGerenciadorTarefas.ExecutarTarefaAgenda);
            _timerTarefa.Interval = 30000;
            _timerTarefa.Enabled = true;
            _EventLog.WriteEntry("Serviço iniciado");
        }

        public void Finalizar()
        {
            _EventLog.WriteEntry("Serviço parado");
        }
    }
}
