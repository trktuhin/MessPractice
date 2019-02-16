using AutoMapper;
using Mess.Models;
using Mess.Resources;

namespace Mess.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile(){
            ////Domain to Resource
            CreateMap<SmartMess, MessResource>();


            ////Resource to Domain
            CreateMap<MessResource, SmartMess>().ForMember(ms=>ms.MessId,opt=>opt.Ignore());

        }
    }
}