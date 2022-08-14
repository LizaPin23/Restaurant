using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitorController : MonoBehaviour
{
    [SerializeField] private VisitorsDated[] _visitors;
    [SerializeField] private SpriteRenderer _frontSprite;
    [SerializeField] private SpriteRenderer _backSprite;
    [SerializeField] private SpriteRenderer _sittingSprite;
    
    public void SetRandomVisitor()
    {
      int i = Random.Range(0, _visitors.Length);

        VisitorsDated visitor = _visitors[i];

        _frontSprite.sprite = visitor.FrontSprite;
        _backSprite.sprite = visitor.BackSprite;
        _sittingSprite.sprite = visitor.SittingSprite;
    }

    
}
