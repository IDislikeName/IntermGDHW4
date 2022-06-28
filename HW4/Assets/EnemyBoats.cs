using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.currenthp -= 1;
            Destroy(gameObject);
        }
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
