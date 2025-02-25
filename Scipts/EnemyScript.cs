using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour

{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject EnemyBulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
    float shootInterval = 4f;

    void Start()
    {
        InvokeRepeating(nameof(shootInterval), shootInterval, shootInterval);
    }
    void Update()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
        if (transform.position.x <= -7.16)
        {
            transform.position = new Vector3(7.16f, Random.Range(-4.7f, 4.7f), 0f);
        }

        if (transform.position.x <= -7.16f)
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        if (EnemyBulletPrefab != null && bulletSpawnPoint != null)
        {
            Instantiate(EnemyBulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBullet"))
        {
            ScoreManager.Instance.AddPoint();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"{collision.gameObject.name} triggered me!");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"{collision.gameObject.name} collided me!");
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }

}
