using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using System.Data.Common;
using System.Collections;

namespace SPA
{
    public partial class AddLenTime : Form
    {
        Form1 f1;
        OleDbConnection myOleDbConnection;
        OleDbDataAdapter myDataAdapter;
        DataSet myDataSet;
        public OleDbConnection obj_connect = null;
        int p = 0;

        public AddLenTime()
        {
            InitializeComponent();
           
            string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;" + "data source=spa.mdb";
            myOleDbConnection = new OleDbConnection(connectionString);

            myOleDbConnection = new OleDbConnection(connectionString);
            myDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM Персонал", myOleDbConnection);
            myDataSet = new DataSet("Персонал");

            myDataAdapter.Fill(myDataSet, "Персонал");

            myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Клиенты", myOleDbConnection);
            myDataAdapter.SelectCommand.Connection.Open();
            myDataAdapter.SelectCommand.ExecuteNonQuery();
            myDataAdapter.Fill(myDataSet, "Клиенты");

            myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Время", myOleDbConnection);
            myDataAdapter.SelectCommand.ExecuteNonQuery();
            myDataAdapter.Fill(myDataSet, "Время");


            myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Процедуры", myOleDbConnection);
            myDataAdapter.SelectCommand.ExecuteNonQuery();
            myDataAdapter.Fill(myDataSet, "Процедуры");

            myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Специальности", myOleDbConnection);
            myDataAdapter.SelectCommand.ExecuteNonQuery();
            myDataAdapter.Fill(myDataSet, "Специальности");

            myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Расписание", myOleDbConnection);
            myDataAdapter.SelectCommand.ExecuteNonQuery();
            myDataAdapter.Fill(myDataSet, "Расписание");

            myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM spa_процедуры", myOleDbConnection);
            myDataAdapter.SelectCommand.ExecuteNonQuery();
            myDataAdapter.Fill(myDataSet, "spa_процедуры");


            myDataAdapter.SelectCommand.Connection.Close();

            this.dataGridView1.DataSource = myDataSet.Tables["Время"].DefaultView;
            this.dataGridView1.Columns["ID"].Visible = false;
            this.dataGridView1.Columns["Дата"].Visible = false;
            this.dataGridView1.Columns["flag"].Visible = false;

            comboBox1.DataSource = myDataSet.Tables["Процедуры"].DefaultView;
            comboBox1.DisplayMember = "Название";

            comboBox6.DataSource = myDataSet.Tables["Персонал"].DefaultView;
            comboBox6.DisplayMember = "Фамилия";

            comboBox7.DataSource = myDataSet.Tables["spa_процедуры"].DefaultView;
            comboBox7.DisplayMember = "Название";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //
            //int a = 10, b = 10, c = 1990;
            //dateTimePicker1.Value = new DateTime(c, b, a);

            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            //listBox1.Items.Add(dateTimePicker1.Value.ToShortDateString());
            //listBox1.Items.Add(dateTimePicker1.Value.Month.ToString());
            // MessageBox.Show(dateTimePicker1.Value.Date.ToString());


        }

        private void AddLenTime_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(this.button3, "Выйти");
            t.SetToolTip(this.button2, "Удалить");
            t.SetToolTip(this.button1, "Добавить");
            t.SetToolTip(this.button4, "Назад");

            label1.Visible = false;
            label8.Visible = false;
            comboBox1.Visible = false;

