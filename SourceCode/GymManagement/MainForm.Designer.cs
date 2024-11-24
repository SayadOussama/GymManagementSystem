namespace GymManagement
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDateAndTime = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.subscriberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subscriberManagmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewSubscriberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findSubscriberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subscribersWithTrainerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyOfSalaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainerManagmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewTrainerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findTrainerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gymSubscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subscriptionManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewSubscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subscriptionInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryHistoryListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GymManagement.Properties.Resources.gym;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 91);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(106, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "User :";
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentUser.Location = new System.Drawing.Point(170, 22);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(60, 22);
            this.lblCurrentUser.TabIndex = 4;
            this.lblCurrentUser.Text = "?????";
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.Image = global::GymManagement.Properties.Resources.TurnOff;
            this.btnExit.Location = new System.Drawing.Point(1137, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(74, 80);
            this.btnExit.TabIndex = 6;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblDateAndTime
            // 
            this.lblDateAndTime.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblDateAndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateAndTime.ForeColor = System.Drawing.Color.Black;
            this.lblDateAndTime.Location = new System.Drawing.Point(402, 9);
            this.lblDateAndTime.Name = "lblDateAndTime";
            this.lblDateAndTime.Size = new System.Drawing.Size(1006, 39);
            this.lblDateAndTime.TabIndex = 76;
            this.lblDateAndTime.Text = "??????";
            this.lblDateAndTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDateAndTime);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.lblCurrentUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1211, 80);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1211, 438);
            this.panel2.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subscriberToolStripMenuItem,
            this.trainersToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.gymSubscriptionToolStripMenuItem,
            this.salaryHistoryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1211, 72);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // subscriberToolStripMenuItem
            // 
            this.subscriberToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subscriberManagmentToolStripMenuItem,
            this.addNewSubscriberToolStripMenuItem,
            this.findSubscriberToolStripMenuItem,
            this.subscribersWithTrainerToolStripMenuItem,
            this.historyOfSalaryToolStripMenuItem});
            this.subscriberToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subscriberToolStripMenuItem.Image = global::GymManagement.Properties.Resources.fitness;
            this.subscriberToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subscriberToolStripMenuItem.Name = "subscriberToolStripMenuItem";
            this.subscriberToolStripMenuItem.Size = new System.Drawing.Size(180, 68);
            this.subscriberToolStripMenuItem.Text = "Subscribers";
            // 
            // subscriberManagmentToolStripMenuItem
            // 
            this.subscriberManagmentToolStripMenuItem.Image = global::GymManagement.Properties.Resources.SubscriberManagement;
            this.subscriberManagmentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subscriberManagmentToolStripMenuItem.Name = "subscriberManagmentToolStripMenuItem";
            this.subscriberManagmentToolStripMenuItem.Size = new System.Drawing.Size(334, 70);
            this.subscriberManagmentToolStripMenuItem.Text = "Subscriber Management";
            this.subscriberManagmentToolStripMenuItem.Click += new System.EventHandler(this.subscriberManagmentToolStripMenuItem_Click);
            // 
            // addNewSubscriberToolStripMenuItem
            // 
            this.addNewSubscriberToolStripMenuItem.Image = global::GymManagement.Properties.Resources.AddNewSubscriber;
            this.addNewSubscriberToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewSubscriberToolStripMenuItem.Name = "addNewSubscriberToolStripMenuItem";
            this.addNewSubscriberToolStripMenuItem.Size = new System.Drawing.Size(334, 70);
            this.addNewSubscriberToolStripMenuItem.Text = "Add New Subscriber";
            this.addNewSubscriberToolStripMenuItem.Click += new System.EventHandler(this.addNewSubscriberToolStripMenuItem_Click);
            // 
            // findSubscriberToolStripMenuItem
            // 
            this.findSubscriberToolStripMenuItem.Image = global::GymManagement.Properties.Resources.Findsubscriber;
            this.findSubscriberToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.findSubscriberToolStripMenuItem.Name = "findSubscriberToolStripMenuItem";
            this.findSubscriberToolStripMenuItem.Size = new System.Drawing.Size(334, 70);
            this.findSubscriberToolStripMenuItem.Text = "Find Subscriber";
            this.findSubscriberToolStripMenuItem.Click += new System.EventHandler(this.findSubscriberToolStripMenuItem_Click);
            // 
            // subscribersWithTrainerToolStripMenuItem
            // 
            this.subscribersWithTrainerToolStripMenuItem.Image = global::GymManagement.Properties.Resources.TrainerWithSubscribers;
            this.subscribersWithTrainerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subscribersWithTrainerToolStripMenuItem.Name = "subscribersWithTrainerToolStripMenuItem";
            this.subscribersWithTrainerToolStripMenuItem.Size = new System.Drawing.Size(334, 70);
            this.subscribersWithTrainerToolStripMenuItem.Text = "Subscribers with Trainer";
            this.subscribersWithTrainerToolStripMenuItem.Click += new System.EventHandler(this.subscribersWithTrainerToolStripMenuItem_Click);
            // 
            // historyOfSalaryToolStripMenuItem
            // 
            this.historyOfSalaryToolStripMenuItem.Name = "historyOfSalaryToolStripMenuItem";
            this.historyOfSalaryToolStripMenuItem.Size = new System.Drawing.Size(334, 70);
            this.historyOfSalaryToolStripMenuItem.Click += new System.EventHandler(this.historyOfSalaryToolStripMenuItem_Click);
            // 
            // trainersToolStripMenuItem
            // 
            this.trainersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainerManagmentToolStripMenuItem,
            this.addNewTrainerToolStripMenuItem,
            this.findTrainerToolStripMenuItem});
            this.trainersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainersToolStripMenuItem.Image = global::GymManagement.Properties.Resources.trainer;
            this.trainersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.trainersToolStripMenuItem.Name = "trainersToolStripMenuItem";
            this.trainersToolStripMenuItem.Size = new System.Drawing.Size(151, 68);
            this.trainersToolStripMenuItem.Text = "Trainers";
            // 
            // trainerManagmentToolStripMenuItem
            // 
            this.trainerManagmentToolStripMenuItem.Image = global::GymManagement.Properties.Resources.TrainerManagement;
            this.trainerManagmentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.trainerManagmentToolStripMenuItem.Name = "trainerManagmentToolStripMenuItem";
            this.trainerManagmentToolStripMenuItem.Size = new System.Drawing.Size(305, 70);
            this.trainerManagmentToolStripMenuItem.Text = "Trainer Management";
            this.trainerManagmentToolStripMenuItem.Click += new System.EventHandler(this.trainerManagmentToolStripMenuItem_Click);
            // 
            // addNewTrainerToolStripMenuItem
            // 
            this.addNewTrainerToolStripMenuItem.Image = global::GymManagement.Properties.Resources.AddnewTrainer;
            this.addNewTrainerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewTrainerToolStripMenuItem.Name = "addNewTrainerToolStripMenuItem";
            this.addNewTrainerToolStripMenuItem.Size = new System.Drawing.Size(305, 70);
            this.addNewTrainerToolStripMenuItem.Text = "Add New Trainer";
            this.addNewTrainerToolStripMenuItem.Click += new System.EventHandler(this.addNewTrainerToolStripMenuItem_Click);
            // 
            // findTrainerToolStripMenuItem
            // 
            this.findTrainerToolStripMenuItem.Image = global::GymManagement.Properties.Resources.FindTrainer;
            this.findTrainerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.findTrainerToolStripMenuItem.Name = "findTrainerToolStripMenuItem";
            this.findTrainerToolStripMenuItem.Size = new System.Drawing.Size(305, 70);
            this.findTrainerToolStripMenuItem.Text = "Find Trainer";
            this.findTrainerToolStripMenuItem.Click += new System.EventHandler(this.findTrainerToolStripMenuItem_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userManagementToolStripMenuItem,
            this.addNToolStripMenuItem});
            this.usersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usersToolStripMenuItem.Image = global::GymManagement.Properties.Resources.team_management;
            this.usersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(130, 68);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.Image = global::GymManagement.Properties.Resources.UserManagment;
            this.userManagementToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(284, 70);
            this.userManagementToolStripMenuItem.Text = "User Management";
            this.userManagementToolStripMenuItem.Click += new System.EventHandler(this.userManagementToolStripMenuItem_Click);
            // 
            // addNToolStripMenuItem
            // 
            this.addNToolStripMenuItem.Image = global::GymManagement.Properties.Resources.AddnewUser;
            this.addNToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNToolStripMenuItem.Name = "addNToolStripMenuItem";
            this.addNToolStripMenuItem.Size = new System.Drawing.Size(284, 70);
            this.addNToolStripMenuItem.Text = "Add New User";
            this.addNToolStripMenuItem.Click += new System.EventHandler(this.addNToolStripMenuItem_Click);
            // 
            // gymSubscriptionToolStripMenuItem
            // 
            this.gymSubscriptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subscriptionManagementToolStripMenuItem,
            this.addNewSubscriptionToolStripMenuItem,
            this.subscriptionInfoToolStripMenuItem});
            this.gymSubscriptionToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gymSubscriptionToolStripMenuItem.Image = global::GymManagement.Properties.Resources.SubscribeSection;
            this.gymSubscriptionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.gymSubscriptionToolStripMenuItem.Name = "gymSubscriptionToolStripMenuItem";
            this.gymSubscriptionToolStripMenuItem.Size = new System.Drawing.Size(231, 68);
            this.gymSubscriptionToolStripMenuItem.Text = "Gym Subscription";
            // 
            // subscriptionManagementToolStripMenuItem
            // 
            this.subscriptionManagementToolStripMenuItem.Image = global::GymManagement.Properties.Resources.SSubscribeManagment;
            this.subscriptionManagementToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subscriptionManagementToolStripMenuItem.Name = "subscriptionManagementToolStripMenuItem";
            this.subscriptionManagementToolStripMenuItem.Size = new System.Drawing.Size(350, 70);
            this.subscriptionManagementToolStripMenuItem.Text = "Subscription Management";
            this.subscriptionManagementToolStripMenuItem.Click += new System.EventHandler(this.subscriptionManagementToolStripMenuItem_Click);
            // 
            // addNewSubscriptionToolStripMenuItem
            // 
            this.addNewSubscriptionToolStripMenuItem.Image = global::GymManagement.Properties.Resources.AddNewSubscription;
            this.addNewSubscriptionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewSubscriptionToolStripMenuItem.Name = "addNewSubscriptionToolStripMenuItem";
            this.addNewSubscriptionToolStripMenuItem.Size = new System.Drawing.Size(350, 70);
            this.addNewSubscriptionToolStripMenuItem.Text = "Add New Subscription ";
            this.addNewSubscriptionToolStripMenuItem.Click += new System.EventHandler(this.addNewSubscriptionToolStripMenuItem_Click);
            // 
            // subscriptionInfoToolStripMenuItem
            // 
            this.subscriptionInfoToolStripMenuItem.Image = global::GymManagement.Properties.Resources.SHowDetails;
            this.subscriptionInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subscriptionInfoToolStripMenuItem.Name = "subscriptionInfoToolStripMenuItem";
            this.subscriptionInfoToolStripMenuItem.Size = new System.Drawing.Size(350, 70);
            this.subscriptionInfoToolStripMenuItem.Text = "Subscription Info";
            this.subscriptionInfoToolStripMenuItem.Click += new System.EventHandler(this.subscriptionInfoToolStripMenuItem_Click);
            // 
            // salaryHistoryToolStripMenuItem
            // 
            this.salaryHistoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salaryHistoryListToolStripMenuItem});
            this.salaryHistoryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salaryHistoryToolStripMenuItem.Image = global::GymManagement.Properties.Resources.moneyMM;
            this.salaryHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.salaryHistoryToolStripMenuItem.Name = "salaryHistoryToolStripMenuItem";
            this.salaryHistoryToolStripMenuItem.Size = new System.Drawing.Size(190, 68);
            this.salaryHistoryToolStripMenuItem.Text = "Salary History ";
            this.salaryHistoryToolStripMenuItem.Click += new System.EventHandler(this.salaryHistoryToolStripMenuItem_Click);
            // 
            // salaryHistoryListToolStripMenuItem
            // 
            this.salaryHistoryListToolStripMenuItem.Image = global::GymManagement.Properties.Resources.GetHistory;
            this.salaryHistoryListToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.salaryHistoryListToolStripMenuItem.Name = "salaryHistoryListToolStripMenuItem";
            this.salaryHistoryListToolStripMenuItem.Size = new System.Drawing.Size(264, 70);
            this.salaryHistoryListToolStripMenuItem.Text = "Salary History List";
            this.salaryHistoryListToolStripMenuItem.Click += new System.EventHandler(this.salaryHistoryListToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.menuStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1211, 80);
            this.panel3.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::GymManagement.Properties.Resources.Main__2_;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1211, 438);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 518);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GymManagement";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load_2);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblDateAndTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem subscriberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscriberManagmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewSubscriberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findSubscriberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscribersWithTrainerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyOfSalaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainerManagmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewTrainerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findTrainerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gymSubscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscriptionManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewSubscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscriptionInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salaryHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salaryHistoryListToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

