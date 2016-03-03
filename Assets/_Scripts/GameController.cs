using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    //Private Instance Variables
    private int _scoreValue;
    private int _livesValue;
    private AudioSource _gameoverSound;

    // PUBLIC INSTANCE VARIABLES
    public int tankCount;
	public GameObject tank;

    //public Access methods
    public int ScoreValue
    {
        get
        {
            return _scoreValue;
        }
        set
        {
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;
        }
    }
    public int livesValue
    {
        get
        {
            return _livesValue;
        }
        set
        {
            //Debug.Log(this._livesValue);
            this._livesValue = value;

            if (this._livesValue <= 0)
            {
                this.LivesLabel.text = "Lives: 0";
                this._endGame();
            }
            else
            {
                this.LivesLabel.text = "Lives: " + this._livesValue;
            }
        }
    }

    //Public Instance Variables
    public PlayerController player;
    public EnemyController enemy;
    public Text LivesLabel;
    public Text ScoreLabel;
    //public Text GameOverLabel;
    //public Text HighscoreLabel;
    //public Button RestartButton;


    // Use this for initialization
    void Start () {
        initialize();
        this._GenerateTanks ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Private method
    private void initialize()
    {
        this._livesValue = 5;
        this._scoreValue = 0;
        //this.GameOverLabel.enabled = false;
        //this.HighscoreLabel.enabled = false;
        //this.RestartButton.gameObject.SetActive(false);
    }

    // generate Clouds
    private void _GenerateTanks() {
		for (int count=0; count < this.tankCount; count++) {
			Instantiate(tank);
		}
	}

    private void _endGame()
    {
        //this.HighscoreLabel.text = "Highscore : " + this._scoreValue;
        //this.GameOverLabel.enabled = true;
        //this.HighscoreLabel.enabled = true;
        this.LivesLabel.enabled = false;
        this.ScoreLabel.enabled = false;
        this.player.gameObject.SetActive(false);
        this.enemy.gameObject.SetActive(false);
        //this.RestartButton.gameObject.SetActive(true);
        this._gameoverSound.Play();
    }
}
