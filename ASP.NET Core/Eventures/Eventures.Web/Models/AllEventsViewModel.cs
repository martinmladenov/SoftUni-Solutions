namespace Eventures.Web.Models
{
    using System.Collections.Generic;

    public class AllEventsViewModel
    {
        public IEnumerable<EventListingViewModel> Events { get; set; }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }
    }
}