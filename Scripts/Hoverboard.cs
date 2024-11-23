using UnityEngine;

public class Hoverboard : MonoBehaviour
{

    //movement player
    private Vector3 direction;

    //falling
    public float gravity = -9.8f; //public shows on unity bar

    // fly up
    public float upStrength = 5f;
    //sprite
    // Sprites
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex; // Keep track of index in array sprites

    // Time for showing alternative sprite
    private float showAltSpriteTime = 0.4f; 
    private float timer = 0.0f; // Timer for alternative sprite

    //set conditions for sprite
    private void Awake()
    {
        //retrieve the sprite from unity to this var
        spriteRenderer = GetComponent<SpriteRenderer>();

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

            //animation hoverboard
            timer = 0.0f;

            // Change sprite temporarily
            spriteRenderer.sprite = sprites[1];
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

        // Handle displaying alternative sprite for a set time
        if (timer < showAltSpriteTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            // Revert to original sprite after time is up
            spriteRenderer.sprite = sprites[0]; // Assuming first sprite is original
        }

    }


}