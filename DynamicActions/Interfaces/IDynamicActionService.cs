using DynamicActions.ViewModels;

namespace DynamicActions.Interfaces
{
    public interface IDynamicActionService
    {
        Task<DynamicActionLogicModel> Add(DynamicActionCreateLogicModel model);

        Task<DynamicActionCalculateResultLogicModel> Calculate(DynamicActionCalculateLogicModel model);

        Task<List<DynamicActionLogicModel>> GetAvailableActions();

        Task<List<DynamicActionHistoryLogicModel>> History(int dynamicActionId);
    }
}
