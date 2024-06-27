namespace MultiplesOf3or5
{
    public class MultiplesOf3or5
    {
        private int _number;

        public MultiplesOf3or5(int number)
        {
            _number = number;
        }

        public int Sum()
        {
            if (_number < 0) return 0;

            int sum = 0;

            while (_number > 0)
            {
                _number--;
                if (_number % 3 == 0 || _number % 5 == 0)
                {
                    sum += _number;
                }
            }

            return sum;
        }
    }
}