using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flatStrength;

    // The scale factor to adjust the bird's size
    public float scaleChangeAmount = 0.1f;

    // The speed at which the bird scales up or down
    public float scalingSpeed = 2f;

    private Vector3 originalScale;
    private Vector3 currentScale;
    private float targetScale = 1f;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // Set the constraints to freeze rotation in the Z-axis (rotation around the forward axis)
       
        originalScale = transform.localScale;
        currentScale = originalScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive )
        {
            myRigidbody.velocity = Vector2.up * flatStrength ;
        }

        // Check if 'Q' is held down to start resizing bigger
        if (Input.GetKey(KeyCode.Q))
        {
            ResizeBird(scaleChangeAmount);
        }

        // Check if 'E' is held down to start resizing smaller
        if (Input.GetKey(KeyCode.E))
        {
            ResizeBird(-scaleChangeAmount);
        }
    }

    private void ResizeBird(float scaleChange)
    {
        targetScale = Mathf.Clamp(targetScale + scaleChange, 0.5f, 2f);
        currentScale.x = Mathf.MoveTowards(currentScale.x, targetScale, Time.deltaTime * scalingSpeed);
        currentScale.y = Mathf.MoveTowards(currentScale.y, targetScale, Time.deltaTime * scalingSpeed);
        transform.localScale = currentScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
