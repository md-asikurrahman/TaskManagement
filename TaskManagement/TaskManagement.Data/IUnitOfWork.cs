using System;

namespace TaskManagement.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
