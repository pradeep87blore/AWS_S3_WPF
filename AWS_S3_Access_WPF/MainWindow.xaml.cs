using System;
using System.Collections.Generic;
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
using S3Access_NETFramework;

namespace AWS_S3_Access_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private S3Access s3Accesser = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            string bucketName = "pradeep87blore3";

            string sFilePath = "D:\\TestImage.jpg";
            if (s3Accesser == null)
                s3Accesser = new S3Access();

            Console.WriteLine(s3Accesser.CreateBucket(bucketName));

            s3Accesser.UploadFile(sFilePath, bucketName);

        }
    }
}
