using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace SAISurvey.Servicos.EnvioConvite
{
    [RunInstaller(true)]
    public partial class piEnviarConvite : System.Configuration.Install.Installer
    {
        public piEnviarConvite()
        {
            InitializeComponent();
        }
    }
}
