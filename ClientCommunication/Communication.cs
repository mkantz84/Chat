using Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace ClientCommunication
{
    public class Communication
    {
        #region Variables

        private Thread _ChatThread;
        private string _IPAdress;
        private int _Port;
        private TcpClient _TcpClient;
        private BinaryFormatter _BinaryFormatter = new BinaryFormatter();

        #endregion

        #region Properties

        public User ActiveUser { get; set; }

        #endregion

        #region Constructor

        public Communication(User activeUser, string iPAdress, int port)
        {
            ActiveUser = activeUser;
            _IPAdress = iPAdress;
            _Port = port;
        }

        #endregion

        #region Methods

        public void Init()
        {
            _TcpClient = new TcpClient();
            _TcpClient.Connect(IPAddress.Parse(_IPAdress), _Port);
            _ChatThread = new Thread(ManageChatSession);
            _ChatThread.Start();
        }

        /// <summary>
        /// endless loop for getting information from server
        /// </summary>
        private void ManageChatSession()
        {
            NetworkStream networkStream = _TcpClient.GetStream();
            Packet packet = (Packet)_BinaryFormatter.Deserialize(networkStream);
            HandlePacket(packet);
            _BinaryFormatter.Serialize(networkStream, ActiveUser);

            while (true)
            {
                try
                {
                    if (_TcpClient.Connected)
                    {
                        packet = (Packet)_BinaryFormatter.Deserialize(networkStream);
                        HandlePacket(packet);
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }
        }

        private void HandlePacket(Packet packet)
        {
            switch (packet.Type)
            {
                case TypeData.MESSAGE:
                    OnMessageReceived(packet.Message, packet.Color);
                    break;
                case TypeData.USERS_INIT:
                    OnUsersInit(packet.UsersList);
                    break;
                case TypeData.ADD_USER:
                    OnNewUserAdded(packet.User);
                    break;
                case TypeData.REMOVE_USER:
                    OnUserRemoved(packet.User, packet.Message);
                    break;
                case TypeData.GET_ID:
                    ActiveUser.Id = packet.ID;
                    break;
            }
        }

        public void SendMessage(string text, List<User> users)
        {
            try
            {
                NetworkStream networkStream = _TcpClient.GetStream();

                Packet packet;
                if (users != null && users.Count > 0)
                {
                    packet = new Packet()
                    {
                        Type = TypeData.PRIVATE_MESSAGE,
                        Message = text,
                        Color = ActiveUser.UserColor,
                        UsersList = users,
                    };
                }
                else
                {
                    packet = new Packet()
                    {
                        Type = TypeData.MESSAGE,
                        Message = string.Format("{0}: {1}", ActiveUser.NickName, text),
                        Color = ActiveUser.UserColor,
                    };
                }

                _BinaryFormatter.Serialize(networkStream, packet);
            }
            catch
            {
                _TcpClient.Close();
                _ChatThread.Abort();
                OnConnectionStoped();
            }
        }

        #endregion

        #region Events

        public delegate void MessageReceivedDelegate(string message, Color color);
        public event MessageReceivedDelegate MessageReceived;
        private void OnMessageReceived(string message, Color color)
        {
            if (MessageReceived == null) return;
            MessageReceived.Invoke(message, color);
        }

        public delegate void UsersInitDelegate(List<User> usersList);
        public event UsersInitDelegate UsersInit;
        private void OnUsersInit(List<User> usersList)
        {
            if (UsersInit == null) return;
            UsersInit.Invoke(usersList);
        }

        public delegate void NewUserAddedDelegate(User user);
        public event NewUserAddedDelegate NewUserAdded;
        private void OnNewUserAdded(User user)
        {
            if (NewUserAdded == null) return;
            NewUserAdded.Invoke(user);
        }

        public delegate void UserRemovedDelegate(User user, string message);
        public event UserRemovedDelegate UserRemoved;
        private void OnUserRemoved(User user, string message)
        {
            if (UserRemoved == null) return;
            UserRemoved.Invoke(user, message);
        }

        public delegate void ConnectionStopedDelegate();
        public event ConnectionStopedDelegate ConnectionStoped;
        private void OnConnectionStoped()
        {
            if (ConnectionStoped == null) return;
            ConnectionStoped.Invoke();
        }

        #endregion
    }
}
