using TopStories.Common;
using System;

namespace TopStories.Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;

        public int CurrentYear => DateTime.UtcNow.Year;
    }
}
