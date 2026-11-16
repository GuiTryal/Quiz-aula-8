using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class AbrirCena
{
    const string Caminho = "Assets/Scenes/Cena.unity";

    static AbrirCena()
    {
        EditorSceneManager.playModeStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(Caminho);

        EditorApplication.delayCall += () =>
        {
            if (!EditorApplication.isPlayingOrWillChangePlaymode &&
                string.IsNullOrEmpty(EditorSceneManager.GetActiveScene().path))
                EditorSceneManager.OpenScene(Caminho);
        };
    }
}
