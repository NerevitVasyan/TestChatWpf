using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
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

namespace TestChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public class AlignmentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //File.WriteAllText("D:/chat.txt", (values[1] as User).Nickname);

            if((values[0] as User)?.Nickname== (values[1] as User)?.Nickname)
            {
                return HorizontalAlignment.Left;
            }
            return HorizontalAlignment.Right;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

   
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            //TestFill fill = new TestFill();
            // fill.Fill();
            // MessageBox.Show("Filled");
            ChatContext db = new ChatContext();
            listUsers.ItemsSource = db.Users.ToList();

            listMessages.ItemsSource = GetMessages();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User s = listUsers.SelectedItem as User;
            Message m = new Message
            {
                Date = DateTime.Now,
                Sender = s,
                Text = MessageText.Text
            };

            using (ChatContext db = new ChatContext())
            {
                db.Users.Attach(s);
                db.Messages.Add(m);
                db.SaveChanges();
            }

            MessageText.Text = String.Empty;
            listMessages.ItemsSource = GetMessages();
        }


        private List<Message> GetMessages ()
        {
           
            using (ChatContext db = new ChatContext())
            {
                return db.Messages.Include("Sender").ToList();
            }
        }

    }
}
