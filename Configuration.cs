using System;
using System.Globalization;

namespace AutomatedTests
{
    public class Configuration : WebdriverFramework.Framework.WebDriver.Configuration
    {
        /// <summary>
        /// copy stored models from \Resources\StoredModels if true 
        /// </summary>
        public static bool CopyStoredModels
        {
            get { return Convert.ToBoolean(GetValue("copy_stored_models"), CultureInfo.InvariantCulture); }
        }

    }
}