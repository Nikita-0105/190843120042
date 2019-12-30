using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoDotNetConnectedArchExamples.Dal;
using AdoDotNetConnectedArchExamples.Validations;

namespace AdoDotNetConnectedArchExamples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        InfowayCustomerDal customerDal = new InfowayCustomerDal();
        DataTable customersTable;
        int currentIndex = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            customersTable = customerDal.GetAllCustomers();
            Navigation(currentIndex);
        }
        private void Navigation(int index)
        {
            if (customersTable.Rows.Count>0)
            {
                txtCustomerId.Text = customersTable.Rows[index].ItemArray[0].ToString();
                txtContactName.Text = customersTable.Rows[index].ItemArray[1].ToString();
                txtCity.Text = customersTable.Rows[index].ItemArray[2].ToString();
            }
        }

        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            Navigation(currentIndex);
        }

        private void btnMoveLast_Click(object sender, EventArgs e)
        {
            currentIndex = customersTable.Rows.Count-1;
            Navigation(currentIndex);
        }

        private void btnMovePrevious_Click(object sender, EventArgs e)
        {
            if (currentIndex>0)
            {
                currentIndex--;
                Navigation(currentIndex);
            }
        }

        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            if (currentIndex <customersTable.Rows.Count-1)
            {
                currentIndex++;
                Navigation(currentIndex);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtCustomerId.Text = string.Empty;
            txtContactName.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCustomerId.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InfowayCustomer customer = new InfowayCustomer()
            {
                CustomerId = int.Parse(txtCustomerId.Text),
                ContactName = txtContactName.Text,
                City = txtCity.Text
            };
            try
            {
                customerDal.InsertCustomer(customer);
                customersTable = customerDal.GetAllCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            InfowayCustomer customer = new InfowayCustomer()
            {
                CustomerId = int.Parse(txtCustomerId.Text),
                ContactName = txtContactName.Text,
                City = txtCity.Text
            };
            try
            {
                customerDal.UpdateCustomer(customer);
                customersTable = customerDal.GetAllCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            InfowayCustomer customer = new InfowayCustomer()
            {
                CustomerId = int.Parse(txtCustomerId.Text),
                ContactName = txtContactName.Text,
                City = txtCity.Text
            };
            try
            {
                customerDal.DeleteCustomer(customer);
                customersTable = customerDal.GetAllCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
