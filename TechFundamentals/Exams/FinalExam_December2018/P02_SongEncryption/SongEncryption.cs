namespace P02_SongEncryption
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class SongEncryption
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string artistPattern = @"^[A-Z][a-z\s']+$";
            string songPattern = @"^[A-Z ]+$";

            while (input != "end")
            {
                string[] artistAndSong = input.Split(":");

                string artist = artistAndSong[0];
                string song = artistAndSong[1];
                string encryptedArtist = string.Empty;
                string encryptedSong = string.Empty;
                int lenght = artist.Length;

                Match artistMatch = Regex.Match(artist, artistPattern);
                Match songMatch = Regex.Match(song, songPattern);

                if (!artistMatch.Success || !songMatch.Success)
                {
                    Console.WriteLine("Invalid input!");
                }

                else if (artistMatch.Success && songMatch.Success)
                {
                    encryptedArtist = GetEncryptedText(lenght, artist, encryptedArtist);
                    encryptedSong = GetEncryptedText(lenght, song, encryptedSong);

                    Console.WriteLine($"Successful encryption: {encryptedArtist}@{encryptedSong}");
                }

                input = Console.ReadLine();
            }
        }

        private static string GetEncryptedText(int lenght, string textToEncrypt, string encryptedText)
        {
            for (int i = 0; i < textToEncrypt.Length; i++)
            {
                char symbol = textToEncrypt[i];
                if (symbol == 32 || symbol == 39)
                {
                    encryptedText += symbol;
                    continue;
                }
                else
                {
                    int lenghtToEncrypt = symbol + lenght;

                    if (symbol > 64 && symbol < 91)
                    {
                        if (lenghtToEncrypt > 90)
                        {
                            symbol = (char)((lenghtToEncrypt - 90) + 64);
                        }
                        else
                        {
                            symbol = (char)(lenghtToEncrypt);
                        }
                    }

                    else if (symbol > 96 && symbol < 123)
                    {
                        if (lenghtToEncrypt > 122)
                        {
                            symbol = (char)((lenghtToEncrypt - 122) + 96);
                        }
                        else
                        {
                            symbol = (char)(lenghtToEncrypt);
                        }
                    }
                    encryptedText += symbol;
                }
            }

            return encryptedText;
        }
    }
}
