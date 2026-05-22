using UnityEngine;

public class GearScript : MonoBehaviour
{
    public float t;
    public static bool isOver = false;
    public static bool isPressed = false;
    private bool tracker = false;
    private bool idk = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            if (idk == false)
            {
                t = 0;
                idk = true;
            }
            t += Time.deltaTime * 0.1f;
            transform.rotation = Quaternion.Slerp(Quaternion.Euler(transform.rotation.eulerAngles), Quaternion.Euler(0f, 0f, 180f), t);
        }
        else
        {
            if (isOver)
            {
                if (!tracker)
                {
                    t = 0;
                }
                tracker = true;
                t += Time.deltaTime * 5f;
                transform.rotation = Quaternion.Slerp(Quaternion.Euler(0f, 0f, 0f), Quaternion.Euler(0f, 0f, 10f), t);
            }
            else
            {
                tracker = false;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }
}
