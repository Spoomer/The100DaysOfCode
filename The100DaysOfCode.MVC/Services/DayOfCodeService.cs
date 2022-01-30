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
        var daysOfCode = await _dbAccess.GetListAsync<DayOfCode>();
        var viewmodel = _mapper.Map<IEnumerable<DayOfCode>,IEnumerable<DayOfCodeViewModel>>(daysOfCode);
        return viewmodel;
    }

    public async Task CreateDayOfCode(DayOfCodeViewModel dayOfCodeViewModel)
    {
        var dayOfCode = _mapper.Map<DayOfCodeViewModel,DayOfCode>(dayOfCodeViewModel);
        await _dbAccess.CreateAsync(dayOfCode);
    }
}
