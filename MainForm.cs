 using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JIP
{
        enum RowState
        {
            Existed,
            New,
            Modified,
            ModifiedNew,
            Deleted
        }
    public partial class MainForm : Form
    {
        DataBaseConnection dataBase = new DataBaseConnection();
        int selectedRow;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //CreatColumns();
            RefreshDataGrid(dgv_Bids);
        }

        private void CreatColumns()
        {
            dgv_Bids.Columns.Add("nf_Bid", "Заявка");//nvarchar(9)
            dgv_Bids.Columns.Add("nf_NameBid", "Наименование"); //nvarchar(100)
            dgv_Bids.Columns.Add("nf_OutCustomer", "Контрагент"); //nvarchar(255)
            dgv_Bids.Columns.Add("nf_Priority", "Приоритет"); //int
            dgv_Bids.Columns.Add("IsNew", String.Empty);
        }

        private void RefreshDataGrid(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string queryString = $"select nf_Bid,nf_NameBid,nf_OutCustomer,nf_Priority from t_Bids";
            //SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());//позволяет выполнять операции с данными из БД
            dataBase.OpenConnection();

            DataSet ds;
            SqlDataAdapter adapter;
            //SqlCommandBuilder commandBuilder;
            adapter = new SqlDataAdapter(queryString, dataBase.GetConnection());
            ds = new DataSet();
            adapter.Fill(ds);
            dgv.DataSource = ds.Tables[0];

            //SqlDataReader reader = command.ExecuteReader();//считывает полученные в результате запроса данные
            //if (reader.HasRows) // если есть данные
            //{
            //    while (reader.Read())// построчно считываем данные
            //    {
            //        ReadSingleRow(dgw, reader);
            //    }
            //    reader.Close();
            //}
        }


        private void ReadSingleRow(DataGridView dgw, IDataReader record)
        {
            dgw.Rows.Add(record.GetString(0), record.GetString(1), record.IsDBNull(2) ? null : record.GetString(2), record.GetInt32(3), RowState.ModifiedNew);
        }

        private void dgv_Bids_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_Bids.Rows[selectedRow];
                tbx_SelectedBid.Text = $@"{row.Cells[0].Value.ToString()}  {row.Cells[1].Value.ToString()}  {row.Cells[2].Value?.ToString()}";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dgv_Bids.Columns["nf_OutCustomer"].Visible = false;
            //this.dgv_Bids.Columns["IsNew"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgv_Bids.Columns["nf_OutCustomer"].Visible = true;
        }

        private void tbx_Filter_TextChanged(object sender, EventArgs e)
        {
            //Search(dgv_Bids);


            //(dgv_Bids.DataSource as DataTable).DefaultView.RowFilter = $"nf_NameBid LIKE '%{tbx_Filter.Text}%'";
            //DataView MyDataView = new DataView(dgv_Bids);


            try
            {
                //((DataTable)dgv_Bids.DataSource).DefaultView.RowFilter = "nf_NameBid like'" + tbx_Filter.Text.Trim().Replace("'", "''") + "%'"; // поиск начиная с первого символа
                ((DataTable)dgv_Bids.DataSource).DefaultView.RowFilter = string.Format("nf_NameBid like '%{0}%'", tbx_Filter.Text.Trim().Replace("'", "''")); // поиск не зависит от места в строке
            }
            catch (Exception)
            {

            }

        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string searchString = $"select * from ordrsip.dbo.tBids where concat (nf_Id, nf_Designation, nf_Name, nf_TaskType, nf_Priority) like '%" + tbx_Filter.Text + "%'";
            SqlCommand com = new SqlCommand(searchString, dataBase.GetConnection());
            dataBase.OpenConnection();
            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }
            read.Close();
        }

        private void btn_ShowColumnList_Click(object sender, EventArgs e)
        {
            chlbx_Columns.Visible = false;
        }
    }
}

