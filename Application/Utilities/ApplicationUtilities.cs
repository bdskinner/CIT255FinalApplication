using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.IO;

namespace Application
{
    public static class ApplicationUtilities
    {
        #region GLOBAL VARIABLES

        public const string defaultPoster = "Images\\ComingSoon.jpg";

        #endregion

        #region METHODS

        /// <summary>
        /// Handles exceptions thrown during application operations.
        /// </summary>
        /// <param name="exc"></param>
        public static void CatchExceptions(Exception exc)
        {
            if (exc is DriveNotFoundException)
            {
                //Display the error message on the screen.
                MessageBox.Show(exc.Message.ToString());
                return;
            }
            else if (exc is DirectoryNotFoundException)
            {
                //Display the error message on the screen.
                MessageBox.Show(exc.Message.ToString());
                return; 
            }
            else if (exc is FileNotFoundException)
            {
                //Display the error message on the screen.
                MessageBox.Show(exc.Message.ToString());
                return;
            }
            else if (exc is EndOfStreamException)
            {
                //Display the error message on the screen.
                MessageBox.Show(exc.Message.ToString());
                return;
            }
            else if (exc is ArgumentException)
            {
                //Display the error message on the screen.
                MessageBox.Show(exc.Message.ToString());
                return;
            }
            if (exc is NoNullAllowedException)
            {
                //Display the error message on the screen.
                MessageBox.Show(exc.Message.ToString());
                return;
            }
            else if (exc is ArgumentOutOfRangeException)
            {
                //Display the error message on the screen.
                MessageBox.Show(exc.Message.ToString());
                return;
            }
            else if (exc is Exception)
            {
                //Display the error message on the screen.
                MessageBox.Show(exc.Message.ToString());
                return;
            }
        }
        
        /// <summary>
        /// Displays the open file dialog to allow the user to select an image for a movie's poster.
        /// </summary>
        /// <returns>String: the full path to the image selected.</returns>
        public static string ChooseImageFile()
        {
            //Code found at: 
            //  Site Name: stackoverflow.com
            //  URL: http://stackoverflow.com/questions/24449988/how-to-get-file-path-from-openfiledialog-and-folderbrowserdialog

            //Create and display an open file dialog box.
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Image Files | *.jpg; *.png; *.bmp";

            //Get the path of the file selected.
            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                //label1.Text = choofdlog.FileName;
                //pbMoviePoster.Image = choofdlog.FileName;

                //pbMoviePoster.ImageLocation = choofdlog.FileName;
                return choofdlog.FileName;
            }

            return "";
        }

        /// <summary>
        /// Fills a winforms control (listbox, combobox) with the genres from the database.
        /// </summary>
        /// <returns>Control: The control that has been filled with the genres.</returns>
        public static Control FillGenreList()
        {
            //Variable Declarations.
            ComboBox genreControl = new ComboBox();
            DataSet movieGenres;

            AccessRepository repository = new AccessRepository();

            //Get the genre titles from the database.
            using (repository)
            {
                movieGenres = repository.GetAllGenreTitles();
            }

            //Add the genre titles to the genre combobox.
            DataRow emptyDataRow = movieGenres.Tables[0].NewRow();
            emptyDataRow[0] = 0;
            emptyDataRow[1] = "Select A Genre";
            movieGenres.Tables[0].Rows.InsertAt(emptyDataRow, 0);

            genreControl.DataSource = movieGenres.Tables[0];
            genreControl.ValueMember = "GenreID";
            genreControl.DisplayMember = "GenreTitle";

            //Return the filled control.
            return genreControl;
        }

        public static Control FillMovieList()
        {
            //Variable Declarations.
            ListBox movieListControl = new ListBox();
            DataSet movieTitles;

            AccessRepository repository = new AccessRepository();

            //Get the movie titles from the database.
            movieTitles = repository.GetAllMovieTitles();

            movieListControl.DataSource = movieTitles.Tables[0];
            movieListControl.ValueMember = "MovieID";
            movieListControl.DisplayMember = "Title";

            //Return the control.
            return movieListControl;
        }

        public static Control FillRatingsList()
        {
            //Variable Declarations.
            DataSet movieRatings;
            ComboBox ratingsControl = new ComboBox();
            AccessRepository repository = new AccessRepository();

            //Get the movie titles from the database.
            using (repository)
            {
                movieRatings = repository.GetAllRatingTitles();
            }

            //Add the genre titles to the ratings combobox.
            DataRow emptyDataRow = movieRatings.Tables[0].NewRow();
            emptyDataRow[0] = 0;
            emptyDataRow[1] = "Select A Rating";
            movieRatings.Tables[0].Rows.InsertAt(emptyDataRow, 0);


            ratingsControl.DataSource = movieRatings.Tables[0];
            ratingsControl.ValueMember = "RatingID";
            ratingsControl.DisplayMember = "RatingTitle";

            //Return the control.
            return ratingsControl;
        }

        #endregion
    }
}
