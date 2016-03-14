using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen;

    //private Text totalDeathsTextField;
    //private Text myDeathsTextField;
    private Text namesFieldTextField;
    private Text scoresTextField;

    void Awake()
    {
        //highScore = GetComponent<Highscore>();
        //totalDeathsTextField = transform.Find("TotalDeathCounter").GetComponent<Text>();
        //myDeathsTextField = transform.Find("MyDeaths").GetComponent<Text>();
        namesFieldTextField = gameOverScreen.transform.Find("NamesField").GetComponent<Text>();
        scoresTextField = gameOverScreen.transform.Find("ScoresField").GetComponent<Text>();
    }

    public void MakeABoard(string _score, string _scoreType) {
        //make the textfield clear so we can put a new score in them
        namesFieldTextField.text = "";
        scoresTextField.text = "";

        if (_scoreType == "time")
            MakeTimeBoard(_score);
        else
            MakeScoreBoard(_score);
    }

    private void MakeScoreBoard(string _score) {
        //make the textfield clear so we can put a new score in them
        namesFieldTextField.text = "";
        scoresTextField.text = "";

        string[] myStr = _score.Trim().Split('\n');

        foreach (string text in myStr) {
            string[] myStr2 = text.Split('_');
            namesFieldTextField.text += myStr2[0] + "\n";
            scoresTextField.text += myStr2[1] + "\n";
        }
    }



    
    private void MakeTimeBoard(string _score)
    {
        //split each line into a string array
        string[] lines = _score.Trim().Split('\n');
        
        foreach (string text in lines)
        {
            //split the names and time in a string array
            string[] namesAndTimes = text.Split('_');

            //add all the names to the scoreboard
            namesFieldTextField.text += namesAndTimes[0] + "\n";

            //make lists for each time type
            List<char> min = new List<char>();
            List<char> sec = new List<char>();
            List<char> frac = new List<char>();

            //make a char array that we store the time in
            char[] timeArray = namesAndTimes[1].ToCharArray();

            //put the right values in the right list
            for (int i = timeArray.Length - 1; i >= 0; i--)
            {
                if (i > timeArray.Length - 3)
                    frac.Add(timeArray[i]);//fractions
                else if (i > timeArray.Length - 5)
                    sec.Add(timeArray[i]);//seconds
                else
                    min.Add(timeArray[i]);//minutes
            }

            //reverse each list because when they are not added in the right order
            min.Reverse();
            sec.Reverse();
            frac.Reverse();

            var time = string.Format("{0:00}:{1:00}:{2:00}", new string(min.ToArray()), new string(sec.ToArray()), new string(frac.ToArray()));
            scoresTextField.text += time + "\n";
        }
    }
    
}
