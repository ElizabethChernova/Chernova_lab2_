using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chernova_lab2_.Models
{
    class UserCandidate
    {
        #region Fields
        private string _name;
        private string _surname;
        private int _age;
        private DateTime _dateOfBirth=DateTime.Today;
        private string _emailAddress;

        private string _sunSign;
        private Boolean _isAdult;
        private Boolean _hasBirthday;
        private string _chineseSign;


        #endregion
        public UserCandidate()
        {
        }

        public UserCandidate(string name, string surname, DateTime? dataOfBirth)
        {
            _name = name;
            _surname = surname;
            if (dataOfBirth.HasValue)
            {
                _dateOfBirth = dataOfBirth.Value;
            }
            else
            {
                _dateOfBirth = new DateTime();
            }
        }

        public UserCandidate(string name, string surname, string emailAddress)
        {
            _name = name;
            _surname = surname;
            _emailAddress = emailAddress;
        }

        public UserCandidate(string name, string surname, DateTime? dataOfBirth, string emailAddress)
        {
            _name = name;
            _surname = surname;
            if (dataOfBirth.HasValue)
            {
                _dateOfBirth = dataOfBirth.Value;
            }
            else
            {
                _dateOfBirth = new DateTime();
            }
            _emailAddress = emailAddress;
        }
        #region Properties
        public string ZodiacWestern
        {
            get { return _sunSign = CountWestern(); }
          //  set { _sunSign = value; }
            
        }
        public int Age
        {
            get => _age = DateTime.Today.Year - _dateOfBirth.Year;
             set { _age = DateTime.Today.Year - _dateOfBirth.Year; }
        }
        public Boolean HasBirthday
        {
            get => _hasBirthday = DateTime.Today.Month == _dateOfBirth.Month && DateTime.Today.Day == _dateOfBirth.Day;
           //   set { _hasBirthday = DateTime.Today.Month == _dateOfBirth.Month && DateTime.Today.Day == _dateOfBirth.Day; }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { Task.Run(async()=>await SetNewInfo());
                _dateOfBirth = value; }
        }

        private async Task SetNewInfo()
        {
           await Task.Run(()=>ZodiacWestern);
           await Task.Run(()=>ZodiacChineese);
            await Task.Run(() => IsAdult);
            await Task.Run(() => HasBirthday);
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string ZodiacChineese
        {
            get { return _chineseSign = CountChineese(); }
           // set { _chineseSign = value; }
            }

        #endregion

        private string CountWestern()
        {


            if ((DateOfBirth.Day >= 21 && DateOfBirth.Month == 3) || (DateOfBirth.Day <= 20 && DateOfBirth.Month == 4)) return "Овен";
            if ((DateOfBirth.Day >= 21 && DateOfBirth.Month == 4) || (DateOfBirth.Day <= 20 && DateOfBirth.Month == 5)) return "Телець ";
            if ((DateOfBirth.Day >= 21 && DateOfBirth.Month == 5) || (DateOfBirth.Day <= 21 && DateOfBirth.Month == 6)) return "Близнюки ";
            if ((DateOfBirth.Day >= 22 && DateOfBirth.Month == 6) || (DateOfBirth.Day <= 22 && DateOfBirth.Month == 7)) return "рак";
            if ((DateOfBirth.Day >= 23 && DateOfBirth.Month == 7) || (DateOfBirth.Day <= 23 && DateOfBirth.Month == 8)) return "лев";
            if ((DateOfBirth.Day >= 24 && DateOfBirth.Month == 8) || (DateOfBirth.Day <= 23 && DateOfBirth.Month == 9)) return "Діва";
            if ((DateOfBirth.Day >= 24 && DateOfBirth.Month == 9) || (DateOfBirth.Day <= 23 && DateOfBirth.Month == 10)) return "Терези ";
            if ((DateOfBirth.Day >= 24 && DateOfBirth.Month == 10) || (DateOfBirth.Day <= 22 && DateOfBirth.Month == 11)) return "Скорпіон ";
            if ((DateOfBirth.Day >= 23 && DateOfBirth.Month == 11) || (DateOfBirth.Day <= 21 && DateOfBirth.Month == 12)) return "Стрілець ";
            if ((DateOfBirth.Day >= 22 && DateOfBirth.Month == 12) || (DateOfBirth.Day <= 20 && DateOfBirth.Month == 1)) return "Козеріг ";
            if ((DateOfBirth.Day >= 21 && DateOfBirth.Month == 1) || (DateOfBirth.Day <= 18 && DateOfBirth.Month == 2)) return "Водолій ";
            else return "Риби ";

        }

        private string CountChineese()
        {
            switch (DateOfBirth.Year % 12.0)
            {

                case 1:
                    return "Півень";

                case 2:
                    return "Собака";
                case 3:
                    return "Свиня";
                case 4:
                    return "Щур";
                case 5:
                    return "Бик ";
                case 6:
                    return "Тигр ";
                case 7:
                    return "Кролик ";
                case 8:

                    return "Дракон ";
                case 9:
                    return "Змія ";
                case 10:
                    return "Кінь";
                case 11:
                    return "Коза";
                default:
                    return "Мавпа";
            }
        }

       /* private bool DoHaveBirthday()
        {
            return HasBirthday = DateTime.Today.Month == DateOfBirth.Month && DateTime.Today.Day == DateOfBirth.Day;
        }
*/
        private int CountAge()
        {
            return DateTime.Today.Year - DateOfBirth.Year;
        }
        public bool IsRight()
        {
        
            if (CountAge() < 0 &&( DateTime.Today.Month < DateOfBirth.Month || DateTime.Today.Month == DateOfBirth.Month && DateTime.Today.Day < DateOfBirth.Day) || CountAge() > 135) return false;
            return true;
        }
        public Boolean IsAdult
        {
            get => _isAdult = DateOfBirth.Year>18 &&( DateOfBirth.Month> DateTime.Today.Month || (DateOfBirth.Month == DateTime.Today.Month && DateOfBirth.Day > DateTime.Today.Day));
           // private set {_isAdult = value; }
        }
    }
  


}
