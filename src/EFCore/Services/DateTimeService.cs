using ProjectTemplate.Application;

namespace ProjectTemplate.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
