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
                ValidMovieInformation(newMovie);

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
        /// <param name="reviewText"></param>
        public void AddReview(int ratingID, int movieID, string reviewText)
        {
            _repository.AddReview(ratingID, movieID, reviewText);
        }

        /// <summary>
        /// Deletes a movie from the database.
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteMovie(int ID)
        {
            _repository.DeleteMovie(ID);
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
            return _repository.GetAllGenreTitles();
        }

        /// <summary>
        /// Gets the information for all the movies in the database.
        /// </summary>
        /// <returns></returns>
        public List<Movie> GetAllMovies()
        {
            return _repository.GetAllMovies();
        }

        /// <summary>
        /// Gets the ID's and titles of all the movies for the movies in the database.
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllMovieTitles()
        {
            return _repository.GetAllMovieTitles();
        }

        /// <summary>
        /// Gets all the ID's and ratings from the database.
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllRatingTitles()
        {
            return _repository.GetAllRatingTitles();
        }

        /// <summary>
        /// Updates the information for a specific movie in the database.
        /// </summary>
        /// <param name="newMovie"></param>
        /// <param name="moviePoster"></param>
        public void UpdateMovie(Movie newMovie, byte[] moviePoster)
        {
            _repository.UpdateMovie(newMovie, moviePoster);
        }

        /// <summary>
        /// Checks the movie information being added or updated for valid data.
        /// </summary>
        private void ValidMovieInformation(Movie movie)
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

            //Movie Genre Title.
            //if (movie.GenreTitle == "" || movie.GenreTitle == "" || movie.GenreTitle.ToLower() == "select a genre")
            //{
            //    throw new ArgumentException();
            //}
        }

        #endregion
    }
}
