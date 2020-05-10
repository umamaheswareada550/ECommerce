using System;
using Microsoft.Extensions.Configuration;

namespace Mahesh.MicroApp.Core.Configuration
{
    public abstract class CoreConfiguration<TConfiguration>:ICoreConfiguration where TConfiguration:ICoreConfiguration
    {
        public CoreConfiguration(bool applyDefaultValues)
        {
            SetValues(applyDefaultValues);
        }

        #region Core Configuration Implementation
        //This regio sould be copied and pasted into each class that implements ICoreConfiguration
        //This has to be duplicated in CoreConfiguration and CoreConfigurationDictionary because C# does not support inheriting from multiple classes
        //Each private method in the following region
        #region Private Members
        private ICoreConfiguration ICoreConfig=>((ICoreConfiguration)this);
        #endregion
        #region Protected Members
        protected virtual void SetValues(bool applyDefaultValues) { }
        #endregion

        #region Public Members
        public void Bind(IConfigurationSection configurationSection){
            ICoreConfig.Bind(configurationSection);
        }
        #endregion
        #endregion
    }
}