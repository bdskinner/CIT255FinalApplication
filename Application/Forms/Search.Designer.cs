namespace Application
{
    partial class Search
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
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnResetForm = new System.Windows.Forms.Button();
            this.btnSearchMovie = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lstMovieList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearchTitle = new System.Windows.Forms.TextBox();
            this.chkSortGenre = new System.Windows.Forms.CheckBox();
            this.chkSortTitle = new System.Windows.Forms.CheckBox();
            this.chkSortReleaseDate = new System.Windows.Forms.CheckBox();
            this.chkSortRating = new System.Windows.Forms.CheckBox();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.cmbRating = new System.Windows.Forms.ComboBox();
            this.chkSearchTitle = new System.Windows.Forms.CheckBox();
            this.chkSearchGenre = new System.Windows.Forms.CheckBox();
            this.chkSearchRating = new System.Windows.Forms.CheckBox();
            this.chkSearchReleaseDate = new System.Windows.Forms.CheckBox();
            this.dtpSearchDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpSearchDateTo = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainMenu.Location = new System.Drawing.Point(521, 496);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(169, 47);
            this.btnMainMenu.TabIndex = 37;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnResetForm
            // 
            this.btnResetForm.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetForm.Location = new System.Drawing.Point(324, 496);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.Size = new System.Drawing.Size(169, 47);
            this.btnResetForm.TabIndex = 36;
            this.btnResetForm.Text = "Reset Form";
            this.btnResetForm.UseVisualStyleBackColor = true;
            this.btnResetForm.Click += new System.EventHandler(this.btnResetForm_Click);
            // 
            // btnSearchMovie
            // 
            this.btnSearchMovie.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchMovie.Location = new System.Drawing.Point(127, 496);
            this.btnSearchMovie.Name = "btnSearchMovie";
            this.btnSearchMovie.Size = new System.Drawing.Size(169, 47);
            this.btnSearchMovie.TabIndex = 35;
            this.btnSearchMovie.Text = "Search Movies";
            this.btnSearchMovie.UseVisualStyleBackColor = true;
            this.btnSearchMovie.Click += new System.EventHandler(this.btnSearchMovie_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 34;
            this.label2.Text = "Movie List";
            // 
            // lstMovieList
            // 
            this.lstMovieList.FormattingEnabled = true;
            this.lstMovieList.Location = new System.Drawing.Point(69, 131);
            this.lstMovieList.Name = "lstMovieList";
            this.lstMovieList.Size = new System.Drawing.Size(181, 329);
            this.lstMovieList.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(296, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 39);
            this.label1.TabIndex = 32;
            this.label1.Text = "Search Movies";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(304, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 38;
            this.label3.Text = "Search by";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(294, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 21);
            this.label4.TabIndex = 39;
            this.label4.Text = "Sort by";
            // 
            // txtSearchTitle
            // 
            this.txtSearchTitle.Enabled = false;
            this.txtSearchTitle.Location = new System.Drawing.Point(417, 163);
            this.txtSearchTitle.Name = "txtSearchTitle";
            this.txtSearchTitle.Size = new System.Drawing.Size(210, 20);
            this.txtSearchTitle.TabIndex = 40;
            // 
            // chkSortGenre
            // 
            this.chkSortGenre.AutoSize = true;
            this.chkSortGenre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSortGenre.Location = new System.Drawing.Point(521, 398);
            this.chkSortGenre.Name = "chkSortGenre";
            this.chkSortGenre.Size = new System.Drawing.Size(78, 25);
            this.chkSortGenre.TabIndex = 51;
            this.chkSortGenre.Text = "Genre";
            this.chkSortGenre.UseVisualStyleBackColor = true;
            // 
            // chkSortTitle
            // 
            this.chkSortTitle.AutoSize = true;
            this.chkSortTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSortTitle.Location = new System.Drawing.Point(330, 398);
            this.chkSortTitle.Name = "chkSortTitle";
            this.chkSortTitle.Size = new System.Drawing.Size(64, 25);
            this.chkSortTitle.TabIndex = 48;
            this.chkSortTitle.Text = "Title:";
            this.chkSortTitle.UseVisualStyleBackColor = true;
            // 
            // chkSortReleaseDate
            // 
            this.chkSortReleaseDate.AutoSize = true;
            this.chkSortReleaseDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSortReleaseDate.Location = new System.Drawing.Point(330, 429);
            this.chkSortReleaseDate.Name = "chkSortReleaseDate";
            this.chkSortReleaseDate.Size = new System.Drawing.Size(133, 25);
            this.chkSortReleaseDate.TabIndex = 53;
            this.chkSortReleaseDate.Text = "Release Date";
            this.chkSortReleaseDate.UseVisualStyleBackColor = true;
            // 
            // chkSortRating
            // 
            this.chkSortRating.AutoSize = true;
            this.chkSortRating.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSortRating.Location = new System.Drawing.Point(521, 429);
            this.chkSortRating.Name = "chkSortRating";
            this.chkSortRating.Size = new System.Drawing.Size(81, 25);
            this.chkSortRating.TabIndex = 52;
            this.chkSortRating.Text = "Rating";
            this.chkSortRating.UseVisualStyleBackColor = true;
            // 
            // cmbGenre
            // 
            this.cmbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenre.Enabled = false;
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Location = new System.Drawing.Point(417, 282);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(111, 21);
            this.cmbGenre.TabIndex = 59;
            // 
            // cmbRating
            // 
            this.cmbRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRating.Enabled = false;
            this.cmbRating.FormattingEnabled = true;
            this.cmbRating.Location = new System.Drawing.Point(417, 312);
            this.cmbRating.Name = "cmbRating";
            this.cmbRating.Size = new System.Drawing.Size(111, 21);
            this.cmbRating.TabIndex = 60;
            // 
            // chkSearchTitle
            // 
            this.chkSearchTitle.AutoSize = true;
            this.chkSearchTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSearchTitle.Location = new System.Drawing.Point(330, 159);
            this.chkSearchTitle.Name = "chkSearchTitle";
            this.chkSearchTitle.Size = new System.Drawing.Size(64, 25);
            this.chkSearchTitle.TabIndex = 61;
            this.chkSearchTitle.Text = "Title:";
            this.chkSearchTitle.UseVisualStyleBackColor = true;
            this.chkSearchTitle.CheckedChanged += new System.EventHandler(this.chkSearchTitle_CheckedChanged);
            // 
            // chkSearchGenre
            // 
            this.chkSearchGenre.AutoSize = true;
            this.chkSearchGenre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSearchGenre.Location = new System.Drawing.Point(330, 278);
            this.chkSearchGenre.Name = "chkSearchGenre";
            this.chkSearchGenre.Size = new System.Drawing.Size(78, 25);
            this.chkSearchGenre.TabIndex = 62;
            this.chkSearchGenre.Text = "Genre";
            this.chkSearchGenre.UseVisualStyleBackColor = true;
            this.chkSearchGenre.CheckedChanged += new System.EventHandler(this.chkSearchGenre_CheckedChanged);
            // 
            // chkSearchRating
            // 
            this.chkSearchRating.AutoSize = true;
            this.chkSearchRating.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSearchRating.Location = new System.Drawing.Point(330, 308);
            this.chkSearchRating.Name = "chkSearchRating";
            this.chkSearchRating.Size = new System.Drawing.Size(81, 25);
            this.chkSearchRating.TabIndex = 63;
            this.chkSearchRating.Text = "Rating";
            this.chkSearchRating.UseVisualStyleBackColor = true;
            this.chkSearchRating.CheckedChanged += new System.EventHandler(this.chkSearchRating_CheckedChanged);
            // 
            // chkSearchReleaseDate
            // 
            this.chkSearchReleaseDate.AutoSize = true;
            this.chkSearchReleaseDate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSearchReleaseDate.Location = new System.Drawing.Point(330, 187);
            this.chkSearchReleaseDate.Name = "chkSearchReleaseDate";
            this.chkSearchReleaseDate.Size = new System.Drawing.Size(133, 25);
            this.chkSearchReleaseDate.TabIndex = 64;
            this.chkSearchReleaseDate.Text = "Release Date";
            this.chkSearchReleaseDate.UseVisualStyleBackColor = true;
            this.chkSearchReleaseDate.CheckedChanged += new System.EventHandler(this.chkSearchReleaseDate_CheckedChanged);
            // 
            // dtpSearchDateFrom
            // 
            this.dtpSearchDateFrom.CustomFormat = "MM/dd/yyyy";
            this.dtpSearchDateFrom.Enabled = false;
            this.dtpSearchDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSearchDateFrom.Location = new System.Drawing.Point(515, 223);
            this.dtpSearchDateFrom.Name = "dtpSearchDateFrom";
            this.dtpSearchDateFrom.Size = new System.Drawing.Size(136, 20);
            this.dtpSearchDateFrom.TabIndex = 66;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(413, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 21);
            this.label5.TabIndex = 67;
            this.label5.Text = "From Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(433, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 21);
            this.label6.TabIndex = 68;
            this.label6.Text = "To Date:";
            // 
            // dtpSearchDateTo
            // 
            this.dtpSearchDateTo.CustomFormat = "MM/dd/yyyy";
            this.dtpSearchDateTo.Enabled = false;
            this.dtpSearchDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSearchDateTo.Location = new System.Drawing.Point(515, 249);
            this.dtpSearchDateTo.Name = "dtpSearchDateTo";
            this.dtpSearchDateTo.Size = new System.Drawing.Size(136, 20);
            this.dtpSearchDateTo.TabIndex = 69;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 569);
            this.Controls.Add(this.dtpSearchDateTo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpSearchDateFrom);
            this.Controls.Add(this.chkSearchReleaseDate);
            this.Controls.Add(this.chkSearchRating);
            this.Controls.Add(this.chkSearchGenre);
            this.Controls.Add(this.chkSearchTitle);
            this.Controls.Add(this.cmbRating);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.chkSortReleaseDate);
            this.Controls.Add(this.chkSortRating);
            this.Controls.Add(this.chkSortGenre);
            this.Controls.Add(this.chkSortTitle);
            this.Controls.Add(this.txtSearchTitle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnResetForm);
            this.Controls.Add(this.btnSearchMovie);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstMovieList);
            this.Controls.Add(this.label1);
            this.Name = "Search";
            this.Text = "Search for Movies";
            this.Load += new System.EventHandler(this.Search_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnResetForm;
        private System.Windows.Forms.Button btnSearchMovie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstMovieList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearchTitle;
        private System.Windows.Forms.CheckBox chkSortGenre;
        private System.Windows.Forms.CheckBox chkSortTitle;
        private System.Windows.Forms.CheckBox chkSortReleaseDate;
        private System.Windows.Forms.CheckBox chkSortRating;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.ComboBox cmbRating;
        private System.Windows.Forms.CheckBox chkSearchTitle;
        private System.Windows.Forms.CheckBox chkSearchGenre;
        private System.Windows.Forms.CheckBox chkSearchRating;
        private System.Windows.Forms.CheckBox chkSearchReleaseDate;
        private System.Windows.Forms.DateTimePicker dtpSearchDateFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpSearchDateTo;
    }
}