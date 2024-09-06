using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using PdfWiver.Data;
using PdfWiver.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI;
using WinRT.Interop;
using static System.Runtime.InteropServices.JavaScript.JSType;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PdfWiver.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public FlowDirection Dir { get; set; }
        public FilesServices Files { get; set; }
        public HomePage()
        {
            this.InitializeComponent();
            Files = new FilesServices();

            //listfiles.ItemsSource = Files.GetAllFiles();
            //Task.Run(LoadData);
        }



        private void switchDir_Toggled(object sender, RoutedEventArgs e)
        {
            var toggle = sender as ToggleSwitch;

            if (toggle != null)
            {
                if (toggle.IsOn)
                {
                    Dir = FlowDirection.RightToLeft;
                    gridDir.FlowDirection = Dir;
                }
                else
                {
                    Dir = FlowDirection.LeftToRight;
                    gridDir.FlowDirection = Dir;
                }

            }
        }

        private void switchLight_Toggled(object sender, RoutedEventArgs e)
        {
            var toggle = sender as ToggleSwitch;

            if (toggle != null)
            {
                if (toggle.IsOn)
                {
                    this.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xE4, 0xE4, 0xE4));
                }
                else
                {
                    this.Background = new SolidColorBrush(Colors.White);
                }

            }
        }

        //private async Task LoadData()
        //{
        //    var res = await Files.LoadFilesAsync();

        //DispatcherQueue.TryEnqueue(() => { listfiles.ItemsSource = res;ringload.Visibility
        //         = Visibility.Collapsed;
               
        //    });



        //}

        private void listfiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var data = listfiles.SelectedItem;
             
            if(data is FilesModel item)
            {
                pdfview.Source = new Uri($"file:///{item.FilePath}");
            }
          

          
        }

        private void btnopenfilein_Click(object sender, RoutedEventArgs e)
        {
            if(listfiles.SelectedItem is null)
            {
                return;
            }
            var data = listfiles.SelectedItem;

            if(data is FilesModel item)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = item.FilePath,
                    UseShellExecute = true,
                });
            }

            
        }

        private async void btnopenfolder_Click(object sender, RoutedEventArgs e)
        {

            txtchoose.Visibility = Visibility.Collapsed;
            ringload.Visibility = Visibility.Visible;
            FolderPicker folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add("*"); // מאפשר בחירה של כל סוגי הקבצים

            // פתרון לתאימות עם חלונות
            var window = App.MainWindow;

            // Retrieve the window handle (HWND) of the current WinUI 3 window.
            var hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);

            // Initialize the folder picker with the window handle (HWND).
            WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hWnd);



            // בחירת תקייה
            StorageFolder folder = await folderPicker.PickSingleFolderAsync();

            var res = await Files.LoadFilesAsync(folder);

            listfiles.ItemsSource = res; 
            ringload.Visibility= Visibility.Collapsed;
            txtcountfiles.Text = $"({res.Count})";
            txtcountfiles.Visibility= Visibility.Visible;

        }
    }
}
