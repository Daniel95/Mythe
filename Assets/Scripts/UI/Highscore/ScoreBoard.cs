using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    private SaveData saveData;

    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private Text playerRankText;

    [SerializeField]
    private Text pageNumberText;

    [SerializeField]
    private int scoresPerPage = 10;

    private int pageNumber = 1;

    private int maxPageNumber;

    private bool isTimeData;

    private string savedScores;

    private string[] dataLines;

    private Text namesFieldTextField;
    private Text scoresTextField;

    void Awake()
    {
        namesFieldTextField = gameOverScreen.transform.Find("NamesField").GetComponent<Text>();
        scoresTextField = gameOverScreen.transform.Find("ScoresField").GetComponent<Text>();
    }

    private void MakeABoard(List<string> _score, bool _isTimeData) {
        //make the textfield clear so we can put a new score in them
        namesFieldTextField.text = "";
        scoresTextField.text = "";

        isTimeData = _isTimeData;

        int startRank = (pageNumber * scoresPerPage) - scoresPerPage + 1;

        if (_isTimeData)
            MakeTimeBoard(_score, startRank);
        else
            MakeScoreBoard(_score, startRank);
    }

    private void MakeScoreBoard(List<string> _score, int _startRank) {
        //the rank where i show at which place this score is in de leaderboards
        int rank = _startRank;

        foreach (string text in _score) {
            string[] myStr2 = text.Split('_');
            namesFieldTextField.text += rank.ToString() + ". " + myStr2[0] + "\n";
            scoresTextField.text += myStr2[1] + "\n";

            rank++;
        }
    }
    
    private void MakeTimeBoard(List<string> _score, int _startRank)
    {
        //the rank where i show at which place this score is in de leaderboard
        int rank = _startRank;

        foreach (string text in _score)
        {
            //split the names and time in a string array
            string[] namesAndTimes = text.Split('_');

            //add all the names to the scoreboard
            namesFieldTextField.text += rank.ToString() + ". " + namesAndTimes[0] + "\n";

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

            rank++;
        }
    }
    /*
    public void GetPlayerRanking(string _scoreType)
    {
        //only do this if saveData is not null,
        //if it is null, it means we are in the highscore scene and not the game scene
        if (saveData != null)
        {
            int scoreReached = 0;
            print(_scoreType);
            for (int i = 0; i < DataTypes.dataTypeNames.Length; i++)
            {
                if (_scoreType == DataTypes.dataTypeNames[i])
                {
                    scoreReached = saveData.DataTypeValues[i];
                }
            }

            //this is the score we are looking for
            string plrScore = saveData.PlayerName + "_" + scoreReached.ToString();

            print(plrScore);

            for (int m = 0; m < dataLines.Length; m++) {
                //compare every score, until we get our own. 
                if (plrScore == dataLines[m])
                {
                    playerRankText.text = (m + 1).ToString();
                    break;
                }
            }
        }
    }*/

    public void GetPlayerRanking(string _scoreType)
    {
        //only do this if saveData is not null,
        //if it is null, it means we are in the highscore scene and not the game scene
        if (saveData != null)
        {
            for (int i = 0; i < dataLines.Length; i++) {
                string[] splitLines = dataLines[i].Split('_');
                if (splitLines[0] == saveData.PlayerName) {
                    playerRankText.text = (i + 1).ToString();
                    break;
                }
            }
        }
    }

    public List<string> CutLines(string _uncutScore)
    {
        //split all the lines in a array
        dataLines = _uncutScore.Trim().Split('\n');

        //calculate the max page number
        maxPageNumber = Mathf.CeilToInt(dataLines.Length / (float)scoresPerPage);

        //make a new list where we will store the selected scores in
        List<string> cuttedLines = new List<string>();

        for (int i = (pageNumber * scoresPerPage) - scoresPerPage; i < (pageNumber * scoresPerPage); i++)
        {
            //if the index (i) isnt higher then the total lines, and not lower then zero
            if (i < dataLines.Length && i >= 0)
                cuttedLines.Add(dataLines[i]);
        }
        //return the results
        return cuttedLines;
    }

    public void ChangePageNumber(int _change)
    {
        //change the page number
        pageNumber += _change;

        //check if it isnt out of range
        if (pageNumber > maxPageNumber)
            pageNumber = 1;
        else if (pageNumber < 1)
            pageNumber = maxPageNumber;

        pageNumberText.text = pageNumber.ToString();

        //make the new page, with the same string only differently cut.
        MakeABoard(CutLines(savedScores), isTimeData);
    }

    public void NewScoreBoard(string _score, string _scoreType)
    {
        //reset the page
        pageNumber = 1;

        //update the ui
        pageNumberText.text = pageNumber.ToString();

        //save the current loaded scores in savedScores
        savedScores = _score;

        //if the dataType is Time, make a special board.
        if (_scoreType == "time")
            MakeABoard(CutLines(_score), true);
        else //else make a normal board
            MakeABoard(CutLines(_score), false);
    }
}
