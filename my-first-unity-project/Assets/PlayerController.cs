using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float moveSpeed = 4.0f;
  public float rotateSpeed = 1.5f;

  // Start is called before the first frame update
  void Start()
  {
    Debug.Log("Player started");
  }

  // Update is called once per frame
  void Update()
  {
    float speed = Input.GetAxis("Vertical");

    Animator anim = gameObject.GetComponent<Animator>();
    if (speed != 0) {
      anim.SetBool("forward", true);
    } else {
      anim.SetBool("forward", false);
    }

    transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

    Vector3 forward = transform.TransformDirection(Vector3.forward);

    CharacterController controller = GetComponent<CharacterController>();
    controller.SimpleMove(forward * speed * moveSpeed);
  }
}
