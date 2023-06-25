using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint.EntryForms
{
    public partial class SetPolygonValuesForm : Form
    {
        public SetPolygonValuesForm()
        {
            InitializeComponent();
        }

        public int SidesQty { get; private set; }

        public int Inscribed { get; private set; }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sides.Text) || (Convert.ToInt32(sides.Text) < 3))
            {
                MessageBox.Show("Sides entry is not correct", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sides.Focus();
                return;
            }

            SidesQty = Convert.ToInt32(sides.Text);
            Inscribed = inscribed.SelectedIndex;
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetPolygonValuesForm_Load(object sender, EventArgs e)
        {
            Text = "Polygon setting";
            inscribed.SelectedIndex = 0;
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - Width - 20;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - Height - 20;
        }

        private void sides_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
