using Common;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PersonReader.Decorators
{
    public class RetryReader : IPersonReader
    {
        private IPersonReader _wrappedReader;
        private TimeSpan _retryDelay;
        private int _retryCount = 0;

        public RetryReader(IPersonReader wrappedReader,
            TimeSpan retryDelay)
        {
            _wrappedReader = wrappedReader;
            _retryDelay = retryDelay;
        }

        public IReadOnlyCollection<Person> GetPeople()
        {
            _retryCount++;
            try
            {
                var people = _wrappedReader.GetPeople();
                _retryCount = 0;
                return people;
            }
            catch (Exception)
            {
                if (_retryCount >= 3)
                    throw;
                Thread.Sleep(_retryDelay);
                return this.GetPeople();
            }
        }

        public Person GetPerson(int id)
        {
            _retryCount++;
            try
            {
                var person = _wrappedReader.GetPerson(id);
                _retryCount = 0;
                return person;
            }
            catch (Exception)
            {
                if (_retryCount >= 3)
                    throw;
                Thread.Sleep(_retryDelay);
                return this.GetPerson(id);
            }
        }
    }
}
