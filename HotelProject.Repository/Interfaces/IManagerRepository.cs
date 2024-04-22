﻿using HotelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository.Interfaces
{
    public interface IManagerRepository : IRepositoryBase<Manager>, IFullyUpdatable<Manager>
    {

    }
}
