@ModelType LoginViewModel

@Code
    ViewBag.Title = "Log in"
    Layout = "~/Views/Shared/_LayoutNotLoggedIn.vbhtml"

End Code

<br />
<br />

<div class="row">

    <div class="col-md-12">
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
                            @Html.ActionLink("Register as a new user", "Register", Nothing, New With {.onmousedown = "_gaq.push(['_trackEvent', 'Login', 'Register', 'User going to registration page']);"})
                        </div>
                    </div>

                    @* Enable this once you have account confirmation enabled for password reset functionality*@
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            @Html.ActionLink("Forgot your password?", "ForgotPassword", Nothing, New With {.onmousedown = "_gaq.push(['_trackEvent', 'Login', 'ForgotPassword', 'User requested password recovery']);"})
                        </div>
                    </div>

                </text>
            End Using
        </section>
    </div>

</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
