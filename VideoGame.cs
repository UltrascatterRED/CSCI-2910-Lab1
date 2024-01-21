using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bartonn_csci2910_lab1
{
    internal class VideoGame : IComparable
    {
        private string Name;
        private string Platform;
        private int Year;
        private string Genre;
        private string Publisher;
        private decimal NA_Sales;
        private decimal EU_Sales;
        private decimal JP_Sales;
        private decimal Other_Sales;
        private decimal Global_Sales;

        //basic parameterized constructor
        public VideoGame
            (
                string name, string platform, int year, string genre, string publisher, decimal na_Sales, 
                decimal eu_Sales, decimal jp_Sales, decimal other_Sales, decimal global_Sales
            )
        {
            SetName(name);
            SetPlatform(platform);
            SetYear(year);
            SetGenre(genre);
            SetPublisher(publisher);
            SetNA_Sales(na_Sales);
            SetEU_Sales(eu_Sales);
            SetJP_Sales(jp_Sales);
            SetOther_Sales(other_Sales);
            SetGlobal_Sales(global_Sales);
        }

        //getters
        public string GetName() { return Name; }
        public string GetPlatform() { return Platform; }
        public int GetYear() { return Year; }
        public string GetGenre() { return Genre; }
        public string GetPublisher() { return Publisher; }
        public decimal GetNA_Sales() { return NA_Sales; }
        public decimal GetEU_Sales() { return EU_Sales; }
        public decimal GetJP_Sales() { return JP_Sales; }
        public decimal GetOther_Sales() { return Other_Sales; }
        public decimal GetGlobal_Sales() { return Global_Sales; }

        //setters
        private void SetName( string name ) { Name = name; }
        private void SetPlatform( string platform ) { Platform = platform; }
        private void SetYear( int year ) { Year = year; }
        private void SetGenre(string genre) { Genre = genre; }
        private void SetPublisher(string publisher) { Publisher = publisher; }
        private void SetNA_Sales(decimal na_sales) { NA_Sales = na_sales; }
        private void SetEU_Sales(decimal eu_sales) { EU_Sales = eu_sales; }
        private void SetJP_Sales(decimal jp_sales) { JP_Sales = jp_sales; }
        private void SetOther_Sales(decimal other_sales) { Other_Sales = other_sales; }
        private void SetGlobal_Sales(decimal global_sales) { Global_Sales = global_sales; }

        //methods
        public int CompareTo(object? obj)
        {
            //base code for this method obtained from the Microsoft C# IComparable page
            //(https://learn.microsoft.com/en-us/dotnet/api/system.icomparable?view=net-8.0)

            if (obj == null) return 1;

            VideoGame otherGame = obj as VideoGame;
            if (otherGame != null)
                return this.Name.CompareTo(otherGame.Name);
            else
                throw new ArgumentException("Object is not of type 'VideoGame'.");
        }
        public override string ToString()
        {
            return 
                Name + " | " + 
                Platform + " | " + 
                Year + " | " + 
                Genre + " | " +
                Publisher + " | " +
                NA_Sales + " | " +
                EU_Sales + " | " +
                JP_Sales + " | " +
                Other_Sales + " | " +
                Global_Sales + "\n";
        }
    }
}
