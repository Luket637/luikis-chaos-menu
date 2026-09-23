using UnityEngine;
using UnityEngine.XR;

namespace LukisChaosMenu
{
    public class Menu : MonoBehaviour
    {
        private InputDevice leftController;
        private bool lastYState;

        private GameObject menuPanel;

        public void Initialize()
        {
            CreateMenu();

            leftController =
                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

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
        }

        private void ToggleMenu()
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
        }
    }
}
