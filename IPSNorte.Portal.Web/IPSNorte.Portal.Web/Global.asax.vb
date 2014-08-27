Imports System.Web.Http
Imports System.Web.Optimization
Imports System.Runtime.Remoting
Imports System.Threading.Tasks
Imports IPSNorte.Portal.eXpertisObjects
Imports IPSNorte.Portal.Lib

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
               .ProjectNumber = 23,
               .PhoneNumber = 942889900,
               .PhoneNumber2 = 699599499
           }


        Dim userManager = New ApplicationUserManager(New CustomUserStore())
        Await userManager.CreateAsync(user, "ASDFasdf1.")

        LoadTickets(user)

    End Function

    Private Shared Sub LoadTickets(ByVal user As ApplicationUser)

        Dim ticketServiceClient = New TicketServiceClient()

        For i As Integer = 0 To 1200

            Dim ticket As Ticket = New Ticket()
            ticket.CreatedDate = Now.AddMinutes(-i * 3)
            ticket.CreatedBy = user.ToServiceUser()
            ticket.Id = System.Guid.NewGuid.ToString()
            ticket.Description = "Sample ticket " + i.ToString() + " " + WeekdayName(Weekday(DateTime.Now.AddDays(CInt(Math.Ceiling(Rnd() * 7)))))
            ticket.Priority = CType(CInt(Math.Ceiling(Rnd() * 3)), TicketPriorityEnum)
            ticket.ProjectNumber = CInt(Math.Ceiling(Rnd() * 100))
            ticket.Status = CType(CInt(Math.Ceiling(Rnd() * 2)), TicketStatusEnum)

            ticketServiceClient.CreateTicket(ticket)

        Next (i)

    End Sub

End Class
