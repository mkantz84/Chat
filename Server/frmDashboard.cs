using System;
using System.Threading;
using System.Windows.Forms;
using Classes;
using ChatServer;

namespace Server
{
    public partial class frmDashboard : Form
    {
        #region Variables
        
        private Chat _Server;
        private Thread _OpenCommunicationThread;

        #endregion

        #region Constructor

        public frmDashboard()
        {
            InitializeComponent();

            lstClientsHistory.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lstClientsConnected.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            _OpenCommunicationThread = new Thread(OpenCommunication);
            _OpenCommunicationThread.Start();
        }

        #endregion

        #region Methods

        private void OpenCommunication()
        {
            _Server = new Chat();
            _Server.UserAdded += _Server_UserAdded;
            _Server.UserDisconnected += _Server_UserDisconnected;
            _Server.Init();
        }

        private void UpdateConnectedList(User user)
        {
            for (int i = 0; i < lstClientsConnected.Items.Count; i++)
            {
                if (lstClientsConnected.Items[i].Text == user.Id.ToString())
                {
                    lstClientsConnected.Items.RemoveAt(i);
                    break;
                }
            }
        }

        private void UpdateHistory(User user)
        {
            ListViewItem historyViewItem = new ListViewItem();
            historyViewItem.Text = user.Id.ToString();
            historyViewItem.SubItems.Add(user.NickName);
            historyViewItem.SubItems.Add("DISCONNECTED");
            historyViewItem.SubItems.Add(DateTime.Now.ToShortTimeString());
            lstClientsHistory.Items.Add(historyViewItem);
        }

        #endregion

        #region Event Handlers

        private void _Server_UserDisconnected(User user)
        {
            Invoke(new Action(() =>
            {
                UpdateHistory(user);
                UpdateConnectedList(user);
            }));
        }

        private void _Server_UserAdded(User user)
        {
            Invoke(new Action(() =>
            {
                ListViewItem userViewItem = new ListViewItem();
                userViewItem.Text = user.Id.ToString();
                userViewItem.SubItems.Add(user.NickName);
                userViewItem.SubItems.Add("Connected");
                userViewItem.SubItems.Add(DateTime.Now.ToShortTimeString());
                lstClientsConnected.Items.Add(userViewItem);
            }));
        }

        private void frmDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            _OpenCommunicationThread.Abort();
            Environment.Exit(1);
        }

        #endregion
    }
}