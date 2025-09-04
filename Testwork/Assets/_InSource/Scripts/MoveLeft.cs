using UnityEngine;

public class FlyingCube : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float amplitude = 2f;
    public float frequency = 1f;

    private float startY;
    private float randomOffset;

    void Start()
    {
        startY = transform.position.y;
        randomOffset = Random.Range(0f, 2f * Mathf.PI);
    }

    void Update()
    {
        // ƒвижение влево и по синусоиде
        float newX = transform.position.x - moveSpeed * Time.deltaTime;
        float newY = startY + amplitude * Mathf.Sin(Time.time * frequency + randomOffset);

        transform.position = new Vector3(newX, newY, transform.position.z);

        // ”ничтожение за камерой
        if (transform.position.x < -15f) Destroy(gameObject);
    }
}