using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    [RequireComponent(typeof(Animation))]
    public sealed class FuseView : MonoBehaviour
    {
        [SerializeField] private Image _targetItemIcon;
        [SerializeField] private Text _targetItemLevel;

        [Space(10f)]
        [SerializeField] private Image _consumedItemIcon;
        [SerializeField] private Text _consumedItemLevel;

        [Space(10f)]
        [SerializeField] private Image _resultItemIcon;
        [SerializeField] private Text _resultItemLevel;

        private Animation _animation;


        private void Awake()
        {
            _animation = GetComponent<Animation>();
        }

        public void Init(Sprite target, string targetLevel, Sprite consumed, string consumedLevel, Sprite result, string resultLevel)
        {
            _targetItemIcon.sprite = target;
            _targetItemLevel.text = targetLevel;

            _consumedItemIcon.sprite = consumed;
            _consumedItemLevel.text = consumedLevel;

            _resultItemIcon.sprite = result;
            _resultItemLevel.text = resultLevel;
        }

        public void Init(Sprite target, string targetLevel)
        {
            _targetItemIcon.sprite = target;
            _targetItemLevel.text = targetLevel;

            _consumedItemIcon.color = Color.red;
            _consumedItemLevel.text = string.Empty;

            _resultItemIcon.color = Color.red;
            _resultItemLevel.text = string.Empty;
        }

        public Animation PlayAnimation()
        {
            _animation.Play();
            return _animation;
        }
    }

}