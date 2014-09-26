using System.Windows.Forms;
namespace MkvCompare
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.reduce_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.toolStripContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(1024, 743);
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(1024, 768);
            this.toolStripContainer.TabIndex = 0;
            this.toolStripContainer.Text = "toolStripContainer";
            // 
            // reduce_btn
            // 
            this.reduce_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this.reduce_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.reduce_btn.FlatAppearance.BorderSize = 0;
            this.reduce_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(255)))), ((int)(((byte)(232)))));
            this.reduce_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(224)))), ((int)(((byte)(204)))));
            this.reduce_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reduce_btn.Image = global::MkvCompare.Properties.Resources.reduce_button;
            this.reduce_btn.Location = new System.Drawing.Point(947, 0);
            this.reduce_btn.Name = "reduce_btn";
            this.reduce_btn.Size = new System.Drawing.Size(30, 25);
            this.reduce_btn.TabIndex = 7;
            this.reduce_btn.UseVisualStyleBackColor = false;
            this.reduce_btn.Click += new System.EventHandler(this.reduce_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.close_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.close_btn.FlatAppearance.BorderSize = 0;
            this.close_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.close_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_btn.Image = global::MkvCompare.Properties.Resources.close_button;
            this.close_btn.Location = new System.Drawing.Point(975, 0);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(50, 25);
            this.close_btn.TabIndex = 6;
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.reduce_btn);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.toolStripContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MkvCompare";
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ToolStripContainer toolStripContainer;
        private Button close_btn;
        private Button reduce_btn;
    }
}