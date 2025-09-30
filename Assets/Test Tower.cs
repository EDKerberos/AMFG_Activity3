using UnityEngine;

public class TestTower : MonoBehaviour
{
    [Header("LOOKING ATT")]
    [SerializeField] private Transform target;
    [SerializeField] private float turnSpd;

    [Header("SHOOTING ATT")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform towerGun;
    private float playerDist;
    [SerializeField] private float hostileDist;
    [SerializeField] private float fireRate;
    [SerializeField] private float intTimer;

    void Update()
    {
        LookatPlayer();

        playerDist = Mathf.Sqrt(Mathf.Pow(target.transform.position.x - this.transform.position.x, 2)
            + Mathf.Pow(target.transform.position.y - this.transform.position.y, 2));
        var vectorDist = Vector3.Distance(target.transform.position, this.transform.position);
        // Debug.Log($"Distance {playerDist:F2}, Vector (vectorDist)");

        intTimer += Time.deltaTime;
        if (playerDist <= hostileDist)
        {
            if (intTimer >= fireRate)
            {
                Shoot();
                intTimer = 0f;
            }
        }
    }

    private void LookatPlayer()
    {
        var direction = target.position - transform.position;
        direction.Normalize();
        var targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        var rot = Quaternion.Euler(0, 0, -targetAngle);
        var currentAngle = this.transform.eulerAngles.z;
        var newAngle = Mathf.LerpAngle(currentAngle, targetAngle, turnSpd * Time.deltaTime);
        var newRot = Quaternion.Lerp(this.transform.rotation, Quaternion.Euler(0, 0, -targetAngle), turnSpd * Time.deltaTime);
        this.transform.rotation = newRot;
    }

    private void Shoot()
    {
        Vector2 spawnPos = towerGun ? (Vector2)towerGun.position : (Vector2)transform.position;
        float shootDir = Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
        Instantiate(bulletPrefab, towerGun.position, Quaternion.Euler(0, 0, shootDir));
    }
}
