﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04PC_BlogStore.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entity);

        void Delete(int id);

        void Update(T entity);

        List<T> GetList();

        T GetById(int id);
    }
}
