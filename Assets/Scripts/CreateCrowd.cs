using UnityEngine;

public class CreateCrowd : MonoBehaviour
{
    public Transform prefab;
    public int maxX = 0;
    public int maxZ = 0;

    // Check total amount of Genres
    public int rockTotal;
    public int popTotal;
    public int countryTotal;
    public int metalTotal;



    void Start()
    {
        for (int i = 0; i < maxX; i++)
        {
            for (int j = 0; j < maxZ; j++)
            {
                Instantiate(prefab, new Vector3((i) - 25, 0, j), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        rockTotal = GenreAssignment.rockTotal;
        popTotal = GenreAssignment.popTotal;
        countryTotal = GenreAssignment.countryTotal;
        metalTotal = GenreAssignment.metalTotal;

        if (Input.GetKeyDown(KeyCode.F))
        {
            rockTotal = 0;
            popTotal = 0;
            countryTotal = 0;
            metalTotal = 0;

        }

    }
}
