using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PT2
{
    public partial class Form1 : Form
    {
        String name, sec, elective, rollno, date, scr, cmnt,myconnection,query;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            sec = comboBox1.Text;
            elective = comboBox2.Text;
            rollno = textBox2.Text;
            date = comboBox3.Text + " " + comboBox4.Text + " " + comboBox5.Text;

            if (radioButton1.Checked)
                scr = radioButton1.Text;
            else if (radioButton2.Checked)
                scr = radioButton2.Text;
            else
                scr = radioButton2.Text;

            cmnt = richTextBox1.Text;


            try
            {
                myconnection = "SERVER=127.0.0.1;DATABASE=dotnet;UID=root;PASSWORD=aaditya";
                query = "insert into pt2(name,sec,elective,rollno,date,scr,cmnt) values ('" + name + "','" + sec + "','" + elective + "','" + rollno + "','" + date + "','" + scr + "','" + cmnt + "')";
                MySqlConnection connection = new MySqlConnection(myconnection);
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader myReader;
                connection.Open();
                myReader = command.ExecuteReader();
                MessageBox.Show("Thankyou for Registration. Your choice is " + elective);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}