using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnityModel
{
    public class RefreshToken : BaseEntity
    {
        public string RefreshTokensId { get; set; }
        public string Subject { get; set; }
        public string ClientId { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string ProtectedTicket { get; set; }


    }
}
