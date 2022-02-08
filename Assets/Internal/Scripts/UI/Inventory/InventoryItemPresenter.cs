using Core.InventorySystem;
using Core.ItemSystem;

using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.UI
{

    public sealed class InventoryItemPresenter : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private InventoryItemView _inventoryItemView;

        private LootItemData _item;
        private Inventory _inventory;

        private DetailItemPresenter _detailItemPresenter;

        public void Init(
            DetailItemPresenter detailItemPresenter,
            LootItemData item,
            Inventory inventory,
            Sprite sprite,
            float rateValue)
        {
            _detailItemPresenter = detailItemPresenter;
            _item = item;
            _inventoryItemView.Init(sprite, rateValue);

            _inventory = inventory;

            if (_inventory.EquipedItem == _item)
            {
                _inventoryItemView.EnableOutline();
            }

            _inventory.EquipItemChanged += OnEquipItemChanged;
        }


        private void OnDestroy()
        {
            _inventory.EquipItemChanged -= OnEquipItemChanged;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _detailItemPresenter.ShowItemDetail(_item);
        }

        private void OnEquipItemChanged(LootItemData item)
        {
            if(item == null || item.Equals(_item) == false)
            {
                _inventoryItemView.DisableOutline();
                return;
            }

            _inventoryItemView.EnableOutline();
        }
    }

}