using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetMeetup.Blazor.Server
{
    public static class Globals
    {
        public static readonly string LogFile = Guid.NewGuid().ToString();
        public static readonly string DBName = Guid.NewGuid().ToString();
    }
}
