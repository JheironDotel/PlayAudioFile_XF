using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayAudio_XF.Services
{
    public interface IAudio
    {
        void PlayMp3File(string fileName);
        bool PauseMp3File();
        bool StopMp3File();
        bool CloseMp3Player();

        bool PlayWavFile(string fileName);


        void PlayLocalFile(int fileNumber);
    }
}
