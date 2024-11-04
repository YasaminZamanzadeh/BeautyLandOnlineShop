using System;
using System.Collections.Generic;
using System.Linq;

namespace BeautyLand.Application.Services.Dtos.PaginationDto
{
    public class PaginationDto<TValue> where TValue : class
    {

        public PaginationDto(int pageIndex, int pageSize, int rowCount, IEnumerable<TValue> model)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            RowCount = rowCount;
            Model = model;
            Page = new Pager(rowCount, pageIndex, pageSize);
        }

        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int RowCount { get; private set; }
        public IEnumerable<TValue> Model { get; private set; }
        public Pager Page { get; private set; } // Made private setter for consistency
        public bool HasPreviousPage => (PageIndex > 1);
        public bool HasNextPage => (PageIndex < Page.TotalPages);

        public class Pager
        {
            public Pager() { } // Parameterless constructor for deserialization

            public Pager(long totalItems, int currentPage = 1, int pageSize = 10, int maxPages = 5)
            {
                var totalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);

                // Ensure current page isn't out of range
                if (currentPage < 1)
                {
                    currentPage = 1;
                }
                else if (currentPage > totalPages)
                {
                    currentPage = totalPages;
                }

                // Calculate start and end pages
                int startPage, endPage;
                if (totalPages <= maxPages)
                {
                    startPage = 1;
                    endPage = totalPages;
                }
                else
                {
                    int maxPagesBeforeCurrentPage = maxPages / 2;
                    int maxPagesAfterCurrentPage = (maxPages + 1) / 2 - 1;

                    if (currentPage <= maxPagesBeforeCurrentPage + 1)
                    {
                        startPage = 1;
                        endPage = maxPages;
                    }
                    else if (currentPage + maxPagesAfterCurrentPage >= totalPages)
                    {
                        startPage = totalPages - maxPages + 1;
                        endPage = totalPages;
                    }
                    else
                    {
                        startPage = currentPage - maxPagesBeforeCurrentPage;
                        endPage = currentPage + maxPagesAfterCurrentPage;
                    }
                }

                // Calculate pages
                Pages = Enumerable.Range(startPage, (endPage + 1) - startPage).ToArray();
                TotalPages = totalPages;
            }

            public IEnumerable<int> Pages { get; private set; }
            public int TotalPages { get; private set; }
        }
    }
}