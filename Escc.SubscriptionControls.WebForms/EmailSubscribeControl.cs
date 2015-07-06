using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Escc.AddressAndPersonalDetails;
using Escc.FormControls.WebForms;
using Escc.FormControls.WebForms.Validators;
using Escc.SubscriptionControls.WebForms.Properties;

namespace Escc.SubscriptionControls.WebForms
{
    /// <summary>
    /// Control to capture an email address, to subscribe to a service delivered by email
    /// </summary>
    public class EmailSubscribeControl : WebControl, INamingContainer
    {
        private TextBox email;
        private TextBox confirmEmail;
        private SubscriptionEventArgs eventArgs;

        private Label emailReadOnly;

        #region Properties

        /// <summary>
        /// Gets or sets the name of the query string parameter containing the activation code.
        /// </summary>
        /// <value>The code parameter.</value>
        public string CodeParameter { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailSubscribeControl"/> class.
        /// </summary>
        public EmailSubscribeControl()
        {
            this.Service = new SubscriptionService();
            this.CodeParameter = "code";
        }

        /// <summary>
        /// Hook up internal events
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            this.EmailAddressSubmitted += new System.EventHandler<SubscriptionEventArgs>(this.ShowConfirmationMessage_EmailAddressSubmitted);
            this.SubscriptionOptionsUpdated += new System.EventHandler<SubscriptionEventArgs>(this.ShowConfirmationMessage_SubscriptionOptionsUpdated);
            base.OnInit(e);
        }

        #endregion

        /// <summary>
        /// Gets or sets the header template which appears before everything in the initial subscription view. 
        /// </summary>
        /// <value>The header template.</value>
        [TemplateContainer(typeof(XhtmlContainer))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)] // This makes it validate in Visual Studio (allegedly)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] // This makes it validate in Visual Studio (allegedly)
        public ITemplate SubscribeHeaderTemplate { get; set; }

