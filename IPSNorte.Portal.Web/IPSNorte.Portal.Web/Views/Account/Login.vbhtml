@ModelType LoginViewModel
@Imports IPSNorte.Portal.Web.Web.Resources

@Code
    ViewBag.Title = "Log in"
    Layout = "~/Views/Shared/_LayoutNotLoggedIn.vbhtml"

End Code

<br />
<br />

<div class="row">
    <div class="col-md-7 text-center hideOnMediumOrBelow">
        <img src="~/Content/images/Tickets_page.jpg" style="width:100%" />
    </div>

    <script>
        $(function () {
            $("#tabs").tabs();
        });
    </script>

    <div class="col-md-5">

        <div id="tabs">
            <ul>
                <li><a href="#tabs-1">@LoginView_Login</a></li>
                <li><a href="#tabs-2">@LoginView_Register</a></li>
                <li><a href="#tabs-3">@LoginView_Contact</a></li>
            </ul>
            <div id="tabs-1">
                <h2>@LoginView_Login</h2>
                <section id="loginForm">
                    @Using Html.BeginForm("Login", "Account", New With {.ReturnUrl = ViewBag.ReturnUrl}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
                        @Html.AntiForgeryToken()
                        @<text>
                            @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                            <div class="form-group">
                                @Html.LabelFor(Function(m) m.Email, New With {.class = "col-md-2 control-label"})
                                <div class="col-md-10">
                                    @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger"})
                                </div>
                            </div>
                            <div class="form-group">
                                @Html.LabelFor(Function(m) m.Password, New With {.class = "col-md-2 control-label"})
                                <div class="col-md-10">
                                    @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-2"></div>
                                <div class=" col-md-10">
                                    <div class="">
                                        @Html.CheckBoxFor(Function(m) m.RememberMe)
                                        @Html.LabelFor(Function(m) m.RememberMe)
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <input type="submit" value="Log in" class="btn btn-default" onmousedown="_gaq.push(['_trackEvent', 'Login', 'Login', 'User logged in']);" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    @Html.ActionLink("Forgot your password?", "ForgotPassword", Nothing, New With {.onmousedown = "_gaq.push(['_trackEvent', 'Login', 'ForgotPassword', 'User requested password recovery']);"})
                                </div>
                            </div>

                        </text>
                    End Using
                </section>
            </div>
            <div id="tabs-2">
                @Html.Partial("_Register", New RegisterViewModel())
              </div>
            <div id="tabs-3">
                <h2> IPSNorte</h2>
                <address>
                   
                    Parque Tecnológico de Cantabria <br />
                    Edificio 3000 <br />
                    C/Isabel Torres, 11ª, 1ª Planta<br />
                    39011 - Santander (Cantabria).<br />
                    <abbr title="Phone">P:</abbr>
                    942.26.00.15
                </address>

                <address>
                    <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
                    <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
                </address>
 </div>
        </div>


    </div>

</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
