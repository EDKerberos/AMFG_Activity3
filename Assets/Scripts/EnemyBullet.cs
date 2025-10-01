using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float playerDist;

    [SerializeField] private float killDist;
    [SerializeField] private float travelSpeed;
    [SerializeField] private float lifeSpan;
    private float lifeTimer;

    void Awake()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        target = playerObject.transform;
    }

    void Update()
    {
        this.transform.position += transform.up * travelSpeed * Time.deltaTime;

        playerDist = Mathf.Sqrt(Mathf.Pow(target.transform.position.x - this.transform.position.x, 2)
        + Mathf.Pow(target.transform.position.y - this.transform.position.y, 2));
        var vectorDist = Vector3.Distance(target.transform.position, this.transform.position);

        if (playerDist <= killDist)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        lifeTimer += Time.deltaTime;
        if (lifeTimer >= lifeSpan)
        {
            Destroy(gameObject);
        }
    }
}