using UnityEngine;
using UnityEngine.XR;

namespace LukisChaosMenu
{
    public class Menu : MonoBehaviour
    {
        private InputDevice leftController;
        private bool lastYState;

        private GameObject menuPanel;
        private GameObject titleObject;

        public void Initialize()
        {
            leftController =
                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

            CreateMenu();

            menuPanel.SetActive(false);
        }

        private void Update()
        {
            if (!leftController.isValid)
            {
                leftController =
                    InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
            }

            if (leftController.TryGetFeatureValue(
                CommonUsages.secondaryButton,
                out bool yPressed))
            {
                if (yPressed && !lastYState)
                {
                    ToggleMenu();
                }

                lastYState = yPressed;
            }
        }

        private void CreateMenu()
        {
            // Flat 3D panel
            menuPanel = GameObject.CreatePrimitive(
                PrimitiveType.Quad
            );

            menuPanel.name = "MenuPanel";

            menuPanel.transform.SetParent(transform);

            menuPanel.transform.localPosition =
                new Vector3(0f, 0f, 0.15f);

            menuPanel.transform.localRotation =
                Quaternion.identity;

            menuPanel.transform.localScale =
                new Vector3(0.5f, 0.3f, 1f);

            // Blue panel
            Renderer panelRenderer =
                menuPanel.GetComponent<Renderer>();

            panelRenderer.material.color =
                Color.blue;

            // Black title
            CreateTitle();
        }

        private void CreateTitle()
        {
            titleObject =
                new GameObject("Title");

            titleObject.transform.SetParent(
                menuPanel.transform
            );

            titleObject.transform.localPosition =
                new Vector3(0f, 0.05f, -0.01f);

            titleObject.transform.localRotation =
                Quaternion.identity;

            TextMesh text =
                titleObject.AddComponent<TextMesh>();

            text.text =
                "Lukis Chaos Menu";

            text.fontSize = 48;
            text.characterSize = 0.01f;

            text.anchor =
                TextAnchor.MiddleCenter;

            text.alignment =
                TextAlignment.Center;

            text.color =
                Color.black;
        }

        private void ToggleMenu()
        {
            menuPanel.SetActive(
                !menuPanel.activeSelf
            );
        }
    }
}
