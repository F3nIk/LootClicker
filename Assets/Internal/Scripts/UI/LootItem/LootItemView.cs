using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{

    [RequireComponent(typeof(Animation))]
    public sealed class LootItemView : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private Animation _animation;

        private void Awake()
        {
            _animation = GetComponent<Animation>();
        }

        public void OnClick()
        {
            gameObject.SetActive(false);
        }

        public Animation PlayAnimation()
        {
            gameObject.SetActive(true);

            _animation.Play("LootItemShow");

            return _animation;
        }

        public void SetIcon(Sprite sprite)
        {
            _image.sprite = sprite;
        }
    }

}