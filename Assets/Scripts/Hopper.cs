using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]

public class Hopper : MonoBehaviour
{
    public float force = 5f;
    public float rayLenght = 2f;
    public float lvlEndDealy = 5;
    public float shrinkRate = 0.05f;
    public int bottleToCollet;
    public GameObject sceneChange;
    public GameObject fadeOut;
    public AudioSource bottleOpenSound;
    public AudioSource jumpSound;

    public GameObject gameoverPanel;
    private Rigidbody2D myrb2d;

    private bool moveRight= false;
    private bool canTap = true;
    private Vector3 spwanPosition;

    private GameObject[] virus_bg;
    private int index = 0;

    private Timer timer;
    public float gameTime = 125;
    public float awardTime = 125;
    public Animator timerAnim;

    private bool animPlayed = false;

    public GameObject playerHolder;
    public GameObject playerHolderToHide;

    public Text timeTxt;


    // logic for Size choosing
    private float[] playerSize =  {0.9f, 0.8f, 0.7f , 0.6f};
    public Sprite[] playerSprite;
    private SpriteRenderer spriteRenderer;

    private int currentSizeIndex = 0;


    // Google Add

     private admobdemo googleAdScript;

     // hints

     public Text hintText;

     [Range(10,20)]
     public int hintShowModulo;
     public Animator hintTexAnim;

     private bool hintShown = false;

    // Start is called before the first frame update
    void Start()
    {
        /* prepare the timer*/
        timer = new Timer(gameTime , true);
        DisplayAd();
        spwanPosition = transform.position;
        myrb2d = GetComponent<Rigidbody2D>();
        if(sceneChange==null){
            Debug.LogError("Attach level clear Prefab");
        }
        FindGameObjectsWithTag();
    }

    void FindGameObjectsWithTag()
    {
        bottleToCollet = GameObject.FindGameObjectsWithTag("Bottle").Length;
        bottleOpenSound = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
        jumpSound = GameObject.FindGameObjectWithTag("Jump").GetComponent<AudioSource>();
        virus_bg = GameObject.FindGameObjectsWithTag("Virus_bg");
        spriteRenderer = GetComponent<SpriteRenderer>();

        googleAdScript = GameObject.FindGameObjectWithTag("Google_Ad").GetComponent<admobdemo>();
        googleAdScript.HideBanner();

        transform.localScale = Vector3.one*playerSize[0];
        spriteRenderer.sprite = playerSprite[0];
    }

    // Update is called once per frame
    void Update()
    {
        timer.RunTimer();
        timeTxt.text = timer.TimeRemaining().ToString();
        // optimize this more
        if(timer.IsTimeOut()){
            GameOver();
        }
        if(timer.TimeRemaining() < 11 && !animPlayed){
            animPlayed = true;
            timerAnim.SetTrigger("Alert");
        }

        if(!hintShown && timer.TimeRemaining() >0 && timer.TimeRemaining() % hintShowModulo==0){
            ShowHints();
        }

         if (Input.GetKeyDown(KeyCode.Escape))
                  SceneManager.LoadScene(1);
    }

    public void RightMove(){
        if(!canTap) return;
        jumpSound.Play();
        AddForceRight();
    }

    public void LeftMove()
    {
        if (!canTap) return;
        jumpSound.Play();
        AddForceLeft();
    }

    void AddForceRight(){
        myrb2d.velocity =Vector2.zero;
        myrb2d.AddForce(GetDirectionRight()*force, ForceMode2D.Impulse);
    }

    void AddForceLeft()
    {
        myrb2d.velocity = Vector2.zero;
        myrb2d.AddForce(GetDirectionLeft() * force, ForceMode2D.Impulse);
    }

    Vector2 GetDirectionRight(){
        Vector2 dir = transform.position;
       // Vector2 origin = transform.position;
       
        dir.x =1;
        dir.y =1;

       
        return (dir).normalized;

    }

