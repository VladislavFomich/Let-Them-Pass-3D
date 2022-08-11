using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LvlCanvasView : MonoBehaviour
{
    [SerializeField] private TMP_Text lvlNumText;
    [SerializeField] private TMP_Text lvlMovesText;


    private ManageScene _manageScene;
    private int _moves;
    private void Awake()
    {
        _manageScene = GetComponent<ManageScene>();
    }
    private void Start()
    {
        lvlNumText.text = _manageScene.ThisSceneNum.ToString();
        lvlMovesText.text = "0";
    }

    public void UpMovesNum()
    {
        _moves++;
       lvlMovesText.text = _moves.ToString();
    }

}
