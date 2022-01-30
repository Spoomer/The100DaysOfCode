namespace The100DaysOfCode.MVC;

public class AutoMapperProfileV1 : Profile
{
    public AutoMapperProfileV1()
    {
        CreateMap<DayOfCode,DayOfCodeViewModel>();
        CreateMap<DayOfCodeViewModel,DayOfCode>();
        CreateMap<Goal,GoalViewModel>();
        CreateMap<GoalViewModel,Goal>();
        CreateMap<Note,NoteViewModel>();
        CreateMap<NoteViewModel,Note>();
    }
}
