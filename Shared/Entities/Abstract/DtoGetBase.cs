using System;
namespace Shared.Entities.Abstract
{
    public class DtoGetBase
    {
        public virtual int CurrentPage { get; set; } = 1;
        public virtual int PageSize { get; set; } = 20;
        public virtual int TotalCount { get; set; }
        public virtual int TotalPage => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize));
        public virtual bool ShowPrevious => CurrentPage > 1;
        public virtual bool ShowNext => CurrentPage > TotalPage;
        public virtual bool IsAscending { get; set; } = false;
    }
}

