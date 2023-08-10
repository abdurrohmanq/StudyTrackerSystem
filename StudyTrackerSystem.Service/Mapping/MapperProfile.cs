using AutoMapper;
using StudyTrackerSystem.Domain.Entities.Groups;
using StudyTrackerSystem.Domain.Entities.Payments;
using StudyTrackerSystem.Domain.Entities.Reminders;
using StudyTrackerSystem.Domain.Entities.Students;
using StudyTrackerSystem.Domain.Entities.StudyResults;
using StudyTrackerSystem.Domain.Entities.Subjects;
using StudyTrackerSystem.Domain.Entities.Teachers;
using StudyTrackerSystem.Domain.Entities.TextBooks;
using StudyTrackerSystem.Service.DTOs.Groups;
using StudyTrackerSystem.Service.DTOs.Payments;
using StudyTrackerSystem.Service.DTOs.Reminders;
using StudyTrackerSystem.Service.DTOs.Students;
using StudyTrackerSystem.Service.DTOs.StudyResults;
using StudyTrackerSystem.Service.DTOs.Subjects;
using StudyTrackerSystem.Service.DTOs.Teachers;
using StudyTrackerSystem.Service.DTOs.Textbooks;

namespace StudyTrackerSystem.Service.Mapping;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Student, StudentResultDto>().ReverseMap();
        CreateMap<StudentCreationDto, Student>().ReverseMap();
        CreateMap<StudentUpdateDto, Student>().ReverseMap();

        CreateMap<Teacher, TeacherResultDto>().ReverseMap();
        CreateMap<TeacherCreationDto, Teacher>().ReverseMap();
        CreateMap<TeacherUpdateDto, Teacher>().ReverseMap();

        CreateMap<Group, GroupResultDto>().ReverseMap();
        CreateMap<GroupCreationDto, Group>().ReverseMap();
        CreateMap<GroupUpdateDto, Group>().ReverseMap();

        CreateMap<Payment, PaymentResultDto>().ReverseMap();
        CreateMap<PaymentCreationDto, Payment>().ReverseMap();
        CreateMap<PaymentUpdateDto, Payment>().ReverseMap();

        CreateMap<Subject, SubjectResultDto>().ReverseMap();
        CreateMap<SubjectCreationDto, Subject>().ReverseMap();
        CreateMap<SubjectUpdateDto, Subject>().ReverseMap();

        CreateMap<TextBook, TextBookResultDto>().ReverseMap();
        CreateMap<TextBookCreationDto, TextBook>().ReverseMap();
        CreateMap<TextBookUpdateDto, TextBook>().ReverseMap();

        CreateMap<Reminder, ReminderResultDto>().ReverseMap();
        CreateMap<ReminderCreationDto, Reminder>().ReverseMap();
        CreateMap<ReminderUpdateDto, Reminder>().ReverseMap();

        CreateMap<StudyResult, StudyResultResultDto>().ReverseMap();
        CreateMap<StudyResultCreationDto, StudyResult>().ReverseMap();
        CreateMap<StudyResultUpdateDto, StudyResult>().ReverseMap();
    }
}
