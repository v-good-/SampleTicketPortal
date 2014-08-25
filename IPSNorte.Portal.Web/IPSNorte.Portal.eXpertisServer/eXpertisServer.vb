Imports System.Runtime.Remoting.Channels
Imports System.Configuration
Imports IPSNorte.Portal.eXpertisObjects
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels.Tcp
Imports IPSNorte.Portal.eXpertisObjects.Services

Module eXpertisServer


    Sub Main()

        Console.WriteLine("{0} - Starting .net remoting server", DateTime.Now.ToShortTimeString())

        RemotingConfiguration.Configure("IPSNorte.Portal.eXpertisServer.exe.config", False)
        Console.WriteLine("{0} - Registered Ticket service as IPSNorte.Portal.UserService", DateTime.Now.ToShortTimeString())
        Console.WriteLine("{0} - Registered Ticket service as IPSNorte.Portal.TicketService", DateTime.Now.ToShortTimeString())

        Console.WriteLine("")
        Console.WriteLine("")

        Console.WriteLine("{0} Listening...hit enter to stop server.", DateTime.Now.ToShortTimeString())
        Console.ReadLine()
    End Sub

End Module
