using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SAISurvey.App.Servicos.Excecoes;

namespace SAISurvey.App.Servicos
{
    public class CSVFile
    {
        private String _caminhoarquivo = String.Empty;
        private StringBuilder _sb;
        private StreamReader _sr;
        private StreamWriter _sw;

        public CSVFile(String pCaminhoArquivo, Boolean pCriarArquivo)
        {
            _caminhoarquivo = pCaminhoArquivo;
            _sb = new StringBuilder();
            VerificarArquivoExiste(pCriarArquivo);
        }

        public void Salvar()
        {
            _sw = new StreamWriter(_caminhoarquivo,false, System.Text.Encoding.UTF8);
            _sw.Write(_sb);
            _sw.Flush();
            _sw.Close();
        }

        private void CriarArquivo()
        {
            FileStream fs = new FileStream(_caminhoarquivo, FileMode.CreateNew, FileAccess.ReadWrite);
            fs.Close();
        }

        private void InicializarArquivo()
        {
            _sb.Clear();
            Salvar();
        }

        private void VerificarArquivoExiste(Boolean pCriarArquivo)
        {
            if (!File.Exists(_caminhoarquivo))
            {
                if (pCriarArquivo)
                {
                    CriarArquivo();
                    InicializarArquivo();
                }
                else
                {
                    throw new CSVFileNaoEncontrado();
                }
            }
            else
            {
                _sr = new StreamReader(_caminhoarquivo, System.Text.Encoding.UTF8);
                _sb.Append(_sr.ReadToEnd());
                _sr.Close();
            }
        }

        public Boolean Inserir(String pTexto)
        {
            Boolean vResult = false;
            _sb.AppendLine(pTexto);
            vResult = true;
            return vResult;
        }
    }
}
