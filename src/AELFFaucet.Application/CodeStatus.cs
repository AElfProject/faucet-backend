namespace AELFFaucet
{
    public enum CodeStatus
    {
        Success = 1, // (success)
        HadReceived = 2, // (Already received)
        InvalidAddress = 3, // (Invalid address)
        BalanceNotAdequate = 4, // (Insufficient balance)
        SystemError = 5, // (System error)
        InvalidPlatform = 6,
        InvalidCaptcha = 7
    }
}