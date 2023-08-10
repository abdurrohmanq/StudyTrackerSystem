using AutoMapper;
using StudyTrackerSystem.Data.IRepositories.Common;
using StudyTrackerSystem.Data.Repositories.Common;
using StudyTrackerSystem.Domain.Entities.Groups;
using StudyTrackerSystem.Service.DTOs.Groups;
using StudyTrackerSystem.Service.Helpers;
using StudyTrackerSystem.Service.Interfaces;
using StudyTrackerSystem.Service.Mapping;

namespace StudyTrackerSystem.Service.Services;

public class GroupService : IGroupService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GroupService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>()));
    }
    public async Task<Response<GroupResultDto>> CreateAsync(GroupCreationDto dto)
    {

        var mappedGroup = mapper.Map<Group>(dto);

        await unitOfWork.GroupRepository.CreateAsync(mappedGroup);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<GroupResultDto>(mappedGroup);

        return new Response<GroupResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var group = await unitOfWork.GroupRepository.GetByIdAsync(id);
        if (group is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = false
            };

        unitOfWork.GroupRepository.Delete(group);
        await unitOfWork.SaveChanges();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<IEnumerable<GroupResultDto>>> GetAllAsync()
    {
        var groups = unitOfWork.GroupRepository.GetAll();
        var result = new List<GroupResultDto>();

        foreach (var group in groups)
        {
            var map = mapper.Map<GroupResultDto>(group);
            result.Add(map);
        }

        return new Response<IEnumerable<GroupResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<GroupResultDto>> GetAsync(long id)
    {
        var group = await unitOfWork.GroupRepository.GetByIdAsync(id);
        if (group is null)
            return new Response<GroupResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var result = mapper.Map<GroupResultDto>(group);

        return new Response<GroupResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<GroupResultDto>> UpdateAsync(GroupUpdateDto dto)
    {
        var group = await unitOfWork.GroupRepository.GetByIdAsync(dto.Id);
        if (group is null)
            return new Response<GroupResultDto>()
            {
                StatusCode = 404,
                Message = "Not Found",
                Data = null
            };

        var mappedGroup = mapper.Map(dto, group);

        unitOfWork.GroupRepository.Update(mappedGroup);
        await unitOfWork.SaveChanges();

        var result = mapper.Map<GroupResultDto>(mappedGroup);

        return new Response<GroupResultDto>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
