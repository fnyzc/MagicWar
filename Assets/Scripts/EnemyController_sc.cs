using UnityEngine;

public class EnemyController_sc : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireballSpeed = 8f;
    public float fireballDamage = 15f;

    public GameObject fireRingPrefab;

    [Header("Slow Curse")]
    public GameObject slowCursePrefab;
    public float slowCurseSpeed = 6f;
    public float slowDuration = 2f;

    [SerializeField]
    private float slowCurseCooldown = 8f;
    private float nextSlowCurseTime = 0f;

    [Header("Blink")]
    public float minBlinkDistance = 2f;
    public float maxBlinkDistance = 5f;
    public float blinkCooldown = 5f;
    private float nextBlinkTime = 0f;

    [Header("Self Heal Settings")]
    public float healAmount = 20f;
    public int maxHealCount = 3;          
    public float healPercent = 0.4f; 
    private int currentHealCount = 0;
    private Health_sc health;


    public AudioClip sfxBlink; 


    private void Awake()
    {
        health = GetComponent<Health_sc>();
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Y))
            CastFireball();

        if (Input.GetKeyDown(KeyCode.U))
            CastFireRing();

        if (Input.GetKeyDown(KeyCode.I))
            CastSlowCurse();

        if (Input.GetKeyDown(KeyCode.O))
            CastSelfHeal();

        if (Input.GetKeyDown(KeyCode.P))
            BlinkRandom();*/ 
        //Aksiyonları test etmek için

    }

    void CastFireball()
    {
        if (fireballPrefab == null) return;

        GameObject ball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.left * fireballSpeed; //yön sola doğru
        }

        EnemyProjectile_sc proj = ball.GetComponent<EnemyProjectile_sc>();
        if (proj != null)
        {
            proj.damage = fireballDamage;
        }
    }

    void CastFireRing()
    {
        if (FireRing_sc.IsActive)
        {
            Debug.Log("FireRing hasn't been destroyed");
            return;
        }
        Instantiate(fireRingPrefab, transform.position, Quaternion.identity);
        
    }

    void CastSlowCurse()
    {
        if(Time.time < nextSlowCurseTime) return;

        nextSlowCurseTime = Time.time + slowCurseCooldown;

        if (slowCursePrefab == null) return;

        GameObject curse = Instantiate(slowCursePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = curse.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.left * slowCurseSpeed;
        }

        SlowCurseProjectile_sc proj = curse.GetComponent<SlowCurseProjectile_sc>();
        if (proj != null)
        {
            proj.slowDuration = slowDuration;
        }
    }

    void CastSelfHeal()
{
    if (health == null) return;

    if (currentHealCount >= maxHealCount) return;

    float hpPercent = health.currentHealth / health.maxHealth;

    if (hpPercent > healPercent) return;

    if (Mathf.Approximately(health.currentHealth, health.maxHealth)) return;
    
    health.Heal(healAmount);
    currentHealCount++;
    Debug.Log($"Enemy healed. Healed {currentHealCount}/{maxHealCount} times");
}


    void BlinkRandom()
    {
    if (Time.time < nextBlinkTime) return;

    float angle = Random.Range(0f, Mathf.PI * 2f);
    Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

    float distance = Random.Range(minBlinkDistance, maxBlinkDistance);
    Vector3 targetPos = transform.position + (Vector3)dir * distance;

    transform.position = targetPos;
    nextBlinkTime = Time.time + blinkCooldown;

    if (AudioController_sc.Instance != null && sfxBlink != null)
        AudioController_sc.Instance.PlaySfx(sfxBlink);
    }

}
