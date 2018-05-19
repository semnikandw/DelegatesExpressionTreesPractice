using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesExpressionTreesPractice
{
    class Account
    {
        // Объявляем делегат
        public delegate void AccountStateHandler(string message);
        // Создаем переменную делегата
        AccountStateHandler _ourDelegate;

        // Регистрируем делегат
        // Регистрируем делегат
        public void RegisterHandler(AccountStateHandler del)
        {
            Delegate mainDel = System.Delegate.Combine(del, _ourDelegate);
            _ourDelegate = mainDel as AccountStateHandler;
        }
        // Отмена регистрации делегата
        public void UnregisterHandler(AccountStateHandler del)
        {
            Delegate mainDel = System.Delegate.Remove(_ourDelegate, del);
            _ourDelegate = mainDel as AccountStateHandler;
        }

        int _sumVar; // Переменная для хранения суммы

        public Account(int sumVar)
        {
            _sumVar = sumVar;
        }

        public int CurrentSumVar
        {
            get { return _sumVar; }
        }

        public void Put(int sum)
        {
            _sumVar += sum;
        }

        public void Withdraw(int sum)
        {
            if (sum <= _sumVar)
            {
                _sumVar -= sum;

                if (_ourDelegate != null)
                    _ourDelegate($"Сумма {sum} снята со счета");
            }
            else
            {
                if (_ourDelegate != null)
                    _ourDelegate("Недостаточно денег на счете");
            }
        }
    }
}
