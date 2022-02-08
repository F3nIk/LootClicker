using Core.InventorySystem;
using Core.ItemSystem;

using System.Collections.Generic;

using UnityEngine;

namespace Core.UI
{

    public sealed class FuseInventoryView : MonoBehaviour
    {
        [SerializeField] private FuseInventoryItemFactory _fuseInventoryItemFactory;

        private FusePresenter _fusePresenter;
        private Inventory _inventory;
        private LootItemData _item;

        private List<FuseInventoryItemPresenter> _itemViews;

        public void Init(FusePresenter fusePresenter, Inventory inventory, LootItemData item)
        {
            _fusePresenter = fusePresenter;
            _inventory = inventory;
            _item = item;

            Show();
        }

        public void Show()
        {
            foreach (var item in _inventory.Items)
            {
                if (item.Level < item.MaxLevel && item.Equals(_inventory.EquipedItem) && item.Equals(_item))
                {
                }
                    _itemViews.Add(_fuseInventoryItemFactory.Create(_fusePresenter, item));
            }
        }
    }
}
