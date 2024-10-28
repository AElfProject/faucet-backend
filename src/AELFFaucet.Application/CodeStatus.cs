namespace AELFFaucet
{
    public enum CodeStatus
    {
        Success = 1, //成功 (success)
        HadReceived = 2, //已领取过 (Already received)
        InvalidAddress = 3, //无效地址 (Invalid address)
        BalanceNotAdequate = 4, //余额不足 (Insufficient balance)
        SystemError = 5, //系统错误 (System error)
        InvalidPlatform = 6,
        InvalidCaptcha = 7
    }
}