using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Data.Objects.Enums
{
    public enum PaymentMode
    {
        [Display(Name = "Cashs")]
        Cash, 
        Cheque, 
        POS, 
        Others
    }
}
