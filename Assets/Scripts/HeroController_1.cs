using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController_1 : MonoBehaviour
{
    [SerializeField] private float speed_;                  //"SerializeField" significa que desde el inspector podemos  manipular o ver su valor.
    [SerializeField] private Vector2 movementDirection;     //"SerializeField" significa que desde el inspector podemos  manipular o ver su valor.
    private Rigidbody2D rigidbody2D_;                       //Variable de instanciamiento

  [Header("Animation Variables")]                                                             //"Pestaña" con título en el Inspector
  [SerializeField] AnimatorController_1 animatorController;               //Instanciamiento de Clase alias "animatorController"
                                                                          //"SerializeField" significa que desde el inspector podemos  manipular o ver su valor.

    [SerializeField] private float jumpForce;               //Agregamos una variable flotante para agrear furza al salto
    private bool jumpPressed = false;                       //variable usadas para saber si se apretó la barra espaciadora

    void Start()

    {
        rigidbody2D_ = GetComponent<Rigidbody2D>();         //Instanciando la variable.
        animatorController.Play(AnimationId.Idle);                               //Llamamos a la clase "AnimatorController_1" y le mandamos a su
                                                                                 //Método "Play" el "string" "Idle" guardado en "AnimationId"
        jumpPressed = Input.GetButtonDown("Jump");          //instanciamos la barra espaciadora a variable "jumpPressed"

    }

    // Update is called once per frame
    void Update()
    {
        HandleControls();                                    //invocando el método "HandleControls" (abre el puerto de entrada del teclado)
        HandleMovement();                                    //invocando el método "HandleMovement" (multiplica el valor de "x" por "speed".
        HandleFlip();                                       //invocando el método "HandleFlip" (rota el personaje a la izquierda o a la derecha)
        HandleJump();                                       //invocando el método "HandleJump" (agregamos furza vertical hacia arriba al Hero)
    }

    void HandleControls()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        jumpPressed = Input.GetButtonDown("Jump");          //asociamos la variable "jumpPressed" a la barra espaciadora

    }

    void HandleMovement()
    {
        rigidbody2D_.velocity = new Vector2(movementDirection.x * speed_, rigidbody2D_.velocity.y);

        if (Mathf.Abs(rigidbody2D_.velocity.x) > 0)     //si el velor absoluto matemático de la velocidasd es mayor a cero..
         {
             animatorController.Play(AnimationId.Run);    //ejecuta en el script AnimatorController_1 el método "Play"
                                                          //mandando dentro de la variable "AnimationAI" el clip "Run"
         }
         else                                            //de otro modo ejecuta en el script AnimatorController_1 el método "Play"
                                                         //mandando dentro de la variable "AnimationAI" el clip "Idle"
         {
             animatorController.Play(AnimationId.Idle);
         }
    }
    void HandleFlip()
    {
        if (rigidbody2D_.velocity.magnitude > 0)                //Sólo si el personaje se está moviendo ejecuta estas lineas...
        {
            if (rigidbody2D_.velocity.x >= 0)                           //si la velocidad en "x" es mayor que cero ejecuta la siguiente linea....
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);            //No rotes
            }
            else                                                                            //de otro modo ejecuta las siguientes lineas.....
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);              //rota en "y" 180º
            }
        }
    }
    void HandleJump()           //Método para agregarle fuerza la RigidBody del Hero
     {
         
         if (jumpPressed)        //si la barra espaciadora es apretada.....
            
         {
             this.rigidbody2D_.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);//agrega impulso de fuerza instantanea hacia arriba           
         }
     }
}
