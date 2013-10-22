﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using clRecorderLog.Model;

namespace clRecorderLog.DAL
{
    public class CSVFile
    {
        private String _caminhoarquivo = String.Empty;
        private StringBuilder _sb;
        private StreamReader _sr;
        private StreamWriter _sw;

        private void Salvar()
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
            _sb.AppendLine("Data;Hora;Evento;Observacao");
            _sb.AppendLine(DateTime.Now.ToString("dd/MM/yyyy") + ";" + DateTime.Now.ToString("T") + ";Abertura do arquivo;Criação do arquivo realizada com sucesso com sucesso");
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
                    throw new FileRecorderLogNotFound();
                }
            }
            else
            {
                _sr = new StreamReader(_caminhoarquivo, System.Text.Encoding.UTF8);
                _sb.Append(_sr.ReadToEnd());
                _sr.Close();
            }
        }

        public CSVFile(String pCaminhoArquivo, Boolean pCriarArquivo)
        {
            _caminhoarquivo = pCaminhoArquivo;
            _sb = new StringBuilder();
            VerificarArquivoExiste(pCriarArquivo);
        }

        public Boolean Inserir(MRecordLog pRecordeLog)
        {
            Boolean vResult = false;
            _sb.AppendLine(pRecordeLog.Horario.ToString("dd/MM/yyyy") + ";"+
                           pRecordeLog.Horario.ToString("T") + ";"+
                           pRecordeLog.Evento + ";"+
                           pRecordeLog.Observacao);
            Salvar();
            vResult = true;
            return vResult;
        }
    }
}