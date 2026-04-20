using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.DTOs.WebHook
{
    public class WebhookDTO
    {
        public string? Action { get; set; }
        public string? Type { get; set; }
        public string? Api_Version { get; set; }
        public WebhookData? Data { get; set; }
        public DateTime? Date_Created { get; set; }
        public long? Id { get; set; }
        public bool? Live_Mode { get; set; }
        public long? User_Id { get; set; }
    }

    public class WebhookData
    {
        public string? Id { get; set; }
    }
}
