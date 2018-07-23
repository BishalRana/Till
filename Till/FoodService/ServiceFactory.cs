using System;
using Till.Data;

namespace Till.FoodService
{
    // uses of partial classes so that service type object could not to be instantiate from any other part.
    //only way to create service type object is using ServiceFactory class
    public partial class Service
    {
        public partial class ServiceFactory
        {
            //method to create service typed object like takeway,eatin
            public Service createSerivceType(string serviceName)
            {
                ServiceEnum serviceEnum;
                Service serviceType = null;
                if (Enum.TryParse<ServiceEnum>(serviceName, out serviceEnum))
                {
                    switch (serviceEnum)
                    {
                        case ServiceEnum.TAKEWAY:
                            serviceType = new Takeaway();
                            break;
                        case ServiceEnum.EATIN:
                            serviceType = new EatIn();
                            break;
                        default:
                            serviceType = null;
                            break;
                    }

                    return serviceType;
                }
                return null;
            }
        }
    }
}
