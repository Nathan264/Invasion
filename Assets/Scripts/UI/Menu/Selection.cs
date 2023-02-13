using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    [SerializeField] private CharInfo charInfo;
    [SerializeField] private PlayerData pData;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject charMainContainer;
    [SerializeField] private GameObject charBtnPrefab;
    [SerializeField] private List<Char> chars;
    [SerializeField] private Vector3 initialPos;
    [SerializeField] private Vector3 plusPos;
    [SerializeField] private Image selectionImage;
    

    private void Start()
    {
        ClearCharInfo();
        GenerateCharContainers();
    }

    private void GenerateCharContainers()
    {
        
        for (int i = 0; i < chars.Count; i++)
        {   
            GameObject tmp = Instantiate(charBtnPrefab);

            tmp.transform.SetParent(charMainContainer.transform);
                    
            Char btnChar = chars[i];

            tmp.GetComponent<RectTransform>().localPosition = initialPos;
            tmp.GetComponent<Image>().sprite = chars[i].charSprite;
            Button btn = tmp.GetComponent<Button>();
            btn.onClick.AddListener(() => SelectChar(btnChar));
            btn.onClick.AddListener(() => PlaceCursor(btn));

            if (i == 0)
            {
                SelectChar(btnChar);
                PlaceCursor(btn);
            }

            initialPos += plusPos;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Lvl1");
    }

    public void BackToMenu()
    {
        gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void SelectChar(Char selectedChar)
    {
        pData.SelectedChar = selectedChar;
        charInfo.UpdateCharInfo();
    }

    private void PlaceCursor(Button btn)
    {
        selectionImage.gameObject.SetActive(true);
        selectionImage.transform.SetParent(btn.transform);
        selectionImage.GetComponent<RectTransform>().localPosition = new Vector3(0, 40, 0);
    }    

    private void ClearCharInfo()
    {
        pData.SelectedChar = null;
    }
}
