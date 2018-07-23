using System;
using Till.Data;

namespace Till.ServiceInterface
{
    public interface IService
    {
        void Charge(Item item);
        void DeductCharge(Item item);
    }
}
