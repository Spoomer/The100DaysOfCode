namespace The100DaysOfCode.MVC.Services;

public class DayOfCodeService
{
    private readonly IDbAccess _dbAccess;
    private readonly IMapper _mapper;

    public DayOfCodeService(IDbAccess dbAccess, IMapper mapper)
    {
        _dbAccess = dbAccess;
        _mapper = mapper;
    }
    public async Task<IEnumerable<DayOfCodeViewModel>> GetDayOfCodeViewModelsAsync()
    {
        var daysOfCode = await _dbAccess.GetManyAsListAsync<DayOfCode>();
        var viewmodel = _mapper.Map<IEnumerable<DayOfCode>,IEnumerable<DayOfCodeViewModel>>(daysOfCode);
        return viewmodel;
    }
    public async Task<DayOfCodeViewModel?> GetDayOfCodeViewModelAsync(int id)
    {
        DayOfCode? dayOfCode = await _dbAccess.GetWithIdAsync<DayOfCode>(id);
        if (dayOfCode is null)
        {
            return null;
        }
        //DayOfCodeViewModel dayOfCodeView = _mapper.Map<DayOfCode,DayOfCodeViewModel>(dayOfCode);
        IList<Goal> goals = _dbAccess.GetManyAsEnumerable<Goal>().Where(x=>x.DayOfCodeId == id).ToList();
        //IList<GoalViewModel> goalsView = _mapper.Map<IList<Goal>,IList<GoalViewModel>>(goals);
        dayOfCode.Goals = goals;
        IList<Note> notes = _dbAccess.GetManyAsEnumerable<Note>().Where(x=>x.DayOfCodeId == id).ToList();;
        //IEnumerable<NoteViewModel> notesView = _mapper.Map<IEnumerable<Note>,IEnumerable<NoteViewModel>>(notes);
        dayOfCode.Notes = notes;
        var viewmodel = _mapper.Map<DayOfCode,DayOfCodeViewModel>(dayOfCode);
        return viewmodel;
    }
    public async Task CreateDayOfCode(DayOfCodeViewModel dayOfCodeViewModel)
    {
        var dayOfCode = _mapper.Map<DayOfCodeViewModel,DayOfCode>(dayOfCodeViewModel);
        await _dbAccess.CreateAsync(dayOfCode);
    }
    public async Task<bool> EditDayOfCodeAsync(DayOfCodeViewModel dayOfCodeViewModel)
    {
        DayOfCode dayOfCode = _mapper.Map<DayOfCodeViewModel,DayOfCode>(dayOfCodeViewModel);
        return await _dbAccess.ReplaceAsync(dayOfCode);
    }
}
