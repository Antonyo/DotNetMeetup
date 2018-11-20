using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetMeetup.Blazor.Shared.Services.Trace
{
    public interface ITraceService
    {
        void Log(string msg, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "", [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0);
    }
}
