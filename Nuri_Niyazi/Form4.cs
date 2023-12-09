using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nuri_Niyazi
{
    public partial class Form4 : Form
    {
        public Form6 frm6;
        public Form5 frm5;
        public Form3 frm3;
        public Form4()
        {
            InitializeComponent();
            
            frm5 = new Form5();
            frm6 = new Form6();
          
            frm5.frm4 = this;
            frm6.frm4 = this;
            
            
        }



        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=data.mdb");   
        public OleDbCommand kmt = new OleDbCommand();   
        public OleDbDataAdapter adtr = new OleDbDataAdapter();   
        public DataSet dtst = new DataSet();
        
        public int row = 0;
           
        

        public void view()
        {
            /*bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From Books", bag);
            adtr.Fill(dtst, "Books");
            dataGridView1.DataSource = dtst.Tables["Books"];
            adtr.Dispose();
            bag.Close();*/

            bag.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From rental", bag);
            adtr.Fill(dtst, "rental");
            dataGridView1.DataSource = dtst.Tables["rental"];
            adtr.Dispose();
            bag.Close();
        }

        public void combo()   
        {   
            /*int status;   
            bag.Open();   
            kmt.Connection = bag;
            kmt.CommandText = "Select Title from Books";   
            OleDbDataReader oku;   
            oku = kmt.ExecuteReader();    
            bag.Close();   
            oku.Dispose();*/

            int status;
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select type from rental";
            OleDbDataReader oku;
            oku = kmt.ExecuteReader();
            bag.Close();
            oku.Dispose();
        }   

        private void Form4_Load(object sender, EventArgs e)
        {
            /*view();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Име на книга";
            dataGridView1.Columns[2].HeaderText = "Автор";
            dataGridView1.Columns[3].HeaderText = "Категория";
            dataGridView1.Columns[4].HeaderText = "ISBN";
            dataGridView1.Columns[5].HeaderText = "Брой страници";
            dataGridView1.Columns[6].HeaderText = "Номер на рафта";
            dataGridView1.Columns[7].HeaderText = "Дата на издаване";
            dataGridView1.Columns[8].HeaderText = "Цена";
            dataGridView1.Columns[9].HeaderText = "Наличност";*/

            view();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "accommodation type";
            dataGridView1.Columns[2].HeaderText = "location";
            dataGridView1.Columns[3].HeaderText = "date available from";
            dataGridView1.Columns[4].HeaderText = "date available until";
            dataGridView1.Columns[5].HeaderText = "cost per day";
            /*dataGridView1.Columns[6].HeaderText = "Номер на рафта";
            dataGridView1.Columns[7].HeaderText = "Дата на издаване";
            dataGridView1.Columns[8].HeaderText = "Цена";
            dataGridView1.Columns[9].HeaderText = "Наличност";*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm5.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*dtst.Tables["Books"].Clear();
            this.Close();*/

            dtst.Tables["rental"].Clear();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string book_id;
            try
            {
                int row = 0;
                for (row = 0; row <= dataGridView1.Rows.Count; row++)
                {
                    
                    if (dataGridView1.Rows[row].Cells[0].Selected == true || dataGridView1.Rows[row].Cells[1].Selected == true || dataGridView1.Rows[row].Cells[2].Selected == true || dataGridView1.Rows[row].Cells[3].Selected == true || dataGridView1.Rows[row].Cells[4].Selected == true || dataGridView1.Rows[row].Cells[5].Selected == true || dataGridView1.Rows[row].Cells[6].Selected == true || dataGridView1.Rows[row].Cells[7].Selected == true || dataGridView1.Rows[row].Cells[8].Selected == true)
                    {
                        break;

                    }
                }
                book_id = dataGridView1.Rows[row].Cells[0].Value.ToString();

                DialogResult answer;
                answer = MessageBox.Show("Are you sure you want to delete this book?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    /*bag.Open();
                    kmt.Connection = bag;
                    kmt.CommandText = "DELETE from Books WHERE BookID=" + book_id + "";
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();
                    bag.Close();
                    dtst.Tables["Books"].Clear();
                    view();*/

                    bag.Open();
                    kmt.Connection = bag;
                    kmt.CommandText = "DELETE from rental WHERE ID=" + book_id + "";
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();
                    bag.Close();
                    dtst.Tables["rental"].Clear();
                    view();
                }
            }
            catch
            { ;}
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            frm6.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /*OleDbDataAdapter adtr = new OleDbDataAdapter("select * From Books", bag);
            if (textBox1.Text == "")
            {
                kmt.Connection = bag;
                kmt.CommandText = "Select * from Books";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "Books");
            }
            if (Convert.ToBoolean(bag.State) == false)
            {
                bag.Open();
            }
            adtr.SelectCommand.CommandText = " Select * From Books" +
                 " where(Title like '%" + textBox1.Text + "%' )";
            dtst.Tables["Books"].Clear();
            adtr.Fill(dtst, "Books");
            bag.Close();*/

            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From rental", bag);
            if (textBox1.Text == "")
            {
                kmt.Connection = bag;
                kmt.CommandText = "Select * from rental";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "rental");
            }
            if (Convert.ToBoolean(bag.State) == false)
            {
                bag.Open();
            }
            adtr.SelectCommand.CommandText = " Select * From rental" +
                 " where(type like '%" + textBox1.Text + "%' )";
            dtst.Tables["rental"].Clear();
            adtr.Fill(dtst, "rental");
            bag.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            /*OleDbDataAdapter adtr = new OleDbDataAdapter("select * From Books", bag);
            if (textBox2.Text == "")
            {
                kmt.Connection = bag;
                kmt.CommandText = "Select * from Books";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "Books");
            }
            if (Convert.ToBoolean(bag.State) == false)
            {
                bag.Open();
            }
            adtr.SelectCommand.CommandText = " Select * From Books" +
                 " where(Author like '%" + textBox2.Text + "%' )";
            dtst.Tables["Books"].Clear();
            adtr.Fill(dtst, "Books");
            bag.Close();*/

            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From rental", bag);
            if (textBox2.Text == "")
            {
                kmt.Connection = bag;
                kmt.CommandText = "Select * from rental";
                adtr.SelectCommand = kmt;
                adtr.Fill(dtst, "rental");
            }
            if (Convert.ToBoolean(bag.State) == false)
            {
                bag.Open();
            }
            adtr.SelectCommand.CommandText = " Select * From rental" +
                 " where(location like '%" + textBox2.Text + "%' )";
            dtst.Tables["rental"].Clear();
            adtr.Fill(dtst, "rental");
            bag.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frm6.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm6.textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm6.textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            /*frm6.textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm6.textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            frm6.textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            frm6.dateTimePicker7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            frm6.textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            frm6.checkBox9.Checked = (bool)dataGridView1.CurrentRow.Cells[9].Value;*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
