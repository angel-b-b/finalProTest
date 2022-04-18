using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] private float speed;
  private Rigidbody2D body;
  private Animator anim;

  private bool shoot;

  private bool death;


  private void Awake() {

      //Grabs referneces for rigidbody and animator from object
      body = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>();
  }

  private void Update() {

      float horizontalInput = Input.GetAxis("Horizontal");
      body.velocity = new Vector2(Input.GetAxis("Horizontal")* speed, body.velocity.y);

    //flips player facing left
        if(horizontalInput < -0.01f) {
            transform.localScale = Vector3.one;
        } else if(horizontalInput > 0.01f) {
            transform.localScale = new Vector3(-1,1,1);
        }

      if(Input.GetKey(KeyCode.Space)) {
          body.velocity = new Vector2(body.velocity.x, speed);
      }

        if(Input.GetKey(KeyCode.E)) {
            anim.SetBool("shoot", true);
        } else {
            anim.SetBool("shoot", false);
        }

      //Set animator parameters
      anim.SetBool("walk", horizontalInput !=0 );
  }
}
