﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Excecoes
{
    public class ExUsuarioNaoAdministrador : Exception
    {
        public ExUsuarioNaoAdministrador(String Message) { }
    }
}