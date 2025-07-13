using AutoMapper;
using DMS.Data.EF.Models;
using DMS.Data.EF.Query;

namespace DMS.Data.EF.Mapping;

internal class DMSManualMapping : Profile
{
    public DMSManualMapping()
    {
        // < From , To >
        CreateMap<DmManualDto, DmManual>()
        .ForMember(d => d.ManualCode, opt => opt.MapFrom(src => src.ManualCode))
        .ForMember(d => d.ManualLevel, opt => opt.MapFrom(src => src.ManualLevel))
        .ForMember(d => d.ManualName, opt => opt.MapFrom(src => src.ManualName))
        .ForMember(d => d.DmManualCategoryId, opt => opt.MapFrom(src => src.DmManualCategoryId))
        .ForMember(d => d.CanExport, opt => opt.MapFrom(src => src.CanExport))
        .ForMember(d => d.Comments, opt => opt.MapFrom(src => src.Comments))
        .ForMember(d => d.VesselId, opt => opt.MapFrom(src => src.VesselId))
        .ForMember(d => d.Origin, opt => opt.MapFrom(src => src.Origin))
        .ForMember(d => d.ParentId, opt => opt.MapFrom(src => src.ParentId))
        .ForMember(d => d.ManualLevel, opt => opt.MapFrom(src => src.ManualLevel))
        .ForMember(d => d.ModifiedBy, opt => opt.MapFrom(src => src.ModifiedBy))
        .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(src => src.ModifiedDate))
        .ForMember(d => d.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
        .ForMember(d => d.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
        .ForMember(d => d.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted));
    }
}
