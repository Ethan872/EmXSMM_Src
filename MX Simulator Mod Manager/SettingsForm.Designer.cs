namespace MX_Simulator_Mod_Manager
{
    partial class SettingsForm
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
            this.monoFlat_ThemeContainer1 = new MonoFlat.MonoFlat_ThemeContainer();
            this.notiBox = new MonoFlat.MonoFlat_NotificationBox();
            this.browseBtn = new MonoFlat.MonoFlat_Button();
            this.mxsDirTbox = new MonoFlat.MonoFlat_TextBox();
            this.settingsCloseBtn = new MonoFlat.MonoFlat_Button();
            this.monoFlat_ThemeContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monoFlat_ThemeContainer1
            // 
            this.monoFlat_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.monoFlat_ThemeContainer1.Controls.Add(this.notiBox);
            this.monoFlat_ThemeContainer1.Controls.Add(this.browseBtn);
            this.monoFlat_ThemeContainer1.Controls.Add(this.mxsDirTbox);
            this.monoFlat_ThemeContainer1.Controls.Add(this.settingsCloseBtn);
            this.monoFlat_ThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monoFlat_ThemeContainer1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.monoFlat_ThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.monoFlat_ThemeContainer1.Name = "monoFlat_ThemeContainer1";
            this.monoFlat_ThemeContainer1.Padding = new System.Windows.Forms.Padding(10, 70, 10, 9);
            this.monoFlat_ThemeContainer1.RoundCorners = true;
            this.monoFlat_ThemeContainer1.Sizable = true;
            this.monoFlat_ThemeContainer1.Size = new System.Drawing.Size(707, 167);
            this.monoFlat_ThemeContainer1.SmartBounds = true;
            this.monoFlat_ThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.monoFlat_ThemeContainer1.TabIndex = 0;
            this.monoFlat_ThemeContainer1.Text = "Settings";
            // 
            // notiBox
            // 
            this.notiBox.BorderCurve = 8;
            this.notiBox.Font = new System.Drawing.Font("Tahoma", 9F);
            this.notiBox.Image = null;
            this.notiBox.Location = new System.Drawing.Point(275, 12);
            this.notiBox.MinimumSize = new System.Drawing.Size(100, 40);
            this.notiBox.Name = "notiBox";
            this.notiBox.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Error;
            this.notiBox.RoundCorners = false;
            this.notiBox.ShowCloseButton = false;
            this.notiBox.Size = new System.Drawing.Size(267, 40);
            this.notiBox.TabIndex = 3;
            this.notiBox.Text = "No directory selected!";
            this.notiBox.Visible = false;
            // 
            // browseBtn
            // 
            this.browseBtn.BackColor = System.Drawing.Color.Transparent;
            this.browseBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseBtn.Image = null;
            this.browseBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.browseBtn.Location = new System.Drawing.Point(548, 88);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(146, 41);
            this.browseBtn.TabIndex = 2;
            this.browseBtn.Text = "...";
            this.browseBtn.TextAlignment = System.Drawing.StringAlignment.Center;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // mxsDirTbox
            // 
            this.mxsDirTbox.BackColor = System.Drawing.Color.Transparent;
            this.mxsDirTbox.Font = new System.Drawing.Font("Tahoma", 11F);
            this.mxsDirTbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(183)))), ((int)(((byte)(191)))));
            this.mxsDirTbox.Image = null;
            this.mxsDirTbox.Location = new System.Drawing.Point(13, 88);
            this.mxsDirTbox.MaxLength = 32767;
            this.mxsDirTbox.Multiline = false;
            this.mxsDirTbox.Name = "mxsDirTbox";
            this.mxsDirTbox.ReadOnly = false;
            this.mxsDirTbox.Size = new System.Drawing.Size(529, 41);
            this.mxsDirTbox.TabIndex = 1;
            this.mxsDirTbox.Text = "MX Simulator Directory";
            this.mxsDirTbox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.mxsDirTbox.UseSystemPasswordChar = false;
            // 
            // settingsCloseBtn
            // 
            this.settingsCloseBtn.BackColor = System.Drawing.Color.Transparent;
            this.settingsCloseBtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.settingsCloseBtn.Image = null;
            this.settingsCloseBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsCloseBtn.Location = new System.Drawing.Point(548, 12);
            this.settingsCloseBtn.Name = "settingsCloseBtn";
            this.settingsCloseBtn.Size = new System.Drawing.Size(146, 41);
            this.settingsCloseBtn.TabIndex = 0;
            this.settingsCloseBtn.Text = "Save & Close";
            this.settingsCloseBtn.TextAlignment = System.Drawing.StringAlignment.Center;
            this.settingsCloseBtn.Click += new System.EventHandler(this.settingsCloseBtn_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 167);
            this.Controls.Add(this.monoFlat_ThemeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.monoFlat_ThemeContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MonoFlat.MonoFlat_ThemeContainer monoFlat_ThemeContainer1;
        private MonoFlat.MonoFlat_Button browseBtn;
        private MonoFlat.MonoFlat_TextBox mxsDirTbox;
        private MonoFlat.MonoFlat_Button settingsCloseBtn;
        public MonoFlat.MonoFlat_NotificationBox notiBox;
    }
}