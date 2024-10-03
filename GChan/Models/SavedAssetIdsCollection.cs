﻿using GChan.Trackers;
using System.Text.Json;

namespace GChan.Models
{
    /// <summary>
    /// Thread safe collection of <see cref="long"/>s. For saving downloaded image ids.
    /// </summary>
    public class SavedAssetIdsCollection : ConcurrentHashSet<AssetId>
    {
        private static readonly JsonSerializerOptions jsonOptions = new();

        public SavedAssetIdsCollection()
        { 
        
        }

        public SavedAssetIdsCollection(string json)
        {
            LoadJson(json);
        }

        private void LoadJson(string json)
        {
            var assetIds = JsonSerializer.Deserialize<AssetId[]>(json, jsonOptions);

            locker.EnterWriteLock();

            try
            {
                foreach (var assetId in assetIds)
                {
                    set.Add(assetId);
                }
            }
            finally
            {
                if (locker.IsWriteLockHeld)
                {
                    locker.ExitWriteLock();
                }
            }
        }

        public string ToJson()
        {
            var array = ToArray();
            return JsonSerializer.Serialize(array, jsonOptions);
        }
    }
}
