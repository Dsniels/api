﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class MateriaSpecificationParams
    {
        public int? Profesor {  get; set; }
        public int? Carrera { get; set; }
        public int Sort { get; set; }
        public int PageIndex { get; set; } = 1;

        private const int MaxPageSize = 50;

        private int _pageSize = 3;
        public int PageSize
        {
            get => _pageSize; set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string Search {  get ; set; }

    }
}
