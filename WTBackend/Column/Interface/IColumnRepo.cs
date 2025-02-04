using WTBackend.APIResponses;
using WTBackend.Column.Dto;
using WTBackend.Column.Models;

namespace WTBackend.Column.Interface
{
    public interface IColumnRepo
    {
        Task<List<ResponseColumnDTO>> GetAllColumns();

        Task<ApiResponse> DeleteColumn(string Title);

        Task<ApiResponse> CreateColumn(CreateColumnDTO columnDTO);
    }
}
