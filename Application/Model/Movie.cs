using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Application
{
    public class Movie
    {
        #region FIELDS

        private int _genreID;
        private string _genreTitle;
        private int _movieID;
        private Bitmap _moviePoster;
        private DateTime _releaseDate;
        private List<Review> _reviews;
        private string _synopsis;
        private string _title;

        #endregion

        #region PROPERTIES
        
        public int GenreID
        {
            get { return _genreID; }
            set { _genreID = value; }
        }

        public string GenreTitle
        {
            get { return _genreTitle; }
            set { _genreTitle = value; }
        }

        public int MovieID
        {
            get { return _movieID; }
            set { _movieID = value; }
        }

        public Bitmap MoviePoster
        {
            get { return _moviePoster; }
            set { _moviePoster = value; }
        }

        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value; }
        }

        public List<Review> Reviews
        {
            get { return _reviews; }
            set { _reviews = value; }
        }

        public string Synopsis
        {
            get { return _synopsis; }
            set { _synopsis = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        #endregion

        #region METHODS



        #endregion
    }
}
