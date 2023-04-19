using HelpURL.Application.ViewModel;

namespace HelpURL.Application.Interfaces
{
   public interface IURLService
    {
        Task<List<ResponseUrlViewModel>> GetAll();
        Task<ResponseUrlViewModel> Create(RequestUrlViewModel viewModel);
        Task<ResponseUrlViewModel> Edit(Guid id, RequestUrlViewModel viewModel);
        Task<bool> Delete(Guid id);
    }
}
