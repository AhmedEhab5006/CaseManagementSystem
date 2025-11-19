using Application.Dto_s.Commons;
using Application.Repositories;
using Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public record RevokeReAssignmentRequestCommand(
    Guid RequestId,
    string AssignerId,
    DeleteDto Delete
) : IRequest<DeleteAndUpdateValidatation>;

public class RevokeReAssignmentRequestHandler : IRequestHandler<RevokeReAssignmentRequestCommand, DeleteAndUpdateValidatation>
{
    private readonly IUnitOfWork _unitOfWork;

    public RevokeReAssignmentRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteAndUpdateValidatation> Handle(RevokeReAssignmentRequestCommand request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.CaseReAssignmentRequestRepository.GetByIdAsync(request.RequestId);

        if (entity is null)
            return DeleteAndUpdateValidatation.DoesnotExist;

        if (entity.AssignerId != request.AssignerId || entity.RequestStatus != CaseReAssignmentRequestStates.Pending)
            return DeleteAndUpdateValidatation.DoesnotExist;

        entity.isDeleted = true;
        entity.deletionReason = request.Delete.DeletionReason;
        entity.deletedAt = DateTime.UtcNow;
        entity.deletedBy = request.Delete.DeletedBy;

        _unitOfWork.CaseReAssignmentRequestRepository.Update(entity);

        var result = await _unitOfWork.SaveChangesAsync();

        return result > 0 ? DeleteAndUpdateValidatation.Done : DeleteAndUpdateValidatation.Error;
    }
}
