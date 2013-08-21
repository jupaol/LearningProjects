using System;
using System.ServiceModel;
using System.Windows.Forms;
using NinjectShared;

namespace ServiceClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string resFromWcf;

            using (var channelFactory = new ChannelFactory<ILoggingService>("MyLoggingServiceEndPoint"))
            {
                var proxy = channelFactory.CreateChannel();

                resFromWcf = proxy.DoWork();
            }

            
        }
    }
}
