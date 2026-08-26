using UnityEngine;

public class BGLoop : MonoBehaviour
{
 public Transform[] segments;   // 2+ salinan gedung (side by side)
    public float resetX = -20f;    // titik recycle (kiri)
    public float loopWidth = 40f;  // lebar total (jarak buat pindah ke kanan)

    void Update()
    {
        float speed = ScoreManager.instance.gameSpeed;

        // gerakin semua segmen ke kiri
        foreach (Transform seg in segments)
        {
            seg.Translate(Vector2.left * speed * Time.deltaTime);

            // kalau segmen keluar kiri, recycle ke kanan
            if (seg.position.x <= resetX)
                seg.position += new Vector3(loopWidth, 0, 0);
        }
    }
}
