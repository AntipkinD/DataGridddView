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

namespace DataGridddView
{
    public partial class Form1 : Form
    {
        int[] firstMASS = new int[30];
        int[] secondMASS = new int[30];
        StreamReader svoj;
        bool check = false;
        Random kakoyto = new Random();
        DataTable MASS = new DataTable();
        public Form1()
        {
            InitializeComponent();
            MASS.Columns.Add("Первый массив", typeof(int));
            MASS.Columns.Add("Второй массив", typeof(int));
            MASS.Columns.Add("Разность массивов", typeof(int));
            ZapolneneRND();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            check = false;
            dataGridView1.DataSource = MASS;
            /*dataGridView + кнопки (ввести из файла, вывести в файл) + массив (30x30) */
            //индивидуальное задание: найти разность двух сформированных случайным образом массивов
        }
        void Zapolnene(DataTable value)
        {
            for (int j = 0; j < secondMASS.Length; j++)
            {
                value.Rows.Add(firstMASS[j], secondMASS[j], (firstMASS[j] - secondMASS[j]));
            }
        }
        void ZapolneneRND()
        {
            MASS.Rows.Clear();
            for (int i = 0; i < firstMASS.Length; i++)
            {
                firstMASS[i] = kakoyto.Next(-900, 900);
                secondMASS[i] = kakoyto.Next(-900, 900);
            }
            Zapolnene(MASS);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MASS.Rows.Clear();
            svoj = new StreamReader("D:\\VSWorks\\Project Massives\\dgrvw.txt");
            int j = 0;
            int k = 1;
            string[] firstsecond = (svoj.ReadToEnd().Split(' '));
            for (int i = 0; i < 30; i++)
            {
                firstMASS[i] = Convert.ToInt32(firstsecond[j]);
                secondMASS[i] = Convert.ToInt32(firstsecond[k]);
                j += 2;
                k += 2;
            }
            Zapolnene(MASS);
            dataGridView1.DataSource = MASS;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ZapolneneRND();
            dataGridView1.DataSource = MASS;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                chart1.Series[0].Points.Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value));
                chart1.Series[1].Points.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value));
                chart1.Series[2].Points.Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value));
            }

        }
    }
}
