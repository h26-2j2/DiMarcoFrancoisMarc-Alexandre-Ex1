using UnityEngine;

public class DeplacementWarp : MonoBehaviour
{
    // Variables publiques
    public bool cheminInversee;
    public float vitesseY;
    public float limiteHaute;
    public float limiteBasse;

    // Variables privés
    private float positionX;
    private bool downScale = false;
    private float scale = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Valeurs aléatoires
        positionX = Random.Range(-2f, 2f);
        vitesseY = Random.Range(1.5f, 4f);

        // Assignation de la valeur aléatoire positionX au composant Transform du gameobject.
        Transform transformX = GetComponent<Transform>();
        transformX.Translate(positionX, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        // logique de déplacement
        positionX = transform.position.x;
        
        // cheminInverse (true) => chemin hexagone haut vers le bas.
        // cheminInverse (false) => chemin hexagone bas vers le haut.
        if (cheminInversee)
        {
            transform.position -= new Vector3(0, vitesseY, 0) * Time.deltaTime;

            if (transform.position.y < limiteBasse)
            {
                transform.position = new Vector3(positionX, limiteHaute);
            }
        }
        else
        {
            transform.position += new Vector3(0, vitesseY, 0) * Time.deltaTime;

            if (transform.position.y > limiteHaute)
            {
                transform.position = new Vector3(positionX, limiteBasse);
            }
        }

        // logique de l'échelle
        if (transform.localScale.x >= 4f)
        {
            downScale = true; // déclare que l'échelle doit diminuer
            transform.localScale -= new Vector3(scale, scale, 0) * Time.deltaTime;
        }
        else if (transform.localScale.x >= 1f && downScale) // si l'échelle doit diminuer, descend le scale
        {
            transform.localScale -= new Vector3(scale, scale, 0) * Time.deltaTime;
        }
        else if (transform.localScale.x <= 4f && !downScale) // si l'échelle ne doit pas diminuer, augmente le scale
        {
            transform.localScale += new Vector3(scale, scale, 0) * Time.deltaTime;
        }
        else if (transform.localScale.x <= 1f)
        {
            downScale = false; // déclare que l'échelle doit augmenter
            transform.localScale += new Vector3(scale, scale, 0) * Time.deltaTime;
        }
    }
}
