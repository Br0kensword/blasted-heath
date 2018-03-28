using UnityEngine;

public class FPS : MonoBehaviour
{

    public float moveSpeed;
    public float camSens;
    public float maxVert = 45f;
    public float minVert = -45f;
    public float jumpForce = 10.0f;
    private float gravity = 12.0f;
    
    private float jumpVelocity;
    public GameObject cam;


    private CharacterController player;


    public void Start()
    {
        player = GetComponent<CharacterController>();
    }


    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;
        float moveVerticle = Input.GetAxis("Vertical") * moveSpeed;

        float rotateHorizontal = Input.GetAxis("Mouse X") * camSens;
        float rotateVerticle = Input.GetAxis("Mouse Y") * camSens;

        if(player.isGrounded){
            jumpVelocity = -gravity * Time.deltaTime;

            if(Input.GetKeyDown(KeyCode.Space)){
                jumpVelocity = jumpForce;
            }
        }
        else{
            jumpVelocity -= gravity * Time.deltaTime;
        }
        


        Vector3 movement = new Vector3(moveHorizontal, jumpVelocity, moveVerticle);

        transform.Rotate(0, rotateHorizontal, 0);

        rotateVerticle = Mathf.Clamp(rotateVerticle, minVert, maxVert);
        cam.transform.Rotate(-rotateVerticle, 0, 0);

        movement = transform.rotation * movement;

        player.Move(movement * Time.deltaTime);

    }
}
