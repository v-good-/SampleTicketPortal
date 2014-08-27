@ModelType RegisterViewModel

@Imports IPSNorte.Portal.Web.Web.Resources
@Imports CaptchaMvc.HtmlHelpers

@Code
    ViewBag.Title = "Register"
    Layout = "~/Views/Shared/_LayoutNotLoggedIn.vbhtml"

End Code

<h2>@ViewBag.Title.</h2>

@Using Html.BeginForm("Register", "Account", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})

    @Html.AntiForgeryToken()

    @<text>
        <h4>Create a new account.</h4>
        <hr />
        @Html.ValidationSummary("", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.LabelFor(Function(m) m.Email, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.Password, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.ConfirmPassword, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.FirstName, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.FirstName, New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.LastName, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.LastName, New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.Phone1, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.Phone1, New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.Phone2, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.Phone2, New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.JobRole, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.JobRole, New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.ProjectNumber, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.ProjectNumber, New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.Company, New With {.class = "col-md-2 control-label"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.Company, New With {.class = "form-control"})
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <label for="captcha">@Html.Captcha(RegiterPage_CaptchaRefreshText,
                                                   RegiterPage_CaptchaInputText, 5,
                                                   RegiterPage_CaptchaRequiredText)</label><br />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" class="btn btn-default" value="Register" />
            </div>
        </div>
    </text>
End Using

@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
