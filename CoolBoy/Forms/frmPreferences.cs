using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            // By default, the selected path of the dialog will be the current one
            fbdWeb.SelectedPath = _utilities.WebFolder;
            DialogResult result = fbdWeb.ShowDialog();

            if (result == DialogResult.OK)
                tbxFolder.Text = fbdWeb.SelectedPath + Path.DirectorySeparatorChar;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // Ignore any changes and close the window
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            // TODO: save changes to configuration file
            if (!tbxFolder.Text.EndsWith(Path.DirectorySeparatorChar.ToString()))
                tbxFolder.Text += Path.DirectorySeparatorChar;

            if (!Directory.Exists(tbxFolder.Text))
            {
                MessageBox.Show("The selected folder doesn't exist", "Folder error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (tbxFolder.Text != _utilities.WebFolder)
                    _utilities.WebFolder = tbxFolder.Text;
            }

            if (tbxStart.Text != _utilities.StartPage)
                _utilities.StartPage = tbxStart.Text;

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
