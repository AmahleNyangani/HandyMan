using HandyMan.Data.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandyMan.Models.Settings
{
    [Table("Settings")]
    public class Settings : BasePrimaryKey
    {
        public string key { get; set; }

        public string value { get; set; }

        public string description { get; set; }

        public bool isActive { get; set; }
    }
}