            comboBox7.Text = null;
            comboBox1.Text = null;
            comboBox7.Text = null;
            comboBox6.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (p == 1)
            {
                String s = dateTimePicker1.Value.ToShortDateString() + " " + comboBox2.SelectedItem.ToString() + ":" + comboBox3.SelectedItem.ToString() + " - " + comboBox4.SelectedItem.ToString() + ":" + comboBox5.SelectedItem.ToString() + "( " + comboBox1.Text + ")";
                string cmd = "INSERT INTO Время (Дата,Специалист,Процедура,С,По,_Дата)  VALUES ('" + s + "','" + comboBox6.Text + "','" + comboBox1.Text + "','" + comboBox2.SelectedItem.ToString() + ":" + comboBox3.SelectedItem.ToString() + "','" + comboBox4.SelectedItem.ToString() + ":" + comboBox5.SelectedItem.ToString() + "','" + dateTimePicker1.Value.ToShortDateString() + Properties.Resources1.ResourceEntry;

                try
                {

                    if (comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || comboBox4.SelectedIndex == -1 || comboBox5.SelectedIndex == -1)
                        MessageBox.Show("Не все поля времени заполнены!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    if (Convert.ToInt32(comboBox4.SelectedItem.ToString()) > Convert.ToInt32(comboBox2.SelectedItem.ToString()) || ((Convert.ToInt32(comboBox4.SelectedItem.ToString()) == Convert.ToInt32(comboBox2.SelectedItem.ToString()) && Convert.ToInt32(comboBox5.SelectedItem.ToString()) > Convert.ToInt32(comboBox3.SelectedItem.ToString()))))
                    {

                        myDataAdapter.InsertCommand = new OleDbCommand(cmd, myOleDbConnection);

                        myDataAdapter.InsertCommand.Connection.Open();
                        myDataAdapter.InsertCommand.ExecuteNonQuery();
                        myDataAdapter.InsertCommand.Connection.Close();

                        myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Время", myOleDbConnection);
                        myDataAdapter.SelectCommand.Connection.Open();
                        myDataAdapter.SelectCommand.ExecuteNonQuery();
                        myDataAdapter.SelectCommand.Connection.Close();

                        myDataSet.Tables["Время"].Clear();
                        myDataAdapter.Fill(myDataSet, "Время");

                    }
                    else
                    {
                        MessageBox.Show("Введите корректное время!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    obj_connect = null;

                }
            }
            
           else if(p==2)
            {

                String s = dateTimePicker1.Value.ToShortDateString() + " " + comboBox2.SelectedItem.ToString() + ":" + comboBox3.SelectedItem.ToString() + " - " + comboBox4.SelectedItem.ToString() + ":" + comboBox5.SelectedItem.ToString() + "( " + comboBox7.Text + ")";
                string cmd = "INSERT INTO Время (Дата,Специалист,Процедура,С,По,_Дата)  VALUES ('" + s + "','" + comboBox6.Text + "','" + comboBox7.Text + "','" + comboBox2.SelectedItem.ToString() + ":" + comboBox3.SelectedItem.ToString() + "','" + comboBox4.SelectedItem.ToString() + ":" + comboBox5.SelectedItem.ToString() + "','" + dateTimePicker1.Value.ToShortDateString() + Properties.Resources1.ResourceEntry;


                try
                {

                    if (comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || comboBox4.SelectedIndex == -1 || comboBox5.SelectedIndex == -1)
                        MessageBox.Show("Не все поля времени заполнены!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    if (Convert.ToInt32(comboBox4.SelectedItem.ToString()) > Convert.ToInt32(comboBox2.SelectedItem.ToString()) || ((Convert.ToInt32(comboBox4.SelectedItem.ToString()) == Convert.ToInt32(comboBox2.SelectedItem.ToString()) && Convert.ToInt32(comboBox5.SelectedItem.ToString()) > Convert.ToInt32(comboBox3.SelectedItem.ToString()))))
                    {

                        myDataAdapter.InsertCommand = new OleDbCommand(cmd, myOleDbConnection);

                        myDataAdapter.InsertCommand.Connection.Open();
                        myDataAdapter.InsertCommand.ExecuteNonQuery();
                        myDataAdapter.InsertCommand.Connection.Close();

                        myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Время", myOleDbConnection);
                        myDataAdapter.SelectCommand.Connection.Open();
                        myDataAdapter.SelectCommand.ExecuteNonQuery();
                        myDataAdapter.SelectCommand.Connection.Close();

                        myDataSet.Tables["Время"].Clear();
                        myDataAdapter.Fill(myDataSet, "Время");

                    }
                    else
                    {
                        MessageBox.Show("Введите корректное время!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    obj_connect = null;

                }
            }
             }

      


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddLenTime_Activated(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            myDataAdapter.DeleteCommand = new OleDbCommand("DELETE FROM Время WHERE ID= " + dataGridView1.SelectedRows[0].Cells[0].Value, myOleDbConnection);
            try
            {
                myDataAdapter.DeleteCommand.Connection.Open();
                myDataAdapter.DeleteCommand.ExecuteNonQuery();
                myDataAdapter.DeleteCommand.Connection.Close();

                myDataAdapter.SelectCommand = new OleDbCommand("Select * FROM Время", myOleDbConnection);
                myDataAdapter.SelectCommand.Connection.Open();
                myDataAdapter.SelectCommand.ExecuteNonQuery();
                myDataAdapter.SelectCommand.Connection.Close();

                myDataSet.Tables["Время"].Clear();
                myDataAdapter.Fill(myDataSet, "Время");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                obj_connect = null;
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex != -1)
            {

                comboBox8.Visible = false;
                label14.Visible = false;

                if (comboBox8.Text == "Процедуры")
                {
                    label1.Visible = true;
                    comboBox1.Visible = true;
                    label8.Visible = false;
                    comboBox7.Visible = false;
                    p=1;
                }
                else
                {
                    label1.Visible = false;
                    comboBox1.Visible = false;
                    label8.Visible = true;
                    comboBox7.Visible = true;
                    p = 2;
                }
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            comboBox1.Visible = false;
            label8.Visible = false;
            comboBox7.Visible = false;
            comboBox8.Visible = true;
            label14.Visible = true;

           
            comboBox8.SelectedIndex = -1;
            comboBox7.Text = null;
            comboBox6.Text = null;

            p = 0;
        }
    }
}
