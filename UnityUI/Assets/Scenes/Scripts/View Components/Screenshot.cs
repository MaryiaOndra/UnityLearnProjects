using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Screenshot 
{
    private Sprite _image;
    private DateTime _creationTime;

    public Sprite Image => _image;
    public DateTime CreationTime => _creationTime;

    public Screenshot(Sprite image, DateTime creationTime) 
    {
        _image = image;
        _creationTime = creationTime;
    }

}
