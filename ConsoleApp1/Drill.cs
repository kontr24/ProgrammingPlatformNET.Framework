using System;

namespace Лабор3
{
    public class Drill : PowerTools
    {
        MechanismType _MechanismType;

        private string _Company;
        public string GetCompany()
        {
            return _Company;
        }
        public void SetCompany(string Company)
        {
            _Company = Company;
        }

        public MechanismType GetMechanismType()
        {
            return _MechanismType;
        }
        public void SetMechanismType(MechanismType mechanismType)
        {
            _MechanismType = mechanismType;
        }

        public Drill(string Company, MechanismType mechanismType, bool DeviceClass, int NoiseLevel, int Weight, double Price)
        {


            SetCompany(Company);   //Производитель

            SetMechanismType(mechanismType); // вид
            SetDeviceClass(DeviceClass); //класс прибора
            SetNoiseLevel(NoiseLevel); //уровень шума(Дб)
            SetWeight(Weight); //вес
            SetPrice(Price); //цена
        }

        public override string ToString()
        {

            /*Console.ForegroundColor = ConsoleColor.Red;*/



            return string.Format("{0,-10} |{1,-15}  |{2,-10} |{3,-5} |{4,-5} |{5,-5}", GetCompany(), GetMechanismType(), (GetDeviceClass() ? "лёгкий" : "тяжёлый"), GetNoiseLevel(), GetWeight(), GetPrice(), Console.ForegroundColor);
            /*return GetCompany() + "\t|" + GetView() + "\t|" + (GetDeviceClass() ? "лёгкий" : "тяжёлый") + "    \t|" + GetNoiseLevel() + "\t|" + GetWeight() + "\t|" + GetPrice();*/
        }



        /*public static implicit operator Drill(int v)
        {
            throw new NotImplementedException();
        }*/
    }
    public enum MechanismType
    {
        ударный = 1,
        безударный
    }
}
