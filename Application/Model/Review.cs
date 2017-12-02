using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Review
    {
        #region FIELDS

        private int _movieID;
        private int _ratingID;
        private string _ratingTitle;
        private string _reviewerFName;
        private string _reviewerLName;
        private int _reviewID;
        private string _reviewText;

        #endregion
        
        #region PROPERTIES

        public int MovieID
        {
            get { return _movieID; }
            set { _movieID = value; }
        }
        
        public int RatingID
        {
            get { return _ratingID; }
            set { _ratingID = value; }
        }

        public string RatingTitle
        {
            get { return _ratingTitle; }
            set { _ratingTitle = value; }
        }

        public string ReviewerFName
        {
            get { return _reviewerFName; }
            set { _reviewerFName = value; }
        }

        public string ReviewerLName
        {
            get { return _reviewerLName; }
            set { _reviewerLName = value; }
        }

        public int ReviewID
        {
            get { return _reviewID; }
            set { _reviewID = value; }
        }

        public string ReviewText
        {
            get { return _reviewText; }
            set { _reviewText = value; }
        }
        
        #endregion

        #region METHODS



        #endregion
    }
}
