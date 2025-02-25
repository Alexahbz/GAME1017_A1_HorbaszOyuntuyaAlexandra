using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject PlayerBulletPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Button restart;
    private bool isDead = false;
    [SerializeField] List<GameObject> activeEnemies;

     
    void Start()
    {
        restart.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }
        if (Input.GetKey(KeyCode.W) && transform.position.y <= 4.46f)
        {
            transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y >= -4.46f)
        {
            transform.Translate(0f, -moveSpeed * Time.deltaTime, 0f);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(PlayerBulletPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Die();
        }
    }
    private void Die()
    {
        isDead = true;
        SceneManager.LoadScene("End Scene");
        restart.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    private void RestartGame()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        gameObject.SetActive(true);
        isDead = false;
        restart.gameObject.SetActive(false);

        ResetEnemies();
    }
    private void ResetEnemies()
    {
        foreach (GameObject enemy in activeEnemies)
        {
            Destroy(enemy);
        }
        activeEnemies.Clear();
    }
}
