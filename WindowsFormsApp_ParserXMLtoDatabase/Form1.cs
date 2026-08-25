using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp_ParserXMLtoDatabase.Model_XML;

namespace WindowsFormsApp_ParserXMLtoDatabase
{
    public partial class Form1 : Form
    {
        CL_Parser parser = new CL_Parser();
        Root root = new Root();

        F_DatabaseView F_DatabaseView = new F_DatabaseView();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonLoadXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                String xmlFilePath = openFileDialog.FileName;
                root = parser.Parser(xmlFilePath);
                MessageBox.Show("Successfully finished loading the XML into the MySQL database!");
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void buttonViewDatabase_Click(object sender, EventArgs e)
        {
            F_DatabaseView.ShowDialog();
        }
    }
}
