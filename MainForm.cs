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
            CreatColumns();
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

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();
            string queryString = $"select nf_Bid,nf_NameBid,nf_OutCustomer,nf_Priority from t_Bids";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgv_Bids.Columns["nf_OutCustomer"].Visible = true;
        }

    }
}
