using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace AtendoCloudSystem.Menus.Dto
{
    [AutoMapFrom(typeof(MenuRegistration))]
    public class MenuRegistrationDto : CreationAuditedEntityDto
    {
        public virtual Guid MenuId { get; protected set; }

        public virtual long UserId { get; protected set; }

        public virtual string UserName { get; protected set; }

        public virtual string UserSurname { get; protected set; }
    }
}
