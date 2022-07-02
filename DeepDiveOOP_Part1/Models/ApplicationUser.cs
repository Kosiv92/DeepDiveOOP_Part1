using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveOOP_Part1
{
    abstract public class ApplicationUser
    {
        private readonly AccessRightments _userAccessRightments;

        public AccessRightments UserAccesRightments { get => _userAccessRightments; }

        public ApplicationUser(AccessRightments userAccessRightments)
        {
            _userAccessRightments = userAccessRightments;
        }

    }
}
