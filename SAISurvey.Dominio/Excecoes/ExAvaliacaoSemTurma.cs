﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Excecoes
{
    public class ExAvaliacaoSemTurma : Exception
    {
        public ExAvaliacaoSemTurma() : base("Avaliação não possui uma turma associada.") { }
    }
}
