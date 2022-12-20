using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene
{
    private PhysicsScene scene;

    private GameScene() { } //prevent instantiation

    public static GameScene Create(GameObject player)
    {
        Scene scene = SceneManager.LoadScene("Background",
            new LoadSceneParameters()
            {
                loadSceneMode = LoadSceneMode.Additive,
                localPhysicsMode = LocalPhysicsMode.Physics3D
            });

        SceneManager.MoveGameObjectToScene(player, scene);

        return new()
        {
            scene = scene.GetPhysicsScene()
        };
    }

    public void Simulate(float step)
    {
        scene.Simulate(step);
    }
}
