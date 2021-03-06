﻿using StarOJ.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StarOJ.Sdk
{
    public interface IOJService
    {
        IJudgerService JudgerService { get; }

        Task<OJOptions> GetOptions(CancellationToken cancellationToken = default);
    }
}
