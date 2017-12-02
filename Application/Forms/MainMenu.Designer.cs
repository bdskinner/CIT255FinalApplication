namespace Application
{
    partial class MainMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewMovies = new System.Windows.Forms.Button();
            this.btnAddMovies = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnUpdateMovies = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(260, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Main Menu";
            // 
            // btnViewMovies
            // 
            this.btnViewMovies.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewMovies.Location = new System.Drawing.Point(102, 132);
            this.btnViewMovies.Name = "btnViewMovies";
            this.btnViewMovies.Size = new System.Drawing.Size(234, 51);
            this.btnViewMovies.TabIndex = 1;
            this.btnViewMovies.Text = "View Movies";
            this.btnViewMovies.UseVisualStyleBackColor = true;
            this.btnViewMovies.Click += new System.EventHandler(this.btnViewMovies_Click);
            // 
            // btnAddMovies
            // 
            this.btnAddMovies.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMovies.Location = new System.Drawing.Point(367, 132);
            this.btnAddMovies.Name = "btnAddMovies";
            this.btnAddMovies.Size = new System.Drawing.Size(234, 51);
            this.btnAddMovies.TabIndex = 2;
            this.btnAddMovies.Text = "Add Movies";
            this.btnAddMovies.UseVisualStyleBackColor = true;
            this.btnAddMovies.Click += new System.EventHandler(this.btnAddMovies_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(367, 208);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(234, 51);
            this.button3.TabIndex = 4;
            this.button3.Text = "Delete Movies";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnUpdateMovies
            // 
            this.btnUpdateMovies.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateMovies.Location = new System.Drawing.Point(102, 208);
            this.btnUpdateMovies.Name = "btnUpdateMovies";
            this.btnUpdateMovies.Size = new System.Drawing.Size(234, 51);
            this.btnUpdateMovies.TabIndex = 3;
            this.btnUpdateMovies.Text = "Update Movies";
            this.btnUpdateMovies.UseVisualStyleBackColor = true;
            this.btnUpdateMovies.Click += new System.EventHandler(this.btnUpdateMovies_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(367, 284);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(234, 51);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(102, 284);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(234, 51);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 483);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnUpdateMovies);
            this.Controls.Add(this.btnAddMovies);
            this.Controls.Add(this.btnViewMovies);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Limelight Main Menu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnViewMovies;
        private System.Windows.Forms.Button btnAddMovies;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnUpdateMovies;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSearch;
    }
}

