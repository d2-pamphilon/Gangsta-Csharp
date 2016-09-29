using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private List<Button> menuItems;
    public int index = 0;   
   
	
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))        
            index = (index + 1 >= menuItems.Count) ? 0 : index + 1;
        
        if (Input.GetKeyDown(KeyCode.UpArrow))        
            index = (index - 1 < 0) ? menuItems.Count -1: index - 1;

        foreach(Button b in menuItems)
        {            
            b.interactable = b != menuItems[index] ? false : true;     
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {          
            menuItems[index].onClick.Invoke();            
        }        
    }

    public void Quit()
    {
        Application.Quit();
    }

}
