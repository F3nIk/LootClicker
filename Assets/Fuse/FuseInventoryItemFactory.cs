using Core.ItemSystem;

using UnityEngine;

namespace Core.UI
{

    public sealed class FuseInventoryItemFactory : MonoBehaviour
    {
        [SerializeField] private FuseInventoryItemPresenter _fuseInventoryItemPresenter;
        [SerializeField] private Transform _parent;

        public FuseInventoryItemPresenter Create(FusePresenter fusePresenter, LootItemData item)
        {
            var presenter = Instantiate(_fuseInventoryItemPresenter, _parent);
            presenter.Init(fusePresenter, item);

            return presenter;
        }
    }

}