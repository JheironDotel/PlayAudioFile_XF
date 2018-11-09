using PCLStorage;
using PlayAudio_XF.Services;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.EventArguments;
using Plugin.MediaManager.Abstractions.Implementations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PlayAudio_XF
{
    public partial class MainPage : ContentPage
    {
        private FileData pickedFile;

        public MainPage()
        {
            InitializeComponent();

            this.volumeLabel.Text = "Volume (0-" + CrossMediaManager.Current.VolumeManager.MaxVolume + ")";
            //Initialize Volume settings to match interface
            int.TryParse(this.volumeEntry.Text, out var vol);
            CrossMediaManager.Current.VolumeManager.CurrentVolume = vol;
            CrossMediaManager.Current.VolumeManager.Mute = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CrossMediaManager.Current.StatusChanged += CurrentOnStatusChanged;
        }

        protected override void OnDisappearing()
        {
            CrossMediaManager.Current.StatusChanged -= CurrentOnStatusChanged;
            base.OnDisappearing();
        }

        private void CurrentOnStatusChanged(object sender, StatusChangedEventArgs e)
        {
            Debug.WriteLine($"MediaManager Status: {e.Status}");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (pickedFile != null)
                {
                    string picketFilePath = pickedFile.FilePath;

                    var mediaFile = new MediaFile
                    {
                        Type = MediaFileType.Audio,
                        Availability = ResourceAvailability.Local,
                        Url = picketFilePath
                        //,Metadata = new MediaFileMetadata() { Title = "My Title", Artist = "My Artist", Album = "My Album" },
                        ,MetadataExtracted = true                        
                    };

                    //await CrossMediaManager.Current.Play(picketFilePath);
                    await CrossMediaManager.Current.Play(mediaFile);
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void btnStop_Clicked(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();            
        }

        private void SetVolumeBtn_OnClicked(object sender, EventArgs e)
        {
            //int.TryParse(this.volumeEntry.Text, out var vol);
            //CrossMediaManager.Current.VolumeManager.CurrentVolume = vol;
        }

        private void MutedBtn_OnClicked(object sender, EventArgs e)
        {
            //if (CrossMediaManager.Current.VolumeManager.Mute)
            //{
            //    CrossMediaManager.Current.VolumeManager.Mute = false;
            //    mutedBtn.Text = "Mute";
            //}
            //else
            //{
            //    CrossMediaManager.Current.VolumeManager.Mute = true;
            //    mutedBtn.Text = "Unmute";
            //}
        }

        private async void btnSearch_Clicked(object sender, EventArgs e)
        {
            pickedFile = await CrossFilePicker.Current.PickFile();

            if (pickedFile == null)
            {
                await DisplayAlert("Archivo Audio", "Debe seleccionar un archivo de audio", "Ok");
                return;
            }
        }


        #region POR SI SE QUIERE REPRODUDIR DESDE UNA RUTA LOCAL EN EL PROYECTO
        //DependencyService.Get<IAudio>().PlayMp3File(picketFilePath);

        //var folder = await FileSystem.Current.GetFileFromPathAsync(picketFilePath);

        //using (streamR = await folder.OpenAsync(FileAccess.Read))
        //{
        //}

        //String folderName = "Audios";
        //string filename = "02.-Antologia-De-Caricias.mp3";
        //IFolder rootFolder = FileSystem.Current.LocalStorage;
        //var subFolderExists = await rootFolder.CheckExistsAsync("Audios");
        //if (subFolderExists == ExistenceCheckResult.FolderExists)
        //{
        //    var subFolder = await rootFolder.GetFolderAsync("Audios");
        //    //folder = await folder.CreateFolderAsync(folderName, CreationCollisionOption.ReplaceExisting);

        //    //IFile file = await rootFolder.GetFileAsync(filename);
        //    //var content = await file.ReadAllTextAsync();

        //    var localAudioFile = subFolder.Path + "/" + filename;

        //    var realLocal = new System.Uri(localAudioFile).AbsolutePath;

        //    DependencyService.Get<IAudio>().PlayMp3File(realLocal);

        #endregion

    }
}
