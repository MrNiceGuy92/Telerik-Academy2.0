namespace CSharpFormatting
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date { get; set; }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (value.Length < 10)
                {
                    throw new ArgumentException("Invalid length of title.");
                }

                this.title = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Location cannot be null.");
                }

                this.location = value;
            }
        }

        public int CompareTo(object inputObject)
        {
            Event otherDate = inputObject as Event;

            int compareByDate = this.date.CompareTo(otherDate.date);
            int compareByTitle = this.title.CompareTo(otherDate.title);
            int compareByLocation = this.location.CompareTo(otherDate.location);

            if (compareByDate == 0 && compareByTitle != 0)
            {
                return compareByLocation;
            }
            else if (compareByDate == 0 && compareByTitle == 0)
            {
                return compareByTitle;
            }
            else
            {
                return compareByDate;
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();

            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.title);

            if (this.location != null && this.location != string.Empty)
            {
                toString.Append(" | " + this.location);
            }

            return toString.ToString();
        }
    }
}