using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Лабор3
{
    public class Shop
    {
        private List<Drill> _products;

        public List<Drill> Products
        {
            get
            {
                return _products;
            }

            set
            {
                _products = value;
            }
        }

        public object Drills { get; private set; }

        public void ShowDrills()
        {


            foreach (Drill p in _products)
            {

                Console.WriteLine(p.ToString());
            }

        }


        public delegate int Compare(Drill a, Drill b); //делегат для функций сравнения



        public delegate void Finished(Shop sender);  //делегат для функции обратного вызова

        public delegate void SortDelegate(Compare compare, bool Descending = false);

        /* public delegate void SortDelegate(Shop s, Compare c, bool d);

          public SortDelegate SortDelegateFunc = (s, c, d) => s.Sort(c, d);*/

        public event Finished FinishedEvent; //событие

        
        public delegate void BeginInvoke(); //метод делегата 

        public void SortAsync()
        {
            new SortDelegate(Sort).BeginInvoke(CompanySort, false, (result) => ShowDrills(), 0); //создаётся экземпляр, выполнется делегат асинхронно в потоке
        }

        /* public void SortAsync(Compare compare, bool Descending = false) //вызывает основной метод Sort с помощью метода делегата BeginInvoke
          {
              SortDelegateFunc.BeginInvoke(this, compare, Descending, (result) => {
                  FinishedEvent.Invoke(this);
              }, this);

          }*/

        //сортировка
        public void Sort(Compare compare, bool Descending = false)
        {
            /* int t = 0;
             Drill temp;
             for (int i = 0; i < _products.Count - 1; i++)
             {
                 for (int j = i; j < _products.Count; j++)
                 {

                     Thread.Sleep(500);   //задержка

                     t = compare(_products[i], _products[j]);
                     if (!Descending)
                     {
                         if (t == 1)
                         {
                             temp = _products[i];
                             _products[i] = _products[j];
                             _products[j] = temp;
                         }
                     }
                     else
                     {
                         if (t == -1)
                         {
                             temp = _products[i];
                             _products[i] = _products[j];
                             _products[j] = temp;
                         }
                     }
                 }
             }*/
            Thread.Sleep(500);
            _products.Sort((a, b) => compare(a, b));
            
            if (FinishedEvent != null) //проверка, что подписчики имеются
            {
                FinishedEvent.Invoke(this);// принимает делегат и выполняет его в потоке
                //this ссылется на текущий экземпляр класса
            }
        }


        public int CompanySort(Drill a, Drill b) //1. Сравнение по фирме
        {

            return string.Compare(a.GetCompany(), b.GetCompany());
        }


        public int MechanismTypeSort(Drill a, Drill b) //2. Сравнение по виду
        {

            if (a.GetMechanismType() > b.GetMechanismType())
            {
                return 1;
            }
            else if (a.GetMechanismType() < b.GetMechanismType())
            {
                return -1;
            }
            else
            {
                return 0;

            }
        }

        public int DeviceClassSort(Drill a, Drill b)  //3.Сравнение по классу прибора
        {

            if (a.GetDeviceClass())
            {
                return 1;
            }
            else
                return -1;

        }
        public int NoiseLevelSort(Drill a, Drill b) //4.Сравнение по уровню шума
        {
            if (a.GetNoiseLevel() < b.GetNoiseLevel())
            {

                return 1;
            }

            if (a.GetNoiseLevel() > b.GetNoiseLevel())
            {
                return -1;
            }
            else
                return 0;

        }
        public int WeightSort(Drill a, Drill b) //5. Сравнение по  весу
        {
            if (a.GetWeight() < b.GetWeight())
            {
                return -1;
            }

            if (a.GetWeight() > b.GetWeight())
            {
                return 1;
            }
            else
                return 0;
        }
        public int PriceSort(Drill a, Drill b) //6. Сравнение по цене
        {
            if (a.GetPrice() < b.GetPrice())
            {
                return -1;
            }

            if (a.GetPrice() > b.GetPrice())
            {
                return 1;
            }
            else
                return 0;
        }
    }
}


/*public void Sort(Compare compare, bool Descending = false)
{

    _products.Sort((a, b) => compare(a, b));
}*/



/*public static int SortDeviceClass(Drill a, Drill b)
{
    int ret = b.GetDeviceClass().CompareTo(a.GetDeviceClass());
    if (ret != 0)
        return ret;
    return a.GetPrice().CompareTo(b.GetPrice());
}


public void Sort(List<Drill> list, Func<Drill, Drill, int> comparer)
{
    for (int i = 0; i < list.Count; i++)
    {
        for (int j = i + 1; j < list.Count; j++)
        {
            if (comparer(list[i], list[j]) > 0)
            {
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}

 public void CompanySort()
{


    ShowDrills();
}
}*/
