using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using AutoMapper;



namespace Volunteer
{
    public class AutoMapping : Profile
    {
        
        public AutoMapping() {
            CreateMap<Student, StudentDTO>()
                        .ForMember(des => des.Name, opts => opts
                        .MapFrom(src => src.Person.Name))
                        .ForMember(des => des.Grade, opts => opts
                        .MapFrom(src => (int)(DateTime.Now.Year)-src.Grade.StartYear ))
                        .ForMember(des => des.NeighborhoodName, opts => opts
                        .MapFrom(src => src.Neighborhood.Description))
                        .ReverseMap();
            CreateMap<Family, FamilyDTO>()
                        .ForMember(des => des.NeighborhoodName, opts => opts
                         .MapFrom(src => src.Neighborhood.Description))
                        .ForMember(des => des.VolunteerType, opts => opts
                        .MapFrom(src => src.VolunteerType.Dscription))
                        .ForMember(des => des.Status, opts => opts
                        .MapFrom(src => src.Status.Description))
                        .ReverseMap();
        }
}}
