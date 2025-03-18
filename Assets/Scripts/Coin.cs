using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private AudioClip collectSound;

    private int count = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            count++;
            AudioSource.PlayClipAtPoint(collectSound, collision.transform.position);
            Destroy(collision.gameObject);
        }
    }
}
