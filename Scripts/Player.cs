using UnityEngine;

public class Player : MonoBehaviour
{

    //movement player
    private Vector3 direction;

    //falling
    public float gravity = -9.8f; //public shows on unity bar

    // fly up
    public float upStrength = 5f;
    //sprite
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;//keep track of index in array sprites

    //set conditions for sprite
    private void Awake()
    {
        //retrieve the sprite from unity to this var
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {

        //continuously call function every (time interval)
        InvokeRepeating(nameof(AnimateSprite), 0.45f, 0.45f);

    }

    //every single frame
    private void Update()
    {

        //user input
        //1- user tap, bird fly
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //need bird to move up with some force hence multiply by factor
            direction = Vector3.up * upStrength;

        }

        //Tracking user tap input
        if (Input.touchCount > 0)
        {
            //detect touch
            Touch touch = Input.GetTouch(0);

            //if touch, bird go up
            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * upStrength;

            }


        }
        direction.y += gravity * Time.deltaTime; //apply gravity on bird
        transform.position += direction * Time.deltaTime; //upward force on bird if tap

    }
    //function for animating sprite
    private void AnimateSprite()
    {

        //iterate through array of sprites each time interval
        spriteIndex++;
        //loop back to begin if at end
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        //initialize point in location in array
        spriteRenderer.sprite = sprites[spriteIndex];
    }

}