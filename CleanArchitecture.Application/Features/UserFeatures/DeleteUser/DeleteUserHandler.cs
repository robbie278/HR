using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.UserFeatures.DeleteUser
{
    public class DeleteUserHandler: IRequestHandler<DeleteUserRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public DeleteUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserRequest request,CancellationToken cancellationToken)
        {
            var user = await _userRepository.Get(request.id, cancellationToken);
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            
            _userRepository.Delete(user);
            await _unitOfWork.Save(cancellationToken).ConfigureAwait(false); 
            
            return Unit.Value;
        }
    }
}
