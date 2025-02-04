using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WTBackend.APIResponses;
using WTBackend.Column.Dto;
using WTBackend.Column.Interface;
using WTBackend.Column.Models;
using WTBackend.DbHelper;

namespace WTBackend.Column.Repository
{
    public class ColumnRepository : IColumnRepo
    {
        private readonly KanbanDbContext _dbContext;
        private readonly IMapper _mapper;
        public ColumnRepository(KanbanDbContext kanbanDbContext, IMapper mapper) {
        _mapper = mapper;
        _dbContext = kanbanDbContext;
        }

        #region GetColumns
        public async Task<List<ResponseColumnDTO>> GetAllColumns()
        {
            var columns = await _dbContext.columns
                    .Include(c => c.Activity) // Die Aktivitäten werden mitgeladen
                    .ToListAsync();

            var columnDtos = _mapper.Map<List<ResponseColumnDTO>>(columns);

            return columnDtos;

        }
        #endregion

        #region CreateColumn
        public async Task<ApiResponse> CreateColumn(CreateColumnDTO createColumnDTO)
        {
            try
            {
                if (string.IsNullOrEmpty(createColumnDTO.Title))
                {
                    return ApiResponse.ErrorResponse("Columntitle can not be Empty");
                }

                var columnExists = await _dbContext.columns
                        .AnyAsync(c => c.Title == createColumnDTO.Title);

                if (columnExists)
                {
                    return ApiResponse.ErrorResponse("Coulumn Already exists");
                }

                var column = _mapper.Map<ColumnModel>(createColumnDTO);

                await _dbContext.columns.AddAsync(column);
                await _dbContext.SaveChangesAsync();
                return ApiResponse.SuccessResponse($"Column '{column.Title}' created.");



            }
            catch (DbUpdateException ex)
            {
                return ApiResponse.ErrorResponse("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                return ApiResponse.ErrorResponse("Unexpected error occured: " + ex.Message);
            }
        }
        #endregion

        #region DeleteColumn
        public async Task<ApiResponse> DeleteColumn(string title)
        {
            try
            {
                
                var column = await _dbContext.columns.FirstOrDefaultAsync(c => c.Title == title);

                if (column == null)
                {
                    return ApiResponse.ErrorResponse($"Column '{title}' does not exist.");
                }

                _dbContext.columns.Remove(column);
                await _dbContext.SaveChangesAsync();

                return ApiResponse.SuccessResponse($"Column '{title}' was deleted."); 
            }
            catch (DbUpdateException ex)
            {
                return ApiResponse.ErrorResponse("Error while updating the database.", ex);
            }
            catch (Exception ex)
            {
                return ApiResponse.ErrorResponse("An unexpected error occurred.", ex);
            }
        }
        #endregion

    }
}

