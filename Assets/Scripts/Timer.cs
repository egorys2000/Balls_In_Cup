using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI TimerText;

    [SerializeField]
    public string InitText;

    private int Time = 0;

    void Start()
    {
        StartCoroutine(Tick());
    }

    private IEnumerator Tick() 
    {
        while (true) 
        {
            TimerText.text = InitText + Time.ToString();
            Time++;
            yield return new WaitForSeconds(1f);
        }
        
    }
}
