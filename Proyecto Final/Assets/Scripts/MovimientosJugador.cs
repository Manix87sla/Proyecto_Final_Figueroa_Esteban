
using UnityEngine;

public class MovimientosJugador : MonoBehaviour
{

    public float MovX, MovZ;

    public float VelocidadMovimiento = 15f;
    public float VelocidadRotacion = 200f;

    public float altura = 100f;
    public bool suelo;
    public LayerMask mascara;

    public Rigidbody RbJugador;

    public Vector3 PosInicial;



    void Start()
    {
        PosInicial = transform.position;
        RbJugador = GetComponent<Rigidbody>();
    }

    void Update()
    {
        spawnear(); //por si cae
    }


    void spawnear()
    {
        if (transform.position.y < -5)
        {
            transform.position = PosInicial;
        }

    }

    void FixedUpdate()
    {
        MoverJugador();

        EstaenSuelo();
                
        if (Input.GetKeyDown(KeyCode.K) && suelo == true)
        {
            Saltar();
        }
        
               
    }

    void MoverJugador()
    {
        MovX = Input.GetAxis("Horizontal");
        MovZ = Input.GetAxis("Vertical");

        Vector3 MovimientoJugador = new Vector3(MovX, 0, MovZ);
        RbJugador.AddForce(MovimientoJugador * VelocidadMovimiento * Time.fixedDeltaTime);
        transform.Rotate(0, MovX * VelocidadRotacion * Time.fixedDeltaTime, 0);
    }
     
    void EstaenSuelo()
    {
        RaycastHit rayo = new RaycastHit();
              

        if (Physics.Raycast(RbJugador.transform.position, Vector3.down, out rayo, 0.3f, mascara))
        {
                        suelo = true;
        }
        else
        {
            suelo = false;
        }

    }
    
    void Saltar()
    {
        RbJugador.AddForce(Vector3.up * altura,ForceMode.Impulse);
    }    



  
    
   





}
