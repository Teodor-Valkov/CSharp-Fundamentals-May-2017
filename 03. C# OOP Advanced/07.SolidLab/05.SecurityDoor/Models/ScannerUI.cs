namespace _05.SecurityDoor
{
    public class ScannerUI : ISecurityKeyCardUI, ISecurityPinCodeUI
    {
        public string RequestKeyCard()
        {
            return "Key card scanned!";
        }

        public int RequestPinCode()
        {
            return 1234;
        }
    }
}