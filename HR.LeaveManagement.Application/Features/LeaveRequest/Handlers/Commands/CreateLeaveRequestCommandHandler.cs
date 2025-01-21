using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Application.Responses;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Commands;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IEmailSender _emailSender;

    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _emailSender = emailSender;
    }

    public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request,
        CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Request is invalid";
            response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        }

        var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request.CreateLeaveRequestDto);
        leaveRequest = await _leaveRequestRepository.AddAsync(leaveRequest);

        response.Message = "Leave Request Created";
        response.Id = leaveRequest.Id;
        
        _ = Task.Run(async () =>
        {
            try
            {
                await _emailSender.SendEmailAsync(new Email
                {
                    To = "recipient@example.com",
                    Subject = "Leave Request Submitted",
                    Body =
                        $"Your leave request for {request.CreateLeaveRequestDto.StartDate:D} to {request.CreateLeaveRequestDto.EndDate:D} has been submitted."
                });

                // Log success (use a logger here)
                // _logger.LogInformation("Email sent successfully to {To}.", "recipient@example.com");
            }
            catch (Exception ex)
            {
                // Log failure (use a logger here)
                // _logger.LogError(ex, "Failed to send email to {To}.", "recipient@example.com");
            }
        });
        return response;
    }
}