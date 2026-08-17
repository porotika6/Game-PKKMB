using UnityEngine;

// Dipasang di scene Play, pada GameObject kosong (misal "PlayerSpawner").
// Membaca karakter yang sudah dipilih & di-confirm di MainMenu, lalu spawn prefabnya.
public class PlayerSpawner : MonoBehaviour
{
    public CharacterDatabase database;
    public Transform spawnPoint;

    void Start()
    {
        CharacterData selected = database.GetSelectedCharacter();
        Instantiate(selected.gameplayPrefab, spawnPoint.position, Quaternion.identity);
    }
}