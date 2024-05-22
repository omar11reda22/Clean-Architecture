using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Data
{
    public class RegistrationDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string E_Mail { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

    }
}
