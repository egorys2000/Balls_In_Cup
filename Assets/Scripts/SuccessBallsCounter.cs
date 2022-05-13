using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessBallsCounter : MonoBehaviour
{
    [SerializeField]
    private int _balls_counter = 0;

    public int BallsCounter 
    {
        get { return _balls_counter; }
        private set { _balls_counter = value; } 
    }

    void OnTriggerEnter(Collider collider)
    {
        BallsCounter++;
        GameManager.Get().UpdateScore(BallsCounter);
    }

    void OnTriggerExit(Collider collider)
    {
        BallsCounter--;
        GameManager.Get().UpdateScore(BallsCounter);
    }
}
