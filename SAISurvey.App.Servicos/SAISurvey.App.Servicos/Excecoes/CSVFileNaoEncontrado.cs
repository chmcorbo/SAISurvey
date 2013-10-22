using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.App.Servicos.Excecoes
{
    public class CSVFileNaoEncontrado : Exception
    {
        public CSVFileNaoEncontrado() : base("Arquivo não encontrado") { }
    }
}
