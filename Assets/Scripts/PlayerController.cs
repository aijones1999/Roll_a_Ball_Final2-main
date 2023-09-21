using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class StartPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3((float)-6.65, (float)0.752, -8);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private float movementX;
    private float movementY;

    private Rigidbody rb;
    private int count;

    // At the start of the game..
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;

            SetCountText();
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 10)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
        }
    }
}