using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Game/Character Data")]
public class CharacterData : ScriptableObject
{
    [Header("Info tampilan")]
    public string characterName;
    [TextArea] public string popupDescription;
    public Sprite icon;
    // public Color color;

    [Header("Gameplay")]
    public GameObject gameplayPrefab;
}