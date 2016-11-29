using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Classes;

namespace ChatServer
{
    class Communication
    {
        #region Variables

        private static int counter = 0;

        private NetworkStream _NetworkStream;
        private TcpClient _Client;
        private User _User;
        private BinaryFormatter _BinaryFormatter = new BinaryFormatter();

        #endregion

        #region Constructor

        public Communication(TcpClient tcpClient)
        {
            _Client = tcpClient;
            Thread chatThread = new Thread(StartChat) { IsBackground = true };
            chatThread.Start();
        }
        #endregion

        #region Methodes

        private void runChat()
        {
            OnUserAdded(_User);
            NetworkStream networkStream = _Client.GetStream();

            try
            {
                while (true)
                {
                    Packet packet = (Packet)_BinaryFormatter.Deserialize(networkStream);
                    HandleData(packet);
                }
            }
            catch (Exception)
            {
                networkStream.Close();
            }
        }

        private void HandleData(Packet packet)
        {
            switch (packet.Type)
            {
                case TypeData.MESSAGE:
                    Chat.SendMsgToAll(packet);
                    break;
                case TypeData.PRIVATE_MESSAGE:
                    Chat.SendMsgToPrivate(_User, packet);
                    break;
            }
        }

        private void SendNewId(NetworkStream networkStream)
        {
            Packet packet = new Packet()
            {
                Type = TypeData.GET_ID,
                ID = ++counter,
            };
            _BinaryFormatter.Serialize(networkStream, packet);
        }

        private void StartChat()
        {
            _NetworkStream = _Client.GetStream();
            SendNewId(_NetworkStream);
            _User = (User)_BinaryFormatter.Deserialize(_NetworkStream);

            Packet packet = new Packet
            {
                Type = TypeData.MESSAGE,
                Message ="\t\t"+ _User.NickName.ToUpper() + "! WELCONE TO CHAT!",
            };
            _BinaryFormatter.Serialize(_NetworkStream, packet);

            Chat._ConnectedUsers.Add(_User, _Client);
            Chat.SendUsersList(_User, _NetworkStream);

            packet = new Packet
            {
                Type = TypeData.MESSAGE,
                Message = "SERVER SAYS:\r\n\t" + _User.NickName.ToUpper() + " HAS JOINED THE CHAT"
            };

            Chat.SendMsgToAll(packet);

            //create a new thread for this user
            Thread chatThread = new Thread(new ThreadStart(runChat));
            chatThread.Start();
        }
        #endregion

        #region Events

        public delegate void InsertSuerDelegate(User user);
        public event InsertSuerDelegate UserAdded;
        private void OnUserAdded(User user)
        {
            if (UserAdded == null) return;
            UserAdded.Invoke(user);
        }

        #endregion
    }
}
