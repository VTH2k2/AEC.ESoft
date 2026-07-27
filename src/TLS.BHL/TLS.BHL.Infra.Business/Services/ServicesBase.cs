namespace AEC.ESoft.Infra.Business.Services
{
    public class ServicesBase
    {
        private IServiceProvider serviceProvider;

        public ServicesBase(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
    }
}