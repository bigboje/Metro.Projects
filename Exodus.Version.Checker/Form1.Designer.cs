namespace Exodus.Version.Checker
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveToFileCheck = new System.Windows.Forms.CheckBox();
            this.progressText = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.compareVersion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveToFileCheck
            // 
            this.saveToFileCheck.AutoSize = true;
            this.saveToFileCheck.Checked = true;
            this.saveToFileCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveToFileCheck.Location = new System.Drawing.Point(12, 92);
            this.saveToFileCheck.Name = "saveToFileCheck";
            this.saveToFileCheck.Size = new System.Drawing.Size(82, 17);
            this.saveToFileCheck.TabIndex = 10;
            this.saveToFileCheck.Text = "Save to File";
            this.saveToFileCheck.UseVisualStyleBackColor = true;
            this.saveToFileCheck.Visible = false;
            // 
            // progressText
            // 
            this.progressText.AutoSize = true;
            this.progressText.Location = new System.Drawing.Point(12, 9);
            this.progressText.Name = "progressText";
            this.progressText.Size = new System.Drawing.Size(69, 13);
            this.progressText.TabIndex = 9;
            this.progressText.Text = "Action: None";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 25);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(421, 32);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 8;
            // 
            // compareVersion
            // 
            this.compareVersion.Location = new System.Drawing.Point(12, 63);
            this.compareVersion.Name = "compareVersion";
            this.compareVersion.Size = new System.Drawing.Size(122, 23);
            this.compareVersion.TabIndex = 7;
            this.compareVersion.Text = "Initialize Comparer";
            this.compareVersion.UseVisualStyleBackColor = true;
            this.compareVersion.Click += new System.EventHandler(this.compareVersion_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 113);
            this.Controls.Add(this.saveToFileCheck);
            this.Controls.Add(this.progressText);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.compareVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Metro Exodus Version Checker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox saveToFileCheck;
        private System.Windows.Forms.Label progressText;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button compareVersion;
    }
}

