using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_Project
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        CSharpCourseEfTravelDbEntities db = new CSharpCourseEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.TblLocation.Count().ToString();
            lblSumCapacity.Text = db.TblLocation.Sum(x => x.LocationCapacity).ToString();
            lblGuideCount.Text = db.TblGuide.Count().ToString();
            lblAvgCapacity.Text = ((double)db.TblLocation.Average(x => x.LocationCapacity)).ToString("F2");
            lblAvgPrice.Text = ((double)db.TblLocation.Average(x => x.LocationPrice)).ToString("F2") +" TL";

            int lastCountryId = db.TblLocation.Max(x => x.LocationId);
            lblLastCountry.Text = db.TblLocation.Where(x => x.LocationId == lastCountryId).Select(y => y.LocationCountry).FirstOrDefault();

            lblKapadokyaCount.Text = db.TblLocation.Where(x => x.LocationCity == "Kapadokya").Select(y => y.LocationCapacity).FirstOrDefault().ToString();
            lblAvgTrCapacity.Text = db.TblLocation.Where(x => x.LocationCountry == "Türkiye").Average(y => y.LocationCapacity).ToString();

            var romeGuideId = db.TblLocation.Where(x => x.LocationCity == "Roma").Select(y => y.LocationId).FirstOrDefault();
            lblRomeGuide.Text = db.TblGuide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName+""+y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity = db.TblLocation.Max(x => x.LocationCapacity);
            lblHighestCapacity.Text = db.TblLocation.Where(x => x.LocationCapacity == maxCapacity).Select(y => y.LocationCity).FirstOrDefault().ToString();

            var maxPrice = db.TblLocation.Max(x => x.LocationPrice);
            lblMostExpensive.Text = db.TblLocation.Where(x => x.LocationPrice == maxPrice).Select(y => y.LocationCity).FirstOrDefault().ToString();

            var guideId = db.TblGuide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname == "Çınar").Select(y => y.GuideId).FirstOrDefault();
            lblOneGuideJobCount.Text = db.TblLocation.Where(x => x.GuideId == guideId).Count().ToString();
        }






















        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblLocationCount_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
