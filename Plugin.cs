using System;
using BepInEx;
using UnityEngine;
using System.Globalization;
using TMPro;
using System.Collections;
using GorillaLocomotion;

namespace GorillaVelocityChecker
{
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
    {
		static string currentVelocity;
        static float cooldown = 0.5f, lastTime = 0f;
		public static GameObject veloObj;
		static TextMeshPro veloText;
        static Renderer cooliCoolRenderer;

        void OnEnable()
		{
			HarmonyPatches.ApplyHarmonyPatches();
		}

		void OnDisable()
		{
			HarmonyPatches.RemoveHarmonyPatches();
		}

		void OnGameInitialized(object sender, EventArgs e) { }
        void Start()
		{
            veloObj = GameObject.CreatePrimitive(PrimitiveType.Quad);
            veloObj.name = "Velocity Object Self";
            veloObj.transform.SetParent(GTPlayer.Instance.headCollider.transform, worldPositionStays: false);
            veloObj.transform.localPosition = new Vector3(-0.6f, 0.6f, 1.6f);
            veloObj.transform.localRotation = Quaternion.identity;
            veloObj.transform.localScale = Vector3.one;

            Destroy(veloObj.GetComponent<Collider>());

            cooliCoolRenderer = veloObj.GetComponent<Renderer>();
            cooliCoolRenderer.material = new Material(Shader.Find("GUI/Text Shader"));

            veloText = veloObj.AddComponent<TextMeshPro>();
            veloText.alignment = TextAlignmentOptions.Center;
            veloText.transform.rotation = Quaternion.Euler(0, 180, 0);
            veloText.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            veloText.fontSize = 1;
            veloText.text = "0.0";
            veloText.color = Color.white;
        }

        void FixedUpdate()
		{
            if (lastTime >= cooldown)
			{
                Vector3 velocityVector = GorillaTagger.Instance.offlineVRRig.LatestVelocity();
                float speedMagnitude = velocityVector.magnitude;
                currentVelocity = speedMagnitude.ToString("F1", CultureInfo.InvariantCulture);
                lastTime = 0f;
            }

            veloText.text = $"Position: {veloObj.transform.localPosition.ToString("F1", CultureInfo.InvariantCulture)}\n Rotation: {veloObj.transform.localEulerAngles.ToString("F1", CultureInfo.InvariantCulture)}";

            lastTime += Time.deltaTime;
            if (veloObj.transform.localRotation != Quaternion.identity) veloObj.transform.localRotation = Quaternion.identity;
        }
    }
}
