using Microsoft.Extensions.Configuration;

namespace Mahesh.MicroApp.Core.Configuration
{
    public interface ICoreConfiguration
    {
        void Bind(IConfigurationSection configurationSection);
    }
}