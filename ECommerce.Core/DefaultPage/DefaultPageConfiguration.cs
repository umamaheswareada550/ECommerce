using Mahesh.MicroApp.Core.Configuration;

namespace Mahesh.MicroApp.Core.Configuration
{
    public class DefaultPageConfiguration:CoreConfiguration<DefaultPageConfiguration>
    {
        public DefaultPageConfiguration():base(false){}
        public DefaultPageConfiguration(bool applyDefaultValues) : base(applyDefaultValues)
        {
        }

        public string FileName { get; set; }
    }
}