namespace Application
{
    partial class DeleteMovie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteMovie));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstMovieList = new System.Windows.Forms.ListBox();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnResetForm = new System.Windows.Forms.Button();
            this.btnDeleteMovie = new System.Windows.Forms.Button();
            this.pbMoviePoster = new System.Windows.Forms.PictureBox();
            this.lblMovieTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMoviePoster)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(286, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Delete Movies";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Movie List";
            // 
            // lstMovieList
            // 
            this.lstMovieList.FormattingEnabled = true;
            this.lstMovieList.Location = new System.Drawing.Point(59, 131);
            this.lstMovieList.Name = "lstMovieList";
            this.lstMovieList.Size = new System.Drawing.Size(181, 329);
            this.lstMovieList.TabIndex = 4;
            this.lstMovieList.Click += new System.EventHandler(this.lstMovieList_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(511, 496);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(169, 47);
            this.btnMainMenu.TabIndex = 30;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnResetForm
            // 
            this.btnResetForm.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetForm.Location = new System.Drawing.Point(314, 496);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.Size = new System.Drawing.Size(169, 47);
            this.btnResetForm.TabIndex = 29;
            this.btnResetForm.Text = "Reset Form";
            this.btnResetForm.UseVisualStyleBackColor = true;
            this.btnResetForm.Click += new System.EventHandler(this.btnResetForm_Click);
            // 
            // btnDeleteMovie
            // 
            this.btnDeleteMovie.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteMovie.Location = new System.Drawing.Point(117, 496);
            this.btnDeleteMovie.Name = "btnDeleteMovie";
            this.btnDeleteMovie.Size = new System.Drawing.Size(169, 47);
            this.btnDeleteMovie.TabIndex = 28;
            this.btnDeleteMovie.Text = "Delete Movie";
            this.btnDeleteMovie.UseVisualStyleBackColor = true;
            this.btnDeleteMovie.Click += new System.EventHandler(this.btnDeleteMovie_Click);
            // 
            // pbMoviePoster
            // 
            this.pbMoviePoster.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbMoviePoster.BackgroundImage")));
            this.pbMoviePoster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMoviePoster.ImageLocation = "";
            this.pbMoviePoster.Location = new System.Drawing.Point(359, 131);
            this.pbMoviePoster.Name = "pbMoviePoster";
            this.pbMoviePoster.Size = new System.Drawing.Size(205, 260);
            this.pbMoviePoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMoviePoster.TabIndex = 31;
            this.pbMoviePoster.TabStop = false;
            // 
            // lblMovieTitle
            // 
            this.lblMovieTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovieTitle.Location = new System.Drawing.Point(310, 414);
            this.lblMovieTitle.Name = "lblMovieTitle";
            this.lblMovieTitle.Size = new System.Drawing.Size(310, 29);
            this.lblMovieTitle.TabIndex = 32;
            this.lblMovieTitle.Text = "X";
            this.lblMovieTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DeleteMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 578);
            this.Controls.Add(this.lblMovieTitle);
            this.Controls.Add(this.pbMoviePoster);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnResetForm);
            this.Controls.Add(this.btnDeleteMovie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstMovieList);
            this.Controls.Add(this.label1);
            this.Name = "DeleteMovie";
            this.Text = "Delete Movies";
            this.Load += new System.EventHandler(this.DeleteMovie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMoviePoster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstMovieList;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnResetForm;
        private System.Windows.Forms.Button btnDeleteMovie;
        private System.Windows.Forms.PictureBox pbMoviePoster;
        private System.Windows.Forms.Label lblMovieTitle;
    }
}