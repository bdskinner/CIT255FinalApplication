using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.IO;

namespace Application
{
    public class AccessRepository : IDisposable, IRepository
    {
        #region FIELDS
        
        private static string _dbConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Data\\Limelight.accdb;";
        private List<Movie> _movies;
        private List<Review> _reviews;   

        #endregion

        #region CONSTRUCTOR(S)

        public AccessRepository()
        {
            _reviews = ReadAllReviews();
            _movies = ReadAllMovies();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Inserts an image into the the database.
        /// </summary>
        /// <param name="movieID"></param>
        /// <param name="Image"></param>
        private void AddImage(int movieID, byte[] Image)
        {
            //Code Found at Site: Stack overflow
            //URL: https://stackoverflow.com/questions/15273617/c-sharp-insert-picture-into-ms-access


            //Variable Declarations.
            OleDbConnection dbConnection;
            dbConnection = ConnectToDatabase();
            
            // You've got the filename from the result of your OpenDialog operation
            //var pic = File.ReadAllBytes(yourFileName);
            OleDbCommand cmd = new OleDbCommand("INSERT INTO MoviePosters (MovieID, MoviePoster) VALUES (@p1, @p2)", dbConnection);
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "INSERT INTO MoviePosters (MovieID, MoviePoster) VALUES (@p1, @p2)";
            cmd.Parameters.AddWithValue("@p1", movieID);
            cmd.Parameters.AddWithValue("@p2", Image);
            
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        /// <summary>
        /// Saves the image of the movie's poster to the movie poster table in the database.
        /// </summary>
        /// <param name="newMovie"></param>
        /// <param name="newMoviePoster"></param>
        public void AddMovie(Movie newMovie, byte[] newMoviePoster)
        {
            //Variable Declarations.
            int newMovieIDValue = 0;
            string sqlStatement = $"INSERT INTO MovieInformation ( Title, Synopsis, ReleaseDate, GenreID ) VALUES ( '{newMovie.Title}', '{newMovie.Synopsis}', '{newMovie.ReleaseDate}', {newMovie.GenreID} );";

            //Insert the new movie information into the MovieInformation Table.
            newMovieIDValue = ExecuteSQLGetIDValue(sqlStatement);

            //Insert the movie poster image into the MoviePosters table.
            AddImage(newMovieIDValue, newMoviePoster);
        }

        /// <summary>
        /// Inserts a new movie review into the MovieReview table.
        /// </summary>
        /// <param name="ratingID"></param>
        /// <param name="movieID"></param>
        /// <param name="reviewText"></param>
        public void AddReview(int ratingID, int movieID, string reviewText)
        {
            //Insert the new review into the MovieReviews table.
            ExecuteSQL($"INSERT INTO MovieReviews ( ReviewText, RatingID, MovieID ) VALUES ( '{reviewText}', {ratingID}, {movieID});");
        }

        /// <summary>
        /// Connects to a local instance of a ms access database.
        /// </summary>
        /// <returns>OleDbConnection: Returns a connection to an OleDb database.</returns>
        private static OleDbConnection ConnectToDatabase()
        {
            //Variable Declarations.            
            //OleDbConnection sqlServerCnct = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Users\\Ben\\Documents\\CSharp Projects\\DatabaseInfo\\DatabaseInfo.accdb;");
            OleDbConnection databaseCnct = new OleDbConnection(_dbConnectionString);

            //Return the connection object.
            return databaseCnct;
        }

        /// <summary>
        /// Deletes the movie information for the selected movie from the database.
        /// </summary>
        /// <param name="movieID"></param>
        public void DeleteMovie(int movieID)
        {
            //Variable Declarations.
            string sqlStatement = $"DELETE FROM MovieInformation WHERE MovieID = {movieID};";

            //Delete the movie information from the MovieInformation table.
            ExecuteSQL(sqlStatement);

            //Delete the movie's poster image from the MoviePosters table.
            sqlStatement = $"DELETE FROM MoviePosters WHERE MovieID = {movieID};";
            ExecuteSQL(sqlStatement);
        }

        /// <summary>
        /// Method to handle the IDisposable interface contract
        /// </summary>
        public void Dispose()
        {
            _movies = null;
            _reviews = null;
        }

        /// <summary>
        /// Executes the provided sql statement.
        /// </summary>
        /// <param name="sqlstatement"></param>
        private static void ExecuteSQL(string sqlstatement)
        {
            //Variable Declarations.
            OleDbConnection dbConnection;
            OleDbCommand command;

            //Create a connection to the database.
            dbConnection = ConnectToDatabase();
            command = new OleDbCommand(sqlstatement, dbConnection);

            //Execute the sql statement.
            dbConnection.Open();
            command.ExecuteNonQuery();
            dbConnection.Close();
        }

        /// <summary>
        /// Executes the provided sql statement and returns the ID value of the record inserted if an insert operation was performed.
        /// </summary>
        /// <param name="sqlStatement"></param>
        /// <returns></returns>
        private static int ExecuteSQLGetIDValue(string sqlStatement)
        {
            //Code Found At
            //Site: Microsoft MSDN Website
            //URL: https://social.msdn.microsoft.com/Forums/vstudio/en-US/3195f7bd-9024-4d68-b162-30a75f9d36a3/how-to-get-last-inserted-id-in-c-using-mysql-msaccess?forum=wpf

            //Variable Declarations.
            OleDbConnection dbConnection;
            OleDbCommand command;
            int ID;
            string getIDValueQuery = "Select @@Identity";



            //Create a connection to the database.
            dbConnection = ConnectToDatabase();
            command = new OleDbCommand(sqlStatement, dbConnection);

            //using (OleDbCommand cmd = new OleDbCommand(sqlStatement, dbConnection))

            //    {
            //        cmd.Parameters.AddWithValue("", Category.Text);
            //        dbConnection.Open();
            //        cmd.ExecuteNonQuery();
            //        cmd.CommandText = query2;
            //        ID = (int)cmd.ExecuteScalar();

            //    }

            //Execute the sql statement.
            dbConnection.Open();
            command.ExecuteNonQuery();
            command.CommandText = getIDValueQuery;
            ID = (int)command.ExecuteScalar();
            dbConnection.Close();

            //Return the ID value for the record just inserted.
            return ID;
        }

        /// <summary>
        /// Returns a dataset containing GenreID's and Genre Titles from the database.
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllGenreTitles()
        {
            //Variable Declarations.
            DataSet genreTitles = new DataSet();

            //Get all movie titles in the database.
            genreTitles = GetSQLResults("SELECT GenreID, GenreTitle FROM Genres ORDER BY GenreTitle;");

            //Return the results.
            return genreTitles;
        }

        /// <summary>
        /// Returns a list of movie objects containing all the information about the movie from the database.
        /// </summary>
        /// <returns></returns>
        public List<Movie> GetAllMovies()
        {
            //Return the list of movies.
            return _movies;
        }
        
        /// <summary>
        /// Returns a dataset containing MovieID's and Movie Titles from the database.
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllMovieTitles()
        {
            //Variable Declarations.
            DataSet movieTitles = new DataSet();

            //Get all movie titles in the database.
            movieTitles = GetSQLResults("SELECT MovieID, Title FROM MovieInformation ORDER BY Title");

            //Return the results.
            return movieTitles;
        }

        /// <summary>
        /// Returns a dataset containing RatingID's and Rating Titles from the database.
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllRatingTitles()
        {
            //Variable Declarations.
            DataSet ratingTitles = new DataSet();

            //Get all movie titles in the database.
            ratingTitles = GetSQLResults("SELECT RatingID, RatingTitle FROM Ratings ORDER BY RatingID DESC;");

            //Return the results.
            return ratingTitles;
        }

        /// <summary>
        /// Returs a movie poster iaage based on the value in the MovieId parameter.
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns>MemoryStream: memorystream contains image for movie poster.</returns>
        private MemoryStream GetImageByID(int movieID)
        {
            //Variable Declarations.
            OleDbDataAdapter da = new OleDbDataAdapter();
            MemoryStream ms = null;
            DataSet results = null;

            //Retrieve the movie poster image.
            results = GetSQLResults($"SELECT MoviePoster FROM MoviePosters WHERE MovieID = {movieID}");

            //Store the image in a memorystream.
            if (results.Tables[0].Rows.Count > 0)
            {
                ms = new MemoryStream((byte[])results.Tables[0].Rows[0]["MoviePoster"]);
            }

            //Return the image in a memory stream.
            return ms;
        }

        /// <summary>
        /// Returns all informatio
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        private DataSet GetMovieInfoByID(int movieID)
        {
            //Variable Declarations.
            DataSet movieTitles = new DataSet();

            //Get all movie titles in the database.
            movieTitles = GetSQLResults($"SELECT * FROM MovieInformation WHERE MovieID = {movieID}");

            //Return the results.
            return movieTitles;
        }

        /// <summary>
        /// Returns a list of list of reviews for the MoviedID provided.
        /// </summary>
        /// <param name="movieID"></param>
        /// <returns></returns>
        private List<Review> GetReviewsByMovieID(int movieID)
        {
            //Variable Declarations.
            List<Review> reviews = new List<Review>();

            //Loop through the list of reviews and find the review(s) with the ID value provided.
            foreach (Review review in _reviews)
            {
                if (review.MovieID == movieID)
                {
                    reviews.Add(review);
                }
            }

            //Return the results.
            return reviews;
        }

        /// <summary>
        /// Returns a list of all user defined database objects in a string array to the calling method.
        /// </summary>
        /// <returns>DataSet: Contains a list of database objects that were retrieved using the query in the sqlStatement parameter. </returns>
        private static DataSet GetSQLResults(string sqlStatement)
        {
            //Variable Declarations.
            OleDbConnection dbConnection = new OleDbConnection();
            DataSet dbObjects = new DataSet();

            //Create a connection to the database.
            dbConnection = ConnectToDatabase();

            //Open the database connection.
            dbConnection.Open();

            //Fill the dataset with the results from the database.
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlStatement, dbConnection);
            adapter.Fill(dbObjects);

            //Close the database connection.
            dbConnection.Close();

            //Return the results.
            return dbObjects;
        }
        
        /// <summary>
        /// Reads all the movie information the movie from the database and adds a new Movie object for each movie to a list of movies.
        /// </summary>
        /// <returns></returns>
        private List<Movie> ReadAllMovies()
        {
            //Variable Declarations.
            DataSet moviesDS = new DataSet();
            List<Movie> movies = new List<Movie>();

            //Get all movie titles in the database.
            //moviesDS = GetSQLResults("SELECT * FROM MovieInformation ORDER BY Title");
            moviesDS = GetSQLResults("SELECT MovieInformation.MovieID, MovieInformation.Title, MovieInformation.Synopsis, MovieInformation.ReleaseDate, MovieInformation.GenreID, Genres.GenreTitle FROM MovieInformation INNER JOIN Genres ON MovieInformation.GenreID = Genres.GenreID;");
            
            //Loop through the dataset and add a movie object to the list of movies.
            foreach (DataRow movie in moviesDS.Tables[0].Rows)
            {
                //Create a new movie object.
                Movie newMovie = new Movie();

                //Save the movie information to the new movie object.
                //newMovie.MovieID = moviesDS.Tables[0].Columns["MovieID"];
                newMovie.MovieID = movie.Field<int>("MovieID");
                newMovie.Title = movie.Field<string>("Title");
                newMovie.Synopsis = movie.Field<string>("Synopsis");
                newMovie.ReleaseDate = movie.Field<DateTime>("ReleaseDate");
                newMovie.GenreID = movie.Field<int>("GenreID");
                newMovie.GenreTitle = movie.Field<string>("GenreTitle");
                newMovie.Reviews = GetReviewsByMovieID(newMovie.MovieID);
                newMovie.MoviePoster = new Bitmap(GetImageByID(newMovie.MovieID));

                //Add the new movie object to the movie list.
                movies.Add(newMovie);

                newMovie = null;
            }

            moviesDS.Dispose();
            
            //Return the results.
            return movies;
        }

        /// <summary>
        /// Reads all the movie information the movie from the database and adds a new Movie object for each movie to a list of movies.
        /// </summary>
        /// <returns></returns>
        private List<Review> ReadAllReviews()
        {
            //Variable Declarations.
            DataSet reviewsDS = new DataSet();
            List<Review> reviews = new List<Review>();

            //Get all movie titles in the database.
            reviewsDS = GetSQLResults("SELECT MovieReviews.ReviewID, MovieReviews.ReviewerFName, MovieReviews.ReviewerLName, MovieReviews.ReviewText, MovieReviews.RatingID, MovieReviews.MovieID, Ratings.RatingTitle FROM MovieReviews INNER JOIN Ratings ON MovieReviews.RatingID = Ratings.RatingID;");

            //Loop through the dataset and add a movie object to the list of movies.
            foreach (DataRow review in reviewsDS.Tables[0].Rows)
            {
                //Create a new movie object.
                Review newReview = new Review();

                //Save the review information to the new review object.
                newReview.ReviewID = review.Field<int>("ReviewID");
                newReview.ReviewerFName = review.Field<string>("ReviewerFName");
                newReview.ReviewerLName = review.Field<string>("ReviewerLName");
                newReview.ReviewText = review.Field<string>("ReviewText");
                newReview.RatingID = review.Field<int>("RatingID");
                newReview.MovieID = review.Field<int>("MovieID");
                newReview.RatingTitle = review.Field<string>("RatingTitle");

                //Add the new movie object to the list of reviews.
                reviews.Add(newReview);

                newReview = null;
            }

            reviewsDS.Dispose();

            //Return the results.
            return reviews;
        }        

        /// <summary>
        /// Updates the information for an existing movie in the database.
        /// </summary>
        /// <param name="updatedMovie"></param>
        public void UpdateMovie(Movie updatedMovie, byte[] updatedMoviePoster)
        {
            //Variable Declarations.
            string sqlStatement = $"UPDATE MovieInformation SET Title = '{updatedMovie.Title}', Synopsis = '{updatedMovie.Synopsis}', ReleaseDate = '{updatedMovie.ReleaseDate}', GenreID = {updatedMovie.GenreID} WHERE MovieID = {updatedMovie.MovieID};";

            //Update the existing movie information in the MovieInformation Table.
            ExecuteSQL(sqlStatement);
            
            //Delete the current image from the MoviePosters table.
            sqlStatement = $"DELETE * FROM MoviePosters WHERE MovieID = {updatedMovie.MovieID}";
            ExecuteSQL(sqlStatement);

            //Insert the movie poster image into the MoviePosters table.
            AddImage(updatedMovie.MovieID, updatedMoviePoster);
        }

        #endregion
    }
}
