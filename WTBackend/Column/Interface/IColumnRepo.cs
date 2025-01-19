using WTBackend.Column.Dto;
using WTBackend.Column.Models;

namespace WTBackend.Column.Interface
{
    public interface IColumnRepo
    {
        Task<List<ColumnDTO>> GetAllColumns();
    }
}
