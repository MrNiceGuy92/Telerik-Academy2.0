namespace CSharpFormatting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;

    public class EventHolder
    {
        private MultiDictionary<string, Event> comparedByTitleMultiDictionary = new MultiDictionary<string, Event>(true);
        private OrderedBag<Event> comparedByDateOrderedBag = new OrderedBag<Event>();

        public void AddEvent(
                             DateTime date,
                             string title,
                             string location)
        {
            Event newEvent = new Event(date, title, location);
            this.comparedByTitleMultiDictionary.Add(title.ToLower(), newEvent);
            this.comparedByDateOrderedBag.Add(newEvent);
            EventExecuter.Messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string title = titleToDelete.ToLower();
            int removed = 0;

            foreach (var eventToRemove in this.comparedByTitleMultiDictionary[title])
            {
                removed++;
                this.comparedByDateOrderedBag.Remove(eventToRemove);
            }

            this.comparedByTitleMultiDictionary.Remove(title);
            EventExecuter.Messages.EventDeleted(removed);
        }

        public void ListEvents(DateTime date, int count)
        {
            OrderedBag<Event>.View eventsToShow = this.comparedByDateOrderedBag.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            int showed = 0;

            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                Messages.PrintEvent(eventToShow);
                showed++;
            }

            if (showed == 0)
            {
                EventExecuter.Messages.NoEventsFound();
            }
        }
    }
}