using Core.InventorySystem;
using Core.ItemSystem;


namespace Core
{

    public sealed class Fuse
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

            _consumedItem = null;
            _targetItem = null;
        }

        public void SetTargetItem(LootItemData item)
        {
            _targetItem = item;
            _consumedItem = FindConsumedItem();
        }

        public LootItemData GetFusedItem()
        {
            return new LootItemData(_targetItem, _targetItem.Level + 1);
        }

        private LootItemData FindConsumedItem()
        {
            foreach (var item in _inventory.Items)
            {
                if(_targetItem.Id == item.Id && _targetItem.Level == item.Level && _targetItem != item)
                {
                    return item;
                }
            }

            return null;
        }
    }

}