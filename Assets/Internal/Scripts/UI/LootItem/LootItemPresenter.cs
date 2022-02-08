using Core.IO;

using UnityEngine;

namespace Core.UI
{

    public sealed class LootItemPresenter : MonoBehaviour
    {
        [SerializeField] private LootItemView _lootItemView;

        private IInput _input;

        public void Init(IInput input)
        {
            _input = input;
        }

        public void SetReadyToBeClosed()
        {
            _input.OnClick += OnClick;
        }

        public Animation PlayAnimation()
        {
            return _lootItemView.PlayAnimation();
        }

        public void OnClick()
        {
            _lootItemView.OnClick();
            _input.OnClick -= OnClick;
        }

        public void SetIcon(Sprite sprite)
        {
            _lootItemView.SetIcon(sprite);
        }
    }

}