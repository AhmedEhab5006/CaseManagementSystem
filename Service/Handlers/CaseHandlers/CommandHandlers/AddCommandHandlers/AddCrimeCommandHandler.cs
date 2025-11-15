using Application.Dto_s.CaseDtos;
using Application.Features.Case.Commands.AddCrimeToLitigant;
using Application.Repositories;
using Application.Repositories.CaseRepositories;
using Application.UseCases;
using Domain.Enums;
using MediatR;

namespace Application.Features.Case.Commands.AddCrimeToLitigant
{
    public class AddCrimeCommandHandler : IRequestHandler<AddCrimeCommand, AddCrimeValidations>
    {
        private readonly ICaseService _caseService;

        public AddCrimeCommandHandler(ICaseService caseService)
        {
            _caseService = caseService;
        }

        public async Task<AddCrimeValidations> Handle(AddCrimeCommand request, CancellationToken cancellationToken)
        {
            return await _caseService.AddCrimeToLitigantAsync(request.CrimeAdd);
        }
    }
}
