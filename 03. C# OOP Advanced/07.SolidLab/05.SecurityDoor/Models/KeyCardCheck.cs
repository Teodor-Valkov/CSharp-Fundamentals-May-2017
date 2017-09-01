using System;

namespace _05.SecurityDoor
{
    public class KeyCardCheck : SecurityCheck, ISecurityKeyCardUI
    {
        private ISecurityKeyCardUI securityKeyCard;

        public KeyCardCheck(ISecurityKeyCardUI securityUI)
        {
            this.securityKeyCard = securityUI;
        }

        private bool IsValid(string code)
        {
            return true;
        }

        public override bool ValidateUser()
        {
            string code = securityKeyCard.RequestKeyCard();
            if (IsValid(code))
            {
                return true;
            }

            return false;
        }

        public string RequestKeyCard()
        {
            Console.WriteLine("Slide your key card:");
            return Console.ReadLine();
        }
    }
}