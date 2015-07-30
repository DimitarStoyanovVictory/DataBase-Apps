namespace Problem4.ATMDatabase
{
    public class AtmMachine
    {
        private int _id;
        private string _cardNumber;

        public AtmMachine()
        {
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

        private string myVar;

        public string MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
        
    }
}
