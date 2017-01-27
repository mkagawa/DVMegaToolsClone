namespace DVMegaToolsClone
{
    partial class DVMegaToolsClone
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comPort = new System.Windows.Forms.ComboBox();
            this.myCall = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.myCall2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rpt1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rpt2 = new System.Windows.Forms.TextBox();
            this.write = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.yourCall = new System.Windows.Forms.TextBox();
            this.logOutputBox = new System.Windows.Forms.ListBox();
            this.rxInvert = new System.Windows.Forms.CheckBox();
            this.txInvert = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comPort);
            this.groupBox1.Location = new System.Drawing.Point(26, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 57);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Communication Port for Arduino USB";
            // 
            // comPort
            // 
            this.comPort.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comPort.FormattingEnabled = true;
            this.comPort.Location = new System.Drawing.Point(246, 20);
            this.comPort.Name = "comPort";
            this.comPort.Size = new System.Drawing.Size(126, 23);
            this.comPort.TabIndex = 1;
            this.comPort.SelectedIndexChanged += new System.EventHandler(this.comPort_SelectedIndexChanged);
            // 
            // myCall
            // 
            this.myCall.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.myCall.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myCall.Location = new System.Drawing.Point(272, 122);
            this.myCall.MaxLength = 8;
            this.myCall.Name = "myCall";
            this.myCall.Size = new System.Drawing.Size(126, 21);
            this.myCall.TabIndex = 3;
            this.myCall.TextChanged += new System.EventHandler(this.myCall_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "My Call Sign";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Short Msg (max 4 characters)";
            // 
            // myCall2
            // 
            this.myCall2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myCall2.Location = new System.Drawing.Point(272, 162);
            this.myCall2.MaxLength = 4;
            this.myCall2.Name = "myCall2";
            this.myCall2.Size = new System.Drawing.Size(126, 21);
            this.myCall2.TabIndex = 4;
            this.myCall2.WordWrap = false;
            this.myCall2.TextChanged += new System.EventHandler(this.myCall2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Repeater 1";
            // 
            // rpt1
            // 
            this.rpt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.rpt1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rpt1.Location = new System.Drawing.Point(272, 202);
            this.rpt1.MaxLength = 8;
            this.rpt1.Name = "rpt1";
            this.rpt1.Size = new System.Drawing.Size(126, 21);
            this.rpt1.TabIndex = 5;
            this.rpt1.WordWrap = false;
            this.rpt1.TextChanged += new System.EventHandler(this.rpt1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Repeater 2 (GW)";
            // 
            // rpt2
            // 
            this.rpt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.rpt2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rpt2.Location = new System.Drawing.Point(272, 242);
            this.rpt2.MaxLength = 8;
            this.rpt2.Name = "rpt2";
            this.rpt2.Size = new System.Drawing.Size(126, 21);
            this.rpt2.TabIndex = 6;
            this.rpt2.WordWrap = false;
            this.rpt2.TextChanged += new System.EventHandler(this.rpt2_TextChanged);
            // 
            // write
            // 
            this.write.Location = new System.Drawing.Point(272, 293);
            this.write.Name = "write";
            this.write.Size = new System.Drawing.Size(126, 23);
            this.write.TabIndex = 7;
            this.write.Text = "Write to EEPROM";
            this.write.UseVisualStyleBackColor = true;
            this.write.Click += new System.EventHandler(this.write_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(105, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Your Call Sign";
            // 
            // yourCall
            // 
            this.yourCall.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.yourCall.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yourCall.Location = new System.Drawing.Point(272, 82);
            this.yourCall.MaxLength = 8;
            this.yourCall.Name = "yourCall";
            this.yourCall.Size = new System.Drawing.Size(126, 21);
            this.yourCall.TabIndex = 2;
            this.yourCall.Text = "CQCQCQ";
            this.yourCall.WordWrap = false;
            this.yourCall.TextChanged += new System.EventHandler(this.yourCall_TextChanged);
            // 
            // logOutputBox
            // 
            this.logOutputBox.Enabled = false;
            this.logOutputBox.FormattingEnabled = true;
            this.logOutputBox.Location = new System.Drawing.Point(26, 333);
            this.logOutputBox.Name = "logOutputBox";
            this.logOutputBox.Size = new System.Drawing.Size(372, 56);
            this.logOutputBox.TabIndex = 14;
            this.logOutputBox.UseTabStops = false;
            // 
            // rxInvert
            // 
            this.rxInvert.AutoSize = true;
            this.rxInvert.Location = new System.Drawing.Point(26, 293);
            this.rxInvert.Name = "rxInvert";
            this.rxInvert.Size = new System.Drawing.Size(70, 17);
            this.rxInvert.TabIndex = 15;
            this.rxInvert.Text = "RX invert";
            this.rxInvert.UseVisualStyleBackColor = true;
            // 
            // txInvert
            // 
            this.txInvert.AutoSize = true;
            this.txInvert.Location = new System.Drawing.Point(108, 293);
            this.txInvert.Name = "txInvert";
            this.txInvert.Size = new System.Drawing.Size(70, 17);
            this.txInvert.TabIndex = 16;
            this.txInvert.Text = "TX Invert";
            this.txInvert.UseVisualStyleBackColor = true;
            // 
            // DVMegaToolsClone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 404);
            this.Controls.Add(this.txInvert);
            this.Controls.Add(this.rxInvert);
            this.Controls.Add(this.logOutputBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.yourCall);
            this.Controls.Add(this.write);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rpt2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rpt1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.myCall2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myCall);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(449, 443);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(449, 443);
            this.Name = "DVMegaToolsClone";
            this.Text = "DVMega Tool Clone (by NW6UP)";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox myCall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox myCall2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox rpt1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox rpt2;
        private System.Windows.Forms.Button write;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox yourCall;
        private System.Windows.Forms.ComboBox comPort;
        private System.Windows.Forms.ListBox logOutputBox;
        private System.Windows.Forms.CheckBox rxInvert;
        private System.Windows.Forms.CheckBox txInvert;
    }
}

