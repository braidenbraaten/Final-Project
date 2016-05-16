using UnityEngine;
using System.Collections;

public class activateDeactivate : MonoBehaviour
{
    public float firstTimer;
    public GameObject firstSource;
    public float secondTimer;
    public GameObject secondSource;
    public float thirdTimer;
    public GameObject thirdSource;
    //public float fourthTimer;
    public GameObject fourthSource;

    // Use this for initialization
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        firstTimer -= Time.deltaTime;

        firstSource.SetActive(false);
        secondSource.SetActive(false);
        thirdSource.SetActive(false);
        fourthSource.SetActive(false);

        foreach (Transform child in this.transform)
        {
            //if (firstTimer >= 0)
            //    firstSource.SetActive(false);
            //else
            //    firstSource.SetActive(true);

            if (firstTimer <= 0)
            {
                firstTimer = 0;
                firstSource.SetActive(true);
                secondTimer -= Time.deltaTime;
            }
            if (secondTimer >= 0)
                secondSource.SetActive(false);

            if (secondTimer <= 0)
            {
                secondTimer = 0;
                secondSource.SetActive(true);
                thirdSource.SetActive(true);

                thirdTimer -= Time.deltaTime;
            }

            if (thirdTimer <= 0)
            {
                thirdTimer = 0;
                thirdSource.SetActive(false);
                fourthSource.SetActive(true);
            }
        }
    }
}
