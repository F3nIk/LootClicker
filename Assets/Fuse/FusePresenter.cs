using Core;
using Core.InventorySystem;
using Core.ItemSystem;

using UnityEngine;
using UnityEngine.UI;

using Zenject;

namespace Core.UI
{

    public class FusePresenter : MonoBehaviour
    {
        [SerializeField] private FuseInventoryView _fuseInventoryView;
        [SerializeField] private FuseView _fuseView;
        [SerializeField] private Button _closeButton;

        private Inventory _inventory;
        private Fuse _fuse;


        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
        }

        public void SetTargetItem(Inventory inventory, Fuse fuse, LootItemData item)
        {
            _inventory = inventory;
            _fuse = fuse;
            _fuse.SetTargetItem(item);
            _fuseView.SetTargetIcon(item.Icon);
            _fuseInventoryView.Init(this, inventory, item);
        }

        public void AddItem(LootItemData item)
        {
            _fuse.AddItemToConsume(item);
        }

        public void Fuse()
        {
            _fuse.FuseItem();
        }

        private void OnCloseButtonClick()
        {
            Destroy(gameObject);
        }
    }
}