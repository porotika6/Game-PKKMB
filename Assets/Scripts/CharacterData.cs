using UnityEngine;

// Data untuk SATU karakter (1 aset = 1 prodi).
// Buat lewat: klik kanan di Project window -> Create -> Game -> Character Data
[CreateAssetMenu(fileName = "NewCharacter", menuName = "Game/Character Data")]
public class CharacterData : ScriptableObject
{
    [Header("Info tampilan")]
    public string characterName;
    [TextArea] public string popupDescription;
    public Sprite icon;
    public string hexCode;

    [Header("Gameplay")]
    public GameObject gameplayPrefab;
}