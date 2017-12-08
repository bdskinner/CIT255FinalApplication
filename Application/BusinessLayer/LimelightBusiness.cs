using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Application
{
    class LimelightBusiness : IRepository
    {
        #region FIELDS

        IRepository _repository;

        #endregion

        #region PROPERTIES



        #endregion

        #region CONSTRUCTOR

        public LimelightBusiness(IRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Adds a new movie to the database.
        /// </summary>
        /// <param name="newMovie"></param>
        /// <param name="moviePoster"></param>
        public void AddMovie(Movie newMovie, byte[] moviePoster)
        {
            try
            {
                //Check data to make sure it is valid.
                ValidateMovieInformation(newMovie);

                //Save the movie information to the data source.
                _repository.AddMovie(newMovie, moviePoster);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Adds a new review for a movie to the database.
        /// </summary>
        /// <param name="ratingID"></param>
        /// <param name="movieID"></param>
        /// <param name="comment"></param>
        public void AddRating(int ratingID, int movieID, string comment)
        {
            try
            {
                //Validate the rating information.
                ValidateRatingInformation(ratingID, comment);

                //Add the rating to the database.
                _repository.AddRating(ratingID, movieID, comment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes a movie from the database.
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteMovie(int ID)
        {
            try
            {
                _repository.DeleteMovie(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Dispose of the business class instance.
        /// </summary>
        public void Dispose()
        {
            _repository = null;
        }

        /// <summary>
        /// Gets all the ID's and genres from the databases.
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllGenreTitles()
        {
            try
            {
                return _repository.GetAllGenreTitles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the information for all the movies in the database.
        /// </summary>
        /// <returns></returns>
        public List<Movie> GetAllMovies()
        {
            try
            {
                return _repository.GetAllMovies();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the ID's and titles of all the movies for the movies in the database.
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllMovieTitles()
        {
            try
            {
                return _repository.GetAllMovieTitles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets all the ID's and ratings from the database.
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllRatingTitles()
        {
            try
            {
                return _repository.GetAllRatingTitles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Updates the information for a specific movie in the database.
        /// </summary>
        /// <param name="newMovie"></param>
        /// <param name="moviePoster"></param>
        public void UpdateMovie(Movie newMovie, byte[] moviePoster)
        {
            try
            {
                //Validate the updated movie information.
                ValidateMovieInformation(newMovie);

                //Update the movie information in the database.
                _repository.UpdateMovie(newMovie, moviePoster);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Checks the movie information being added or updated for valid data.
        /// </summary>
        private void ValidateMovieInformation(Movie movie)
        {
            //Movie Title.
            if (movie.Title == "")
            {
                throw new ArgumentException("A movie title must be provided.");
            }

            if (movie.Title.Contains("'"))
            {
                throw new ArgumentException("Apostrophes cannot be used in the movie's title.");
            }

            //Movie Synopsis.
            if (movie.Synopsis == "")
            {
                throw new ArgumentException("A synopsis for the movie must be provided.");
            }

            if (movie.Synopsis.Contains("'"))
            {
                throw new ArgumentException("Apostrophes cannot be used in the movie's synopsis.");
            }

            //Movie Genre ID.
            if (movie.GenreID == 0)
            {
                throw new ArgumentException("Please select the genre for the movie.");
            }
        }
        
        /// <summary>
        /// Checks the rating title to make sure it is valid.
        /// </summary>
        public void ValidateRatingInformation(int ratingID, string comment)
        {
            //Check the rating selected for a valid value.
            if (ratingID == 0)
            {
                throw new ArgumentException("A rating must be chosen from the list provided.");
            }

            //If a comment was entered validate the data entered.
            if (comment != "")
            {
                if (comment.Contains("'"))
                {
                    throw new ArgumentException("Apostrophes cannot be used in the in the text of the comment.");
                }
            }
        }
        
        /// <summary>
        /// Checks the start and end date to make sure that they are valid.
        /// </summary>
        public void ValidateSearchDates(DateTime fromDate, DateTime toDate)
        {
            if (fromDate > toDate)
            {
                throw new ArgumentException("The search from date must occur before the search to date.");
            }
        }

        /// <summary>
        /// Checks the genre title to make sure it is valid.
        /// </summary>
        public void ValidateSearchGenre(string genreTitle)
        {
            switch (genreTitle)
            {
                case "":
                case "Select A Genre":
                    throw new ArgumentException("A genre must be chosen to use the genre as a search criteria.");
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Checks the movie title being searched forto make sure it contains valid data.
        /// </summary>
        public void ValidateSearchTitle(string movieTitle)
        {
            if (movieTitle == "")
            {
                throw new ArgumentException("To search by movie title a movie title must be provided.");
            }

            if (movieTitle.Contains("'"))
            {
                throw new ArgumentException("Apostrophes cannot be used in the movie's title.");
            }
        }

        #endregion
    }
}
