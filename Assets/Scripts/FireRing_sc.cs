using UnityEngine;

public class FireRing_sc : MonoBehaviour
{
    [Header("Fire Ring Settings")]
    public float damage = 15f;
    public static bool IsActive = false;

    private void Start()
    {
       IsActive = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Health_sc hp = other.GetComponent<Health_sc>();
            if (hp != null)
            {
                hp.TakeDamage(damage);
                Debug.Log("FireRing hit player!");
            }
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        IsActive = false;
    }
}
