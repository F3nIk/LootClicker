using Core.InventorySystem;
using Core.ItemSystem;


namespace Core
{

    public class Fuse
    {
        private Inventory _inventory;

        private LootItemData _targetItem;
        private LootItemData _consumedItem;

        public Fuse(Inventory inventory)
        {
            _inventory = inventory;
        }

        public LootItemData Target => _targetItem;
        public LootItemData Consumed => _consumedItem;

        public void FuseItem()
        {
            _inventory.RemoveItem(_consumedItem);

            _targetItem.IncreaseLevel();
        }

        public void SetTargetItem(LootItemData item)
        {
            _targetItem = item;
        }

        public void AddItemToConsume(LootItemData item)
        {
            _consumedItem = item;
        }
    }

}