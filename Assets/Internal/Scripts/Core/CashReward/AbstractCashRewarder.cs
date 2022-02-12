namespace Core.CashRewardSystem
{

    public abstract class AbstractCashRewarder
    {
        protected float _reward;
        protected CashHandler _cashHandler;

        public AbstractCashRewarder(CashHandler cashHandler)
        {
            _cashHandler = cashHandler;
        }
    }

}