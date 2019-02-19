using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;


namespace Program{

    class Server{
        private Socket ListenSocket = null;
        private bool SocketEnd = false;

        public Server(){
            ListenSocket = null;
        }

        public void Strat_Server(){
            ListenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream , ProtocolType.Tcp);
            int Port = 9998;
            ListenSocket.Bind(new IPEndPoint(IPAddress.Any , Port));

            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAD = Dns.GetHostEntry("localhost").AddressList[0];

            Console.WriteLine("Server Start (Port Number : {0}", Port);
            Console.WriteLine("Computer Name : {0} {1}", host , ipAD);

            ListenSocket.Listen(100);

            while(SocketEnd == false){
                Socket ClientSocket = (Socket)ListenSocket.Accept();
                Console.WriteLine("Client Connect IP Address : {0}", ClientSocket.RemoteEndPoint);

            }

        }
            static void Main(string[] args){
                Server ChServer = new Server();
                ChServer.Strat_Server();
            }
    }
}