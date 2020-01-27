using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using System.IO;

namespace Homework_12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Picture> _pictures=new List<Picture>();
        public MainWindow()
        {
            InitializeComponent();
            var i = Directory.GetCurrentDirectory();
            LoadImages("Pictures");
        }

        private void LoadImages(string path)
        {
            if(!Directory.Exists(path))
                return;
            var imageDir = new DirectoryInfo(path);
            var pictures = new List<Picture>();
            try
            {
                int counter = 0;
                foreach (var image in imageDir.GetFiles())
                {
                    BitmapImage bi = new BitmapImage(new Uri(image.FullName));
                    Image picIm = new Image(){Source = bi};
                    Picture newPic = new Picture() { Image = bi, Name = image.Name, Creation = image.CreationTime.ToString() };
                    string group = $"Group_{counter}";
                    RateRadioButton rb1 = new RateRadioButton(newPic){Content = Rate.High, GroupName = group};
                    RateRadioButton rb2 = new RateRadioButton(newPic){Content = Rate.Medium, GroupName = group};
                    RateRadioButton rb3 = new RateRadioButton(newPic) {Content = Rate.Low, GroupName = group, IsChecked = true};
                    rb1.Checked += Rate_Click;
                    rb2.Checked += Rate_Click;
                    rb3.Checked += Rate_Click;

                    newPic.RateRbS.Add(rb1);
                    newPic.RateRbS.Add(rb2);
                    newPic.RateRbS.Add(rb3);
                    
                    _pictures.Add(newPic);
                    counter++;
                }

                LstView.ItemsSource = _pictures;
            }
            catch (Exception e)
            {
                return;
            }
        }


        private void EndButton_Click(object sender, RoutedEventArgs e)
        {
            ScrViewer.ScrollToEnd();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ScrViewer.ScrollToTop();
        }

        private void Rate_Click(object sender, RoutedEventArgs e)
        {
            if (sender is RateRadioButton rb)
            {
                if (rb.Content.ToString() == "High")
                {
                    rb.Picture.Rate = Rate.High;
                }
                else if(rb.Content.ToString()=="Medium")
                {
                    rb.Picture.Rate = Rate.Medium;
                }
                else
                {
                    rb.Picture.Rate = Rate.Low;
                }
            }
        }
        private void SortByRate_OnSelected(object sender, RoutedEventArgs e)
        {
            List<Picture> pictures = new List<Picture>();
            _pictures.ForEach(p =>
            {
                if (p.Rate == Rate.High)
                {
                    pictures.Add(p);
                }
            });
            _pictures.ForEach(p =>
            {
                if (p.Rate == Rate.Medium)
                {
                    pictures.Add(p);
                }
            }); _pictures.ForEach(p =>
            {
                if (p.Rate == Rate.Low)
                {
                    pictures.Add(p);
                }
            });
            _pictures = pictures;
            LstView.ItemsSource = _pictures;
        }

        private void SortByName_OnSelected(object sender, RoutedEventArgs e)
        {
            _pictures.Sort();
            LstView.ItemsSource = null;
            LstView.ItemsSource = _pictures;
        }
    }

}
