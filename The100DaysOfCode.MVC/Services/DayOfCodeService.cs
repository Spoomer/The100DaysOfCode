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
    internal async Task<IEnumerable<DayOfCodeViewModel>> GetDayOfCodeViewModelsAsync()
    {
        var daysOfCode = await _dbAccess.GetManyAsListAsync<DayOfCode>();
        var viewmodel = _mapper.Map<IEnumerable<DayOfCode>,IEnumerable<DayOfCodeViewModel>>(daysOfCode);
        return viewmodel;
    }
    internal async Task<DayOfCodeViewModel?> GetDayOfCodeViewModelAsync(int id)
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
    internal async Task<GoalViewModel?> GetGoalViewModel(int id)
    {
        Goal? goal = await _dbAccess.GetWithIdAsync<Goal>(id);
        if(goal is null)
        {
            return null;
        }
        return _mapper.Map<Goal,GoalViewModel>(goal);
    }
    internal async Task<NoteViewModel?> GetNoteViewModel(int id)
    {
        Note? note = await _dbAccess.GetWithIdAsync<Note>(id);
        if (note is null)
        {
            return null;
        }
        return _mapper.Map<Note, NoteViewModel>(note);
    }
    internal async Task CreateDayOfCode(DayOfCodeViewModel dayOfCodeViewModel)
    {
        var dayOfCode = _mapper.Map<DayOfCodeViewModel,DayOfCode>(dayOfCodeViewModel);
        await _dbAccess.CreateAsync(dayOfCode);
    }
    internal async Task<bool> EditDayOfCodeAsync(DayOfCodeViewModel dayOfCodeViewModel)
    {
        DayOfCode dayOfCode = _mapper.Map<DayOfCodeViewModel,DayOfCode>(dayOfCodeViewModel);
        return await _dbAccess.ReplaceAsync(dayOfCode);
    }

    internal async Task DeleteDayOfCodeAsync(int id)
    {
        await _dbAccess.DeleteAsync<DayOfCode>(id);
    }
    internal async Task DeleteGoalAsync(int id)
    {
        await _dbAccess.DeleteAsync<Goal>(id);
    }
    internal async Task DeleteNoteAsync(int id)
    {
        await _dbAccess.DeleteAsync<Note>(id);
    }
    internal async Task AddGoalToDayOfCodeAsync(int dayOfCodeId, string name)
    {
        DayOfCode? dayOfCode = await _dbAccess.GetWithIdAsync<DayOfCode>(dayOfCodeId);
        if (dayOfCode == null) return;
        dayOfCode.Goals.Add(new Goal() { Name = name, DayOfCodeId = dayOfCodeId});
        await _dbAccess.ReplaceAsync(dayOfCode);
    }
    internal async Task AddNoteToDayOfCodeAsync(int dayOfCodeId, string text)
    {
        DayOfCode? dayOfCode = await _dbAccess.GetWithIdAsync<DayOfCode>(dayOfCodeId);
        if (dayOfCode == null) return;
        dayOfCode.Notes.Add(new Note() { Text = text, DayOfCodeId = dayOfCodeId });
        await _dbAccess.ReplaceAsync(dayOfCode);
    }

    internal async Task CheckGoalAsync(int id, bool isChecked)
    {
        Goal? goal = await _dbAccess.GetWithIdAsync<Goal>(id);
        if (goal == null) return;
        goal.Check = isChecked;
        await _dbAccess.ReplaceAsync(goal);
    }
    internal async Task EditGoalAsync(int id, string name)
    {
        Goal? goal = await _dbAccess.GetWithIdAsync<Goal>(id);
        if (goal == null) return;
        goal.Name = name;
        await _dbAccess.ReplaceAsync(goal);
    }
    internal async Task EditNoteAsync(int id, string text)
    {
        Note? note = await _dbAccess.GetWithIdAsync<Note>(id);
        if (note == null) return;
        note.Text = text;
        await _dbAccess.ReplaceAsync(note);
    }
}
