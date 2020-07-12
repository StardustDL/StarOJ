using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StarOJ.Server.Pages
{
    public class HostModel : PageModel
    {
        public HostModel()
        {
        }

        public string Title { get; private set; } = "StarOJ";
    }
}