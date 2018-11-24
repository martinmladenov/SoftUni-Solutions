namespace Eventures.Services
{
    using Data;

    public abstract class DataService : BaseService
    {
        protected readonly EventuresDbContext context;

        protected DataService(EventuresDbContext context)
        {
            this.context = context;
        }
    }
}