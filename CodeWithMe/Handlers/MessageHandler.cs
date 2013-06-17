﻿using System;

namespace CodeWithMe
{
    public class MessageHandler
    {
        /// <summary>
        /// Handles the Coding Text
        /// </summary>
        /// <param name="msg">Code text</param>
        /// <param name="server">Server</param>
        public static void HandleCodeMsg(string msg, Server server)
        {
            MainForm.mainForm.richTextBoxCode.AppendText(msg);
        }

        public static void HandleChatMsg(string msg, Server server)
        {
            MainForm.mainForm.richTextBoxChat.AppendText(msg);
            MainForm.mainForm.richTextBoxChat.AppendText(Environment.NewLine);
        }

        /// <summary>
        /// Handles Client > Server and Server > Client deletion of code
        /// </summary>
        /// <param name="length">Length of the text deleted</param>
        /// <param name="server">Server</param>
        public static void HandleCodeDel(int length, Server server)
        {
            if (length < 0)
                return;

            MainForm.mainForm.richTextBoxCode.Select(length, 1);
            MainForm.mainForm.richTextBoxCode.SelectedText = "";
            MainForm.mainForm.richTextBoxCode.SelectionStart = length;
        }
    }
}