using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asssignment5
{
    public partial class Student : Form
    {
        List<int> ids = new List<int>();
        List<string> names = new List<string>();
        List<string> mobiles = new List<string>();
        List<string> addresses = new List<string>();
        List<int> ages = new List<int>();
        List<double> gpas = new List<double>();


        
        public Student()
        {
            InitializeComponent();


           
        }

        

        private void showallButton_Click(object sender, EventArgs e)
        {
            infoRichTextBox.Text = "";

            for (int index = 0; index < ids.Count(); index++)
            {
                infoRichTextBox.Text += "\nId: " + ids[index] + "  Name: " + names[index] + "  Mobile" + mobiles[index] + "  address :" + addresses[index] + "  ages :" + ages[index] + "  Gpa: " + gpas[index];

            }

            double max = 0, min = 4.00,total=0;
            string maxName = "", minName = "";
            for (int i = 0; i <gpas.Count(); i++)
            {
                total += gpas[i];
                if (max < gpas[i])
                {
                    max = gpas[i];
                    maxName = names[i];
                }
                if (min>gpas[i])
                {
                    min = gpas[i];
                    minName = names[i];
                }
            }

            maxTextBox.Text = max.ToString();
            maxNameTextBox.Text = maxName;

            minTextBox.Text = min.ToString();
            minNameTextBox.Text = minName;

            totalTextBox.Text = total.ToString();
            averageTextBox.Text = (total /ids.Count()).ToString();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text=="" || nameTextBox.Text=="" || mobileTextBox.Text=="" || addressTextBox.Text=="" || gpatTextBox.Text=="" || ageTextBox.Text == "")    
            {
                MessageBox.Show("Enter input");
                return;
            }
            for (int i = 0; i < mobiles.Count(); i++)
            {
                if (mobileTextBox.Text == mobiles[i])
                {
                    MessageBox.Show("Contact no. already exist.");
                    return;
                }

            }
            if (idTextBox.Text.Length !=4)
            {
                MessageBox.Show("only 4 digit allowed");
                return;
            }
            if (mobileTextBox.Text.Length !=11)
            {
                MessageBox.Show("Enter 11 digit");
                return;
            }

            if (nameTextBox.Text.Length >30)

            {
                MessageBox.Show("Character can not be more 30 words");
                return;
            }

            if (Convert.ToDouble(gpatTextBox.Text)<0 || Convert.ToDouble(gpatTextBox.Text) >4)
            {
                MessageBox.Show("enter between 0 to 4");
                return;
            }

            ids.Add(Convert.ToInt32(idTextBox.Text));
            names.Add(nameTextBox.Text);
            mobiles.Add(mobileTextBox.Text);
            addresses.Add(addressTextBox.Text);
            ages.Add(Convert.ToInt32(ageTextBox.Text));
            gpas.Add(Convert.ToDouble(gpatTextBox.Text));

            int index = ids.Count() - 1;

            infoRichTextBox.Text = "";

            infoRichTextBox.Text = "Id: " + ids[index] + "  Name: " +   names[index] + "  Mobile" +  mobiles[index] + "  address :" +  addresses[index] + "  ages :" + ages[index] + "  Gpa: " + gpas[index];
            
            

        }

       
        private void searchButton_Click(object sender, EventArgs e)
        {
            int flag = -1, index = -1;

           
            

            if (searchTextBox.Text == "")
            {
                MessageBox.Show("Enter input");
                return;
            }

            
            
                if (idRadioButton.Checked == true)
            {
                    try
                    {
                        int id = Convert.ToInt32(searchTextBox.Text);
                        index = ids.IndexOf(id);
                        flag = 1;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Enter id");
                        throw;
                    }
                }
                else if (nameRadioButton.Checked == true)
                {
                    index = names.IndexOf(searchTextBox.Text);
                    
                    flag = 1;
                }
                else if (mobileRadioButton.Checked==true)
                {
                    index = mobiles.IndexOf(searchTextBox.Text);
                    flag = 1;
                    
                }

                if (index >=0 && flag==1)
                {
                    infoRichTextBox.Text = "Id: " + ids[index] + "  Name: " + names[index] + "  Mobile" + mobiles[index] + "  address :" + addresses[index] + "  ages :" + ages[index] + "  Gpa: " + gpas[index];
                    MessageBox.Show("Found");
                }
                else
                {
                    MessageBox.Show("Not Found");
                }
            }
        
    }
}
