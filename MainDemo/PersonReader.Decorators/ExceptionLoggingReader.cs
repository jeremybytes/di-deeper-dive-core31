using Common;
using PeopleViewer.Logging;
using System;
using System.Collections.Generic;

namespace PersonReader.Decorators
{
    public class ExceptionLoggingReader : IPersonReader
    {
        IPersonReader _wrappedReader;
        ILogger _logger;

        public ExceptionLoggingReader(IPersonReader wrappedReader, 
            ILogger logger)
        {
            _wrappedReader = wrappedReader;
            _logger = logger;
        }

        public IReadOnlyCollection<Person> GetPeople()
        {
            try
            {
                return _wrappedReader.GetPeople();
            }
            catch (Exception ex)
            {
                _logger?.LogException(ex);
                throw;
            }
        }

        public Person GetPerson(int id)
        {
            try
            {
                return _wrappedReader.GetPerson(id);
            }
            catch (Exception ex)
            {
                _logger?.LogException(ex);
                throw;
            }
        }
    }
}
