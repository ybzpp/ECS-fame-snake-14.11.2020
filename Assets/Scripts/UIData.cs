using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIData : MonoBehaviour
{
    public GameObject UIScreen;

    public Button GameScreenButton;
    public Button ControllScreenButton;
    public Button BackButton;
    public GameObject UIGameLine;
    public GameObject UIControllLine;

    //ui game screen
    public GameObject UIGameScreen;

    public TextMeshProUGUI ScoreValueText;
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI GridSizeText;
    public TextMeshProUGUI TimeText;

    public TextMeshProUGUI TailLengthText;
    public Button TailLengthButtonPlus;
    public Button TailLengthButtonMinus;

    public TextMeshProUGUI FoodToLevelMaxText;
    public Button FoodToLevelMaxPlus;
    public Button FoodToLevelMaxMinus;

    public TextMeshProUGUI SpeedText;
    public Slider SpeedSlider;
    public TextMeshProUGUI DirectionText;
    public TextMeshProUGUI CameraText;

    //ui controll screen
    public GameObject UIControllScreen;

    //ui ingame
    public GameObject UIScreenInGame;
    public Button UIButtonSettingInGame;
    public Button UIButtonRestartInGame;
    public Button UIButtonCameraInGame;
    public TextMeshProUGUI ScoreValueIngameText;

    private void Start()
    {
        GameScreenView();
    }

    public void UIScreenView(bool value)
    {
        UIScreen.SetActive(value);
    }
    public void UIScreenView()
    {
        UIScreen.SetActive(false);
    }


    public void ControllScreenView()
    {
        if (UIGameLine.activeSelf)
            UIGameLine.SetActive(false);

        if (UIGameScreen.activeSelf)
            UIGameScreen.SetActive(false);

        if (!UIControllLine.activeSelf)
            UIControllLine.SetActive(true);

        if (!UIControllScreen.activeSelf)
            UIControllScreen.SetActive(true);

    }
    public void GameScreenView()
    {
        if (!UIGameLine.activeSelf)
            UIGameLine.SetActive(true);

        if (!UIGameScreen.activeSelf)
            UIGameScreen.SetActive(true);

        if (UIControllLine.activeSelf)
            UIControllLine.SetActive(false);

        if (UIControllScreen.activeSelf)
            UIControllScreen.SetActive(false);
    }  


    


}    



