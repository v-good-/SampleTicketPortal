Imports System.Web.Http
Imports System.Web.Optimization
Imports System.Runtime.Remoting
Imports System.Threading.Tasks

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        RemotingConfiguration.Configure(Server.MapPath("Web.config"), False)

        InitializeData().Wait()

    End Sub

    Private Async Function InitializeData() As Task
        Dim user = New ApplicationUser() With {
               .UserName = "test1@pasbridge.com",
               .Email = "test1@pasbridge.com",
               .FirstName = "John",
               .LastName = "Doe",
               .JobRole = "Director",
               .Company = "Pasbridge",
               .ProjectNumber = "2014/55435",
               .PhoneNumber = 942889900,
               .PhoneNumber2 = 699599499
           }


        Dim userManager = New ApplicationUserManager(New CustomUserStore())
        Await userManager.CreateAsync(user, "ASDFasdf1.")
    End Function

End Class
