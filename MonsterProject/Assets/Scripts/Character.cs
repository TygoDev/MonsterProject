using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Custom/Character")]
public class Character : ScriptableObject
{
    public Sprite sprite;
    public new string name;
}
