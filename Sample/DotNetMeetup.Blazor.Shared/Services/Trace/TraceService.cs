using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DotNetMeetup.Blazor.Shared.Services.Trace
{
    public class TraceService : ITraceService
    {
        private const int DEFAULT_MAX_LINES = 1000;

        int _maxLines;
        IList<string> _stackLines = new List<string>();

        public TraceService()
        {
            _maxLines = DEFAULT_MAX_LINES;
        }

        public TraceService(int maxLines)
        {
            _maxLines = maxLines;
        }

        public void Log(string msg, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "", [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            try
            {
                if (_stackLines.Count == _maxLines)
                    _stackLines.RemoveAt(0);

                _stackLines.Add($"{memberName} ({sourceLineNumber}) : {msg}");
            }
            catch { }
        }

        public void Clear()
        {
            _stackLines.Clear();
        }

        public string Print()
        {
            return String.Join(Environment.NewLine, _stackLines);
        }
    }
}
