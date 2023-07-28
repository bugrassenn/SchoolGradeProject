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
    public partial class FrmClub : Form
    {
        public FrmClub()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-GA77R8Q;Initial Catalog=BonusSchool;Integrated Security=True");

        void list ()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Club", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmClub_Load(object sender, EventArgs e)
        {
            list();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            list();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Tbl_Club (clubName) values (@p1)", conn);
            cmd.Parameters.AddWithValue("@p1",TxtClubName.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Club added to list.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            list();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtClubID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtClubName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Delete From Tbl_Club where clubID=@p1", conn);
            cmd.Parameters.AddWithValue("@p1",txtClubID.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Club Deleted");
            list();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update Tbl_Club Set clubName=@p1 Where clubID =@p2", conn);
            cmd.Parameters.AddWithValue("@p1",TxtClubName.Text);
            cmd.Parameters.AddWithValue("@p2",txtClubID.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Update Club");
            list();
        }

     
    }
}
