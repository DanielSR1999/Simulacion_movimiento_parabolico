using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ParabolicMovement : MonoBehaviour
{
    [Range(0f,2f)]
    public float delay;
    Rigidbody2D myRB;
    public float initialVelocity, angle;
    public int normalizer = 10;
    public bool InAir = false;
    public Canvas resultsUI;
    public Text estimatedDistance, distance, winText;
    public GameObject circlePrefab;
    public InputField estimatedDistanceInput;
    float initialXPosition, finalXposition, relativeDistance;
    public float distanceNormalizer = 9.214274f;
    public float errorTolerance = 5f;
    private void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        InAir = false;
        initialXPosition = transform.position.x;
        StartCoroutine(LaunchCircle());
    }
    IEnumerator LaunchCircle()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y,angle);
        yield return new WaitForSeconds(delay);
        myRB.velocity = transform.right * (initialVelocity/normalizer);
        InAir = true;
        StartCoroutine(DrawCircle());
        
    }
    IEnumerator DrawCircle()
    {
        yield return new WaitForSeconds(0.05f);
        Instantiate(circlePrefab, transform.position, Quaternion.identity);
        StartCoroutine(DrawCircle());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (InAir)
        {
            finalXposition = transform.position.x;
            estimatedDistance.text = "Distancia estimada: " + estimatedDistanceInput.text;
            distance.text = "Distancia: " + calculateDistance().ToString();
            calculateErrorTolerance();
            if (calculateErrorTolerance() <= errorTolerance)
            {
                winText.text = "Felicitaciones, has acertado";
            }
            else
            {
                winText.text = "Has ingresado un valor erróneo";
            }

            resultsUI.enabled = true;
            InAir = false;
            StopAllCoroutines();
            Invoke("reloadScene", 4.8f);
        }
       
    }
    float calculateErrorTolerance()
    {
        float distance = calculateDistance();  
        float errorTolerance = (float.Parse(estimatedDistanceInput.text) - distance) / (distance) *100;
        return Mathf.Abs(errorTolerance);

    }
    float calculateDistance()
    {
        relativeDistance = finalXposition - initialXPosition;
        float newDistance = relativeDistance * distanceNormalizer;
        return newDistance;
    }
    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
