using Core.InventorySystem;

using UnityEngine;

using Zenject;

namespace Core.UI
{

    public sealed class InventoryPresenter : MonoBehaviour
    {
        [SerializeField] private InventoryView _inventoryView;
        [SerializeField] private ToggleButton _openCloseButton;

        private Inventory _inventory;

        [Inject]
        public void Construct(Inventory inventory)
        {
            _inventory = inventory;
            _inventoryView.Init(inventory);
        }

        private void OnEnable()
        {
            _openCloseButton.ValueChanged += OnButtonClick;
            _inventory.InventoryChanged += OnInventoryChanged;
        }

        private void OnDisable()
        {
            _openCloseButton.ValueChanged -= OnButtonClick;
            _inventory.InventoryChanged -= OnInventoryChanged;
        }

        private void OnButtonClick()
        {
            if (_inventoryView.Showed) _inventoryView.Hide();
            else _inventoryView.ShowInventory();
        }

        private void OnInventoryChanged()
        {
            if (_inventoryView.Showed) _inventoryView.Hide();
        }

    }

}