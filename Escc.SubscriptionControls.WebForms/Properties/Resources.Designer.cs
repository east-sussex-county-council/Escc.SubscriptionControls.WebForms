﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Escc.SubscriptionControls.WebForms.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Escc.SubscriptionControls.WebForms.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thank you for subscribing to &quot;{ServiceName}&quot;.
        ///
        ///Your subscription is not yet active. During the subscription process, we 
        ///explained that we would ask you to confirm your subscription. 
        ///
        ///To do this, click on the link below or paste it into your browser&apos;s
        ///address bar.
        ///
        ///{Activation URL}
        ///
        ///By confirming your subscription, you are agreeing to receive email
        ///from East Sussex County Council at the following email address: 
        ///
        ///{Email address}
        ///
        ///If you did not subscribe to {ServiceName}, 
        ///please ignore thi [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ActivationEmailBody {
            get {
                return ResourceManager.GetString("ActivationEmailBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Confirm subscription to {0}.
        /// </summary>
        internal static string ActivationEmailSubject {
            get {
                return ResourceManager.GetString("ActivationEmailSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;p&gt;Unfortunately it was not possible to activate your subscription.&lt;/p&gt;.
        /// </summary>
        internal static string EmailActivationFailure {
            get {
                return ResourceManager.GetString("EmailActivationFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;p&gt;Thank you for subscribing to {ServiceName}. Your subscription is now active.&lt;/p&gt;.
        /// </summary>
        internal static string EmailActivationSuccess {
            get {
                return ResourceManager.GetString("EmailActivationSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have already subscribed to this service.
        /// </summary>
        internal static string EmailAlreadySubscribed {
            get {
                return ResourceManager.GetString("EmailAlreadySubscribed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Confirm email.
        /// </summary>
        internal static string EmailConfirmEntryPrompt {
            get {
                return ResourceManager.GetString("EmailConfirmEntryPrompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your email addresses do not match.
        /// </summary>
        internal static string EmailConfirmMismatchError {
            get {
                return ResourceManager.GetString("EmailConfirmMismatchError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please confirm your email address.
        /// </summary>
        internal static string EmailConfirmRequiredError {
            get {
                return ResourceManager.GetString("EmailConfirmRequiredError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;p&gt;Unfortunately it was not possible to cancel your subscription.&lt;/p&gt;.
        /// </summary>
        internal static string EmailDeactivationFailure {
            get {
                return ResourceManager.GetString("EmailDeactivationFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;p&gt;Your subscription to {ServiceName} has been cancelled.&lt;/p&gt;.
        /// </summary>
        internal static string EmailDeactivationSuccess {
            get {
                return ResourceManager.GetString("EmailDeactivationSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email.
        /// </summary>
        internal static string EmailEntryPrompt {
            get {
                return ResourceManager.GetString("EmailEntryPrompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter a valid email address.
        /// </summary>
        internal static string EmailInvalidError {
            get {
                return ResourceManager.GetString("EmailInvalidError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please enter your email address.
        /// </summary>
        internal static string EmailRequiredError {
            get {
                return ResourceManager.GetString("EmailRequiredError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;p&gt;Thank you for subscribing to {ServiceName}.&lt;/p&gt; 
        ///    
        ///&lt;p&gt;&lt;strong&gt;Your subscription is not yet active.&lt;/strong&gt;&lt;/p&gt;
        ///        
        ///&lt;p&gt;We have sent you an email containing a link back to this site. To confirm 
        ///your subscription, please look at your email and click on the link we have sent.&lt;/p&gt;.
        /// </summary>
        internal static string EmailSubscribeConfirmation {
            get {
                return ResourceManager.GetString("EmailSubscribeConfirmation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;p&gt;Enter your email address below to subscribe to {ServiceName}.&lt;/p&gt;.
        /// </summary>
        internal static string EmailSubscribeIntro {
            get {
                return ResourceManager.GetString("EmailSubscribeIntro", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;p&gt;Nothing was found to subscribe to.&lt;/p&gt;
        ///
        ///&lt;p&gt;Please check that you have typed the address of the page correctly, or let us know if you followed a link that doesn&apos;t work.&lt;/p&gt;.
        /// </summary>
        internal static string EmailSubscribeNoService {
            get {
                return ResourceManager.GetString("EmailSubscribeNoService", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Subscribe.
        /// </summary>
        internal static string SubscribeButtonText {
            get {
                return ResourceManager.GetString("SubscribeButtonText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Change subscriptions choices.
        /// </summary>
        internal static string SubscriptionOptionsUpdateButtonText {
            get {
                return ResourceManager.GetString("SubscriptionOptionsUpdateButtonText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;p&gt;Your subscription options to {ServiceName} have been successfully updated.&lt;/p&gt;.
        /// </summary>
        internal static string SubscriptionOptionsUpdatedConfirmation {
            get {
                return ResourceManager.GetString("SubscriptionOptionsUpdatedConfirmation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;p&gt;Here is the email address you have used to subscribe to {ServiceName}&lt;/p&gt;.
        /// </summary>
        internal static string SubscriptionOptionsUpdateIntro {
            get {
                return ResourceManager.GetString("SubscriptionOptionsUpdateIntro", resourceCulture);
            }
        }
    }
}
