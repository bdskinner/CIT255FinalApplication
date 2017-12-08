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
        string sortByFields = "";

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
            //Variable Declarations.
            LimelightBusiness business = new LimelightBusiness(repository);
            List<Movie> results = new List<Movie>();

            //Validate the title if it is being used as a search criteria.
            if (chkSearchTitle.Checked == true)
            {
                try
                {
                    business.ValidateSearchTitle(txtSearchTitle.Text);
                }
                catch (Exception ex)
                {
                    //Handle an exceptions thrown.
                    ApplicationUtilities.CatchExceptions(ex);
                    return;
                }
            }

            //Validate the release date range if it is being used as a search criteria.
            if (chkSearchReleaseDate.Checked == true)
            {
                try
                {
                    business.ValidateSearchDates(dtpSearchDateFrom.Value, dtpSearchDateTo.Value);
                }
                catch (Exception ex)
                {
                    //Handle an exceptions thrown.
                    ApplicationUtilities.CatchExceptions(ex);
                    return;
                }
            }

            //Validate the release date range if it is being used as a search criteria.
            if (chkSearchGenre.Checked == true)
            {
                try
                {
                    business.ValidateSearchGenre(cmbGenre.Text);
                }
                catch (Exception ex)
                {
                    //Handle an exceptions thrown.
                    ApplicationUtilities.CatchExceptions(ex);
                    return;
                }
            }

            //Search for the movies.
            //xxx();

            //Search for the movies with that match the entered criteria.
            results = SortMovies(SearchForMovies());

            //Add the movie titles from the search result to the movie list box.
            lstMovieList.Items.Clear();
            foreach (Movie movie in results)
            {
                lstMovieList.Items.Add(movie.Title);
            }
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

        private void chkSortGenre_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSortGenre.Checked == true)
            {
                if (sortByFields == "")
                {
                    sortByFields = "Genre";
                }
                else
                {
                    if (sortByFields.Substring(0, 5) == "Title")
                    {
                        sortByFields = sortByFields.Insert(5, "Genre");
                    }
                    else
                    {
                        sortByFields = "Genre" + sortByFields;
                    }
                }
            }
            else
            {
                sortByFields = sortByFields.Replace("Genre", "");
            }
        }

        private void chkSortReleaseDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSortReleaseDate.Checked == true)
            {
                sortByFields = sortByFields + "ReleaseDate";
            }
            else
            {
                sortByFields = sortByFields.Replace("ReleaseDate", "");
            }
        }

        private void chkSortTitle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSortTitle.Checked == true)
            {
                sortByFields = "Title" + sortByFields;
            }
            else
            {
                sortByFields = sortByFields.Replace("Title", "");
            }
        }

        private void Search_Load(object sender, EventArgs e)
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

            //Fill the genres combobox.
            FillGenreList();

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
            cmbGenre.SelectedIndex = 0;

            txtSearchTitle.Text = "";
            dtpSearchDateFrom.Value = DateTime.Now;
            dtpSearchDateTo.Value = DateTime.Now;

            //Sort controls.
            chkSortTitle.Checked = false;
            chkSortReleaseDate.Checked = false;
            chkSortGenre.Checked = false;
        }

        /// <summary>
        /// Returns a list of movies that match the criteria selected by the user.
        /// </summary>
        /// <returns>List of Movies: Movies that match the criteria selected by the user.</returns>
        private List<Movie> SearchForMovies()
        {
            //Variable Declarations.
            List<Movie> results = movies;

            //Check to see if the search criteria includes the movie title.
            if (chkSearchTitle.Checked == true)
            {
                //If the movie title is used as a search criteria...

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

                //Query the list of available movies.
                var query = from x in results
                            where x.GenreTitle == cmbGenre.Text
                            select x;

                //Save the results of the query.
                results = query.ToList<Movie>();
            }

            //Return the search results.
            return results;
        }

        /// <summary>
        /// Returns a list of movies from the search that have been sorted by the criteria selected by the user.
        /// </summary>
        /// <param name="results"></param>
        /// <returns>List of Movies: Movies search results sorted by the criteria selected by the user..</returns>
        private List<Movie> SortMovies(List<Movie> results)
        {
            //Sort the results of the search.
            switch (sortByFields)
            {
                case "Title":
                    var query = from x in results
                                orderby x.Title ascending
                                select x;
                    results = query.ToList<Movie>();
                    break;
                case "ReleaseDate":
                    var query2 = from x in results
                                 orderby x.ReleaseDate ascending
                                 select x;
                    results = query2.ToList<Movie>();
                    break;
                case "Genre":
                    var query3 = from x in results
                                 orderby
                                     x.GenreTitle ascending
                                 select x;
                    results = query3.ToList<Movie>();
                    break;

                case "TitleReleaseDate":
                    var query4 = from x in results
                                 orderby
                                     x.Title,
                                     x.ReleaseDate ascending
                                 select x;
                    results = query4.ToList<Movie>();
                    break;
                case "TitleGenre":
                    var query5 = from x in results
                                 orderby
                                     x.GenreTitle,
                                     x.Title ascending
                                 select x;
                    results = query5.ToList<Movie>();
                    break;

                case "GenreReleaseDate":
                    var query6 = from x in results
                                 orderby
                                     x.GenreTitle,
                                     x.ReleaseDate ascending
                                 select x;
                    results = query6.ToList<Movie>();
                    break;
                case "TitleGenreReleaseDate":
                    var query7 = from x in results
                                 orderby
                                     x.GenreTitle,
                                     x.Title,
                                     x.ReleaseDate ascending
                                 select x;
                    results = query7.ToList<Movie>();
                    break;
                default:
                    break;
            }

            //Return the sorted search results.
            return results;
        }
        
        #endregion
    }
}
