using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WTBackend.Column.Dto;
using WTBackend.Column.Interface;
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
        public async Task<List<ColumnDTO>> GetAllColumns()
        {
            var columns = await _dbContext.columns
                    .Include(c => c.Activity) // Die Aktivitäten werden mitgeladen
                    .ToListAsync();

            var columnDtos = _mapper.Map<List<ColumnDTO>>(columns);

            return columnDtos;

        }
    }
}
