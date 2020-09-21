using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform cam;
    //public Transform head;

    //private PhotonView PV;
    public CharacterController myCC;
    public float movementSpeed = 12f;
    public float rotationSpeed;
    float headRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //PV = GetComponent<PhotonView>();
        //myCC = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            BasicMovement();
            //BasicRotation();
        }
    }

    void BasicMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        myCC.Move(move * movementSpeed * Time.deltaTime);

        if(Input.GetKey(KeyCode.W))
        {
            myCC.Move(transform.forward * Time.deltaTime * movementSpeed);
        }
        if(Input.GetKey(KeyCode.A))
        {
            myCC.Move(-transform.right * Time.deltaTime * movementSpeed);
        }
        if(Input.GetKey(KeyCode.S))
        {
            myCC.Move(-transform.forward * Time.deltaTime * movementSpeed);
        }
        if(Input.GetKey(KeyCode.D))
        {
            myCC.Move(transform.right * Time.deltaTime * movementSpeed);
        }
    }

    void BasicRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        //float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;

        transform.Rotate(new Vector3(0, mouseX, 0));


        // headRotation -= mouseY;
        // headRotation = Mathf.Clamp(headRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(headRotation, 0f, 0f);
        //playerBody.Rotate(Vector3.up * mouseX);
        cam.localEulerAngles = new Vector3(headRotation, 0f, 0f);
    }
}