    Vector2 GetDirectionLeft()
    {
        Vector2 dir = transform.position;
        //   Vector2 origin = transform.position;

        
            dir.x = -1;
            dir.y = 1;
         
      

        return (dir).normalized;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag.Equals("Bottle")) {
            bottleOpenSound.Play();
                Destroy(other.gameObject);
                DestroyVirusOnBackGround();
            if(--bottleToCollet == 0) {
                canTap = false;
               // transform.position = spwanPosition;
                SaveLevelPrefs();
                UTIL.canShowRewardAd = true;
                StartCoroutine(Delay((lvlEndDealy)));
            }
        }
    }


    void DestroyVirusOnBackGround(){
        int max = Random.Range(index , index+5);
        if(max>virus_bg.Length){
            max = virus_bg.Length-1;
        }
        if(max<virus_bg.Length)
        for(int i = index;i<=max;++i){
            virus_bg[i].GetComponent<Rigidbody2D>().gravityScale = 1;
            Destroy(virus_bg[i] , 3f);
            index++;
        }
    }

     IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(0.05f);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
       // Instantiate(sceneChange);
       // yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(UTIL.lvlOffset + UTIL.levelIndex);
    }

     IEnumerator JustDelay(float delay){
          yield return new WaitForSeconds(delay);
          hintShown = false;
     }

    public void GameOver(){
        Debug.Log("GameOver");
        playerHolderToHide.SetActive(true);
        gameoverPanel.SetActive(true);
        // show the player to choose
        playerHolder.SetActive(true);
        playerHolderToHide.SetActive(false);
       // playerHolder.SetActive(true); // this is called in admob callback
        timer.StopTimer();
        canTap = false;
    }

    public void ResetToDefault(){
        animPlayed = false;
        gameoverPanel.SetActive(false);
        canTap = true;
        timer.SetTimer(awardTime);
        timer.RestTimer();
        timerAnim.SetTrigger("Default");
    }


    public void DisplayAd() {
            // Add a logic to check 
        if(googleAdScript == null)
            googleAdScript = GameObject.FindGameObjectWithTag("Google_Ad").GetComponent<admobdemo>();

        if(UTIL.canShowRewardAd)
        {
            if(Random.Range(0 , 10) > 2){
                   googleAdScript.ShowRewardVideo();
            }
        } else {
             UTIL.canShowRewardAd = false;
        }
           
    }
    public void AllLevelsCompleted()
    {
         SceneManager.LoadScene(UTIL.levelIndex+1);
    }

    void SaveLevelPrefs(){
         ++UTIL.levelIndex;
       
        if(UTIL.levelIndex >= UTIL.MAX_LEVEL){
            AllLevelsCompleted();
        }
        int totlLvlUnlocked = PlayerPrefs.GetInt(UTIL.PREFS_LVL_CLEARED,-1);
        
        if(totlLvlUnlocked >= UTIL.MAX_LEVEL || totlLvlUnlocked >= UTIL.levelIndex)
        {
            // do not save the level
           // Debug.LogError("totlLvlUnlocked is not correct "+totlLvlUnlocked);
            return;
        }
        Debug.Log("Saved Levle"+ UTIL.levelIndex);
        PlayerPrefs.SetInt(UTIL.PREFS_LVL_CLEARED , UTIL.levelIndex);
        PlayerPrefs.Save();
        
    }

    public void PlayerChooser(int index){
        currentSizeIndex = index;
        // change the player UI
        transform.localScale = Vector3.one*playerSize[currentSizeIndex];
        spriteRenderer.sprite = playerSprite[currentSizeIndex];
        playerHolder.SetActive(false);
        ResetToDefault();
    }

    public void Home()
    {
          SceneManager.LoadScene(1);
    }

    void ShowHints()
    {
        /*Add the logic to show hints*/
        string[] hints = {"Try Bumping around the edges" 
        , "tap rapidly if you feel stuck" , 
        "You know, You can change \n your avatar"
        ,"All you need to do is \n tap tap and tap"
        ,"wait for Gameover\n to Change your Avatar"};

        int index = Random.Range( 0 , hints.Length);
        hintText.text = hints[index];
        if(Random.Range( 0 , 10) > 4)
        hintTexAnim.SetTrigger("Appear");
        hintShown = true;
        StartCoroutine(JustDelay(1));
    }
    
}
