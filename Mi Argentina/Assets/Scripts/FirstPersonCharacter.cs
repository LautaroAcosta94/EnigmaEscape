using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCharacter : MonoBehaviour
{
    
    //Variables para el movimiento del mouse en Y
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 2.5f;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;
    
    //Variables para el movimiento del mouse en X
    float cameraPitch = 0.0f;

    //Variable para ocultar el cursor
    [SerializeField] bool lockCursor = true;

    //Variables para el movimiento del personaje
    [SerializeField] float velocidad = 6f;
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    CharacterController controller = null;
    float velocidadActual;

    Vector2 direccion = Vector2.zero;
    Vector2 velocidadDireccion = Vector2.zero;

    //Variables para correr
    public bool isSprinting = false;

    void Start()
    {
        //Llama al character controller
        controller = GetComponent<CharacterController>();
        //Llama al metodo para ocultar el cursor al iniciar el juego
        OcultarCursor();
    }

    void Update()
    {
        //Llama a la variable para mirar con el mouse
        UpdateMouseLook();

        //Llama a la variable para mover al personaje
        UpdateMovement();
    }

    //Metodo Mouse Look
    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;

        //Limita el movimiento de la camara a 90 grados en X
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    //Metodo para ocultar el cursor
    void OcultarCursor()
    {
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    //Metodo para mover al jugador
    void UpdateMovement()
    {
        Vector2 targetDir = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        direccion = Vector2.SmoothDamp(direccion, targetDir, ref velocidadDireccion, moveSmoothTime);

        //Se usa para correr
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if(isSprinting == true)
        {
            velocidadActual = velocidad * 2;
        }
        else
        {
            velocidadActual = velocidad;
        }

        Vector3 velocity = (transform.forward * direccion.y + transform.right * direccion.x) * velocidadActual;

        controller.Move(velocity * Time.deltaTime);
    }

}
