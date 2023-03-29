using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject finish;
    private Transform gameEnd;
    public GameObject restart;

    private void Start()
    {
        restart.gameObject.SetActive(false);
    }
    private void Awake()
    {
        gameEnd = GetComponent<Transform>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(finish, gameEnd.position, Quaternion.identity);
        restart.gameObject.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
