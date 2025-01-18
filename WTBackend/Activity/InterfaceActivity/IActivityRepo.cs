using WTBackend.Activity.Models;

namespace WTBackend.Activity.InterfaceActivity
{
    public interface IActivityRepo
    {
        Task<List<ActivityModel>> GetAllActivities();
    }
}
