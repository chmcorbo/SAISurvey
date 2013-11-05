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
            if (!System.Diagnostics.EventLog.SourceExists("SAISurveyEnvioConvite"))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    "SAISurveyEnvioConvite", "SAISurveyEnvioConviteLog");
            }
            _EventLog.Source = "SAISurveyEnvioConvite";
            _EventLog.Log = "SAISurveyEnvioConviteLog";
        }

        public void Iniciar(String[] args)
        {
            //_EventLog.WriteEntry("Inicialização");
            //_EventLog.WriteEntry("Criando o objeto Gerenciador de Tarefas");
            sGerenciadorTarefas = new SGerenciadorTarefas(_EventLog);
            //_EventLog.WriteEntry("Criando o objeto _timerTarefa");
            _timerTarefa = new System.Timers.Timer();
            _timerTarefa.Enabled = false;
            //_EventLog.WriteEntry("Fazendo method point no objeto _timerTarefa.");
            _timerTarefa.Elapsed += new System.Timers.ElapsedEventHandler(sGerenciadorTarefas.ExecutarTarefaAgenda);
            _timerTarefa.Interval = 30000;
            //_EventLog.WriteEntry("Habilitando o timer (_timerTarefa).");
            _timerTarefa.Enabled = true;
            //_EventLog.WriteEntry("Inicialização concluída");
        }

        public void Finalizar()
        {
            //_EventLog.WriteEntry("Serviço parado");
        }
    }
}
