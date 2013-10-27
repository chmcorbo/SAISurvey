using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using SAISurvey.Dominio.Servicos;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Servicos;

namespace SAISurvey.Servicos.EnvioConvite
{
    public class SGerenciadorTarefas
    {
        private System.Diagnostics.EventLog _EventLog;

        public SGerenciadorTarefas(System.Diagnostics.EventLog pEventLog)
        {
            _EventLog = pEventLog;
        }

        public void ExecutarTarefaAgenda(Object source, ElapsedEventArgs e)
        {
            try
            {
                ConectionManager conexao = new ConectionManager();
                ServEnviarConviteAvaliacao servEnviarConviteAvaliacao = new ServEnviarConviteAvaliacao(conexao);
                servEnviarConviteAvaliacao.Execute(DateTime.Now);
                _EventLog.WriteEntry("Execução do serviço servEnviarConviteAvaliacao.Execute().");
            }
            catch (Exception Ex)
            {
                _EventLog.WriteEntry("Erro durante a execução do serviço servEnviarConviteAvaliacao. Erro: " + Ex.Message);
            }
        }
    }
}
