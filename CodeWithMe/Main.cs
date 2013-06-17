using System;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace CodeWithMe
{
    public partial class MainForm : Form
    {
        #region Variables
        /* Main Form (mainForm) */
        public static MainForm mainForm;
        /// <summary>
        /// True: It's the server
        /// False: It is the client
        /// </summary>
        private bool isServer;
        /// <summary>
        /// Client
        /// </summary>
        private Client client;
        /// <summary>
        /// Server
        /// </summary>
        Server server;
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Events
        private void MainForm_Load(object sender, EventArgs e)
        {
            mainForm = this;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client != null )
                client.Disconnect();
        }
        #endregion

        #region Button Events
        /// <summary>
        /// Starts the server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonServer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxHost.Text) || string.IsNullOrEmpty(textBoxPort.Text))
                return;

            if (Start(textBoxHost.Text, Convert.ToInt32(textBoxPort.Text)))
            {
                server = new Server();
                isServer = true;
                buttonClient.Enabled = false;
            }
        }
        /// <summary>
        /// Starts the client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUser.Text) || string.IsNullOrEmpty(textBoxHost.Text) || string.IsNullOrEmpty(textBoxPort.Text))
                return;

            if (buttonClient.Text == "Disconnect")
            {
                // Disconnect client
                client.Disconnect();
                client = null;
                // Enable all components needed to connect again
                EnableComponents(true, false);
                buttonClient.Text = "Connect as Client";
                MessageBox.Show("Disconnected!");
            }
            else
            {
                client = new Client();
                client.username = textBoxUser.Text;
                if (client.Connect(textBoxHost.Text, Convert.ToInt32(textBoxPort.Text)))
                {
                    isServer = false;
                    EnableComponents(false, false);
                    buttonClient.Text = "Disconnect";
                }
            }
        }
        /// <summary>
        /// Sends a chat message to the other clients / server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxMsg.Text, @"[a-zA-Z]") || Regex.IsMatch(textBoxMsg.Text, @"[0-9]"))
            {
                if (isServer)
                {
                    server.SendToAll("[Server]: " + textBoxMsg.Text + "\0|Chat");
                    richTextBoxChat.AppendText("[Server]: " + textBoxMsg.Text + "\n"); // Send our message to the chat so we can see it too
                }
                else
                {
                    if (client != null)
                    {
                        client.Send("[" + client.username + "]: " + textBoxMsg.Text + "\0|Chat");
                        richTextBoxChat.AppendText("[" + client.username + "]: " + textBoxMsg.Text + "\n"); // Send our message to the chat so we can see it too
                    }
                }
            }
            textBoxMsg.Clear(); // Clear after sending
        }
        #endregion

        #region TextBox Events
        /// <summary>
        /// Message box : On enter, chat send data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (Regex.IsMatch(textBoxMsg.Text, @"[a-zA-Z]") || Regex.IsMatch(textBoxMsg.Text, @"[0-9]"))
                {
                    if (isServer)
                    {
                        server.SendToAll("[Server]: " + textBoxMsg.Text + "\0|Chat");
                        richTextBoxChat.AppendText("[Server]: " + textBoxMsg.Text + "\n"); // Send our message to the chat so we can see it too
                    }
                    else
                    {
                        if (client != null)
                        {
                            client.Send("[" + client.username + "]: " + textBoxMsg.Text + "\0|Chat");
                            richTextBoxChat.AppendText("[" + client.username + "]: " + textBoxMsg.Text + "\n"); // Send our message to the chat so we can see it too
                        }
                    }
                }
                textBoxMsg.Clear(); // Clear after sending
            }
        }
        #endregion

        #region RichTextBox Events
        // Code box
        private void richTextBoxCode_TextChanged(object sender, EventArgs e)
        {
            string tokens = "(auto|double|int|public|function|struct|end|break|else|long|switch|case|enum|register|typedef|char|extern|return|union|const|float|short|unsigned|continue|for|signed|void|default|goto|sizeof|volatile|do|if|static|while)";
            Regex rex = new Regex(tokens);
            MatchCollection mc = rex.Matches(richTextBoxCode.Text);
            int StartCursorPosition = richTextBoxCode.SelectionStart;
            foreach (Match m in mc)
            {
                int startIndex = m.Index;
                int StopIndex = m.Length;
                richTextBoxCode.Select(startIndex, StopIndex);
                richTextBoxCode.SelectionColor = Color.Blue;
                richTextBoxCode.SelectionStart = StartCursorPosition;
                richTextBoxCode.SelectionColor = Color.Black;
            }
        }

        private void richTextBoxCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (isServer)
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    int length = richTextBoxCode.TextLength;

                    server.SendToAll(length.ToString() + "\0|Del");
                    return;
                }

                server.SendToAll(e.KeyChar + "\0|Code");
            }
            else
            {
                if (client != null)
                {
                    if (e.KeyChar == (char)Keys.Back)
                    {
                        int length = richTextBoxCode.TextLength;

                        client.Send(length.ToString() + "\0|Del");
                        return;
                    }

                    client.Send(e.KeyChar + "\0|Code");
                }
            }
        }
        #endregion

        #region Component Functions
        /* RichTextBox WriteLog */
        public void WriteLog(string txt)
        {
            MethodInvoker invoker = new MethodInvoker(delegate() {
                richTextBoxLogs.AppendText(txt);
                richTextBoxLogs.AppendText(Environment.NewLine); 
            });

            this.Invoke(invoker);
        }

        /* (Client) Enable Components after server accepts */
        public void EnableComponents(bool disconnected, bool disable)
        {
            MethodInvoker invoker;

            if (disconnected)
            {
                invoker = new MethodInvoker(delegate() {
                    richTextBoxCode.Enabled = false;
                    buttonServer.Enabled = true;
                    textBoxHost.Enabled = true;
                    textBoxUser.Enabled = true;
                    textBoxPort.Enabled = true;
                });
                this.Invoke(invoker);
                return;
            }

            invoker = new MethodInvoker(delegate() {
                if (disable)
                    richTextBoxCode.Enabled = true;
                else
                {
                    buttonServer.Enabled = false;
                    textBoxHost.Enabled = false;
                    textBoxUser.Enabled = false;
                    textBoxPort.Enabled = false;
                }
            });

            this.Invoke(invoker);
        }
        #endregion

        #region Initial Server Start
        /* TcpListener */
        private TcpListener listener;

        public bool Start(string host, int port)
        {
            if (string.IsNullOrEmpty(textBoxHost.Text) || string.IsNullOrEmpty(textBoxPort.Text))
                return false;

            try
            {
                listener = new TcpListener(IPAddress.Parse(host), port);
                listener.Start();
                AcceptThread();
                WriteLog("Successfully Started the Server!");
                WriteLog("Accepting Clients... ");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to start server {0} " + ex.Message, "Failed to start!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog("Failed to start server " + ex.Message);
                return false;
            }
        }

        public void AcceptThread()
        {
            new Thread(Accept).Start();
        }

        async void Accept()
        {
            try
            {
                while (true)
                {
                    if (listener.Pending())
                    {
                        server.client = await listener.AcceptSocketAsync();

                        new Thread(server.OnConnect).Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed! " + ex.Message, "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteLog("Failed! " + ex.Message);
            }
        }
        #endregion
    }
}
