﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;


namespace WindowsFormsApp1
{
    public partial class Produk : Form
    {
      

        public Produk()
        {
            InitializeComponent();
        }

        private void Produk_Load(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            DataGridView1.Rows.Add(namaBox.Text, jenisBox.Text, jumlahBox.Text, hargaBox.Text);
        }


        private void exportButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Discord bot\dbFaydMedicine.mdf;Integrated Security=True;Connect Timeout=30");

            for (int i = 0; i < DataGridView1.Rows.Count - 1; i++)
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO obatDataTable (NAMA, JENIS, JUMLAH, HARGA)VALUES('" + DataGridView1.Rows[i].Cells[0].Value + "','" + DataGridView1.Rows[i].Cells[1].Value + "','" + DataGridView1.Rows[i].Cells[2].Value + "','" + DataGridView1.Rows[i].Cells[3].Value + "')", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            DataGridView1.Rows.Clear();
        }

        private void simpanFileButton_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(@"D:\Discord bot\faym.txt");
            for (int i = 0; i < DataGridView1.Rows.Count - 1; i++)
            {

                for (int j = 0; j < DataGridView1.Columns.Count; j++)
                {

                    writer.Write("\t" + DataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                }
                writer.WriteLine("");
                writer.WriteLine("-------------------------------------------------------------------");
            }
            writer.Close();
            MessageBox.Show("Data Exported");
        }

        private void hargaBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void jumlahBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void jenisBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void namaBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
