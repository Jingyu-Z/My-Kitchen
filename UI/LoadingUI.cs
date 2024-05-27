using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dots;
    private float dotRate = 0.3f;

    private void Start() {
        StartCoroutine(DotsAnimation());
    }
    IEnumerator DotsAnimation()
    {
        while(true)
        {
             dots.text = " ";
            yield return new WaitForSeconds(0.3f);
            dots.text = ".";
            yield return new WaitForSeconds(0.3f);
            dots.text = "..";
            yield return new WaitForSeconds(0.3f);
            dots.text = "...";
            yield return new WaitForSeconds(0.3f);
        }
    }
}
