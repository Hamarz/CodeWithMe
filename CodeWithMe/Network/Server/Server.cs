using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CodeWithMe
{
    public class Server
    {
        #region Variables
        /* Client Username */
        public string username;
        /* Client Socket */
        public Socket client;
        /* Byte Buffer */
        private byte[] buffer = new byte[1024];
        #endregion

        public void OnConnect()
        {
            MainForm.mainForm.EnableComponents(false, true);
            // Add client to the list
            IClient.clients.Add(client);

            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, Receive, null);
        }

        #region Receive / Send
        public void Receive(IAsyncResult ar)
        {
            try
            {
                string receiveStr = String.Empty;

                var bytesReceived = client.EndReceive(ar);
                if (bytesReceived > 0)
                {
                    receiveStr = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                    // Handle Packet data
                    PacketHandler.HandleData(receiveStr, this);

                    client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, Receive, null);
                }
                else // Client disconnected?
                    IClient.clients.Remove(client);
            }
            catch (Exception ex)
            {
                MainForm.mainForm.WriteLog("Failed to receive data " + ex.Message);
                client.Close();
            }
        }
        /// <summary>
        /// Sends data to a client
        /// </summary>
        /// <param name="val"></param>
        public void Send(string val)
        {
            try
            {
                byte[] newBytes = System.Text.Encoding.ASCII.GetBytes(val);
                client.Send(newBytes, 0, newBytes.Length, SocketFlags.None);
            }
            catch (Exception ex)
            {
                MainForm.mainForm.WriteLog("Failed to send data " + ex.Message);
                client.Close();
            }
        }
        /// <summary>
        /// Sends data to all connected clients
        /// </summary>
        /// <param name="val"></param>
        public void SendToAll(string val)
        {
            try
            {
                byte[] newBytes = System.Text.Encoding.ASCII.GetBytes(val);
                foreach (Socket clients in IClient.clients)
                {
                    if (clients != null)
                        client.Send(newBytes, 0, newBytes.Length, SocketFlags.None);
                }
            }
            catch (Exception ex)
            {
                MainForm.mainForm.WriteLog("Failed to send data " + ex.Message);
                client.Close();
            }
        }
        #endregion
    }
}
