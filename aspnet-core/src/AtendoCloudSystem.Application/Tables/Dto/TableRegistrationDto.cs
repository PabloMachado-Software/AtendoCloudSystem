using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace AtendoCloudSystem.Tables.Dto
{
    [AutoMapFrom(typeof(TableRegistration))]
    public class TableRegistrationDto : CreationAuditedEntityDto
    {
        public virtual Guid TableId { get; protected set; }

        public virtual long UserId { get; protected set; }

        public virtual string UserName { get; protected set; }

        public virtual string UserSurname { get; protected set; }
    }
}
