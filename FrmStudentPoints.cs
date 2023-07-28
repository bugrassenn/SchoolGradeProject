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
using System.Reflection;

namespace BonusProject
{
    public partial class FrmStudentPoints : Form
    {
        public FrmStudentPoints()
        {
            InitializeComponent();
        }


        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-GA77R8Q;Initial Catalog=BonusSchool;Integrated Security=True");
        public string number;

        private void FrmStudentPoints_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select lessonName,exam1,exam2,exam3,project, average,status  From Tbl_Points INNER JOIN Tbl_Lessons ON Tbl_Points.lessonID = Tbl_Lessons.lessonID Where studentID=@p1",conn);
            cmd.Parameters.AddWithValue("@p1", number);
            //this.Text= number.ToString();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
