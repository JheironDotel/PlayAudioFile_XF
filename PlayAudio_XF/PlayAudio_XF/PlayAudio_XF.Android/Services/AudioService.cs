using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PlayAudio_XF.Droid.Services;
using Xamarin.Forms;
using PlayAudio_XF.Services;
using Android.Media;
using Java.IO;

[assembly: Dependency(typeof(AudioService))]

namespace PlayAudio_XF.Droid.Services
{
    public class AudioService : IAudio
    {
        public AudioService() { }

        private MediaPlayer _mediaPlayer;

        public async void PlayMp3File(string fileName)
        {
            if (_mediaPlayer == null)
            {
                _mediaPlayer = new MediaPlayer();
            }

            //FileInputStream fs = new FileInputStream(fileName);
            var fileqq = Android.Net.Uri.FromFile(new File(fileName));

            _mediaPlayer.Reset();
            //await _mediaPlayer.SetDataSourceAsync(fs.FD,);
            await _mediaPlayer.SetDataSourceAsync(global::Android.App.Application.Context, fileqq);
            _mediaPlayer.SetAudioStreamType(Stream.Music);
            _mediaPlayer.PrepareAsync();
            _mediaPlayer.Start();


            //audio en una carpeta del proyecto de android
            //_mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.test);


            //var fileqq = Android.Net.Uri.FromFile(new File(fileName));
            //_mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, fileqq);
            //_mediaPlayer.Start();

        }

        public bool PauseMp3File()
        {
            _mediaPlayer.Pause();
            return true;
        }

        public bool StopMp3File()
        {
            _mediaPlayer.Stop();
            return true;
        }

        public bool CloseMp3Player()
        {
            _mediaPlayer.Release();
            return true;
        }


        public bool PlayWavFile(string fileName)
        {
            //_mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.ding_persevy);
            //_mediaPlayer.Start();

            return true;
        }


        public void PlayLocalFile(int fileNumber)
        {
            if (_mediaPlayer == null)
            {
                _mediaPlayer = new MediaPlayer();
            }

            ///*_mediaPlayer.Reset();
            ////await _mediaPlayer.SetDataSourceAsync(fs.FD,);
            //await _mediaPlayer.SetDataSourceAsync(global::Android.App.Application.Context, fileqq);
            //_mediaPlayer.SetAudioStreamType(Stream.Music);
            //_mediaPlayer.PrepareAsync();
            //_mediaPlayer.Start();


            //audio en una carpeta del proyecto de android
            if (fileNumber == 1)
            {
                _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.Horse_1);
            }
            else if (fileNumber == 2)
            {
                _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.Cat_2);
            }
            else if (fileNumber == 3)
            {
                _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.Dog_3);
            }

            _mediaPlayer.Start();

        }

    }
}