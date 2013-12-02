namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm
{
    partial class MainForm
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
            this.dataContext = new System.Windows.Forms.BindingSource(this.components);
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewUnitFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openExistingUnitFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.filesTab = new SupremeFiction.UI.SupremeRulerModdingTool.WinForm.ExitableTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataContext)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.unitToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1122, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectGameToolStripMenuItem,
            this.saveFilesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // selectGameToolStripMenuItem
            // 
            this.selectGameToolStripMenuItem.Name = "selectGameToolStripMenuItem";
            this.selectGameToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.selectGameToolStripMenuItem.Text = "Select Game";
            // 
            // saveFilesToolStripMenuItem
            // 
            this.saveFilesToolStripMenuItem.Name = "saveFilesToolStripMenuItem";
            this.saveFilesToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.saveFilesToolStripMenuItem.Text = "Save Files";
            // 
            // unitToolStripMenuItem
            // 
            this.unitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewUnitFileToolStripMenuItem,
            this.openExistingUnitFileToolStripMenuItem});
            this.unitToolStripMenuItem.Name = "unitToolStripMenuItem";
            this.unitToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.unitToolStripMenuItem.Text = "Unit";
            // 
            // createNewUnitFileToolStripMenuItem
            // 
            this.createNewUnitFileToolStripMenuItem.Name = "createNewUnitFileToolStripMenuItem";
            this.createNewUnitFileToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.createNewUnitFileToolStripMenuItem.Text = "Create New Unit File";
            // 
            // openExistingUnitFileToolStripMenuItem
            // 
            this.openExistingUnitFileToolStripMenuItem.Name = "openExistingUnitFileToolStripMenuItem";
            this.openExistingUnitFileToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.openExistingUnitFileToolStripMenuItem.Text = "Open Existing Unit File";
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 672);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(1122, 22);
            this.mainStatusStrip.TabIndex = 1;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // filesTab
            // 
            this.filesTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesTab.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.filesTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filesTab.ItemSize = new System.Drawing.Size(150, 24);
            this.filesTab.Location = new System.Drawing.Point(0, 24);
            this.filesTab.Name = "filesTab";
            this.filesTab.SelectedIndex = 0;
            this.filesTab.Size = new System.Drawing.Size(1122, 648);
            this.filesTab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.filesTab.TabIndex = 2;
            this.filesTab.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 694);
            this.Controls.Add(this.filesTab);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataContext)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource dataContext;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewUnitFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openExistingUnitFileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripMenuItem saveFilesToolStripMenuItem;
        private ExitableTabControl filesTab;
    }
}