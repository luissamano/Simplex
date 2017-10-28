namespace Simplex
{
    partial class Simplex
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simplex));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bBuild = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bMaximize = new System.Windows.Forms.ToolStripButton();
            this.bMinimize = new System.Windows.Forms.ToolStripButton();
            this.txtEquations = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Equations";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 25);
            this.panel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bBuild,
            this.toolStripSeparator1,
            this.bMaximize,
            this.bMinimize});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(457, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "vStrip";
            // 
            // bBuild
            // 
            this.bBuild.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bBuild.Image = ((System.Drawing.Image)(resources.GetObject("bBuild.Image")));
            this.bBuild.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bBuild.Name = "bBuild";
            this.bBuild.Size = new System.Drawing.Size(38, 22);
            this.bBuild.Text = "Build";
            this.bBuild.ToolTipText = "Build Equations";
            this.bBuild.Click += new System.EventHandler(this.bBuild_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bMaximize
            // 
            this.bMaximize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bMaximize.Enabled = false;
            this.bMaximize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bMaximize.Image = ((System.Drawing.Image)(resources.GetObject("bMaximize.Image")));
            this.bMaximize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bMaximize.Name = "bMaximize";
            this.bMaximize.Size = new System.Drawing.Size(65, 22);
            this.bMaximize.Text = "Maximize";
            this.bMaximize.ToolTipText = "Maximize target function";
            this.bMaximize.Click += new System.EventHandler(this.bMaximize_Click);
            // 
            // bMinimize
            // 
            this.bMinimize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bMinimize.Enabled = false;
            this.bMinimize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bMinimize.Image = ((System.Drawing.Image)(resources.GetObject("bMinimize.Image")));
            this.bMinimize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bMinimize.Name = "bMinimize";
            this.bMinimize.Size = new System.Drawing.Size(62, 22);
            this.bMinimize.Text = "Minimize";
            this.bMinimize.ToolTipText = "Minimize target function";
            this.bMinimize.Click += new System.EventHandler(this.bMinimize_Click);
            // 
            // txtEquations
            // 
            this.txtEquations.AcceptsReturn = true;
            this.txtEquations.AcceptsTab = true;
            this.txtEquations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEquations.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquations.Location = new System.Drawing.Point(15, 57);
            this.txtEquations.Multiline = true;
            this.txtEquations.Name = "txtEquations";
            this.txtEquations.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEquations.Size = new System.Drawing.Size(302, 131);
            this.txtEquations.TabIndex = 2;
            this.txtEquations.TextChanged += new System.EventHandler(this.txtEquations_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(15, 207);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(302, 248);
            this.textBox1.TabIndex = 3;
            // 
            // Simplex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 467);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtEquations);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Simplex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simplex";
            this.Load += new System.EventHandler(this.Simplex_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox txtEquations;
        private System.Windows.Forms.ToolStripButton bBuild;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bMaximize;
        private System.Windows.Forms.ToolStripButton bMinimize;
        private System.Windows.Forms.TextBox textBox1;
    }
}

