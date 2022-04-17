using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Chernova_lab2_.ViewModels;
namespace Chernova_lab2_.Views
{
    /// <summary>
    /// Interaction logic for DataSelectView.xaml
    /// </summary>
    public partial class DataSelectView : UserControl
    {

        private DataSelectViewModel _viewModel;
        public DataSelectView()
        {
            InitializeComponent();
            DataContext = _viewModel = new DataSelectViewModel();
        }
      
        /*  private void BSelected_Click(object sender, RoutedEventArgs e)
          {
              if (String.IsNullOrWhiteSpace(TbDataPicker.Text) || TbDataPicker.SelectedDate> DateTime.Today || DateTime.Today.Year-((DateTime)TbDataPicker.SelectedDate).Year>135)
              {
                  MessageBox.Show("wrong data");
                  return;
              } 


              _viewModel.DataOfBirth = (DateTime)TbDataPicker.SelectedDate;

              String happyBirthday = "";
              if (_viewModel.HasBirthday) { happyBirthday = " Happy birthday! "; }
              TbDateOfBirth.Text ="You was born on "+ TbDataPicker.Text; 
              TbAge.Text= " age now is " + _viewModel.Age + happyBirthday;
              TbZodiacWestern.Text = "Your western zodiac is: " +_viewModel.ZodiacWestern;
              TbZodiacChineese.Text = "Your eastern zodiac is: " + _viewModel.ZodiacChineese;

          }
  */
    }
}
