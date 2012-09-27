http://www.codeplex.com/antiCSRF

AntiCSRF makes it easier for ASP.NET developers to guard themselves against Cross Site Request Forgery. 
You'll no longer have to manually add and check protection tokens.

AntiCSRF developed in C#.

Notes
=====
The normal recommended way of adding a CSRF token to an ASP.NET application is to use ViewState in combination with a ViewStateUserKey. This
requires ViewState to be enabled and an application to have some way of identifying a user uniquely, usually via a SessionID which in turn
requires session state to be enabled. AntiCSRF does not have these requirements; instead if requires cookies to be enabled on the user's browser
and uses a temporary cookie, cleared when the browser is closed, to identify a user and a hidden form field to carry the CSRF token.

The ViewStateUserKey approach protects against One-Click Attacks. One-Click Attack is sometimes incorrectly referred to as 
Microsoft's name for Cross-Site Request Forgery. However, this is not entirely correct. One-Click Attacks refer to a subset of CSRF attacks -
one that use a malicious ViewState to perform the request. Because web forms developed with ASP.NET use ViewState for post-backs, 
an attacker can perform the post-back they want the user to perform unknowingly, and record the ViewState. Due to the way that ASP.NET 
ignores HTTP verbs when using Request.Params versus Request.Form, and in web controls, this request can often be made via GET. For more
details please see http://keepitlocked.net/archive/2008/05/29/viewstateuserkey-doesn-t-prevent-cross-site-request-forgery.aspx


Usage instructions
==================
    * Add a reference to the AntiCSS project or DLL, or copy the DLL to your web applications BIN folder.
    * Add a reference to the module into your web.config;
          o For IIS6/IIS7 in Classic ASP.NET mode
            <system.web>
                ....
                <httpModules>            
                    <add name="AntiCSRF" type="Idunno.AntiCsrf.AntiCsrfModule, Idunno.AntiCsrf"/>
                </httpModules>
                ....
                </system.web>                
          o For IIS7 in integrated pipeline mode
              <system.webmodules>
                  ....
                  <modules>
                      <add name="AntiCSRF" type="Idunno.AntiCsrf.AntiCsrfModule, Idunno.AntiCsrf"/>
                  </modules>
                  ....
              </system.webmodules>
    * Optout any pages you do not want protected by adding the Idunno.AntiCsrf.SuppressCsrfCheck attribute to their declarations, for example
      [Idunno.AntiCsrf.SuppressCsrfCheck]
      public partial class unprotectedPage : System.Web.UI.Page  

Configuration
=============
The module supports configuration via web.config. In order to utilise the configuration options you must first add a custom configuration 
section to your web.config

<configuration>
    ....
    <configSections>
        ....
        <section name="csrfSettings"  type="Idunno.AntiCsrf.Configuration.CsrfSettings, Idunno.AntiCsrf" />   
        ....
    </configSections>
</configuration>

Then create a configuration section in your web.config

<configuration>
    ....
    <csrfSettings cookieName="__CSRFCOOKIE" formFieldName="__CSRFTOKEN" detectionResult="RaiseException" errorPage="" />
    ....    
</configuration>

The configuration options are as follows

Name 	        Purpose
--------------------------------------------------------------------------------------------------------------------
cookieName 	    specifies the name of the cookie used to hold the anti-CSRF token. This defaults to __CSRFCOOKIE.
formfieldName 	specifies the name of the form field used to hold the anti-CSRF token This defatults to __CSRFTOKEN.
detectionResult this may be either RaiseException, which throws exceptions on a potential CSRF attack 
                or Redirect which will redirect to the URL specified in the errorPage setting. 
                You must set a URL in the errorPage setting if you choose Redirect. This defaults to RaiseException.
errorPage       a page name to redirect to if the detectionResult is set to Redirect. 

Limitations
    * You, the developer, must ensure your GET requests are idempotent (i.e. they do not cause state changes within your application). 
      GET requests are not protected with this module. See http://www.w3.org/Protocols/rfc2616/rfc2616-sec9.html#sec9.1.2 which specifies 
      that the GET and HEAD HTTP methods SHOULD NOT have the significance of taking an action other than retrieval.
    * Non-ASP.NET forms are not protected with this module.

Disclaimer
    * This software is provided "as-is". You bear the risk of using it. The contributors give no express warranties, guarantees or conditions.
      Like any security software this should become part of your defence in depth strategy and should not be solely relied upon for protection.
