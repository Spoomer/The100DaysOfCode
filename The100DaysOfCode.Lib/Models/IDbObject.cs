using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace The100DaysOfCode.Lib.Models;

public interface IDbObject
{
    public int Id { get; set; }
    public long UtcTimestamp { get; set; }
}
