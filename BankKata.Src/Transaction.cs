namespace BankKata.Src
{
    public class Transaction
    {
        private readonly decimal _amount;
        private readonly string _date;

        public Transaction(decimal amount, string date)
        {
            _amount = amount;
            _date = date;
        }

        protected bool Equals(Transaction other)
        {
            return _amount == other._amount && string.Equals(_date, other._date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Transaction) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_amount.GetHashCode()*397) ^ (_date != null ? _date.GetHashCode() : 0);
            }
        }
    }
}