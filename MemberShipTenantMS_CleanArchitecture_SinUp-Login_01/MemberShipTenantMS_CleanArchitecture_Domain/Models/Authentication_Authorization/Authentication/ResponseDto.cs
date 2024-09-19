using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipTenantMS_CleanArchitecture_Application.DTO_s.Authentication
{
    public class ResponseDto
    {
        public string? Status { get; set; }
        public string? Message { get; set; }
        public string? Token { get; set; }
        public DateTime Expiration { get; set;}
    }
}
