namespace Mahesh.MicroApp.Core.Configuration
{
    public class ClientAppConfiguration:CoreConfiguration<ClientAppConfiguration>
    {
        public ClientAppConfiguration():base(false) { }
        public ClientAppConfiguration(bool applyDefaultValues):base(applyDefaultValues) { }

        public DefaultPageConfiguration DefaultPage{get;set;}
        public string RootPath{get;set;}

        protected override void SetValues(bool applyDefaultValues)
        {
            base.SetValues(applyDefaultValues);
            if(applyDefaultValues){
                RootPath=@"ClientApp\dist";
            }
        }
    }
}