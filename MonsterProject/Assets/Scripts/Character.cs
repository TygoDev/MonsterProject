using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu(fileName = "New Character", menuName = "Custom/Character")]
public class Character : ScriptableObject
{
    public Sprite sprite;
    public GameObject footPrint;
    public Sprite footPrintSprite;
    public new string name;
    public RuntimeAnimatorController controller;
    public BulletInfo.BulletType bulletType = BulletInfo.BulletType.NONE;
}
