using ChatBot.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatBot.Controllers
{
    public partial class DatabaseController
    {
        [HttpPost]
        public IActionResult BackupDatabase([FromBody] DatabaseName name)
        {
            var result = _databaseService.Backup(name);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult RestoreDatabase([FromBody] DatabaseName name)
        {
            var result = _databaseService.Restore(name);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult ClearDatabase()
        {
            var result = _databaseService.Clear();
            return Ok(result);
        }
    }
}
