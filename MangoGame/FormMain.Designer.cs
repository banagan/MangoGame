namespace MangoGame
{
    partial class FormMain
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
            this.lvwGameList = new System.Windows.Forms.ListView();
            this.lvwUserList = new System.Windows.Forms.ListView();
            this.listView3 = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwGameList
            // 
            this.lvwGameList.Location = new System.Drawing.Point(33, 24);
            this.lvwGameList.Name = "lvwGameList";
            this.lvwGameList.Size = new System.Drawing.Size(96, 507);
            this.lvwGameList.TabIndex = 0;
            this.lvwGameList.UseCompatibleStateImageBehavior = false;
            // 
            // lvwUserList
            // 
            this.lvwUserList.Location = new System.Drawing.Point(636, 24);
            this.lvwUserList.Name = "lvwUserList";
            this.lvwUserList.Size = new System.Drawing.Size(124, 507);
            this.lvwUserList.TabIndex = 1;
            this.lvwUserList.UseCompatibleStateImageBehavior = false;
            // 
            // listView3
            // 
            this.listView3.Location = new System.Drawing.Point(167, 24);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(434, 377);
            this.listView3.TabIndex = 2;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(167, 419);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 112);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 537);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "加入房间测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.lvwUserList);
            this.Controls.Add(this.lvwGameList);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwGameList;
        private System.Windows.Forms.ListView lvwUserList;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;

    }
}