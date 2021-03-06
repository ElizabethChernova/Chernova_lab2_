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
        private bool isEnable = true;

        #endregion
        #region Properties
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                NotifyPropertyChanged("IsEnable");
            }
        }
        public string Email
        {
            get
            {
            
               
                return user.EmailAddress;
            }


        
            set
            {
                try { user.EmailAddress = value; }

                catch (AdressExeption ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}. Невірне значення: {ex.Value}");
                  
                }
                }
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
            get
            {
                int age=0;
                try
                {
                     age= user.Age;
                }


                catch (PersonException ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}. Невірне значення: {ex.Value}");
                }
                catch (DeadPersonException ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}. Невірне значення: {ex.Value}");
                }
                return age;
            }
        
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
            set
            {
             
                     isEnable = false;
                    Task.Run(async () => await SetNewInfo());
                    // isEnable = true;
                    user.DateOfBirth = value;
                
            }
        }
        private async Task SetNewInfo()
        {
            await Task.Run(() => ZodiacWestern);
            await Task.Run(() => ZodiacChineese);
            await Task.Run(() => IsAdult);
            await Task.Run(() => HasBirthday);
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
      
                if (user.HasBirthday)
                {
                    MessageBox.Show("З Днем народження!");
                }

            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

    }

}
