using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework8._1
{
    public partial class Main : Form
    {
        TrueFalseDatabase database;
        public Main()
        {
            InitializeComponent();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalseDatabase(dlg.FileName);
                database.Add("Земля круглая?", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalseDatabase(dlg.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                database.Save();

            }
            catch 
            {
                MessageBox.Show($"Невозможно сохранить! Пожалуйста откройте или создайте файл!", "TrueFalse", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

       
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            tbQuestion.Text = database[(int)nudNumber.Value - 1].Text;
            cbTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                database.Add($"#{database.Count + 1}", true);
                nudNumber.Maximum = database.Count;
                nudNumber.Value = database.Count;
            }
            catch
            {
                MessageBox.Show($"Пожалуйста откройте или создайте файл!", "TrueFalse", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                database.Remove((int)nudNumber.Value - 1);
                nudNumber.Maximum--;
                nudNumber.Value--;
            }
            catch 
            {
                MessageBox.Show($"Пожалуйста откройте или создайте файл!", "TrueFalse", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                database[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
                database[(int)nudNumber.Value - 1].TrueFalse = cbTrue.Checked;
            }
            catch
            {
                MessageBox.Show($"Пожалуйста откройте или создайте файл!", "TrueFalse", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

       

        private void оПрограммеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show($"Ким Алексей, TrueFalse v1.0, все авторские права принадлежат моему коту Мите", "TrueFalse", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Ким Алексей, TrueFalse v1.0, все авторские права принадлежат моему коту Мите", "TrueFalse", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tsButtonInfo1_MouseHover(object sender, EventArgs e)
        {
            textBox1.Visible = true;
        }

        private void tsButtonInfo1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Visible = false;

        }
    }
}
