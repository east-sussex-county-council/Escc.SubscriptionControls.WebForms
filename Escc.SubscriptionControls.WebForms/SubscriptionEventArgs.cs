using System;
using Escc.AddressAndPersonalDetails;

namespace Escc.SubscriptionControls.WebForms
{
    /// <summary>
    /// Information about a subscription
    /// </summary>
    public class SubscriptionEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionEventArgs"/> class.
        /// </summary>
        public SubscriptionEventArgs()
        {
            this.Success = true;
        }

        /// <summary>
        /// Gets or sets the service to subscribe to.
        /// </summary>
        /// <value>The service.</value>
        public SubscriptionService Service { get; set; }

        /// <summary>
        /// Gets or sets the email address to subscribe.
        /// </summary>
        /// <value>The email address.</value>
        public ContactEmail EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether activation or deactivation succeeds.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the code required to activate or deactivate a subscription.
        /// </summary>
        /// <value>The subscription code.</value>
        public string SubscriptionCode { get; set; }
    }
}
