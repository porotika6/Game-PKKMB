using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public CharacterDatabase characterDatabase; 
    public Transform spawnPoint; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CharacterData selected = characterDatabase.GetSelectedCharacter();

         if (selected.gameplayPrefab != null)
         {
        Instantiate(selected.gameplayPrefab, spawnPoint.position, spawnPoint.rotation);
         }

         else
         {
            Debug.LogWarning("Selected character does not have a gameplay prefab assigned.");
         }
    }

}
