using GymManagement.Users;

namespace GymManagement.Subscribers.Controls
{
    partial class ctrlFindSubscriber
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblAccountID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbSubscribeType = new System.Windows.Forms.GroupBox();
            this.lblSubscribeTypeChooice = new System.Windows.Forms.Label();
            this.gbTrainer = new System.Windows.Forms.GroupBox();
            this.lblTrainerChooice = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.lblSubscribEndDate = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.lblSubscribeStartDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.btnAddNewAccount = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.txtFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblIsPaid = new System.Windows.Forms.Label();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pbIsActive = new System.Windows.Forms.PictureBox();
            this.pbIsPaid = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.ctrlPersonCard1 = new ctrlPersonCard.ctrlPersonCard();
            this.groupBox2.SuspendLayout();
            this.gbSubscribeType.SuspendLayout();
            this.gbTrainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            this.gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIsActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIsPaid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAccountID
            // 
            this.lblAccountID.AutoSize = true;
            this.lblAccountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountID.Location = new System.Drawing.Point(1090, 57);
            this.lblAccountID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccountID.Name = "lblAccountID";
            this.lblAccountID.Size = new System.Drawing.Size(49, 25);
            this.lblAccountID.TabIndex = 127;
            this.lblAccountID.Text = "N/A";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(906, 57);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 25);
            this.label9.TabIndex = 126;
            this.label9.Text = "Account ID :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gbSubscribeType);
            this.groupBox2.Controls.Add(this.gbTrainer);
            this.groupBox2.Controls.Add(this.pictureBox14);
            this.groupBox2.Controls.Add(this.lblSubscribEndDate);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.pictureBox13);
            this.groupBox2.Controls.Add(this.lblSubscribeStartDate);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(899, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 420);
            this.groupBox2.TabIndex = 125;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Subscribe Info";
            // 
            // gbSubscribeType
            // 
            this.gbSubscribeType.Controls.Add(this.lblSubscribeTypeChooice);
            this.gbSubscribeType.Location = new System.Drawing.Point(6, 319);
            this.gbSubscribeType.Name = "gbSubscribeType";
            this.gbSubscribeType.Size = new System.Drawing.Size(424, 95);
            this.gbSubscribeType.TabIndex = 119;
            this.gbSubscribeType.TabStop = false;
            this.gbSubscribeType.Text = "Subscribe Type";
            // 
            // lblSubscribeTypeChooice
            // 
            this.lblSubscribeTypeChooice.AutoSize = true;
            this.lblSubscribeTypeChooice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubscribeTypeChooice.Location = new System.Drawing.Point(143, 46);
            this.lblSubscribeTypeChooice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubscribeTypeChooice.Name = "lblSubscribeTypeChooice";
            this.lblSubscribeTypeChooice.Size = new System.Drawing.Size(108, 25);
            this.lblSubscribeTypeChooice.TabIndex = 121;
            this.lblSubscribeTypeChooice.Text = "????????";
            // 
            // gbTrainer
            // 
            this.gbTrainer.Controls.Add(this.lblTrainerChooice);
            this.gbTrainer.Location = new System.Drawing.Point(6, 196);
            this.gbTrainer.Name = "gbTrainer";
            this.gbTrainer.Size = new System.Drawing.Size(424, 113);
            this.gbTrainer.TabIndex = 118;
            this.gbTrainer.TabStop = false;
            this.gbTrainer.Text = "Trainer chooice";
            // 
            // lblTrainerChooice
            // 
            this.lblTrainerChooice.AutoSize = true;
            this.lblTrainerChooice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrainerChooice.Location = new System.Drawing.Point(143, 46);
            this.lblTrainerChooice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTrainerChooice.Name = "lblTrainerChooice";
            this.lblTrainerChooice.Size = new System.Drawing.Size(108, 25);
            this.lblTrainerChooice.TabIndex = 120;
            this.lblTrainerChooice.Text = "????????";
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = global::GymManagement.Properties.Resources.gymDateEnd;
            this.pictureBox14.Location = new System.Drawing.Point(-1, 125);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(31, 26);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox14.TabIndex = 115;
            this.pictureBox14.TabStop = false;
            // 
            // lblSubscribEndDate
            // 
            this.lblSubscribEndDate.AutoSize = true;
            this.lblSubscribEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubscribEndDate.Location = new System.Drawing.Point(6, 168);
            this.lblSubscribEndDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubscribEndDate.Name = "lblSubscribEndDate";
            this.lblSubscribEndDate.Size = new System.Drawing.Size(175, 29);
            this.lblSubscribEndDate.TabIndex = 117;
            this.lblSubscribEndDate.Text = "DD\\MM\\YYYY";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(29, 124);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(211, 25);
            this.label13.TabIndex = 116;
            this.label13.Text = "Subscribe Date End:";
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = global::GymManagement.Properties.Resources.gymDateStart;
            this.pictureBox13.Location = new System.Drawing.Point(-1, 28);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(31, 26);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox13.TabIndex = 113;
            this.pictureBox13.TabStop = false;
            // 
            // lblSubscribeStartDate
            // 
            this.lblSubscribeStartDate.AutoSize = true;
            this.lblSubscribeStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubscribeStartDate.Location = new System.Drawing.Point(6, 75);
            this.lblSubscribeStartDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubscribeStartDate.Name = "lblSubscribeStartDate";
            this.lblSubscribeStartDate.Size = new System.Drawing.Size(175, 29);
            this.lblSubscribeStartDate.TabIndex = 114;
            this.lblSubscribeStartDate.Text = "DD\\MM\\YYYY";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 27);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(219, 25);
            this.label8.TabIndex = 113;
            this.label8.Text = "Subscribe Date Start:";
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.btnAddNewAccount);
            this.gbFilters.Controls.Add(this.btnFind);
            this.gbFilters.Controls.Add(this.cbFilterBy);
            this.gbFilters.Controls.Add(this.txtFilterValue);
            this.gbFilters.Controls.Add(this.label1);
            this.gbFilters.Location = new System.Drawing.Point(6, 3);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(819, 77);
            this.gbFilters.TabIndex = 128;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filter";
            // 
            // btnAddNewAccount
            // 
            this.btnAddNewAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddNewAccount.Image = global::GymManagement.Properties.Resources.AddPerson_32;
            this.btnAddNewAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewAccount.Location = new System.Drawing.Point(695, 16);
            this.btnAddNewAccount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddNewAccount.Name = "btnAddNewAccount";
            this.btnAddNewAccount.Size = new System.Drawing.Size(44, 37);
            this.btnAddNewAccount.TabIndex = 21;
            this.btnAddNewAccount.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Image = global::GymManagement.Properties.Resources.SearchPerson;
            this.btnFind.Location = new System.Drawing.Point(625, 16);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(44, 37);
            this.btnFind.TabIndex = 18;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Account ID",
            "Person ID"});
            this.cbFilterBy.Location = new System.Drawing.Point(140, 25);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(210, 24);
            this.cbFilterBy.TabIndex = 16;
            // 
            // txtFilterValue
            // 
            this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterValue.Location = new System.Drawing.Point(370, 26);
            this.txtFilterValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFilterValue.Name = "txtFilterValue";
            this.txtFilterValue.Size = new System.Drawing.Size(214, 22);
            this.txtFilterValue.TabIndex = 17;
            this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
            this.txtFilterValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtFilterValue_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Find By:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(141, 439);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(174, 29);
            this.lblTotalAmount.TabIndex = 131;
            this.lblTotalAmount.Text = "Total Amount:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(4, 389);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 20);
            this.label14.TabIndex = 130;
            this.label14.Text = "Total Amount:";
            // 
            // lblIsPaid
            // 
            this.lblIsPaid.AutoSize = true;
            this.lblIsPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsPaid.Location = new System.Drawing.Point(715, 439);
            this.lblIsPaid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIsPaid.Name = "lblIsPaid";
            this.lblIsPaid.Size = new System.Drawing.Size(93, 29);
            this.lblIsPaid.TabIndex = 133;
            this.lblIsPaid.Text = "Is Paid";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsActive.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblIsActive.Location = new System.Drawing.Point(1118, 3);
            this.lblIsActive.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(101, 25);
            this.lblIsActive.TabIndex = 135;
            this.lblIsActive.Text = "Is Active ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pbIsActive
            // 
            this.pbIsActive.Image = global::GymManagement.Properties.Resources.Green_Light;
            this.pbIsActive.Location = new System.Drawing.Point(1256, 3);
            this.pbIsActive.Name = "pbIsActive";
            this.pbIsActive.Size = new System.Drawing.Size(100, 101);
            this.pbIsActive.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIsActive.TabIndex = 134;
            this.pbIsActive.TabStop = false;
            // 
            // pbIsPaid
            // 
            this.pbIsPaid.Image = global::GymManagement.Properties.Resources.checkedTruePaid;
            this.pbIsPaid.Location = new System.Drawing.Point(576, 422);
            this.pbIsPaid.Name = "pbIsPaid";
            this.pbIsPaid.Size = new System.Drawing.Size(78, 80);
            this.pbIsPaid.TabIndex = 132;
            this.pbIsPaid.TabStop = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.Image = global::GymManagement.Properties.Resources.money;
            this.pictureBox15.Location = new System.Drawing.Point(8, 422);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(64, 64);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox15.TabIndex = 129;
            this.pictureBox15.TabStop = false;
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(8, 84);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(890, 302);
            this.ctrlPersonCard1.TabIndex = 136;
            // 
            // ctrlFindSubscriber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.lblIsActive);
            this.Controls.Add(this.pbIsActive);
            this.Controls.Add(this.lblIsPaid);
            this.Controls.Add(this.pbIsPaid);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.pictureBox15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.lblAccountID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Name = "ctrlFindSubscriber";
            this.Size = new System.Drawing.Size(1356, 519);
            this.Load += new System.EventHandler(this.ctrlFindSubscriber_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbSubscribeType.ResumeLayout(false);
            this.gbSubscribeType.PerformLayout();
            this.gbTrainer.ResumeLayout(false);
            this.gbTrainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIsActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIsPaid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAccountID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbSubscribeType;
        private System.Windows.Forms.GroupBox gbTrainer;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Label lblSubscribEndDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.Label lblSubscribeStartDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Button btnAddNewAccount;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox txtFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pbIsPaid;
        private System.Windows.Forms.Label lblIsPaid;
        private System.Windows.Forms.PictureBox pbIsActive;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblSubscribeTypeChooice;
        private System.Windows.Forms.Label lblTrainerChooice;
        private ctrlPersonCard.ctrlPersonCard ctrlPersonCard1;
    }
}
