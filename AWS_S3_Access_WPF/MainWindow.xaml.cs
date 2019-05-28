using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using S3Access_NETFramework;

namespace AWS_S3_Access_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private S3Access s3Accesser = null;

        private string selectedFile = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            if (s3Accesser == null)
                s3Accesser = new S3Access();

        }

        // Choose file
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.ShowDialog();

            selectedFile = textbox_filePath.Text = fileDlg.FileName;
        }


        // Upload file
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if((String.IsNullOrEmpty(selectedFile) || (!File.Exists(selectedFile))))
            {
                MessageBox.Show("Choose a proper file and continue");
                return;
            }

            string bucketName = "pradeep87blore4";

            Console.WriteLine(s3Accesser.CreateBucket(bucketName));

            s3Accesser.UploadFile(selectedFile, bucketName);
        }

        private void ListBuckets_Click(object sender, RoutedEventArgs e)
        {
            var bucketList = s3Accesser.GetAllBuckets();

            foreach (string str in bucketList)
            {
                listbox_bucketList.Items.Add((str));
            }
        }
    }
}
