using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //шаблон для создания яблок
    public GameObject applePrefab;
    //скорость движения яблони
    public float speed = 1f;
    //растояние, на котором должно изменятся направление движения яблони
    public float leftAndRightEdge = 10f;
    //вероятность случайного изменения направления движения
    public float chanceToChangeDirection = 0.1f;
    //частота создания экземпляров яблок
    public float secondsBetweenAppleDrops = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //сбрасывать яблоки раз в 2 секунды
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        //перемещаемся
        Vector3 pos = transform.position;
        //перемещение в риальном времени внезависимости от частоты кадров
        //deltaTime количество секунд, прошедших после отображения предыдущего кадра
        pos.x += speed * Time.deltaTime;
        transform.position = pos;        
        //изменение направления движения яблони
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirection)
        {
            speed *= -1;
        }
    }
}
