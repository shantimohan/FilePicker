using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FilePicker
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void PickAFile_Clicked(object sender, EventArgs e)
        {
            FileData file = await CrossFilePicker.Current.PickFile();

            if (file != null)
            {
                FileName.Text = file.FileName;
                FileContents.Text = Encoding.UTF8.GetString(file.DataArray);
            }
        }

        private async void SaveFile_Clicked(object sender, EventArgs e)
        {
            byte[] byteData = Encoding.UTF8.GetBytes(FileContents.Text);
            FileData file = new FileData()
            {
                DataArray = byteData,
                FileName = FileName.Text.Trim()
            };

            bool status = await CrossFilePicker.Current.SaveFile(file);
        }
    }
}
