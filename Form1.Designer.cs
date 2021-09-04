namespace CrabMCSM
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.JavaRoute = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.选项 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出 = new System.Windows.Forms.ToolStripMenuItem();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton3 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton4 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton5 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DefaultJavaChosed = new MaterialSkin.Controls.MaterialRadioButton();
            this.UseYourOwnJava = new MaterialSkin.Controls.MaterialRadioButton();
            this.BypassZZ = new MaterialSkin.Controls.MaterialCheckBox();
            this.JavaFile = new MaterialSkin.Controls.MaterialRaisedButton();
            this.choosejava = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.materialRaisedButton6 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.选项.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Java 路径，如不选择则默认使用系统内优先级最高的 Java";
            // 
            // JavaRoute
            // 
            this.JavaRoute.Depth = 0;
            this.JavaRoute.Enabled = false;
            this.JavaRoute.Hint = "";
            this.JavaRoute.Location = new System.Drawing.Point(15, 279);
            this.JavaRoute.MouseState = MaterialSkin.MouseState.HOVER;
            this.JavaRoute.Name = "JavaRoute";
            this.JavaRoute.PasswordChar = '\0';
            this.JavaRoute.SelectedText = "";
            this.JavaRoute.SelectionLength = 0;
            this.JavaRoute.SelectionStart = 0;
            this.JavaRoute.Size = new System.Drawing.Size(631, 23);
            this.JavaRoute.TabIndex = 29;
            this.JavaRoute.Text = "你的 Java 路径（请去掉我）";
            this.toolTip1.SetToolTip(this.JavaRoute, "Java的路径，将会在启动时检验\r\n");
            this.JavaRoute.UseSystemPasswordChar = false;
            // 
            // materialSingleLineTextField1
            // 
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Hint = "";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(15, 413);
            this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(631, 23);
            this.materialSingleLineTextField1.TabIndex = 33;
            this.materialSingleLineTextField1.Text = "自定义Jar名称（不填即默认）";
            this.toolTip1.SetToolTip(this.materialSingleLineTextField1, "Java的路径，将会在启动时检验\r\n");
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.选项;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "CrabMCSM - 运行中";
            this.notifyIcon1.Visible = true;
            // 
            // 选项
            // 
            this.选项.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.选项.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出});
            this.选项.Name = "选项";
            this.选项.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.选项.Size = new System.Drawing.Size(101, 26);
            this.选项.Text = "选项";
            this.选项.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 退出
            // 
            this.退出.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.退出.Name = "退出";
            this.退出.Size = new System.Drawing.Size(100, 22);
            this.退出.Text = "退出";
            this.退出.Click += new System.EventHandler(this.退出_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.Black;
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDown1.ForeColor = System.Drawing.Color.White;
            this.numericUpDown1.Location = new System.Drawing.Point(86, 528);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(145, 17);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 529);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "最小内存值";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(233, 527);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "最大内存值";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BackColor = System.Drawing.Color.Black;
            this.numericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericUpDown2.ForeColor = System.Drawing.Color.White;
            this.numericUpDown2.Location = new System.Drawing.Point(307, 527);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(163, 17);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.Value = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.materialRaisedButton1.Location = new System.Drawing.Point(1065, 519);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(110, 37);
            this.materialRaisedButton1.TabIndex = 19;
            this.materialRaisedButton1.Text = "启动服务器";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click_1);
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.materialRaisedButton2.Location = new System.Drawing.Point(843, 519);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(110, 37);
            this.materialRaisedButton2.TabIndex = 20;
            this.materialRaisedButton2.Text = "重启服务器";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click_1);
            // 
            // materialRaisedButton3
            // 
            this.materialRaisedButton3.Depth = 0;
            this.materialRaisedButton3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.materialRaisedButton3.Location = new System.Drawing.Point(954, 519);
            this.materialRaisedButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton3.Name = "materialRaisedButton3";
            this.materialRaisedButton3.Primary = true;
            this.materialRaisedButton3.Size = new System.Drawing.Size(110, 37);
            this.materialRaisedButton3.TabIndex = 21;
            this.materialRaisedButton3.Text = "关闭服务器";
            this.materialRaisedButton3.UseVisualStyleBackColor = true;
            this.materialRaisedButton3.Click += new System.EventHandler(this.materialRaisedButton3_Click_1);
            // 
            // materialRaisedButton4
            // 
            this.materialRaisedButton4.Depth = 0;
            this.materialRaisedButton4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.materialRaisedButton4.Location = new System.Drawing.Point(1065, 439);
            this.materialRaisedButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton4.Name = "materialRaisedButton4";
            this.materialRaisedButton4.Primary = true;
            this.materialRaisedButton4.Size = new System.Drawing.Size(110, 37);
            this.materialRaisedButton4.TabIndex = 22;
            this.materialRaisedButton4.Text = "插件管理器";
            this.materialRaisedButton4.UseVisualStyleBackColor = true;
            this.materialRaisedButton4.Click += new System.EventHandler(this.materialRaisedButton4_Click_1);
            // 
            // materialRaisedButton5
            // 
            this.materialRaisedButton5.Depth = 0;
            this.materialRaisedButton5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.materialRaisedButton5.Location = new System.Drawing.Point(911, 439);
            this.materialRaisedButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton5.Name = "materialRaisedButton5";
            this.materialRaisedButton5.Primary = true;
            this.materialRaisedButton5.Size = new System.Drawing.Size(153, 37);
            this.materialRaisedButton5.TabIndex = 23;
            this.materialRaisedButton5.Text = "配置文件编辑器";
            this.materialRaisedButton5.UseVisualStyleBackColor = true;
            this.materialRaisedButton5.Click += new System.EventHandler(this.materialRaisedButton5_Click_1);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(11, 77);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(936, 18);
            this.materialLabel1.TabIndex = 24;
            this.materialLabel1.Text = "为了防止宿主机因分配内存过高崩溃，目前程序识别的最大内存值只有当前可用内存的一半（我也不知道这愚蠢的算法是怎么写的）";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "最大可分配的 Ram ：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(10, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "Java 的设置";
            // 
            // DefaultJavaChosed
            // 
            this.DefaultJavaChosed.AutoSize = true;
            this.DefaultJavaChosed.Depth = 0;
            this.DefaultJavaChosed.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DefaultJavaChosed.Location = new System.Drawing.Point(9, 198);
            this.DefaultJavaChosed.Margin = new System.Windows.Forms.Padding(0);
            this.DefaultJavaChosed.MouseLocation = new System.Drawing.Point(-1, -1);
            this.DefaultJavaChosed.MouseState = MaterialSkin.MouseState.HOVER;
            this.DefaultJavaChosed.Name = "DefaultJavaChosed";
            this.DefaultJavaChosed.Ripple = true;
            this.DefaultJavaChosed.Size = new System.Drawing.Size(152, 30);
            this.DefaultJavaChosed.TabIndex = 27;
            this.DefaultJavaChosed.TabStop = true;
            this.DefaultJavaChosed.Text = "使用系统默认 Java";
            this.DefaultJavaChosed.UseVisualStyleBackColor = true;
            this.DefaultJavaChosed.CheckedChanged += new System.EventHandler(this.DefaultJavaChosed_CheckedChanged);
            // 
            // UseYourOwnJava
            // 
            this.UseYourOwnJava.AutoSize = true;
            this.UseYourOwnJava.Depth = 0;
            this.UseYourOwnJava.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UseYourOwnJava.Location = new System.Drawing.Point(9, 228);
            this.UseYourOwnJava.Margin = new System.Windows.Forms.Padding(0);
            this.UseYourOwnJava.MouseLocation = new System.Drawing.Point(-1, -1);
            this.UseYourOwnJava.MouseState = MaterialSkin.MouseState.HOVER;
            this.UseYourOwnJava.Name = "UseYourOwnJava";
            this.UseYourOwnJava.Ripple = true;
            this.UseYourOwnJava.Size = new System.Drawing.Size(122, 30);
            this.UseYourOwnJava.TabIndex = 28;
            this.UseYourOwnJava.TabStop = true;
            this.UseYourOwnJava.Text = "另外指定 Java";
            this.UseYourOwnJava.UseVisualStyleBackColor = true;
            this.UseYourOwnJava.CheckedChanged += new System.EventHandler(this.UseYourOwnJava_CheckedChanged);
            // 
            // BypassZZ
            // 
            this.BypassZZ.AutoSize = true;
            this.BypassZZ.Depth = 0;
            this.BypassZZ.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BypassZZ.Location = new System.Drawing.Point(9, 328);
            this.BypassZZ.Margin = new System.Windows.Forms.Padding(0);
            this.BypassZZ.MouseLocation = new System.Drawing.Point(-1, -1);
            this.BypassZZ.MouseState = MaterialSkin.MouseState.HOVER;
            this.BypassZZ.Name = "BypassZZ";
            this.BypassZZ.Ripple = true;
            this.BypassZZ.Size = new System.Drawing.Size(408, 30);
            this.BypassZZ.TabIndex = 30;
            this.BypassZZ.Text = "绕过智障算法，强制开启超过内存可用数值一半的服务器";
            this.BypassZZ.UseVisualStyleBackColor = true;
            this.BypassZZ.CheckedChanged += new System.EventHandler(this.BypassZZ_CheckedChanged);
            // 
            // JavaFile
            // 
            this.JavaFile.Depth = 0;
            this.JavaFile.Location = new System.Drawing.Point(652, 275);
            this.JavaFile.MouseState = MaterialSkin.MouseState.HOVER;
            this.JavaFile.Name = "JavaFile";
            this.JavaFile.Primary = true;
            this.JavaFile.Size = new System.Drawing.Size(80, 31);
            this.JavaFile.TabIndex = 31;
            this.JavaFile.Text = "Open...";
            this.JavaFile.UseVisualStyleBackColor = true;
            this.JavaFile.Click += new System.EventHandler(this.JavaFile_Click);
            // 
            // choosejava
            // 
            this.choosejava.DefaultExt = "exe";
            this.choosejava.Filter = "应用程序|*.exe";
            this.choosejava.Title = "选择Java环境";
            this.choosejava.FileOk += new System.ComponentModel.CancelEventHandler(this.choosejava_FileOk);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.ForeColor = System.Drawing.Color.LightGray;
            this.groupBox1.Location = new System.Drawing.Point(755, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 259);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "版本公告 版本：null";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(8, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "null";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(15, 572);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "null";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(908, 572);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(266, 17);
            this.label7.TabIndex = 35;
            this.label7.Text = "©2019-2021 Crab Studio.All rights reserved.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // materialRaisedButton6
            // 
            this.materialRaisedButton6.Depth = 0;
            this.materialRaisedButton6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.materialRaisedButton6.Location = new System.Drawing.Point(1074, 382);
            this.materialRaisedButton6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton6.Name = "materialRaisedButton6";
            this.materialRaisedButton6.Primary = true;
            this.materialRaisedButton6.Size = new System.Drawing.Size(101, 37);
            this.materialRaisedButton6.TabIndex = 36;
            this.materialRaisedButton6.Text = "内网映射";
            this.materialRaisedButton6.UseVisualStyleBackColor = true;
            this.materialRaisedButton6.Click += new System.EventHandler(this.materialRaisedButton6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1187, 598);
            this.Controls.Add(this.materialRaisedButton6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.materialSingleLineTextField1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.JavaFile);
            this.Controls.Add(this.BypassZZ);
            this.Controls.Add(this.JavaRoute);
            this.Controls.Add(this.UseYourOwnJava);
            this.Controls.Add(this.DefaultJavaChosed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.materialRaisedButton5);
            this.Controls.Add(this.materialRaisedButton4);
            this.Controls.Add(this.materialRaisedButton3);
            this.Controls.Add(this.materialRaisedButton2);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(1187, 598);
            this.MinimumSize = new System.Drawing.Size(1187, 598);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrabSS | Crab MC Server Starter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.选项.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip 选项;
        private System.Windows.Forms.ToolStripMenuItem 退出;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton3;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton4;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton5;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialRadioButton DefaultJavaChosed;
        private MaterialSkin.Controls.MaterialRadioButton UseYourOwnJava;
        private MaterialSkin.Controls.MaterialSingleLineTextField JavaRoute;
        private MaterialSkin.Controls.MaterialCheckBox BypassZZ;
        private MaterialSkin.Controls.MaterialRaisedButton JavaFile;
        private System.Windows.Forms.OpenFileDialog choosejava;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton6;
    }
}

