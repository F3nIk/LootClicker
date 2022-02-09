using Core.InventorySystem;
using Core.ItemSystem;
using Core.UI;

using UnityEngine;

using Zenject;

namespace Core.UI
{

    public sealed class DetailItemPresenter : MonoBehaviour
    {
        [SerializeField] private DetailItemViewFactory _detailItemViewFactory;
        [SerializeField] private FusePresenterFactory _fusePresenterFactory;

        private DetailItemView _detailItemView;

        private Inventory _inventory;
        private LootItemData _item;

        [Inject]
        public void Construct(Inventory inventory)
        {
            _inventory = inventory;
        }

        public void ShowItemDetail(LootItemData item)
        {
            if (_detailItemView != null) Clear();

            _item = item;
            _detailItemView = _detailItemViewFactory.Create();
            _detailItemView.SetItem(item, _inventory.HasEquipedItemAndEqualsTo(_item));

            SubscribeToViewEvents();
        }

        private void SubscribeToViewEvents()
        {
            _detailItemView.CloseButtonClick.AddListener(OnCloseButtonClick);
            _detailItemView.EquipButtonClick.AddListener(OnEquipButtonClick);
            _detailItemView.FuseButtonClick.AddListener(OnFuseButtonClick);
        }

        private void UnsubscribeFromViewEvents()
        {
            _detailItemView.CloseButtonClick.RemoveListener(OnCloseButtonClick);
            _detailItemView.EquipButtonClick.RemoveListener(OnEquipButtonClick);
            _detailItemView.FuseButtonClick.RemoveListener(OnFuseButtonClick);
        }

        private void OnCloseButtonClick()
        {
            UnsubscribeFromViewEvents();
            Clear();
        }

        private void OnEquipButtonClick()
        {
            _inventory.EquipItem(_item);
        }

        private void OnFuseButtonClick()
        {
            _fusePresenterFactory.Create(_item);

            OnCloseButtonClick();
        }

        private void Clear()
        {
            Destroy(_detailItemView.gameObject);
            _detailItemView = null;
        }
    }

}