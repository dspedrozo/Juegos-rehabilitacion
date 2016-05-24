using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gen_esferas : MonoBehaviour {

    public Rigidbody pelota;        //prefab esfera
    public float delayTime;         //delay entre generacion de pelota
    public float x_pos;             //posicion de generacion
    public Text contIzqTxt;
    public Text contDerTxt;
    public float velocidad;
    public float izq_der;           //variable para hacer salir mas esferas de izquierda(0.0) o de derecha(1.0)
                                    //en 0.5 salen igual cantidad de izq y der (es aleatorio de todas maneras)

    private float genTime;         //timer para generacion
    private float x;                
    private float random;           //random para izq o der
    private int contIzq, contDer;

    void Start() {
        x_pos = 2.5f;
        x = x_pos;
        genTime = 0.0f;
        contIzq = contDer = 0;
        contIzqTxt.text = "Izq: " + contIzq.ToString();
        contDerTxt.text = "Der: " + contDer.ToString();
    }

    void Update() {
        random = Random.value;
        genTime += Time.deltaTime;
        if(genTime > delayTime)
        {
            if (random > izq_der)
            {
                x = -x_pos;
                contIzq++;
                contIzqTxt.text = "Izq: " + contIzq.ToString();
            }
            else {
                x = x_pos;
                contDer++;
                contDerTxt.text = "Der: " + contDer.ToString();
            }
            Rigidbody pelotaRB = (Rigidbody) Instantiate(pelota, new Vector3(x, 5, 0), Quaternion.identity);
            pelotaRB.velocity = transform.forward * -velocidad;
            genTime = 0.0f;
        }
        
    }
}
