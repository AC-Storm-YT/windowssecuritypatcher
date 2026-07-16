namespace Windows_Security_Patcher
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picBackground;
        private MaterialSkin.Controls.MaterialButton btnKSHSP;
        private MaterialSkin.Controls.MaterialButton btnDisableKSHSP;
        private MaterialSkin.Controls.MaterialButton btnHVCI;
        private MaterialSkin.Controls.MaterialButton btnDisableHVCI;
        // Added the new button here
        private MaterialSkin.Controls.MaterialButton btnCheckDrivers;
        private System.Windows.Forms.Panel pnlConsole;
        private System.Windows.Forms.TextBox txtConsole;
        private MaterialSkin.Controls.MaterialButton btnCloseConsole;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnKSHSP = new MaterialSkin.Controls.MaterialButton();
            this.btnDisableKSHSP = new MaterialSkin.Controls.MaterialButton();
            this.btnHVCI = new MaterialSkin.Controls.MaterialButton();
            this.btnDisableHVCI = new MaterialSkin.Controls.MaterialButton();
            // Initialize new button
            this.btnCheckDrivers = new MaterialSkin.Controls.MaterialButton();
            this.pnlConsole = new System.Windows.Forms.Panel();
            this.btnCloseConsole = new MaterialSkin.Controls.MaterialButton();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.pnlConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // btnKSHSP
            // 
            this.btnKSHSP.AutoSize = false;
            this.btnKSHSP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnKSHSP.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnKSHSP.Depth = 0;
            this.btnKSHSP.HighEmphasis = true;
            this.btnKSHSP.Icon = null;
            this.btnKSHSP.Location = new System.Drawing.Point(30, 100);
            this.btnKSHSP.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnKSHSP.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnKSHSP.Name = "btnKSHSP";
            this.btnKSHSP.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnKSHSP.Size = new System.Drawing.Size(250, 50);
            this.btnKSHSP.TabIndex = 2;
            this.btnKSHSP.Tag = "KSHSP_ON";
            this.btnKSHSP.Text = "Enable Kernel Stack Protection";
            this.btnKSHSP.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnKSHSP.UseAccentColor = false;
            this.btnKSHSP.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnDisableKSHSP
            // 
            this.btnDisableKSHSP.AutoSize = false;
            this.btnDisableKSHSP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDisableKSHSP.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDisableKSHSP.Depth = 0;
            this.btnDisableKSHSP.HighEmphasis = true;
            this.btnDisableKSHSP.Icon = null;
            this.btnDisableKSHSP.Location = new System.Drawing.Point(290, 100);
            this.btnDisableKSHSP.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDisableKSHSP.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDisableKSHSP.Name = "btnDisableKSHSP";
            this.btnDisableKSHSP.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDisableKSHSP.Size = new System.Drawing.Size(250, 50);
            this.btnDisableKSHSP.TabIndex = 4;
            this.btnDisableKSHSP.Tag = "KSHSP_OFF";
            this.btnDisableKSHSP.Text = "Disable Kernel Stack Protection";
            this.btnDisableKSHSP.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnDisableKSHSP.UseAccentColor = false;
            this.btnDisableKSHSP.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnHVCI
            // 
            this.btnHVCI.AutoSize = false;
            this.btnHVCI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHVCI.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnHVCI.Depth = 0;
            this.btnHVCI.HighEmphasis = true;
            this.btnHVCI.Icon = null;
            this.btnHVCI.Location = new System.Drawing.Point(30, 160);
            this.btnHVCI.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnHVCI.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnHVCI.Name = "btnHVCI";
            this.btnHVCI.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnHVCI.Size = new System.Drawing.Size(250, 50);
            this.btnHVCI.TabIndex = 1;
            this.btnHVCI.Tag = "HVCI_ON";
            this.btnHVCI.Text = "Enable Memory Integrity";
            this.btnHVCI.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnHVCI.UseAccentColor = false;
            this.btnHVCI.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnDisableHVCI
            // 
            this.btnDisableHVCI.AutoSize = false;
            this.btnDisableHVCI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDisableHVCI.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDisableHVCI.Depth = 0;
            this.btnDisableHVCI.HighEmphasis = true;
            this.btnDisableHVCI.Icon = null;
            this.btnDisableHVCI.Location = new System.Drawing.Point(290, 160);
            this.btnDisableHVCI.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDisableHVCI.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDisableHVCI.Name = "btnDisableHVCI";
            this.btnDisableHVCI.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDisableHVCI.Size = new System.Drawing.Size(250, 50);
            this.btnDisableHVCI.TabIndex = 5;
            this.btnDisableHVCI.Tag = "HVCI_OFF";
            this.btnDisableHVCI.Text = "Disable Memory Integrity";
            this.btnDisableHVCI.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnDisableHVCI.UseAccentColor = false;
            this.btnDisableHVCI.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnCheckDrivers
            // 
            this.btnCheckDrivers.AutoSize = false;
            this.btnCheckDrivers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCheckDrivers.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCheckDrivers.Depth = 0;
            this.btnCheckDrivers.HighEmphasis = true;
            this.btnCheckDrivers.Icon = null;
            this.btnCheckDrivers.Location = new System.Drawing.Point(30, 220); // Placed below Enable/Disable rows
            this.btnCheckDrivers.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCheckDrivers.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCheckDrivers.Name = "btnCheckDrivers";
            this.btnCheckDrivers.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCheckDrivers.Size = new System.Drawing.Size(510, 40); // Full width button
            this.btnCheckDrivers.TabIndex = 6;
            this.btnCheckDrivers.Text = "Scan System for Driver Conflicts";
            this.btnCheckDrivers.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCheckDrivers.UseAccentColor = true; // Use accent color to make it stand out
            this.btnCheckDrivers.Click += new System.EventHandler(this.btnCheckDrivers_Click);
            // 
            // pnlConsole
            // 
            this.pnlConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConsole.Controls.Add(this.btnCloseConsole);
            this.pnlConsole.Controls.Add(this.txtConsole);
            this.pnlConsole.Location = new System.Drawing.Point(30, 280); // Lowered to make room for the scan button
            this.pnlConsole.Name = "pnlConsole";
            this.pnlConsole.Size = new System.Drawing.Size(510, 400);
            this.pnlConsole.TabIndex = 0;
            this.pnlConsole.Visible = false;
            // 
            // btnCloseConsole
            // 
            this.btnCloseConsole.AutoSize = false;
            this.btnCloseConsole.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCloseConsole.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCloseConsole.Depth = 0;
            this.btnCloseConsole.HighEmphasis = true;
            this.btnCloseConsole.Icon = null;
            this.btnCloseConsole.Location = new System.Drawing.Point(155, 350);
            this.btnCloseConsole.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCloseConsole.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCloseConsole.Name = "btnCloseConsole";
            this.btnCloseConsole.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCloseConsole.Size = new System.Drawing.Size(200, 36);
            this.btnCloseConsole.TabIndex = 0;
            this.btnCloseConsole.Text = "Close Console";
            this.btnCloseConsole.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCloseConsole.UseAccentColor = false;
            this.btnCloseConsole.Click += new System.EventHandler(this.btnCloseConsole_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.Color.Black;
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsole.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtConsole.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtConsole.Location = new System.Drawing.Point(10, 10);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(488, 330);
            this.txtConsole.TabIndex = 1;
            // 
            // picBackground
            // 
            this.picBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackground.Image = global::Windows_Security_Patcher.Properties.Resources.agaqist0oj021;
            this.picBackground.Location = new System.Drawing.Point(3, 64);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(564, 710);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackground.TabIndex = 3;
            this.picBackground.TabStop = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(570, 777);
            this.Controls.Add(this.pnlConsole);
            this.Controls.Add(this.btnCheckDrivers); // Add scan button to form
            this.Controls.Add(this.btnDisableHVCI);
            this.Controls.Add(this.btnHVCI);
            this.Controls.Add(this.btnDisableKSHSP);
            this.Controls.Add(this.btnKSHSP);
            this.Controls.Add(this.picBackground);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Windows Security Patcher";
            this.pnlConsole.ResumeLayout(false);
            this.pnlConsole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);

        }
    }
}