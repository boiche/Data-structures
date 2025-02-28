using DesignPatterns.Creational.Builder.PhoneBuilders.Interfaces;
using DesignPatterns.Creational.Builder.Phones;

namespace DesignPatterns.Creational.Builder
{
    public class SamsungPhoneBuilder : IPhoneBuilder<Phone>
    {
        private readonly Phone _phone = new();
        public SamsungPhoneBuilder(SamsungModels model)
        {
            _phone.Brand = "Samsung";
            _phone.Model = model.ToString();
        }

        public Phone Build()
        {            
            return _phone;
        }

        public IPhoneBuilder<Phone> BuildCamera()
        {            
            switch (_phone.Model)
            {
                case "S9":
                    {
                        _phone.Camera.Resolution = 10;
                        _phone.Camera.Model = "Wide";
                        goto default;
                    };
                case "S9Plus":
                    {                        
                        _phone.Camera.Resolution = 12;
                        _phone.Camera.Model = "Telephoto";
                        goto default;
                    };
                default:
                    {
                        _phone.Camera.Brand = "Samsung";
                    }; break;
            }
            return this;
        }

        public IPhoneBuilder<Phone> BuildProcessor()
        {
            switch (_phone.Model)
            {
                case "S9":
                    {
                        _phone.CentralPowerUnit.Cores = 6;
                        _phone.CentralPowerUnit.Model = "Exynos 6810";
                        _phone.CentralPowerUnit.ClockSpeed = 1.6f;
                        goto default;
                    };
                case "S9Plus":
                    {
                        _phone.CentralPowerUnit.Cores = 8;
                        _phone.CentralPowerUnit.Model = "Exynos 9810";
                        _phone.CentralPowerUnit.ClockSpeed = 2.7f;
                        goto default;
                    };
                default:
                    {
                        _phone.CentralPowerUnit.Brand = "Samsung";                                                
                    } break;
            }
            return this;
        }

        public IPhoneBuilder<Phone> BuildOS()
        {
            switch (_phone.Model)
            {
                case "S9":
                    {
                        _phone.OperatingSystem.Bits = 32;                        
                        goto default;
                    }
                case "S9Plus":
                    {
                        _phone.OperatingSystem.Bits = 64;
                        goto default;
                    }
                default:
                    {
                        _phone.OperatingSystem.Name = "Android";
                        _phone.OperatingSystem.Version = "8.0";
                        _phone.OperatingSystem.Developer = "Google";
                    } break;
            }
            return this;
        }
    }
}
