using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Custom/Character")]
public class Character : ScriptableObject
{
    public Sprite sprite;
    public GameObject footPrint;
    public Sprite footPrintSprite;
    public new string name;
    public string species;
}
