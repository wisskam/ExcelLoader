using ExcelLoader.Class;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ExcelLoader
{
    public partial class Form1 : Form
    {
        public Form1(string[] args)
        {
            InitializeComponent();

            this.Text += " - ";

            if (args[0] == "")
                this.Text += "No path loaded";

            else
            {
                string path = args[0];
                this.Text += $"\n {path}";
            }

        }

        private void databasesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormDatabases formDatabases = new FormDatabases();
        
            formDatabases.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (FileLoader.FilePath == "")
            {
                this.previewGroupBox.Enabled = false;
            }

            else
            {
                if(FileLoader.CurrentFileGroup == "excel")
                    PrepareTableList();

                this.fileDataGridView.DataSource = FileLoader.FileDataTable;
                this.databaseComboBox.Items.AddRange(
                    ConnectionList.Connections.Select(connection => connection.Server + " " + connection.Name).ToArray()
                );
            }
        }

        private void tableComboBox_TextChanged(object sender, EventArgs e)
        {
            this.tableComboBox.SelectedIndex = FileLoader.CurrentTableIndex;
        }

        private void PrepareTableList()
        {
            this.tableComboBox.Enabled = true;

            for (int i = 0; i < FileLoader.FileDataTableSchema.Rows.Count; i++)
            {
                this.tableComboBox.Items.Add(FileLoader.FileDataTableSchema.Rows[i]["TABLE_NAME"].ToString());
            }

            this.tableComboBox.SelectedIndex = FileLoader.CurrentTableIndex;
        }

        private string PrepareCreateQuery(string tableName, string[] columns)
        {
            string query = $"CREATE TABLE {tableName} (";

            for (int i = 0; i < columns.Length; i++)
            {
                query += $"{columns[i]} varchar(max)";

                if (i < columns.Length - 1)
                    query += ", ";
                else
                    query += ")";

            }

            return query;
        }

        private string PrepareInsertQuery(string tableName, DataRowCollection rows)
        {
            string query = $"INSERT INTO {tableName} VALUES";
            string value = "";
            Regex rgx = new Regex("(['^$.|?*+()\\\\])");

            for (int i = 0; i < rows.Count; i++)
            {
                query += "(";

                for (int j = 0; j < rows[i].ItemArray.Length; j++)
                {
                    query += $"\'{rows[i].ItemArray[j].ToString().Replace("'", "\'\'")}\'";

                    if (j < rows[i].ItemArray.Length - 1)
                        query += ", ";
                }

                query += ")";
                if (i < rows.Count - 1)
                    query += ", ";
            }


            return query;
        }

        private void databaseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadButton.Enabled = true;
            ConnectionList.Selected = this.databaseComboBox.SelectedIndex;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            bool tableCreated = false;
            string tableName = FileLoader.GetFileName().Replace(" ", "_");
            int pageQuantity = 100;



            try
            {
                string createQuery = PrepareCreateQuery(tableName, FileLoader.FileDataTable.Columns
                                                                    .Cast<DataColumn>()
                                                                    .Select(column => column.ColumnName)
                                                                    .ToArray()
                );

                ConnectionList.Current().RunQuery(createQuery);
                tableCreated = true;
                for(int i = 0; i < FileLoader.FileDataTable.Rows.Count / pageQuantity; i++)
                {
                    DataTable dataTablePage = FileLoader.FileDataTable.Rows.Cast<System.Data.DataRow>().Skip(i * pageQuantity).Take(pageQuantity).CopyToDataTable();

                    string insertQuery = PrepareInsertQuery(tableName, dataTablePage.Rows);

                    ConnectionList.Current().RunQuery(insertQuery);
                }
                
                MessageBox.Show($"Table {FileLoader.GetFileName()} succesfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                if(tableCreated)
                    ConnectionList.Current().RunQuery($"DROP TABLE {tableName}");

                MessageBox.Show(ex.Message, ex.GetType().FullName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
