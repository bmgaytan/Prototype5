using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;
    private float maxSpeed = 16;
    private float minSpeed = 12;
    private float torque = 2;
    private float xSpawnPos = 4;
    private float ySpawnPos = -4;
    public int pointValue;
    public ParticleSystem explosionParticle;

    private Rigidbody targetrb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetrb = GetComponent<Rigidbody>();
        targetrb.AddForce(RandomForce(), ForceMode.Impulse);
        targetrb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }

    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-torque, torque);
    }

    Vector3 RandomSpawn()
    {
        return new Vector3(Random.Range(-xSpawnPos, xSpawnPos), ySpawnPos);
    }
}
