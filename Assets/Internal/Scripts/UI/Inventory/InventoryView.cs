using Core.InventorySystem;

using System.Collections.Generic;

using UnityEngine;

namespace Core.UI
{

    public sealed class InventoryView : MonoBehaviour
    {
        [SerializeField] private InventoryItemPresenterFactory _inventoryItemViewFactory;
        [SerializeField] private Transform _parent;
        private Inventory _inventory;
        private List<InventoryItemPresenter> _views;

        public bool Showed => gameObject.activeInHierarchy;

        public void Init(Inventory inventory)
        {
            _inventory = inventory;
            _views = new List<InventoryItemPresenter>();

            gameObject.SetActive(false);
        }

        public void ShowInventory()
        {
            gameObject.SetActive(true);

            foreach (var item in _inventory.Items)
            {
                _views.Add(_inventoryItemViewFactory.CreateItemView(_parent, item, _inventory, item.Icon, item.RewardRate));
            }
        }

        public void Hide()
        {
            foreach (var view in _views)
            {
                Destroy(view.gameObject);
            }

            _views.Clear();

            gameObject.SetActive(false);
        }
    }

}