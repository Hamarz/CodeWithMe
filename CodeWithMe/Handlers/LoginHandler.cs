namespace CodeWithMe
{
    public class LoginHandler
    {
        public static void HandleLogin(string username, Server server)
        {
            MainForm.mainForm.WriteLog(username + " connected!");

            server.username = username; // Set the client username for the server

            server.Send("Success|Verify"); // Send verification
        }
    }
}