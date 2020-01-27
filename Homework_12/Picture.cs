using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Homework_12
{
    enum Rate
    {
        High, Medium, Low
    }
    class Picture : IComparable
    {
        public BitmapImage Image { get; set; }
        public string Name { get; set; }
        public string Creation { get; set; }
        public Rate Rate { get; set; } = Rate.Low;
        public List<RateRadioButton> RateRbS { get;}

        public Picture()
        {
            RateRbS=new List<RateRadioButton>();
        }


        public int CompareTo(object obj)
        {
            if (obj is Picture pic)
            {
                return Name.CompareTo(pic.Name);
            }
            else
            {
                throw new InvalidDataException();
            }
        }
    }
}
