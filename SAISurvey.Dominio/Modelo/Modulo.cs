using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Modelo
{
    [Serializable]
    public class Modulo : EntidadeBase
    {
        public virtual Bloco Bloco { get; set; }
        public virtual String Descricao { get; set; }
        public Modulo()
        {
            Bloco = new Bloco();
        }

        public Modulo(Bloco pBloco)
        {
            Bloco = pBloco;
        }
    }
}
