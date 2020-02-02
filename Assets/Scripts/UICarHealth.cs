using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICarHealth : MonoBehaviour
{
    public static UICarHealth instance { get; private set; }
    public List<Image> aGrid = new List<Image>();
    public Image HP1;
    public Image HP2;
    public Image HP3;
    public Image HP4;
    public Image HP5;
    public Image HP6;
    public Image HP7;
    public Image HP8;
    public Image HP9;
    public Image HP10;
    public Text display;
    void Start()
    {
        aGrid.Add(HP1);
        aGrid.Add(HP2);
        aGrid.Add(HP3);
        aGrid.Add(HP4);
        aGrid.Add(HP5);
        aGrid.Add(HP6);
        aGrid.Add(HP7);
        aGrid.Add(HP8);
        aGrid.Add(HP9);
        aGrid.Add(HP10);
    }

    public void UpdateValues(int health)
    {
        display.text = ""+health;
        for(int n = 0; n < 10; n++) 
         aGrid[n].enabled = (health/10 > n);
    }
}
