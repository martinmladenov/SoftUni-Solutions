namespace PANDA.App.Services
{
    using Data;

    public abstract class DataService
    {
        protected PandaDbContext context;

        protected DataService(PandaDbContext context)
        {
            this.context = context;
        }
    }
}