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

    public void MakeScoreBoard(string score) {
        //make the textfield clear so we can put a new score in them
        namesFieldTextField.text = "";
        scoresTextField.text = "";

        string[] myStr = score.Trim().Split('\n');

        foreach (string text in myStr) {
            string[] myStr2 = text.Split('_');
            namesFieldTextField.text += myStr2[0] + "\n";
            scoresTextField.text += myStr2[1] + "\n";
        }
    }

    public void MakeTimeBoard(string score)
    {

        string[] myStr = score.Trim().Split('\n');

        foreach (string text in myStr)
        {
            string[] myStr2 = text.Split('_');
            namesFieldTextField.text += myStr2[1] + "\n";
            int stringCounter = 1;

            List<char> min = new List<char>();
            List<char> sec = new List<char>();
            List<char> frac = new List<char>();

            foreach (char character in myStr2[0])
            {
                if (stringCounter < 3) min.Add(character);
                else if (stringCounter < 5) sec.Add(character);//sec
                else frac.Add(character);//frac
                stringCounter++;

            }

            string minStr = new string(min.ToArray());
            string secStr = new string(sec.ToArray());
            string fracStr = new string(frac.ToArray());
            var time = string.Format("{0:00}:{1:00}:{2:00}", minStr, secStr, fracStr);
            scoresTextField.text += time + "\n";
        }
    }
}
