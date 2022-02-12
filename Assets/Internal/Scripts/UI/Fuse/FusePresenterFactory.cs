using Core.ItemSystem;

using UnityEngine;

using Zenject;

namespace Core.UI
{

    public sealed class FusePresenterFactory : MonoBehaviour
    {
        [SerializeField] private FusePresenter _fusePresenterPrefab;
        [SerializeField] private Transform _parent;

        private Fuse _fuse;

        [Inject]
        public void Construct(Fuse fuse)
        {
            _fuse = fuse;
        }

        public FusePresenter Create(LootItemData targetItem)
        {
            var presenter = Instantiate(_fusePresenterPrefab, _parent);

            _fuse.SetTargetItem(targetItem);
            presenter.Init(_fuse);
            return presenter;
        }
    }
}