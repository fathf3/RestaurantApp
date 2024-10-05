﻿using RestaurantApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BusinessLayer.Abstracts
{
    public interface IMenuTableService : IGenericService<MenuTable>
    {
        int TMenuTableCount();
        void TChangeMenuTableStatusToTrue(int id);
        void TChangeMenuTableStatusToFalse(int id);
    }
}