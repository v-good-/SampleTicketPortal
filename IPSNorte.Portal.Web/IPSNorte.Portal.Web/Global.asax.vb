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

        'TODO remove this sample data...
        InitializeSampleData().Wait()

    End Sub

    Private Async Function InitializeSampleData() As Task

        Dim user As ApplicationUser = Await LoadUser()

        LoadTickets(user)
        LoadAlerts(user)
        LoadEvents()

    End Function

    Private Async Function LoadUser() As Task(Of ApplicationUser)

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
        Return user
    End Function

    Private Shared Sub LoadAlerts(user As ApplicationUser)

        Dim alertServiceClient = New AlertServiceClient()

        For i As Integer = 0 To 10
            Dim alert As Alert = New Alert
            alert.AlertDate = DateTime.Today.AddDays(-i)
            alert.Description = String.Format("{0} - Donec interdum eros et risus hendrerit luctus. Nulla a mollis nulla. Integer imperdiet iaculis mi eget consectetur. Sed ligula turpis, tincidunt id velit vitae, viverra suscipit dui. Aliquam eleifend faucibus lacus non molestie. Aenean metus purus, accumsan eu dui id, tempor fringilla lorem. Vestibulum dignissim, ante a gravida maximus, orci augue ultricies nisi, et tempor lectus ligula vel erat.", i)
            alert.ProjectNumber = user.ProjectNumber

            alertServiceClient.CreateAlert(alert)

        Next (i)

    End Sub

    Private Shared Sub LoadEvents()

        Dim eventServiceClient = New EventServiceClient()

        For i As Integer = 0 To 10
            Dim theEvent = New CustomEvent()

            theEvent.EventDate = DateTime.Today.AddDays(-i)
            theEvent.Description = String.Format("{0} - Donec arcu leo, tempor ac risus nec, auctor suscipit mi. Vivamus metus felis, pellentesque eu elementum quis, tristique vitae lacus. Proin laoreet lorem vitae elit tempor, dictum tincidunt tellus ultrices. Suspendisse mattis metus ut enim venenatis, aliquam tempus enim mollis. Aliquam metus dolor, suscipit vel justo vel, sollicitudin faucibus nulla. Quisque vel augue mauris. Phasellus non orci vitae arcu commodo rutrum ac eget justo. Curabitur aliquam at lacus vitae venenatis.", i)
            theEvent.Title = String.Format("Event title {0}", i)
            theEvent.Id = Guid.NewGuid().ToString()

            eventServiceClient.CreateEvent(theEvent)

        Next (i)

    End Sub
    
    Private Shared Sub LoadTickets(ByVal user As ApplicationUser)

        Dim ticketServiceClient = New TicketServiceClient()

        For i As Integer = 0 To 1200

            Dim ticket As Ticket = New Ticket()
            ticket.CreatedDate = Now.AddMinutes(-i * 3)
            ticket.CreatedBy = user.ToServiceUser()
            ticket.Description = "Sample ticket " + i.ToString() + " " + WeekdayName(Weekday(DateTime.Now.AddDays(CInt(Math.Ceiling(Rnd() * 7)))))
            ticket.Priority = CType(CInt(Math.Ceiling(Rnd() * 3)), TicketPriorityEnum)
            ticket.ProjectNumber = CInt(Math.Ceiling(Rnd() * 100))
            ticket.Status = CType(CInt(Math.Ceiling(Rnd() * 2)), TicketStatusEnum)
            ticket.Number = i
            ticket.Entries = New List(Of TicketEntry)()

            For ii As Integer = 0 To 10
                ticket.Entries.Add(New TicketEntry() With {
                                   .Comment = "I don't thinks this is working as expected.. blah blah...",
                                   .CreatedBy = user.ToServiceUser(),
                                   .CreatedDate = DateTime.Now})
            Next (ii)

            ticketServiceClient.CreateTicket(ticket)

        Next (i)

    End Sub

End Class
