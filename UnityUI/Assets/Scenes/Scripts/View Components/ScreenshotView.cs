using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using Assets.Scenes.Scripts.Extencions;

public class ScreenshotView : MonoBehaviour, IEndDragHandler, IBeginDragHandler, IDragHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Text _date;

    private Transform _dragingParent;
    private Transform _previousParent;

    public void Init(Transform dragingParent)
    {
        _previousParent = transform.parent;
        _dragingParent = dragingParent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = _dragingParent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var container = EventSystem.current.GetFirstComponentUnderPointer<DropContainer>(eventData);

        if (container != null)
        {
            transform.parent = container.Container;
        }
        else
        {
            transform.parent = _previousParent;
        }     
    }

    public void Render(Screenshot screenshot)
    {
        _image.sprite = screenshot.Image;
        _date.text = screenshot.CreationTime.ToString();
    }
}
