using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WTBackend.Activity.Dto;
using WTBackend.Activity.InterfaceActivity;
using WTBackend.Activity.Models;
using WTBackend.APIResponses;
using WTBackend.DbHelper;

namespace WTBackend.Activity.ActivityRepo
{
    public class ActivityRepository : IActivityRepo
    {
        private readonly KanbanDbContext _dbContext;
        private readonly IMapper _mapper;
        public ActivityRepository(KanbanDbContext kanbanDbContext, IMapper mapper) { 
            _dbContext = kanbanDbContext;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateActivityAsync(CreateActivityDTO activityModel)
        {
            try
            {
                if (string.IsNullOrEmpty(activityModel.ColumnTitle))
                {
                    // Wenn der ColumnTitle leer oder null ist => default "New"
                    activityModel.ColumnTitle = "New";
                }
                else
                {
                    // Gucken ob die Spalte existiert
                    var columnExists = await _dbContext.columns
                        .AnyAsync(c => c.Title == activityModel.ColumnTitle);

                    if (!columnExists)
                    {
                        // Wenn die Spalte nicht existiert
                        return ApiResponse.ErrorResponse("Coulumn does not exist");
                    }
                }

                //Mapping von CreateActivityModel -> ActivityModel für die Datenbank
                var activity = _mapper.Map<ActivityModel>(activityModel);

                await _dbContext.activities.AddAsync(activity);
                await _dbContext.SaveChangesAsync();
                return ApiResponse.SuccessResponse("Activity was created");

            }
            catch (DbUpdateException ex)
            {
                // Fehler bei Datenbankaktualisierungen
                return ApiResponse.ErrorResponse("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Allgemeine Fehlerbehandlung
                return ApiResponse.ErrorResponse("Unexpected error occured: " + ex.Message);
            }

        }
    }
}
