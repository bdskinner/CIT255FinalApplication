using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Variable Declarations.
            ClosingScreen closingScreen = new ClosingScreen();

            //Hide the main menu form.
            this.Hide();

            //Show the form.
            closingScreen.ShowDialog();
        }

        private void btnAddMovies_Click(object sender, EventArgs e)
        {
            //Variable Declarations.
            AddMovie addRecords = new AddMovie();

            //Show the form.
            addRecords.ShowDialog();
        }

        private void btnViewMovies_Click(object sender, EventArgs e)
        {
            //Variable Declarations.
            ViewRecords viewRecords = new ViewRecords();

            //Show the form.
            viewRecords.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search searchForMovies = new Search();

            searchForMovies.ShowDialog();
        }

        private void btnUpdateMovies_Click(object sender, EventArgs e)
        {
            UpdateMovie updateMovie = new UpdateMovie();

            updateMovie.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteMovie deleteMovie = new DeleteMovie();

            deleteMovie.ShowDialog();
        }
    }
}
