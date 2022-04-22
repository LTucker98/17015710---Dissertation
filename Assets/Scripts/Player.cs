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

    private static int rockTotal, popTotal, countryTotal, metalTotal;
    private static int secondRock, secondPop, secondCountry, secondMetal;
    private static int thirdRock, thirdPop, thirdCountry, thirdMetal;
    private static int fourthRock, fourthPop, fourthCountry, fourthMetal;

    [SerializeField] public TextMeshProUGUI[] genreTotal;
    [SerializeField] public TextMeshProUGUI[] currentTotal;
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
        }
        if (eventTwo)
        {
            currentTotal[0].text = "Rock: " + secondRock;
            currentTotal[1].text = "Pop: " + secondPop;
            currentTotal[2].text = "Country: " + secondCountry;
            currentTotal[3].text = "Metal: " + secondMetal;
        }
        if (eventThree)
        {
            currentTotal[0].text = "Rock: " + thirdRock;
            currentTotal[1].text = "Pop: " + thirdPop;
            currentTotal[2].text = "Country: " + thirdCountry;
            currentTotal[3].text = "Metal: " + thirdMetal;
        }
        if (eventFour)
        {
            currentTotal[0].text = "Rock: " + fourthRock;
            currentTotal[1].text = "Pop: " + fourthPop;
            currentTotal[2].text = "Country: " + fourthCountry;
            currentTotal[3].text = "Metal: " + fourthMetal;
        }
        else if (!eventOne && !eventTwo && !eventThree && !eventFour)
        {
            currentTotal[0].text = "Rock: 0";
            currentTotal[1].text = "Pop: 0";
            currentTotal[2].text = "Country: 0";
            currentTotal[3].text = "Metal: 0";
        }
    }

}

