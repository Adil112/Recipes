using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Recipes;

namespace Recipes
{
    public partial class Form1 : Form
    {
        RecMas rec;
        int row;
        int numpic;
        int count = 0;
        string[] url;
        public Form1()
        {
            InitializeComponent();
            var js = new ReadJson();
            rec = js.Read();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int num = rec.recipes.Length;
            string[] names = new string[num];
            for (int i = 0; i < num; i++)
            {
                names[i] = rec.recipes[i].Name;
            }
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Название";
            column1.Width = 190;
            column1.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column1);

            for (int i = 0; i < num; i++)
            {
                dataGridView1.Rows.Add(names[i]);
            }


            int a = 0;
        }
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = rec.recipes[row].Description;
            textBox2.Text = rec.recipes[row].Instructions;
            label4.Text = rec.recipes[row].Difficulty.ToString();
            textBox3.Text = rec.recipes[row].Name;
            numpic = rec.recipes[row].Images.Length;
            url = rec.recipes[row].Images;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.ImageLocation = url[0];

        }
        private void pictureBox1_Click(object sender, EventArgs e) // для просмотра всех картинок, покликайте на картинку
        {
            if (count >= numpic) count = 0;
            pictureBox1.ImageLocation = url[count];
            count++;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

    }
}
