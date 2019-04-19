using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeus.Common.Logging
{
    public interface ILogService
    {
        void Debug(string message);
        void Debug(string message, object owner);

        void Info(string message);
        void Info(string message, object owner);

        void Warn(string message);
        void Warn(string message, object owner);

        void Error(string message);
        void Error(string message, object owner);
        void Error(string message, Exception exception);
        void Error(string message, Exception exception, object owner);

        void Fatal(string message);
        void Fatal(string message, object owner);
    }
}
