using DexCMS.Core.Enums;
using DexCMS.Core.Interfaces;
using DexCMS.Core.Models;
using System;
using System.Threading.Tasks;

namespace DexCMS.Core
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
