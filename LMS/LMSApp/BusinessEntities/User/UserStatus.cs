﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public enum UserStatus
    {
        AutheticatedAdmin,
        AutheticatedUser,
        AutheticatedLeader,
        AutheticatedManger,
        NonAutheticatedUser
    }
}
