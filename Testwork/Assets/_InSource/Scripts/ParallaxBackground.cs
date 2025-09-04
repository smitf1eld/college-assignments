using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float parallaxEffect = 0.5f; // Сила эффекта параллакса (0 - стоит на месте, 1 - движется как передний план)
    private float length; // Длина одного спрайта фона
    private float startPos; // Начальная позиция по X

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponentInChildren<SpriteRenderer>().bounds.size.x; // Получаем длину первого дочернего спрайта
    }

    void Update()
    {
        // Бесконечно движем фон назад
        float temp = (Camera.main.transform.position.x * (1 - parallaxEffect));
        float dist = (Camera.main.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        // Если камера уперлась в край спрайта, переставляем его вперед
        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}