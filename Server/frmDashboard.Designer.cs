namespace Server
{
    partial class frmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbUsers = new System.Windows.Forms.TabPage();
            this.lstClientsConnected = new System.Windows.Forms.ListView();
            this.clmnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnNickName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbHistory = new System.Windows.Forms.TabPage();
            this.lstClientsHistory = new System.Windows.Forms.ListView();
            this.clmnHistoryId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnOutTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tbUsers.SuspendLayout();
            this.tbHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbUsers);
            this.tabControl1.Controls.Add(this.tbHistory);
            this.tabControl1.Location = new System.Drawing.Point(15, 14);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(488, 358);
            this.tabControl1.TabIndex = 2;
            // 
            // tbUsers
            // 
            this.tbUsers.Controls.Add(this.lstClientsConnected);
            this.tbUsers.Location = new System.Drawing.Point(4, 25);
            this.tbUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbUsers.Name = "tbUsers";
            this.tbUsers.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbUsers.Size = new System.Drawing.Size(480, 329);
            this.tbUsers.TabIndex = 0;
            this.tbUsers.Text = "USERS";
            this.tbUsers.UseVisualStyleBackColor = true;
            // 
            // lstClientsConnected
            // 
            this.lstClientsConnected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnID,
            this.clmnNickName,
            this.clmnStatus,
            this.clmnTime});
            this.lstClientsConnected.Location = new System.Drawing.Point(7, 6);
            this.lstClientsConnected.Margin = new System.Windows.Forms.Padding(4);
            this.lstClientsConnected.Name = "lstClientsConnected";
            this.lstClientsConnected.Size = new System.Drawing.Size(463, 313);
            this.lstClientsConnected.TabIndex = 0;
            this.lstClientsConnected.UseCompatibleStateImageBehavior = false;
            this.lstClientsConnected.View = System.Windows.Forms.View.Details;
            // 
            // clmnID
            // 
            this.clmnID.Text = "ID";
            this.clmnID.Width = 25;
            // 
            // clmnNickName
            // 
            this.clmnNickName.Text = "Nick Name";
            this.clmnNickName.Width = 25;
            // 
            // clmnStatus
            // 
            this.clmnStatus.Text = "Status            ";
            this.clmnStatus.Width = 79;
            // 
            // clmnTime
            // 
            this.clmnTime.Text = "Login Time";
            this.clmnTime.Width = 25;
            // 
            // tbHistory
            // 
            this.tbHistory.Controls.Add(this.lstClientsHistory);
            this.tbHistory.Location = new System.Drawing.Point(4, 25);
            this.tbHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbHistory.Name = "tbHistory";
            this.tbHistory.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbHistory.Size = new System.Drawing.Size(480, 329);
            this.tbHistory.TabIndex = 1;
            this.tbHistory.Text = "HISTORY";
            this.tbHistory.UseVisualStyleBackColor = true;
            // 
            // lstClientsHistory
            // 
            this.lstClientsHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnHistoryId,
            this.columnHeader1,
            this.columnHeader2,
            this.clmnOutTime});
            this.lstClientsHistory.Location = new System.Drawing.Point(7, 6);
            this.lstClientsHistory.Margin = new System.Windows.Forms.Padding(4);
            this.lstClientsHistory.Name = "lstClientsHistory";
            this.lstClientsHistory.Size = new System.Drawing.Size(463, 313);
            this.lstClientsHistory.TabIndex = 1;
            this.lstClientsHistory.UseCompatibleStateImageBehavior = false;
            this.lstClientsHistory.View = System.Windows.Forms.View.Details;
            // 
            // clmnHistoryId
            // 
            this.clmnHistoryId.Text = "ID";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nick Name";
            this.columnHeader1.Width = 98;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status                     ";
            this.columnHeader2.Width = 100;
            // 
            // clmnOutTime
            // 
            this.clmnOutTime.Text = "LogoutTime";
            this.clmnOutTime.Width = 98;
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 383);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmDashboard";
            this.Text = "Server Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDashboard_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tbUsers.ResumeLayout(false);
            this.tbHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbUsers;
        private System.Windows.Forms.ListView lstClientsConnected;
        private System.Windows.Forms.ColumnHeader clmnNickName;
        private System.Windows.Forms.ColumnHeader clmnStatus;
        private System.Windows.Forms.TabPage tbHistory;
        private System.Windows.Forms.ListView lstClientsHistory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader clmnOutTime;
        private System.Windows.Forms.ColumnHeader clmnID;
        private System.Windows.Forms.ColumnHeader clmnHistoryId;
        private System.Windows.Forms.ColumnHeader clmnTime;
    }
}