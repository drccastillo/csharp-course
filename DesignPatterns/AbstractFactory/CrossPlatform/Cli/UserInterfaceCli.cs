using System;
using CrossPlatform.Services;

namespace CrossPlatform.Cli
{
    public class UserInterfaceCli
    {
        private readonly UserInterfaceService _service;

        public UserInterfaceCli(UserInterfaceService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Run(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: <program> <platform>");
                Console.WriteLine($"Supported platforms: {string.Join(", ", _service.GetSupportedPlatforms())}");
                return;
            }

            var platform = args[0];
            try
            {
                _service.CreateUserInterface(platform);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Supported platforms: {string.Join(", ", _service.GetSupportedPlatforms())}");
            }
        }
    }
}