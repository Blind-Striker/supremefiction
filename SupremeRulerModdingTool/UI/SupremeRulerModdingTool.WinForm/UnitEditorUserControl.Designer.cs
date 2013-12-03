namespace SupremeFiction.UI.SupremeRulerModdingTool.WinForm
{
    partial class UnitEditorUserControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.categoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbSubClass = new System.Windows.Forms.ComboBox();
            this.subClassesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbClasses = new System.Windows.Forms.ComboBox();
            this.classesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblSubClass = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.dataGridUnits = new System.Windows.Forms.DataGridView();
            this.cntGridItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataContext = new System.Windows.Forms.BindingSource(this.components);
            this.pasteRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subClassesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUnits)).BeginInit();
            this.cntGridItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataContext)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmbCategories);
            this.splitContainer1.Panel1.Controls.Add(this.cmbSubClass);
            this.splitContainer1.Panel1.Controls.Add(this.cmbClasses);
            this.splitContainer1.Panel1.Controls.Add(this.lblSubClass);
            this.splitContainer1.Panel1.Controls.Add(this.lblClass);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer1.Panel1.Controls.Add(this.lblSearch);
            this.splitContainer1.Panel1.Controls.Add(this.lblCategory);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5, 0, 2, 0);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridUnits);
            this.splitContainer1.Size = new System.Drawing.Size(1043, 505);
            this.splitContainer1.SplitterDistance = 28;
            this.splitContainer1.TabIndex = 0;
            // 
            // cmbCategories
            // 
            this.cmbCategories.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dataContext, "CurrentCategoryItemSelectedValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbCategories.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.dataContext, "CurrentCategoryItem", true));
            this.cmbCategories.DataSource = this.categoriesBindingSource;
            this.cmbCategories.DisplayMember = "ComboboxItemDisplayMember";
            this.cmbCategories.FormattingEnabled = true;
            this.cmbCategories.Location = new System.Drawing.Point(66, 4);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(99, 21);
            this.cmbCategories.TabIndex = 9;
            this.cmbCategories.ValueMember = "ComboboxItemValueMember";
            // 
            // categoriesBindingSource
            // 
            this.categoriesBindingSource.DataMember = "Categories";
            this.categoriesBindingSource.DataSource = this.dataContext;
            // 
            // cmbSubClass
            // 
            this.cmbSubClass.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dataContext, "CurrentSubClassItemSelectedValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbSubClass.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.dataContext, "CurrentSubClassItem", true));
            this.cmbSubClass.DataSource = this.subClassesBindingSource;
            this.cmbSubClass.DisplayMember = "ComboboxItemDisplayMember";
            this.cmbSubClass.FormattingEnabled = true;
            this.cmbSubClass.Location = new System.Drawing.Point(402, 3);
            this.cmbSubClass.Name = "cmbSubClass";
            this.cmbSubClass.Size = new System.Drawing.Size(246, 21);
            this.cmbSubClass.TabIndex = 8;
            this.cmbSubClass.ValueMember = "ComboboxItemValueMember";
            // 
            // subClassesBindingSource
            // 
            this.subClassesBindingSource.DataMember = "SubClasses";
            this.subClassesBindingSource.DataSource = this.dataContext;
            // 
            // cmbClasses
            // 
            this.cmbClasses.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.dataContext, "CurrentClassItemSelectedValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbClasses.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.dataContext, "CurrentClassItem", true));
            this.cmbClasses.DataSource = this.classesBindingSource;
            this.cmbClasses.DisplayMember = "ComboboxItemValueMember";
            this.cmbClasses.FormattingEnabled = true;
            this.cmbClasses.Location = new System.Drawing.Point(209, 3);
            this.cmbClasses.Name = "cmbClasses";
            this.cmbClasses.Size = new System.Drawing.Size(127, 21);
            this.cmbClasses.TabIndex = 7;
            this.cmbClasses.ValueMember = "ComboboxItemValueMember";
            // 
            // classesBindingSource
            // 
            this.classesBindingSource.DataMember = "Classes";
            this.classesBindingSource.DataSource = this.dataContext;
            // 
            // lblSubClass
            // 
            this.lblSubClass.AutoSize = true;
            this.lblSubClass.Location = new System.Drawing.Point(347, 7);
            this.lblSubClass.Name = "lblSubClass";
            this.lblSubClass.Size = new System.Drawing.Size(54, 13);
            this.lblSubClass.TabIndex = 6;
            this.lblSubClass.Text = "Sub Class";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(176, 6);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(32, 13);
            this.lblClass.TabIndex = 4;
            this.lblClass.Text = "Class";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataContext, "SearchText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSearch.Location = new System.Drawing.Point(706, 3);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(332, 21);
            this.txtSearch.TabIndex = 3;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(659, 6);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 13);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(8, 6);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(57, 13);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Categories";
            // 
            // dataGridUnits
            // 
            this.dataGridUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUnits.ContextMenuStrip = this.cntGridItems;
            this.dataGridUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridUnits.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridUnits.Location = new System.Drawing.Point(0, 0);
            this.dataGridUnits.Name = "dataGridUnits";
            this.dataGridUnits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridUnits.Size = new System.Drawing.Size(1043, 473);
            this.dataGridUnits.TabIndex = 0;
            this.dataGridUnits.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DataGridUnitsKeyPress);
            // 
            // cntGridItems
            // 
            this.cntGridItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyRowsToolStripMenuItem,
            this.deleteRowsToolStripMenuItem,
            this.pasteRowsToolStripMenuItem});
            this.cntGridItems.Name = "cntGridItems";
            this.cntGridItems.Size = new System.Drawing.Size(153, 92);
            // 
            // copyRowsToolStripMenuItem
            // 
            this.copyRowsToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyRowsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyRowsToolStripMenuItem.Text = "Copy Rows";
            // 
            // deleteRowsToolStripMenuItem
            // 
            this.deleteRowsToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteRowsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteRowsToolStripMenuItem.Text = "Delete Rows";
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            // 
            // dataContext
            // 
            this.dataContext.DataSource = typeof(SupremeFiction.UI.SupremeRulerModdingTool.Foundation.ViewModels.UnitEditorViewModel);
            // 
            // pasteRowsToolStripMenuItem
            // 
            this.pasteRowsToolStripMenuItem.Name = "pasteRowsToolStripMenuItem";
            this.pasteRowsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pasteRowsToolStripMenuItem.Text = "Paste Rows";
            // 
            // UnitEditorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UnitEditorUserControl";
            this.Size = new System.Drawing.Size(1043, 505);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subClassesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUnits)).EndInit();
            this.cntGridItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataContext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.DataGridView dataGridUnits;
        private System.Windows.Forms.BindingSource dataContext;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblSubClass;
        private System.Windows.Forms.ComboBox cmbClasses;
        private System.Windows.Forms.BindingSource classesBindingSource;
        private System.Windows.Forms.ComboBox cmbSubClass;
        private System.Windows.Forms.BindingSource subClassesBindingSource;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.BindingSource categoriesBindingSource;
        private System.Windows.Forms.ContextMenuStrip cntGridItems;
        private System.Windows.Forms.ToolStripMenuItem copyRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteRowsToolStripMenuItem;
    }
}
