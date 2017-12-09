using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application
{
    public partial class ViewRecords : Form
    {
        #region FORM VARIABLES

        List<Movie> movies;
        IRepository repository = new AccessRepository();

        #endregion

        #region CONSTRUCTOR

        public ViewRecords()
        {
            InitializeComponent();
        }

        #endregion

        #region EVENTS
        
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            //Reset the controls on the form.
            ResetForm();
            lstMovieList.SelectedIndex = -1;
        }

        private void btnSaveRating_Click(object sender, EventArgs e)
        {
            //Add the rating to the database.
            AddRating();
        }

        private void lstMovieList_Click(object sender, EventArgs e)
        {
            //Display the information about the movie on the form.
            ResetForm();

            //Display the movie information on the form.
            DisplayMovieInfo();
        }

        private void ViewRecords_Load(object sender, EventArgs e)
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

            //Fill the ratings combobox.
            FillRatingsList();

            //Clear the controls on the form.
            ResetForm();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Adds a new rating and comment to the database for the selected movie.
        /// </summary>
        private void AddRating()
        {
            //Variable Declarations.
            LimelightBusiness business = new LimelightBusiness(repository);

            try
            {
                //Insert the new movie review.
                business.AddRating((int)cmbRating.SelectedValue, (int)lstMovieList.SelectedValue, txtComment.Text);

                //Refresh the list of movies.
                movies = business.GetAllMovies();
            }
            catch (Exception ex)
            {
                //Handle the exception.
                ApplicationUtilities.CatchExceptions(ex);
                return;
            }

            //Re-display the movie information on the form.
            DisplayMovieInfo();

            cmbRating.SelectedIndex = 0;
            txtComment.Text = "";
        }

        /// <summary>
        /// Displays the information about the movie selected from the movie listbox on the form.
        /// </summary>
        private void DisplayMovieInfo()
        {
            foreach (Movie movie in movies)
            {
                //Check the movie object with the matching MovieID.
                if (movie.MovieID == (int)lstMovieList.SelectedValue)
                {
                    //Add the movie information to the form.
                    pbMoviePoster.Image = movie.MoviePoster;
                    txtTitle.Text = movie.Title;
                    txtSynopsis.Text = movie.Synopsis;
                    lblReleaseDate.Text = movie.ReleaseDate.Date.ToShortDateString();
                    lblGenre.Text = movie.GenreTitle.ToString();

                    //Display the movie rating and comments (if any) in the Ratings listview.
                    lstvwReview.Items.Clear();
                    foreach (Review review in movie.Reviews)
                    {
                        string[] row = { review.RatingTitle, review.ReviewText };
                        var listViewItem = new ListViewItem(row);
                        lstvwReview.Items.Add(listViewItem);
                    }

                    break;
                }
            }
        }

        /// <summary>
        /// Fills the movie listbox with a list of titles for all movies in the database.
        /// </summary>
        private void FillMovieList()
        {
            //Variable Declarations.
            DataSet movieTitles;
            LimelightBusiness business = new LimelightBusiness(repository);

            //Get the movie titles from the database.
            try
            {
                movieTitles = business.GetAllMovieTitles();
            }
            catch (Exception ex)
            {
                ApplicationUtilities.CatchExceptions(ex);
                return;
            }
            
            //Fill the movie listbox with the movie titles.
            lstMovieList.DataSource = movieTitles.Tables[0];
            lstMovieList.ValueMember = "MovieID";
            lstMovieList.DisplayMember = "Title";
        }

        /// <summary>
        /// Fills the ratings combobox with the various rating levels.
        /// </summary>
        private void FillRatingsList()
        {
            //Variable Declarations.
            DataSet movieRatings;
            LimelightBusiness business = new LimelightBusiness(repository);

            //Get the movie titles from the database.
            try
            {
                movieRatings = business.GetAllRatingTitles();
            }
            catch (Exception ex)
            {
                ApplicationUtilities.CatchExceptions(ex);
                return;
            }
            
            //Add the genre titles to the ratings combobox.
            DataRow emptyDataRow = movieRatings.Tables[0].NewRow();
            emptyDataRow[0] = 0;
            emptyDataRow[1] = "Select A Rating";
            movieRatings.Tables[0].Rows.InsertAt(emptyDataRow, 0);


            cmbRating.DataSource = movieRatings.Tables[0];
            cmbRating.ValueMember = "RatingID";
            cmbRating.DisplayMember = "RatingTitle";
        }

        /// <summary>
        /// Resets the controls on the form to their beginning state.
        /// </summary>
        private void ResetForm()
        {
            pbMoviePoster.Image = null;
            txtTitle.Text = "";
            txtSynopsis.Text = "";
            lblReleaseDate.Text = "";
            lblGenre.Text = "";
            lstvwReview.Items.Clear();
            cmbRating.SelectedIndex = 0;
            txtComment.Text = "";
        }

        #endregion
    }
}
