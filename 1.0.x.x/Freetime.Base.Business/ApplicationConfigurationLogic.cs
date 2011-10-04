using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Freetime.Base.Data.Contracts;
using Freetime.Base.Data;
using Freetime.Base.Business.Implementable;
using Freetime.Base.Data.Entities;
using Freetime.Base.Data.Collection;

namespace Freetime.Base.Business
{
    public class ApplicationConfigurationLogic : BaseLogic<IApplicationConfigurationSession>, IApplicationConfigurationLogic
    {
        #region Singleton Structure

        #region Variables
        private static IApplicationConfigurationLogic s_instance;
        #endregion

        #region Current
        private static IApplicationConfigurationLogic Current
        {
            get
            {
                s_instance = s_instance ?? new ApplicationConfigurationLogic();
                return s_instance;
            }
        }
        #endregion

        #region Configurations
        private static ConfigurationItemCollection Configurations { get; set; }
        #endregion

        #region SetApplicationLogic
        public static void SetApplicationLogic(IApplicationConfigurationLogic logic)
        {
            s_instance = logic;
        }
        #endregion

        #region LoadConfigurations
        private static void LoadConfigurations()
        {
            Configurations = Current.GetAllConfigurations();
        }
        #endregion

        #region ApplicationConfigurationLogic
        static ApplicationConfigurationLogic()
        {
            LoadConfigurations();
        }
        #endregion

        #region GetCachedConfigItem
        private static ConfigurationItem GetCachedConfigItem(string configName)
        {
            return Configurations.FirstOrDefault(x => x.ConfigName == configName);
        }
        #endregion
        
        #region GetConfig

        #region Bool
        public static bool GetConfigBool(string configName)
        {
            if (configName == null)
                throw new ArgumentNullException(configName);

            var configItem = GetCachedConfigItem(configName);

            if (configItem == null)
                return false;

            switch (configItem.ConfigValue.ToLower())
            { 
                case "true":
                    return true;
                case "1":
                    return true;
                case "false":
                    return false;
                case "0":
                    return false;
                default:
                    return false;
            }
        }
        #endregion

        #region Int16
        public static Int16 GetConfigInt16(string configName)
        {
            if (configName == null)
                throw new ArgumentNullException(configName);

            var configItem = GetCachedConfigItem(configName);

            if (configItem == null)
                return default(Int32);

            Int16 value;
            Int16.TryParse(configItem.ConfigValue, out value);
            return value;
        }
        #endregion

        #region Int32
        public static Int32 GetConfigInt32(string configName)
        {
            if (configName == null)
                throw new ArgumentNullException(configName);

            var configItem = GetCachedConfigItem(configName);

            if (configItem == null)
                return default(Int32);

            Int32 value;
            Int32.TryParse(configItem.ConfigValue, out value);
            return value;
        }
        #endregion

        #region Int64
        public static Int64 GetConfigInt64(string configName)
        {
            if (configName == null)
                throw new ArgumentNullException(configName);

            var configItem = GetCachedConfigItem(configName);

            if (configItem == null)
                return default(Int32);

            Int64 value;
            Int64.TryParse(configItem.ConfigValue, out value);
            return value;
        }
        #endregion

        #region Decimal
        public static decimal GetConfigDecimal(string configName)
        {
            if (configName == null)
                throw new ArgumentNullException(configName);

            var configItem = GetCachedConfigItem(configName);

            if (configItem == null)
                return decimal.Zero;
            
            decimal value;
            decimal.TryParse(configItem.ConfigValue, out value);
            return value;
        }
        #endregion

        #region Double
        public static double GetConfigDouble(string configName)
        {
            if (configName == null)
                throw new ArgumentNullException(configName);

            var configItem = GetCachedConfigItem(configName);

            if (configItem == null)
                return default(double);

            double value;
            double.TryParse(configItem.ConfigValue, out value);
            return value;
        }
        #endregion

        #region Float
        public static float GetConfigFloat(string configName)
        {
            if (configName == null)
                throw new ArgumentNullException(configName);

            var configItem = GetCachedConfigItem(configName);

            if (configItem == null)
                return default(float);

            float value;
            float.TryParse(configItem.ConfigValue, out value);
            return value;
        }
        #endregion

        #region String
        public static string GetConfigString(string configName)
        {
            if (configName == null)
                throw new ArgumentNullException(configName);

            var configItem = GetCachedConfigItem(configName);

            if (configItem == null)
                return null;

            return configItem.ConfigValue;
        }
        #endregion

        #endregion

        #endregion

        #region Class
        protected override IApplicationConfigurationSession DefaultSession
        {
            get 
            {
                return new ApplicationConfigurationSession();
            }
        }

        internal ApplicationConfigurationLogic()
        { 
        }

        public ConfigurationItemCollection GetAllConfigurations()
        {
            return CurrentSession.GetAllConfigurations();
        }

        public ConfigurationItem GetConfigurationItem(string configName)
        {
            if (configName == null)
                throw new ArgumentNullException("configName");

            return CurrentSession.GetConfigurationItem(configName);
        }

        public void SaveConfigurationItem(ConfigurationItem configItem)
        {
            if (configItem == null)
                throw new ArgumentNullException("configItem");

            CurrentSession.SaveConfigurationItem(configItem);
        }

        public void DeleteConfigurationItem(ConfigurationItem configItem)
        {
            if (configItem == null)
                throw new ArgumentNullException("configItem");

            CurrentSession.DeleteConfigurationItem(configItem);
        }
        #endregion

    }
}
