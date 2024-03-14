using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private int _doorOpened;
    private bool _bossAccessible;

    [SerializeField] public List<DoorManager> Doors;
    private List<bool> _doorsBool = new List<bool>();

    // Start is called before the first frame update
    void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this);


        _doorOpened = 0;
        Doors = new List<DoorManager>();
    }

    private void Start()
    {
        foreach (DoorManager doors in Doors)
        {
            doors.OnDoorOpened += DoorOpened;
            _doorsBool.Add(false);
        }
    }

    public void DoorOpened(DoorManager door)
    {
        _doorsBool[Doors.IndexOf(door)] = true;

        if (_doorsBool.All(element => element == true))
            UnlockBoss();
        
    }

    private void UnlockBoss()
    {
        //TO DO;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
