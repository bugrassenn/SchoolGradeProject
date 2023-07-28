using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProject
{
    public partial class FrmLessons : Form
    {
        public FrmLessons()
        {
            InitializeComponent();
        }
        // dataset
        DataSet1TableAdapters.Tbl_LessonsTableAdapter ds = new DataSet1TableAdapters.Tbl_LessonsTableAdapter();
        void list()
        {
            dataGridView1.DataSource = ds.LessonList();
        }
        
        void clear()
        {
            TxtLessonName.Text = "";
            TxtLessonID.Text = "";
        }
       
        private void FrmLessons_Load(object sender, EventArgs e)
        {
            list();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ds.AddLesson(TxtLessonName.Text);
            MessageBox.Show("Lesson Add!");
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            // listeleme işlemi
            list();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ds.DeleteLesson(byte.Parse (TxtLessonID.Text));
            MessageBox.Show("Lesson Deleted!");
            clear();
            list();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ds.UpdateLesson(TxtLessonName.Text, byte.Parse(TxtLessonID.Text));
            MessageBox.Show("Lesson Update!");
            clear();
            list();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           TxtLessonID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
           TxtLessonName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            
        }
    }
}
