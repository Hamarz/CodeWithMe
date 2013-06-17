using System;

namespace CodeWithMe
{
    public class PacketHandler
    {
        /// <summary>
        /// Handles incoming data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="server"></param>
        public static void HandleData(string data, Server server)
        {
            if (data.Contains(Packet.GetPacket(Packets.ACCOUNT_LOGIN)))
            {
                data.Remove(data.Length - Packets.ACCOUNT_LOGIN.ToPacket().Length);

                string username = Packet.HandleSplitData(data)[0];

                if (!string.IsNullOrEmpty(username))
                    LoginHandler.HandleLogin(username, server);
            }
            else if (data.Contains(Packet.GetPacket(Packets.CODE_MSG)))
            {
                data.Remove(data.Length - Packets.CODE_MSG.ToPacket().Length);

                string msg = Packet.HandleSplitData(data)[0];

                if (!string.IsNullOrEmpty(msg))
                    MessageHandler.HandleCodeMsg(msg, server);
            }
            else if (data.Contains(Packet.GetPacket(Packets.CODE_DEL)))
            {
                data.Remove(data.Length - Packets.CODE_DEL.ToPacket().Length);

                int length = Convert.ToInt32(Packet.HandleSplitData(data)[0]);

                if (length >= 0)
                    MessageHandler.HandleCodeDel(length, server);
            }
            else if (data.Contains(Packet.GetPacket(Packets.CHAT_MSG)))
            {
                data.Remove(data.Length - Packets.CHAT_MSG.ToPacket().Length);

                string chatMessage = Packet.HandleSplitData(data)[0];

                if (!string.IsNullOrEmpty(chatMessage))
                    MessageHandler.HandleChatMsg(chatMessage, server);
            }
        }
    }
}
