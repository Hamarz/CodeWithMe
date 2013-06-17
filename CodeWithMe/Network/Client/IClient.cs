using System;
using System.Net.Sockets;
using System.Collections.Generic;

namespace CodeWithMe
{
    public class IClient
    {
        /// <summary>
        /// Clients that are currently connected
        /// </summary>
        public static List<Socket> clients = new List<Socket>();
    }
}
