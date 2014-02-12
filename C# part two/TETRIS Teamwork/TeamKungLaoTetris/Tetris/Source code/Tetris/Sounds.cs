using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Media;
using System.Windows.Forms;
using System.Security;

namespace Tetris
{
    static class Sounds
    {
        public enum SoundEffects { Move, Rotate, ClearLine, Drop, LevelUp, GameOver }
        static int[,] musicSheet;
        const string path = @"..\..\sound\";
        public static Thread musicThread;
        static bool musicOn = true;
        static bool sfxOn = true;
        static bool musicAvalible = true;
        public static bool SfxON
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
        static Sounds() // A static constructor to load the game music when the method class is first used
        {
            try
            {
                StreamReader musicFile = new StreamReader(path + "music.mus");
                musicThread = new Thread(new ThreadStart(PlayMusic));
                LoadMusicFromFile(musicFile);
                if (musicOn)
                {
                    StartMusic();
                }
            }
            catch (TypeInitializationException)
            {
                MessageBox.Show("The music file is corrupted (is not in the correct format)! The music will be disabled!", "The music is corrupted?!");
                Sounds.musicAvalible = false;
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("The music file path is empty? The music will be disabled!", "The music file path is empty?!");
                Sounds.musicAvalible = false;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The music file path is empty? The music will be disabled!", "The music file path is empty?!");
                Sounds.musicAvalible = false;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(string.Format("The file {0} was not found! The music will be disabled!", (path + "music.mus")), "File not found!");
                Sounds.musicAvalible = false;
            }
            catch (FileLoadException)
            {
                MessageBox.Show(string.Format("The file {0} cannot be loaded! The music will be disabled!", (path + "music.mus")), "File cannot be loaded!");
                Sounds.musicAvalible = false;
            }
            catch (IOException)
            {
                MessageBox.Show(string.Format(@"Input Output error occured while trying to open {0} ! The music will
be disabled!", (path + "music.mus")), "Input Output error!");
                Sounds.musicAvalible = false;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(string.Format(@"You don't have permission to access {0} ! The music will
be disabled!", (path + "music.mus")), "You don't have permission to access this file");
                Sounds.musicAvalible = false;
            }
            catch (SecurityException)
            {
                MessageBox.Show(string.Format(@"You don't have permission to access {0} ! The music will
be disabled!", (path + "music.mus")), "You don't have permission to access this file");
                Sounds.musicAvalible = false;
            }

        }
        public static void SFX(SoundEffects sfx)
        {
            if (sfxOn)
            {
                switch (sfx)
                {
                    case SoundEffects.Move:
                        PlaySoundFromFile(path + "move.wav");
                        break;
                    case SoundEffects.Rotate:
                        PlaySoundFromFile(path + "rotate.wav");
                        break;
                    case SoundEffects.LevelUp:
                        PlaySoundFromFile(path + "levelup.wav");
                        break;
                    case SoundEffects.ClearLine:
                        PlaySoundFromFile(path + "clearline.wav");
                        break;
                    case SoundEffects.Drop:
                        PlaySoundFromFile(path + "drop.wav");
                        break;
                    case SoundEffects.GameOver:
                        PlaySoundFromFile(path + "gameover.wav");
                        break;
                }
            }
        }
        internal static void PlaySoundFromFile(string filePath)
        {
            using (SoundPlayer player = new SoundPlayer(filePath))
            {
                try
                {
                    player.Stop();
                    player.Play();
                }
                catch (TypeInitializationException)
                {
                    MessageBox.Show("The sound file is corrupted (is not in the correct format)! Sound will be disabled!", "Sound file is corrupted?!");
                    Sounds.musicAvalible = false;
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("The sound file path is empty? The sound will be disabled!", "The sound file path is empty?!");
                    Sounds.SfxON = false;
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("The sound file path is empty? The sound will be disabled!", "The sound file path is empty?!");
                    Sounds.SfxON = false;
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show(string.Format("The file {0} was not found! Sound will be disabled!", filePath), "File not found!");
                    Sounds.SfxON = false;
                }
                catch (FileLoadException)
                {
                    MessageBox.Show(string.Format("The file {0} cannot be loaded! The sound will be disabled!", filePath), "File cannot be loaded!");
                    Sounds.SfxON = false;
                }
                catch (IOException)
                {
                    MessageBox.Show(string.Format(@"Input Output error occured while trying to open {0} ! The sound will
be disabled!", filePath), "Input Output error!");
                    Sounds.SfxON = false;
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(string.Format(@"You don't have permission to access {0} ! The sound will
be disabled!", filePath), "You don't have permission to access this file");
                    Sounds.SfxON = false;
                }
                catch (SecurityException)
                {
                    MessageBox.Show(string.Format(@"You don't have permission to access {0} ! The sound will
be disabled!", filePath), "You don't have permission to access this file");
                    Sounds.SfxON = false;
                }
            }
        }
        internal static void StopMusic()
        {
            musicThread.Abort();
            musicThread = new Thread(new ThreadStart(PlayMusic));
        }
        internal static void StartMusic()
        {
            musicThread.Start();
        }
        internal static void LoadMusicFromFile(StreamReader loadMusic)
        {
            try
            {
                int lines = int.Parse(loadMusic.ReadLine());
                musicSheet = new int[lines, 2];
                for (int i = 0; i < lines; i++)
                {
                    string[] musicLine = loadMusic.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    musicSheet[i, 0] = int.Parse(musicLine[0]);
                    musicSheet[i, 1] = int.Parse(musicLine[1]);
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
        internal static void PlayMusic()
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
