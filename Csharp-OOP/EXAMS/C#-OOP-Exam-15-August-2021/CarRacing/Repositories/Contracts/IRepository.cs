namespace CarRacing.Repositories.Contracts
{
    using CarRacing.Models.Cars.Contracts;
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IReadOnlyCollection<T> Models { get; }

        void Add(T model);

        bool Remove(T model);

        T FindBy(string property);
    }
}
