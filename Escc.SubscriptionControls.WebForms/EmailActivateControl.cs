using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escc.SubscriptionControls.WebForms.Properties;

namespace Escc.SubscriptionControls.WebForms
{
    /// <summary>
    /// Process an activation link for a subscription, and display confirmation message
    /// </summary>
    [ToolboxData("<{0}:EmailActivateControl runat=server></{0}:EmailActivateControl>")]
    public class EmailActivateControl : WebControl, INamingContainer
    {
        #region Initialisation
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailActivateControl"/> class.
        /// </summary>
        public EmailActivateControl()
        {
            this.Service = new SubscriptionService();
            this.CodeParameter = "code";
        }

        /// <summary>
        /// Hook up internal event handlers, and attempt activation
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            // hook up internal event handlers
            this.Activated += new EventHandler<SubscriptionEventArgs>(DisplayMessage_Activated);
            this.ActivationFailed += new System.EventHandler(DisplayMessage_ActivationFailed);
            this.ActivationRequestMissing += new System.EventHandler(DisplayMessage_ActivationFailed);

            base.OnInit(e);
        }
        #endregion

        #region Templated control
        /// <summary>
        /// Container for header and footer templates
        /// </summary>
        private class XhtmlContainer : PlaceHolder, INamingContainer { }

        /// <summary>
        /// Renders the HTML opening tag of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        public override void RenderBeginTag(HtmlTextWriter writer) { }

        /// <summary>
        /// Renders the HTML closing tag of the control into the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A <see cref="T:System.Web.UI.HtmlTextWriter"/> that represents the output stream to render HTML content on the client.</param>
        public override void RenderEndTag(HtmlTextWriter writer) { }

