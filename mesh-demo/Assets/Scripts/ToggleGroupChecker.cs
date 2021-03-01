using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable] public class ToggleEvent : UnityEvent<Toggle> { }
public class ToggleGroupChecker : MonoBehaviour
{
    [SerializeField] ToggleEvent onActiveToggleChanged;

    ToggleGroup toggleGroup;
    Toggle activeToggle;
    Toggle[] toggles;

    private void Awake()
    {
        toggleGroup = GetComponent<ToggleGroup>();
        toggles = GetComponentsInChildren<Toggle>();
    }

    private void OnEnable()
    {
        foreach (var tgl in toggles)
        {
            tgl.onValueChanged.AddListener(HandleToggleValueChanged);
        }

        Toggle _activeTgl = toggleGroup.GetFirstActiveToggle();
    }

    void HandleToggleValueChanged(bool isOn)
    {
        Toggle _activeTgl = toggleGroup.GetFirstActiveToggle();

        if (isOn)
        {
            onActiveToggleChanged?.Invoke(_activeTgl);
        }
    }

    private void OnDisable()
    {
        foreach (var tgl in toggles)
        {
            tgl.onValueChanged.RemoveListener(HandleToggleValueChanged);
        }
    }
}
