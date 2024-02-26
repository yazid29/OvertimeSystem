using API.DTOs.AccountRoles;
using API.DTOs.Accounts;
using API.DTOs.Employees;
using API.DTOs.Overtimes;
using API.DTOs.OvertimeRequests;
using API.DTOs.Roles;
using API.Models;
using AutoMapper;

namespace API.DTOs
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            // Account
            CreateMap<AccountRequestDto, Account>()
                .ForMember(dest => dest.Otp, opt => opt.MapFrom(src => 0))
                .ForMember(dest => dest.Expired, opt => opt.MapFrom(src => new DateTime()))
                .ForMember(dest => dest.IsUsed, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

            CreateMap<Account, AccountResponseDto>();
            // Account Role
            CreateMap<AccountRoleRequestDto, AccountRole>();
            CreateMap<AccountRole, AccountRoleResponseDto>();
            // Employee
            CreateMap<EmployeeRequestDto, Employee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.JoinedDate, opt => opt.MapFrom(src => new DateTime()));

            CreateMap<Employee, EmployeeResponseDto>();
            // Overtime
            CreateMap<OvertimeRequestDto, Overtime>();
            CreateMap<Overtime, OvertimeResponseDto>();
            // Overtime Request
            CreateMap<OvertimeReqRequestDto, OvertimeRequest>()
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => new DateTime()));
            CreateMap<OvertimeRequest, OvertimeReqResponseDto>();
            // Role
            CreateMap<RoleRequestDto, Role>();
            CreateMap<Role, RoleResponseDto>();
        }
    }
}
