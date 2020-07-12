using System.Collections.Generic;

namespace StarOJ.Models
{
    public class PropertyCollection
    {
        public Dictionary<string, string> Raw { get; set; } = new Dictionary<string, string>();

        public string this[string key, string defaultValue = ""]
        {
            get
            {
                return Raw.TryGetValue(key, out var res) ? res : defaultValue;
            }
            set
            {
                Raw[key] = value;
            }
        }
    }
}
