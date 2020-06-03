using System;
using System.Collections.Generic;


namespace DTOModel
{
    public class ForgotPasswordDto
    {
        public Guid Id { set; get; }
        public String Email { set; get; }
        public String OTP { set; get; }
        public bool IsActive { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime LastModifiedDate { set; get; }
    }
}
