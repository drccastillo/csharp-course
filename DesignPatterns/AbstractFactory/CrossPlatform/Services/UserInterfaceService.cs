using System;
using System.Collections.Generic;
using System.Linq;
using CrossPlatform.Client;
using CrossPlatform.Interfaces;

namespace CrossPlatform.Services
{
    public class UserInterfaceService
    {
        private readonly Dictionary<string, IUserInterfaceComponentFactory> _factories;

        public UserInterfaceService(IEnumerable<IUserInterfaceComponentFactory> factories)
        {
            _factories = factories.ToDictionary(
                f => f.GetPlatformName(),
                StringComparer.OrdinalIgnoreCase);
        }

        public IEnumerable<string> GetSupportedPlatforms() => _factories.Keys;

        public void CreateUserInterface(string platform)
        {
            if (!_factories.TryGetValue(platform, out var factory))
            {
                throw new NotSupportedException($"Platform '{platform}' is not supported.");
            }

            var app = new UserInterfaceApplication(factory);
            app.CreateLoginForm();
        }
    }
}