namespace Winkle
{
    partial class UpdateNotification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateNotification));
            this.NewVersionAvailable = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.RichTextBox();
            this.buttonGetUpdate = new System.Windows.Forms.Button();
            this.buttonIgnore = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelShortDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // NewVersionAvailable
            // 
            this.NewVersionAvailable.AutoSize = true;
            this.NewVersionAvailable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewVersionAvailable.Location = new System.Drawing.Point(113, 9);
            this.NewVersionAvailable.Name = "NewVersionAvailable";
            this.NewVersionAvailable.Size = new System.Drawing.Size(140, 21);
            this.NewVersionAvailable.TabIndex = 0;
            this.NewVersionAvailable.Text = "Update available";
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(27, 95);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(761, 397);
            this.description.TabIndex = 1;
            this.description.Text = "";
            // 
            // buttonGetUpdate
            // 
            this.buttonGetUpdate.Location = new System.Drawing.Point(158, 498);
            this.buttonGetUpdate.Name = "buttonGetUpdate";
            this.buttonGetUpdate.Size = new System.Drawing.Size(221, 23);
            this.buttonGetUpdate.TabIndex = 2;
            this.buttonGetUpdate.Text = "Get update";
            this.buttonGetUpdate.UseVisualStyleBackColor = true;
            this.buttonGetUpdate.Click += new System.EventHandler(this.buttonGetUpdate_Click);
            // 
            // buttonIgnore
            // 
            this.buttonIgnore.Location = new System.Drawing.Point(448, 498);
            this.buttonIgnore.Name = "buttonIgnore";
            this.buttonIgnore.Size = new System.Drawing.Size(218, 23);
            this.buttonIgnore.TabIndex = 3;
            this.buttonIgnore.Text = "Ignore this update";
            this.buttonIgnore.UseVisualStyleBackColor = true;
            this.buttonIgnore.Click += new System.EventHandler(this.buttonIgnore_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::Winkle.Properties.Resources.winkle;
            this.pictureBoxLogo.InitialImage = global::Winkle.Properties.Resources.winkle;
            this.pictureBoxLogo.Location = new System.Drawing.Point(27, 9);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 4;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelShortDescription
            // 
            this.labelShortDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShortDescription.Location = new System.Drawing.Point(114, 39);
            this.labelShortDescription.Name = "labelShortDescription";
            this.labelShortDescription.Size = new System.Drawing.Size(674, 50);
            this.labelShortDescription.TabIndex = 5;
            this.labelShortDescription.Text = resources.GetString("labelShortDescription.Text");
            // 
            // UpdateNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 550);
            this.Controls.Add(this.labelShortDescription);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.buttonIgnore);
            this.Controls.Add(this.buttonGetUpdate);
            this.Controls.Add(this.description);
            this.Controls.Add(this.NewVersionAvailable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateNotification";
            this.Text = "New update available for download";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NewVersionAvailable;
        private System.Windows.Forms.RichTextBox description;
        private System.Windows.Forms.Button buttonGetUpdate;
        private System.Windows.Forms.Button buttonIgnore;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelShortDescription;
    }
}