using ProjectTemplate.Application;

namespace ProjectTemplate.EFCoreAndIdentity.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
