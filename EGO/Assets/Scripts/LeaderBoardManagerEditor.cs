#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LeaderboardManager))]
public class LeaderboardManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LeaderboardManager leaderboardManager = (LeaderboardManager)target;
        if (GUILayout.Button("Clear Leaderboard"))
        {
            leaderboardManager.ClearLeaderboard();
        }
    }
}
#endif
