using System;

namespace EntityLibary
{
    public class Record
    {
        public Record(int id, string title, string artist, int duration, int year)
        {
            Id = id;
            Title = title;
            Artist = artist;
            Duration = duration;
            Year = year;
        }
        public Record()
        {

        }

        public int Id { get; init; }
        public string Title { get; init; }

        public string Artist { get; init; }
        public int Duration { get; init; }
        public int Year { get; set; }

    }
}
