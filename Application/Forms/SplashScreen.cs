using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Application
{
    public partial class SplashScreen : Form
    {
        #region CONSTRUCTOR

        public SplashScreen()
        {
            InitializeComponent();
        }

        #endregion



        #region EVENTS

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            pictureBox1.Select();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            //Variable Declarations.
            MainMenu frmMainMenu = new MainMenu();

            //Hide the splash screen.
            this.Hide();
            this.Opacity = 0;

            //Display the main menu form.
            frmMainMenu.ShowDialog();
        }
        
        #endregion
    }
}
