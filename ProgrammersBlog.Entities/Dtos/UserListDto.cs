﻿using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities;
using System.Collections.Generic;

namespace ProgrammersBlog.Entities.Dtos
{
    public class UserListDto : DtoGetBase
    {
        public IList<User> Users { get; set; }
    }
}
