using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Application
{
    public partial class UpdateMovie : Form
    {
        #region FORM VARIABLES

        List<Movie> movies;
        IRepository repository = new AccessRepository();

        #endregion

        #region CONSTRUCTOR

        public UpdateMovie()
        {
            InitializeComponent();
        }

        #endregion
        
        #region EVENTS
        
        private void btnChoosePoster_Click(object sender, EventArgs e)
        {
            pbMoviePoster.ImageLocation = ApplicationUtilities.ChooseImageFile();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
            lstMovieList.SelectedIndex = -1;
        }

        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            try
            {
                //Update the movie information.
                UpdateMovieInfo();
            }
            catch (Exception ex)
            {
                //Handle an exceptions thrown.
                ApplicationUtilities.CatchExceptions(ex);
                return;
            }

            //Fill the movie titles listbox.
            FillMovieList();

            //Reset the form.
            ResetForm();
            lstMovieList.SelectedIndex = -1;
        }

        private void lstMovieList_Click(object sender, EventArgs e)
        {
            //Display the information about the movie on the form.
            ResetForm();

            //Display the movie information on the form.
            DisplayMovieInfo();

            //Enable the update movie button.
            btnUpdateMovie.Enabled = true;
        }

        private void UpdateMovie_Load(object sender, EventArgs e)
        {
            //Variable Declarations.
            LimelightBusiness business = new LimelightBusiness(repository);

            //Fill the list of movies and reviews.
            try
            {
                movies = business.GetAllMovies();
            }
            catch (Exception ex)
            {
                ApplicationUtilities.CatchExceptions(ex);
                return;
            }
            
            //Fill the movie titles listbox.
            FillMovieList();
            lstMovieList.SelectedIndex = -1;

            //Fill the genres combobox.
            FillGenreList();

            //Clear the controls on the form.
            ResetForm();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Displays the information about the movie selected from the movie listbox on the form.
        /// </summary>
        private void DisplayMovieInfo()
        {
            //Find the movie information based on the ID value of the movie title selected.
            foreach (Movie movie in movies)
            {
                //Check the movie object with the matching MovieID.
                if (movie.MovieID == (int)lstMovieList.SelectedValue)
                {
                    //Add the movie information to the form.
                    pbMoviePoster.ImageLocation = "" ;
                    pbMoviePoster.Image = movie.MoviePoster;
                    txtMovieTitle.Text = movie.Title;
                    txtMovieSynopsis.Text = movie.Synopsis;
                    dtpReleaseDate.Value = movie.ReleaseDate;
                    cmbGenre.Text = movie.GenreTitle.ToString();

                    break;
                }
            }
        }

        /// <summary>
        /// Fills the ratings combobox with the various rating levels.
        /// </summary>
        private void FillGenreList()
        {
            //Variable Declarations.
            DataSet movieGenres;
            LimelightBusiness business = new LimelightBusiness(repository);

            //Get the genre titles from the database.
            try
            {
                movieGenres = business.GetAllGenreTitles();
            }
            catch (Exception ex)
            {
                ApplicationUtilities.CatchExceptions(ex);
                return;
            }
            
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
        /// Fills the movie listbox with a list of titles for all movies in the database.
        /// </summary>
        private void FillMovieList()
        {
            //Variable Declarations.
            DataSet movieTitles;
            //AccessRepository repository = new AccessRepository();
            LimelightBusiness business = new LimelightBusiness(repository);

            //Get the movie titles from the database.
            //using (repositoy)
            //{
            //    movieTitles = repository.GetAllMovieTitles();
            //}
            movieTitles = business.GetAllMovieTitles();

            lstMovieList.DataSource = movieTitles.Tables[0];
            lstMovieList.ValueMember = "MovieID";
            lstMovieList.DisplayMember = "Title";
        }

        /// <summary>
        /// Resets the controls on the form to their beginning state.
        /// </summary>
        private void ResetForm()
        {
            pbMoviePoster.Image = null;
            pbMoviePoster.ImageLocation = ApplicationUtilities.defaultPoster;
            txtMovieTitle.Text = "";
            txtMovieSynopsis.Text = "";
            dtpReleaseDate.Value = DateTime.Now;
            cmbGenre.SelectedIndex = 0;
            btnUpdateMovie.Enabled = false;
        }

        /// <summary>
        /// Updates the movie information in the database.
        /// </summary>
        private void UpdateMovieInfo()
        {
            //Variable Declarations.
            //AccessRepository repository = new AccessRepository();
            LimelightBusiness business = new LimelightBusiness(repository);

            //Find the movie information based on the ID value of the movie title selected.
            foreach (Movie movie in movies)
            {
                //Check the movie object with the matching MovieID.
                if (movie.MovieID == (int)lstMovieList.SelectedValue)
                {
                    //Update the information for the movie selected in the movie list.
                    movie.Title = txtMovieTitle.Text;
                    movie.Synopsis = txtMovieSynopsis.Text;
                    movie.ReleaseDate = dtpReleaseDate.Value;
                    movie.GenreID = (int)cmbGenre.SelectedValue;
                    movie.GenreTitle = cmbGenre.Text;
                    movie.MoviePoster = new Bitmap(pbMoviePoster.Image);

                    //Take the image from the picture box and store in a byte array.
                    MemoryStream ms = new MemoryStream();
                    pbMoviePoster.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] moviePoster = ms.GetBuffer();

                    //Update the movie info.
                    try
                    {
                        //Insert the new movie information into the database.
                        business.UpdateMovie(movie, moviePoster);
                        
                        //Tell the user the information has ben updated successfully.
                        MessageBox.Show("The information has been updated successsfully.");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    break;
                }
            }
        }
        
        #endregion

        
    }
}
