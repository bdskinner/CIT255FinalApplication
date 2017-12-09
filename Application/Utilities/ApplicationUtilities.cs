using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
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
            else if (exc is DeletedRowInaccessibleException)
            {
                //Display the error message on the screen.
                MessageBox.Show(exc.Message.ToString());
                return;
            }
            else if (exc is OleDbException)
            {
                //Display the error message on the screen.
                MessageBox.Show(exc.Message.ToString());
                return;
            }
            else if (exc is ReadOnlyException)
            {
                //Display the error message on the screen.
                MessageBox.Show(exc.Message.ToString());
                return;
            }
            else if (exc is RowNotInTableException)
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
                //Check the file type of the file selected.
                if (choofdlog.FileName.Substring(choofdlog.FileName.Length - 4) != "jpeg" && choofdlog.FileName.Substring(choofdlog.FileName.Length - 3) != "jpg" && choofdlog.FileName.Substring(choofdlog.FileName.Length - 3) != "png" && choofdlog.FileName.Substring(choofdlog.FileName.Length - 3) != "bmp")
                {
                    //If an image file was not selected throw an error.
                    throw new ArgumentException("The file selected for the movie poster image must be an image file (.jpg, .png. or .bmp).");
                }
                else
                {
                    //If an image file was selected return the path.
                    return choofdlog.FileName;
                }
            }

            return choofdlog.FileName; 
        }
        
        #endregion
    }
}
