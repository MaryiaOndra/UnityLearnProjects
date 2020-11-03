using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ScreenshotListView : MonoBehaviour
{
    [SerializeField] private ScreenshotView _template;
    [SerializeField] private Transform _cointainer;
    [SerializeField] private Sprite _defaultSprite;

    private void Awake()
    {
        Render(new List<Screenshot>()
        { 
            new Screenshot(_defaultSprite, DateTime.Now),
            new Screenshot(_defaultSprite, DateTime.Now),
            new Screenshot(_defaultSprite, DateTime.Now),
            new Screenshot(_defaultSprite, DateTime.Now),
            new Screenshot(_defaultSprite, DateTime.Now),        
            new Screenshot(_defaultSprite, DateTime.Now),        
            new Screenshot(_defaultSprite, DateTime.Now),        
            new Screenshot(_defaultSprite, DateTime.Now),        
            new Screenshot(_defaultSprite, DateTime.Now),               
        });
    }

    private void Render(IEnumerable<Screenshot> screenshots)
    {
        foreach (var screensot in screenshots)
        {
            var view = Instantiate(_template, _cointainer) as ScreenshotView;
            view.Render(screensot);
        }
    }
}
