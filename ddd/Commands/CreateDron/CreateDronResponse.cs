using System;

namespace ddd.Commands.CreateDron
{
    public class CreateDronResponse 
    {
        public Guid DronId { get; private set; }
        public string DronName { get; private set; }

        public static CreateDronResponse Create(Guid dronId, string name)
        {
            return new CreateDronResponse()
            {
                DronId = dronId,
                DronName = name
            };
        }
    }
}
