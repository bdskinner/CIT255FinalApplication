using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application
{
    public partial class Search : Form
    {
        #region FORM VARIABLES

        List<Movie> movies;
        IRepository repository = new AccessRepository();

        #endregion

        #region CONSTRUCTOR

        public Search()
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
            ResetForm();
            lstMovieList.SelectedIndex = -1;
        }

        private void btnSearchMovie_Click(object sender, EventArgs e)
        {
            xxx();
        }

        private void chkSearchGenre_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSearchGenre.Checked == true)
            {
                cmbGenre.Enabled = true;
            }
            else
            {
                cmbGenre.SelectedIndex = 0;
                cmbGenre.Enabled = false;
            }
        }

        private void chkSearchRating_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSearchRating.Checked == true)
            {
                cmbRating.Enabled = true;
            }
            else
            {
                cmbRating.Enabled = false;
            }
        }

        private void chkSearchReleaseDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSearchReleaseDate.Checked == true)
            {
                dtpSearchDateFrom.Enabled = true;
                dtpSearchDateTo.Enabled = true;
            }
            else
            {
                dtpSearchDateFrom.Value = DateTime.Now;
                dtpSearchDateTo.Value = DateTime.Now;

                dtpSearchDateFrom.Enabled = false;
                dtpSearchDateTo.Enabled = false;
            }
        }

        private void chkSearchTitle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSearchTitle.Checked == true)
            {
                txtSearchTitle.Enabled = true;
            }
            else
            {
                txtSearchTitle.Text = "";
                txtSearchTitle.Enabled = false;
            }
        }

        private void Search_Load(object sender, EventArgs e)
        {
            //Variable Declarations.
            //AccessRepository repository = new AccessRepository();
            LimelightBusiness business = new LimelightBusiness(repository);

            //Fill the list of movies and reviews.
            //using (repository)
            //{
            //    movies = repository.GetAllMovies();
            //}
            movies = business.GetAllMovies();

            //Fill the movie titles listbox.
            //FillMovieList();
            //lstMovieList.SelectedIndex = -1;

            //Fill the genres combobox.
            FillGenreList();

            //Fill the ratings combobox.
            FillRatingsList();

            //Clear the controls on the form.
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
            // AccessRepository repository = new AccessRepository();
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
        /// Displays the current list of movies in the movie listbox.
        /// </summary>
        private void FillMovieList()
        {
            //Variable Declarations.
            DataSet movieTitles;
            //AccessRepository repository = new AccessRepository();
            LimelightBusiness business = new LimelightBusiness(repository);

            //Get the movie titles from the database.
            //using (repository)
            //{
            //    movieTitles = repository.GetAllMovieTitles();
            //}
            movieTitles = business.GetAllMovieTitles();
            
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
            //AccessRepository repository = new AccessRepository();
            LimelightBusiness business = new LimelightBusiness(repository);

            //Get the movie titles from the database.
            //using (repository)
            //{
            //    movieRatings = repository.GetAllRatingTitles();
            //}
            movieRatings = business.GetAllRatingTitles();

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
            //Reset the form controls to their initial state.

            //Movie Listbox.
            lstMovieList.Items.Clear();

            //Search controls.
            chkSearchTitle.Checked = false;
            chkSearchReleaseDate.Checked = false;
            chkSearchGenre.Checked = false;
            chkSearchRating.Checked = false;
            cmbGenre.SelectedIndex = 0;
            cmbRating.SelectedIndex = 0;

            txtSearchTitle.Text = "";
            dtpSearchDateFrom.Value = DateTime.Now;
            dtpSearchDateTo.Value = DateTime.Now;

            //Sort controls.
            chkSortTitle.Checked = false;
            chkSortReleaseDate.Checked = false;
            chkSortGenre.Checked = false;
            chkSortRating.Checked = false;
        }








        private void xxx()
        {
            //Variable Declarations.
            List<Movie> results = movies;

            //Check to see if the search criteria includes the movie title.
            if (chkSearchTitle.Checked == true)
            {
                //If the movie title is used as a search criteria...

                //Check for valid search data.
                if (txtSearchTitle.Text =="")
                {
                    MessageBox.Show("A value must be entered to use the title as a search criteria.");
                    txtSearchTitle.Focus();
                    return;
                }

                //Query the list of available movies.
                var query = from x in results
                    where x.Title.ToLower().Contains(txtSearchTitle.Text.ToLower())
                    select x;
                
                //Save the results of the query.
                results = query.ToList<Movie>();
            }

            //Check to see if the search criteria includes the release date.
            if (chkSearchReleaseDate.Checked == true)
            {
                //If the movie's release date is used as a search criteria...

                //Check for valid search data.
                if (dtpSearchDateTo.Value < dtpSearchDateFrom.Value)
                {
                    MessageBox.Show("The search from date must occur before the search to date.");
                    dtpSearchDateFrom.Focus();
                    return;
                }

                //Query the list of available movies.
                var query = from x in results
                    where 
                        x.ReleaseDate >= dtpSearchDateFrom.Value &&
                        x.ReleaseDate <= dtpSearchDateTo.Value
                   select x;

                //Save the results of the query.
                results = query.ToList<Movie>();
            }

            //Check to see if the search criteria includes the genre.
            if (chkSearchGenre.Checked == true)
            {
                //If the movie genre is used as a search criteria...

                //Check for valid search data.
                if (cmbGenre.SelectedIndex == 0)
                {
                    MessageBox.Show("A genre must be chosen to use the genre as a search criteria.");
                    cmbGenre.Focus();
                    return;
                }

                //Query the list of available movies.
                var query = from x in results
                            where x.GenreTitle == cmbGenre.Text
                            select x;

                //Save the results of the query.
                results = query.ToList<Movie>();
            }









            //Sort the results.
            if (chkSortTitle.Checked == true)
            {
                if (chkSortReleaseDate.Checked == true)
                {
                    if (chkSortGenre.Checked == true)
                    {
                        //Sort by Title, Release Date, and Genre.
                        var query = from x in results
                                    orderby
                                        x.Title,
                                        x.ReleaseDate,
                                        x.GenreTitle ascending
                                    select x;

                        //Save the results of the query.
                        results = query.ToList<Movie>();
                    }
                    else
                    {
                        //Sort by Title and Release Date.
                        var query = from x in results
                                    orderby
                                        x.Title,
                                        x.ReleaseDate ascending
                                    select x;

                        //Save the results of the query.
                        results = query.ToList<Movie>();
                    }
                }
                else
                {
                    if (chkSortGenre.Checked == true)
                    {
                        //Sort by Title and Genre.
                        var query = from x in results
                                    orderby
                                        x.Title,
                                        x.GenreTitle ascending
                                    select x;

                        //Save the results of the query.
                        results = query.ToList<Movie>();
                    }
                    else
                    {
                        //Sort by Title.
                        var query = from x in results
                                    orderby x.Title ascending
                                    select x;

                        //Save the results of the query.
                        results = query.ToList<Movie>();
                    }
                }
            }

            if (chkSortReleaseDate.Checked == true)
            {
                if (chkSortGenre.Checked == true)
                {
                    //Sort by Title, Release Date, and Genre.
                    var query = from x in results
                                orderby
                                    x.ReleaseDate,
                                    x.GenreTitle ascending
                                select x;

                    //Save the results of the query.
                    results = query.ToList<Movie>();
                }
                else
                {
                    //Sort by Title and Release Date.
                    var query = from x in results
                                orderby
                                    x.ReleaseDate ascending
                                select x;

                    //Save the results of the query.
                    results = query.ToList<Movie>();
                }
            }

            if (chkSortGenre.Checked == true)
            {
                //Sort by Title, Release Date, and Genre.
                var query = from x in results
                            orderby
                                x.GenreTitle ascending
                            select x;

                //Save the results of the query.
                results = query.ToList<Movie>();
            }





            //results2 = results.OrderBy(x => x.Title).ThenBy(x => x.GenreTitle);





            //Add the movie titles from the search result to the movie list box.
            lstMovieList.Items.Clear();
            foreach (Movie movie in results)
            {
                lstMovieList.Items.Add(movie.Title);
            }
        }

        #endregion
    }
}
