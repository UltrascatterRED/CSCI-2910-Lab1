namespace bartonn_csci2910_lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<VideoGame> games = new List<VideoGame>();
            string currentLine;
            try
            {
                Console.WriteLine("Application Loading (may take a moment)...");
                //videogames.csv MUST be in the same directory as Program.cs to be read.
                StreamReader sr = new StreamReader("..\\..\\..\\videogames.csv");
                //skips header record in videogames.csv
                sr.ReadLine();
                currentLine = sr.ReadLine();

                while (currentLine != null)
                {
                    //stores current record as VideoGame object
                    string[] currentFields = currentLine.Split(',');

                    string currentName = currentFields[0];
                    string currentPlatform = currentFields[1];
                    int currentYear = int.Parse(currentFields[2]);
                    string currentGenre = currentFields[3];
                    string currentPublisher = currentFields[4];
                    decimal currentNA_Sales = decimal.Parse(currentFields[5]);
                    decimal currentEU_Sales = decimal.Parse(currentFields[6]);
                    decimal currentJP_Sales = decimal.Parse(currentFields[7]);
                    decimal currentOther_Sales = decimal.Parse(currentFields[8]);
                    decimal currentGlobal_Sales = decimal.Parse(currentFields[9]);

                    games.Add
                    (
                        new VideoGame
                        (
                            currentName, currentPlatform, currentYear, currentGenre, currentPublisher, currentNA_Sales,
                            currentEU_Sales, currentJP_Sales, currentOther_Sales, currentGlobal_Sales
                        )
                    );
                    //reads in next line
                    currentLine = sr.ReadLine();
                }

                SortVideoGameList(games);
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to the Video Game Database");
                    Console.WriteLine("-----------------------------------------------------------------");
                    Console.WriteLine("1.) Search by Publisher");
                    Console.WriteLine("2.) Search by Genre");
                    Console.WriteLine("3.) Exit");
                    Console.WriteLine();
                    Console.Write("Number of your Selection (1,2,3): ");
                    try
                    {
                        switch (int.Parse(Console.ReadLine()))
                        {
                            case 1:
                                //******************************************************************************
                                //extracts all records published by user-inputted publisher
                                Console.Write("Enter publisher to search for:\t");
                                PublisherData(games, Console.ReadLine());
                                Console.WriteLine("Press [ENTER] to continue");
                                Console.ReadLine();
                                continue;
                            case 2:
                                //******************************************************************************
                                //extracts all records of user-inputted genre
                                Console.Write("Enter genre to search for:\t");
                                GenreData(games, Console.ReadLine());
                                Console.WriteLine("Press [ENTER] to continue");
                                Console.ReadLine();
                                continue;
                            case 3:
                                break;
                            default:
                                continue;
                        }
                    }
                    catch(Exception ex) 
                    {
                        continue;
                    }
                    break;
                }
                

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        //this method was obtained from a StackOverflow forum:
        //(https://stackoverflow.com/questions/2094239/swap-two-items-in-listt)
        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
        public static void DisplayVideoGameList(List<VideoGame> gameList)
        {
            //displays all records (including record number) to console
            int recordNum = 1;
            foreach (VideoGame game in gameList)
            {
                Console.WriteLine(recordNum + "\t" + game.ToString());
                recordNum++;
            }
        }
        public static void SortVideoGameList(List<VideoGame> gameList)
        {
            //selection sort
            int unsortedLength = gameList.Count;
            while (unsortedLength > 1)
            {
                int startingIndex = gameList.Count - unsortedLength;
                //for loop iterates to value of 'games.Count' due to
                //previous skipping of file's header record
                for (int i = startingIndex + 1; i < gameList.Count; i++)
                {
                    if (gameList.ElementAt(i).CompareTo(gameList.ElementAt(startingIndex)) < 0)
                    {
                        Swap(gameList, startingIndex, i);
                    }
                }
                unsortedLength--;
            }
        }
        public static void PublisherData(List<VideoGame> baseGameList, string publisher)
        {
            List<VideoGame> publisherGames = new List<VideoGame>();
            foreach (VideoGame game in baseGameList)
            {
                //toUpper() used as a precaution against case inconsistency
                if (game.GetPublisher().ToUpper() == publisher.ToUpper())
                {
                    publisherGames.Add(game);
                }
            }
            if (publisherGames.Count == 0)
            {
                Console.WriteLine("Publisher '" + publisher + "' not found.");
                return;
            }
            SortVideoGameList(publisherGames);
            DisplayVideoGameList(publisherGames);

            decimal publisherPercentage = Math.Round((decimal)publisherGames.Count / baseGameList.Count * 100, 2);
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine(publisherGames.Count + " out of " + baseGameList.Count + " games were developed by " +
                publisher + " (" + publisherPercentage + "%)\n");
        }
        public static void GenreData(List<VideoGame> baseGameList, string genre)
        {
            List<VideoGame> genreGames = new List<VideoGame>();
            foreach (VideoGame game in baseGameList)
            {
                //toUpper() used as a precaution against case inconsistency
                if (game.GetGenre().ToUpper() == genre.ToUpper())
                {
                    genreGames.Add(game);
                }
            }
            if (genreGames.Count == 0)
            {
                Console.WriteLine("Genre '" + genre + "' not found.");
                return;
            }
            SortVideoGameList(genreGames);
            DisplayVideoGameList(genreGames);

            decimal publisherPercentage = Math.Round((decimal)genreGames.Count / baseGameList.Count * 100, 2);
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine(genreGames.Count + " out of " + baseGameList.Count + " games are '" +
                genre + "' games (" + publisherPercentage + "%)\n");
        }
    }
}