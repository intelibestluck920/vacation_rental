using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;


namespace Nuri_Niyazi
{
    public partial class Form3 : Form
    {

        public string Pcommand;
        public bool isOpen;

        public Form4 frm4;
        public Form5 frm5;
        public Form6 frm6;        

        string[] misal = { "Понякога всичко, което трябва да направиш, за да успокоиш някого, е да му напомниш, че си до него. Туве Янсон",
                            "Ако не можем да променим ситуацията, да променим себе си. Виктор Франкъл", 
                            "Чашата се пълни с много капки, но прелива само с една М. Авелок", 
                            "Любовта е чувството за непълнота при отсъствие. Гонкур", 
                            "Животът ни връща само това, което даваме на другите. И. Андрич", 
                            "Не се страхувайте от моментите, когато нищо не се случва, защото в тишина се раждат най-ценните неща. Ирина Хакамада", 
                            "За всяко зло има два лека - времето и мълчанието. Граф Монте Кристо", 
                            "Мечта, която мечтаеш сам, е само мечта. Мечта, която мечтаете заедно, е реалност. Дж. Ленън" };


        
        Random random = new Random();
        int a;


        public Form3()
        {
            InitializeComponent();
            frm4 = new Form4();
            frm5 = new Form5();
            frm6 = new Form6();
            


            frm4.frm3 = this;
            frm5.frm3 = this;
            frm6.frm3 = this;           
            
        }
  

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Do you want to exit the program?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label2.Text =DateTime.Now.ToLongTimeString();
            label1.Text = string.Format("{0:dd MMMM yyyy dddd}",DateTime.Now);


            /*a = random.Next(6);
            label4.Text = misal [a];*/
           
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            frm4.ShowDialog();
        }              

    }
}
