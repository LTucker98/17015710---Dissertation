using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int playerMainGameplay = 0;
    public static int playerRockGameplay = 0;
    public static int playerPopGameplay = 0;
    public static int playerCountryGameplay = 0;
    public static int playerMetalGameplay = 0;

    [Range(-50, 50)]
    public int main = 0;

    [Range(-50, 50)]
    public int rock = 0;

    [Range(-50, 50)]
    public int pop = 0;

    [Range(-50, 50)]
    public int country = 0;

    [Range(-50, 50)]
    public int metal = 0;

    public bool eventOne, eventTwo, eventThree, eventFour;

    [Header("First Genre")]
    public int rockTotal;
    public int popTotal;
    public int countryTotal;
    public int metalTotal;

    [Header("Second Genre")]
    public int secondRock;
    public int secondPop;
    public int secondCountry;
    public int secondMetal;

    [Header("Third Genre")]
    public int thirdRock;
    public int thirdPop;
    public int thirdCountry;
    public int thirdMetal;

    [Header("Fourth Genre")]
    public int fourthRock;
    public int fourthPop;
    public int fourthCountry;
    public int fourthMetal;

    [SerializeField] public TextMeshProUGUI[] genreTotal;
    [SerializeField] public TextMeshProUGUI[] currentTotal;
    [SerializeField] public TextMeshProUGUI currentEvent;
    // Start is called before the first frame update
    void Start()
    {
        playerMainGameplay = main;
        playerRockGameplay = rock;
        playerPopGameplay = pop;
        playerCountryGameplay = country;
        playerMetalGameplay = metal;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            main = Random.Range(-25, 26);
            rock = Random.Range(-25, 26);
            pop = Random.Range(-25, 26);
            country = Random.Range(-25, 26);
            metal = Random.Range(-25, 26);
        }
        playerMainGameplay = main;
        playerRockGameplay = rock;
        playerPopGameplay = pop;
        playerCountryGameplay = country;
        playerMetalGameplay = metal;


        eventOne = GenreAssignment.eventOne;
        eventTwo = GenreAssignment.eventTwo;
        eventThree = GenreAssignment.eventThree;
        eventFour = GenreAssignment.eventFour;


        rockTotal = GenreAssignment.rockTotal;
        popTotal = GenreAssignment.popTotal;
        countryTotal = GenreAssignment.countryTotal;
        metalTotal = GenreAssignment.metalTotal;

        secondRock = GenreAssignment.secondRock;
        secondPop = GenreAssignment.secondPop;
        secondCountry = GenreAssignment.secondCountry;
        secondMetal = GenreAssignment.secondMetal;

        thirdRock = GenreAssignment.thirdRock;
        thirdPop = GenreAssignment.thirdPop;
        thirdCountry = GenreAssignment.thirdCountry;
        thirdMetal = GenreAssignment.thirdMetal;

        fourthRock = GenreAssignment.fourthRock;
        fourthPop = GenreAssignment.fourthPop;
        fourthCountry = GenreAssignment.fourthCountry;
        fourthMetal = GenreAssignment.fourthMetal;

        SetUI();
    }
    private void SetUI()
    {
        genreTotal[0].text = "Rock: " + rockTotal;
        genreTotal[1].text = "Pop: " + popTotal;
        genreTotal[2].text = "Country: " + countryTotal;
        genreTotal[3].text = "Metal: " + metalTotal;

        if (eventOne)
        {
            currentTotal[0].text = "Rock: " + rockTotal;
            currentTotal[1].text = "Pop: " + popTotal;
            currentTotal[2].text = "Country: " + countryTotal;
            currentTotal[3].text = "Metal: " + metalTotal;
            currentEvent.text = "Event: First Genre";
        }
        if (eventTwo)
        {
            currentTotal[0].text = "Rock: " + secondRock;
            currentTotal[1].text = "Pop: " + secondPop;
            currentTotal[2].text = "Country: " + secondCountry;
            currentTotal[3].text = "Metal: " + secondMetal;
            currentEvent.text = "Event: Second Genre";
        }
        if (eventThree)
        {
            currentTotal[0].text = "Rock: " + thirdRock;
            currentTotal[1].text = "Pop: " + thirdPop;
            currentTotal[2].text = "Country: " + thirdCountry;
            currentTotal[3].text = "Metal: " + thirdMetal;
            currentEvent.text = "Event: Third Genre";
        }
        if (eventFour)
        {
            currentTotal[0].text = "Rock: " + fourthRock;
            currentTotal[1].text = "Pop: " + fourthPop;
            currentTotal[2].text = "Country: " + fourthCountry;
            currentTotal[3].text = "Metal: " + fourthMetal;
            currentEvent.text = "Event: Fourth Genre";
        }
        else if (!eventOne && !eventTwo && !eventThree && !eventFour)
        {
            currentTotal[0].text = "Rock: 0";
            currentTotal[1].text = "Pop: 0";
            currentTotal[2].text = "Country: 0";
            currentTotal[3].text = "Metal: 0";
            currentEvent.text = "Event: None";
        }
    }

}

