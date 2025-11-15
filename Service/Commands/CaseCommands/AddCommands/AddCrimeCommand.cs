using Application.Dto_s.CaseDtos;
using Domain.Enums;
using MediatR;

namespace Application.Features.Case.Commands.AddCrimeToLitigant
{
    public class AddCrimeCommand : IRequest<AddCrimeValidations>
    {
        public CrimeAddDto CrimeAdd { get; set; }

        public AddCrimeCommand(CrimeAddDto crimeAdd)
        {
            CrimeAdd = crimeAdd;
        }
    }
}
