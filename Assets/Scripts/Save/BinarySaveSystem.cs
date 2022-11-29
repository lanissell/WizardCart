using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;

namespace Save
{
    public static class BinarySaveSystem
    {
        private const string FILENAME = "/GameSaveData.dat";
        private static readonly string _filePath;

        static BinarySaveSystem()
        {
            _filePath = Application.persistentDataPath + FILENAME;
        }

        public static void Save(SaveData data)
        {
            using (FileStream file = File.Create(_filePath))
            {
                new BinaryFormatter().Serialize(file, data);
            }
        }

        public static SaveData Load()
        {
            SaveData loadedData;
            using (FileStream file = File.Open(_filePath, FileMode.OpenOrCreate))
            {
                if (file.Length == 0) return new SaveData();
                loadedData = (SaveData)new BinaryFormatter().Deserialize(file);
            }
            return loadedData;
        }

    }
}
