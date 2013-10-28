using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAISurvey.App.Servicos;
using SAISurvey.Dominio.Modelo;
using SAISurvey.Dominio.Excecoes;
using SAISurvey.Dominio.Servicos;
using SAISurvey.Persistence.nHibernate.Repositorios;
using SAISurvey.Persistence.nHibernate.Servicos;

namespace SAISurvey.Persistence.nHibernate.Servicos
{
    public class ServExportadorAvaliacaoCSV : IServExportadorAvaliacaoCSV
    {
        private CSVFile _csvFile;
        private String _CaminhoArquivo;
        private ConectionManager _conexao;
        private RepositorioAvaliacaoAluno repositorioAvaliacaoAluno;

        public ServExportadorAvaliacaoCSV(String pCaminhoArquivo)
        {
            _CaminhoArquivo = pCaminhoArquivo;
            _conexao = new ConectionManager();
            repositorioAvaliacaoAluno = new RepositorioAvaliacaoAluno(_conexao);
        }

        public Boolean Execute(AvaliacaoAluno pAvaliacaoAluno)
        {
            AvaliacaoAluno avaliacaoAluno = repositorioAvaliacaoAluno.ObterPorID(pAvaliacaoAluno.ID);

            if (avaliacaoAluno == null)
                throw new ExAvaliacaoAlunoInexistente();

            if (avaliacaoAluno.Fechada != "S")
                throw new ExAvaliacaoAlunoNaoEstaFechada();
            
            String NomeArquivo = "Avaliacao_"+pAvaliacaoAluno.ID+"_"+pAvaliacaoAluno.Aluno.Matricula+".csv";
            _csvFile = new CSVFile(_CaminhoArquivo+NomeArquivo, true);

            Boolean _erro = true;
            _csvFile.Inserir("Curso;" + pAvaliacaoAluno.Avaliacao.Turma.Modulo.Bloco.Curso.Descricao+";");
            _csvFile.Inserir("Bloco;" + pAvaliacaoAluno.Avaliacao.Turma.Modulo.Bloco.Descricao + ";");
            _csvFile.Inserir("Modulo;" + pAvaliacaoAluno.Avaliacao.Turma.Modulo.Descricao + ";");
            _csvFile.Inserir("Turma;" + pAvaliacaoAluno.Avaliacao.Turma.Descricao + ";");
            _csvFile.Inserir("Aluno;"+ pAvaliacaoAluno.Aluno.Nome+ ";");
            _csvFile.Inserir(Environment.NewLine);
            _csvFile.Inserir("Questão;Resposta;");
            foreach(RespostaQuestao respostaQuestao in pAvaliacaoAluno.RespostasQuestoes)
            {
                _csvFile.Inserir(respostaQuestao.Questao.Descricao + ";" + respostaQuestao.Resposta.Descricao);
            }
            _csvFile.Inserir("Comentários;" + pAvaliacaoAluno.Comentarios);
            _csvFile.Salvar();
            _erro = false;
            return !_erro;
        }
    }
}
