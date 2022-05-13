using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject BallsCollectedText;

    [SerializeField]
    private Slider GravitySlider;

    public void SetGravitySlider(float NewValue) 
    {
        GravitySlider.value = NewValue;
    }

    public void UpdateScore(int NewScore) 
    {
        float duration = .1f;
        float strength = .1f;

        BallsCollectedText.transform.DOShakeScale(duration, .025f * (Vector3.up + Vector3.right), 2, 0, true);
        BallsCollectedText.transform.DOShakeRotation(duration, 5 * Vector3.forward, 2, 1f, true);
        BallsCollectedText.GetComponent<TextMeshProUGUI>().text = NewScore.ToString() + "/" + GameManager.Get().MaxBalls;
    }
}
