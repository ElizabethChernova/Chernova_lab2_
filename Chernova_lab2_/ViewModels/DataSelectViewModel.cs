using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Chernova_lab2_.Models;
using Chernova_lab2_.Tools;

namespace Chernova_lab2_.ViewModels
{
    class DataSelectViewModel : INotifyPropertyChanged
    {

        #region Field
        private Person user = new Person();
        private RelayCommand<object> _selectDateCommand;
      

        #endregion
        #region Properties
        public string Email
        {
            get { return user.EmailAddress; }
            set { user.EmailAddress = value; }
        }
        public string Surname
        {
            get { return user.Surname; }
            set { user.Surname = value; }
        }
        public string Name
        {
            get { return user.Name; }
            set { user.Name = value; }
        }
        public string ZodiacWestern
        {
            get { return user.ZodiacWestern; }
            set { } //user.ZodiacWestern = value; }

        }
        public bool IsAdult
        {
            get => user.IsAdult;
            set { }
        }
        public int Age
        {
            get => user.Age;
            set { user.Age = value; }
        }
        public Boolean HasBirthday
        {
            get => user.HasBirthday;
        set{} //{ user.HasBirthday = value ; }
        }
        public DateTime DateOfBirth
        {
            get { return user.DateOfBirth; }
            set {  user.DateOfBirth = value; }
        }

     /*   public DateTime DataOfBirth
        {
            get { return user.DataOfBirth; }
            set { user.DataOfBirth = value;
            *//*  Age=  CountAge();
                HasBirthday = DoHaveBirthday();
                ZodiacChineese = CountChineese();
                ZodiacWestern = CountWestern();*//*
            }
        }
*/
  
        public string ZodiacChineese
        {
            get { return user.ZodiacChineese; }
           set {}// user.ZodiacChineese = value; }
        }
        #endregion
     

        public RelayCommand<object> SelectDateCommand
        {
            get
            {
                return _selectDateCommand ??= new RelayCommand<object>(_ => SetData());
            }
        }

    

        /*
private async Task<void> SetDataAsync()
{
return await Task.Run(()=>SetData());
}
*/
        private void SetData()
        {
            NotifyPropertyChanged("Name");
            NotifyPropertyChanged("Surname");
            NotifyPropertyChanged("Email");
            NotifyPropertyChanged("Age");
            NotifyPropertyChanged("IsAdult");
            NotifyPropertyChanged("ZodiacWestern");
            NotifyPropertyChanged("ZodiacChineese");
            if (!user.IsRight())
            {
                MessageBox.Show("Некоректно обрано дату народження!");
            }
            else
            {
                if (user.HasBirthday)
                {
                    MessageBox.Show("З Днем народження!");
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

    }

}
