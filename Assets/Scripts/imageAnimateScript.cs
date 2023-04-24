using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class imageAnimateScript : MonoBehaviour
{
    private float fps;

    [SerializeField] private Sprite[] sprites;

    private Image image;
    private int index;
    private float timer;

    // Start is called before the first frame update
    private void OnEnable()
    {
        image = GetComponent<Image>();
        fps = 25f;
        index = 0;
        timer = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if ((timer += Time.deltaTime) >= (1/fps))
        {
            timer = 0;
            image.sprite = sprites[index];
            if(index < sprites.Length-1)
            {
                index += 1;
            }
            
        }
    }
}
