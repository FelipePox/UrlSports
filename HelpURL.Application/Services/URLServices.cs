using AutoMapper;
using HelpURL.Application.Interfaces;
using HelpURL.Application.ViewModel;
using HelpURL.Domain.Entities;
using HelpURL.Domain.Interfaces;
using HelpURL.Domain.ValueObjects;
using HelpURL.Infra.Data.Transactions;

namespace HelpURL.Application.Services;

public sealed class URLServices : IURLService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IURLRepository _urlRepository;

    public URLServices(IMapper mapper, IUnitOfWork unitOfWork, IURLRepository urlRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _urlRepository = urlRepository;
    }

    public async Task<ResponseUrlViewModel> Create(RequestUrlViewModel viewModel)
    {
        var url = new URL(
            new URLTexto(viewModel.URLTexto),
            new Descricao(viewModel.Descricao));

        if (!url.IsValid)
            throw new Exception("Os dados inseridos estão inválidos.");

        var urlResponse = await _urlRepository.Insert(url);
        if (await _unitOfWork.SaveChangesAsync() <= 0)
            throw new Exception("Erro ao salvar a URL.");

        return _mapper.Map<ResponseUrlViewModel>(urlResponse);

    }

    public async Task<bool> Delete(Guid id)
    {
        var urlExistente = await _urlRepository.GetOneWhere(r => r.Id == id);

        if (urlExistente is null)
            throw new Exception("url inexistente.");

        await _urlRepository.Delete(urlExistente);


        if (await _unitOfWork.SaveChangesAsync() <= 0)
            throw new Exception("Erro ao salvar as alterações.");

        return true;

    }

    public async Task<ResponseUrlViewModel> Edit(Guid id, RequestUrlViewModel viewModel)
    {
        var urlExistente = await _urlRepository.GetOneWhere(r => r.Id == id);
        if (urlExistente is null)
            throw new Exception("url inexistente.");

        urlExistente.Update(new URLTexto(viewModel.URLTexto), new Descricao(viewModel.Descricao));

        if (!urlExistente.IsValid)
            throw new Exception("Os dados inseridos estão inválidos.");

        var urlResponse = await _urlRepository.Update(urlExistente);

        if (await _unitOfWork.SaveChangesAsync() <= 0)
            throw new Exception("Erro ao salvar as alterações.");

        return _mapper.Map<ResponseUrlViewModel>(urlResponse);
    }

    public async Task<List<ResponseUrlViewModel>> GetAll()
     => _mapper.Map<List<ResponseUrlViewModel>>
        (await _urlRepository.GetAll());
}
