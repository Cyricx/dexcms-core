using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTCMS.Base.Enums;
using TTCMS.Base.Interfaces;
using TTCMS.Base.Models;

namespace DexCMS.Core.Server
{
    public static class Logger
    {
        private static ILogRepository repository;

        public static void InitializeRepository(ILogRepository repo)
        {
            repository = repo;
        }

        public async static Task<int> WriteLog(LogType logType, string message)
        {
            Log log = new Log
            {
                LogTime = DateTime.Now,
                LogType = logType,
                Message = message
            };

            return await repository.AddAsync(log);
        }
    }
}
