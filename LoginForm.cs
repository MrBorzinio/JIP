using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JIP
{
    public partial class LoginForm : Form
    {
        DataBaseConnection database = new DataBaseConnection();

        public LoginForm()
        {
            InitializeComponent();
        }

        //перетаскивание формы без бордеров -------------------------------------------------------------------
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [System.Runtime.InteropServices.DllImport("user32.dll")]

        public static extern bool ReleaseCapture();


        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //-----------------------------------------------------------------------------------------------------

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Hide();                                     //   !!!!!!!!!!!!!!!!!!  времяночка
            MainForm mainForm = new MainForm();        //   !!!!!!!!!!!!!!!!!!  времяночка
            mainForm.ShowDialog();                    //   !!!!!!!!!!!!!!!!!!  времяночка

            cbx_User.Select();

            var queryUsers = $"select id, nf_User from t_Users where nf_Pas IS NOT NULL";
            SqlDataAdapter commandUsers = new SqlDataAdapter(queryUsers, database.GetConnection());
            database.OpenConnection();
            DataTable users = new DataTable();
            commandUsers.Fill(users);
            cbx_User.DataSource = users;
            cbx_User.ValueMember = "id";
            cbx_User.DisplayMember = "nf_User"; 
            database.CloseConnection();

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbx_User.Text) && !string.IsNullOrEmpty(tbx_Password.Text))
            {
                var sqlCheckPassUser  = $"SELECT*FROM t_Users WHERE nf_User='{cbx_User.Text}' AND nf_Pas='{tbx_Password.Text}'";
                var commandCheckPassUser = new SqlCommand(sqlCheckPassUser, database.GetConnection());

                database.OpenConnection();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand command = new SqlCommand(sqlCheckPassUser, database.GetConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    //cbx_User.Clear();
                    tbx_Password.Clear();
                    chbx_ShowPass.Checked = false;
                    Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Пароль введен неверно! Попробуйте еще раз!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tbx_Password.Focus();

                }

            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chbx_ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chbx_ShowPass.Checked == true)
            {
                tbx_Password.UseSystemPasswordChar = false;
            }
            else
            {
                tbx_Password.UseSystemPasswordChar = true;
            }
        }

    }


}
