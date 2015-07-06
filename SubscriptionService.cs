using System;
using System.Collections.Generic;
using System.Text;

namespace EsccWebTeam.ServiceSubscriptions
{
    /// <summary>
    /// A service which can be subscribed to
    /// </summary>
    [Serializable] // for ViewState support
    public class SubscriptionService
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
    }
}
