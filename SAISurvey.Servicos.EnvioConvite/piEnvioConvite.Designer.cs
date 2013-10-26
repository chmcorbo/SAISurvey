namespace SAISurvey.Servicos.EnvioConvite
{
    partial class piEnviarConvite
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spiEnviarConvite = new System.ServiceProcess.ServiceProcessInstaller();
            this.siEnviarConvite = new System.ServiceProcess.ServiceInstaller();
            // 
            // spiEnviarConvite
            // 
            this.spiEnviarConvite.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.spiEnviarConvite.Password = null;
            this.spiEnviarConvite.Username = null;
            // 
            // siEnviarConvite
            // 
            this.siEnviarConvite.Description = "Serviço de envio de convite de participação de questionário";
            this.siEnviarConvite.DisplayName = "wsSAISurveyEnvioConvite";
            this.siEnviarConvite.ServiceName = "SAISurveyEnvioConvite";
            // 
            // piEnviarConvite
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.spiEnviarConvite,
            this.siEnviarConvite});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller spiEnviarConvite;
        private System.ServiceProcess.ServiceInstaller siEnviarConvite;
    }
}