using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Application
{
    public partial class AddMovie : Form
    {
        #region FORM VARIABLES

        IRepository repository = new AccessRepository();

        #endregion

        #region CONSTRUCTOR

        public AddMovie()
        {
            InitializeComponent();
        }

        #endregion

        #region EVENTS

        private void AddMovie_Load(object sender, EventArgs e)
        {
            //Fill the genres combobox.
            FillGenreList();

            //Clear the controls on the form.
            ResetForm();
        }

        private void btnChoosePoster_Click(object sender, EventArgs e)
        {
            //Code found at: 
            //  Site Name: stackoverflow.com
            //  URL: http://stackoverflow.com/questions/24449988/how-to-get-file-path-from-openfiledialog-and-folderbrowserdialog

            //Create and display an open file dialog box.
            //OpenFileDialog choofdlog = new OpenFileDialog();
            //choofdlog.Filter = "Image Files | *.jpg; *.png; *.bmp";

            ////Get the path of the file selected.
            //if (choofdlog.ShowDialog() == DialogResult.OK)
            //{
            //    //label1.Text = choofdlog.FileName;
            //    //pbMoviePoster.Image = choofdlog.FileName;

            //    pbMoviePoster.ImageLocation = choofdlog.FileName;
            //}

            pbMoviePoster.ImageLocation = ApplicationUtilities.ChooseImageFile();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnSaveMovie_Click(object sender, EventArgs e)
        {
            ////Variable Declarations.
            //Movie newMovie = new Movie();
            ////AccessRepository repository = new AccessRepository();
            //LimelightBusiness business = new LimelightBusiness(repository);

            ////Take the image from the picture box and store in a byte array.
            //MemoryStream ms = new MemoryStream();
            //pbMoviePoster.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //byte[] moviePoster = ms.GetBuffer();

            ////Set the information entered by the user into a movie object.
            //newMovie.Title = txtMovieTitle.Text;
            //newMovie.Synopsis = txtMovieSynopsis.Text;
            //newMovie.ReleaseDate = dtpReleaseDate.Value;
            //newMovie.GenreID = (int)cmbGenre.SelectedValue;

            ////Insert the new movie information into the database.
            ////using (repository)
            ////{
            ////    repository.InsertNewMovie(newMovie, moviePoster);
            ////}


            //try
            //{
            //    //Insert the new movie information into the database.
            //    business.AddMovie(newMovie, moviePoster);

            //    //Tell the user the information was added successfully.
            //    MessageBox.Show("The Information has been Added Successfully!!");

            //    //Reset the form.
            //    ResetForm();
            //}
            //catch (Exception ex)
            //{
            //    //Handle an exceptions thrown.
            //    ApplicationUtilities.CatchExceptions(ex);
            //}

            //Save the new movie to the data source.
            AddNewMovie();

            //Reset the form.
            ResetForm();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Fills the ratings combobox with the various rating levels.
        /// </summary>
        private void FillGenreList()
        {
            //Variable Declarations.
            DataSet movieGenres;
            //AccessRepository repository = new AccessRepository();
            LimelightBusiness business = new LimelightBusiness(repository);

            //Get the genre titles from the database.
            //using (repository)
            //{
            //    movieGenres = repository.GetAllGenreTitles();
            //}
            movieGenres = business.GetAllGenreTitles();

            //Add the genre titles to the genre combobox.
            DataRow emptyDataRow = movieGenres.Tables[0].NewRow();
            emptyDataRow[0] = 0;
            emptyDataRow[1] = "Select A Genre";
            movieGenres.Tables[0].Rows.InsertAt(emptyDataRow, 0);

            cmbGenre.DataSource = movieGenres.Tables[0];
            cmbGenre.ValueMember = "GenreID";
            cmbGenre.DisplayMember = "GenreTitle";
        }

        /// <summary>
        /// Resets the controls on the form to their beginning state.
        /// </summary>
        private void ResetForm()
        {
            pbMoviePoster.Image = null;
            pbMoviePoster.ImageLocation = "";
            pbMoviePoster.ImageLocation = ApplicationUtilities.defaultPoster;
            txtMovieTitle.Text = "";
            txtMovieSynopsis.Text = "";
            dtpReleaseDate.Value = DateTime.Now;
            cmbGenre.SelectedIndex = 0;
            txtMovieTitle.Focus();
        }

        private void AddNewMovie()
        {
            //Variable Declarations.
            Movie newMovie = new Movie();
            //AccessRepository repository = new AccessRepository();
            LimelightBusiness business = new LimelightBusiness(repository);

            //Take the image from the picture box and store in a byte array.
            MemoryStream ms = new MemoryStream();
            pbMoviePoster.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] moviePoster = ms.GetBuffer();

            //Set the information entered by the user into a movie object.
            newMovie.Title = txtMovieTitle.Text;
            newMovie.Synopsis = txtMovieSynopsis.Text;
            newMovie.ReleaseDate = dtpReleaseDate.Value;
            newMovie.GenreID = (int)cmbGenre.SelectedValue;

            //Insert the new movie information into the database.
            //using (repository)
            //{
            //    repository.InsertNewMovie(newMovie, moviePoster);
            //}


            try
            {
                //Insert the new movie information into the database.
                business.AddMovie(newMovie, moviePoster);

                //Tell the user the information was added successfully.
                MessageBox.Show("The Information has been Added Successfully!!");
            }
            catch (Exception ex)
            {
                //Handle an exceptions thrown.
                ApplicationUtilities.CatchExceptions(ex);
            }
        }
        
        #endregion
    }
}
