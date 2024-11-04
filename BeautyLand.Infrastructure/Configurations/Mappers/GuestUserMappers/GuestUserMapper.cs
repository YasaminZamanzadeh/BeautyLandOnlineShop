using AutoMapper;
using BeautyLand.Application.Services.Site.GuestUsers.GuestUserProfile;
using BeautyLand.Domain.GuestUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyLand.Infrastructure.Configurations.Mappers.GuestUsers
{
    public class GuestUserMapper : Profile
    {

        public GuestUserMapper()
        {

            CreateMap<GuestUserDto, GuestUser>()
                                .ForMember(destinationMember => destinationMember.System,
                                memberOptions => memberOptions.MapFrom(sourceMember => new GuestUserSystem
                                {
                                    Family = sourceMember.System.Family,
                                    Model = sourceMember.System.Model,
                                    IsSpider = sourceMember.System.IsSpider
                                }))

                                .ForMember(destinationMember => destinationMember.Browser,
                               memberOptions => memberOptions.MapFrom
                               (sourceMember => new GuestUserSystemProfile
                               {
                                   Family = sourceMember.Browser.Family,
                                   Version = sourceMember.Browser.Version
                               }))

                                .ForMember(destinationMember => destinationMember.OperatingSystem,
                                memberOptions => memberOptions.MapFrom(sourceMember => new GuestUserSystemProfile
                                {
                                    Family = sourceMember.OperatingSystem.Family,
                                    Version = sourceMember.OperatingSystem.Version
                                }));
        }
    }
}