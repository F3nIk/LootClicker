using System;

using UnityEngine;

public sealed class MonoBehaviourMessages : MonoBehaviour
{
    public event Action Awaked;
    public event Action Started;
    public event Action Enabled;
    public event Action Disabled;
    public event Action ApplicationQuited;
    public event Action<bool> ApplicationFocused;
    public event Action<bool> ApplicationPaused;

    private void Awake() => Awaked?.Invoke();

    private void Start() => Started?.Invoke();

    private void OnEnable() => Enabled?.Invoke();

    private void OnDisable() => Disabled?.Invoke();

    private void OnApplicationQuit() => ApplicationQuited?.Invoke();

    private void OnApplicationFocus(bool focus) => ApplicationFocused?.Invoke(focus);

    private void OnApplicationPause(bool pause) => ApplicationPaused?.Invoke(pause);
}
