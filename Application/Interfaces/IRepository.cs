using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace Application
{
    interface IRepository : IDisposable
    {
        #region METHODS

        /// <summary>
        /// Deletes the movie information for the selected movie from the database.
        /// </summary>
        /// <param name="movieID"></param>
        void DeleteMovie(int movieID);

        /// <summary>
        /// Method to handle the IDisposable interface contract
        /// </summary>
        //void Dispose();

        /// <summary>
        /// Returns a dataset containing GenreID's and Genre Titles from the database.
        /// </summary>
        /// <returns></returns>
        DataSet GetAllGenreTitles();

        /// <summary>
        /// Returns a list of movie objects containing all the information about the movie from the database.
        /// </summary>
        /// <returns></returns>
        List<Movie> GetAllMovies();

        /// <summary>
        /// Returns a dataset containing MovieID's and Movie Titles from the database.
        /// </summary>
        /// <returns></returns>
        DataSet GetAllMovieTitles();

        /// <summary>
        /// Returns a dataset containing RatingID's and Rating Titles from the database.
        /// </summary>
        /// <returns></returns>
        DataSet GetAllRatingTitles();

        /// <summary>
        /// Saves the image of the movie's poster to the movie poster table in the database.
        /// </summary>
        /// <param name="newMovie"></param>
        /// <param name="newMoviePoster"></param>
        void AddMovie(Movie newMovie, byte[] newMoviePoster);

        /// <summary>
        /// Inserts a new movie review into the MovieReview table.
        /// </summary>
        /// <param name="ratingID"></param>
        /// <param name="movieID"></param>
        /// <param name="reviewText"></param>
        void AddRating(int ratingID, int movieID, string reviewText);

        /// <summary>
        /// Updates the information for an existing movie in the database.
        /// </summary>
        /// <param name="updatedMovie"></param>
        void UpdateMovie(Movie updatedMovie, byte[] updatedMoviePoster);

        #endregion
    }
}
