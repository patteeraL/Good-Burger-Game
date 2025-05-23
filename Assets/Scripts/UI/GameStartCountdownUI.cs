using UnityEngine;
using TMPro;

public class GameStartCountdownUI : MonoBehaviour
{

    private const string NUMBER_POPUP = "NumberPopup";

    [SerializeField] private TextMeshProUGUI countdownText;

    private Animator animator;
    private int PreviousCountdownNumber;

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    private void Start(){
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e){
        if (KitchenGameManager.Instance.IsCountdownToStartActive()){
            Show();
        } else {
            Hide();
        }
    }

    private void Update(){
        int countdownNumber =  Mathf.CeilToInt(KitchenGameManager.Instance.GetCountdownToStartTimer());
        countdownText.text = countdownNumber.ToString();

        if (PreviousCountdownNumber != countdownNumber){
            PreviousCountdownNumber = countdownNumber;
            animator.SetTrigger(NUMBER_POPUP);
            SoundManager.Instance.PlayCountdownSound();
        }
    }

    private void Show(){
        gameObject.SetActive(true);
    }

    private void Hide(){
        gameObject.SetActive(false);
    }
    
}
