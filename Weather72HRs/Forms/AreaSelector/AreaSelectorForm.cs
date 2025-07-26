using Weather72HRs.Core.Area.Instance;
using static Weather72HRs.Core.Utils.Validate;

namespace Weather72HRs.Forms.AreaSelector
{
    public partial class AreaSelectorForm : Form
    {
        public Country SelectedCountry { get; }
        public bool AreaSelectedProperly => SelectedDistrict != null;

        public Province? SelectedProvince => SelectedCountry.Get(cbProvince.Text);
        public City? SelectedCity => SelectedProvince?.Get(cbCity.Text);
        public District? SelectedDistrict => SelectedCity?.Get(cbDistrict.Text);

        public AreaSelectorForm(Country country)
        {
            SelectedCountry = country;

            InitializeComponent();
            ResetComboBoxes();
        }

        private void ResetComboBoxes()
        {
            cbProvince.Items.Clear();
            cbCity.Items.Clear();
            cbDistrict.Items.Clear();

            string[] provinces = SelectedCountry.Children.Select(p => p.Name).ToArray();
            cbProvince.Items.AddRange(provinces);
        }

        private void OnProvinceSelected()
        {
            Province province = RequiresNotNull(SelectedProvince);
            List<City> cities = province.Children;

            cbCity.Items.Clear();
            cbDistrict.Items.Clear();

            cbCity.Items.AddRange(cities.Select(c => c.Name).ToArray());
        }

        private void OnCitySelected()
        {
            City city = RequiresNotNull(SelectedCity);
            List<District> districts = city.Children;

            cbDistrict.Items.Clear();
            cbDistrict.Items.AddRange(districts.Select(d => d.Name).ToArray());
        }

        private void EnsureAllComboBoxesSelected()
        {
            if (!AreaSelectedProperly)
            {
                MessageBox.Show("请正确填写位置信息。", "错误");
                return;
            }
            else Close();
        }

        private void cbProvince_TextChanged(object sender, EventArgs e) => OnProvinceSelected();

        private void cbCity_TextChanged(object sender, EventArgs e) => OnCitySelected();

        private void btnConfirm_Click(object sender, EventArgs e) => EnsureAllComboBoxesSelected();

        private void btnReset_Click(object sender, EventArgs e) => ResetComboBoxes();
    }
}
