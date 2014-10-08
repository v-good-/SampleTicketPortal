@Imports IPSNorte.Portal.Web.Web.Resources

<div id="cookieWarning" class="alert-info">

   @Html.Raw(String.Format(CookieWarningView_Message, String.Format("<a href='http://ipsnorte.com/contacto.php'>{0}</a>", CookieWarningView_PrivacyPolicy)))

    
        
        @Html.ActionLink(CookieWarningView_Accept, "AcceptCookies", "Home", Nothing, New With {.class = "btn btn-default"})

</div>
