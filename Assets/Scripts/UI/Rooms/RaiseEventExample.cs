using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaiseEventExample : MonoBehaviour
{
    [SerializeField] private Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }
    }

    private void ChangeColor()
    {
        float r = Random.Range(0f, .9f);
        float g = Random.Range(0f, .9f);
        float b = Random.Range(0, .9f);

        image.color = new Color(r, g, b, 1f);
    }
}
