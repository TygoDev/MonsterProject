using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo : MonoBehaviour
{
    public enum BulletType
    {
        NONE,
        BUBBLE,
        CLOUD,
        FROZEN,
        JELLY,
        JUICE,
        RAINBOW,
        STRAWBERRY
    }
    public BulletType bulletType = BulletType.NONE;
    [SerializeField] Sprite bubble;
    [SerializeField] Sprite cloud;
    [SerializeField] Sprite frozen;
    [SerializeField] Sprite jelly;
    [SerializeField] Sprite juice;
    [SerializeField] Sprite rainbow;
    [SerializeField] Sprite strawberry;
    public void UpdateSprite()
    {
        var sprite = GetComponent<SpriteRenderer>();
        switch(bulletType)
        { 
            case BulletType.BUBBLE:
                sprite.sprite = bubble;
                break;
             case BulletType.CLOUD:
                sprite.sprite = cloud;
                break;
            case BulletType.FROZEN:
                sprite.sprite = frozen;
                break;
            case BulletType.JELLY:
                sprite.sprite = jelly;
                break;
            case BulletType.JUICE:
                sprite.sprite = juice;
                break;
            case BulletType.RAINBOW:
                sprite.sprite = rainbow;
                break;
            case BulletType.STRAWBERRY:
                sprite.sprite = strawberry;
                break;
        }
    }
}
