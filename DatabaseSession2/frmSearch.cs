using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseSession2
{
    public partial class frmSearch : Form
    {
        //This defines a list of PERSON objects that we created
        List<Person> people = new List<Person>();

        
        public frmSearch()
        {
            InitializeComponent();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void cmbCity_Click(object sender, EventArgs e)
        {
            if (cmbCountry.Text == "Pakistan")
            {
                cmbCity.Items.Clear();
                cmbCity.Items.Add("Karachi");
                cmbCity.Items.Add("Lahore");
                cmbCity.Items.Add("Islamabad");
                cmbCity.Items.Add("Rawalpindi");
                cmbCity.Items.Add("Quetta");
            }
            else if (cmbCountry.Text == "India")
            {
                cmbCity.Items.Clear();
                cmbCity.Items.Add("Mumbai");
                cmbCity.Items.Add("New Delhi");
                cmbCity.Items.Add("Bhopal");
                cmbCity.Items.Add("Lucknow");
            }
            else if (cmbCountry.Text == "Afghanistan")
            {
                cmbCity.Items.Clear();
                cmbCity.Items.Add("Kabul");
                cmbCity.Items.Add("Kunduz");
                cmbCity.Items.Add("Ghazni");
            }
            else if (cmbCountry.Text == "China")
            {
                cmbCity.Items.Clear();
                cmbCity.Items.Add("Beijing");
                cmbCity.Items.Add("Shanghai");
                cmbCity.Items.Add("Hong Kong");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            people.Add(new Person("Amna Tariq", "India", "Lucknow", "Female", "2/6/1988", "Null", "Delhi School of Economics", "MS-Finance", "2004", "2008", "Self-Employed", "Financial Analyst"));
            people.Add(new Person("Sarfraz Hussain", "Pakistan", "Karachi", "Male", "10/25/1998", "Eating, Gaming, Hiking", "Habib University DSSE", "BSCS", "2016", "2020", "Microsoft", "CEO"));
            people.Add(new Person("Zakir Khan", "India", "Mumbai", "Male", "1/1/1990", "Comedy, Food", "General High School", "Fine Arts", "2006", "2010", "Self-Employed", "Stand Up Comedian"));
            people.Add(new Person("Sarah Ahmed", "China", "Hong Kong", "Female", "11/15/1996", "Reading, Calligraphy, Fine Arts", "Hong Kong University", "Arts And Social Science", "2014", "2018", "Xiaomi", "MTO - HR"));
            people.Add(new Person("Soha Ali", "Afghanistan", "Kunduz", "Female", "1/18/1980", "Politics, Research in Science", "Harvey Mudd College", "MSCS", "1995", "2003", "Apple", "Director - Operations"));
            people.Add(new Person("Wasif Rizvi", "Pakistan", "Lahore", "Male", "1/1/1979", "Problem Solving, Reading", "Harvard University", "MBA", "1994", "2002", "Habib University", "President"));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbResults.Items.Clear();
            string gender = "";
            if (rbMale.Checked)
            {
                gender = "Male";
            }
            else if (rbFemale.Checked)
            {
                gender = "Female";
            }
            foreach (Person person in people)
            {
                /*I saw this code on StackOverflow and basically picked up the idea of Profuct of Sums form 
                 * i.e. (A'+A).(B'+B).(C'+C)+(D)
                 * A being NAME, B being Country, C being City and D being Gender
                 * Also Gender is a value which is always selected so there is no possibility of searching a record without
                 * specifying the gender.
                 */
                if ((string.IsNullOrWhiteSpace(txtName.Text) || person.Name == txtName.Text) && (string.IsNullOrWhiteSpace(cmbCountry.Text) || person.Country == cmbCountry.Text) && (string.IsNullOrWhiteSpace(cmbCity.Text) || person.City == cmbCity.Text) && (person.Gender == gender))
                {
                    lbResults.Items.Add(person.Name + "  (" + person.Country + "," + person.City + ")");
                    
                }
            }
        }
        public class Person
        {
            public string Name, Country, City, Gender, DOB, Interests, School, Degree, YearStart, YearEnd;
            public string Employer, JobTitle;

            public Person(string name, string country, string city, string gender, string dob, string interests, string school, string degree, string yearstart, string yearend, string employer, string jobtitle)
            {
                this.Name = name;
                this.Country = country;
                this.City = city;
                this.Gender = gender;
                this.DOB = dob;
                this.Interests = interests;
                this.School = school;
                this.Degree = degree;
                this.YearEnd = yearend;
                this.YearStart = yearstart;
                this.Employer = employer;
                this.JobTitle = jobtitle;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbResults.Items.Clear();
        }

        public void lbResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            foreach (Person person in people)
            {
                if ((string)lbResults.SelectedItem == person.Name + "  (" + person.Country + "," + person.City + ")")
                {
                    //we create the viewer form here on this button click and then pass the selected person object to it via the overloaded constructor
                    ProfileViewer viewer = new ProfileViewer(person);
                    viewer.Show();
                }
            }

        }
    }

}
