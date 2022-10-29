using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f, 1f)]
    private float scrollSpeed = .15f;
    private float offset;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        StartCoroutine(Countdown(6));
    }

    IEnumerator Countdown(int seconds)
    {
        int counter;
        while (true)
        {
            yield return new WaitForSeconds(seconds);
            scrollSpeed *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
