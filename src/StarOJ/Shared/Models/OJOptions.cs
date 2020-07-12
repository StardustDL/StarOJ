﻿using System;
using System.Text;

namespace StarOJ.Models
{
    public class OJOptions
    {
        public string Name { get; set; } = "StarOJ";

        public string Description { get; set; } = "";

        public int StartYear { get; set; } = 2020;

        public string Onwer { get; set; } = "StardustDL";

        public string Icon { get; set; } = "icon.png";

        public string Cover { get; set; } = "";

        public string Header { get; set; } = "";

        public string Footer { get; set; } = "";

        public PropertyCollection Properties { get; set; } = new PropertyCollection();
    }
}
