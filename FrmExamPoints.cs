using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BonusProject
{
    public partial class FrmExamPoints : Form
    {
        public FrmExamPoints()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-GA77R8Q;Initial Catalog=BonusSchool;Integrated Security=True");
        int Pointsid;
        int exam1, exam2, exam3, project;
        double average;

        DataSet1TableAdapters.Tbl_PointsTableAdapter ds = new DataSet1TableAdapters.Tbl_PointsTableAdapter();
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.PointList(int.Parse(TxtStudentID.Text));
        }

        private void FrmExamPoints_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Lessons", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbLesson.DisplayMember = "lessonName";
            CmbLesson.ValueMember = "lessonID";
            CmbLesson.DataSource = dt;
        }

        private void TxtStatus_TextChanged(object sender, EventArgs e)
        {
            if(TxtStatus.Text == "True")
            {
                TxtStatus.BackColor = Color.SeaGreen;
            }
            if (TxtStatus.Text == "False")
            {
                TxtStatus.BackColor = Color.Red;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Pointsid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TxtStudentID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtExam1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtExam2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtExam3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProject.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtAverage.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            
           // string status;

            exam1 = Convert.ToInt16(TxtExam1.Text);
            exam2 = Convert.ToInt16(TxtExam2.Text);
            exam3 = Convert.ToInt16(TxtExam3.Text);
            project = Convert.ToInt16(TxtProject.Text);
            average = (exam1 + exam2 + exam3 + project) / 4;
            TxtAverage.Text = average.ToString();

            if(average >= 50 )
            {
                TxtStatus.Text = "True";
            }
            else
            {
                TxtStatus.Text = "False";
            }

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ds.PointsUpdate(byte.Parse(CmbLesson.SelectedValue.ToString()),int.Parse(TxtStudentID.Text),byte.Parse(TxtExam1.Text), byte.Parse(TxtExam2.Text), byte.Parse(TxtExam3.Text), byte.Parse(TxtProject.Text),decimal.Parse(TxtAverage.Text), bool.Parse(TxtStatus.Text),Pointsid);
        }
    }
}
