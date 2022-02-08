using Core.InventorySystem;
using Core.ItemSystem;

using UnityEngine;

namespace Core.UI
{

    public class InventoryItemPresenterFactory : MonoBehaviour
    {
        [SerializeField] private InventoryItemPresenter _inventoryItemPrefab;
        [SerializeField] private DetailItemPresenter _detailItemPresenter;

        public virtual InventoryItemPresenter CreateItemView(Transform parent, LootItemData item, Inventory inventory, Sprite icon, float rateValue)
        {
            var created = Instantiate(_inventoryItemPrefab, parent);
            created.Init(_detailItemPresenter, item, inventory, icon, rateValue);

            return created;
        }

    }

}