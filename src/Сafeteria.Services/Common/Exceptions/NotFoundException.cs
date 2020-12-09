using System;

namespace Сafeteria.Services.Common.Exeptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, string id)
            : base($"Failed to find {entityName} entity with Id: {id}")
        {

        }
    }
}