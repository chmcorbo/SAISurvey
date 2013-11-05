using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Servicos;
using SAISurvey.Persistence.nHibernate;
using SAISurvey.Persistence.nHibernate.Repositorios;
using SAISurvey.App.Servicos.Modelo;
using SAISurvey.App.Servicos;

namespace SAISurvey.Persistence.nHibernate.Servicos
{
    public class ServEnviarConviteAvaliacao : IServEnviarConviteAvaliacao
    {
        private ConectionManager _conexao;
        private String _URL = String.Empty;

        public ServEnviarConviteAvaliacao(ConectionManager pConexao, String pURL)
        {
            _conexao = pConexao;
            _URL = pURL;
        }

        public Boolean Execute(DateTime pDataReferencia)
        {
            Boolean _erro = false;
            List<Avaliacao> lstAvaliacoes;
            EnvioEmail envioEmail = new EnvioEmail("smtp.gmail.com", true, "chmcorbo", "nqbx2009");
            MessagemEmail messagemEmail = new MessagemEmail();
            String _URLAluno = String.Empty;
            messagemEmail.Remetente = "comunicacao@infnet.edu.br";
            messagemEmail.Assunto = "Questionário de Avaliação do Curso";

            try
            {
                _conexao.BeginTransaction();
                RepositorioAvaliacao repositorioAvaliacao = new RepositorioAvaliacao(_conexao);
                RepositorioGenerico<AvaliacaoAluno> repositorioAvaliacaoAluno = new RepositorioGenerico<AvaliacaoAluno>(_conexao);
                lstAvaliacoes = repositorioAvaliacao.ListarSemConvite(pDataReferencia).ToList();
                if (lstAvaliacoes.Count() > 0)
                {
                    foreach (Avaliacao avaliacao in lstAvaliacoes)
                    {
                        foreach (Aluno aluno in avaliacao.Turma.Alunos)
                        {
                            AvaliacaoAluno avaliacaoAluno = new AvaliacaoAluno() { Avaliacao = avaliacao, Aluno = aluno };
                            foreach (Questao questao in avaliacao.Questoes)
                            {
                                avaliacaoAluno.AdicionarRespostaQuestao(questao);
                            }

                            _URLAluno = _URL + "?ID=" + avaliacaoAluno.ID;
                            messagemEmail.Destinatario = aluno.Email;
                            messagemEmail.ConteudoMessagem = "Olá " + aluno.Nome + "," +
                                Environment.NewLine +
                                Environment.NewLine +
                                "Esse é um convite para você responder um questionário de avaliação do módulo " + avaliacao.Turma.Modulo.Descricao +
                                Environment.NewLine +
                                "Clique no link " + _URLAluno +
                                Environment.NewLine +
                                Environment.NewLine +
                                "Esse questionário estará disponível até o dia " + avaliacao.Data_Fim.Value.ToString("dd/MM/yyyy") +
                                " as " + avaliacao.Data_Fim.Value.ToString("hh:mm:ss");
                            envioEmail.Enviar(messagemEmail);
                            repositorioAvaliacaoAluno.Adicionar(avaliacaoAluno);
                        }
                        avaliacao.ConviteEnviado = "S";
                        repositorioAvaliacao.Atualizar(avaliacao);
                    }
                }
                _conexao.CommitTransaction();
            }
            catch
            {
                _conexao.RollbackTransaction();
                _erro = true;
            }
            return !_erro;
        }
    }
}
