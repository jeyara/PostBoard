﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using PostBoard.Data.Models;
using PostBoard.Data.Repository;
using PostBoard.Framework.Caching;
using PostBoard.Framework.Helper;
using PostBoard.Framework.Interfaces;

namespace NextG_IS.Services.Core.Services
{
       /// <summary>
        /// Setting manager
        /// </summary>
        public partial class SettingService : ISettingService
        {
            #region Constants

            /// <summary>
            /// Key for caching
            /// </summary>
            private const string SETTINGS_ALL_KEY = "pb.setting.all";
            /// <summary>
            /// Key pattern to clear cache
            /// </summary>
            private const string SETTINGS_PATTERN_KEY = "pb.setting.";

            #endregion

            #region Fields

            private readonly IRepository<Setting> _settingRepository;
            private readonly ICacheManager _cacheManager;

            #endregion

            #region Ctor

            /// <summary>
            /// Ctor
            /// </summary>
            /// <param name="cacheManager">Cache manager</param>
            /// <param name="settingRepository">Setting repository</param>
            public SettingService(ICacheManager cacheManager,IRepository<Setting> settingRepository)
            {
                this._cacheManager = cacheManager;
                this._settingRepository = settingRepository;
            }

            #endregion

            #region Nested classes

            [Serializable]
            public class SettingForCaching
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string Value { get; set; }
                public string Description { get; set; }
            }

            #endregion

            #region Utilities

