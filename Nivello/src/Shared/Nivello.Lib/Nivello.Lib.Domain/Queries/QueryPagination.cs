namespace Nivello.Lib.Nivello.Lib.Domain.Queries
{
    public abstract class QueryPagination : Query
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
