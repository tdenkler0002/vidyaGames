using System;
namespace SweeneyVidyaGames.Api.Resources
{
    public sealed class ConnectionString
    {
        public ConnectionString(string value) => Value = value;
        public string Value { get; }
    }
}
