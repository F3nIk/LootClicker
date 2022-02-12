
namespace Core.IO
{

    public interface ISaveable
    {
        public object SaveableObject { get; }
        public string GetFileName();
    }

}