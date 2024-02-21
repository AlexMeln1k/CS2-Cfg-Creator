namespace Counter_StrikeCfgCreator
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnChangeDirectory = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCreateConfig = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.chkJumpThrow = new System.Windows.Forms.CheckBox();
            this.chkBob = new System.Windows.Forms.CheckBox();
            this.chkOptimization = new System.Windows.Forms.CheckBox();
            this.chkSayHello = new System.Windows.Forms.CheckBox();
            this.btnJumpThrowHint = new System.Windows.Forms.Button();
            this.btnNewBobHint = new System.Windows.Forms.Button();
            this.btnOptimizeHint = new System.Windows.Forms.Button();
            this.btnShaderScopeHint = new System.Windows.Forms.Button();
            this.txtEnterKeyJumpThrow = new System.Windows.Forms.TextBox();
            this.btnSetKeyForJumpThrow = new System.Windows.Forms.Button();
            this.btnDisTracesHint = new System.Windows.Forms.Button();
            this.ChkDisGunfireTraces = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnChangeDirectory
            // 
            this.btnChangeDirectory.Location = new System.Drawing.Point(12, 12);
            this.btnChangeDirectory.Name = "btnChangeDirectory";
            this.btnChangeDirectory.Size = new System.Drawing.Size(42, 28);
            this.btnChangeDirectory.TabIndex = 0;
            this.btnChangeDirectory.Text = "...";
            this.btnChangeDirectory.UseVisualStyleBackColor = true;
            this.btnChangeDirectory.Click += new System.EventHandler(this.btnChangeDirectory_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(54, 13);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.ReadOnly = true;
            this.txtDirectory.Size = new System.Drawing.Size(332, 26);
            this.txtDirectory.TabIndex = 1;
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.Location = new System.Drawing.Point(12, 58);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(219, 24);
            this.chk1.TabIndex = 5;
            this.chk1.Text = "cs2_machine_convars.vcfg";
            this.chk1.UseVisualStyleBackColor = true;
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.Location = new System.Drawing.Point(12, 84);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(251, 24);
            this.chk2.TabIndex = 6;
            this.chk2.Text = "cs2_user_convars_0_slot0.vcfg";
            this.chk2.UseVisualStyleBackColor = true;
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.Location = new System.Drawing.Point(12, 110);
            this.chk3.Name = "chk3";
            this.chk3.Size = new System.Drawing.Size(228, 24);
            this.chk3.TabIndex = 7;
            this.chk3.Text = "cs2_user_keys_0_slot0.vcfg";
            this.chk3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 10;
            // 
            // btnCreateConfig
            // 
            this.btnCreateConfig.Location = new System.Drawing.Point(12, 349);
            this.btnCreateConfig.Name = "btnCreateConfig";
            this.btnCreateConfig.Size = new System.Drawing.Size(94, 28);
            this.btnCreateConfig.TabIndex = 13;
            this.btnCreateConfig.Text = "Create";
            this.btnCreateConfig.UseVisualStyleBackColor = true;
            this.btnCreateConfig.Click += new System.EventHandler(this.btnCreateConfig_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 22);
            this.label5.TabIndex = 15;
            this.label5.Text = "Improve Config";
            // 
            // chkJumpThrow
            // 
            this.chkJumpThrow.AutoSize = true;
            this.chkJumpThrow.Location = new System.Drawing.Point(42, 177);
            this.chkJumpThrow.Name = "chkJumpThrow";
            this.chkJumpThrow.Size = new System.Drawing.Size(110, 24);
            this.chkJumpThrow.TabIndex = 16;
            this.chkJumpThrow.Text = "JumpThrow";
            this.chkJumpThrow.UseVisualStyleBackColor = true;
            this.chkJumpThrow.CheckedChanged += new System.EventHandler(this.chkJumpThrow_CheckedChanged);
            // 
            // chkBob
            // 
            this.chkBob.AutoSize = true;
            this.chkBob.Location = new System.Drawing.Point(42, 207);
            this.chkBob.Name = "chkBob";
            this.chkBob.Size = new System.Drawing.Size(149, 24);
            this.chkBob.TabIndex = 17;
            this.chkBob.Text = "Disable New Bob";
            this.chkBob.UseVisualStyleBackColor = true;
            // 
            // chkOptimization
            // 
            this.chkOptimization.AutoSize = true;
            this.chkOptimization.Location = new System.Drawing.Point(42, 237);
            this.chkOptimization.Name = "chkOptimization";
            this.chkOptimization.Size = new System.Drawing.Size(151, 24);
            this.chkOptimization.TabIndex = 18;
            this.chkOptimization.Text = "CS2 Optimization";
            this.chkOptimization.UseVisualStyleBackColor = true;
            this.chkOptimization.CheckedChanged += new System.EventHandler(this.chkOptimization_CheckedChanged);
            // 
            // chkSayHello
            // 
            this.chkSayHello.AutoSize = true;
            this.chkSayHello.Location = new System.Drawing.Point(42, 267);
            this.chkSayHello.Name = "chkSayHello";
            this.chkSayHello.Size = new System.Drawing.Size(139, 24);
            this.chkSayHello.TabIndex = 19;
            this.chkSayHello.Text = "Hello in console";
            this.chkSayHello.UseVisualStyleBackColor = true;
            // 
            // btnJumpThrowHint
            // 
            this.btnJumpThrowHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJumpThrowHint.Location = new System.Drawing.Point(12, 177);
            this.btnJumpThrowHint.Name = "btnJumpThrowHint";
            this.btnJumpThrowHint.Size = new System.Drawing.Size(24, 23);
            this.btnJumpThrowHint.TabIndex = 20;
            this.btnJumpThrowHint.Text = "?";
            this.btnJumpThrowHint.UseVisualStyleBackColor = true;
            this.btnJumpThrowHint.Click += new System.EventHandler(this.btnJumpThrowHint_Click);
            // 
            // btnNewBobHint
            // 
            this.btnNewBobHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewBobHint.Location = new System.Drawing.Point(12, 206);
            this.btnNewBobHint.Name = "btnNewBobHint";
            this.btnNewBobHint.Size = new System.Drawing.Size(24, 23);
            this.btnNewBobHint.TabIndex = 21;
            this.btnNewBobHint.Text = "?";
            this.btnNewBobHint.UseVisualStyleBackColor = true;
            this.btnNewBobHint.Click += new System.EventHandler(this.btnNewBobHint_Click);
            // 
            // btnOptimizeHint
            // 
            this.btnOptimizeHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptimizeHint.Location = new System.Drawing.Point(12, 238);
            this.btnOptimizeHint.Name = "btnOptimizeHint";
            this.btnOptimizeHint.Size = new System.Drawing.Size(24, 23);
            this.btnOptimizeHint.TabIndex = 22;
            this.btnOptimizeHint.Text = "?";
            this.btnOptimizeHint.UseVisualStyleBackColor = true;
            this.btnOptimizeHint.Click += new System.EventHandler(this.btnOptimizeHint_Click);
            // 
            // btnShaderScopeHint
            // 
            this.btnShaderScopeHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShaderScopeHint.Location = new System.Drawing.Point(12, 268);
            this.btnShaderScopeHint.Name = "btnShaderScopeHint";
            this.btnShaderScopeHint.Size = new System.Drawing.Size(24, 23);
            this.btnShaderScopeHint.TabIndex = 23;
            this.btnShaderScopeHint.Text = "?";
            this.btnShaderScopeHint.UseVisualStyleBackColor = true;
            this.btnShaderScopeHint.Click += new System.EventHandler(this.btnShaderScopeHint_Click);
            // 
            // txtEnterKeyJumpThrow
            // 
            this.txtEnterKeyJumpThrow.Location = new System.Drawing.Point(282, 176);
            this.txtEnterKeyJumpThrow.Name = "txtEnterKeyJumpThrow";
            this.txtEnterKeyJumpThrow.ReadOnly = true;
            this.txtEnterKeyJumpThrow.Size = new System.Drawing.Size(104, 26);
            this.txtEnterKeyJumpThrow.TabIndex = 25;
            // 
            // btnSetKeyForJumpThrow
            // 
            this.btnSetKeyForJumpThrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetKeyForJumpThrow.Location = new System.Drawing.Point(192, 176);
            this.btnSetKeyForJumpThrow.Name = "btnSetKeyForJumpThrow";
            this.btnSetKeyForJumpThrow.Size = new System.Drawing.Size(84, 26);
            this.btnSetKeyForJumpThrow.TabIndex = 26;
            this.btnSetKeyForJumpThrow.Text = "Set key";
            this.btnSetKeyForJumpThrow.UseVisualStyleBackColor = true;
            this.btnSetKeyForJumpThrow.Click += new System.EventHandler(this.btnSetKeyForJumpThrow_Click);
            // 
            // btnDisTracesHint
            // 
            this.btnDisTracesHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisTracesHint.Location = new System.Drawing.Point(12, 298);
            this.btnDisTracesHint.Name = "btnDisTracesHint";
            this.btnDisTracesHint.Size = new System.Drawing.Size(24, 23);
            this.btnDisTracesHint.TabIndex = 28;
            this.btnDisTracesHint.Text = "?";
            this.btnDisTracesHint.UseVisualStyleBackColor = true;
            this.btnDisTracesHint.Click += new System.EventHandler(this.btnDisTracesHint_Click);
            // 
            // ChkDisGunfireTraces
            // 
            this.ChkDisGunfireTraces.AutoSize = true;
            this.ChkDisGunfireTraces.Location = new System.Drawing.Point(42, 297);
            this.ChkDisGunfireTraces.Name = "ChkDisGunfireTraces";
            this.ChkDisGunfireTraces.Size = new System.Drawing.Size(194, 24);
            this.ChkDisGunfireTraces.TabIndex = 27;
            this.ChkDisGunfireTraces.Text = "Disabling gunfire traces";
            this.ChkDisGunfireTraces.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 389);
            this.Controls.Add(this.btnDisTracesHint);
            this.Controls.Add(this.ChkDisGunfireTraces);
            this.Controls.Add(this.btnSetKeyForJumpThrow);
            this.Controls.Add(this.txtEnterKeyJumpThrow);
            this.Controls.Add(this.btnShaderScopeHint);
            this.Controls.Add(this.btnOptimizeHint);
            this.Controls.Add(this.btnNewBobHint);
            this.Controls.Add(this.btnJumpThrowHint);
            this.Controls.Add(this.chkSayHello);
            this.Controls.Add(this.chkOptimization);
            this.Controls.Add(this.chkBob);
            this.Controls.Add(this.chkJumpThrow);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCreateConfig);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chk3);
            this.Controls.Add(this.chk2);
            this.Controls.Add(this.chk1);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.btnChangeDirectory);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "CFG Creator (CS2) V 0.0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing_1);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangeDirectory;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.CheckBox chk1;
        private System.Windows.Forms.CheckBox chk2;
        private System.Windows.Forms.CheckBox chk3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreateConfig;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkJumpThrow;
        private System.Windows.Forms.CheckBox chkBob;
        private System.Windows.Forms.CheckBox chkOptimization;
        private System.Windows.Forms.CheckBox chkSayHello;
        private System.Windows.Forms.Button btnJumpThrowHint;
        private System.Windows.Forms.Button btnNewBobHint;
        private System.Windows.Forms.Button btnOptimizeHint;
        private System.Windows.Forms.Button btnShaderScopeHint;
        private System.Windows.Forms.TextBox txtEnterKeyJumpThrow;
        private System.Windows.Forms.Button btnSetKeyForJumpThrow;
        private System.Windows.Forms.Button btnDisTracesHint;
        private System.Windows.Forms.CheckBox ChkDisGunfireTraces;
    }
}

