using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ExcelLoader
{
    public partial class FormDatabases : Form
    {
        private int _newCounter = 0;

        public FormDatabases()
        {

            InitializeComponent();

        }

        private void databasesNewButton_Click(object sender, EventArgs e)
        {
            Connection con = new Connection("New database " + _newCounter);

            ConnectionList.Add(con);
            
            this.databasesListView.Items.Add(con.Server);
            this.databasesListView.Items[ConnectionList.Selected].Selected = true;
            this.databasesListView.Items[ConnectionList.Selected].Focused = true;

            this.databaseTestButton.Enabled = false;

            ++_newCounter;
        }

        private void databaseSaveButton_Click(object sender, EventArgs e)
        {
            //Validation
            bool[] validation = {
                this.databaseServerText.Text != "",
                this.databaseNameText.Text != "",
                this.databaseUsernameText.Text != "",
                this.databasePasswordText.Text != "",
                this.databaseTypeBox.SelectedItem != null
            };

            if (validation.Contains(false))
            {
                MessageBox.Show("Missing values in form!", "Validation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Save connection
            ConnectionList.Connections[ConnectionList.Selected] = new Connection(
                this.databaseServerText.Text,
                this.databaseNameText.Text,
                this.databaseUsernameText.Text,
                this.databasePasswordText.Text,
                this.databaseTypeBox.SelectedItem.ToString()
            );


            this.databaseTestButton.Enabled = true;
            this.databasesListView_Reload();
        }

        private void databasesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.databasesListView.SelectedIndices.Count > 0)
            {
                ConnectionList.Selected = this.databasesListView.SelectedIndices[0];

                ReadConnectionDataToForm();

                EnableForm();
            }
            else
            {
                ConnectionList.Selected = -1;

                DisableForm();

            }
        }

        private void databasesListView_Reload()
        {
            string[] connectionsArray = ConnectionList.Connections.Select(x => x.Server).ToArray();

            this.databasesListView.BeginUpdate();

            this.databasesListView.Clear();

            foreach (string connection in connectionsArray)
            {
                this.databasesListView.Items.Add(connection);
            }

            this.databasesListView.EndUpdate();

            if (ConnectionList.Selected >= 0)
            {
                this.databasesListView.Items[ConnectionList.Selected].Selected = true;
                this.databasesListView.Items[ConnectionList.Selected].Focused = true;
            }

        }

        private void ReadConnectionDataToForm()
        {
            Connection con = ConnectionList.Connections.ElementAt(ConnectionList.Selected);

            if (con != null)
            {

                this.databaseServerText.Text = con.Server;
                this.databaseNameText.Text = con.Name;
                this.databaseUsernameText.Text = con.Username;
                this.databasePasswordText.Text = con.Password;
                this.databaseTypeBox.SelectedIndex = Array.IndexOf(Connection.AvailableTypes, con.Type);

            }

        }

        private void databaseDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectionList.Connections.RemoveAt(ConnectionList.Selected);
                ConnectionList.Selected = ConnectionList.Connections.Count - 1;

                DisableForm();
                this.databasesListView_Reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection remove error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableForm()
        {
            this.databaseDetailsBox.Enabled = true;

        }

        private void DisableForm()
        {
            this.databaseDetailsBox.Enabled = false;
        }

        private void databaseTestButton_Click(object sender, EventArgs e)
        {
            try
            {

                ConnectionList.Connections[ConnectionList.Selected].TestConnection();

                MessageBox.Show("Connection created successfully!", "Connection test success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (ArgumentOutOfRangeException aorex)
            {
                MessageBox.Show("No connection detected, create new and save data to new connection\n" + aorex.Message,
                    "Connection missing",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Connection test error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void FormDatabases_Dispose(object sender, EventArgs e)
        {
            ConnectionList.Save();
        }
        private void FormDatabases_Load(object sender, EventArgs e)
        {
            ConnectionList.Load();

            this.databaseTypeBox.Items.AddRange(Connection.AvailableTypes);

            if (!ConnectionList.isEmpty())
            {
                this.databasesListView_Reload();
            }

        }
    }
}
