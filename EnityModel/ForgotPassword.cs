using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnityModel
{
    public class ForgotPassword : BaseEntity
    {
        public String Email { set; get; }
        public String OTP { set; get; }
    }
}
