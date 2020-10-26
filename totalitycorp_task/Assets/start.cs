using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    //public FlexibleColorPicker f;
    public ColorPickerTriangle c;
    public Camera cam;
    public manger man;
    private bool t=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
           cam.backgroundColor = c.TheColor;
        
    }
   public void get_in()
    {
        man.enabled = true;
    }
    public void menu()
    {
        
        man.enabled = false;
    }

    public void bgclick()
    {
        man.enabled = false;
    }
    public void back()
    {
        man.enabled = true;

    }
}
