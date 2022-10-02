using System;
using Newtonsoft.Json;
using UnityEngine;

namespace ObjectsStorage
{
    public static class Storage
    {
        public static TStorageObject Save<TStorageObject, TData>(TStorageObject storageObject)
            where TStorageObject : StorageObject<TData>
        {
            if (storageObject.Data == null)
            {
                Debug.LogError($"Data of {storageObject.Key} is empty");
                return storageObject;
            }

            if (string.IsNullOrWhiteSpace(storageObject.Key))
            {
                Debug.LogError($"Invalid key: '{storageObject.Key}'");
                return storageObject;
            }

            var jsonData = JsonConvert.SerializeObject(storageObject.Data);
            PlayerPrefs.SetString(storageObject.Key, jsonData);

            return storageObject;
        }

        public static TStorageObject Load<TStorageObject, TData>(TStorageObject storageObject)
            where TStorageObject : StorageObject<TData>
        {
            if (!PlayerPrefs.HasKey(storageObject.Key))
            {
                storageObject.Data = storageObject.GetDefaultData();
                return storageObject;
            }

            var json = PlayerPrefs.GetString(storageObject.Key);
            try
            {
                storageObject.Data = JsonConvert.DeserializeObject<TData>(json);
                
                return storageObject;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                return storageObject;
            }
        }
    }
}