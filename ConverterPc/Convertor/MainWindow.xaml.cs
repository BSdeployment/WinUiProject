using Convertor.Actions;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using System;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Convertor
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

        }

        private async void btnDone_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int from = cmbfrom.SelectedIndex;
                int to = cmdto.SelectedIndex;
                txtresult.Text = ConverterAction.ConvertValues(from, to, txtinput.Text);
            }

            catch {


                ContentDialog dialog = new ContentDialog
                {
                    FlowDirection = FlowDirection.RightToLeft,
                    XamlRoot = this.Content.XamlRoot,
                    Title = "warning",
                    Content = "הזנת ערך לא חוקי, שים לב לבחירתך!",
                    PrimaryButtonText = "אישור",
                  
                };

              await dialog.ShowAsync();
            }

        }
    }
}