        /// <summary>
        /// Gets or sets the intro template which appears before the header template and form controls. Include a <see cref="System.Web.UI.WebControls.Literal"/> with <c>ID</c> set to <c>"IntroServiceName"</c> to display the value of <see cref="SubscriptionService.Name"/>.
        /// </summary>
        /// <value>The intro template.</value>
        [TemplateContainer(typeof(XhtmlContainer))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)] // This makes it validate in Visual Studio (allegedly)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] // This makes it validate in Visual Studio (allegedly)
        public ITemplate IntroTemplate { get; set; }

        /// <summary>
        /// Gets or sets the header template which appears before the form controls. 
        /// </summary>
        /// <value>The header template.</value>
        [TemplateContainer(typeof(XhtmlContainer))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)] // This makes it validate in Visual Studio (allegedly)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] // This makes it validate in Visual Studio (allegedly)
        public ITemplate FormHeaderTemplate { get; set; }

        /// <summary>
        /// Gets or sets the extra options template which appears before the footer template
        /// </summary>
        /// <value>The footer template.</value>
        [TemplateContainer(typeof(XhtmlContainer))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)] // This makes it validate in Visual Studio (allegedly)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] // This makes it validate in Visual Studio (allegedly)
        public ITemplate FormExtraOptionsTemplate { get; set; }

        /// <summary>
        /// Gets or sets the footer template which appears after the form controls
        /// </summary>
        /// <value>The footer template.</value>
        [TemplateContainer(typeof(XhtmlContainer))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)] // This makes it validate in Visual Studio (allegedly)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] // This makes it validate in Visual Studio (allegedly)
        public ITemplate FormFooterTemplate { get; set; }

        /// <summary>
        /// Gets or sets the footer template which appears after everything in the initial subscription view. 
        /// </summary>
        /// <value>The header template.</value>
        [TemplateContainer(typeof(XhtmlContainer))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)] // This makes it validate in Visual Studio (allegedly)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] // This makes it validate in Visual Studio (allegedly)
        public ITemplate SubscribeFooterTemplate { get; set; }

        /// <summary>
        /// Gets or sets the header template which appears before everything in the confirmation view. 
        /// </summary>
        /// <value>The header template.</value>
        [TemplateContainer(typeof(XhtmlContainer))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)] // This makes it validate in Visual Studio (allegedly)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] // This makes it validate in Visual Studio (allegedly)
        public ITemplate ConfirmationHeaderTemplate { get; set; }

        /// <summary>
        /// Gets or sets the confirmation template which is displayed when an email address is submitted. Include a <see cref="System.Web.UI.WebControls.Literal"/> with <c>ID</c> set to <c>"ConfirmationServiceName"</c> to display the value of <see cref="SubscriptionService.Name"/>.
        /// </summary>
        /// <value>The confirmation template.</value>
        [TemplateContainer(typeof(XhtmlContainer))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)] // This makes it validate in Visual Studio (allegedly)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] // This makes it validate in Visual Studio (allegedly)
        public ITemplate ConfirmationTemplate { get; set; }

        /// <summary>
        /// Gets or sets the footer template which appears after everything in the confirmation view. 
        /// </summary>
        /// <value>The header template.</value>
        [TemplateContainer(typeof(XhtmlContainer))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)] // This makes it validate in Visual Studio (allegedly)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] // This makes it validate in Visual Studio (allegedly)
        public ITemplate ConfirmationFooterTemplate { get; set; }

        /// <summary>
        /// Gets or sets the header template which is displayed when no service is supplied.
        /// </summary>
        /// <value>The template.</value>
        [TemplateContainer(typeof(XhtmlContainer))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)] // This makes it validate in Visual Studio (allegedly)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] // This makes it validate in Visual Studio (allegedly)
        public ITemplate NotFoundHeaderTemplate { get; set; }

        /// <summary>
        /// Gets or sets the template which is displayed when no service is supplied.
        /// </summary>
        /// <value>The template.</value>
        [TemplateContainer(typeof(XhtmlContainer))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)] // This makes it validate in Visual Studio (allegedly)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] // This makes it validate in Visual Studio (allegedly)
        public ITemplate NotFoundTemplate { get; set; }

        /// <summary>
        /// Gets or sets the footer template which is displayed when no service is supplied.
        /// </summary>
        /// <value>The template.</value>
        [TemplateContainer(typeof(XhtmlContainer))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)] // This makes it validate in Visual Studio (allegedly)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)] // This makes it validate in Visual Studio (allegedly)
        public ITemplate NotFoundFooterTemplate { get; set; }

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
        /// Build the email address entry form
        /// </summary>
        protected override void CreateChildControls()
        {
            if (this.Service == null || this.Service.Id <= 0 || String.IsNullOrEmpty(this.Service.Name))
            {
                // Add header template
                if (NotFoundHeaderTemplate != null)
                {
                    XhtmlContainer header = new XhtmlContainer();
                    NotFoundHeaderTemplate.InstantiateIn(header);
                    this.Controls.Add(header);
                }

                // Add no service template
                if (NotFoundTemplate == null) NotFoundTemplate = new DefaultTemplate(this.Service, Resources.EmailSubscribeNoService);

                XhtmlContainer template = new XhtmlContainer();
                NotFoundTemplate.InstantiateIn(template);
                this.Controls.Add(template);

                // Add footer template
                if (NotFoundFooterTemplate != null)
                {
                    XhtmlContainer footer = new XhtmlContainer();
                    NotFoundFooterTemplate.InstantiateIn(footer);
                    this.Controls.Add(footer);
                }
            }
            else
            {
                bool IsNewSubscription = true;

                // Get activation code from querystring
                string subscriptionCode = this.Context.Request.QueryString[this.CodeParameter];
                // Did we find a valid subscription code?
                if (!string.IsNullOrEmpty(subscriptionCode))
                {
                    // This is a change of an existing subscription.
                    IsNewSubscription = false;
                }

                // Add header template
                if (SubscribeHeaderTemplate != null)
                {
                    XhtmlContainer header = new XhtmlContainer();
                    SubscribeHeaderTemplate.InstantiateIn(header);
                    this.Controls.Add(header);
                }

                // Add intro template
                if (IntroTemplate == null)
                {
                    if (IsNewSubscription)
                    {
                        IntroTemplate = new DefaultTemplate(this.Service, Resources.EmailSubscribeIntro);
                    }
                    else
                    {
                        IntroTemplate = new DefaultTemplate(this.Service, Resources.SubscriptionOptionsUpdateIntro);
                    }
                }

                XhtmlContainer intro = new XhtmlContainer();
                IntroTemplate.InstantiateIn(intro);
                this.Controls.Add(intro);

                // If the intro contains a Literal with the id "serviceName", replace it with the current service name
                Literal serviceName = intro.FindControl("IntroServiceName") as Literal;
                if (serviceName != null) serviceName.Text = Service.Name;

                // validation messages - added in at this point to work around a .NET bug
                this.Controls.Add(new EsccValidationSummary());

                // Add form header template
                if (FormHeaderTemplate != null)
                {
                    XhtmlContainer header = new XhtmlContainer();
                    FormHeaderTemplate.InstantiateIn(header);
                    this.Controls.Add(header);
                }

                if (IsNewSubscription)
                {
                    // Display controls suitable for a new subscription.

                    // email box
                    this.email = new TextBox();
                    this.email.MaxLength = 255; // e-GIF
                    this.email.ID = "sub1"; // don't call the box "email", spammers look for that
                    this.email.CssClass = "email";

                    FormPart emailPart = new FormPart(Resources.EmailEntryPrompt, this.email);
                    emailPart.Required = true;
                    this.Controls.Add(emailPart);

                    // Confirm email box
                    this.confirmEmail = new TextBox();
                    this.confirmEmail.MaxLength = 255; // e-GIF
                    this.confirmEmail.ID = "sub2";
                    this.confirmEmail.CssClass = "email";

                    FormPart confirmPart = new FormPart(Resources.EmailConfirmEntryPrompt, this.confirmEmail);
                    confirmPart.Required = true;
                    this.Controls.Add(confirmPart);

                    // validate email
                    EsccRequiredFieldValidator vrEmail = new EsccRequiredFieldValidator(this.email.ID, Resources.EmailRequiredError);
                    this.Controls.Add(vrEmail);

                    EmailValidator vrxEmail = new EmailValidator(this.email.ID, Resources.EmailInvalidError);
                    this.Controls.Add(vrxEmail);

                    // validate confirmation of email - no need for an EmailValidator because it must match the one above
                    EsccRequiredFieldValidator vrConfirm = new EsccRequiredFieldValidator(this.confirmEmail.ID, Resources.EmailConfirmRequiredError);
                    this.Controls.Add(vrConfirm);

                    EsccCustomValidator vMatchConfirm = new EsccCustomValidator(this.confirmEmail.ID, Resources.EmailConfirmMismatchError);
                    vMatchConfirm.ServerValidate += new ServerValidateEventHandler(vMatchConfirm_ServerValidate);
                    this.Controls.Add(vMatchConfirm);

                    // validate that email is not already subscribed to this service
                    EsccCustomValidator vSubscriptionExists = new EsccCustomValidator(this.confirmEmail.ID, Resources.EmailAlreadySubscribed);
                    vSubscriptionExists.ServerValidate += new ServerValidateEventHandler(vSubscriptionExists_ServerValidate);
                    this.Controls.Add(vSubscriptionExists);
                }
                else
                {
                    // Display controls suitable for a subscription update.

                    // Add the subscription email address as information feedback.
                    this.emailReadOnly = new Label();
                    this.emailReadOnly.ID = "sub3"; // don't call the box "email", spammers look for that
                    this.emailReadOnly.Text = this.GetEmailAddressForExistingSubscription(new Guid(subscriptionCode));

                    FormPart emailPart = new FormPart(Properties.Resources.EmailEntryPrompt, this.emailReadOnly);
                    this.Controls.Add(emailPart);
                }

                // Add extra options template
                if (FormExtraOptionsTemplate != null)
                {
                    XhtmlContainer extraOptions = new XhtmlContainer();
                    FormExtraOptionsTemplate.InstantiateIn(extraOptions);
                    this.Controls.Add(extraOptions);
                }

                // Add form footer template
                if (FormFooterTemplate != null)
                {
                    XhtmlContainer footer = new XhtmlContainer();
                    FormFooterTemplate.InstantiateIn(footer);
                    this.Controls.Add(footer);
                }

                // Submit button
                EsccButton submitButton = new EsccButton();
                submitButton.Text = Resources.SubscribeButtonText;
                submitButton.CssClass = "button";
                submitButton.Click += new EventHandler(submitButton_Click);

                // Update button
                EsccButton updateButton = new EsccButton();
                updateButton.Text = Resources.SubscriptionOptionsUpdateButtonText;
                updateButton.CssClass = "button buttonBigger";
                updateButton.Click += new EventHandler(updateButton_Click);

                FormButtons buttons = new FormButtons();
                if (IsNewSubscription) buttons.Controls.Add(submitButton); else buttons.Controls.Add(updateButton);
                this.Controls.Add(buttons);

                // Add footer template
                if (SubscribeFooterTemplate != null)
                {
                    XhtmlContainer footer = new XhtmlContainer();
                    SubscribeFooterTemplate.InstantiateIn(footer);
                    this.Controls.Add(footer);
                }
            }
        }

        /// <summary>
        /// An inheriting class can supply the subscription email address from the database.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetEmailAddressForExistingSubscription(Guid subscriptionCode)
        {
            return null;
        }


        /// <summary>
        /// Handles the ServerValidate event of the vSubscriptionExists control.
        /// </summary>
        /// <param name="source">The source of the event.</param>
        /// <param name="args">The <see cref="System.Web.UI.WebControls.ServerValidateEventArgs"/> instance containing the event data.</param>
        void vSubscriptionExists_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Calling app is supposed to hook up to this and set e.Success = false if an existing subscription is found
            this.OnCheckingExistingSubscription();
            args.IsValid = this.eventArgs.Success;
        }

        /// <summary>
        /// Check that both entered email addresses match
        /// </summary>
        /// <param name="source">Textbox to validate</param>
        /// <param name="args">Validation arguments</param>
        private void vMatchConfirm_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Note that this is not a RequiredFieldValidator, so return true if either one of the boxes is empty.
            // Otherwise the RequiredFieldValidator would throw up another message for the same problem.
            if (this.email.Text.Length > 0 && this.confirmEmail.Text.Length > 0 && this.email.Text != this.confirmEmail.Text)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }

        #region Events

        /// <summary>
        /// Event indicating that an email address to subscribe to the service has been submitted
        /// </summary>
        public event EventHandler<SubscriptionEventArgs> EmailAddressSubmitted;

        /// <summary>
        /// Event raised to allow consumer to check for an existing subscription. Set <c>e.Success = false</c> if an existing subscription is found.
        /// </summary>
        public event EventHandler<SubscriptionEventArgs> CheckingExistingSubscription;

        /// <summary>
        /// Event indicating that a change to the subscription options has been submitted
        /// </summary>
        public event EventHandler<SubscriptionEventArgs> SubscriptionOptionsUpdated;

        /// <summary>
        /// Raise an event indicating that an email address to subscribe to the service has been submitted
        /// </summary>
        protected virtual void OnEmailAddressSubmitted()
        {
            // Get the form email address either as the newly submitted one (via TextBox control) or as the read-only version (via Label control).
            string emailAddress = null;
            try { emailAddress = this.email.Text; }
            catch { }
            if (string.IsNullOrEmpty(emailAddress) && this.emailReadOnly != null) emailAddress = this.emailReadOnly.Text;

            if (this.EmailAddressSubmitted != null)
            {
                this.eventArgs = new SubscriptionEventArgs();
                this.eventArgs.Service = this.Service;
                this.eventArgs.EmailAddress = new ContactEmail(emailAddress);
                this.EmailAddressSubmitted(this, this.eventArgs);
            }
        }

        /// <summary>
        /// Raise an to allow consumer to check for an existing subscription. Set <c>e.Success = false</c> if an existing subscription is found.
        /// </summary>
        protected virtual void OnCheckingExistingSubscription()
        {
            // Get the form email address either as the newly submitted one (via TextBox control) or as the read-only version (via Label control).
            string emailAddress = null;
            try { emailAddress = this.email.Text; }
            catch { }
            if (string.IsNullOrEmpty(emailAddress) && this.emailReadOnly != null) emailAddress = this.emailReadOnly.Text;

            if (this.CheckingExistingSubscription != null)
            {
                this.eventArgs = new SubscriptionEventArgs();
                this.eventArgs.Service = this.Service;
                this.eventArgs.EmailAddress = new ContactEmail(emailAddress);
                this.CheckingExistingSubscription(this, this.eventArgs);
            }
        }

        /// <summary>
        /// Raise an event indicating that a change to the subscription options has been submitted
        /// </summary>
        protected virtual void OnSubscriptionOptionsUpdated()
        {
            // Get the form email address either as the newly submitted one (via TextBox control) or as the read-only version (via Label control).
            string emailAddress = null;
            try { emailAddress = this.email.Text; }
            catch { }
            if (string.IsNullOrEmpty(emailAddress) && this.emailReadOnly != null) emailAddress = this.emailReadOnly.Text;

            if (this.SubscriptionOptionsUpdated != null)
            {
                this.eventArgs = new SubscriptionEventArgs();
                this.eventArgs.Service = this.Service;
                this.eventArgs.EmailAddress = new ContactEmail(emailAddress);
                this.eventArgs.SubscriptionCode = this.Context.Request.QueryString[this.CodeParameter];
                this.SubscriptionOptionsUpdated(this, this.eventArgs);
            }
        }

        #endregion

        #region Event handlers

        /// <summary>
        /// Event handler for when form is submitted
        /// </summary>
        /// <param name="sender">The submit button</param>
        /// <param name="e">The submit button's click coordinates</param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                this.OnEmailAddressSubmitted();
            }
        }

        /// <summary>
        /// Event handler for when the form is submitted with an update
        /// </summary>
        /// <param name="sender">The update button</param>
        /// <param name="e">The update button's click coordinates</param>
        private void updateButton_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                this.OnSubscriptionOptionsUpdated();
            }
        }

        /// <summary>
        /// When a subscription has been saved into the database, show a message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowConfirmationMessage_EmailAddressSubmitted(object sender, EventArgs e)
        {
            this.ShowConfirmationMessage(Resources.EmailSubscribeConfirmation);
        }

        /// <summary>
        /// When subscription options have been updated in the database, show a message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowConfirmationMessage_SubscriptionOptionsUpdated(object sender, EventArgs e)
        {
            this.ShowConfirmationMessage(Resources.SubscriptionOptionsUpdatedConfirmation);
        }

        /// <summary>
        /// Clears the current page display and replaces it with an xhtml message.
        /// </summary>
        private void ShowConfirmationMessage(string confirmationXHtml)
        {
            this.EnsureChildControls();
            this.Controls.Clear();

            // Add header template
            if (ConfirmationHeaderTemplate != null)
            {
                XhtmlContainer header = new XhtmlContainer();
                ConfirmationHeaderTemplate.InstantiateIn(header);
                this.Controls.Add(header);
            }

            // Add content template
            if (ConfirmationTemplate == null) ConfirmationTemplate = new DefaultTemplate(this.Service, confirmationXHtml);

            XhtmlContainer confirmation = new XhtmlContainer();
            ConfirmationTemplate.InstantiateIn(confirmation);
            this.Controls.Add(confirmation);

            // If the confirmation contains a Literal with the id "serviceName", replace it with the current service name
            Literal serviceName = confirmation.FindControl("ConfirmationServiceName") as Literal;
            if (serviceName != null) serviceName.Text = Service.Name;

            // Add footer template
            if (ConfirmationFooterTemplate != null)
            {
                XhtmlContainer footer = new XhtmlContainer();
                ConfirmationFooterTemplate.InstantiateIn(footer);
                this.Controls.Add(footer);
            }
        }

        #endregion

    }
}
