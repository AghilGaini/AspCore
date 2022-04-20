﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Interfaces
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        ICityRepository _cityRepository { get; }
        IPermisionRepository _permisionRepository { get; }
        void Complete();
    }
}
