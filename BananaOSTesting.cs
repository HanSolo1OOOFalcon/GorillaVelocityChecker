using GorillaVelocityChecker;
using System.Text;
using UnityEngine;

namespace BananaOS.Pages
{
    public class ExamplePage : WatchPage
    {
        //What will be shown on the main menu if DisplayOnMainMenu is set to true
        public override string Title => "Example";

        //Enabling will display your page on the main menu if you're nesting pages you should set this to false
        public override bool DisplayOnMainMenu => true;

        //This method will be ran after the watch is completely setup
        public override void OnPostModSetup()
        {
            //max selection index so the indicator stays on the screen
            selectionHandler.maxIndex = 11;
        }

        //What you return is what is drawn to the watch screen the screen will be updated everytime you press a button
        public override string OnGetScreenContent()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<color=yellow>==</color> Example <color=yellow>==</color>");
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(0, "Y+"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(1, "Y-"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(2, "X+"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(3, "X-"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(4, "Z+"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(5, "Z-"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(6, "RY+"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(7, "RY-"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(8, "RX+"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(9, "RX-"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(10, "RZ+"));
            stringBuilder.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(11, "RZ-"));
            return stringBuilder.ToString();
        }

        public override void OnButtonPressed(WatchButtonType buttonType)
        {
            switch (buttonType)
            {
                case WatchButtonType.Up:
                    selectionHandler.MoveSelectionUp();
                    break;

                case WatchButtonType.Down:
                    selectionHandler.MoveSelectionDown();
                    break;

                case WatchButtonType.Enter:
                    if (selectionHandler.currentIndex == 0)
                    {
                        GorillaVelocityChecker.Plugin.veloObj.transform.localPosition += new Vector3(0f, 0.1f, 0f);
                        return;
                    }
                    if (selectionHandler.currentIndex == 1)
                    {
                        GorillaVelocityChecker.Plugin.veloObj.transform.localPosition -= new Vector3(0f, 0.1f, 0f);
                        return;
                    }
                    if (selectionHandler.currentIndex == 2)
                    {
                        GorillaVelocityChecker.Plugin.veloObj.transform.localPosition += new Vector3(0.1f, 0f, 0f);
                        return;
                    }
                    if (selectionHandler.currentIndex == 3)
                    {
                        GorillaVelocityChecker.Plugin.veloObj.transform.localPosition -= new Vector3(0.1f, 0f, 0f);
                        return;
                    }
                    if (selectionHandler.currentIndex == 4)
                    {
                        GorillaVelocityChecker.Plugin.veloObj.transform.localPosition += new Vector3(0f, 0f, 0.1f);
                        return;
                    }
                    if (selectionHandler.currentIndex == 5)
                    {
                        GorillaVelocityChecker.Plugin.veloObj.transform.localPosition -= new Vector3(0f, 0f, 0.1f);
                        return;
                    }
                    if (selectionHandler.currentIndex == 6)
                    {
                        GorillaVelocityChecker.Plugin.veloObj.transform.localRotation *= Quaternion.Euler(0f, 10f, 0f);
                        return;
                    }
                    if (selectionHandler.currentIndex == 7)
                    {
                        GorillaVelocityChecker.Plugin.veloObj.transform.localRotation *= Quaternion.Euler(0f, -10f, 0f);
                        return;
                    }
                    if (selectionHandler.currentIndex == 8)
                    {
                        GorillaVelocityChecker.Plugin.veloObj.transform.localRotation *= Quaternion.Euler(10f, 0f, 0f);
                        return;
                    }
                    if (selectionHandler.currentIndex == 9)
                    {
                        GorillaVelocityChecker.Plugin.veloObj.transform.localRotation *= Quaternion.Euler(-10f, 0f, 0f);
                        return;
                    }
                    if (selectionHandler.currentIndex == 10)
                    {
                        GorillaVelocityChecker.Plugin.veloObj.transform.localRotation *= Quaternion.Euler(0f, 0f, 10f);
                        return;
                    }
                    if (selectionHandler.currentIndex == 11)
                    {
                        GorillaVelocityChecker.Plugin.veloObj.transform.localRotation *= Quaternion.Euler(0f, 0f, -10f);
                        return;
                    }
                    break;

                //It is recommended that you keep this unless you're nesting pages if so you should use the SwitchToPage method
                case WatchButtonType.Back:
                    ReturnToMainMenu();
                    break;
            }
        }
    }
}