using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;
    public bool isLeft = true;
    public float boundaryY = 4.5f;

    void Update()
    {
        float move = 0f;
        if (isLeft)
        {
            if (Input.GetKey(KeyCode.W)) move = 1f;
            else if (Input.GetKey(KeyCode.S)) move = -1f;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow)) move = 1f;
            else if (Input.GetKey(KeyCode.DownArrow)) move = -1f;
        }

        Vector3 pos = transform.position;
        pos.y += move * speed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, -boundaryY, boundaryY);
        transform.position = pos;
    }
}
