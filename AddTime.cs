using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SPA
{
  public partial class AddTime : Form
  {
    OleDbConnection myOleDbConnection;
    OleDbDataAdapter myDataAdapter;
    string connectionString;
    DataSet myDataSet;
    int p = 0;


    public AddTime()
    {
      InitializeComponent();
      string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;" + "data source=spa.mdb";//connectionString = "provider=Microsoft.Jet.OLEDB.4.0;" + "data source=C:\\Users\\Сева\\Desktop\\курсовая\\курсовая\\Мед_центр.mdb";
      myOleDbConnection = new OleDbConnection(connectionString);

      myDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM Персонал", myOleDbConnection);
      myDataSet = new DataSet("Персонал");
      myDataAdapter.Fill(myDataSet, "Персонал");

      myDataAdapter.SelectCommand = new OleDbCommand("SELECT Процедура, [_Дата], Специалист, С, По, Дата FROM Время", myOleDbConnection);
      myDataAdapter.SelectCommand.Connection.Open();
      myDataAdapter.SelectCommand.ExecuteNonQuery();
      myDataAdapter.Fill(myDataSet, "Время");
      myDataAdapter.Fill(myDataSet, "Время2");
      /* myDataAdapter.SelectCommand = new OleDbCommand("SELECT Время.Процедура, Время.[_Дата], Время.Специалист, Время.С, Время.ПоFROM Время;", myOleDbConnection);
       myDataAdapter.SelectCommand.Connection.Open();
       myDataAdapter.SelectCommand.ExecuteNonQuery();
       myDataAdapter.Fill(myDataSet, "Время");*/

      myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Клиенты", myOleDbConnection);

      myDataAdapter.SelectCommand.ExecuteNonQuery();
      myDataAdapter.Fill(myDataSet, "Клиенты");


      myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Процедуры", myOleDbConnection);
      myDataAdapter.SelectCommand.ExecuteNonQuery();
      myDataAdapter.Fill(myDataSet, "Процедуры");

      myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM spa_процедуры", myOleDbConnection);
      myDataAdapter.SelectCommand.ExecuteNonQuery();
      myDataAdapter.Fill(myDataSet, "spa_процедуры");


      this.dataGridView2.DataSource = myDataSet.Tables[3].DefaultView;
      this.dataGridView1.DataSource = myDataSet.Tables[1].DefaultView;

      this.dataGridView2.Columns["Телефон"].Visible = false;
      this.dataGridView2.Columns["Город"].Visible = false;
      this.dataGridView2.Columns["Улица"].Visible = false;
      this.dataGridView2.Columns["Квартира"].Visible = false;


      comboBox1.DataSource = myDataSet.Tables["Процедуры"].DefaultView;
      comboBox1.DisplayMember = "Название";

      comboBox2.DataSource = myDataSet.Tables["Персонал"].DefaultView;
      comboBox2.DisplayMember = "Фамилия";

      comboBox3.DataSource = myDataSet.Tables["Клиенты"].DefaultView;
      comboBox3.DisplayMember = "Полис";

      comboBox4.DataSource = myDataSet.Tables["spa_процедуры"].DefaultView;
      comboBox4.DisplayMember = "Название";

    }

    private void AddCl_Load(object sender, EventArgs e)
    {
      ToolTip t = new ToolTip();
      t.SetToolTip(this.button8, "Обновить таблицы");
      t.SetToolTip(this.button3, "Найти свободное время");   
      t.SetToolTip(this.button2, "Записать клиента");
      t.SetToolTip(this.button1, "Назад");

        comboBox1.Visible=false;
        comboBox4.Visible = false;

        label3.Visible = false;
        label5.Visible = false;
    }

    private void button3_Click(object sender, EventArgs e)
    {
        if (p == 1)
        {
            myDataAdapter.SelectCommand.Connection.Close();
            try
            {
                string cmd = "";
                if (comboBox2.SelectedIndex == -1 && comboBox2.Text == string.Empty)
                    cmd = "SELECT * FROM Время WHERE ((Процедура= '" + comboBox1.Text + "') AND ([_Дата]='" + dateTimePicker1.Value.ToShortDateString() + "') AND (flag=False))";
                //SELECT * FROM Время WHERE ((Процедура= 'Стрижка') AND ([_Дата]='01.09.2013') AND (flag=False))
                else
                    cmd = "SELECT * FROM Время WHERE ((Процедура='" + comboBox1.Text + "') AND ([_Дата]='" + dateTimePicker1.Value.ToShortDateString() + "') AND (Специалист='" + comboBox2.Text + "') AND (flag=False))";
                //SELECT * FROM Время WHERE ((Процедура= 'Стрижка') AND ([_Дата]='01.09.2013') AND (Специалист = 'Иванов') AND (flag=False))

                myDataAdapter.SelectCommand = new OleDbCommand(cmd, myOleDbConnection);
                myDataAdapter.SelectCommand.Connection.Open();
                myDataAdapter.SelectCommand.ExecuteNonQuery();
                myDataAdapter.SelectCommand.Connection.Close();

                myDataSet.Tables["Время"].Clear();
                myDataSet.Tables["Время2"].Clear();
                myDataAdapter.Fill(myDataSet, "Время");
                myDataAdapter.Fill(myDataSet, "Время2");

                this.dataGridView1.DataSource = myDataSet.Tables["Время2"].DefaultView;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        else  if (p == 2)
        {
            myDataAdapter.SelectCommand.Connection.Close();
            try
            {
                string cmd = "";
                if (comboBox2.SelectedIndex == -1 && comboBox2.Text == string.Empty)
                    cmd = "SELECT * FROM Время WHERE ((Процедура= '" + comboBox4.Text + "') AND ([_Дата]='" + dateTimePicker1.Value.ToShortDateString() + "') AND (flag=False))";
                //SELECT * FROM Время WHERE ((Процедура= 'Стрижка') AND ([_Дата]='01.09.2013') AND (flag=False))
                else
                    cmd = "SELECT * FROM Время WHERE ((Процедура='" + comboBox1.Text + "') AND ([_Дата]='" + dateTimePicker1.Value.ToShortDateString() + "') AND (Специалист='" + comboBox2.Text + "') AND (flag=False))";
                //SELECT * FROM Время WHERE ((Процедура= 'Стрижка') AND ([_Дата]='01.09.2013') AND (Специалист = 'Иванов') AND (flag=False))

                myDataAdapter.SelectCommand = new OleDbCommand(cmd, myOleDbConnection);
                myDataAdapter.SelectCommand.Connection.Open();
                myDataAdapter.SelectCommand.ExecuteNonQuery();
                myDataAdapter.SelectCommand.Connection.Close();

                myDataSet.Tables["Время"].Clear();
                myDataSet.Tables["Время2"].Clear();
                myDataAdapter.Fill(myDataSet, "Время");
                myDataAdapter.Fill(myDataSet, "Время2");

                this.dataGridView1.DataSource = myDataSet.Tables["Время2"].DefaultView;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

    }

    private void button2_Click(object sender, EventArgs e)
    {
        try
        {

            if (dataGridView1.SelectedRows.Count != 1)
                MessageBox.Show("Выберите свободное время в таблице!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {

                string cmd = "INSERT INTO Расписание (Клиент, Процедура, Специалист,С,По,Дата)  VALUES ('" + dataGridView2.SelectedRows[0].Cells[1].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[3].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[4].Value.ToString() + "','" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "')";
                myDataAdapter.InsertCommand = new OleDbCommand(cmd, myOleDbConnection);
                myDataAdapter.InsertCommand.Connection.Close();
                myDataAdapter.InsertCommand.Connection.Open();
                myDataAdapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show(myDataAdapter.InsertCommand.CommandText);
                myDataAdapter.InsertCommand.Connection.Close();

                cmd = "UPDATE Время SET flag = True WHERE (Дата='" + dataGridView1.SelectedRows[0].Cells[5].Value.ToString() + "')";
                myDataAdapter.UpdateCommand = new OleDbCommand(cmd, myOleDbConnection);
                myDataAdapter.UpdateCommand.Connection.Open();
                myDataAdapter.UpdateCommand.ExecuteNonQuery();
                MessageBox.Show(myDataAdapter.UpdateCommand.CommandText);
                myDataAdapter.UpdateCommand.Connection.Close();


            }
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);

        }

    }


    private void button1_Click_1(object sender, EventArgs e)
    {

    }

    private void button8_Click(object sender, EventArgs e)
    {
        string connectionString = "provider=Microsoft.Jet.OLEDB.4.0;" + "data source=spa.mdb";//connectionString = "provider=Microsoft.Jet.OLEDB.4.0;" + "data source=C:\\Users\\Сева\\Desktop\\курсовая\\курсовая\\Мед_центр.mdb";
        myOleDbConnection = new OleDbConnection(connectionString);

        myDataAdapter = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM Персонал", myOleDbConnection);
        myDataSet = new DataSet("Персонал");
        myDataAdapter.Fill(myDataSet, "Персонал");

        myDataAdapter.SelectCommand = new OleDbCommand("SELECT Процедура, [_Дата], Специалист, С, По, Дата FROM Время", myOleDbConnection);
        myDataAdapter.SelectCommand.Connection.Open();
        myDataAdapter.SelectCommand.ExecuteNonQuery();
        myDataAdapter.Fill(myDataSet, "Время");
        myDataAdapter.Fill(myDataSet, "Время2");
        /* myDataAdapter.SelectCommand = new OleDbCommand("SELECT Время.Процедура, Время.[_Дата], Время.Специалист, Время.С, Время.ПоFROM Время;", myOleDbConnection);
         myDataAdapter.SelectCommand.Connection.Open();
         myDataAdapter.SelectCommand.ExecuteNonQuery();
         myDataAdapter.Fill(myDataSet, "Время");*/

        myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Клиенты", myOleDbConnection);

        myDataAdapter.SelectCommand.ExecuteNonQuery();
        myDataAdapter.Fill(myDataSet, "Клиенты");


        myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM Процедуры", myOleDbConnection);
        myDataAdapter.SelectCommand.ExecuteNonQuery();
        myDataAdapter.Fill(myDataSet, "Процедуры");

        myDataAdapter.SelectCommand = new OleDbCommand("SELECT * FROM spa_процедуры", myOleDbConnection);
        myDataAdapter.SelectCommand.ExecuteNonQuery();
        myDataAdapter.Fill(myDataSet, "spa_процедуры");


        this.dataGridView2.DataSource = myDataSet.Tables[3].DefaultView;
        this.dataGridView1.DataSource = myDataSet.Tables[1].DefaultView;

        this.dataGridView2.Columns["Телефон"].Visible = false;
        this.dataGridView2.Columns["Город"].Visible = false;
        this.dataGridView2.Columns["Улица"].Visible = false;
        this.dataGridView2.Columns["Квартира"].Visible = false;


        comboBox1.DataSource = myDataSet.Tables["Процедуры"].DefaultView;
        comboBox1.DisplayMember = "Название";

        comboBox2.DataSource = myDataSet.Tables["Персонал"].DefaultView;
        comboBox2.DisplayMember = "Фамилия";

        comboBox3.DataSource = myDataSet.Tables["Клиенты"].DefaultView;
        comboBox3.DisplayMember = "Полис";

        comboBox4.DataSource = myDataSet.Tables["spa_процедуры"].DefaultView;
        comboBox4.DisplayMember = "Название";
    }

    private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox8.SelectedIndex != -1)
        {

            comboBox8.Visible = false;
            label14.Visible = false;

            if (comboBox8.Text == "Процедуры")
            {
                label3.Visible = true;
                comboBox1.Visible = true;
                label5.Visible = false;
                comboBox4.Visible = false;
                p = 1;
            }
            else
            {
                label3.Visible = false;
                comboBox1.Visible = false;
                label5.Visible = true;
                comboBox4.Visible = true;
                p = 2;
            }
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        label3.Visible = false;
        comboBox1.Visible = false;
        label5.Visible = false;
        comboBox4.Visible = false;
        comboBox8.Visible = true;
        label14.Visible = true;


        comboBox8.SelectedIndex = -1;
        p = 0;
    }

    private void label14_Click(object sender, EventArgs e)
    {

    }
  }
}
