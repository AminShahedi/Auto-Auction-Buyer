namespace AHAB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            checkBox1 = new CheckBox();
            numericUpDown1 = new NumericUpDown();
            groupBox1 = new GroupBox();
            label5 = new Label();
            silverTextBox = new MaskedTextBox();
            goldTextBox = new MaskedTextBox();
            maskedTextBox2 = new MaskedTextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            richTextBox1 = new RichTextBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            label7 = new Label();
            label3 = new Label();
            label6 = new Label();
            groupBox4 = new GroupBox();
            label12 = new Label();
            label4 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            groupBox6 = new GroupBox();
            groupBox5 = new GroupBox();
            numericUpDown2 = new NumericUpDown();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Goldenrod;
            label1.Location = new Point(2, 19);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(28, 19);
            label1.TabIndex = 2;
            label1.Text = "\U0001fa99";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.Location = new Point(8, 23);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(61, 17);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Renew";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown1.Location = new Point(73, 20);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(38, 22);
            numericUpDown1.TabIndex = 5;
            numericUpDown1.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(silverTextBox);
            groupBox1.Controls.Add(goldTextBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(8, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(117, 48);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Max Price";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.GradientActiveCaption;
            label5.Location = new Point(54, 19);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(28, 19);
            label5.TabIndex = 10;
            label5.Text = "\U0001fa99";
            // 
            // silverTextBox
            // 
            silverTextBox.AccessibleName = "silvertextbox";
            silverTextBox.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            silverTextBox.Location = new Point(82, 18);
            silverTextBox.Name = "silverTextBox";
            silverTextBox.Size = new Size(25, 22);
            silverTextBox.TabIndex = 9;
            silverTextBox.Text = "23";
            silverTextBox.TextAlign = HorizontalAlignment.Center;
            silverTextBox.TextChanged += silver_textChange;
            // 
            // goldTextBox
            // 
            goldTextBox.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            goldTextBox.Location = new Point(29, 18);
            goldTextBox.Name = "goldTextBox";
            goldTextBox.Size = new Size(25, 22);
            goldTextBox.TabIndex = 6;
            goldTextBox.Text = "01";
            goldTextBox.TextAlign = HorizontalAlignment.Center;
            goldTextBox.ValidatingType = typeof(int);
            goldTextBox.TextChanged += textbox1_textChange;
            // 
            // maskedTextBox2
            // 
            maskedTextBox2.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            maskedTextBox2.Location = new Point(11, 17);
            maskedTextBox2.Name = "maskedTextBox2";
            maskedTextBox2.Size = new Size(34, 22);
            maskedTextBox2.TabIndex = 8;
            maskedTextBox2.Text = "1000";
            maskedTextBox2.TextChanged += maskedTextBox2_TextChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(258, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            richTextBox1.Size = new Size(169, 140);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(390, 1);
            label2.Name = "label2";
            label2.Size = new Size(26, 12);
            label2.TabIndex = 7;
            label2.Text = "Clear";
            label2.Click += label2_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(maskedTextBox2);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox2.Location = new Point(8, 53);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(53, 46);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Delay";
            groupBox2.MouseHover += groupBoxDelay_MouseHover;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(checkBox1);
            groupBox3.Controls.Add(numericUpDown1);
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox3.Location = new Point(8, 99);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(241, 53);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Bait";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(129, 15);
            label7.Name = "label7";
            label7.Size = new Size(70, 15);
            label7.TabIndex = 15;
            label7.Text = "Renewed : 0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(129, 30);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 13;
            label3.Text = "Counter :  0/10";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(6, 17);
            label6.Name = "label6";
            label6.Size = new Size(77, 15);
            label6.TabIndex = 14;
            label6.Text = "Purchased : 0";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(label10);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(label8);
            groupBox4.Controls.Add(label6);
            groupBox4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox4.Location = new Point(131, 6);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(118, 94);
            groupBox4.TabIndex = 16;
            groupBox4.TabStop = false;
            groupBox4.Text = "Log";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label12.ForeColor = Color.Goldenrod;
            label12.Location = new Point(42, 34);
            label12.Margin = new Padding(0);
            label12.Name = "label12";
            label12.Size = new Size(19, 15);
            label12.TabIndex = 11;
            label12.Text = "\U0001fa99";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(6, 34);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 21;
            label4.Text = "Profit : ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.DarkGoldenrod;
            label11.Location = new Point(58, 34);
            label11.Name = "label11";
            label11.Size = new Size(36, 15);
            label11.TabIndex = 20;
            label11.Text = "1,235";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(6, 52);
            label10.Name = "label10";
            label10.Size = new Size(48, 15);
            label10.TabIndex = 19;
            label10.Text = "GPM : 0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.Highlight;
            label9.Location = new Point(66, 71);
            label9.Name = "label9";
            label9.Size = new Size(40, 15);
            label9.TabIndex = 18;
            label9.Text = "0m 0s";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(6, 70);
            label8.Name = "label8";
            label8.Size = new Size(65, 15);
            label8.TabIndex = 17;
            label8.Text = "Total time :";
            // 
            // groupBox6
            // 
            groupBox6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox6.Location = new Point(64, 202);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(118, 53);
            groupBox6.TabIndex = 21;
            groupBox6.TabStop = false;
            groupBox6.Text = "Bait Log";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(numericUpDown2);
            groupBox5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox5.Location = new Point(71, 54);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(53, 46);
            groupBox5.TabIndex = 11;
            groupBox5.TabStop = false;
            groupBox5.Text = "Min";
            groupBox5.MouseHover += groupBox5_MouseHover;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown2.Location = new Point(9, 16);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(38, 22);
            numericUpDown2.TabIndex = 6;
            numericUpDown2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 157);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(label2);
            Controls.Add(richTextBox1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.Manual;
            Text = "Auto Auction Buyer";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private CheckBox checkBox1;
        private NumericUpDown numericUpDown1;
        private GroupBox groupBox1;
        private MaskedTextBox goldTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private RichTextBox richTextBox1;
        private Label label2;
        private MaskedTextBox maskedTextBox2;
        private MaskedTextBox silverTextBox;
        private Label label5;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label3;
        private Label label6;
        private Label label7;
        private GroupBox groupBox4;
        private Label label9;
        private Label label8;
        private GroupBox groupBox5;
        private NumericUpDown numericUpDown2;
        private Label label10;
        private Label label11;
        private ToolTip toolTip1;
        private GroupBox groupBox6;
        private Label label12;
        private Label label4;
    }
}