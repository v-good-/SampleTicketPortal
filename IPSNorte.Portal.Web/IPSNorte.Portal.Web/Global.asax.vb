Imports System.Web.Http
Imports System.Web.Optimization
Imports System.Runtime.Remoting
Imports System.Threading.Tasks
Imports System.ComponentModel.DataAnnotations
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

        LoadAlerts(user)
        LoadEvents()

    End Function

    Private Shared Sub LoadAlerts(user As ApplicationUser)

        Dim alertServiceClient = New AlertServiceClient()

        For i As Integer = 0 To 10
            Dim alert As Alert = New Alert
            alert.AlertDate = DateTime.Today.AddDays(-i)
            alert.Description = String.Format("Alert number {0}", i)
            alert.ProjectNumber = user.ProjectNumber

            alertServiceClient.CreateAlert(alert)

        Next (i)

    End Sub

    Private Shared Sub LoadEvents()

        Dim eventServiceClient = New EventServiceClient()

        For i As Integer = 0 To 10
            Dim theEvent = New CustomEvent()

            theEvent.EventDate = DateTime.Today.AddDays(-i)
            theEvent.Description = String.Format("Event description for event {0}", i)
            theEvent.Title = String.Format("Event title {0}", i)

            eventServiceClient.CreateEvent(theEvent)

        Next (i)

    End Sub
    
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
