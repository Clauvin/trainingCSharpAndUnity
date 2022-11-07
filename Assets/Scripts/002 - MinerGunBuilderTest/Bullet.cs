using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Color color;
    public float life_time;
    public Vector2 direction;
    public float damage;

    public Bullet()
    {
        this.speed = 1.0f;
        this.color = Color.white;
        this.life_time = 10f;
        this.direction = new Vector2(0.0f, 1.0f);
        this.damage = 1.0f;
    }

    public Bullet(float speed, Color color, float life_time, Vector2 direction, float damage)
    {
        this.speed = speed;
        this.color = color;
        this.life_time = life_time;
        this.direction = direction;
        this.damage = damage;
    }

    public Bullet(Bullet original_bullet)
    {
        this.speed = original_bullet.speed;
        this.color = original_bullet.color;
        this.life_time = original_bullet.life_time;
        this.direction = original_bullet.direction;
        this.damage = original_bullet.damage;
    }

    public string ToString()
    {
        string stringed = speed.ToString() + " " + color.ToString() + " " + life_time.ToString() + " " + direction.ToString() + " " + damage.ToString();
        return stringed;
    }
}
