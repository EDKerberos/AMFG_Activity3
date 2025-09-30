using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float moveSpd;

    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        transform.Translate(hInput * moveSpd * Time.deltaTime, 0, 0);

        transform.Translate(0, vInput * moveSpd * Time.deltaTime, 0);
    }
}
