using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SocketCommunication
{
    public partial class Form1 : Form
    {
        private const int serverPort = 8080;
        private const string serverIPAddress = "127.0.0.1";

        private UdpClient udpClient;
        private Thread receivingThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            udpClient = new UdpClient();

            receivingThread = new Thread(new ThreadStart(ReceiveMessages));
            receivingThread.IsBackground = true;
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            StartServer();
        }

        private void btnStartClient_Click(object sender, EventArgs e)
        {
            StartClient();
        }

        private void StartServer()
        {
            Thread serverThread = new Thread(new ThreadStart(ServerThread));
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void ServerThread()
        {
            try
            {
                using (Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                {
                    IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(serverIPAddress), serverPort);
                    serverSocket.Bind(serverEndPoint);

                    byte[] buffer = new byte[1024];

                    while (true)
                    {
                        EndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                        int bytesRead = serverSocket.ReceiveFrom(buffer, ref clientEndPoint);
                        string receivedMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        UpdateReceivedMessages(receivedMessage);

                        serverSocket.SendTo(Encoding.ASCII.GetBytes("Server received: " + receivedMessage), clientEndPoint);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server error: " + ex.Message);
            }
        }

        private void StartClient()
        {
            try
            {
                udpClient.Connect(serverIPAddress, serverPort);

                byte[] data = Encoding.ASCII.GetBytes(txtMessage.Text);
                udpClient.Send(data, data.Length);

                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] receivedData = udpClient.Receive(ref remoteEndPoint);
                string receivedMessage = Encoding.ASCII.GetString(receivedData);
                UpdateReceivedMessages(receivedMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Client error: " + ex.Message);
            }
            finally
            {
                udpClient.Close();
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                while (true)
                {
                    byte[] data = udpClient.Receive(ref anyIP);
                    string message = Encoding.ASCII.GetString(data);
                    UpdateReceivedMessages(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error receiving messages: " + ex.Message);
            }
        }

        private void UpdateReceivedMessages(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateReceivedMessages), message);
            }
            else
            {
                rtbReceivedMessages.AppendText(message + Environment.NewLine);
            }
        }
    }
}
