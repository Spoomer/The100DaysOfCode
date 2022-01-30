namespace The100DaysOfCode.MVC;

public class AutoMapperProfileV1 : Profile
{
    public AutoMapperProfileV1()
    {
        CreateMap<DayOfCode,DayOfCodeViewModel>();
        CreateMap<Goal,GoalViewModel>();
        CreateMap<Note,NoteViewModel>();
    }
}
