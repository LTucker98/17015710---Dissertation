using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class GenreAssignment : MonoBehaviour
{
    // Genres from most in preference to least
    public int firstGenre;
    public int secondGenre;
    public int thirdGenre;
    public int fourthGenre;

    // Check total amount of Genres
    [HideInInspector]
    public static int rockTotal;
    public static int popTotal;
    public static int countryTotal;
    public static int metalTotal;

    // Assign Enviroment Genre | Created in Environment Script
    public int enviroGenre;

    // Assign enjoyment levels via player
    [HideInInspector]
    public int enjoyMainLevel, enjoyRockLevel, enjoyPopLevel, enjoyCountryLevel, enjoyMetalLevel;
    

    // Sets Booleans for Enviromental areas and Key Events
    [HideInInspector]
    public bool startRock, startPop, startCountry, startMetal;
    [HideInInspector]
    public static bool eventOne, eventTwo, eventThree, eventFour;
    [HideInInspector]
    public bool loop;
    public bool loopOne = false; // Check if first loop is complete

    // Set Individual Enjoyment Level
    public float indEnjoyLevel = 0f;

    // Set Colours of enjoyment
    bool SetColours = false;
    public Material Green, Yellow, Red;
    public Material rock, pop, country, metal;

    public GameObject body;

    [HideInInspector]
    public GameObject rockArea, popArea, countryArea, metalArea;
    
    public Animator anim;
    public int enjoyAnim;
    public bool walking;   // WALKING CONFLICTS WITH OTHER ANIMATIONS

    public Vector3 playerStartPos;  // SET AI POSITION BACK TO ORIGINAL?
    
    private NavMeshAgent agent;


    public static int secondRock, secondPop, secondCountry, secondMetal;
    public static int thirdRock, thirdPop, thirdCountry, thirdMetal;
    public static int fourthRock, fourthPop, fourthCountry, fourthMetal;
    void Start()
    {
        anim = GetComponent<Animator>();
        playerStartPos = this.transform.position;
        AssignGenres();
        AssignEnviroment();
        AssignMaterial();
        CheckTotal();
        agent = GetComponent<NavMeshAgent>();


        rockArea = GameObject.FindGameObjectWithTag("Rock");
        popArea = GameObject.FindGameObjectWithTag("Pop");
        countryArea = GameObject.FindGameObjectWithTag("Country");
        metalArea = GameObject.FindGameObjectWithTag("Metal");
    }

    // Update is called once per frame
    void Update()
    {
        ReassignGenres();
        //AssignMaterial();
        AssignEnviroment();
        AssignPlayer();
        //UpdatePlayer();
        UpdateAnimations();

        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeTotal();
            AssignGenres();
            ReassignGenres();
            //AssignMaterial();
            //ShowVariations();
            CheckTotal();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetColours = true;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SetColours = false;
        }

        if (SetColours)
        {
            AssignColours();
        }
        else
        {
            AssignMaterial();
        }

        if (indEnjoyLevel <= -25f)
        {
            indEnjoyLevel = -25f;
        }
        if (indEnjoyLevel >= 25f)
        {
            indEnjoyLevel = 25f;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            loop = true;
            eventOne = true;
            if(loopOne)
            {
                ChangeTotal();
                AssignGenres();
                ReassignGenres();
                CheckTotal();
                AssignMaterial();
            }
        }
        if (loop)
        {
            StartCoroutine(MoveToGenre());
        }

        if (startRock)
        {
            UpdateRockReaction();
        }
        if (startPop)
        {
            UpdatePopReaction();
        }
        if (startCountry)
        {
            UpdateCountryReaction();
        }
        if (startMetal)
        {
            UpdateMetalReaction();
        }
    }

    IEnumerator MoveToGenre()
    {
        if (eventOne)
        {
            if (firstGenre == 1)
            {
                //walking = true;
                agent.destination = rockArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyRockLevel = Player.playerRockGameplay;
                startRock = true;
                yield return new WaitForSeconds(20);
                startRock = false;
            }
            else if (firstGenre == 2)
            {
                //walking = true;
                agent.destination = popArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyPopLevel = Player.playerPopGameplay;
                startPop = true;
                yield return new WaitForSeconds(20);
                startPop = false;
            }
            else if (firstGenre == 3)
            {
                //walking = true;
                agent.destination = countryArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyCountryLevel = Player.playerCountryGameplay;
                startCountry = true;
                yield return new WaitForSeconds(20);
                startCountry = false;
            }
            else if (firstGenre == 4)
            {
                //walking = true;
                agent.destination = metalArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyMetalLevel = Player.playerMetalGameplay;
                startMetal = true;
                yield return new WaitForSeconds(20);
                startMetal = false;
            }

            eventOne = false;
            eventTwo = true;
        }

        if (eventTwo)
        {
            if (secondGenre == 1)
            {
                //walking = true;
                agent.destination = rockArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyRockLevel = Player.playerRockGameplay;
                startRock = true;
                yield return new WaitForSeconds(20);
                startRock = false;
            }
            else if (secondGenre == 2)
            {
                //walking = true;
                agent.destination = popArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyPopLevel = Player.playerPopGameplay;
                startPop = true;
                yield return new WaitForSeconds(20);
                startPop = false;
            }
            else if (secondGenre == 3)
            {
                //walking = true;
                agent.destination = countryArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyCountryLevel = Player.playerCountryGameplay;
                startCountry = true;
                yield return new WaitForSeconds(20);
                startCountry = false;
            }
            else if (secondGenre == 4)
            {
                //walking = true;
                agent.destination = metalArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyMetalLevel = Player.playerMetalGameplay;
                startMetal = true;
                yield return new WaitForSeconds(20);
                startMetal = false;
            }

            eventTwo = false;
            eventThree = true;
        }

        if (eventThree)
        {
            if (thirdGenre == 1)
            {
                //walking = true;
                agent.destination = rockArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyRockLevel = Player.playerRockGameplay;
                startRock = true;
                yield return new WaitForSeconds(20);
                startRock = false;
            }
            else if (thirdGenre == 2)
            {
                //walking = true;
                agent.destination = popArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyPopLevel = Player.playerPopGameplay;
                startPop = true;
                yield return new WaitForSeconds(20);
                startPop = false;
            }
            else if (thirdGenre == 3)
            {
                //walking = true;
                agent.destination = countryArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyCountryLevel = Player.playerCountryGameplay;
                startCountry = true;
                yield return new WaitForSeconds(20);
                startCountry = false;
            }
            else if (thirdGenre == 4)
            {
                //walking = true;
                agent.destination = metalArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyMetalLevel = Player.playerMetalGameplay;
                startMetal = true;
                yield return new WaitForSeconds(20);
                startMetal = false;
            }


            eventThree = false;
            eventFour = true;
        }

        if (eventFour)
        {
            if (fourthGenre == 1)
            {
                //walking = true;
                agent.destination = rockArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyRockLevel = Player.playerRockGameplay;
                startRock = true;
                yield return new WaitForSeconds(20);
                startRock = false;
            }
            else if (fourthGenre == 2)
            {
                //walking = true;
                agent.destination = popArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyPopLevel = Player.playerPopGameplay;
                startPop = true;
                yield return new WaitForSeconds(20);
                startPop = false;
            }
            else if (fourthGenre == 3)
            {
                //walking = true;
                agent.destination = countryArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyCountryLevel = Player.playerCountryGameplay;
                startCountry = true;
                yield return new WaitForSeconds(20);
                startCountry = false;
            }
            else if (fourthGenre == 4)
            {
                //walking = true;
                agent.destination = metalArea.transform.position;
                yield return new WaitForSeconds(10);
                //walking = false;
                enjoyMetalLevel = Player.playerMetalGameplay;
                startMetal = true;
                yield return new WaitForSeconds(20);
                startMetal = false;
            }

            eventFour = false;

            if (!eventOne && !eventTwo && !eventThree && !eventFour)
            {
                agent.destination = playerStartPos;
                loop = false;
                loopOne = true;
            }
        }
    }

    private void AssignColours()
    {
        if (indEnjoyLevel > 15)
        {
            body.GetComponent<Renderer>().material = Green;
        }
        else if (indEnjoyLevel < -15)
        {
            body.GetComponent<Renderer>().material = Red;
        }
        else
        {
            body.GetComponent<Renderer>().material = Yellow;
        }
    }
    private void AssignGenres()
    {
        firstGenre = Random.Range(1, 5);
        secondGenre = Random.Range(1, 5);
        thirdGenre = Random.Range(1, 5);
        fourthGenre = Random.Range(1, 5);
    }
    private void ReassignGenres()
    {
        if (secondGenre == firstGenre)
        {
            secondGenre = Random.Range(1, 5);
        }

        if (thirdGenre == secondGenre || thirdGenre == firstGenre)
        {
            thirdGenre = Random.Range(1, 5);
        }

        if (fourthGenre == thirdGenre || fourthGenre == secondGenre || fourthGenre == firstGenre)
        {
            fourthGenre = Random.Range(1, 5);
        }
    }
    private void AssignMaterial()
    {
        if (firstGenre == 1)
        {
            body.GetComponent<Renderer>().material = rock;
        }
        if (firstGenre == 2)
        {
            body.GetComponent<Renderer>().material = pop;
        }
        if (firstGenre == 3)
        {
            body.GetComponent<Renderer>().material = country;
        }
        if (firstGenre == 4)
        {
            body.GetComponent<Renderer>().material = metal;
        }

    }
    private void AssignEnviroment()
    {
        enviroGenre = Environment.enviroGenre;
    }
    private void UpdateRockReaction()
    {
        if (enjoyRockLevel >= 0)
        {
            if (firstGenre == 1)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyRockLevel * 0.0004f);
            }
            if (secondGenre == 1)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyRockLevel * 0.0003f);
            }
            if (thirdGenre == 1)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyRockLevel * 0.0002f);
            }
            if (fourthGenre == 1)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyRockLevel * 0.0001f);
            }
        }
        if (enjoyRockLevel <= -1)
        {
            if (firstGenre == 1)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyRockLevel * 0.0001f);
            }
            if (secondGenre == 1)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyRockLevel * 0.0002f);
            }
            if (thirdGenre == 1)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyRockLevel * 0.0003f);
            }
            if (fourthGenre == 1)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyRockLevel * 0.0004f);
            }
        }
    }
    private void UpdatePopReaction()
    {
        if (enjoyPopLevel >= 0)
        {
            if (firstGenre == 2)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyPopLevel * 0.0004f);
            }
            if (secondGenre == 2)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyPopLevel * 0.0003f);
            }
            if (thirdGenre == 2)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyPopLevel * 0.0002f);
            }
            if (fourthGenre == 2)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyPopLevel * 0.0001f);
            }
        }
        if (enjoyPopLevel <= -1)
        {
            if (firstGenre == 2)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyPopLevel * 0.0001f);
            }
            if (secondGenre == 2)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyPopLevel * 0.0002f);
            }
            if (thirdGenre == 2)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyPopLevel * 0.0003f);
            }
            if (fourthGenre == 2)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyPopLevel * 0.0004f);
            }
        }
    }
    private void UpdateCountryReaction()
    {
        if (enjoyCountryLevel >= 0)
        {
            if (firstGenre == 3)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyCountryLevel * 0.0004f);
            }
            if (secondGenre == 3)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyCountryLevel * 0.0003f);
            }
            if (thirdGenre == 3)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyCountryLevel * 0.0002f);
            }
            if (fourthGenre == 3)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyCountryLevel * 0.0001f);
            }
        }
        if (enjoyCountryLevel <= -1)
        {
            if (firstGenre == 3)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyCountryLevel * 0.0001f);
            }
            if (secondGenre == 3)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyCountryLevel * 0.0002f);
            }
            if (thirdGenre == 3)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyCountryLevel * 0.0003f);
            }
            if (fourthGenre == 3)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyCountryLevel * 0.0004f);
            }
        }
    }
    private void UpdateMetalReaction()
    {
        if (enjoyMetalLevel >= 0)
        {
            if (firstGenre == 4)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyMetalLevel * 0.0004f);
            }
            if (secondGenre == 4)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyMetalLevel * 0.0003f);
            }
            if (thirdGenre == 4)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyMetalLevel * 0.0002f);
            }
            if (fourthGenre == 4)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyMetalLevel * 0.0001f);
            }
        }
        if (enjoyMetalLevel <= -1)
        {
            if (firstGenre == 4)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyMetalLevel * 0.0001f);
            }
            if (secondGenre == 4)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyMetalLevel * 0.0002f);
            }
            if (thirdGenre == 4)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyMetalLevel * 0.0003f);
            }
            if (fourthGenre == 4)
            {
                indEnjoyLevel = indEnjoyLevel + (enjoyMetalLevel * 0.0004f);
            }
        }
    }
    private void UpdatePlayer()
    {
        if (enjoyMainLevel >= 0)
        {
            if (enviroGenre == firstGenre)
            {
                //this.transform.position = new Vector3(transform.position.x + (enjoyLevel * 0.004f), transform.position.y, transform.position.z);
                indEnjoyLevel = indEnjoyLevel + (enjoyMainLevel * 0.0004f);
            }
            if (enviroGenre == secondGenre)
            {
                //this.transform.position = new Vector3(transform.position.x + (enjoyLevel * 0.003f), transform.position.y, transform.position.z);
                indEnjoyLevel = indEnjoyLevel + (enjoyMainLevel * 0.0003f);
            }
            if (enviroGenre == thirdGenre)
            {
                //this.transform.position = new Vector3(transform.position.x + (enjoyLevel * 0.002f), transform.position.y, transform.position.z);
                indEnjoyLevel = indEnjoyLevel + (enjoyMainLevel * 0.0002f);
            }
            if (enviroGenre == fourthGenre)
            {
                //this.transform.position = new Vector3(transform.position.x + (enjoyLevel * 0.001f), transform.position.y, transform.position.z);
                indEnjoyLevel = indEnjoyLevel + (enjoyMainLevel * 0.0001f);
            }
        }
        if (enjoyMainLevel <= -1)
        {
            if (enviroGenre == firstGenre)
            {
                //this.transform.position = new Vector3(transform.position.x + (enjoyLevel * 0.001f), transform.position.y, transform.position.z);
                indEnjoyLevel = indEnjoyLevel + (enjoyMainLevel * 0.0001f);
            }
            if (enviroGenre == secondGenre)
            {
                //this.transform.position = new Vector3(transform.position.x + (enjoyLevel * 0.002f), transform.position.y, transform.position.z);
                indEnjoyLevel = indEnjoyLevel + (enjoyMainLevel * 0.0002f);
            }
            if (enviroGenre == thirdGenre)
            {
                //this.transform.position = new Vector3(transform.position.x + (enjoyLevel * 0.003f), transform.position.y, transform.position.z);
                indEnjoyLevel = indEnjoyLevel + (enjoyMainLevel * 0.0003f);
            }
            if (enviroGenre == fourthGenre)
            {
                //this.transform.position = new Vector3(transform.position.x + (enjoyLevel * 0.004f), transform.position.y, transform.position.z);
                indEnjoyLevel = indEnjoyLevel + (enjoyMainLevel * 0.0004f);
            }
        }

    }
    private void AssignPlayer()
    {
        enjoyMainLevel = Player.playerMainGameplay;
        enjoyRockLevel = Player.playerRockGameplay;
        enjoyPopLevel = Player.playerPopGameplay;
        enjoyCountryLevel = Player.playerCountryGameplay;
        enjoyMetalLevel = Player.playerMetalGameplay;
    }
    private void ShowVariations()
    {
        if (enviroGenre == firstGenre)
        {
            this.transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        }
        if (enviroGenre == secondGenre)
        {
            this.transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }
        if (enviroGenre == thirdGenre)
        {
            this.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
        if (enviroGenre == fourthGenre)
        {
            this.transform.position = new Vector3(transform.position.x, -5, transform.position.z);
        }
    }

    private void CheckTotal()
    {
        //First Genre
        if (firstGenre == 1)
        {
            rockTotal++;
        }
        if (firstGenre == 2)
        {
            popTotal++;
        }
        if (firstGenre == 3)
        {
            countryTotal++;
        }
        if (firstGenre == 4)
        {
            metalTotal++;
        }
        // Second Genre
        if (secondGenre == 1)
        {
            secondRock++;
        }
        if (secondGenre == 2)
        {
            secondPop++;
        }
        if (secondGenre == 3)
        {
            secondCountry++;
        }
        if (secondGenre == 4)
        {
            secondMetal++;
        }
        // Third Genre
        if (thirdGenre == 1)
        {
            thirdRock++;
        }
        if (thirdGenre == 2)
        {
            thirdPop++;
        }
        if (thirdGenre == 3)
        {
            thirdCountry++;
        }
        if (thirdGenre == 4)
        {
            thirdMetal++;
        }
        // Fourth Genre
        if (fourthGenre == 1)
        {
            fourthRock++;
        }
        if (fourthGenre == 2)
        {
            fourthPop++;
        }
        if (fourthGenre == 3)
        {
            fourthCountry++;
        }
        if (fourthGenre == 4)
        {
            fourthMetal++;
        }
    }

    private void ChangeTotal()
    {
        if (firstGenre == 1)
        {
            rockTotal--;
        }
        if (firstGenre == 2)
        {
            popTotal--;
        }
        if (firstGenre == 3)
        {
            countryTotal--;
        }
        if (firstGenre == 4)
        {
            metalTotal--;
        }
        // Second Genre
        if (secondGenre == 1)
        {
            secondRock--;
        }
        if (secondGenre == 2)
        {
            secondPop--;
        }
        if (secondGenre == 3)
        {
            secondCountry--;
        }
        if (secondGenre == 4)
        {
            secondMetal--;
        }
        // Third Genre
        if (thirdGenre == 1)
        {
            thirdRock--;
        }
        if (thirdGenre == 2)
        {
            thirdPop--;
        }
        if (thirdGenre == 3)
        {
            thirdCountry--;
        }
        if (thirdGenre == 4)
        {
            thirdMetal--;
        }
        // Fourth Genre
        if (fourthGenre == 1)
        {
            fourthRock--;
        }
        if (fourthGenre == 2)
        {
            fourthPop--;
        }
        if (fourthGenre == 3)
        {
            fourthCountry--;
        }
        if (fourthGenre == 4)
        {
            fourthMetal--;
        }
    }

    private void UpdateAnimations()
    {
        anim.SetFloat("Enjoyment", indEnjoyLevel);
        anim.SetBool("Walking", walking);
    }

    
}
