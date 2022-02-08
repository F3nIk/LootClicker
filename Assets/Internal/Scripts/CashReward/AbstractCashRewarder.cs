namespace Core.CashRewardSystem
{

    public abstract class AbstractCashRewarder
    {
        protected CashRewardDataBundle _dataBundle;
        protected CashHandler _cashHandler;

        public AbstractCashRewarder(CashRewardDataBundle dataBundle, CashHandler cashHandler)
        {
            _dataBundle = dataBundle;
            _cashHandler = cashHandler;
        }
    }

}