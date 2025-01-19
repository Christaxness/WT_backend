using WTBackend.Activity.Dto;
using WTBackend.Activity.Models;
using WTBackend.APIResponses;

namespace WTBackend.Activity.InterfaceActivity
{
    public interface IActivityRepo
    {
        Task<ApiResponse> CreateActivityAsync(CreateActivityDTO activityModel);
    }
}
