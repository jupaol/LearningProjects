using System;
using System.Windows.Forms;
using Service.ClientProxies;
using Service.DataContracts;
using Service.MessageContracts;

namespace Service.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var proxy = new LoggingProxy().GetLoggingProxy();

            var response = proxy.AddDeploymentLog(new AddDeploymentLogRequest
                {
                    AddDeploymentLog = new AddDeploymentLog
                        {
                            BuildName = "some build name",
                            DatabaseServerName = "some database server name",
                            Environment = "some environment",
                            FullBuildName = "some full build name",
                            Product = "some product"
                        }
                });

            var res = response.DeploymentId;

            MessageBox.Show(res.ToString());
        }
    }
}
