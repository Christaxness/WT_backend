using WTBackend.Activity.Dto;
using WTBackend.APIResponses;

namespace WTBackend.Activity.InterfaceActivity
{
    public interface IActivityRepo
    {
        Task<ApiResponse> CreateActivityAsync(CreateActivityDTO activityModel);
    }
}
