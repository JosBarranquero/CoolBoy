using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolBoy.Forms
{
    public partial class frmPreferences : Form
    {
        Utilities _utilities;

        public frmPreferences()
        {
            InitializeComponent();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            fbdWeb.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // Ignore any changes and close the window
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            // TODO: save changes

            this.Close();   // Finally, close the window
        }

        private void frmPreferences_Load(object sender, EventArgs e)
        {
            _utilities = Utilities.Instance;

            tbxFolder.Text = _utilities.WebFolder;
            tbxStart.Text = _utilities.StartPage;
        }
    }
}
