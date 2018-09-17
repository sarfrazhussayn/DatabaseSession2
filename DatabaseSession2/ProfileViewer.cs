using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DatabaseSession2.frmSearch;

namespace DatabaseSession2
{
    public partial class ProfileViewer : Form
    {
        //assigning labels to the imported values
        public string Name1, Country1, City1, Gender1, Interests1, DOB1, School1, Degree1, Employer1, JobTitle1;
        public string yearst, yearend;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ProfileViewer()
        {
            InitializeComponent();
        }
        public ProfileViewer(Person person)
        {
            InitializeComponent();
            Name1 = person.Name;
            Country1 = person.Country;
            City1 = person.City;
            Gender1 = person.Gender;
            DOB1 = person.DOB;
            School1 = person.School;
            Degree1 = person.Degree;
            Employer1 = person.Employer;
            JobTitle1 = person.JobTitle;
            yearst = person.YearStart;
            yearend = person.YearEnd;
            Interests1 = person.Interests;
        }

        private void ProfileViewer_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            labelName.Text = Name1;
            labCountry.Text = Country1;
            labCity.Text = City1;
            labGender.Text = Gender1;
            labDOB.Text = DOB1;
            labSchool.Text = School1;
            labDegree.Text = Degree1;
            labEmployee.Text = Employer1;
            labJT.Text = JobTitle1;
            labYearSt.Text = yearst;
            labYearEnd.Text = yearend;
            labInterests.Text = Interests1;
        }
    }
}