        /// <summary>
        /// Gets or sets the template which appears when activation fails. Include a <see cref="System.Web.UI.WebControls.Literal"/> with <c>ID</c> set to <c>"FailureServiceName"</c> to display the value of <see cref="SubscriptionService.Name"/>.
        /// </summary>
        /// <value>The template.</value>
        [TemplateContainer(typeof(XhtmlContainer))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)] // This makes it validate in Visual Studio (allegedly)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] // This makes it validate in Visual Studio (allegedly)
        public ITemplate FailureTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template which appears when activation succeeds. Include a <see cref="System.Web.UI.WebControls.Literal"/> with <c>ID</c> set to <c>"SuccessServiceName"</c> to display the value of <see cref="SubscriptionService.Name"/>.
        /// </summary>
        /// <value>The template.</value>
        [TemplateContainer(typeof(XhtmlContainer))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)] // This makes it validate in Visual Studio (allegedly)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] // This makes it validate in Visual Studio (allegedly)
        public ITemplate SuccessTemplate { get; set; }
        #endregion

        #region Properties
        private SubscriptionEventArgs eventArgs;

        /// <summary>
        /// Gets or sets the service to subscribe to.
        /// </summary>
        /// <value>The service.</value>
        public SubscriptionService Service { get; set; }

        /// <summary>
        /// Saves any state that was modified after the <see cref="M:System.Web.UI.WebControls.Style.TrackViewState"/> method was invoked.
        /// </summary>
        /// <returns>
        /// An object that contains the current view state of the control; otherwise, if there is no view state associated with the control, null.
        /// </returns>
        protected override object SaveViewState()
        {
            this.ViewState["Service"] = this.Service;
            return base.SaveViewState();
        }

        /// <summary>
        /// Restores view-state information from a previous request that was saved with the <see cref="M:System.Web.UI.WebControls.WebControl.SaveViewState"/> method.
        /// </summary>
        /// <param name="savedState">An object that represents the control state to restore.</param>
        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            if (ViewState["Service"] != null) this.Service = (SubscriptionService)ViewState["Service"];
        }

        /// <summary>
        /// Gets or sets the name of the query string parameter containing the activation code.
        /// </summary>
        /// <value>The code parameter.</value>
        public string CodeParameter { get; set; }
        #endregion

        #region Main logic


        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            // get activation code from querystring
            if (!String.IsNullOrEmpty(this.Context.Request.QueryString[this.CodeParameter]))
            {
                // fire events
                this.OnActivationCodeSubmitted();
                if (this.eventArgs.Success)
                {
                    this.OnActivated();
                }
                else
                {
                    this.OnActivationFailed();
                }
            }
            else
            {
                // fire event
                this.OnActivationRequestMissing();
            }
        }


        #endregion

        #region Event handlers to display messages

        /// <summary>
        /// Display a message indicating that a subscription has been activated successfully
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayMessage_Activated(object sender, EventArgs e)
        {
            this.EnsureChildControls();
            this.Controls.Clear();

            if (SuccessTemplate == null) SuccessTemplate = new DefaultTemplate(this.Service, Resources.EmailActivationSuccess);

            XhtmlContainer container = new XhtmlContainer();
            SuccessTemplate.InstantiateIn(container);
            this.Controls.Add(container);

            // If the intro contains a Literal with the id "SuccessServiceName", replace it with the current service name
            Literal serviceName = container.FindControl("SuccessServiceName") as Literal;
            if (serviceName != null) serviceName.Text = Service.Name;

        }

        /// <summary>
        /// Display a message indicating that activation has failed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayMessage_ActivationFailed(object sender, EventArgs e)
        {
            this.EnsureChildControls();
            this.Controls.Clear();

            if (FailureTemplate == null) FailureTemplate = new DefaultTemplate(this.Service, Resources.EmailActivationFailure);

            XhtmlContainer container = new XhtmlContainer();
            FailureTemplate.InstantiateIn(container);
            this.Controls.Add(container);

            // If the intro contains a Literal with the id "FailureServiceName", replace it with the current service name
            Literal serviceName = container.FindControl("FailureServiceName") as Literal;
            if (serviceName != null) serviceName.Text = Service.Name;
        }

        #endregion

        #region Events

        /// <summary>
        /// Event indicating that a subscription code has been found
        /// </summary>
        public event EventHandler<SubscriptionEventArgs> ActivationCodeSubmitted;

        /// <summary>
        /// Event indicating that an attempt to activate a subscription has failed
        /// </summary>
        /// <remarks>This would be because the code was in the query string but not valid</remarks>
        public event EventHandler ActivationFailed;

        /// <summary>
        /// Event indicating that no attempt to activate a subscription was detected
        /// </summary>
        /// <remarks>This would be because no activation code was found in the query string</remarks>
        public event EventHandler ActivationRequestMissing;

        /// <summary>
        /// Event indicating that a subscription has been activated
        /// </summary>
        public event EventHandler<SubscriptionEventArgs> Activated;

        /// <summary>
        /// Raise an event indicating that a subscription code has been submitted
        /// </summary>
        protected virtual void OnActivationCodeSubmitted()
        {
            if (this.ActivationCodeSubmitted != null)
            {
                this.eventArgs = new SubscriptionEventArgs();
                this.eventArgs.Service = this.Service;
                this.eventArgs.SubscriptionCode = this.Context.Request.QueryString[this.CodeParameter];
                this.ActivationCodeSubmitted(this, this.eventArgs);
            }
        }

        /// <summary>
        /// Raise an event indicating that a subscription has been activated successfully
        /// </summary>
        protected virtual void OnActivated()
        {
            if (this.Activated != null)
            {
                if (this.eventArgs == null)
                {
                    this.eventArgs = new SubscriptionEventArgs();
                    this.eventArgs.Service = this.Service;
                }
                this.Activated(this, this.eventArgs);
            }
        }

        /// <summary>
        /// Raise an event indicating that an attempt to activate a subscription has failed
        /// </summary>
        protected virtual void OnActivationFailed()
        {
            if (this.ActivationFailed != null)
            {
                this.ActivationFailed(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Event indicating that no attempt to activate a subscription was detected
        /// </summary>
        protected virtual void OnActivationRequestMissing()
        {
            if (this.ActivationRequestMissing != null)
            {
                this.ActivationRequestMissing(this, EventArgs.Empty);
            }
        }

        #endregion

    }
}
