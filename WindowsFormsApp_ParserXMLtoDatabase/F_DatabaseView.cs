using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_ParserXMLtoDatabase
{
    public partial class F_DatabaseView : Form
    {
        public F_DatabaseView()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("server=liza.umcs.lublin.pl;user=krudzki;database=krudzki;password=kwiecien0404;SslMode=none");
        String id;

        public void FillGrid()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM information", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.RowTemplate.Height = 60;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.DataSource = table;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            try
            {
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void F_DatabaseView_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO information (ID, name, conservative, venus, know, save, innerTextInformation) VALUES (@ID, @name, @conservative, @venus, @know, @save, @innerTextInformation)", connection);

            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = textBoxID.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = "information";
            command.Parameters.Add("@conservative", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@venus", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@know", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@save", MySqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@innerTextInformation", MySqlDbType.VarChar).Value = textBox6.Text;

            ExecMyQuery(command, "Data Inserted");
        }

        private void ExecMyQuery(MySqlCommand command, string myMsg)
        {
            connection.Open();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show(myMsg);
            }
            else
            {
                MessageBox.Show("Query Not Executed");
            }
            connection.Close();
            FillGrid();
        }

        private void buttonUPDATE_Click(object sender, EventArgs e)
        {

            MySqlCommand command = new MySqlCommand("UPDATE information SET ID=@ID,name=@name,conservative=@conservative,venus=@venus,know=@know,save=@save,innerTextInformation=@innerTextInformation WHERE ID = @ID", connection);

            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = textBoxID.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = "information";
            command.Parameters.Add("@conservative", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@venus", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@know", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@save", MySqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@innerTextInformation", MySqlDbType.VarChar).Value = textBox6.Text;

            ExecMyQuery(command, "Data Updated");
        }

        private void buttonDELETE_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM information WHERE ID =@ID", connection);

            command.Parameters.Add("@ID", MySqlDbType.VarChar).Value = id;

            ExecMyQuery(command, "Data Deleted");
        }
    }
}
