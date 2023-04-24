using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JIP.Resources
{
    public partial class ColumnsForm  : Form
    {
        public List<string> columnNameSource;
        public string [,] arrColumnNameSource;

        public ColumnsForm()
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

        private void ColumnsForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //-----------------------------------------------------------------------------------------------------

        private void ColumnsForm_Load(object sender, EventArgs e)
        {
            //foreach (string columnName in columnNameSource)
            //{
            //    this.chlbx_Columns.Items.Add(columnName, false);
            //}

            //foreach (string columnName in arrColumnNameSource)
            //{
            //    this.chlbx_Columns.Items.Add(columnName, false);
            //}

            int rows = arrColumnNameSource.GetUpperBound(0) + 1;    // количество строк
            for (int i = 0; i < rows; i++)
            {
                Boolean valVisible = arrColumnNameSource[i, 1] =="1" ? true : false;
                this.chlbx_Columns.Items.Add(arrColumnNameSource[i, 0], valVisible);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {

        }

        private void chlbx_Columns_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedColumn = chlbx_Columns.SelectedItem.ToString(); // наименование выбранного чекбокса
                                                                           //MessageBox.Show(selectedColumn);

            //string selectedColumn = chlbx_Columns.GetItemCheckState(chlbx_Columns.Items.IndexOf(chlbx_Columns.SelectedItem)).ToString(); // состояние выбранного чекбокса
            //MessageBox.Show(selectedColumn);
            MainForm f1 = (MainForm)Application.OpenForms["MainForm"]; // Где Form1 это имя формы содежащаяся в переменной Name.
            if (f1 != null) // Если форма существует, то изменяем свойства её объектов
            { 
                if (chlbx_Columns.GetItemCheckState(chlbx_Columns.Items.IndexOf(chlbx_Columns.SelectedItem)) == CheckState.Checked)
                {
                    f1.ChangeColumnVisieble(selectedColumn,true);
                }
                else
                {
                    f1.ChangeColumnVisieble(selectedColumn, false);
                }
                //f1.ChangeSearchColumn();
            }
        }

        //...
        //Обработчик, сигнатура которого совпадает с сигнатурой делегата ItemCheckEventHandler
        void ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox lb = sender as CheckedListBox; //создаем ссылку на объект-инициатор события
            if (e.Index == 0) //если изменено состояние первой строки
            {
                //флаг соответствующий новому состоянию нулевой строки (вкл/выкл)
                bool flag = e.NewValue == CheckState.Checked ? true : false;
                //устанавливаем все остальные строки в то же положение
                for (int i = 1; i < lb.Items.Count; i++)
                    lb.SetItemChecked(i, flag);
            }
        }

    }
}
