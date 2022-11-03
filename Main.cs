using HarmonyLib;
using SALT;
using Console = SALT.Console.Console;
using SALT.Extensions;
using SALT.Registries;
using SALT.Utils;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;
using UnityEngine.SceneManagement;

namespace PolkaLevel
{
    public class Main : ModEntryPoint
    {
        public static Level POLKA;
        public static GameObject GenericButton;

        public override void PreLoad()
        {
            POLKA = LevelRegistry.CreateLevelId("POLKA");
            LevelRegistry.RegisterSceneCreationEvent(POLKA, (Scene scene, GameObject mainLevelStuff) =>
            {
                GameObject block = scene.Instantiate(SAObjects.Block);
                block.transform.position = new Vector3(-10, -1);
                GameObject block2 = scene.Instantiate(SAObjects.Block);
                block2.transform.position = new Vector3(20, -1);
                GameObject block3 = scene.Instantiate(SAObjects.Block);
                block3.transform.position = new Vector3(15, -3);
                GameObject block4 = scene.Instantiate(SAObjects.Block);
                block4.transform.position = new Vector3(25, -3);
                GameObject ground = scene.Instantiate(SAObjects.Block);
                ground.transform.position = new Vector3Int(0,-13,0);
                ground.transform.localScale = new Vector3Int(100,10,100);
                Material black = new Material(Shader.Find("Standard"));
                black.name = "BlackMat";
                black.color = Color.black;
                ground.GetComponentInChildren<MeshRenderer>().sharedMaterial = black;

                if (GenericButton != null) GenericButton.SetActive(false);
            });
            Callbacks.OnMainMenuLoaded += MainMenu;
            Callbacks.OnLevelLoaded += Level;
        }

        public void MainMenu()
        {
            if (GenericButton != null) GenericButton.SetActive(true);
            else
            {
                GenericButton = SAObjects.ModdedLevelButton.InstantiateInactive(true);
                GenericButton.name = "PolkaButton";
                GenericButton.transform.parent = null;
                GenericButton.transform.position = new Vector3(-18.25f, -2.75f, 0);
                GenericButton.GetComponent<ModdedLevelButtonScript>().levelEnum = POLKA;
                GenericButton.SetActive(true);
            }
        }

        public void Level()
        {
            if (GenericButton != null) GenericButton.SetActive(false);
        }
    }
}