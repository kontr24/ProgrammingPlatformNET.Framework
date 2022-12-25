using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Лабор3
{
    public class PowerTools
    {
        private bool _DeviceClass;
        public bool GetDeviceClass()
        {
            return _Weight < 4;
        }

        public bool SetDeviceClass(bool DeviceClass)
        {
            return _DeviceClass;
        }

        private int _NoiseLevel;
        public int GetNoiseLevel()
        {
            return _NoiseLevel;
        }
        public void SetNoiseLevel(int NoiseLevel)
        {
            _NoiseLevel = NoiseLevel;
        }
        private int _Weight;
        public int GetWeight()
        {
            return _Weight;
        }
        public void SetWeight(int Weight)
        {

            _Weight = Weight;
        }
        private double _Price;
        public double GetPrice()
        {
            return _Price;
        }
        public void SetPrice(double Price)
        {
            _Price = Price;
        }

    }

}
