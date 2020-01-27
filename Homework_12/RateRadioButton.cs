using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Homework_12
{
    class RateRadioButton : RadioButton
    {
        public Picture Picture { get; }

        public RateRadioButton(Picture image)
        {
            Picture = image;
        }
    }
}
