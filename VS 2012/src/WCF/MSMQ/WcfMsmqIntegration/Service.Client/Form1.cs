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
            var proxy = new LoggingProxy().GetLoggingProxy("Service.ServiceContracts.LoggingService");
            var addDeploymentLogRequest = new AddDeploymentLogRequest
                {
                    AddDeploymentLog = new AddDeploymentLog
                        {
                            BuildName = "some build name",
                            DatabaseServerName = "some database server name",
                            Environment = "some environment",
                            FullBuildName = "some full build name",
                            Product = "some product"
                        }
                };
            var response = proxy.AddDeploymentLog(addDeploymentLogRequest);

            MessageBox.Show(string.Format("{0}{1}{2}", response.DeploymentId.ToString(), Environment.NewLine, response.NewServerName));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var proxy = new LoggingProxy().GetLoggingProxy("Service.ServiceContracts.LoggingService WSHttp");

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

            MessageBox.Show(string.Format("{0}{1}{2}", response.DeploymentId.ToString(), Environment.NewLine, response.NewServerName));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var proxy = new LoggingProxy().GetQueueLoggingProxy("Service.ServiceContracts.QueueLoggingService NET MSMQ");

            proxy.AddDeploymentLog(new AddDeploymentLogRequest
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

            MessageBox.Show("Message sent.");
        }
    }
}
