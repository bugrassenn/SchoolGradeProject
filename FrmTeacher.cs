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
    public partial class FrmTeacher : Form
    {
        public FrmTeacher()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmClub fr = new FrmClub();
            fr.Show();
        }

        private void BtnLesson_Click(object sender, EventArgs e)
        {
            FrmLessons fr = new FrmLessons();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmStudent fr = new FrmStudent();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmExamPoints fr = new FrmExamPoints();
            fr.Show();
        }
    }
}
