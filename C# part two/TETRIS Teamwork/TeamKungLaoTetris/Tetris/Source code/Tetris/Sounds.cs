using System;
using System.IO;
using System.Threading;
using System.Media;
using System.Windows.Forms;
using System.Security;

namespace Tetris
{
    static class Sounds
    {
        public enum SoundEffects { Move, Rotate, ClearLine, Drop, LevelUp, GameOver }
        private static int[,] musicSheet;
        private const string Path = @"..\..\sound\";
        private static Thread musicThread;
        private static bool musicOn = true;
        private static bool sfxOn = true;
        private static bool musicAvalible = true;

        public static bool SfxOn
        {
            get
            {
                return sfxOn;
            }
            set
            {
                if (value && !sfxOn)
                {
                    sfxOn = true;
                }

                if (!value && sfxOn)
                {
                    sfxOn = false;
                }
            }
        }
        public static bool MusicOn
        {
            get
            {
                return musicOn;
            }
            set
            {
                if (value && !musicOn && musicAvalible)
                {
                    StartMusic();
                    musicOn = true;
                }

                if (!value && musicOn && musicAvalible)
                {
                    StopMusic();
                    musicOn = false;
                }
            }
        }
        static Sounds()
        {
            try
            {
                var musicFile = new StreamReader(Path + "music.mus");
                musicThread = new Thread(PlayMusic);
                LoadMusicFromFile(musicFile);

                if (musicOn)
                {
                    StartMusic();
                }
            }

            catch (TypeInitializationException)
            {
                MessageBox.Show("The music file is corrupted (is not in the correct format)! The music will be disabled!",
                    "The music is corrupted?!");
                musicAvalible = false;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("The music file path is empty? The music will be disabled!",
                    "The music file path is empty?!");
                musicAvalible = false;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The music file path is empty? The music will be disabled!",
                    "The music file path is empty?!");
                musicAvalible = false;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(string.Format("The file {0} was not found! The music will be disabled!",
                    (Path + "music.mus")), "File not found!");
                musicAvalible = false;
            }
            catch (FileLoadException)
            {
                MessageBox.Show(string.Format("The file {0} cannot be loaded! The music will be disabled!",
                    (Path + "music.mus")), "File cannot be loaded!");
                musicAvalible = false;
            }
            catch (IOException)
            {
                MessageBox.Show(string.Format(@"Input Output error occured while trying to open {0}! The music will be disabled!",
                    (Path + "music.mus")), "Input Output error!");
                musicAvalible = false;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(string.Format(@"You don't have permission to access {0} ! The music will be disabled!",
                    (Path + "music.mus")), "You don't have permission to access this file");
                musicAvalible = false;
            }
            catch (SecurityException)
            {
                MessageBox.Show(string.Format(@"You don't have permission to access {0} ! The music will be disabled!",
                    (Path + "music.mus")), "You don't have permission to access this file");
                musicAvalible = false;
            }

        }
        public static void Sfx(SoundEffects sfx)
        {
            if (sfxOn)
            {
                switch (sfx)
                {
                    case SoundEffects.Move:
                        PlaySoundFromFile(Path + "move.wav");
                        break;
                    case SoundEffects.Rotate:
                        PlaySoundFromFile(Path + "rotate.wav");
                        break;
                    case SoundEffects.LevelUp:
                        PlaySoundFromFile(Path + "levelup.wav");
                        break;
                    case SoundEffects.ClearLine:
                        PlaySoundFromFile(Path + "clearline.wav");
                        break;
                    case SoundEffects.Drop:
                        PlaySoundFromFile(Path + "drop.wav");
                        break;
                    case SoundEffects.GameOver:
                        PlaySoundFromFile(Path + "gameover.wav");
                        break;
                }
            }
        }
        private static void PlaySoundFromFile(string filePath)
        {
            using (var player = new SoundPlayer(filePath))
            {
                try
                {
                    player.Stop();
                    player.Play();
                }
                catch (TypeInitializationException)
                {
                    MessageBox.Show("The sound file is corrupted (is not in the correct format)! Sound will be disabled!", "Sound file is corrupted?!");
                    musicAvalible = false;
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("The sound file path is empty? The sound will be disabled!", "The sound file path is empty?!");
                    SfxOn = false;
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("The sound file path is empty? The sound will be disabled!", "The sound file path is empty?!");
                    SfxOn = false;
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show(string.Format("The file {0} was not found! Sound will be disabled!", filePath), "File not found!");
                    SfxOn = false;
                }
                catch (FileLoadException)
                {
                    MessageBox.Show(string.Format("The file {0} cannot be loaded! The sound will be disabled!", filePath), "File cannot be loaded!");
                    SfxOn = false;
                }
                catch (IOException)
                {
                    MessageBox.Show(string.Format(@"Input Output error occured while trying to open {0} ! The sound will
be disabled!", filePath), "Input Output error!");
                    SfxOn = false;
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(string.Format(@"You don't have permission to access {0} ! The sound will
be disabled!", filePath), "You don't have permission to access this file");
                    SfxOn = false;
                }
                catch (SecurityException)
                {
                    MessageBox.Show(string.Format(@"You don't have permission to access {0} ! The sound will
be disabled!", filePath), "You don't have permission to access this file");
                    SfxOn = false;
                }
            }
        }
        private static void StopMusic()
        {
            musicThread.Abort();
            musicThread = new Thread((PlayMusic));
        }
        private static void StartMusic()
        {
            musicThread.Start();
        }
        private static void LoadMusicFromFile(TextReader loadMusic)
        {
            try
            {
                if (loadMusic != null)
                {
                    var lines = int.Parse(loadMusic.ReadLine());
                    musicSheet = new int[lines, 2];
                    for (int i = 0; i < lines; i++)
                    {
                        var readLine = loadMusic.ReadLine();
                        if (readLine != null)
                        {
                            string[] musicLine = readLine.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            musicSheet[i, 0] = int.Parse(musicLine[0]);
                            musicSheet[i, 1] = int.Parse(musicLine[1]);
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new FileLoadException();
            }
            catch (ArgumentException)
            {

                throw new FileLoadException();
            }
        }
        private static void PlayMusic()
        {
            while (true)
            {
                for (int line = 0; line < musicSheet.GetLength(0); line++)
                {
                    if (musicSheet[line, 1] != 0)
                    {
                        Console.Beep(musicSheet[line, 0], musicSheet[line, 1]);
                    }
                    else
                    {
                        Thread.Sleep(musicSheet[line, 0]);
                    }
                }
            }
        }
    }
}
