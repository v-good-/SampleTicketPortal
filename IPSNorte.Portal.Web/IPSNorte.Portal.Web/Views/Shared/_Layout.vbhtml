@Imports IPSNorte.Portal.Web.Web.Resources
@Imports IPSNorte.Portal.Lib

@Code
    

    Dim appName = ApplicationName

    If (Not IsNothing(Request.QueryString("app"))) Then
        appName = Request.QueryString("app")

    End If

    End Code

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - @appName</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
    @Scripts.Render("~/bundles/jqgrid")
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/flot")

    @Html.Partial("~/Views/Shared/_GA.vbhtml")


    @Code

        Dim currentLanguage = Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLower()

        If (currentLanguage.StartsWith("en")) Then
        @<text>
            <script src="~/Scripts/resources/resources-EN.js"></script></text>
        ElseIf (currentLanguage.StartsWith("es")) Then
        @<text>
            <script src="~/Scripts/resources/resources-ES.js"></script></text>
        End If

    End Code
</head>
<body>
    @Code
        Dim userServiceClient = New UserServiceClient()
        Dim user = userServiceClient.FindByName(Me.User.Identity.Name)
        
        If Not user.AcceptCookies Then
            @Html.Partial("_CookieWarning")
        End If
    End Code

<div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink(appName, "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>@Html.ActionLink("Home", "Index", "Home")</li>
                    <li>@Html.ActionLink("About", "About", "Home")</li>
                    <li>@Html.ActionLink("Contact", "Contact", "Home")</li>
                    <li>@Html.ActionLink("Download", "Download", "Home")</li>
 </ul>
                @Html.Partial("_LoginPartial")
            </div>
        </div>
    </div>
    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - IPSNorte</p>
        </footer>
    </div>


</body>
</html>
