using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Concrete
{
    public class OrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public OrderProcessor(EmailSettings emailSettings)
        {
            this.emailSettings = emailSettings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.EnableSsl = this.emailSettings.UseSsl;
                smtp.Host = this.emailSettings.ServerName;
                smtp.Port = this.emailSettings.ServerPort;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(this.emailSettings.Username, this.emailSettings.Password);

                if (this.emailSettings.WriteAsFile)
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtp.PickupDirectoryLocation = this.emailSettings.FileLocation;
                    smtp.EnableSsl = false;
                }

                var body = new StringBuilder()
                    .AppendLine("A new order has been submited")
                    .AppendLine("---")
                    .AppendLine("Items:");

                foreach (var item in cart.Lines)
                {
                    body.AppendFormat("{0} x {1}, unitary price: {2:c} (subtotal: {3:c})", item.Product.Name, item.Product.Price, item.Quantity, item.Product.Price * item.Quantity);
                }

                body.AppendFormat("Total order value {0:c}", cart.ComputeTotalCost())
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shippingDetails.Name)
                    .AppendLine(shippingDetails.Line1)
                    .AppendLine(shippingDetails.Line2 ?? string.Empty)
                    .AppendLine(shippingDetails.Line3 ?? string.Empty)
                    .AppendLine(shippingDetails.City)
                    .AppendLine(shippingDetails.State ?? string.Empty)
                    .AppendLine(shippingDetails.Country)
                    .AppendLine(shippingDetails.Zip ?? string.Empty)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}", shippingDetails.Wrap ? "yes" : "no");

                var mailMessage = new MailMessage(this.emailSettings.MailFromAddress, this.emailSettings.MailToAddress, "New order submitted!", body.ToString());

                if (this.emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }

                smtp.Send(mailMessage);
            }
        }
    }
}
