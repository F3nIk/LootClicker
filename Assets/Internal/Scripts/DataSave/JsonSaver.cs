using System.IO;

using UnityEngine;

namespace Core.IO
{

    public class JsonSaver : ISaver
    {
        public void LoadOverwrite(ISaveable saveable)
        {

            using (StreamReader reader = new StreamReader(saveable.GetFileName()))
            {
                JsonUtility.FromJsonOverwrite(reader.ReadToEnd(), saveable.SaveableObject);
            }

        }

        public void Save(ISaveable saveable)
        {
            using (StreamWriter writer = new StreamWriter(saveable.GetFileName()))
            {
                writer.Write(JsonUtility.ToJson(saveable.SaveableObject));
            }
        }

        public bool Exists(ISaveable saveable) => File.Exists(saveable.GetFileName());
    }
}