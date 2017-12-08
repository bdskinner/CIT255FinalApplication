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
    public partial class DeleteMovie : Form
    {
        #region FORM VARIABLES

        List<Movie> movies;
        IRepository repository = new AccessRepository();

        #endregion

        #region CONSTRUCTOR

        public DeleteMovie()
        {
            InitializeComponent();
        }

        #endregion

        #region EVENTS

        private void DeleteMovie_Load(object sender, EventArgs e)
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

            //Reset the form.
            ResetForm();
            lstMovieList.SelectedIndex = -1;
        }

        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show($"Do you really wish to delete {lstMovieList.Text}", "Delete Movie?", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    //Delete a movie from the database.
                    DeleteAMovie();

                    //Refresh the movie list.
                    FillMovieList();

                    //Reset the form controls.
                    ResetForm();
                    lstMovieList.SelectedIndex = -1;

                    //Tell the user the movie has been deleted.
                    MessageBox.Show("The movie has been successfully deleted.");

                    break;
                case DialogResult.No:
                    break;
                default:
                    break;
            }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
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

            //Enable the delete button.
            btnDeleteMovie.Enabled = true;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Deletes the selected movie from the database.
        /// </summary>
        private void DeleteAMovie()
        {
            //Variable Declarations.
            LimelightBusiness business = new LimelightBusiness(repository);
            
            try
            {
                //Delete the selected movie.
                business.DeleteMovie((int)lstMovieList.SelectedValue);
            }
            catch (Exception ex)
            {
                //Handle the exception.
                ApplicationUtilities.CatchExceptions(ex);
            }
        }

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
                    pbMoviePoster.Image = movie.MoviePoster;
                    lblMovieTitle.Text = movie.Title;

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
        /// Resets the controls on the form to their beginning state.
        /// </summary>
        private void ResetForm()
        {
            pbMoviePoster.Image = null;
            lblMovieTitle.Text = "";
            btnDeleteMovie.Enabled = false;
        }

        #endregion
    }
}
