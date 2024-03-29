﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialSwap.Domain.AggregatesModel
{
    public interface ICrudService<T> where T : class
    {
        public T Create(T entity);

        public T Delete(T entity);

        public T Get(string id);

        public IEnumerable<T> Index(string? selfid);

        public T Update(T entity);
    }
}
