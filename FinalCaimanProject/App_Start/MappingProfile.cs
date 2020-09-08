using System;
using AutoMapper;
using FinalCaimanProject.DTOs;
using FinalCaimanProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalCaimanProject.VM;

namespace FinalCaimanProject.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Member, MembersDTO>();
            Mapper.CreateMap<MembersDTO, Member>();
            Mapper.CreateMap<NoteP, NotePDTO>();

            Mapper.CreateMap<NotePDTO, NoteP>();
            Mapper.CreateMap<Competence, CompetenceDTO>();
            Mapper.CreateMap<CompetenceDTO, Competence>();

            Mapper.CreateMap<SocialNetwork, SocialNetworkDTO>();
            Mapper.CreateMap<SocialNetworkDTO, SocialNetwork>();

            Mapper.CreateMap<Projet, ProjetDirectiveDTO>();
            Mapper.CreateMap<ProjetDirectiveDTO, Projet>();

            Mapper.CreateMap<Specialite, SpecialiteDTO>();
            Mapper.CreateMap<SpecialiteDTO, Specialite>();

            Mapper.CreateMap<Transport, TransportDTO>();
            Mapper.CreateMap<TransportDTO, Transport>();
            /* IQueryable<IdentityRole> MembersDTOs = null;*/
            Mapper.CreateMap<ProfilMemberDTO, Member>();
            Mapper.CreateMap<Member, ProfilMemberDTO>()
                .ForMember(dto => dto.SocialNetworks, opt => opt.MapFrom(x => x.SocialNetworks))
                .ForMember(dto => dto.Competences, opt => opt.MapFrom(x => x.Competences));
            Mapper.CreateMap<Projet, ProjetsDTO>()
                .ForMember(dto => dto.MembersDTOs, opt => opt.MapFrom(x => x.ProjetMembers.Select(y => y.Member).ToList()));
            Mapper.CreateMap<ProjetMember, MembersDTO>();
            Mapper.CreateMap<Projet, ProjetDetailDTO>()
                .ForMember(dto => dto.MembersDTOs, opt => opt.MapFrom(x => x.ProjetMembers.Select(y => y.Member).ToList()))
                .ForMember(dto => dto.NotePDTOs, opt => opt.MapFrom(x => x.NotePs));
            Mapper.CreateMap<Projet, NoteAddProDetailDTO>()
                .ForMember(dto => dto.NotePDTOs, opt => opt.MapFrom(x => x.NotePs));

        }
    }
}