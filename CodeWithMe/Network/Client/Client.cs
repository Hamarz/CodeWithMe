using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace CodeWithMe
{
    public class Client
    {
        #region Variables
        /* Buffer */
        public byte[] buffer = new byte[1024];
        /* Socket Client */
        public Socket client;
        /* Client's Name */
        public string username;
        #endregion

        #region Initial Connect/Disconnect
        public bool Connect(string host, int port)
        {
            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.BeginConnect(host, port, ConnectCallback, client);
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message, "Error!");
                return false;
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                client = (Socket)ar.AsyncState;
                client.EndConnect(ar);

                Send(username + "\0|Login"); // Login on connect

                client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, Receive, null);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.Message, "Error!");
            }
        }

        public void Disconnect()
        {
            if (client != null)
            {
                username = String.Empty;
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }
        #endregion

        #region Receive / Send
        private void Receive(IAsyncResult ar)
        {
            try
            {
                if (client == null)
                    return;

                string receiveStr = String.Empty;

                var bytesReceived = client.EndReceive(ar);
                if (bytesReceived > 0)
                {
                    receiveStr = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesReceived); // Retrieve the data (Put it into a string)

                    if (receiveStr.Contains(Packet.GetPacket(Packets.SERVER_VERIFIED))) // Get the string packet
                        MainForm.mainForm.EnableComponents(false, true); // Enable components after server verification
                    else if (receiveStr.Contains(Packet.GetPacket(Packets.CODE_MSG)))
                    {
                        receiveStr.Remove(receiveStr.Length - Packets.CODE_MSG.ToPacket().Length); // Remove the index

                        string msg = Packet.HandleSplitData(receiveStr)[0]; // Split the data

                        MessageHandler.HandleCodeMsg(msg, null);
                    }
                    else if (receiveStr.Contains(Packet.GetPacket(Packets.CHAT_MSG)))
                    {
                        receiveStr.Remove(receiveStr.Length - Packets.CHAT_MSG.ToPacket().Length);

                        string chatMessage = Packet.HandleSplitData(receiveStr)[0];

                        if (!string.IsNullOrEmpty(chatMessage))
                            MessageHandler.HandleChatMsg(chatMessage, null);
                    }

                    client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, Receive, null);
                }
            }
            catch (Exception ex)
            {
                MainForm.mainForm.WriteLog(ex.Message);
                //client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }

        public void Send(string val)
        {
            try
            {
                if (client == null)
                    return;

                byte[] newBytes = System.Text.Encoding.ASCII.GetBytes(val);
                client.Send(newBytes, 0, newBytes.Length, SocketFlags.None);
            }
            catch (Exception ex)
            {
                MainForm.mainForm.WriteLog(ex.Message);
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }
        #endregion
    }
}
