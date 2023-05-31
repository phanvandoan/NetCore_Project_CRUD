namespace NetCore_Project.DTO.PagedResult
{
    public class PagedResultDto<T>
    {
        //public int PageIndex { get; set; }
        //public int PageSize { get; set; }
        //public int TotalCount { get; set; }
        //public List<T> Items { get; set; }

        //public PagedResultDto(int pageIndex, int pageSize, int totalCount, List<T> items)
        //{
        //    PageIndex = pageIndex;
        //    PageSize = pageSize;
        //    TotalCount = totalCount;
        //    Items = items;
        //}
        /// <summary>
        /// Số page
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// số bản ghi trong 1 page
        /// </summary>
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }

        public PagedResultDto(int pageIndex, int pageSize, int totalCount, List<T> items)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            Items = items;
        }
    }
}
