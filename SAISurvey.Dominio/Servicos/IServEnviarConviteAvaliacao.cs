﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Servicos
{
    public interface IServEnviarConviteAvaliacao
    {
        Boolean Execute(DateTime pDataReferencia);
    }
}
