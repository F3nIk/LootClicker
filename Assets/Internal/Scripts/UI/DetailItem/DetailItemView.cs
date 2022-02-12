using Core.ItemSystem;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Core.UI
{

    public sealed class DetailItemView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Text _nameText;
        [SerializeField] private Text _levelText;
        [SerializeField] private Text _rateText;

        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _fuseButton;
        [SerializeField] private Button _equipButton;

        public UnityEvent CloseButtonClick => _closeButton.onClick;
        public UnityEvent FuseButtonClick => _fuseButton.onClick;
        public UnityEvent EquipButtonClick => _equipButton.onClick;


        public void SetItem(LootItemData item, bool equiped)
        {
            _image.sprite = item.Icon;
            _nameText.text = item.Name;
            _levelText.text = "Level \n" + item.Level + "/" + item.MaxLevel;
            _rateText.text = "x" + item.RewardRate.ToString();

            _equipButton.interactable = !equiped;
            _equipButton.onClick.AddListener(OnEquipButtonClick);

            _fuseButton.interactable = item.Level < item.MaxLevel;
        }

        private void OnEquipButtonClick()
        {
            _equipButton.interactable = false;
            _equipButton.onClick.RemoveListener(OnEquipButtonClick);

        }
    }
}