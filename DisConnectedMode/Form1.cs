using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DisConnectedMode;

public partial class Form1 : Form
{
    DataTable? dataTable = null;
    DataSet? DataSet = null;
    SqlConnection? sqlConnection = null;
    SqlDataAdapter? sqlDataAdapter = null;
    SqlDataReader? sqlDataReader = null;
    SqlCommand? sqlCommand = null;


    public Form1()
    {
        InitializeComponent();

        string conStr = "Data Source=STHQ0124-03;Initial Catalog=Libraryyy;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=False;";
        sqlConnection = new SqlConnection(conStr);
    }
    public void DisConnetctedModeDataRead()
    {
        string selectQuery = textBox.Text;
        sqlDataAdapter = new(selectQuery, sqlConnection);

        dataTable = new();
        sqlDataAdapter.Fill(dataTable);
        dataGridView.DataSource = dataTable;
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
        string a = (textBox.Text);
       
        string selectQuery = "SELECT * FROM Books WHERE Name LIKE @op";
        sqlCommand = new SqlCommand(selectQuery, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@op", '%'+a+'%');
        sqlDataAdapter = new SqlDataAdapter();
        sqlDataAdapter.SelectCommand = sqlCommand;

        dataTable = new();
        sqlDataAdapter.Fill(dataTable);
        dataGridView.DataSource = dataTable;
    }
}