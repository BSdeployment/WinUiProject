using App1.ViewModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {

       public bool showTree { get; set; } = false;
        public MainWindow()
        {
            this.InitializeComponent();
           //listLactures.Visibility = Visibility.Collapsed;
        }

        private async void contentGrid_Drop(object sender, DragEventArgs e)
        {

            var res = await e.DataView.GetStorageItemsAsync();

            foreach (var item in res)
            {
                if (item is StorageFile sf)
                {
                    txt.Text = "please insert any folder with lactures";
                    //myimg.Source = new BitmapImage(new Uri($"file:///{sf.Path}"));
                   

                }
                if (item is StorageFolder folder)
                {
                    txt.Text = folder.Path;
                    PassParameters pass = new PassParameters();
                    pass.Parameters = folder.Path;
                    myframe.Navigate(typeof(BlankPage1),folder.Path);

                }
            }

            //listLactures.Visibility = Visibility.Visible;
        }

        private void contentGrid_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }
    }
}
