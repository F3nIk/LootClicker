using Core.ItemSystem;

using System.Linq;

public class LootItemDataFactory
{
    private readonly LootBoxDataBundle _lootBoxDataBundle;

    private LootItemDataFactory() { }
    public LootItemDataFactory(LootBoxDataBundle lootBoxDataBundle)
    {
        _lootBoxDataBundle = lootBoxDataBundle;
    }

    public LootItemData LoadFromDataBundle(int id)
    {
        var item = _lootBoxDataBundle.Data.ToList().First(item => item.Id == id);

        return new LootItemData(item);
    }

    public LootItemData LoadFromDataBundleAndSaveable(int id, int level)
    {
        var item = _lootBoxDataBundle.Data.ToList().First(item => item.Id == id);

        return new LootItemData(item, level);
    }
}
