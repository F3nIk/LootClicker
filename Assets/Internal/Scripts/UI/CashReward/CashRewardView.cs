
using UnityEngine;
using UnityEngine.UI;

public class CashRewardView : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void ChangeValue(float value) => _text.text = "+" + string.Format("{0:0.###}", value);

}
