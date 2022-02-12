using Core.ItemSystem;

using System.Collections;

using UnityEngine;
using UnityEngine.UI;


namespace Core.UI
{

    public sealed class FusePresenter : MonoBehaviour
    {
        [SerializeField] private FuseView _fuseView;
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _fuseButton;

        private Fuse _fuse;


        private void OnEnable()
        {
            _closeButton.onClick.AddListener(OnCloseButtonClick);
            _fuseButton.onClick.AddListener(OnFuseButtonClick);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
            _fuseButton.onClick.RemoveListener(OnFuseButtonClick);
        }

        public void Init(Fuse fuse)
        {
            _fuse = fuse;


            if(_fuse.Consumed == null)
            {
                _fuseView.Init(_fuse.Target.Icon, GetFormattedLevel(_fuse.Target));
                _fuseButton.interactable = false;
            }
            else
            {
                _fuseView.Init(
                    _fuse.Target.Icon,
                    GetFormattedLevel(_fuse.Target),
                    _fuse.Consumed.Icon,
                    GetFormattedLevel(_fuse.Consumed),
                    _fuse.GetFusedItem().Icon,
                    GetFormattedLevel(_fuse.GetFusedItem()));
            }
        }

        private void OnCloseButtonClick()
        {
            Destroy(gameObject);
        }

        private void OnFuseButtonClick()
        {
            StartCoroutine(Fusing());
        }

        private IEnumerator Fusing()
        {
            yield return new WaitForAnimationFinish(_fuseView.PlayAnimation());

            _fuse.FuseItem();
        }

        private string GetFormattedLevel(LootItemData item)
        {
            return $"Level\n {item.Level}/{item.MaxLevel}";
        }
    }
}