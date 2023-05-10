using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Custom/Character")]
public class Character : ScriptableObject
{
    public Sprite sprite;
    public Sprite footPrint;
    public new string name;
    public string species;
}
