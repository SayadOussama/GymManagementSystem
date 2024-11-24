namespace GymManagement.Subscribers
{
    partial class FrmSubscriberManagement
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
            this.dgvSubscribers = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.subscriberInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewSubscriberAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateSubscriberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSubscriberAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            this.btnAddSubscriber = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbGender = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubscribers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSubscribers
            // 
            this.dgvSubscribers.AllowUserToAddRows = false;
            this.dgvSubscribers.AllowUserToDeleteRows = false;
            this.dgvSubscribers.AllowUserToOrderColumns = true;
            this.dgvSubscribers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubscribers.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvSubscribers.Location = new System.Drawing.Point(12, 172);
            this.dgvSubscribers.Name = "dgvSubscribers";
            this.dgvSubscribers.ReadOnly = true;
            this.dgvSubscribers.RowHeadersWidth = 51;
            this.dgvSubscribers.RowTemplate.Height = 24;
            this.dgvSubscribers.Size = new System.Drawing.Size(1517, 573);
            this.dgvSubscribers.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subscriberInfoToolStripMenuItem,
            this.renewSubscriberAccountToolStripMenuItem,
            this.updateSubscriberToolStripMenuItem,
            this.deleteSubscriberAccountToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(316, 156);
            // 
            // subscriberInfoToolStripMenuItem
            // 
            this.subscriberInfoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subscriberInfoToolStripMenuItem.Image = global::GymManagement.Properties.Resources.id_card;
            this.subscriberInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.subscriberInfoToolStripMenuItem.Name = "subscriberInfoToolStripMenuItem";
            this.subscriberInfoToolStripMenuItem.Size = new System.Drawing.Size(315, 38);
            this.subscriberInfoToolStripMenuItem.Text = "Subscriber Details";
            this.subscriberInfoToolStripMenuItem.Click += new System.EventHandler(this.subscriberInfoToolStripMenuItem_Click);
            // 
            // renewSubscriberAccountToolStripMenuItem
            // 
            this.renewSubscriberAccountToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renewSubscriberAccountToolStripMenuItem.Image = global::GymManagement.Properties.Resources.Renew;
            this.renewSubscriberAccountToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.renewSubscriberAccountToolStripMenuItem.Name = "renewSubscriberAccountToolStripMenuItem";
            this.renewSubscriberAccountToolStripMenuItem.Size = new System.Drawing.Size(315, 38);
            this.renewSubscriberAccountToolStripMenuItem.Text = "Renew Subscriber Account ";
            this.renewSubscriberAccountToolStripMenuItem.Click += new System.EventHandler(this.renewSubscriberAccountToolStripMenuItem_Click);
            // 
            // updateSubscriberToolStripMenuItem
            // 
            this.updateSubscriberToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateSubscriberToolStripMenuItem.Image = global::GymManagement.Properties.Resources.Update;
            this.updateSubscriberToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.updateSubscriberToolStripMenuItem.Name = "updateSubscriberToolStripMenuItem";
            this.updateSubscriberToolStripMenuItem.Size = new System.Drawing.Size(315, 38);
            this.updateSubscriberToolStripMenuItem.Text = "Update Subscriber Account";
            this.updateSubscriberToolStripMenuItem.Click += new System.EventHandler(this.updateSubscriberToolStripMenuItem_Click);
            // 
            // deleteSubscriberAccountToolStripMenuItem
            // 
            this.deleteSubscriberAccountToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteSubscriberAccountToolStripMenuItem.Image = global::GymManagement.Properties.Resources.delete;
            this.deleteSubscriberAccountToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteSubscriberAccountToolStripMenuItem.Name = "deleteSubscriberAccountToolStripMenuItem";
            this.deleteSubscriberAccountToolStripMenuItem.Size = new System.Drawing.Size(315, 38);
            this.deleteSubscriberAccountToolStripMenuItem.Text = "Delete Subscriber Account ";
            this.deleteSubscriberAccountToolStripMenuItem.Click += new System.EventHandler(this.deleteSubscriberAccountToolStripMenuItem_Click);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Account ID",
            "Full Name",
            "Gender",
            "Is Paid"});
            this.cbFilterBy.Location = new System.Drawing.Point(125, 145);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(210, 24);
            this.cbFilterBy.TabIndex = 98;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(342, 145);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(256, 22);
            this.txtFilterValue.TabIndex = 97;
            this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 96;
            this.label1.Text = "Filter By:";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1375, 753);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 37);
            this.button1.TabIndex = 121;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(160, 770);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(29, 20);
            this.lblRecordsCount.TabIndex = 120;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 765);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 119;
            this.label2.Text = "# Records:";
            // 
            // cbIsActive
            // 
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsActive.Location = new System.Drawing.Point(342, 143);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(121, 24);
            this.cbIsActive.TabIndex = 131;
            this.cbIsActive.Visible = false;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // btnAddSubscriber
            // 
            this.btnAddSubscriber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSubscriber.Image = global::GymManagement.Properties.Resources.AdduserMU;
            this.btnAddSubscriber.Location = new System.Drawing.Point(1454, 114);
            this.btnAddSubscriber.Name = "btnAddSubscriber";
            this.btnAddSubscriber.Size = new System.Drawing.Size(88, 55);
            this.btnAddSubscriber.TabIndex = 94;
            this.btnAddSubscriber.UseVisualStyleBackColor = true;
            this.btnAddSubscriber.Click += new System.EventHandler(this.btnAddSubscriber_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GymManagement.Properties.Resources.ManagemnentFrm;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1576, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cbGender
            // 
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "All",
            "Male",
            "Female"});
            this.cbGender.Location = new System.Drawing.Point(342, 145);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(121, 24);
            this.cbGender.TabIndex = 132;
            this.cbGender.Visible = false;
            this.cbGender.SelectedIndexChanged += new System.EventHandler(this.cbGender_SelectedIndexChanged);
            // 
            // FrmSubscriberManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1597, 826);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.txtFilterValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddSubscriber);
            this.Controls.Add(this.dgvSubscribers);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmSubscriberManagement";
            this.Text = "Subscriber Management";
            this.Load += new System.EventHandler(this.FrmSubscriberManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubscribers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvSubscribers;
        private System.Windows.Forms.Button btnAddSubscriber;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.ToolStripMenuItem subscriberInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewSubscriberAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateSubscriberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSubscriberAccountToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbGender;
    }
}