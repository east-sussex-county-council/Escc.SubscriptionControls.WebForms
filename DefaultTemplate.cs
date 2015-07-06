using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace EsccWebTeam.ServiceSubscriptions
{

    /// <summary>
    /// Default template used when no template is specified for a templated control
    /// </summary>
    internal class DefaultTemplate : ITemplate
    {
        private SubscriptionService service;
        private string defaultXhtml;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultTemplate"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="defaultXhtml">The default XHTML.</param>
        internal DefaultTemplate(SubscriptionService service, string defaultXhtml)
        {
            this.service = service;
            this.defaultXhtml = defaultXhtml;
        }

        #region ITemplate Members

        /// <summary>
        /// When implemented by a class, defines the <see cref="T:System.Web.UI.Control"/> object that child controls and templates belong to. These child controls are in turn defined within an inline template.
        /// </summary>
        /// <param name="container">The <see cref="T:System.Web.UI.Control"/> object to contain the instances of controls from the inline template.</param>
        public void InstantiateIn(Control container)
        {
            container.Controls.Add(new LiteralControl(this.defaultXhtml.Replace("{ServiceName}", this.service.Name)));
        }

        #endregion
    }
}
