using Core.IO;

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using Zenject;

namespace Core.UI
{

    public sealed class LootBoxPresenter : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private LootBoxView _lootBoxView;
        [SerializeField] private LootBoxPriceView _lootBoxPriceView;
        [SerializeField] private LootItemFactory _lootItemViewFactory;

        private IInput _input;
        private LootBox _lootBox;

        [Inject]
        public void Construct(LootBox lootBox, IInput input)
        {
            _input = input;
            _lootBox = lootBox;
            ChangePriceValue();
        }

        private void OnEnable()
        {
            _lootBox.Load();
            _lootBoxPriceView.ChangeValue(_lootBox.GetCurrentPrice());

            _button.onClick.AddListener(PlayLootBoxOpenAnimation);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(PlayLootBoxOpenAnimation);
        }

        private void OnApplicationQuit()
        {
            _lootBox.Save();
        }

        public void PlayLootBoxOpenAnimation()
        {
            StartCoroutine(OpenAnimationSequence());
        }

        private IEnumerator OpenAnimationSequence()
        {
            if (_lootBox.CanOpen())
            {
                _button.interactable = false;

                yield return new WaitForAnimationFinish(_lootBoxView.PlayOpenAnimation());

                var looted = _lootBox.Open();
                var lootItemView = _lootItemViewFactory.Create(_input);

                ChangePriceValue();

                yield return new WaitForAnimationFinish(lootItemView.PlayAnimation());

                lootItemView.SetIcon(looted.Icon);
                lootItemView.SetReadyToBeClosed();

                yield return new WaitForAnimationFinish(_lootBoxView.PlayCloseAnimation());

                _button.interactable = true;
            }
        }

        private void ChangePriceValue()
        {
            _lootBoxPriceView.ChangeValue(_lootBox.GetCurrentPrice());
        }
    }

}