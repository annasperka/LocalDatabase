using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalDatabaseApp
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'employeeDataSet1.EmployeeInfo' table. You can move, or remove it, as needed.
            this.employeeInfoTableAdapter.Fill(this.employeeDataSet1.EmployeeInfo);
            timer1.Start();
        }

        private void employeeInfoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeInfoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.employeeDataSet1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.employeeInfoBindingSource.AddNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeInfoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.employeeDataSet1);
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.employeeInfoBindingSource.RemoveCurrent();
        }
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            count = employeeInfoBindingSource.Count;
            label_status.Text = "There are " +count.ToString() + "rows in your Database";

            if (count < 2)
            {
                Next_btn.Visible = false;
                Previous_btn.Visible = false;
            }
            else
            {
                Next_btn.Visible = true;
                Previous_btn.Visible = true;
            }
        }

        private void Previous_btn_Click(object sender, EventArgs e)
        {
            employeeInfoBindingSource.MovePrevious();
        }

        private void Next_btn_Click(object sender, EventArgs e)
        {
            employeeInfoBindingSource.MoveNext();
        }

        private void searchNameToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.employeeInfoTableAdapter.SearchName(this.employeeDataSet1.EmployeeInfo, nameToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                this.employeeInfoTableAdapter.SearchName(this.employeeDataSet1.EmployeeInfo, textBox1.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
