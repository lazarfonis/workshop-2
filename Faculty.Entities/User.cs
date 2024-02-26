using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty.Entities;

public class User : IdentityUser<Guid>
{
    public string LastName { get; set; }
}
