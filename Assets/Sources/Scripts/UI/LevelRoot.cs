using UnityEngine;
using TMPro;

public class LevelRoot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelTxt;
    [SerializeField] private GameObject[] _levels;

    private int _initLevelNum = 1;

    public int Level { get; private set; }

    private void OnEnable()
    {
        Level = (PlayerPrefs.GetInt("Level") == 0) ? _initLevelNum : PlayerPrefs.GetInt("Level");
        ChangeLevelText();

        EnableLevel();
    }

    private void ChangeLevelText()
    {
        _levelTxt.text = "Level " + Level.ToString();
    }

    private void EnableLevel()
    {
        for(int i =  0; i < _levels.Length; i++)
        {
            _levels[i].SetActive(false);
        }
        _levels[(Level - 1) % _levels.Length].SetActive(true);
    }

    public void NewLevel()
    {
        Level++;
        PlayerPrefs.SetInt("Level", Level);
    }
}
