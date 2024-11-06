using UnityEngine;

public class GameManager : MonoBehaviour
{
    private IRules _rulesDefeats;
    private IRules _relesVictories;

    public void InitializeRules(IRules rulesDefeats, IRules relesVictories)
    {
        _rulesDefeats = rulesDefeats;
        _relesVictories = relesVictories;

        _relesVictories.Done += OnWin;
        _rulesDefeats.Done += OnDefeat;
    }

    private void Start()
    {
        _rulesDefeats.Start();
        _relesVictories.Start();
    }

    private void OnDestroy()
    {
        _rulesDefeats.Disable();
        _relesVictories.Disable();

        _relesVictories.Done -= OnWin;
        _rulesDefeats.Done -= OnDefeat;
    }

    private void OnDefeat() => Debug.Log("DEFEAT");

    private void OnWin() => Debug.Log("VICTORY");
}