using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.IO;

struct Menu{
    public GameObject gameObject;
    public int ID;

    public Menu(GameObject p_gameObject, int p_menuID){
        gameObject = p_gameObject;
        ID = p_menuID;
    }
}

public class MenuManager : MonoBehaviour
{

    static MenuManager m_instance;

    static public MenuManager Instance
    {
        get { return m_instance; }
        private set { }
    }
    [SerializeField] GameObject[] m_menuReferences;
    Menu[] m_menu;
    Stack<Menu> m_menuStack;
    [SerializeField] int m_initialMenu;
    int m_currentMenu;
    bool[] m_isMenuInStack;
    bool m_isMenuActive = true;

    private void Awake() {
        if(m_instance == null){m_instance = this; }
        else { Destroy(this.gameObject) ;}
        m_menuStack = new Stack<Menu>();
        m_menu = new Menu[m_menuReferences.Length];
        m_isMenuInStack = new bool[m_menu.Length];
        InitializeMenu();
        
    }
    
    private void Update() {
        if(m_isMenuActive){
            if(Input.GetKeyDown(KeyCode.Escape)){
                GoBack();
            }
        }
    }

    void InitializeMenu(){
        m_currentMenu = m_initialMenu;

        for(int menuIndex = 0; menuIndex < m_menu.Length; menuIndex++){
            Menu menu = new Menu(m_menuReferences[menuIndex], menuIndex);
            m_menu[menuIndex] = menu;
            // DOUBLE CHECK TO AVOID PROBLEM WITH ACTIVE/INACTIVE GAMEOBJECTS AS LONG AS THE REFERENCES ARE SET PROPERLY
            bool isInitialMenu = false;
            if(menuIndex != (int)m_currentMenu){
                isInitialMenu = false;
            }
            else {
                isInitialMenu = true;
                m_menuStack.Push(menu);
            }
            // THE ONLY MENU IN THE STACK IS THE INITIAL MENU
            m_isMenuInStack[menuIndex] = isInitialMenu;
            m_menu[menuIndex].gameObject.SetActive(isInitialMenu);
        }
    }

    public void GoTo(int p_menu){
        // SINCE THERE IS ONLY 1 INSTANCE OF EVERY MENU AVAILABLE, IF IT'S ALREADY IN THE STACK IT CANNOT BE CHARGED/TRANSITION TO AGAIN
        // THE ONLY WAY TO GO BACK TO THE MENU WOULD BE GOING BACK TILL WE REACH IT AGAIN
        // TODO - IF WE WANT TO MOVE BACKWARS TO AN ALREADY EXISTING MENU IN THE STACK WE WOULD NEED TO POP ALL THE MENUS 
        if(m_isMenuInStack[(int)p_menu]) {
            int currentMenuID = m_menuStack.Pop().ID;
             while(currentMenuID != p_menu){
                 m_menuStack.Peek().gameObject.SetActive(false);
                 m_menuStack.Pop();
                 m_isMenuInStack[currentMenuID] = false;
                 currentMenuID = m_menuStack.Pop().ID;
             }
        }
        else
        {
            m_isMenuInStack[m_menuStack.Peek().ID] = false;
            m_menuStack.Peek().gameObject.SetActive(false);

            m_menuStack.Push(m_menu[p_menu]);
            m_menuStack.Peek().gameObject.SetActive(true);
            m_isMenuInStack[p_menu] = true;
        }
    }

    public void GoBack(){
        if(m_menuStack.Count == 1) { return ;}
        // SET CURRENT MENU TO INACTIVE
        m_menuStack.Peek().gameObject.SetActive(false);
        m_isMenuInStack[m_menuStack.Peek().ID] = false;
        m_menuStack.Pop();
        // SET LAST MENU TO ACTIVE
        m_menuStack.Peek().gameObject.SetActive(true);
    }
    
}

