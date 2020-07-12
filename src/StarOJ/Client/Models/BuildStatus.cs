﻿using System;
using System.Linq;

namespace StarOJ.Client.Models
{
    public class BuildStatus
    {
        private string _commit = "";
        private string _branch = "";

        public BuildStatus()
        {
            Commit = "";
            Branch = "";
        }

        public string Commit
        {
            get => _commit; set
            {
                _commit = value;
                if (string.IsNullOrWhiteSpace(value))
                {
                    TrimedCommit = "None";
                }
                else
                {
                    value = value.Trim();
                    TrimedCommit = value.Substring(0, Math.Min(7, value.Length));
                }
            }
        }

        public string Branch
        {
            get => _branch; set
            {
                _branch = value;
                if (string.IsNullOrWhiteSpace(value))
                {
                    TrimedBranch = "None";
                }
                else
                {
                    value = value.Trim();
                    TrimedBranch = value.Split('/').LastOrDefault();
                    if (string.IsNullOrEmpty(TrimedBranch))
                        TrimedBranch = "None";
                }
            }
        }

        public string BuildDate { get; set; } = "None";

        public string Repository { get; set; } = "StardustDL/StarOJ";

        public string Version { get; set; } = "1.0.0";

        public string TrimedCommit { get; private set; }

        public string TrimedBranch { get; private set; }
    }
}
