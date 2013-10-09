using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAISurvey.Dominio.Modelo
{
    public class Usuario : EntidadeBase
    {
        public virtual String Login { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Senha { get; set; }
        public virtual String Administrador { get; set; }
        public Usuario()
        {
            Administrador = "N";
        }
    }
}
