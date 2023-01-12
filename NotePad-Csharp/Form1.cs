using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad_Csharp
{
    public partial class Form1 : Form
    {
        DataTable tableList;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tableList = new DataTable();

            tableList.Columns.Add("Title", typeof(string));
            tableList.Columns.Add("Note", typeof(string));

            dgvNote.DataSource = tableList;

            dgvNote.Columns["Note"].Visible = false;
            dgvNote.Columns["Title"].Width = 245;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            titleBox.Clear();
            noteBox.Clear();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tableList.Rows.Add(titleBox.Text, noteBox.Text);
            btnNew.PerformClick();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            int index = dgvNote.CurrentCell.RowIndex;
            if (index > -1)
            {
                titleBox.Text = tableList.Rows[index].ItemArray[0].ToString();
                noteBox.Text = tableList.Rows[index].ItemArray[1].ToString();

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = dgvNote.CurrentCell.RowIndex;
            tableList.Rows[index].Delete();

        }

        private void dgvNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
