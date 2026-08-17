using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDatabase", menuName = "Game/Character Database")]
public class CharacterDatabase : ScriptableObject
{
    public CharacterData[] characters;

    private const string SELECTED_KEY = "SelectedCharacterIndex";

    public int GetSelectedIndex()
    {
        int index = PlayerPrefs.GetInt(SELECTED_KEY, 0);
        return Mathf.Clamp(index, 0, characters.Length - 1);
    }

    public void SetSelectedIndex(int index)
    {
        PlayerPrefs.SetInt(SELECTED_KEY, index);
        PlayerPrefs.Save();
    }

    public CharacterData GetSelectedCharacter()
    {
        return characters[GetSelectedIndex()];
    }
}