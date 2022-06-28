using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpdateScore : MonoBehaviour
{
    private TMP_Text tmpro;
    // Start is called before the first frame update
    void Start()
    {
        tmpro = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        tmpro.text = "Score: "+GameManager.Instance.score + "\nHealth: " + GameManager.Instance.currenthp;
    }
}
