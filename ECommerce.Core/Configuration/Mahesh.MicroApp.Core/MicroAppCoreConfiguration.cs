namespace Mahesh.MicroApp.Core.Configuration
{
    public class MicroAppCoreConfiguration : CoreConfiguration<MicroAppCoreConfiguration>
    {
        public MicroAppCoreConfiguration():base(false) { }
        public MicroAppCoreConfiguration(bool applyDefaultValues) : base(applyDefaultValues)
        {
        }

        public ClientAppConfiguration ClientApp{get;set;}
    }
}