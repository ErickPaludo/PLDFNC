﻿namespace WebApiFinanc.Pagination
{
    public class QueryStringParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 1;
        public int PageSize { get { return _pageSize; } set { _pageSize = (value > maxPageSize) ? maxPageSize : value; } }
    }
}
