using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSEntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Student stu = new Student()
            {
                FullName = "Travis Eiler",
                DateOfBirth = DateTime.Today
            };

            StudentDb.Add(stu);
            //stu = StudentDb.Add(stu);
            MessageBox.Show($"Student# {stu.StudentId} Added");

            List<Student> allStus = StudentDb.GetAllStudents();
            MessageBox.Show("Total Stu's " + allStus.Count);

            stu.FullName = "Sivart ReliE";
            StudentDb.Update(stu);
            MessageBox.Show("Student Updated");

            StudentDb.Delete(stu);
            allStus = StudentDb.GetAllStudents();
            MessageBox.Show("Total Stu's " + allStus.Count);
        }
    }
}