            /// <summary>
            /// Gets all settings
            /// </summary>
            /// <returns>Setting collection</returns>
            protected virtual IDictionary<string, IList<SettingForCaching>> GetAllSettingsCached()
            {
                //cache
                string key = string.Format(SETTINGS_ALL_KEY);
                return _cacheManager.Get(key, () =>
                {
                    var query = from s in _settingRepository.Table
                                orderby s.Name
                                select s;
                    var settings = query.ToList();
                    var dictionary = new Dictionary<string, IList<SettingForCaching>>();
                    foreach (var s in settings)
                    {
                        var resourceName = s.Name.ToLowerInvariant();
                        var settingForCaching = new SettingForCaching()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Value = s.Value,
                            Description = s.Description
                        };
                        if (!dictionary.ContainsKey(resourceName))
                        {
                            //first setting
                            dictionary.Add(resourceName, new List<SettingForCaching>()
                        {
                            settingForCaching
                        });
                        }
                        else
                        {
                            //already added
                            //most probably it's the setting with the same name but for some certain store (storeId > 0)
                            dictionary[resourceName].Add(settingForCaching);
                        }
                    }
                    return dictionary;
                });
            }

            #endregion

            #region Methods

            /// <summary>
            /// Adds a setting
            /// </summary>
            /// <param name="setting">Setting</param>
            /// <param name="clearCache">A value indicating whether to clear cache after setting update</param>
            public virtual void InsertSetting(Setting setting, bool clearCache = true)
            {
                if (setting == null)
                    throw new ArgumentNullException("setting");

                _settingRepository.Insert(setting);

                //cache
                if (clearCache)
                    _cacheManager.RemoveByPattern(SETTINGS_PATTERN_KEY);

            }

            /// <summary>
            /// Updates a setting
            /// </summary>
            /// <param name="setting">Setting</param>
            /// <param name="clearCache">A value indicating whether to clear cache after setting update</param>
            public virtual void UpdateSetting(Setting setting, bool clearCache = true)
            {
                if (setting == null)
                    throw new ArgumentNullException("setting");

                _settingRepository.Update(setting);

                //cache
                if (clearCache)
                    _cacheManager.RemoveByPattern(SETTINGS_PATTERN_KEY);

            }

            /// <summary>
            /// Deletes a setting
            /// </summary>
            /// <param name="setting">Setting</param>
            public virtual void DeleteSetting(Setting setting)
            {
                if (setting == null)
                    throw new ArgumentNullException("setting");

                _settingRepository.Delete(setting);

                //cache
                _cacheManager.RemoveByPattern(SETTINGS_PATTERN_KEY);

            }

            /// <summary>
            /// Gets a setting by identifier
            /// </summary>
            /// <param name="settingId">Setting identifier</param>
            /// <returns>Setting</returns>
            public virtual Setting GetSettingById(int settingId)
            {
                if (settingId == 0)
                    return null;

                return _settingRepository.GetById(settingId);
            }

            /// <summary>
            /// Get setting value by key
            /// </summary>
            /// <typeparam name="T">Type</typeparam>
            /// <param name="key">Key</param>
            /// <param name="defaultValue">Default value</param>
            /// <param name="storeId">Store identifier</param>
            /// <returns>Setting value</returns>
            public virtual T GetSettingByKey<T>(string key, T defaultValue = default(T))
            {
                if (String.IsNullOrEmpty(key))
                    return defaultValue;

                var settings = GetAllSettingsCached();
                key = key.Trim().ToLowerInvariant();
                if (settings.ContainsKey(key))
                {
                    var settingsByKey = settings[key].FirstOrDefault();

                    if (settingsByKey != null)
                        return UtilityHelper.To<T>(settingsByKey.Value);
                }

                return defaultValue;
            }

            /// <summary>
            /// Set setting value
            /// </summary>
            /// <typeparam name="T">Type</typeparam>
            /// <param name="key">Key</param>
            /// <param name="value">Value</param>
            /// <param name="storeId">Store identifier</param>
            /// <param name="clearCache">A value indicating whether to clear cache after setting update</param>
            public virtual void SetSetting<T>(string key, T value, string description = "", bool clearCache = true)
            {
                if (key == null)
                    throw new ArgumentNullException("key");
                key = key.Trim().ToLowerInvariant();
                string valueStr = UtilityHelper.GetCustomTypeConverter(typeof(T)).ConvertToInvariantString(value);

                var allSettings = GetAllSettingsCached();
                var settingForCaching = allSettings.ContainsKey(key) ?  allSettings[key].FirstOrDefault() : null;
                if (settingForCaching != null)
                {
                    //update
                    var setting = GetSettingById(settingForCaching.Id);
                    setting.Value = valueStr;
                    UpdateSetting(setting, clearCache);
                }
                else
                {
                    //insert
                    var setting = new Setting()
                    {
                        Name = key,
                        Value = valueStr,
                        Description = description
                    };
                    InsertSetting(setting, clearCache);
                }
            }

            /// <summary>
            /// Gets all settings
            /// </summary>
            /// <returns>Setting collection</returns>
            public virtual IList<Setting> GetAllSettings()
            {
                var query = from s in _settingRepository.Table
                            orderby s.Name
                            select s;
                var settings = query.ToList();
                return settings;
            }

            /// <summary>
            /// Determines whether a setting exists
            /// </summary>
            /// <typeparam name="T">Entity type</typeparam>
            /// <typeparam name="TPropType">Code type</typeparam>
            /// <param name="settings">Entity</param>
            /// <param name="keySelector">Key selector</param>
            /// <param name="storeId">Store identifier</param>
            /// <returns>true -setting exists; false - does not exist</returns>
            public virtual bool SettingExists<T, TPropType>(T settings,
                Expression<Func<T, TPropType>> keySelector, int storeId = 0)
                where T : ISettings, new()
            {
                var member = keySelector.Body as MemberExpression;
                if (member == null)
                {
                    throw new ArgumentException(string.Format(
                        "Expression '{0}' refers to a method, not a property.",
                        keySelector));
                }

                var propInfo = member.Member as PropertyInfo;
                if (propInfo == null)
                {
                    throw new ArgumentException(string.Format(
                           "Expression '{0}' refers to a IsMust, not a property.",
                           keySelector));
                }

                string key = typeof(T).Name + "." + propInfo.Name;

                string setting = GetSettingByKey<string>(key);
                return setting != null;
            }

            /// <summary>
            /// Load settings
            /// </summary>
            /// <typeparam name="T">Type</typeparam>
            /// <param name="storeId">Store identifier for which settigns should be loaded</param>
            public virtual T LoadSetting<T>() where T : ISettings, new()
            {
                var settings = Activator.CreateInstance<T>();

                foreach (var prop in typeof(T).GetProperties())
                {
                    // get properties we can read and write to
                    if (!prop.CanRead || !prop.CanWrite)
                        continue;

                    var key = typeof(T).Name + "." + prop.Name;
                    //load by store
                    string setting = GetSettingByKey<string>(key);
                    if (setting == null)
                        continue;

                    if (!UtilityHelper.GetCustomTypeConverter(prop.PropertyType).CanConvertFrom(typeof(string)))
                        continue;

                    if (!UtilityHelper.GetCustomTypeConverter(prop.PropertyType).IsValid(setting))
                        continue;

                    object value = UtilityHelper.GetCustomTypeConverter(prop.PropertyType).ConvertFromInvariantString(setting);

                    //set property
                    prop.SetValue(settings, value, null);
                }

                return settings;
            }

            /// <summary>
            /// Save settings object
            /// </summary>
            /// <typeparam name="T">Type</typeparam>
            /// <param name="storeId">Store identifier</param>
            /// <param name="settings">Setting instance</param>
            public virtual void SaveSetting<T>(T settings) where T : ISettings, new()
            {
                /* We do not clear cache after each setting update.
                 * This behavior can increase performance because cached settings will not be cleared 
                 * and loaded from database after each update */
                foreach (var prop in typeof(T).GetProperties())
                {
                    // get properties we can read and write to
                    if (!prop.CanRead || !prop.CanWrite)
                        continue;

                    if (!UtilityHelper.GetCustomTypeConverter(prop.PropertyType).CanConvertFrom(typeof(string)))
                        continue;

                    string key = typeof(T).Name + "." + prop.Name;
                    //Duck typing is not supported in C#. That's why we're using dynamic type
                    dynamic value = prop.GetValue(settings, null);
                    if (value != null)
                        SetSetting(key, value,"", false);
                    else
                        SetSetting(key, "","", false);
                }

                //and now clear cache
                ClearCache();
            }

            /// <summary>
            /// Save settings object
            /// </summary>
            /// <typeparam name="T">Entity type</typeparam>
            /// <typeparam name="TPropType">Code type</typeparam>
            /// <param name="settings">Settings</param>
            /// <param name="keySelector">Key selector</param>
            /// <param name="storeId">Store ID</param>
            /// <param name="clearCache">A value indicating whether to clear cache after setting update</param>
            public virtual void SaveSetting<T, TPropType>(T settings,
                Expression<Func<T, TPropType>> keySelector,bool clearCache = true) where T : ISettings, new()
            {
                var member = keySelector.Body as MemberExpression;
                if (member == null)
                {
                    throw new ArgumentException(string.Format(
                        "Expression '{0}' refers to a method, not a property.",
                        keySelector));
                }

                var propInfo = member.Member as PropertyInfo;
                if (propInfo == null)
                {
                    throw new ArgumentException(string.Format(
                           "Expression '{0}' refers to a IsMust, not a property.",
                           keySelector));
                }

                string key = typeof(T).Name + "." + propInfo.Name;
                //Duck typing is not supported in C#. That's why we're using dynamic type
                dynamic value = propInfo.GetValue(settings, null);
                if (value != null)
                    SetSetting(key, value, "", clearCache);
                else
                    SetSetting(key, "", "", clearCache);
            }

            /// <summary>
            /// Delete all settings
            /// </summary>
            /// <typeparam name="T">Type</typeparam>
            public virtual void DeleteSetting<T>() where T : ISettings, new()
            {
                var settingsToDelete = new List<Setting>();
                var allSettings = GetAllSettings();
                foreach (var prop in typeof(T).GetProperties())
                {
                    string key = typeof(T).Name + "." + prop.Name;
                    settingsToDelete.AddRange(allSettings.Where(x => x.Name.Equals(key, StringComparison.InvariantCultureIgnoreCase)));
                }

                foreach (var setting in settingsToDelete)
                    DeleteSetting(setting);
            }

            /// <summary>
            /// Delete settings object
            /// </summary>
            /// <typeparam name="T">Entity type</typeparam>
            /// <typeparam name="TPropType">Code type</typeparam>
            /// <param name="settings">Settings</param>
            /// <param name="keySelector">Key selector</param>
            /// <param name="storeId">Store ID</param>
            public virtual void DeleteSetting<T, TPropType>(T settings,
                Expression<Func<T, TPropType>> keySelector) where T : ISettings, new()
            {
                var member = keySelector.Body as MemberExpression;
                if (member == null)
                {
                    throw new ArgumentException(string.Format(
                        "Expression '{0}' refers to a method, not a property.",
                        keySelector));
                }

                var propInfo = member.Member as PropertyInfo;
                if (propInfo == null)
                {
                    throw new ArgumentException(string.Format(
                           "Expression '{0}' refers to a IsMust, not a property.",
                           keySelector));
                }

                string key = typeof(T).Name + "." + propInfo.Name;
                key = key.Trim().ToLowerInvariant();

                var allSettings = GetAllSettingsCached();
                var settingForCaching = allSettings.ContainsKey(key) ?
                    allSettings[key].FirstOrDefault() : null;
                if (settingForCaching != null)
                {
                    //update
                    var setting = GetSettingById(settingForCaching.Id);
                    DeleteSetting(setting);
                }
            }

            /// <summary>
            /// Clear cache
            /// </summary>
            public virtual void ClearCache()
            {
                _cacheManager.RemoveByPattern(SETTINGS_PATTERN_KEY);
            }

            #endregion
        }
    }