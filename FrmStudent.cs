using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BonusProject
{
    public partial class FrmStudent : Form
    {
        public FrmStudent()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-GA77R8Q;Initial Catalog=BonusSchool;Integrated Security=True");

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        string g = " ";
        void list()
        {
            dataGridView1.DataSource = ds.StudentList();
        }

        void clear()
        {
            TxtStudentFirstName.Text = "";
            TxtStudentID.Text = "";
            TxtStudentLastName.Text = "";
            CmbClub.Text = "";
        }
        private void FrmStudent_Load(object sender, EventArgs e)
        {
            list();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Club", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbClub.DisplayMember = "clubName";
            CmbClub.ValueMember = "clubID";
            CmbClub.DataSource = dt;

        }

     

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            

            ds.StudentAdd(TxtStudentFirstName.Text, TxtStudentLastName.Text, byte.Parse(CmbClub.SelectedValue.ToString()), g);
            clear();
            list();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ds.StudentDelete(int.Parse(TxtStudentID.Text));
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtStudentID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtStudentFirstName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtStudentLastName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ds.StudentUpdate(TxtStudentFirstName.Text,TxtStudentLastName.Text,byte.Parse(CmbClub.SelectedValue.ToString()),g,int.Parse(TxtStudentID.Text));
            list();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                g = "Female";
            }
         
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton2.Checked == true)
            {
                g = "Male";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.GetStudent(TxtSearch.Text);
        }
    }
}
