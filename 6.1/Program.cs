using System;

namespace _6._1
{
    class MainApp
    {
        public static void Main()
        {
            CallSystem callsystem = new CallSystem(); // Facade
            callsystem.CallLocal();
            callsystem.CallRemote();
            // Wait for user 
            Console.Read();
        }
    }

    // "Subsystem ClassA" 
    class LocalNetwork
    {
        public void CheckAvailableConnections()
        {
            Console.WriteLine("Connections found");
        }
    }

    // Subsystem ClassB" 
    class GlobalNetwork
    {
        public void EstablishConnection()
        {
            Console.WriteLine("Connection established");
        }
    }


    // Subsystem ClassC" 
    class Server
    {
        public void SendRequest()
        {
            Console.WriteLine("Request sent");
        }
    }
    // Subsystem ClassD" 
    class LocalUser
    {
        public void Connect()
        {
            Console.WriteLine("Connection succesfull");
        }
    }
    // "Facade" 
    class CallSystem
    {
        LocalNetwork localNetwork;
        GlobalNetwork globalNetwork;
        Server server;
        LocalUser localUser;

        public CallSystem()
        {
            localNetwork = new LocalNetwork();
            globalNetwork = new GlobalNetwork();
            server = new Server();
            localUser = new LocalUser();
        }

        public void CallLocal()
        {
            Console.WriteLine("Local call: ");
            localNetwork.CheckAvailableConnections();
            localUser.Connect();
        }

        public void CallRemote()
        {
            Console.WriteLine("Remote call: ");
            globalNetwork.EstablishConnection();
            server.SendRequest();
        }
    }
}
