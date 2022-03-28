using System;
using LMSGrupp3.Models.Entities;


namespace LMSGrupp3.Models.Entities
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}