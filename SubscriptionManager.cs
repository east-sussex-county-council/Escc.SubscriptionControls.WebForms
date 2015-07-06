using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Resources;
using System.Text;
using System.Net.Mail;
using Escc.AddressAndPersonalDetails;
using EsccWebTeam.ServiceSubscriptions.Properties;

namespace EsccWebTeam.ServiceSubscriptions
{
    /// <summary>
    /// Static methods for subscribing to and unsubscribing from services
    /// </summary>
    public static class SubscriptionManager
    {
        /// <summary>
        /// Create and send an activation email for a service subscription.
        /// </summary>
        /// <param name="serviceName">The name of the service being subscribed to</param>
        /// <param name="fromAddress">The address to send the email from.</param>
        /// <param name="subscriberAddress">The subscriber address.</param>
        /// <param name="activationUrl">The activation URL, including a {0} token to be replaced by the activation code.</param>
        /// <param name="activationCode">The code which must be supplied to activate the subscription</param>
        public static void SendActivationEmail(string serviceName, ContactEmail fromAddress, ContactEmail subscriberAddress, Uri activationUrl, string activationCode)
        {
            // get email body and replace variables
            StringBuilder body = new StringBuilder(Resources.ActivationEmailBody);
            body.Replace("{ServiceName}", serviceName);
            body.Replace("{Activation URL}", String.Format(activationUrl.ToString(), activationCode));
            body.Replace("{Email address}", subscriberAddress.EmailAddress);

            // build the email
            MailMessage message = new MailMessage();
            message.To.Add(new MailAddress(subscriberAddress.EmailAddress, subscriberAddress.DisplayName));
            message.From = new MailAddress(fromAddress.EmailAddress, fromAddress.DisplayName);
            message.Subject = String.Format(Resources.ActivationEmailSubject, serviceName);
            message.IsBodyHtml = false;
            message.Body = body.ToString();

            SmtpClient client = new SmtpClient();
            client.Send(message);
        }
    }
}