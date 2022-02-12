
namespace Core.IO
{
    public interface ISaver
    {
        public void Save(ISaveable saveable);

        public void LoadOverwrite(ISaveable saveable);

        public bool Exists(ISaveable saveable);
    }

}