using System;

namespace _05.SecurityDoor
{
    public class PinCodeCheck : SecurityCheck, ISecurityPinCodeUI
    {
        private ISecurityPinCodeUI securityPinCode;

        public PinCodeCheck(ISecurityPinCodeUI securityPinCode)
        {
            this.securityPinCode = securityPinCode;
        }

        private bool IsValid(int pin)
        {
            return true;
        }

        public override bool ValidateUser()
        {
            int pin = securityPinCode.RequestPinCode();
            if (IsValid(pin))
            {
                return true;
            }

            return false;
        }

        public int RequestPinCode()
        {
            Console.WriteLine("Enter your pin code:");
            return int.Parse(Console.ReadLine());
        }
    }
}