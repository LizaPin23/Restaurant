using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [Serializable]
public class VisitorsDated
{
     [SerializeField] private Sprite _frontSprite;
     [SerializeField] private Sprite _backSprite;
     [SerializeField] private Sprite _sittingSprite;

    public Sprite FrontSprite => _frontSprite;
    public Sprite BackSprite => _backSprite;
    public Sprite SittingSprite => _sittingSprite;

}
