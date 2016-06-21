using DexCMS.Core.Infrastructure.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DexCMS.Core.Infrastructure.Models
{
    public class Log
    {
        [Key]
        public int LogID { get; set; }

        public DateTime LogTime { get; set; }

        public LogType LogType { get; set; }

        public string Message { get; set; }
    }
}
