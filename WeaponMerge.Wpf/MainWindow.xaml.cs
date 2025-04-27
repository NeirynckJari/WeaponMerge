using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeaponMerge.Core.Classes.Entities;
using WeaponMerge.Core.Enums;
using WeaponMerge.Core.Interfaces;
using WeaponMerge.Core.Services;

namespace WeaponMerge.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WeaponService weaponService;
        WeaponType selectedType;

        public MainWindow()
        {
            InitializeComponent();
            weaponService = new WeaponService();
        }

        private void PopulateCategoryComboBox()
        {
            cmbWeaponStyle.Items.Clear();
            foreach (WeaponType type in Enum.GetValues<WeaponType>())
            {
                cmbWeaponStyle.Items.Add(type);
            }
        }

        private void UpdateWeaponList(WeaponType type)
        {
            lstWeapons.Items.Clear();
            foreach (IWeapon weapon in weaponService.Weapons)
            {
                if (weapon.Type == type)
                {
                    lstWeapons.Items.Add(weapon);
                }
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateCategoryComboBox();
        }

        private void BtnMakeWeapon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                weaponService.AddWeapon(selectedType);
                UpdateWeaponList(selectedType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void CmbWeaponStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbWeaponStyle.SelectedItem != null)
            {
                selectedType = (WeaponType)cmbWeaponStyle.SelectedItem;
            }
            UpdateWeaponList(selectedType);
        }

        private void BtnMergeWeapons_Click(object sender, RoutedEventArgs e)
        {
            if (lstWeapons.SelectedItems.Count < 2)
            {
                MessageBox.Show("Gelieve twee wapens te kiezen!");
                return;
            }
            else if (lstWeapons.SelectedItems.Count > 2)
            {
                MessageBox.Show("Gelieve enkel twee wapens te kiezen!");
                return;
            }
            try
            {
                weaponService.MergeWeapons((IWeapon)lstWeapons.SelectedItems[0], (IWeapon)lstWeapons.SelectedItems[1]);
                UpdateWeaponList(selectedType);
                lstWeapons.SelectedItems.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}