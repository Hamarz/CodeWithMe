using System;
using System.ComponentModel;

namespace CodeWithMe
{
    public static class Packet
    {
        public static string ToPacket(this Enum val)
        {
            var desAttribute = (DescriptionAttribute[])(val.GetType().GetField(val.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return desAttribute.Length > 0 ? desAttribute[0].Description : val.ToString();
        }

        public static string GetPacket(Packets packet)
        {
            return packet.ToPacket();
        }

        public static string[] HandleSplitData(string data)
        {
            string[] value = data.Split(new char[] { '\0' }, StringSplitOptions.None);

            return value;
        }
    }

    public enum Packets
    {
        [Description("|Login")]
        ACCOUNT_LOGIN           = 1,
        [Description("|Chat")]
        CHAT_MSG                = 2,
        [Description("|Code")]
        CODE_MSG                = 3,
        [Description("|Verify")]
        SERVER_VERIFIED         = 4,
        [Description("|Del")]
        CODE_DEL                = 5,
    }
}
