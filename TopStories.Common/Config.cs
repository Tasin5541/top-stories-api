using System;

namespace TopStories.Common
{
    public sealed class CommandsConnectionString
    {
        public string Value { get; }

        public CommandsConnectionString(string value)
        {
            Value = value;
        }
    }
}
