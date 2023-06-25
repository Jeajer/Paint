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
    public partial class GetDoubleValue : Form
    {
        public GetDoubleValue()
        {
            InitializeComponent();
        }

        public string Title { get; set; }

        public double ResultValue { get; set; }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtValue.Text))
            {
                ResultValue = Convert.ToDouble(txtValue.Text);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Input value is not correct", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValue.Focus();
                return;
            }
        }

        private void GetDoubleValue_Load(object sender, EventArgs e)
        {
            Text = "Get " + Title + " Value";
            Left = Screen.PrimaryScreen.WorkingArea.Width - Width - 20;
            Top = Screen.PrimaryScreen.WorkingArea.Height - Height - 20;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
